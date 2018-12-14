﻿using System;
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
        private CoordinateConverter cc;
        private Localiser localiser;
        private Point2i car1;
        private Point2i car2;
        private Game game;
        private VideoWriter vw = null;

        private CaiNetwork.CaiServer server;
        private CaiNetwork.CaiUDP udp;

        private string[] gametext = { "上半场", "下半场", "加时1", "加时2",
            "加时3", "加时4", "加时5", "加时6", "加时7" , "加时8", "加时9", "加时10", "加时11", "加时12"};
        private Camp[] UI_LastRoundCamp = new Camp[5];

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
            //UI
            
            label_RedBG.SendToBack();
            label_BlueBG.SendToBack();
            label_RedBG.Controls.Add(label_CarA);
            label_RedBG.Controls.Add(labelAScore);
            label_BlueBG.Controls.Add(label_CarB);
            int newX = label_CarB.Location.X - label_BlueBG.Location.X;
            int newY = label_CarB.Location.Y - label_BlueBG.Location.Y;
            label_CarB.Location = new System.Drawing.Point(newX, newY);
            label_BlueBG.Controls.Add(labelBScore);
            newX = labelBScore.Location.X - label_BlueBG.Location.X;
            newY = labelBScore.Location.Y - label_BlueBG.Location.Y;
            labelBScore.Location = new System.Drawing.Point(newX, newY);
            label_GameCount.Text = "上半场";

            InitialCaiServer();
            MessageBox.Show("TCP IP is "+ server.getUsedIP().ToString()+"  port is "+ server.getPort().ToString());
            udp = new CaiNetwork.CaiUDP();
            MessageBox.Show("UDP IP is " + udp.broadcastIpEndPoint.Address.ToString() + "  port is " + udp.broadcastIpEndPoint.Port.ToString());

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
            button_AReset.Enabled = false;
            button_BReset.Enabled = false;

            Game.LoadMap();
            game = new Game();

            if (capture.IsOpened())
            {
                capture.FrameWidth = flags.cameraSize.Width;
                capture.FrameHeight = flags.cameraSize.Height;
                capture.ConvertRgb = true;
                timer100ms.Interval = 75;
                timer100ms.Start();
                //Cv2.NamedWindow("binary");
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
            lock(flags)
            {
                flags.currPassengerNum = game.CurrPassengerNumber;
                for(int i = 0;i!=Game.MaxPassenger;++i)
                {
                    flags.posPassengerStart[i].X = game.Passengers[i].StartDestPos.StartPos.x;
                    flags.posPassengerStart[i].Y = game.Passengers[i].StartDestPos.StartPos.y;
                    flags.posPassengerEnd[i].X = game.Passengers[i].StartDestPos.DestPos.x;
                    flags.posPassengerEnd[i].Y = game.Passengers[i].StartDestPos.DestPos.y;
                    flags.passengerState[i] = game.Passengers[i].Owner;
                    flags.gameState = game.state;
                }
            }
            byte[] Message = game.PackMessage();
            label_CountDown.Text = Convert.ToString(game.Round);
            CaiZhuo_SendBytesViaNet(Message);
            ShowMessage(Message);
        }

        private void CameraReading()
        {
            bool control = false;
            lock (flags)
            {
                control = flags.running;
            }
            if (control)
            {
                using (Mat videoFrame = new Mat())
                using (Mat showFrame = new Mat())
                {
                    if (capture.Read(videoFrame))
                    {
                        lock (flags)
                        {
                            cc.PassengersFilter(flags);
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
                        BeginInvoke(new Action<Image>(UpdateCameraPicture), BitmapConverter.ToBitmap(showFrame));
                        //输出视频
                        if (flags.videomode == true)
                            vw.Write(showFrame);
                    }
                    lock (flags)
                    {
                        control = flags.running;
                    }
                }
            }
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
            udp.sendByte(Message);
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
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lock(flags)
            {
                flags.clickCount = 0;
                flags.calibrated = false;
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
                if (idx == 3) cc.UpdateCorners(ptsShowCorners, flags);
            }
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
            button_AReset.Enabled = true;
            button_BReset.Enabled = true;
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            game.Pause();
            if(game.CarA.People!=null)
            {
                game.CarA.Score += game.CarA.People.Score() / 2;
                int currNum = game.CarA.People.Number;
                game.CarA.FinishCarry(false);
                game.NewPassenger(currNum);
            }
            if (game.CarB.People != null)
            {
                game.CarB.Score += game.CarB.People.Score() / 2;
                int currNum = game.CarB.People.Number;
                game.CarB.FinishCarry(false);
                game.NewPassenger(currNum);
            }
            buttonPause.Enabled = false;
            buttonStart.Enabled = true;
            button_AReset.Enabled = false;
            button_BReset.Enabled = false;
        }

        private void ShowMessage(byte[] M) //通过Message显示信息到UI上
        {
            label_CountDown.Text = $"{(game.MaxRound-game.Round)/600}:{((game.MaxRound - game.Round) / 10)%60/10}{((game.MaxRound - game.Round) / 10) % 60 % 10}";

            labelAScore.Text = $"{game.CarA.Score}";
            labelBScore.Text = $"{game.CarB.Score}";

            label_GameCount.Text = gametext[game.GameCount - 1];
            label_APauseNum.Text = $"{game.APauseNum}";
            label_BPauseNum.Text = $"{game.BPauseNum}";
            label_AFoul1Num.Text = $"{game.AFoul1}";
            label_BFoul1Num.Text = $"{game.BFoul1}";
            label_AFoul2Num.Text = $"{game.AFoul2}";
            label_BFoul2Num.Text = $"{game.BFoul2}";
            //  groupBox_Passenger.Refresh();
        }

        private void button_restart_Click(object sender, EventArgs e)
        {
            lock (game) { game = new Game(); }
            buttonStart.Enabled = true;
            buttonPause.Enabled = false;
            button_AReset.Enabled = false;
            button_BReset.Enabled = false;
        }

        private void buttonChangeScore_Click(object sender, EventArgs e)
        {
            int AScore = (int)numericUpDownScoreA.Value;
            int BScore = (int)numericUpDownScoreB.Value;
            numericUpDownScoreA.Value = 0;
            numericUpDownScoreB.Value = 0;
            lock(game)
            {
                game.CarA.Score += AScore;
                game.CarB.Score += BScore;
            }
        }



        private void button_video_Click(object sender, EventArgs e)
        {
            lock (flags)
            {
                if (flags.videomode == false)
                {
                    string time = DateTime.Now.ToString("MMdd_HH_mm_ss");
                    vw = new VideoWriter("../../video/" + time + ".avi",
                        FourCC.XVID, 10.0, flags.showSize);
                    flags.videomode = true;
                    ((Button)sender).Text = "停止录像";
                    game.FoulTimeFS = new FileStream("../../video/" + time + ".txt", FileMode.CreateNew);
                }
                else
                {
                    vw.Release();
                    vw = null;
                    flags.videomode = false;
                    ((Button)sender).Text = "开始录像";
                    game.FoulTimeFS = null;
                }
            }
        }

        private void button_AReset_Click(object sender, EventArgs e)
        {
            if (game.APauseNum < 3)
            {
                game.AskPause(Camp.CampA);
                buttonPause.Enabled = false;
                buttonStart.Enabled = true;
                button_AReset.Enabled = false;
                button_BReset.Enabled = false;
            }
        }

        private void button_BReset_Click(object sender, EventArgs e)
        {
            if (game.BPauseNum < 3)
            {
                game.AskPause(Camp.CampB);
                buttonPause.Enabled = false;
                buttonStart.Enabled = true;
                button_AReset.Enabled = false;
                button_BReset.Enabled = false;
            }
        }

        private void button_set_Click(object sender, EventArgs e)
        {
            lock (flags)
            {
                SetWindow st = new SetWindow(ref flags, ref game);
                st.Show();
            }
        }

        private void numericUpDownScoreA_ValueChanged(object sender, EventArgs e)
        {
            game.addScore(Camp.CampA, (int)((NumericUpDown)sender).Value);
            ((NumericUpDown)sender).Value = 0;
        }

        private void numericUpDownScoreB_ValueChanged(object sender, EventArgs e)
        {
            game.addScore(Camp.CampB, (int)((NumericUpDown)sender).Value);
            ((NumericUpDown)sender).Value = 0;
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
                flags.configs.hue1Lower = Convert.ToInt32(str[0]);
                flags.configs.hue1Upper = Convert.ToInt32(str[1]);
                flags.configs.hue2Lower = Convert.ToInt32(str[2]);
                flags.configs.hue2Upper = Convert.ToInt32(str[3]);
                flags.configs.saturation1Lower = Convert.ToInt32(str[4]);
                flags.configs.saturation2Lower = Convert.ToInt32(str[5]);
                flags.configs.valueLower = Convert.ToInt32(str[6]);
                flags.configs.areaLower = Convert.ToInt32(str[7]);
                fsRead.Close();
            }
        }

        private void button_Continue_Click(object sender, EventArgs e)
        {
            //if (game.state == GameState.End)
            game.nextStage();
            buttonPause.Enabled = false;
            buttonStart.Enabled = true;
            button_AReset.Enabled = false;
            button_BReset.Enabled = false;
        }

        private void button_AFoul1_Click(object sender, EventArgs e)
        {
            game.AFoul1++;
            game.addScore(Camp.CampA, -10);
            if (game.FoulTimeFS != null)
            {
                byte[] data = Encoding.Default.GetBytes($"A -10 {game.Round}\r\n");
                game.FoulTimeFS.Write(data, 0, data.Length);
            }
        }

        private void button_AFoul2_Click(object sender, EventArgs e)
        {
            game.AFoul2++;
            game.addScore(Camp.CampA, -50);
            if (game.FoulTimeFS != null)
            {
                byte[] data = Encoding.Default.GetBytes($"A -50 {game.Round}\r\n");
                game.FoulTimeFS.Write(data, 0, data.Length);
            }
        }

        private void button_BFoul1_Click(object sender, EventArgs e)
        {
            game.BFoul1++;
            game.addScore(Camp.CampB, -10);
            if (game.FoulTimeFS != null)
            {
                byte[] data = Encoding.Default.GetBytes($"B -10 {game.Round}\r\n");
                game.FoulTimeFS.Write(data, 0, data.Length);
            }
        }

        private void button_BFoul2_Click(object sender, EventArgs e)
        {
            game.BFoul2++;
            game.addScore(Camp.CampB, -50);
            if (game.FoulTimeFS != null)
            {
                byte[] data = Encoding.Default.GetBytes($"B -50 {game.Round}\r\n");
                game.FoulTimeFS.Write(data, 0, data.Length);
            }
        }

        //绘制乘客信息
        private void groupBox_Passenger_Paint(object sender, PaintEventArgs e)
        {
            Brush br_No_NV = new SolidBrush(Color.Silver);
            Brush br_No_V = new SolidBrush(Color.DimGray);
            Brush br_A_NV = new SolidBrush(Color.Pink);
            Brush br_A_V = new SolidBrush(Color.Red);
            Brush br_B_NV = new SolidBrush(Color.SkyBlue);
            Brush br_B_V = new SolidBrush(Color.RoyalBlue);
            Graphics gra = e.Graphics;
            int vbargin = 100;
            for(int i = 0;i!=game.CurrPassengerNumber;++i)
            {
                switch(game.Passengers[i].Owner)
                {
                    case Camp.None:
                        gra.FillEllipse(br_No_V, 40, 100 + i * vbargin, 30, 30);
                        gra.FillEllipse(br_A_NV, 100, 100 + i * vbargin, 30, 30);
                        gra.FillEllipse(br_B_NV, 160, 100 + i * vbargin, 30, 30);
                        break;
                    case Camp.CampA:
                        gra.FillEllipse(br_No_NV, 40, 100 + i * vbargin, 30, 30);
                        gra.FillEllipse(br_A_V, 100, 100 + i * vbargin, 30, 30);
                        gra.FillEllipse(br_B_NV, 160, 100 + i * vbargin, 30, 30);
                        break;
                    case Camp.CampB:
                        gra.FillEllipse(br_No_NV, 40, 100 + i * vbargin, 30, 30);
                        gra.FillEllipse(br_A_NV, 100, 100 + i * vbargin, 30, 30);
                        gra.FillEllipse(br_B_V, 160, 100 + i * vbargin, 30, 30);
                        break;
                    default:break;
                }
            }
        }
    }

    public class MyFlags
    {
        public bool running;
        public bool calibrated;
        public bool videomode;
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

        public Point2i[] posPassengerStart;
        public Point2i[] posPassengerEnd;
        public Camp[] passengerState;
        public int currPassengerNum;
        public GameState gameState;

        public void Init()
        {
            running = false;
            calibrated = false;
            videomode = false;
            configs = new LocConfigs();
            posCarA = new Point2i();
            posCarB = new Point2i();
            showSize = new OpenCvSharp.Size(960, 720);
            cameraSize = new OpenCvSharp.Size(1280, 960);
            logicSize = new OpenCvSharp.Size(270, 270);
            clickCount = 0;
            posPassengerStart = new Point2i[Game.MaxPassenger];
            posPassengerEnd = new Point2i[Game.MaxPassenger];
            passengerState = new Camp[Game.MaxPassenger];
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
        private Mat logic2cam;
        private Mat show2cam;
        private Mat cam2show;
        private Mat show2logic;
        private Mat logic2show;
        private Point2f[] logicCorners;
        private Point2f[] camCorners;
        private Point2f[] showCorners;

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                ((IDisposable)(cam2logic)).Dispose();
                ((IDisposable)(logic2cam)).Dispose();
                ((IDisposable)(show2cam)).Dispose();
                ((IDisposable)(cam2show)).Dispose();
                ((IDisposable)(show2logic)).Dispose();
                ((IDisposable)(logic2show)).Dispose();
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
            logic2show = new Mat();
            show2logic = new Mat();
            cam2show = new Mat();
            logic2cam = new Mat();

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
            cam2show = Cv2.GetPerspectiveTransform(camCorners, showCorners);
        }

        public void UpdateCorners(Point2f[] corners, MyFlags myFlags)
        {
            if (corners == null) return;
            if (corners.Length != 4) return;
            else showCorners = corners;

            logic2show = Cv2.GetPerspectiveTransform(logicCorners, showCorners);
            show2logic = Cv2.GetPerspectiveTransform(showCorners, logicCorners);
            camCorners = Cv2.PerspectiveTransform(showCorners, show2cam);
            cam2logic = Cv2.GetPerspectiveTransform(camCorners, logicCorners);
            logic2cam = Cv2.GetPerspectiveTransform(logicCorners, camCorners);
            myFlags.calibrated = true;
        }

        public Point2f[] ShowToCamera(Point2f[] ptsShow)
        {
            return Cv2.PerspectiveTransform(ptsShow, show2cam);
        }

        public Point2f[] CameraToShow(Point2f[] ptsCamera)
        {
            return Cv2.PerspectiveTransform(ptsCamera, cam2show);
        }

        public Point2f[] CameraToLogic(Point2f[] ptsCamera)
        {
            return Cv2.PerspectiveTransform(ptsCamera, cam2logic);
        }

        public Point2f[] LogicToCamera(Point2f[] ptsLogic)
        {
            return Cv2.PerspectiveTransform(ptsLogic, logic2cam);
        }

        public Point2f[] LogicToShow(Point2f[] ptsLogic)
        {
            return Cv2.PerspectiveTransform(ptsLogic, logic2show);
        }

        public Point2f[] ShowToLogic(Point2f[] ptsShow)
        {
            return Cv2.PerspectiveTransform(ptsShow, show2logic);
        }

        public void PassengersFilter(MyFlags flags)
        {
            if (!flags.calibrated) return;

            for (int i = 0; i < flags.currPassengerNum; ++i)
            {
                Point2f[] res = LogicToCamera(new Point2f[]{ flags.posPassengerStart[i], flags.posPassengerEnd[i]});
                flags.posPassengerStart[i] = res[0];
                flags.posPassengerEnd[i] = res[1];
            }
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
            //using (Mat merged = new Mat())
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

                foreach (Point2i c1 in centres1) Cv2.Circle(mat, c1, 10, new Scalar(0x1b, 0xff, 0xa7), -1);
                foreach (Point2i c2 in centres2) Cv2.Circle(mat, c2, 10, new Scalar(0x00, 0x98, 0xff), -1);
                if (localiseFlags.gameState != GameState.Unstart)
                {
                    for (int i = 0; i < localiseFlags.currPassengerNum; ++i)
                    {
                        int x1 = localiseFlags.posPassengerEnd[i].X;
                        int y1 = localiseFlags.posPassengerEnd[i].Y;
                        int x2 = localiseFlags.posPassengerStart[i].X;
                        int y2 = localiseFlags.posPassengerStart[i].Y;
                        int x10 = x1 - 8;
                        int y10 = y1 - 8;
                        int x20 = x2 - 8;
                        int y20 = y2 - 8;
                        Rect rectDest = new Rect(x10, y10, 16, 16);
                        Rect rectSrc = new Rect(x20, y20, 16, 16);
                        switch (localiseFlags.passengerState[i])
                        {
                            case Camp.CampA:
                                Cv2.Rectangle(mat, rectDest, new Scalar(0x1b, 0xff, 0xa7), -1);
                                if (centres1.Count != 0)
                                    Cv2.Line(mat, centres1[0], 
                                    localiseFlags.posPassengerEnd[i], new Scalar(0x1b, 0xff, 0xa7), 2);
                                break;
                            case Camp.CampB:
                                Cv2.Rectangle(mat, rectDest, new Scalar(0x00, 0x98, 0xff), -1);
                                if(centres2.Count != 0)
                                    Cv2.Line(mat, centres2[0],
                                    localiseFlags.posPassengerEnd[i], new Scalar(0x00, 0x98, 0xff), 2);
                                break;
                            case Camp.None:
                                // Cv2.Circle(mat, localiseFlags.posPassengerStart[i], 5, new Scalar(0xd8, 0x93, 0xce), -1);
                                Cv2.Rectangle(mat, rectSrc, new Scalar(0xf3, 0x96, 0x21), -1);
                                Cv2.Rectangle(mat, rectDest, new Scalar(0x58, 0xee, 0xff), -1);
                                Cv2.Line(mat, localiseFlags.posPassengerStart[i],
                                    localiseFlags.posPassengerEnd[i], new Scalar(0xf3, 0x96, 0x21), 2);
                                break;
                            default:
                                break;
                        }
                    }
                }

                //Cv2.Merge(new Mat[] { car1, car2, black }, merged);
                //Cv2.ImShow("binary", merged);
            }
        }
    }
}

