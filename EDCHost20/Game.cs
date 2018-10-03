using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EDC20HOST
{
    enum GameState { Unstart = 0, Normal = 1, Pause = 2, End = 3 };
    class Game
    {
        public const int MaxSize = 300;
        public const int MaxPassenger = 5;
        public const int MinCarryDistance = 5; //最小接送距离
        public int Round { get; set; }//当前回合
        public GameState state { get; set; }
        public Car CarA, CarB;
        public Passenger[] Passengers;
        public PassengerGenerator Generator { get; set; }
        public int CurrPassengerNumber; //当前乘客数量
        public static bool[,] GameMap = new bool[MaxSize, MaxSize]; //地图信息
        public static bool PassengerDotValid(Dot dot)//乘客点是否有效->7*7方格均为白色
        {
            //return true;
            bool flag = true;
            for (int i = ((dot.x - 3 > 0) ? (dot.x - 3) : 0); i <= ((dot.x + 3 < MaxSize) ? (dot.x + 3) : MaxSize - 1); ++i)
                for (int j = ((dot.y - 3 > 0) ? (dot.y - 3) : 0); j <= ((dot.y + 3 < MaxSize) ? (dot.y + 3) : MaxSize - 1); ++j)
                    if (!GameMap[i, j])
                        flag = false;
            return flag;
        }
        public static bool CarDotValid(Dot dot)//车点是否有效->3*3方格白色大于4
        {
            //return true;
            int count = 0;
            for (int i = ((dot.x - 1 > 0) ? (dot.x - 1) : 0); i <= ((dot.x + 1 < MaxSize) ? (dot.x + 1) : MaxSize - 1); ++i)
                for (int j = ((dot.y - 1 > 0) ? (dot.y - 1) : 0); j <= ((dot.y + 1 < MaxSize) ? (dot.y + 1) : MaxSize - 1); ++j)
                    if (GameMap[i, j])
                        count++;
            if (count >= 4) return true;
            else return false;
        }
        public static void LoadMap()//读取地图文件
        {
            FileStream MapFile = File.OpenRead("map.bmp");
            byte[] buffer = new byte[MapFile.Length - 54]; //存储图片文件
            MapFile.Position = 54;
            MapFile.Read(buffer, 0, buffer.Length);
            for (int i = 0; i != MaxSize; ++i)
                for (int j = 0; j != MaxSize; ++j)
                    if (buffer[(i * MaxSize + j) * 3] > 128)//白色
                        GameMap[MaxSize - 1 - i, j] = true;
                    else
                        GameMap[MaxSize - 1 - i, j] = false;
        }
        public static StartDestDot OppoDots(StartDestDot prevDot)
        {
            StartDestDot newDots = new StartDestDot();
            newDots.StartPos.x = MaxSize - prevDot.StartPos.y;
            newDots.StartPos.y = MaxSize - prevDot.StartPos.x;
            newDots.DestPos.x = MaxSize - prevDot.DestPos.y;
            newDots.DestPos.y = MaxSize - prevDot.DestPos.x;
            return newDots;
        }
        public double GetDistance(Dot A, Dot B)
        {
            return Math.Sqrt((A.x - B.x) * (A.x - B.x) + (A.y - B.y) * (A.y - B.y));
        }
        public Game()
        {
            CarA = new Car(Camp.CampA);
            CarB = new Car(Camp.CampB);
            Passengers = new Passenger[MaxPassenger];
            Round = 0;
            state = GameState.Unstart;
            Generator = new PassengerGenerator();
            Generator.Generate(500);
            Passengers[0] = new Passenger(Generator.NextA(), false, 1);
            Passengers[1] = new Passenger(Generator.NextB(), false, 2);
            Passengers[2] = new Passenger(Generator.NextA(), false, 3);
            Passengers[3] = new Passenger(Generator.NextB(), false, 4);
            Passengers[4] = new Passenger(Generator.NextA(), true, 5);
            CheckPassengerNumber();
        }
        protected void CheckPassengerNumber() //根据回合数更改最大乘客数量
        {
            if (Round == 0)
            {
                CurrPassengerNumber = 2;
            }
            else if (Round == 400)
            {
                CurrPassengerNumber = 4;
            }
            else if (Round == 800)
            {
                CurrPassengerNumber = 5;
            }
        }
        public void Start() //开始比赛
        {
            state = GameState.Normal;
        }
        public void Pause() //暂停比赛
        {
            state = GameState.Pause;
        }
        public void End() //结束比赛
        {
            state = GameState.End;
        }
        public void Update()//每回合执行
        {
            if (state == GameState.Normal)
            {
                Round++;
                //GetInfoFromCameraAndUpdate();
                CheckPassengerNumber();
                #region PunishmentPhase
                if (!CarDotValid(CarA.Pos)) CarA.Stop();
                if (!CarDotValid(CarB.Pos)) CarB.Stop();
                #endregion

                //上车
                for (int i = 0; i != CurrPassengerNumber; ++i)
                {
                    Passenger p = Passengers[i];
                    if (p.Owner != Camp.None) continue; //已经上车了
                    if (CarA.UnderStop == false && CarA.People == null && GetDistance(p.StartDestPos.StartPos, CarA.Pos) < MinCarryDistance)
                    {
                        CarA.StartCarry(p);
                        p.Owner = Camp.CampA;
                    }

                    else if (CarB.UnderStop == false && CarB.People == null && GetDistance(p.StartDestPos.StartPos, CarB.Pos) < MinCarryDistance)
                    {
                        CarB.StartCarry(p);
                        p.Owner = Camp.CampB;
                    }
                }
                //下车
                if (CarA.People != null && GetDistance(CarA.People.StartDestPos.DestPos, CarA.Pos) < MinCarryDistance)
                {
                    int nowPassengerNumber = CarA.People.Number - 1; //与序号的差距
                    CarA.FinishCarry();
                    StartDestDot nextDots;
                    if (nowPassengerNumber == 1 || nowPassengerNumber == 3) //属于A区
                        nextDots = Generator.NextA();
                    else if (nowPassengerNumber == 2 || nowPassengerNumber == 4)//属于B区
                        nextDots = Generator.NextB();
                    else
                        nextDots = Generator.NextS();
                    Passengers[nowPassengerNumber] = new Passenger(nextDots, nowPassengerNumber == 5, nowPassengerNumber);
                }
                if (Round == 1200) //结束比赛
                {
                    Pause();
                }
            }
            else;
            //byte[] message = PackMessage();
            //SendMessage
        } 
        public byte[] PackMessage()
        {
            byte[] message = new byte[64]; //上位机传递的信息
            message[0] = (byte)(((byte)state << 6)|(Round>>8));
            message[1] = (byte)Round;
            message[2] = (byte)((CarA.Pos.x >> 1 & 0x80)| (CarA.Pos.y >> 2 & 0x40)| (CarB.Pos.x >> 3 & 0x20)| (CarB.Pos.y >> 4 & 0x10)
                | (Passengers[0].StartDestPos.StartPos.x >> 5 & 0x08) | (Passengers[0].StartDestPos.StartPos.y >> 6 & 0x04)
                | (Passengers[0].StartDestPos.DestPos.x >> 7 & 0x02) | (Passengers[0].StartDestPos.DestPos.y >> 8 & 0x01));
            message[3] = (byte)((Passengers[1].StartDestPos.StartPos.x >> 1 & 0x80) | (Passengers[1].StartDestPos.StartPos.y >> 2 & 0x40)
                | (Passengers[1].StartDestPos.DestPos.x >> 3 & 0x20) | (Passengers[1].StartDestPos.DestPos.y >> 4 & 0x10)
                | (Passengers[2].StartDestPos.StartPos.x >> 5 & 0x08) | (Passengers[2].StartDestPos.StartPos.y >> 6 & 0x04)
                | (Passengers[2].StartDestPos.DestPos.x >> 7 & 0x02) | (Passengers[2].StartDestPos.DestPos.y >> 8 & 0x01));
            message[4] = (byte)((Passengers[3].StartDestPos.StartPos.x >> 1 & 0x80) | (Passengers[3].StartDestPos.StartPos.y >> 2 & 0x40)
                | (Passengers[3].StartDestPos.DestPos.x >> 3 & 0x20) | (Passengers[3].StartDestPos.DestPos.y >> 4 & 0x10)
                | (Passengers[4].StartDestPos.StartPos.x >> 5 & 0x08) | (Passengers[4].StartDestPos.StartPos.y >> 6 & 0x04)
                | (Passengers[4].StartDestPos.DestPos.x >> 7 & 0x02) | (Passengers[4].StartDestPos.DestPos.y >> 8 & 0x01));
            message[5] = (byte)CarA.Pos.x;
            message[6] = (byte)CarA.Pos.y;
            message[7] = (byte)CarB.Pos.x;
            message[8] = (byte)CarB.Pos.y;
            message[9] = (byte)((CurrPassengerNumber << 4) | (byte)Passengers[0].Owner);
            //设置是否强制停止
            if (CarA.UnderStop) message[9] |= 0x20;
            if (CarB.UnderStop) message[9] |= 0x10;
            message[10] = (byte)((byte)Passengers[1].Owner << 6 | (byte)Passengers[2].Owner << 4
                | (byte)Passengers[3].Owner << 2 | (byte)Passengers[4].Owner);
            for(int i = 0; i != 5; ++i)
            {
                message[11 + i * 4] = (byte)Passengers[i].StartDestPos.StartPos.x;
                message[12 + i * 4] = (byte)Passengers[i].StartDestPos.StartPos.y;
                message[13 + i * 4] = (byte)Passengers[i].StartDestPos.DestPos.x;
                message[14 + i * 4] = (byte)Passengers[i].StartDestPos.DestPos.y;
            }
            message[31] = (byte)CarA.FoulCnt;
            message[32] = (byte)CarB.FoulCnt;
            message[33] = (byte)(CarA.Score >> 8);
            message[34] = (byte)(CarA.Score);
            message[35] = (byte)(CarB.Score >> 8);
            message[36] = (byte)(CarB.Score);
            message[62] = 0x0D;
            message[63] = 0x0A;
            return message;
        }
    }
}
