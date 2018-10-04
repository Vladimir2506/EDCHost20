namespace EDC20HOST
{
    partial class Tracker
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                capture.Dispose();
                cc.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.pbCamera = new System.Windows.Forms.PictureBox();
            this.tbPoint1 = new System.Windows.Forms.TextBox();
            this.tbPoint2 = new System.Windows.Forms.TextBox();
            this.tbPoint3 = new System.Windows.Forms.TextBox();
            this.tbPoint4 = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblHue1L = new System.Windows.Forms.Label();
            this.nudHue1L = new System.Windows.Forms.NumericUpDown();
            this.nudHue1H = new System.Windows.Forms.NumericUpDown();
            this.lblHueH = new System.Windows.Forms.Label();
            this.nudHue2L = new System.Windows.Forms.NumericUpDown();
            this.lblHue2L = new System.Windows.Forms.Label();
            this.nudHue2H = new System.Windows.Forms.NumericUpDown();
            this.lblHue2H = new System.Windows.Forms.Label();
            this.nudSat1L = new System.Windows.Forms.NumericUpDown();
            this.lblSat1L = new System.Windows.Forms.Label();
            this.nudSat2L = new System.Windows.Forms.NumericUpDown();
            this.lblSat2L = new System.Windows.Forms.Label();
            this.nudValueL = new System.Windows.Forms.NumericUpDown();
            this.lblValueL = new System.Windows.Forms.Label();
            this.nudAreaL = new System.Windows.Forms.NumericUpDown();
            this.lblAreaL = new System.Windows.Forms.Label();
            this.timer100ms = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.labelMsg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelALocation = new System.Windows.Forms.Label();
            this.labelBLocation = new System.Windows.Forms.Label();
            this.label1L = new System.Windows.Forms.Label();
            this.label2L = new System.Windows.Forms.Label();
            this.label3L = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label4L = new System.Windows.Forms.Label();
            this.label5L = new System.Windows.Forms.Label();
            this.labelValidP = new System.Windows.Forms.Label();
            this.labelRound = new System.Windows.Forms.Label();
            this.labelState = new System.Windows.Forms.Label();
            this.labelAScore = new System.Windows.Forms.Label();
            this.labelBScore = new System.Windows.Forms.Label();
            this.buttonAFoul = new System.Windows.Forms.Button();
            this.buttonBFoul = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHue1L)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHue1H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHue2L)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHue2H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSat1L)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSat2L)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValueL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAreaL)).BeginInit();
            this.SuspendLayout();
            // 
            // tbInfo
            // 
            this.tbInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbInfo.Location = new System.Drawing.Point(20, 20);
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ReadOnly = true;
            this.tbInfo.Size = new System.Drawing.Size(150, 27);
            this.tbInfo.TabIndex = 1;
            // 
            // pbCamera
            // 
            this.pbCamera.Location = new System.Drawing.Point(200, 20);
            this.pbCamera.Name = "pbCamera";
            this.pbCamera.Size = new System.Drawing.Size(800, 600);
            this.pbCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbCamera.TabIndex = 2;
            this.pbCamera.TabStop = false;
            this.pbCamera.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbCamera_MouseClick);
            // 
            // tbPoint1
            // 
            this.tbPoint1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPoint1.Location = new System.Drawing.Point(20, 70);
            this.tbPoint1.Name = "tbPoint1";
            this.tbPoint1.ReadOnly = true;
            this.tbPoint1.Size = new System.Drawing.Size(150, 27);
            this.tbPoint1.TabIndex = 3;
            // 
            // tbPoint2
            // 
            this.tbPoint2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPoint2.Location = new System.Drawing.Point(20, 120);
            this.tbPoint2.Name = "tbPoint2";
            this.tbPoint2.ReadOnly = true;
            this.tbPoint2.Size = new System.Drawing.Size(150, 27);
            this.tbPoint2.TabIndex = 4;
            // 
            // tbPoint3
            // 
            this.tbPoint3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPoint3.Location = new System.Drawing.Point(20, 170);
            this.tbPoint3.Name = "tbPoint3";
            this.tbPoint3.ReadOnly = true;
            this.tbPoint3.Size = new System.Drawing.Size(150, 27);
            this.tbPoint3.TabIndex = 5;
            // 
            // tbPoint4
            // 
            this.tbPoint4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPoint4.Location = new System.Drawing.Point(20, 220);
            this.tbPoint4.Name = "tbPoint4";
            this.tbPoint4.ReadOnly = true;
            this.tbPoint4.Size = new System.Drawing.Size(150, 27);
            this.tbPoint4.TabIndex = 6;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.Location = new System.Drawing.Point(20, 270);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(150, 30);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "重设边界点";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblHue1L
            // 
            this.lblHue1L.AutoSize = true;
            this.lblHue1L.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHue1L.Location = new System.Drawing.Point(20, 320);
            this.lblHue1L.Name = "lblHue1L";
            this.lblHue1L.Size = new System.Drawing.Size(60, 20);
            this.lblHue1L.TabIndex = 8;
            this.lblHue1L.Text = "Hue1L:";
            // 
            // nudHue1L
            // 
            this.nudHue1L.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudHue1L.Location = new System.Drawing.Point(85, 320);
            this.nudHue1L.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudHue1L.Name = "nudHue1L";
            this.nudHue1L.Size = new System.Drawing.Size(75, 27);
            this.nudHue1L.TabIndex = 10;
            this.nudHue1L.ValueChanged += new System.EventHandler(this.nudHue1L_ValueChanged);
            // 
            // nudHue1H
            // 
            this.nudHue1H.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudHue1H.Location = new System.Drawing.Point(85, 370);
            this.nudHue1H.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudHue1H.Name = "nudHue1H";
            this.nudHue1H.Size = new System.Drawing.Size(75, 27);
            this.nudHue1H.TabIndex = 12;
            this.nudHue1H.ValueChanged += new System.EventHandler(this.nudHue1H_ValueChanged);
            // 
            // lblHueH
            // 
            this.lblHueH.AutoSize = true;
            this.lblHueH.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHueH.Location = new System.Drawing.Point(20, 370);
            this.lblHueH.Name = "lblHueH";
            this.lblHueH.Size = new System.Drawing.Size(64, 20);
            this.lblHueH.TabIndex = 11;
            this.lblHueH.Text = "Hue1H:";
            // 
            // nudHue2L
            // 
            this.nudHue2L.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudHue2L.Location = new System.Drawing.Point(85, 420);
            this.nudHue2L.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudHue2L.Name = "nudHue2L";
            this.nudHue2L.Size = new System.Drawing.Size(75, 27);
            this.nudHue2L.TabIndex = 14;
            this.nudHue2L.ValueChanged += new System.EventHandler(this.nudHue2L_ValueChanged);
            // 
            // lblHue2L
            // 
            this.lblHue2L.AutoSize = true;
            this.lblHue2L.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHue2L.Location = new System.Drawing.Point(20, 420);
            this.lblHue2L.Name = "lblHue2L";
            this.lblHue2L.Size = new System.Drawing.Size(60, 20);
            this.lblHue2L.TabIndex = 13;
            this.lblHue2L.Text = "Hue2L:";
            // 
            // nudHue2H
            // 
            this.nudHue2H.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudHue2H.Location = new System.Drawing.Point(85, 470);
            this.nudHue2H.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudHue2H.Name = "nudHue2H";
            this.nudHue2H.Size = new System.Drawing.Size(75, 27);
            this.nudHue2H.TabIndex = 16;
            this.nudHue2H.ValueChanged += new System.EventHandler(this.nudHue2H_ValueChanged);
            // 
            // lblHue2H
            // 
            this.lblHue2H.AutoSize = true;
            this.lblHue2H.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHue2H.Location = new System.Drawing.Point(20, 470);
            this.lblHue2H.Name = "lblHue2H";
            this.lblHue2H.Size = new System.Drawing.Size(64, 20);
            this.lblHue2H.TabIndex = 15;
            this.lblHue2H.Text = "Hue2H:";
            // 
            // nudSat1L
            // 
            this.nudSat1L.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudSat1L.Location = new System.Drawing.Point(85, 520);
            this.nudSat1L.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudSat1L.Name = "nudSat1L";
            this.nudSat1L.Size = new System.Drawing.Size(75, 27);
            this.nudSat1L.TabIndex = 18;
            this.nudSat1L.ValueChanged += new System.EventHandler(this.nudSat1L_ValueChanged);
            // 
            // lblSat1L
            // 
            this.lblSat1L.AutoSize = true;
            this.lblSat1L.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSat1L.Location = new System.Drawing.Point(20, 520);
            this.lblSat1L.Name = "lblSat1L";
            this.lblSat1L.Size = new System.Drawing.Size(53, 20);
            this.lblSat1L.TabIndex = 17;
            this.lblSat1L.Text = "Sat1L:";
            // 
            // nudSat2L
            // 
            this.nudSat2L.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudSat2L.Location = new System.Drawing.Point(85, 570);
            this.nudSat2L.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudSat2L.Name = "nudSat2L";
            this.nudSat2L.Size = new System.Drawing.Size(75, 27);
            this.nudSat2L.TabIndex = 20;
            this.nudSat2L.ValueChanged += new System.EventHandler(this.nudSat2L_ValueChanged);
            // 
            // lblSat2L
            // 
            this.lblSat2L.AutoSize = true;
            this.lblSat2L.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSat2L.Location = new System.Drawing.Point(20, 570);
            this.lblSat2L.Name = "lblSat2L";
            this.lblSat2L.Size = new System.Drawing.Size(53, 20);
            this.lblSat2L.TabIndex = 19;
            this.lblSat2L.Text = "Sat2L:";
            // 
            // nudValueL
            // 
            this.nudValueL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudValueL.Location = new System.Drawing.Point(85, 620);
            this.nudValueL.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudValueL.Name = "nudValueL";
            this.nudValueL.Size = new System.Drawing.Size(75, 27);
            this.nudValueL.TabIndex = 22;
            this.nudValueL.ValueChanged += new System.EventHandler(this.nudValueL_ValueChanged);
            // 
            // lblValueL
            // 
            this.lblValueL.AutoSize = true;
            this.lblValueL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblValueL.Location = new System.Drawing.Point(20, 620);
            this.lblValueL.Name = "lblValueL";
            this.lblValueL.Size = new System.Drawing.Size(61, 20);
            this.lblValueL.TabIndex = 21;
            this.lblValueL.Text = "ValueL:";
            // 
            // nudAreaL
            // 
            this.nudAreaL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudAreaL.Location = new System.Drawing.Point(85, 670);
            this.nudAreaL.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudAreaL.Name = "nudAreaL";
            this.nudAreaL.Size = new System.Drawing.Size(75, 27);
            this.nudAreaL.TabIndex = 24;
            this.nudAreaL.ValueChanged += new System.EventHandler(this.nudAreaL_ValueChanged);
            // 
            // lblAreaL
            // 
            this.lblAreaL.AutoSize = true;
            this.lblAreaL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAreaL.Location = new System.Drawing.Point(20, 670);
            this.lblAreaL.Name = "lblAreaL";
            this.lblAreaL.Size = new System.Drawing.Size(55, 20);
            this.lblAreaL.TabIndex = 23;
            this.lblAreaL.Text = "AreaL:";
            // 
            // timer100ms
            // 
            this.timer100ms.Tick += new System.EventHandler(this.timer100ms_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1410, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "CurrRound:";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(1413, 570);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 27;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(1522, 570);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(75, 23);
            this.buttonPause.TabIndex = 28;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // labelMsg
            // 
            this.labelMsg.AutoSize = true;
            this.labelMsg.Location = new System.Drawing.Point(197, 682);
            this.labelMsg.Name = "labelMsg";
            this.labelMsg.Size = new System.Drawing.Size(55, 15);
            this.labelMsg.TabIndex = 29;
            this.labelMsg.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1410, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 30;
            this.label2.Text = "A车坐标：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1410, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = "B车坐标：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1410, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.label4.TabIndex = 32;
            this.label4.Text = "乘客1坐标：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1410, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 15);
            this.label5.TabIndex = 33;
            this.label5.Text = "乘客2坐标：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1410, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 15);
            this.label6.TabIndex = 34;
            this.label6.Text = "乘客3坐标：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1410, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 15);
            this.label7.TabIndex = 35;
            this.label7.Text = "乘客4坐标：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1410, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 15);
            this.label8.TabIndex = 36;
            this.label8.Text = "乘客5坐标：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1410, 310);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 15);
            this.label9.TabIndex = 37;
            this.label9.Text = "有效乘客数：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1410, 390);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 15);
            this.label10.TabIndex = 38;
            this.label10.Text = "比赛状态：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1410, 430);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 15);
            this.label11.TabIndex = 39;
            this.label11.Text = "A车得分/犯规：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1410, 470);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 15);
            this.label12.TabIndex = 40;
            this.label12.Text = "B车得分/犯规：";
            // 
            // labelALocation
            // 
            this.labelALocation.AutoSize = true;
            this.labelALocation.Location = new System.Drawing.Point(1530, 30);
            this.labelALocation.Name = "labelALocation";
            this.labelALocation.Size = new System.Drawing.Size(15, 15);
            this.labelALocation.TabIndex = 26;
            this.labelALocation.Text = "0";
            // 
            // labelBLocation
            // 
            this.labelBLocation.AutoSize = true;
            this.labelBLocation.Location = new System.Drawing.Point(1530, 70);
            this.labelBLocation.Name = "labelBLocation";
            this.labelBLocation.Size = new System.Drawing.Size(15, 15);
            this.labelBLocation.TabIndex = 41;
            this.labelBLocation.Text = "0";
            // 
            // label1L
            // 
            this.label1L.AutoSize = true;
            this.label1L.Location = new System.Drawing.Point(1530, 110);
            this.label1L.Name = "label1L";
            this.label1L.Size = new System.Drawing.Size(15, 15);
            this.label1L.TabIndex = 42;
            this.label1L.Text = "0";
            // 
            // label2L
            // 
            this.label2L.AutoSize = true;
            this.label2L.Location = new System.Drawing.Point(1530, 150);
            this.label2L.Name = "label2L";
            this.label2L.Size = new System.Drawing.Size(15, 15);
            this.label2L.TabIndex = 43;
            this.label2L.Text = "0";
            // 
            // label3L
            // 
            this.label3L.AutoSize = true;
            this.label3L.Location = new System.Drawing.Point(1530, 190);
            this.label3L.Name = "label3L";
            this.label3L.Size = new System.Drawing.Size(15, 15);
            this.label3L.TabIndex = 44;
            this.label3L.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1530, 230);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(15, 15);
            this.label17.TabIndex = 45;
            this.label17.Text = "0";
            // 
            // label4L
            // 
            this.label4L.AutoSize = true;
            this.label4L.Location = new System.Drawing.Point(1530, 230);
            this.label4L.Name = "label4L";
            this.label4L.Size = new System.Drawing.Size(15, 15);
            this.label4L.TabIndex = 46;
            this.label4L.Text = "0";
            // 
            // label5L
            // 
            this.label5L.AutoSize = true;
            this.label5L.Location = new System.Drawing.Point(1530, 270);
            this.label5L.Name = "label5L";
            this.label5L.Size = new System.Drawing.Size(15, 15);
            this.label5L.TabIndex = 47;
            this.label5L.Text = "0";
            // 
            // labelValidP
            // 
            this.labelValidP.AutoSize = true;
            this.labelValidP.Location = new System.Drawing.Point(1530, 310);
            this.labelValidP.Name = "labelValidP";
            this.labelValidP.Size = new System.Drawing.Size(15, 15);
            this.labelValidP.TabIndex = 48;
            this.labelValidP.Text = "0";
            // 
            // labelRound
            // 
            this.labelRound.AutoSize = true;
            this.labelRound.Location = new System.Drawing.Point(1530, 350);
            this.labelRound.Name = "labelRound";
            this.labelRound.Size = new System.Drawing.Size(15, 15);
            this.labelRound.TabIndex = 49;
            this.labelRound.Text = "0";
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(1530, 390);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(15, 15);
            this.labelState.TabIndex = 50;
            this.labelState.Text = "0";
            // 
            // labelAScore
            // 
            this.labelAScore.AutoSize = true;
            this.labelAScore.Location = new System.Drawing.Point(1530, 430);
            this.labelAScore.Name = "labelAScore";
            this.labelAScore.Size = new System.Drawing.Size(15, 15);
            this.labelAScore.TabIndex = 51;
            this.labelAScore.Text = "0";
            // 
            // labelBScore
            // 
            this.labelBScore.AutoSize = true;
            this.labelBScore.Location = new System.Drawing.Point(1530, 470);
            this.labelBScore.Name = "labelBScore";
            this.labelBScore.Size = new System.Drawing.Size(15, 15);
            this.labelBScore.TabIndex = 52;
            this.labelBScore.Text = "0";
            // 
            // buttonAFoul
            // 
            this.buttonAFoul.Location = new System.Drawing.Point(1413, 521);
            this.buttonAFoul.Name = "buttonAFoul";
            this.buttonAFoul.Size = new System.Drawing.Size(75, 23);
            this.buttonAFoul.TabIndex = 53;
            this.buttonAFoul.Text = "A犯规";
            this.buttonAFoul.UseVisualStyleBackColor = true;
            this.buttonAFoul.Click += new System.EventHandler(this.buttonAFoul_Click);
            // 
            // buttonBFoul
            // 
            this.buttonBFoul.Location = new System.Drawing.Point(1522, 521);
            this.buttonBFoul.Name = "buttonBFoul";
            this.buttonBFoul.Size = new System.Drawing.Size(75, 23);
            this.buttonBFoul.TabIndex = 54;
            this.buttonBFoul.Text = "B犯规";
            this.buttonBFoul.UseVisualStyleBackColor = true;
            this.buttonBFoul.Click += new System.EventHandler(this.buttonBFoul_Click);
            // 
            // Tracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1857, 1055);
            this.Controls.Add(this.buttonBFoul);
            this.Controls.Add(this.buttonAFoul);
            this.Controls.Add(this.labelBScore);
            this.Controls.Add(this.labelAScore);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.labelRound);
            this.Controls.Add(this.labelValidP);
            this.Controls.Add(this.label5L);
            this.Controls.Add(this.label4L);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label3L);
            this.Controls.Add(this.label2L);
            this.Controls.Add(this.label1L);
            this.Controls.Add(this.labelBLocation);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelMsg);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelALocation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudAreaL);
            this.Controls.Add(this.lblAreaL);
            this.Controls.Add(this.nudValueL);
            this.Controls.Add(this.lblValueL);
            this.Controls.Add(this.nudSat2L);
            this.Controls.Add(this.lblSat2L);
            this.Controls.Add(this.nudSat1L);
            this.Controls.Add(this.lblSat1L);
            this.Controls.Add(this.nudHue2H);
            this.Controls.Add(this.lblHue2H);
            this.Controls.Add(this.nudHue2L);
            this.Controls.Add(this.lblHue2L);
            this.Controls.Add(this.nudHue1H);
            this.Controls.Add(this.lblHueH);
            this.Controls.Add(this.nudHue1L);
            this.Controls.Add(this.lblHue1L);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.tbPoint4);
            this.Controls.Add(this.tbPoint3);
            this.Controls.Add(this.tbPoint2);
            this.Controls.Add(this.tbPoint1);
            this.Controls.Add(this.pbCamera);
            this.Controls.Add(this.tbInfo);
            this.Name = "Tracker";
            this.Text = "Tracker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Tracker_FormClosed);
            this.Load += new System.EventHandler(this.Tracker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHue1L)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHue1H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHue2L)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHue2H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSat1L)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSat2L)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValueL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAreaL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.PictureBox pbCamera;
        private System.Windows.Forms.TextBox tbPoint1;
        private System.Windows.Forms.TextBox tbPoint2;
        private System.Windows.Forms.TextBox tbPoint3;
        private System.Windows.Forms.TextBox tbPoint4;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblHue1L;
        private System.Windows.Forms.NumericUpDown nudHue1L;
        private System.Windows.Forms.NumericUpDown nudHue1H;
        private System.Windows.Forms.Label lblHueH;
        private System.Windows.Forms.NumericUpDown nudHue2L;
        private System.Windows.Forms.Label lblHue2L;
        private System.Windows.Forms.NumericUpDown nudHue2H;
        private System.Windows.Forms.Label lblHue2H;
        private System.Windows.Forms.NumericUpDown nudSat1L;
        private System.Windows.Forms.Label lblSat1L;
        private System.Windows.Forms.NumericUpDown nudSat2L;
        private System.Windows.Forms.Label lblSat2L;
        private System.Windows.Forms.NumericUpDown nudValueL;
        private System.Windows.Forms.Label lblValueL;
        private System.Windows.Forms.NumericUpDown nudAreaL;
        private System.Windows.Forms.Label lblAreaL;
        private System.Windows.Forms.Timer timer100ms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Label labelMsg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelALocation;
        private System.Windows.Forms.Label labelBLocation;
        private System.Windows.Forms.Label label1L;
        private System.Windows.Forms.Label label2L;
        private System.Windows.Forms.Label label3L;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label4L;
        private System.Windows.Forms.Label label5L;
        private System.Windows.Forms.Label labelValidP;
        private System.Windows.Forms.Label labelRound;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.Label labelAScore;
        private System.Windows.Forms.Label labelBScore;
        private System.Windows.Forms.Button buttonAFoul;
        private System.Windows.Forms.Button buttonBFoul;
    }
}

