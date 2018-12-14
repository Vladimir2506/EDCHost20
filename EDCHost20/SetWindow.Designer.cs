namespace EDC20HOST
{
    partial class SetWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBox_DebugMode = new System.Windows.Forms.CheckBox();
            this.nudAreaL = new System.Windows.Forms.NumericUpDown();
            this.lblAreaL = new System.Windows.Forms.Label();
            this.nudValueL = new System.Windows.Forms.NumericUpDown();
            this.lblValueL = new System.Windows.Forms.Label();
            this.nudSat2L = new System.Windows.Forms.NumericUpDown();
            this.lblSat2L = new System.Windows.Forms.Label();
            this.nudSat1L = new System.Windows.Forms.NumericUpDown();
            this.lblSat1L = new System.Windows.Forms.Label();
            this.nudHue2H = new System.Windows.Forms.NumericUpDown();
            this.lblHue2H = new System.Windows.Forms.Label();
            this.nudHue2L = new System.Windows.Forms.NumericUpDown();
            this.lblHue2L = new System.Windows.Forms.Label();
            this.nudHue1H = new System.Windows.Forms.NumericUpDown();
            this.lblHueH = new System.Windows.Forms.Label();
            this.nudHue1L = new System.Windows.Forms.NumericUpDown();
            this.lblHue1L = new System.Windows.Forms.Label();
            this.button_ConfigSave = new System.Windows.Forms.Button();
            this.button_ConfigLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudAreaL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValueL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSat2L)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSat1L)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHue2H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHue2L)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHue1H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHue1L)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox_DebugMode
            // 
            this.checkBox_DebugMode.AutoSize = true;
            this.checkBox_DebugMode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_DebugMode.Location = new System.Drawing.Point(45, 446);
            this.checkBox_DebugMode.Name = "checkBox_DebugMode";
            this.checkBox_DebugMode.Size = new System.Drawing.Size(91, 24);
            this.checkBox_DebugMode.TabIndex = 74;
            this.checkBox_DebugMode.Text = "调试模式";
            this.checkBox_DebugMode.UseVisualStyleBackColor = true;
            this.checkBox_DebugMode.CheckedChanged += new System.EventHandler(this.checkBox_DebugMode_CheckedChanged);
            // 
            // nudAreaL
            // 
            this.nudAreaL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudAreaL.Location = new System.Drawing.Point(106, 392);
            this.nudAreaL.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudAreaL.Name = "nudAreaL";
            this.nudAreaL.Size = new System.Drawing.Size(75, 27);
            this.nudAreaL.TabIndex = 90;
            this.nudAreaL.ValueChanged += new System.EventHandler(this.nudAreaL_ValueChanged);
            // 
            // lblAreaL
            // 
            this.lblAreaL.AutoSize = true;
            this.lblAreaL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAreaL.Location = new System.Drawing.Point(41, 392);
            this.lblAreaL.Name = "lblAreaL";
            this.lblAreaL.Size = new System.Drawing.Size(55, 20);
            this.lblAreaL.TabIndex = 89;
            this.lblAreaL.Text = "AreaL:";
            // 
            // nudValueL
            // 
            this.nudValueL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudValueL.Location = new System.Drawing.Point(106, 342);
            this.nudValueL.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudValueL.Name = "nudValueL";
            this.nudValueL.Size = new System.Drawing.Size(75, 27);
            this.nudValueL.TabIndex = 88;
            this.nudValueL.ValueChanged += new System.EventHandler(this.nudValueL_ValueChanged);
            // 
            // lblValueL
            // 
            this.lblValueL.AutoSize = true;
            this.lblValueL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblValueL.Location = new System.Drawing.Point(41, 342);
            this.lblValueL.Name = "lblValueL";
            this.lblValueL.Size = new System.Drawing.Size(61, 20);
            this.lblValueL.TabIndex = 87;
            this.lblValueL.Text = "ValueL:";
            // 
            // nudSat2L
            // 
            this.nudSat2L.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudSat2L.Location = new System.Drawing.Point(106, 292);
            this.nudSat2L.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudSat2L.Name = "nudSat2L";
            this.nudSat2L.Size = new System.Drawing.Size(75, 27);
            this.nudSat2L.TabIndex = 86;
            this.nudSat2L.ValueChanged += new System.EventHandler(this.nudSat2L_ValueChanged);
            // 
            // lblSat2L
            // 
            this.lblSat2L.AutoSize = true;
            this.lblSat2L.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSat2L.Location = new System.Drawing.Point(41, 292);
            this.lblSat2L.Name = "lblSat2L";
            this.lblSat2L.Size = new System.Drawing.Size(53, 20);
            this.lblSat2L.TabIndex = 85;
            this.lblSat2L.Text = "Sat2L:";
            // 
            // nudSat1L
            // 
            this.nudSat1L.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudSat1L.Location = new System.Drawing.Point(106, 242);
            this.nudSat1L.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudSat1L.Name = "nudSat1L";
            this.nudSat1L.Size = new System.Drawing.Size(75, 27);
            this.nudSat1L.TabIndex = 84;
            this.nudSat1L.ValueChanged += new System.EventHandler(this.nudSat1L_ValueChanged);
            // 
            // lblSat1L
            // 
            this.lblSat1L.AutoSize = true;
            this.lblSat1L.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSat1L.Location = new System.Drawing.Point(41, 242);
            this.lblSat1L.Name = "lblSat1L";
            this.lblSat1L.Size = new System.Drawing.Size(53, 20);
            this.lblSat1L.TabIndex = 83;
            this.lblSat1L.Text = "Sat1L:";
            // 
            // nudHue2H
            // 
            this.nudHue2H.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudHue2H.Location = new System.Drawing.Point(106, 192);
            this.nudHue2H.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudHue2H.Name = "nudHue2H";
            this.nudHue2H.Size = new System.Drawing.Size(75, 27);
            this.nudHue2H.TabIndex = 82;
            // 
            // lblHue2H
            // 
            this.lblHue2H.AutoSize = true;
            this.lblHue2H.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHue2H.Location = new System.Drawing.Point(41, 192);
            this.lblHue2H.Name = "lblHue2H";
            this.lblHue2H.Size = new System.Drawing.Size(64, 20);
            this.lblHue2H.TabIndex = 81;
            this.lblHue2H.Text = "Hue2H:";
            // 
            // nudHue2L
            // 
            this.nudHue2L.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudHue2L.Location = new System.Drawing.Point(106, 142);
            this.nudHue2L.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudHue2L.Name = "nudHue2L";
            this.nudHue2L.Size = new System.Drawing.Size(75, 27);
            this.nudHue2L.TabIndex = 80;
            this.nudHue2L.ValueChanged += new System.EventHandler(this.nudHue2L_ValueChanged);
            // 
            // lblHue2L
            // 
            this.lblHue2L.AutoSize = true;
            this.lblHue2L.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHue2L.Location = new System.Drawing.Point(41, 142);
            this.lblHue2L.Name = "lblHue2L";
            this.lblHue2L.Size = new System.Drawing.Size(60, 20);
            this.lblHue2L.TabIndex = 79;
            this.lblHue2L.Text = "Hue2L:";
            // 
            // nudHue1H
            // 
            this.nudHue1H.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudHue1H.Location = new System.Drawing.Point(106, 92);
            this.nudHue1H.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudHue1H.Name = "nudHue1H";
            this.nudHue1H.Size = new System.Drawing.Size(75, 27);
            this.nudHue1H.TabIndex = 78;
            this.nudHue1H.ValueChanged += new System.EventHandler(this.nudHue1H_ValueChanged);
            // 
            // lblHueH
            // 
            this.lblHueH.AutoSize = true;
            this.lblHueH.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHueH.Location = new System.Drawing.Point(41, 92);
            this.lblHueH.Name = "lblHueH";
            this.lblHueH.Size = new System.Drawing.Size(64, 20);
            this.lblHueH.TabIndex = 77;
            this.lblHueH.Text = "Hue1H:";
            // 
            // nudHue1L
            // 
            this.nudHue1L.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudHue1L.Location = new System.Drawing.Point(106, 42);
            this.nudHue1L.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudHue1L.Name = "nudHue1L";
            this.nudHue1L.Size = new System.Drawing.Size(75, 27);
            this.nudHue1L.TabIndex = 76;
            this.nudHue1L.ValueChanged += new System.EventHandler(this.nudHue1L_ValueChanged);
            // 
            // lblHue1L
            // 
            this.lblHue1L.AutoSize = true;
            this.lblHue1L.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHue1L.Location = new System.Drawing.Point(41, 42);
            this.lblHue1L.Name = "lblHue1L";
            this.lblHue1L.Size = new System.Drawing.Size(60, 20);
            this.lblHue1L.TabIndex = 75;
            this.lblHue1L.Text = "Hue1L:";
            // 
            // button_ConfigSave
            // 
            this.button_ConfigSave.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_ConfigSave.Location = new System.Drawing.Point(392, 158);
            this.button_ConfigSave.Name = "button_ConfigSave";
            this.button_ConfigSave.Size = new System.Drawing.Size(80, 35);
            this.button_ConfigSave.TabIndex = 91;
            this.button_ConfigSave.Text = "保存";
            this.button_ConfigSave.UseVisualStyleBackColor = true;
            this.button_ConfigSave.Click += new System.EventHandler(this.button_ConfigSave_Click);
            // 
            // button_ConfigLoad
            // 
            this.button_ConfigLoad.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_ConfigLoad.Location = new System.Drawing.Point(392, 209);
            this.button_ConfigLoad.Name = "button_ConfigLoad";
            this.button_ConfigLoad.Size = new System.Drawing.Size(80, 35);
            this.button_ConfigLoad.TabIndex = 92;
            this.button_ConfigLoad.Text = "读取";
            this.button_ConfigLoad.UseVisualStyleBackColor = true;
            this.button_ConfigLoad.Click += new System.EventHandler(this.button_ConfigLoad_Click);
            // 
            // SetWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 527);
            this.Controls.Add(this.button_ConfigLoad);
            this.Controls.Add(this.button_ConfigSave);
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
            this.Controls.Add(this.checkBox_DebugMode);
            this.Name = "SetWindow";
            this.Text = "SetWindow";
            ((System.ComponentModel.ISupportInitialize)(this.nudAreaL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValueL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSat2L)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSat1L)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHue2H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHue2L)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHue1H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHue1L)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_DebugMode;
        private System.Windows.Forms.NumericUpDown nudAreaL;
        private System.Windows.Forms.Label lblAreaL;
        private System.Windows.Forms.NumericUpDown nudValueL;
        private System.Windows.Forms.Label lblValueL;
        private System.Windows.Forms.NumericUpDown nudSat2L;
        private System.Windows.Forms.Label lblSat2L;
        private System.Windows.Forms.NumericUpDown nudSat1L;
        private System.Windows.Forms.Label lblSat1L;
        private System.Windows.Forms.NumericUpDown nudHue2H;
        private System.Windows.Forms.Label lblHue2H;
        private System.Windows.Forms.NumericUpDown nudHue2L;
        private System.Windows.Forms.Label lblHue2L;
        private System.Windows.Forms.NumericUpDown nudHue1H;
        private System.Windows.Forms.Label lblHueH;
        private System.Windows.Forms.NumericUpDown nudHue1L;
        private System.Windows.Forms.Label lblHue1L;
        private System.Windows.Forms.Button button_ConfigSave;
        private System.Windows.Forms.Button button_ConfigLoad;
    }
}