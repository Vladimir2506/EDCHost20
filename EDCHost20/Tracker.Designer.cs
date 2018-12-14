﻿namespace EDC20HOST
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
            this.pbCamera = new System.Windows.Forms.PictureBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.timer100ms = new System.Windows.Forms.Timer(this.components);
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.label_CarA = new System.Windows.Forms.Label();
            this.label_CarB = new System.Windows.Forms.Label();
            this.button_restart = new System.Windows.Forms.Button();
            this.numericUpDownScoreA = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownScoreB = new System.Windows.Forms.NumericUpDown();
            this.button_video = new System.Windows.Forms.Button();
            this.button_BReset = new System.Windows.Forms.Button();
            this.button_AReset = new System.Windows.Forms.Button();
            this.button_set = new System.Windows.Forms.Button();
            this.labelBScore = new System.Windows.Forms.Label();
            this.labelAScore = new System.Windows.Forms.Label();
            this.label_CountDown = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_BFoul1 = new System.Windows.Forms.Button();
            this.button_BFoul2 = new System.Windows.Forms.Button();
            this.button_AFoul2 = new System.Windows.Forms.Button();
            this.button_AFoul1 = new System.Windows.Forms.Button();
            this.label_RedBG = new System.Windows.Forms.Label();
            this.label_BlueBG = new System.Windows.Forms.Label();
            this.label_GameCount = new System.Windows.Forms.Label();
            this.button_Continue = new System.Windows.Forms.Button();
            this.label_APauseNum = new System.Windows.Forms.Label();
            this.label_AFoul1Num = new System.Windows.Forms.Label();
            this.label_AFoul2Num = new System.Windows.Forms.Label();
            this.label_BPauseNum = new System.Windows.Forms.Label();
            this.label_BFoul1Num = new System.Windows.Forms.Label();
            this.label_BFoul2Num = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScoreA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScoreB)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCamera
            // 
            this.pbCamera.Location = new System.Drawing.Point(355, 130);
            this.pbCamera.Name = "pbCamera";
            this.pbCamera.Size = new System.Drawing.Size(960, 720);
            this.pbCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbCamera.TabIndex = 2;
            this.pbCamera.TabStop = false;
            this.pbCamera.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbCamera_MouseClick);
            // 
            // btnReset
            // 
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("微软雅黑 Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.Location = new System.Drawing.Point(1735, 926);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 40);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "重设边界点";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // timer100ms
            // 
            this.timer100ms.Tick += new System.EventHandler(this.timer100ms_Tick);
            // 
            // buttonStart
            // 
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Font = new System.Drawing.Font("微软雅黑 Light", 10.8F);
            this.buttonStart.ForeColor = System.Drawing.Color.Green;
            this.buttonStart.Location = new System.Drawing.Point(1735, 742);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(120, 40);
            this.buttonStart.TabIndex = 27;
            this.buttonStart.Text = "开始";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPause.Font = new System.Drawing.Font("微软雅黑 Light", 10.8F);
            this.buttonPause.ForeColor = System.Drawing.Color.Green;
            this.buttonPause.Location = new System.Drawing.Point(1735, 834);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(120, 40);
            this.buttonPause.TabIndex = 28;
            this.buttonPause.Text = "暂停";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // label_CarA
            // 
            this.label_CarA.AutoSize = true;
            this.label_CarA.BackColor = System.Drawing.Color.Transparent;
            this.label_CarA.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_CarA.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_CarA.Location = new System.Drawing.Point(477, 32);
            this.label_CarA.Name = "label_CarA";
            this.label_CarA.Size = new System.Drawing.Size(113, 65);
            this.label_CarA.TabIndex = 30;
            this.label_CarA.Text = "A车";
            // 
            // label_CarB
            // 
            this.label_CarB.AutoSize = true;
            this.label_CarB.BackColor = System.Drawing.Color.Transparent;
            this.label_CarB.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_CarB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_CarB.Location = new System.Drawing.Point(1349, 32);
            this.label_CarB.Name = "label_CarB";
            this.label_CarB.Size = new System.Drawing.Size(109, 65);
            this.label_CarB.TabIndex = 31;
            this.label_CarB.Text = "B车";
            // 
            // button_restart
            // 
            this.button_restart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_restart.Font = new System.Drawing.Font("微软雅黑 Light", 10.8F);
            this.button_restart.ForeColor = System.Drawing.Color.Green;
            this.button_restart.Location = new System.Drawing.Point(1735, 696);
            this.button_restart.Name = "button_restart";
            this.button_restart.Size = new System.Drawing.Size(120, 40);
            this.button_restart.TabIndex = 56;
            this.button_restart.Text = "新游戏";
            this.button_restart.UseVisualStyleBackColor = true;
            this.button_restart.Click += new System.EventHandler(this.button_restart_Click);
            // 
            // numericUpDownScoreA
            // 
            this.numericUpDownScoreA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownScoreA.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.numericUpDownScoreA.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownScoreA.Location = new System.Drawing.Point(89, 581);
            this.numericUpDownScoreA.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownScoreA.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownScoreA.Name = "numericUpDownScoreA";
            this.numericUpDownScoreA.Size = new System.Drawing.Size(96, 40);
            this.numericUpDownScoreA.TabIndex = 57;
            this.numericUpDownScoreA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownScoreA.ValueChanged += new System.EventHandler(this.numericUpDownScoreA_ValueChanged);
            // 
            // numericUpDownScoreB
            // 
            this.numericUpDownScoreB.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.numericUpDownScoreB.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownScoreB.Location = new System.Drawing.Point(1749, 581);
            this.numericUpDownScoreB.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownScoreB.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownScoreB.Name = "numericUpDownScoreB";
            this.numericUpDownScoreB.Size = new System.Drawing.Size(96, 40);
            this.numericUpDownScoreB.TabIndex = 58;
            this.numericUpDownScoreB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownScoreB.ValueChanged += new System.EventHandler(this.numericUpDownScoreB_ValueChanged);
            // 
            // button_video
            // 
            this.button_video.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_video.Font = new System.Drawing.Font("微软雅黑 Light", 10.8F);
            this.button_video.ForeColor = System.Drawing.Color.Green;
            this.button_video.Location = new System.Drawing.Point(1735, 880);
            this.button_video.Name = "button_video";
            this.button_video.Size = new System.Drawing.Size(120, 40);
            this.button_video.TabIndex = 74;
            this.button_video.Text = "开始录像";
            this.button_video.UseVisualStyleBackColor = true;
            this.button_video.Click += new System.EventHandler(this.button_video_Click);
            // 
            // button_BReset
            // 
            this.button_BReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleTurquoise;
            this.button_BReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.button_BReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_BReset.Font = new System.Drawing.Font("微软雅黑 Light", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_BReset.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_BReset.Location = new System.Drawing.Point(1709, 230);
            this.button_BReset.Name = "button_BReset";
            this.button_BReset.Size = new System.Drawing.Size(160, 72);
            this.button_BReset.TabIndex = 75;
            this.button_BReset.Text = "暂停";
            this.button_BReset.UseVisualStyleBackColor = true;
            this.button_BReset.Click += new System.EventHandler(this.button_BReset_Click);
            // 
            // button_AReset
            // 
            this.button_AReset.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button_AReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Pink;
            this.button_AReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LavenderBlush;
            this.button_AReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_AReset.Font = new System.Drawing.Font("微软雅黑 Light", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_AReset.ForeColor = System.Drawing.Color.Red;
            this.button_AReset.Location = new System.Drawing.Point(54, 230);
            this.button_AReset.Name = "button_AReset";
            this.button_AReset.Size = new System.Drawing.Size(160, 72);
            this.button_AReset.TabIndex = 76;
            this.button_AReset.Text = "暂停";
            this.button_AReset.UseVisualStyleBackColor = true;
            this.button_AReset.Click += new System.EventHandler(this.button_AReset_Click);
            // 
            // button_set
            // 
            this.button_set.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_set.Font = new System.Drawing.Font("微软雅黑 Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_set.Location = new System.Drawing.Point(1735, 972);
            this.button_set.Name = "button_set";
            this.button_set.Size = new System.Drawing.Size(120, 40);
            this.button_set.TabIndex = 77;
            this.button_set.Text = "设置";
            this.button_set.UseVisualStyleBackColor = true;
            this.button_set.Click += new System.EventHandler(this.button_set_Click);
            // 
            // labelBScore
            // 
            this.labelBScore.BackColor = System.Drawing.Color.Transparent;
            this.labelBScore.Font = new System.Drawing.Font("微软雅黑", 48F);
            this.labelBScore.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelBScore.Location = new System.Drawing.Point(1010, 15);
            this.labelBScore.Name = "labelBScore";
            this.labelBScore.Size = new System.Drawing.Size(253, 101);
            this.labelBScore.TabIndex = 52;
            this.labelBScore.Text = "0";
            this.labelBScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAScore
            // 
            this.labelAScore.BackColor = System.Drawing.Color.Transparent;
            this.labelAScore.Font = new System.Drawing.Font("微软雅黑", 48F);
            this.labelAScore.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelAScore.Location = new System.Drawing.Point(654, 15);
            this.labelAScore.Name = "labelAScore";
            this.labelAScore.Size = new System.Drawing.Size(253, 101);
            this.labelAScore.TabIndex = 51;
            this.labelAScore.Text = "0";
            this.labelAScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CountDown
            // 
            this.label_CountDown.BackColor = System.Drawing.Color.Transparent;
            this.label_CountDown.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.label_CountDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(124)))), ((int)(((byte)(176)))));
            this.label_CountDown.Location = new System.Drawing.Point(1728, 130);
            this.label_CountDown.Name = "label_CountDown";
            this.label_CountDown.Size = new System.Drawing.Size(192, 56);
            this.label_CountDown.TabIndex = 78;
            this.label_CountDown.Text = "02:00";
            this.label_CountDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(943, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 65);
            this.label1.TabIndex = 79;
            this.label1.Text = ":";
            // 
            // button_BFoul1
            // 
            this.button_BFoul1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleTurquoise;
            this.button_BFoul1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.button_BFoul1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_BFoul1.Font = new System.Drawing.Font("微软雅黑 Light", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_BFoul1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_BFoul1.Location = new System.Drawing.Point(1709, 350);
            this.button_BFoul1.Name = "button_BFoul1";
            this.button_BFoul1.Size = new System.Drawing.Size(160, 72);
            this.button_BFoul1.TabIndex = 64;
            this.button_BFoul1.Text = "失误";
            this.button_BFoul1.UseVisualStyleBackColor = true;
            this.button_BFoul1.Click += new System.EventHandler(this.button_BFoul1_Click);
            // 
            // button_BFoul2
            // 
            this.button_BFoul2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleTurquoise;
            this.button_BFoul2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.button_BFoul2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_BFoul2.Font = new System.Drawing.Font("微软雅黑 Light", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_BFoul2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_BFoul2.Location = new System.Drawing.Point(1709, 470);
            this.button_BFoul2.Name = "button_BFoul2";
            this.button_BFoul2.Size = new System.Drawing.Size(160, 72);
            this.button_BFoul2.TabIndex = 65;
            this.button_BFoul2.Text = "犯规";
            this.button_BFoul2.UseVisualStyleBackColor = true;
            this.button_BFoul2.Click += new System.EventHandler(this.button_BFoul2_Click);
            // 
            // button_AFoul2
            // 
            this.button_AFoul2.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button_AFoul2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Pink;
            this.button_AFoul2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LavenderBlush;
            this.button_AFoul2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_AFoul2.Font = new System.Drawing.Font("微软雅黑 Light", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_AFoul2.ForeColor = System.Drawing.Color.Red;
            this.button_AFoul2.Location = new System.Drawing.Point(54, 470);
            this.button_AFoul2.Name = "button_AFoul2";
            this.button_AFoul2.Size = new System.Drawing.Size(160, 72);
            this.button_AFoul2.TabIndex = 86;
            this.button_AFoul2.Text = "犯规";
            this.button_AFoul2.UseVisualStyleBackColor = true;
            this.button_AFoul2.Click += new System.EventHandler(this.button_AFoul2_Click);
            // 
            // button_AFoul1
            // 
            this.button_AFoul1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button_AFoul1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Pink;
            this.button_AFoul1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LavenderBlush;
            this.button_AFoul1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_AFoul1.Font = new System.Drawing.Font("微软雅黑 Light", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_AFoul1.ForeColor = System.Drawing.Color.Red;
            this.button_AFoul1.Location = new System.Drawing.Point(54, 350);
            this.button_AFoul1.Name = "button_AFoul1";
            this.button_AFoul1.Size = new System.Drawing.Size(160, 72);
            this.button_AFoul1.TabIndex = 85;
            this.button_AFoul1.Text = "失误";
            this.button_AFoul1.UseVisualStyleBackColor = true;
            this.button_AFoul1.Click += new System.EventHandler(this.button_AFoul1_Click);
            // 
            // label_RedBG
            // 
            this.label_RedBG.BackColor = System.Drawing.Color.Red;
            this.label_RedBG.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label_RedBG.Location = new System.Drawing.Point(0, 0);
            this.label_RedBG.Name = "label_RedBG";
            this.label_RedBG.Size = new System.Drawing.Size(920, 120);
            this.label_RedBG.TabIndex = 88;
            // 
            // label_BlueBG
            // 
            this.label_BlueBG.BackColor = System.Drawing.Color.DodgerBlue;
            this.label_BlueBG.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label_BlueBG.Location = new System.Drawing.Point(1000, 0);
            this.label_BlueBG.Name = "label_BlueBG";
            this.label_BlueBG.Size = new System.Drawing.Size(920, 120);
            this.label_BlueBG.TabIndex = 89;
            // 
            // label_GameCount
            // 
            this.label_GameCount.BackColor = System.Drawing.Color.Transparent;
            this.label_GameCount.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_GameCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(124)))), ((int)(((byte)(176)))));
            this.label_GameCount.Location = new System.Drawing.Point(1562, 128);
            this.label_GameCount.Name = "label_GameCount";
            this.label_GameCount.Size = new System.Drawing.Size(189, 61);
            this.label_GameCount.TabIndex = 90;
            this.label_GameCount.Text = "上半场";
            this.label_GameCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_Continue
            // 
            this.button_Continue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Continue.Font = new System.Drawing.Font("微软雅黑 Light", 10.8F);
            this.button_Continue.ForeColor = System.Drawing.Color.Green;
            this.button_Continue.Location = new System.Drawing.Point(1735, 788);
            this.button_Continue.Name = "button_Continue";
            this.button_Continue.Size = new System.Drawing.Size(120, 40);
            this.button_Continue.TabIndex = 91;
            this.button_Continue.Text = "下一节";
            this.button_Continue.UseVisualStyleBackColor = true;
            this.button_Continue.Click += new System.EventHandler(this.button_Continue_Click);
            // 
            // label_APauseNum
            // 
            this.label_APauseNum.Font = new System.Drawing.Font("微软雅黑", 24F);
            this.label_APauseNum.ForeColor = System.Drawing.Color.Red;
            this.label_APauseNum.Location = new System.Drawing.Point(243, 246);
            this.label_APauseNum.Name = "label_APauseNum";
            this.label_APauseNum.Size = new System.Drawing.Size(98, 46);
            this.label_APauseNum.TabIndex = 93;
            this.label_APauseNum.Text = "0";
            this.label_APauseNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_AFoul1Num
            // 
            this.label_AFoul1Num.Font = new System.Drawing.Font("微软雅黑", 24F);
            this.label_AFoul1Num.ForeColor = System.Drawing.Color.Red;
            this.label_AFoul1Num.Location = new System.Drawing.Point(243, 362);
            this.label_AFoul1Num.Name = "label_AFoul1Num";
            this.label_AFoul1Num.Size = new System.Drawing.Size(98, 46);
            this.label_AFoul1Num.TabIndex = 94;
            this.label_AFoul1Num.Text = "0";
            this.label_AFoul1Num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_AFoul2Num
            // 
            this.label_AFoul2Num.Font = new System.Drawing.Font("微软雅黑", 24F);
            this.label_AFoul2Num.ForeColor = System.Drawing.Color.Red;
            this.label_AFoul2Num.Location = new System.Drawing.Point(243, 482);
            this.label_AFoul2Num.Name = "label_AFoul2Num";
            this.label_AFoul2Num.Size = new System.Drawing.Size(98, 46);
            this.label_AFoul2Num.TabIndex = 95;
            this.label_AFoul2Num.Text = "0";
            this.label_AFoul2Num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_BPauseNum
            // 
            this.label_BPauseNum.Font = new System.Drawing.Font("微软雅黑", 24F);
            this.label_BPauseNum.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_BPauseNum.Location = new System.Drawing.Point(1589, 242);
            this.label_BPauseNum.Name = "label_BPauseNum";
            this.label_BPauseNum.Size = new System.Drawing.Size(98, 46);
            this.label_BPauseNum.TabIndex = 96;
            this.label_BPauseNum.Text = "0";
            this.label_BPauseNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_BFoul1Num
            // 
            this.label_BFoul1Num.Font = new System.Drawing.Font("微软雅黑", 24F);
            this.label_BFoul1Num.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_BFoul1Num.Location = new System.Drawing.Point(1589, 362);
            this.label_BFoul1Num.Name = "label_BFoul1Num";
            this.label_BFoul1Num.Size = new System.Drawing.Size(98, 46);
            this.label_BFoul1Num.TabIndex = 97;
            this.label_BFoul1Num.Text = "0";
            this.label_BFoul1Num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_BFoul2Num
            // 
            this.label_BFoul2Num.Font = new System.Drawing.Font("微软雅黑", 24F);
            this.label_BFoul2Num.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_BFoul2Num.Location = new System.Drawing.Point(1589, 482);
            this.label_BFoul2Num.Name = "label_BFoul2Num";
            this.label_BFoul2Num.Size = new System.Drawing.Size(98, 46);
            this.label_BFoul2Num.TabIndex = 98;
            this.label_BFoul2Num.Text = "0";
            this.label_BFoul2Num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.label_BFoul2Num);
            this.Controls.Add(this.label_BFoul1Num);
            this.Controls.Add(this.label_BPauseNum);
            this.Controls.Add(this.label_AFoul2Num);
            this.Controls.Add(this.label_AFoul1Num);
            this.Controls.Add(this.label_APauseNum);
            this.Controls.Add(this.button_Continue);
            this.Controls.Add(this.label_GameCount);
            this.Controls.Add(this.label_BlueBG);
            this.Controls.Add(this.label_RedBG);
            this.Controls.Add(this.button_AFoul2);
            this.Controls.Add(this.button_AFoul1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_CountDown);
            this.Controls.Add(this.button_set);
            this.Controls.Add(this.button_AReset);
            this.Controls.Add(this.button_BReset);
            this.Controls.Add(this.button_video);
            this.Controls.Add(this.button_BFoul2);
            this.Controls.Add(this.button_BFoul1);
            this.Controls.Add(this.numericUpDownScoreB);
            this.Controls.Add(this.numericUpDownScoreA);
            this.Controls.Add(this.button_restart);
            this.Controls.Add(this.labelBScore);
            this.Controls.Add(this.labelAScore);
            this.Controls.Add(this.label_CarB);
            this.Controls.Add(this.label_CarA);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.pbCamera);
            this.Name = "Tracker";
            this.Text = "EDC20HOST";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Tracker_FormClosed);
            this.Load += new System.EventHandler(this.Tracker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScoreA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScoreB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbCamera;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Timer timer100ms;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Label label_CarA;
        private System.Windows.Forms.Label label_CarB;
        private System.Windows.Forms.Button button_restart;
        private System.Windows.Forms.NumericUpDown numericUpDownScoreA;
        private System.Windows.Forms.NumericUpDown numericUpDownScoreB;
        private System.Windows.Forms.Button button_video;
        private System.Windows.Forms.Button button_BReset;
        private System.Windows.Forms.Button button_AReset;
        private System.Windows.Forms.Button button_set;
        private System.Windows.Forms.Label labelBScore;
        private System.Windows.Forms.Label labelAScore;
        private System.Windows.Forms.Label label_CountDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_BFoul1;
        private System.Windows.Forms.Button button_BFoul2;
        private System.Windows.Forms.Button button_AFoul2;
        private System.Windows.Forms.Button button_AFoul1;
        private System.Windows.Forms.Label label_RedBG;
        private System.Windows.Forms.Label label_BlueBG;
        private System.Windows.Forms.Label label_GameCount;
        private System.Windows.Forms.Button button_Continue;
        private System.Windows.Forms.Label label_APauseNum;
        private System.Windows.Forms.Label label_AFoul1Num;
        private System.Windows.Forms.Label label_AFoul2Num;
        private System.Windows.Forms.Label label_BPauseNum;
        private System.Windows.Forms.Label label_BFoul1Num;
        private System.Windows.Forms.Label label_BFoul2Num;
    }
}

