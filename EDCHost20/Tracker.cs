using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

using OpenCvSharp;
using System.Threading;
using OpenCvSharp.Extensions;
using Point2i = OpenCvSharp.Point;
using Cuda = OpenCvSharp.Cuda;

using System.Net;

namespace EDC20HOST
{
    public partial class Tracker : Form
    {
        private MyFlags flags = null;
        private VideoCapture capture = null;
        //private Thread threadCamera = null;
        private Point2f[] ptsShowCorners = null;
        private DateTime timeCamNow;
        private DateTime timeCamPrev;
        private TextBox[] tbsPoint = null;
        private CoordinateConverter cc;
        private Localiser localiser;
        private Point2i car1;
        private Point2i car2;
        private Game game;

        private CaiNetwork.CaiServer server;

        public Dot CarALocation()
        {
            Dot D = new Dot();
            D.x = car1.X;
            D.y = car1.Y;
            return D;
        }
        public Dot CarBLocation()
        {
            Dot D = new Dot();
            D.x = car2.X;
            D.y = car2.Y;
            return D;
        }

        public Tracker()
        {
            InitializeComponent();

            InitialCaiServer();
            MessageBox.Show("IP is "+ server.getUsedIP().ToString()+"  port is "+ server.getPort().ToString());

            tbsPoint = new TextBox[] { tbPoint1, tbPoint2, tbPoint3, tbPoint4 };
            // Init
            flags = new MyFlags();
            flags.Init();
            flags.Start();
            ptsShowCorners = new Point2f[4];
            cc = new CoordinateConverter(flags);
            localiser = new Localiser();
            capture = new VideoCapture();
           // threadCamera = new Thread(CameraReading);
            capture.Open(0);
            timeCamNow = DateTime.Now;
            timeCamPrev = timeCamNow;

            car1 = new Point2i();
            car2 = new Point2i();

            buttonStart.Enabled = true;
            buttonPause.Enabled = false;
            buttonAFoul.Enabled = buttonBFoul.Enabled = false;

            Game.LoadMap();
            game = new Game();

            if (capture.IsOpened())
            {
                capture.FrameWidth = flags.cameraSize.Width;
                capture.FrameHeight = flags.cameraSize.Height;
                capture.ConvertRgb = true;
                timer100ms.Interval = 90;
                timer100ms.Start();
                Cv2.NamedWindow("binary");
            }

        }

        private void Flush() 
        {
            CameraReading();
            lock (flags)
            {
                game.CarA.Pos.x = flags.posCarA.X;
                game.CarA.Pos.y = flags.posCarA.Y;
                game.CarB.Pos.x = flags.posCarB.X;
                game.CarB.Pos.y = flags.posCarB.Y;
            }
            game.Update();
            byte[] Message = game.PackMessage();
            string a = BitConverter.ToString(Message, 0);
            labelMsg.Text = a;
            labelRound.Text = Convert.ToString(game.Round);
            CaiZhuo_SendBytesViaNet(Message);
            ShowMessage(Message);
        }

        private void CameraReading()
        {
            bool control = false;
            lock(flags)
            {
                control = flags.running;
            }
            if(control)
            {
                using (Mat videoFrame = new Mat())
                using (Mat showFrame = new Mat())
                {
                    if (capture.Read(videoFrame))
                    {
                        lock (flags)
                        {
                            localiser.Locate(videoFrame, flags);
                        }
                        localiser.GetLocations(out car1, out car2);
                        lock (flags)
                        {
                            if (flags.calibrated)
                            {
                                Point2f[] car12 = { car1, car2 };
                                Point2f[] carAB = cc.CameraToLogic(car12);
                                flags.posCarA = carAB[0];
                                flags.posCarB = carAB[1];
                            }
                            else
                            {
                                flags.posCarA = car1;
                                flags.posCarB = car2;
                            }
                        }
                        timeCamNow = DateTime.Now;
                        TimeSpan timeProcess = timeCamNow - timeCamPrev;
                        timeCamPrev = timeCamNow;
                        Cv2.Resize(videoFrame, showFrame, flags.showSize, 0, 0, InterpolationFlags.Nearest);
                        BeginInvoke(new Action<TimeSpan>(UpdateProcessTime), timeProcess);
                        BeginInvoke(new Action<Image>(UpdateCameraPicture), BitmapConverter.ToBitmap(showFrame));
                    }
                    lock (flags)
                    {
                        control = flags.running;
                    }
                }
            }
        }

        private void UpdateProcessTime(TimeSpan time)
        {
            string timeToDisp = time.TotalMilliseconds.ToString();
            tbInfo.Text = timeToDisp + "ms";
        }

        private void UpdateCameraPicture(Image img)
        {
            pbCamera.Image = img;
        }

        private void InitialCaiServer()
        {
            server = new CaiNetwork.CaiServer(CaiNetwork.util.getIPV4());//不指定端口，CaiServer会自行寻找空闲的端口；由util自动寻找本机的IPV4地址
            /*
             * 如果需要知道使用的IP和端口
             * 可以调用server.getUsedIP(),server.getPort()
             */
        }

        private void CaiZhuo_SendBytesViaNet(byte[] Message)
        {
            server.GroupSend(Message);
        }

        private void Tracker_FormClosed(object sender, FormClosedEventArgs e)
        {
            server.DisconnectAll();
            lock (flags)
            {
                flags.End();
            }
            timer100ms.Stop();
            //threadCamera.Join();
            capture.Release();

            string arrStr = String.Format("{0} {1} {2} {3} {4} {5} {6} {7}", flags.configs.hue1Lower, flags.configs.hue1Upper, flags.configs.hue2Lower
            , flags.configs.hue2Upper, flags.configs.saturation1Lower, flags.configs.saturation2Lower
            , flags.configs.valueLower, flags.configs.areaLower);
            File.WriteAllText("data.txt", arrStr);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lock(flags)
            {
                flags.clickCount = 0;
                flags.calibrated = false;
            }

            foreach(TextBox tb in tbsPoint)
            {
                tb.Text = "";
            }
        }

        private void pbCamera_MouseClick(object sender, MouseEventArgs e)
        {
            int widthView = pbCamera.Width;
            int heightView = pbCamera.Height;

            int xMouse = e.X;
            int yMouse = e.Y;

            int idx = -1;
            lock (flags)
            {
                if (flags.clickCount < 4) idx = flags.clickCount++;
            }

            if (idx == -1) return;

            if (xMouse >= 0 && xMouse < widthView && yMouse >= 0 && yMouse < heightView)
            {
                ptsShowCorners[idx].X = xMouse;
                ptsShowCorners[idx].Y = yMouse;

                tbsPoint[idx].Text = String.Format("({0},{1})", xMouse, yMouse);
                if (idx == 3) cc.UpdateCorners(ptsShowCorners, flags);
            }
        }

        private void nudHue1L_ValueChanged(object sender, EventArgs e)
        {
            lock (flags) flags.configs.hue1Lower = (int)nudHue1L.Value;
        }

        private void nudHue1H_ValueChanged(object sender, EventArgs e)
        {
            lock (flags) flags.configs.hue1Upper = (int)nudHue1H.Value;
        }

        private void nudHue2L_ValueChanged(object sender, EventArgs e)
        {
            lock (flags) flags.configs.hue2Lower = (int)nudHue2L.Value;
        }

        private void nudHue2H_ValueChanged(object sender, EventArgs e)
        {
            lock (flags) flags.configs.hue2Upper = (int)nudHue2H.Value;
        }

        private void nudSat1L_ValueChanged(object sender, EventArgs e)
        {
            lock (flags) flags.configs.saturation1Lower = (int)nudSat1L.Value;
        }

        private void nudSat2L_ValueChanged(object sender, EventArgs e)
        {
            lock (flags) flags.configs.saturation2Lower = (int)nudSat2L.Value;
        }

        private void nudValueL_ValueChanged(object sender, EventArgs e)
        {
            lock (flags) flags.configs.valueLower = (int)nudValueL.Value;
        }

        private void nudAreaL_ValueChanged(object sender, EventArgs e)
        {
            lock (flags) flags.configs.areaLower = (int)nudAreaL.Value;
        }

        private void timer100ms_Tick(object sender, EventArgs e)
        {
            Flush();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            game.Start();
            buttonPause.Enabled = true;
            buttonStart.Enabled = false;
            buttonAFoul.Enabled = buttonBFoul.Enabled = true;
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            game.Pause();
            buttonPause.Enabled = false;
            buttonStart.Enabled = true;
            buttonAFoul.Enabled = buttonBFoul.Enabled = false;
        }

        private void ShowMessage(byte[] M) //通过Message显示信息到UI上
        {
            int x, y;
            x = ((M[2] & 0x80) << 1) + M[5];
            y = ((M[2] & 0x40) << 2) + M[6];
            labelALocation.Text = $"({x}, {y})";
            x = ((M[2] & 0x20) << 3) + M[7];
            y = ((M[2] & 0x10) << 4) + M[8];
            labelBLocation.Text = $"({x}, {y})";
            int tx, ty;
            x = ((M[2] & 0x08) << 5) + M[11];
            y = ((M[2] & 0x04) << 6) + M[12];
            tx = ((M[2] & 0x02) << 7) + M[13];
            ty = ((M[2] & 0x01) << 8) + M[14];
            label1L.Text = $"({x}, {y}) -> ({tx}, {ty})/{M[9] & 0x03}";
            x = ((M[3] & 0x80) << 1) + M[15];
            y = ((M[3] & 0x40) << 2) + M[16];
            tx = ((M[3] & 0x20) << 3) + M[17];
            ty = ((M[3] & 0x10) << 4) + M[18];
            label2L.Text = $"({x}, {y}) -> ({tx}, {ty})/{(M[10] & 0xC0) >> 6}";
            x = ((M[3] & 0x08) << 5) + M[19];
            y = ((M[3] & 0x04) << 6) + M[20];
            tx = ((M[3] & 0x02) << 7) + M[21];
            ty = ((M[3] & 0x01) << 8) + M[22];
            label3L.Text = $"({x}, {y}) -> ({tx}, {ty})/{(M[10] & 0x30) >> 4}";
            x = ((M[4] & 0x80) << 1) + M[23];
            y = ((M[4] & 0x40) << 2) + M[24];
            tx = ((M[4] & 0x20) << 3) + M[25];
            ty = ((M[4] & 0x10) << 4) + M[26];
            label4L.Text = $"({x}, {y}) -> ({tx}, {ty})/{(M[10] & 0x0C) >> 2}";
            x = ((M[4] & 0x08) << 5) + M[27];
            y = ((M[4] & 0x04) << 6) + M[28];
            tx = ((M[4] & 0x02) << 7) + M[29];
            ty = ((M[4] & 0x01) << 8) + M[30];
            label5L.Text = $"({x}, {y}) -> ({tx}, {ty})/{(M[10] & 0x03)}";
            labelValidP.Text = $"{M[9] >> 2}";
            labelRound.Text = $"{((M[0] & 0x3F) << 8) + M[1]}";
            labelState.Text = $"{((M[0] & 0xC0) >> 6)}";
            labelAScore.Text = $"{(M[33] << 8) + M[34]}/{M[31]}";
            labelBScore.Text = $"{(M[35] << 8) + M[36]}/{M[32]}";
        }

        private void buttonAFoul_Click(object sender, EventArgs e)
        {
            game.CarFoul(Camp.CampA);
            buttonStart.Enabled = true;
            buttonPause.Enabled = false;
            buttonAFoul.Enabled = buttonBFoul.Enabled = false;
        }

        private void buttonBFoul_Click(object sender, EventArgs e)
        {
            game.CarFoul(Camp.CampB);
            buttonStart.Enabled = true;
            buttonPause.Enabled = false;
            buttonAFoul.Enabled = buttonBFoul.Enabled = false;
        }

        private void Tracker_Load(object sender, EventArgs e)
        {
            if (File.Exists("data.txt"))
            {
                FileStream fsRead = new FileStream("data.txt", FileMode.Open);
                int fsLen = (int)fsRead.Length;
                byte[] heByte = new byte[fsLen];
                int r = fsRead.Read(heByte, 0, heByte.Length);
                string myStr = System.Text.Encoding.UTF8.GetString(heByte);
                string[] str = myStr.Split(' ');
                nudHue1L.Value = (flags.configs.hue1Lower = Convert.ToInt32(str[0]));
                nudHue1H.Value = (flags.configs.hue1Upper = Convert.ToInt32(str[1]));
                nudHue2L.Value = (flags.configs.hue2Lower = Convert.ToInt32(str[2]));
                nudHue2H.Value = (flags.configs.hue2Upper = Convert.ToInt32(str[3]));
                nudSat1L.Value = (flags.configs.saturation1Lower = Convert.ToInt32(str[4]));
                nudSat2L.Value = (flags.configs.saturation2Lower = Convert.ToInt32(str[5]));
                nudValueL.Value = (flags.configs.valueLower = Convert.ToInt32(str[6]));
                nudAreaL.Value = (flags.configs.areaLower = Convert.ToInt32(str[7]));
                fsRead.Close();
            }

        }
    }

    public class MyFlags
    {
        public bool running;
        public bool calibrated;
        public int clickCount;
        public struct LocConfigs
        {
            public int hue1Lower;
            public int hue1Upper;
            public int hue2Lower;
            public int hue2Upper;
            public int saturation1Lower;
            public int saturation2Lower;
            public int valueLower;
            public int areaLower;
        }
        public LocConfigs configs;
        public OpenCvSharp.Size showSize;
        public OpenCvSharp.Size cameraSize;
        public OpenCvSharp.Size logicSize;
        public Point2i posCarA;
        public Point2i posCarB;

        public void Init()
        {
            running = false;
            calibrated = false;
            configs = new LocConfigs();
            posCarA = new Point2i();
            posCarB = new Point2i();
            showSize = new OpenCvSharp.Size(640, 480);
            cameraSize = new OpenCvSharp.Size(1280, 960);
            logicSize = new OpenCvSharp.Size(300, 300);
            clickCount = 0;
        }

        public void Start()
        {
            running = true;
        }

        public void End()
        {
            running = false;
        }
    }

    public class CoordinateConverter : IDisposable
    {
        private Mat cam2logic;
        private Mat show2cam;
        private Point2f[] logicCorners;
        private Point2f[] camCorners;
        private Point2f[] showCorners;

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                ((IDisposable)(cam2logic)).Dispose();
                ((IDisposable)(show2cam)).Dispose();
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public CoordinateConverter(MyFlags myFlags)
        {
            camCorners = new Point2f[4];
            logicCorners = new Point2f[4];
            showCorners = new Point2f[4];
            cam2logic = new Mat();
            show2cam = new Mat();

            logicCorners[0].X = 0;
            logicCorners[0].Y = 0;
            logicCorners[1].X = myFlags.logicSize.Width;
            logicCorners[1].Y = 0;
            logicCorners[2].X = 0;
            logicCorners[2].Y = myFlags.logicSize.Height;
            logicCorners[3].X = myFlags.logicSize.Width;
            logicCorners[3].Y = myFlags.logicSize.Height;

            showCorners[0].X = 0;
            showCorners[0].Y = 0;
            showCorners[1].X = myFlags.showSize.Width;
            showCorners[1].Y = 0;
            showCorners[2].X = 0;
            showCorners[2].Y = myFlags.showSize.Height;
            showCorners[3].X = myFlags.showSize.Width;
            showCorners[3].Y = myFlags.showSize.Height;

            camCorners[0].X = 0;
            camCorners[0].Y = 0;
            camCorners[1].X = myFlags.cameraSize.Width;
            camCorners[1].Y = 0;
            camCorners[2].X = 0;
            camCorners[2].Y = myFlags.cameraSize.Height;
            camCorners[3].X = myFlags.cameraSize.Width;
            camCorners[3].Y = myFlags.cameraSize.Height;

            show2cam = Cv2.GetPerspectiveTransform(showCorners, camCorners);
        }

        public void UpdateCorners(Point2f[] corners, MyFlags myFlags)
        {
            if (corners == null) return;
            if (corners.Length != 4) return;
            else showCorners = corners;

            camCorners = Cv2.PerspectiveTransform(showCorners, show2cam);
            cam2logic = Cv2.GetPerspectiveTransform(camCorners, logicCorners);
            myFlags.calibrated = true;
        }

        public Point2f[] ShowToCamera(Point2f[] ptsShow)
        {
            return Cv2.PerspectiveTransform(ptsShow, show2cam);
        }

        public Point2f[] CameraToLogic(Point2f[] ptsCamera)
        {
            return Cv2.PerspectiveTransform(ptsCamera, cam2logic);
        }
    }

    public class Localiser
    {
        private List<Point2i> centres1;
        private List<Point2i> centres2;

        public Localiser()
        {
            centres1 = new List<Point2i>();
            centres2 = new List<Point2i>();
            
        }

        public void GetLocations(out Point2i pt1, out Point2i pt2)
        {
            if (centres1.Count != 0)
            {
                pt1 = centres1[0];
                centres1.Clear();
            }
            else pt1 = new Point2i(-1,-1);
            if (centres2.Count != 0)
            {
                pt2 = centres2[0];
                centres2.Clear();
            }
            else pt2 = new Point2i(-1, -1);
        }

        public void Locate(Mat mat, MyFlags localiseFlags)
        {
            if (mat == null || mat.Empty()) return;
            if (localiseFlags == null) return;
            using (Mat hsv = new Mat())
            using (Mat car1 = new Mat())
            using (Mat car2 = new Mat())
            using (Mat merged = new Mat())
            using (Mat black = new Mat(mat.Size(), MatType.CV_8UC1))
            {
                Cv2.CvtColor(mat, hsv, ColorConversionCodes.RGB2HSV);
                MyFlags.LocConfigs configs = localiseFlags.configs;
                Cv2.InRange(hsv,
                    new Scalar(configs.hue1Lower, configs.saturation1Lower, configs.valueLower),
                    new Scalar(configs.hue1Upper, 255, 255),
                    car1);
                Cv2.InRange(hsv,
                    new Scalar(configs.hue2Lower, configs.saturation2Lower, configs.valueLower),
                    new Scalar(configs.hue2Upper, 255, 255),
                    car2);

                Point2i[][] contours1, contours2;

                contours1 = Cv2.FindContoursAsArray(car1, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
                contours2 = Cv2.FindContoursAsArray(car2, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
                
                foreach (Point2i[] c1 in contours1)
                {
                    Point2i centre = new Point2i();
                    Moments moments = Cv2.Moments(c1);
                    centre.X = (int)(moments.M10 / moments.M00);
                    centre.Y = (int)(moments.M01 / moments.M00);
                    double area = moments.M00;
                    if (area < configs.areaLower) continue;
                    centres1.Add(centre);
                }
                foreach (Point2i[] c2 in contours2)
                {
                    Point2i centre = new Point2f();
                    Moments moments = Cv2.Moments(c2);
                    centre.X = (int)(moments.M10 / moments.M00);
                    centre.Y = (int)(moments.M01 / moments.M00);
                    double area = moments.M00;
                    if (area < configs.areaLower) continue;
                    centres2.Add(centre);
                }

                foreach (Point2i c1 in centres1) Cv2.Circle(mat, c1, 10, new Scalar(0, 255, 0), -1);
                foreach (Point2i c2 in centres2) Cv2.Circle(mat, c2, 10, new Scalar(0, 0, 255), -1);

                Cv2.Merge(new Mat[] { car1, car2, black }, merged);
                Cv2.ImShow("binary", merged);
            }
        }
    }
}

