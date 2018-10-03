using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;
using System.Threading;
using OpenCvSharp.Extensions;
using Point2i = OpenCvSharp.Point;
using Cuda = OpenCvSharp.Cuda;

namespace EDC20HOST
{
    public partial class Tracker : Form
    {
        private MyFlags flags = null;
        private VideoCapture capture = null;
        private Thread threadCamera = null;
        private Point2f[] ptsCameraCorners = null;
        private DateTime timeCamNow;
        private DateTime timeCamPrev;
        private TextBox[] tbsPoint = null;
        private CoordinateConverter cc;
        private Localiser localiser;
        private Point2i car1;
        private Point2i car2;
        private Game game;

        public Dot CarALocation()
        {
            Dot D = new Dot();
            D.x = car1.X;D.y = car1.Y;
            return D;
        }
        public Dot CarBLocation()
        {
            Dot D = new Dot();
            D.x = car2.X; D.y = car2.Y;
            return D;
        }

        public Tracker()
        {
            InitializeComponent();
            
            tbsPoint = new TextBox[] { tbPoint1, tbPoint2, tbPoint3, tbPoint4 };
            // Init
            flags = new MyFlags();
            flags.Init();
            flags.Start();
            ptsCameraCorners = new Point2f[4];
            cc = new CoordinateConverter();
            cc.SetLogicSize(250, 250);
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
            
            Game.LoadMap();
            game = new Game();

            if (capture.IsOpened())
            {
                capture.FrameWidth = 800;
                capture.FrameHeight = 600;
                capture.ConvertRgb = true;
                timer100ms.Interval = 90;
                timer100ms.Start();
                Cv2.NamedWindow("binary");
            }

        }

        private void Flush() 
        {
            CameraReading();
            game.CarA.Pos = CarALocation();
            game.CarB.Pos = CarBLocation();
            game.Update();
            byte[] Message = game.PackMessage();
            string a = BitConverter.ToString(Message, 0);
            labelMsg.Text = a;
            labelRound.Text = Convert.ToString(game.Round);
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
                {
                    if (capture.Read(videoFrame))
                    {
                        lock (flags)
                        {
                            localiser.Locate(videoFrame, flags);
                        }
                        localiser.GetLocations(out car1, out car2);
                        timeCamNow = DateTime.Now;
                        TimeSpan timeProcess = timeCamNow - timeCamPrev;
                        timeCamPrev = timeCamNow;
                        BeginInvoke(new Action<TimeSpan>(UpdateProcessTime), timeProcess);
                        BeginInvoke(new Action<Image>(UpdateCameraPicture), BitmapConverter.ToBitmap(videoFrame));
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

        private void Tracker_FormClosed(object sender, FormClosedEventArgs e)
        {
            lock (flags)
            {
                flags.End();
            }
            timer100ms.Stop();
            //threadCamera.Join();
            capture.Release();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lock(flags)
            {
                flags.clickCount = 0;
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
                ptsCameraCorners[idx].X = xMouse;
                ptsCameraCorners[idx].Y = yMouse;

                tbsPoint[idx].Text = String.Format("({0},{1})", xMouse, yMouse);
                if (idx == 3) cc.UpdateCorners(ptsCameraCorners);
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
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            game.Pause();
            buttonPause.Enabled = false;
            buttonStart.Enabled = true;
        }

         
    }

    public class MyFlags
    {
        public bool running;
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

        public void Init()
        {
            running = false;
            configs = new LocConfigs();
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
        private Point2f[] logicCorners;
        private Point2f[] camCorners;

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                ((IDisposable)(cam2logic)).Dispose();
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public CoordinateConverter()
        {
            camCorners = new Point2f[4];
            logicCorners = new Point2f[4];
            cam2logic = new Mat();
        }

        public void SetLogicSize(int width, int height)
        {
            logicCorners[0].X = 0;
            logicCorners[0].Y = 0;
            logicCorners[1].X = width;
            logicCorners[1].Y = 0;
            logicCorners[2].X = 0;
            logicCorners[2].Y = height;
            logicCorners[3].X = width;
            logicCorners[3].Y = height;
        }

        public void UpdateCorners(Point2f[] corners)
        {
            if (corners == null) return;
            if (corners.Length != 4) return;
            else camCorners = corners;

            cam2logic = Cv2.GetPerspectiveTransform(camCorners, logicCorners);

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
