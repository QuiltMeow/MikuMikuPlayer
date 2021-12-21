namespace MikuMikuPlayer
{
    partial class SpectrumForm
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
            this.barLeft = new System.Windows.Forms.ProgressBar();
            this.barRight = new System.Windows.Forms.ProgressBar();
            this.labelLeft = new System.Windows.Forms.Label();
            this.labelRight = new System.Windows.Forms.Label();
            this.cbDeviceList = new System.Windows.Forms.ComboBox();
            this.ehSpectrum = new System.Windows.Forms.Integration.ElementHost();
            this.spectrum = new MikuMikuPlayer.Spectrum();
            this.btnEnable = new System.Windows.Forms.Button();
            this.labelDeviceList = new System.Windows.Forms.Label();
            this.pbClose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // barLeft
            // 
            this.barLeft.Location = new System.Drawing.Point(45, 115);
            this.barLeft.Name = "barLeft";
            this.barLeft.Size = new System.Drawing.Size(150, 23);
            this.barLeft.TabIndex = 2;
            // 
            // barRight
            // 
            this.barRight.Location = new System.Drawing.Point(300, 115);
            this.barRight.Name = "barRight";
            this.barRight.Size = new System.Drawing.Size(150, 23);
            this.barRight.TabIndex = 3;
            // 
            // labelLeft
            // 
            this.labelLeft.AutoSize = true;
            this.labelLeft.BackColor = System.Drawing.Color.Transparent;
            this.labelLeft.Location = new System.Drawing.Point(27, 123);
            this.labelLeft.Name = "labelLeft";
            this.labelLeft.Size = new System.Drawing.Size(12, 12);
            this.labelLeft.TabIndex = 1;
            this.labelLeft.Text = "L";
            // 
            // labelRight
            // 
            this.labelRight.AutoSize = true;
            this.labelRight.BackColor = System.Drawing.Color.Transparent;
            this.labelRight.Location = new System.Drawing.Point(456, 123);
            this.labelRight.Name = "labelRight";
            this.labelRight.Size = new System.Drawing.Size(13, 12);
            this.labelRight.TabIndex = 4;
            this.labelRight.Text = "R";
            // 
            // cbDeviceList
            // 
            this.cbDeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeviceList.FormattingEnabled = true;
            this.cbDeviceList.Location = new System.Drawing.Point(170, 160);
            this.cbDeviceList.Name = "cbDeviceList";
            this.cbDeviceList.Size = new System.Drawing.Size(137, 20);
            this.cbDeviceList.TabIndex = 6;
            // 
            // ehSpectrum
            // 
            this.ehSpectrum.Location = new System.Drawing.Point(12, 12);
            this.ehSpectrum.Name = "ehSpectrum";
            this.ehSpectrum.Size = new System.Drawing.Size(480, 95);
            this.ehSpectrum.TabIndex = 0;
            this.ehSpectrum.Child = this.spectrum;
            // 
            // btnEnable
            // 
            this.btnEnable.Location = new System.Drawing.Point(313, 158);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(75, 23);
            this.btnEnable.TabIndex = 7;
            this.btnEnable.Text = "啟用";
            this.btnEnable.UseVisualStyleBackColor = true;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // labelDeviceList
            // 
            this.labelDeviceList.AutoSize = true;
            this.labelDeviceList.BackColor = System.Drawing.Color.Transparent;
            this.labelDeviceList.Location = new System.Drawing.Point(111, 163);
            this.labelDeviceList.Name = "labelDeviceList";
            this.labelDeviceList.Size = new System.Drawing.Size(53, 12);
            this.labelDeviceList.TabIndex = 5;
            this.labelDeviceList.Text = "裝置列表";
            // 
            // pbClose
            // 
            this.pbClose.BackColor = System.Drawing.Color.Transparent;
            this.pbClose.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Close;
            this.pbClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbClose.Location = new System.Drawing.Point(460, 0);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(40, 12);
            this.pbClose.TabIndex = 9;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // SpectrumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.BgPlayer;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(504, 200);
            this.Controls.Add(this.pbClose);
            this.Controls.Add(this.labelDeviceList);
            this.Controls.Add(this.btnEnable);
            this.Controls.Add(this.cbDeviceList);
            this.Controls.Add(this.labelRight);
            this.Controls.Add(this.labelLeft);
            this.Controls.Add(this.barRight);
            this.Controls.Add(this.barLeft);
            this.Controls.Add(this.ehSpectrum);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpectrumForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Sepectrum";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SpectrumForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost ehSpectrum;
        private System.Windows.Forms.ProgressBar barLeft;
        private System.Windows.Forms.ProgressBar barRight;
        private Spectrum spectrum;
        public System.Windows.Forms.PictureBox pbClose;
        public System.Windows.Forms.Label labelLeft;
        public System.Windows.Forms.Label labelRight;
        public System.Windows.Forms.ComboBox cbDeviceList;
        public System.Windows.Forms.Button btnEnable;
        public System.Windows.Forms.Label labelDeviceList;
    }
}

