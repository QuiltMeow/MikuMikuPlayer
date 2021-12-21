namespace MikuMikuPlayer
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.pbPlay = new System.Windows.Forms.PictureBox();
            this.pbStop = new System.Windows.Forms.PictureBox();
            this.pbPrev = new System.Windows.Forms.PictureBox();
            this.pbNext = new System.Windows.Forms.PictureBox();
            this.pbVolume = new System.Windows.Forms.PictureBox();
            this.pbPlayList = new System.Windows.Forms.PictureBox();
            this.pbReplay = new System.Windows.Forms.PictureBox();
            this.pbRandom = new System.Windows.Forms.PictureBox();
            this.pbHelp = new System.Windows.Forms.PictureBox();
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            this.labelCurrentPlay = new System.Windows.Forms.Label();
            this.timerMarquee = new System.Windows.Forms.Timer(this.components);
            this.pbSetting = new System.Windows.Forms.PictureBox();
            this.pbLeftHide = new System.Windows.Forms.PictureBox();
            this.pbRightHide = new System.Windows.Forms.PictureBox();
            this.cmsRightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiSpectrum = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTopMost = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpacity = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLockLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRestart = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRandom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightHide)).BeginInit();
            this.cmsRightMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbExit
            // 
            this.pbExit.BackColor = System.Drawing.Color.Transparent;
            this.pbExit.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Exit;
            this.pbExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbExit.Location = new System.Drawing.Point(165, 35);
            this.pbExit.Margin = new System.Windows.Forms.Padding(2);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(40, 40);
            this.pbExit.TabIndex = 0;
            this.pbExit.TabStop = false;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // pbPlay
            // 
            this.pbPlay.BackColor = System.Drawing.Color.Transparent;
            this.pbPlay.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Play;
            this.pbPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPlay.Location = new System.Drawing.Point(5, 230);
            this.pbPlay.Margin = new System.Windows.Forms.Padding(2);
            this.pbPlay.Name = "pbPlay";
            this.pbPlay.Size = new System.Drawing.Size(45, 45);
            this.pbPlay.TabIndex = 1;
            this.pbPlay.TabStop = false;
            this.pbPlay.Click += new System.EventHandler(this.pbPlay_Click);
            this.pbPlay.MouseEnter += new System.EventHandler(this.pbPlay_MouseEnter);
            this.pbPlay.MouseLeave += new System.EventHandler(this.pbPlay_MouseLeave);
            // 
            // pbStop
            // 
            this.pbStop.BackColor = System.Drawing.Color.Transparent;
            this.pbStop.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Stop;
            this.pbStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbStop.Location = new System.Drawing.Point(54, 235);
            this.pbStop.Margin = new System.Windows.Forms.Padding(2);
            this.pbStop.Name = "pbStop";
            this.pbStop.Size = new System.Drawing.Size(40, 40);
            this.pbStop.TabIndex = 2;
            this.pbStop.TabStop = false;
            this.pbStop.Click += new System.EventHandler(this.pbStop_Click);
            // 
            // pbPrev
            // 
            this.pbPrev.BackColor = System.Drawing.Color.Transparent;
            this.pbPrev.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Prev;
            this.pbPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPrev.Location = new System.Drawing.Point(98, 235);
            this.pbPrev.Margin = new System.Windows.Forms.Padding(2);
            this.pbPrev.Name = "pbPrev";
            this.pbPrev.Size = new System.Drawing.Size(40, 40);
            this.pbPrev.TabIndex = 3;
            this.pbPrev.TabStop = false;
            this.pbPrev.Click += new System.EventHandler(this.pbPrev_Click);
            // 
            // pbNext
            // 
            this.pbNext.BackColor = System.Drawing.Color.Transparent;
            this.pbNext.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Next;
            this.pbNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbNext.Location = new System.Drawing.Point(142, 235);
            this.pbNext.Margin = new System.Windows.Forms.Padding(2);
            this.pbNext.Name = "pbNext";
            this.pbNext.Size = new System.Drawing.Size(40, 40);
            this.pbNext.TabIndex = 4;
            this.pbNext.TabStop = false;
            this.pbNext.Click += new System.EventHandler(this.pbNext_Click);
            // 
            // pbVolume
            // 
            this.pbVolume.BackColor = System.Drawing.Color.Transparent;
            this.pbVolume.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Volume_5;
            this.pbVolume.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbVolume.Location = new System.Drawing.Point(186, 239);
            this.pbVolume.Margin = new System.Windows.Forms.Padding(2);
            this.pbVolume.Name = "pbVolume";
            this.pbVolume.Size = new System.Drawing.Size(50, 25);
            this.pbVolume.TabIndex = 5;
            this.pbVolume.TabStop = false;
            // 
            // pbPlayList
            // 
            this.pbPlayList.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayList.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.PlayList;
            this.pbPlayList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPlayList.Location = new System.Drawing.Point(190, 210);
            this.pbPlayList.Margin = new System.Windows.Forms.Padding(2);
            this.pbPlayList.Name = "pbPlayList";
            this.pbPlayList.Size = new System.Drawing.Size(25, 25);
            this.pbPlayList.TabIndex = 6;
            this.pbPlayList.TabStop = false;
            this.pbPlayList.Click += new System.EventHandler(this.pbPlayList_Click);
            // 
            // pbReplay
            // 
            this.pbReplay.BackColor = System.Drawing.Color.Transparent;
            this.pbReplay.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Replay;
            this.pbReplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbReplay.Location = new System.Drawing.Point(35, 279);
            this.pbReplay.Margin = new System.Windows.Forms.Padding(2);
            this.pbReplay.Name = "pbReplay";
            this.pbReplay.Size = new System.Drawing.Size(25, 25);
            this.pbReplay.TabIndex = 7;
            this.pbReplay.TabStop = false;
            this.pbReplay.Click += new System.EventHandler(this.pbReplay_Click);
            this.pbReplay.MouseEnter += new System.EventHandler(this.pbReplay_MouseEnter);
            this.pbReplay.MouseLeave += new System.EventHandler(this.pbReplay_MouseLeave);
            // 
            // pbRandom
            // 
            this.pbRandom.BackColor = System.Drawing.Color.Transparent;
            this.pbRandom.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Random;
            this.pbRandom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbRandom.Location = new System.Drawing.Point(64, 279);
            this.pbRandom.Margin = new System.Windows.Forms.Padding(2);
            this.pbRandom.Name = "pbRandom";
            this.pbRandom.Size = new System.Drawing.Size(25, 25);
            this.pbRandom.TabIndex = 8;
            this.pbRandom.TabStop = false;
            this.pbRandom.Click += new System.EventHandler(this.pbRandom_Click);
            this.pbRandom.MouseEnter += new System.EventHandler(this.pbRandom_MouseEnter);
            this.pbRandom.MouseLeave += new System.EventHandler(this.pbRandom_MouseLeave);
            // 
            // pbHelp
            // 
            this.pbHelp.BackColor = System.Drawing.Color.Transparent;
            this.pbHelp.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Help;
            this.pbHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbHelp.Location = new System.Drawing.Point(135, 50);
            this.pbHelp.Margin = new System.Windows.Forms.Padding(2);
            this.pbHelp.Name = "pbHelp";
            this.pbHelp.Size = new System.Drawing.Size(25, 25);
            this.pbHelp.TabIndex = 9;
            this.pbHelp.TabStop = false;
            this.pbHelp.Click += new System.EventHandler(this.pbHelp_Click);
            // 
            // pbPlayer
            // 
            this.pbPlayer.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayer.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Player;
            this.pbPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPlayer.Location = new System.Drawing.Point(125, 279);
            this.pbPlayer.Margin = new System.Windows.Forms.Padding(2);
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.Size = new System.Drawing.Size(25, 25);
            this.pbPlayer.TabIndex = 10;
            this.pbPlayer.TabStop = false;
            this.pbPlayer.Click += new System.EventHandler(this.pbPlayer_Click);
            // 
            // labelCurrentPlay
            // 
            this.labelCurrentPlay.AutoSize = true;
            this.labelCurrentPlay.BackColor = System.Drawing.Color.Transparent;
            this.labelCurrentPlay.Location = new System.Drawing.Point(180, 185);
            this.labelCurrentPlay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCurrentPlay.Name = "labelCurrentPlay";
            this.labelCurrentPlay.Size = new System.Drawing.Size(35, 12);
            this.labelCurrentPlay.TabIndex = 0;
            this.labelCurrentPlay.Text = "NULL";
            this.labelCurrentPlay.MouseEnter += new System.EventHandler(this.labelCurrentPlay_MouseEnter);
            this.labelCurrentPlay.MouseLeave += new System.EventHandler(this.labelCurrentPlay_MouseLeave);
            // 
            // timerMarquee
            // 
            this.timerMarquee.Interval = 200;
            this.timerMarquee.Tick += new System.EventHandler(this.timerMarquee_Tick);
            // 
            // pbSetting
            // 
            this.pbSetting.BackColor = System.Drawing.Color.Transparent;
            this.pbSetting.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Setting;
            this.pbSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbSetting.Location = new System.Drawing.Point(105, 50);
            this.pbSetting.Margin = new System.Windows.Forms.Padding(2);
            this.pbSetting.Name = "pbSetting";
            this.pbSetting.Size = new System.Drawing.Size(25, 25);
            this.pbSetting.TabIndex = 14;
            this.pbSetting.TabStop = false;
            this.pbSetting.Click += new System.EventHandler(this.pbSetting_Click);
            // 
            // pbLeftHide
            // 
            this.pbLeftHide.BackColor = System.Drawing.Color.Transparent;
            this.pbLeftHide.Location = new System.Drawing.Point(0, 0);
            this.pbLeftHide.Name = "pbLeftHide";
            this.pbLeftHide.Size = new System.Drawing.Size(30, 220);
            this.pbLeftHide.TabIndex = 15;
            this.pbLeftHide.TabStop = false;
            // 
            // pbRightHide
            // 
            this.pbRightHide.BackColor = System.Drawing.Color.Transparent;
            this.pbRightHide.Location = new System.Drawing.Point(220, 0);
            this.pbRightHide.Name = "pbRightHide";
            this.pbRightHide.Size = new System.Drawing.Size(30, 220);
            this.pbRightHide.TabIndex = 16;
            this.pbRightHide.TabStop = false;
            // 
            // cmsRightMenu
            // 
            this.cmsRightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSpectrum,
            this.tsmiTopMost,
            this.tsmiOpacity,
            this.tsmiLockLocation,
            this.tsmiRestart,
            this.tsmiAbout});
            this.cmsRightMenu.Name = "cmsRightMenu";
            this.cmsRightMenu.Size = new System.Drawing.Size(181, 158);
            // 
            // tsmiSpectrum
            // 
            this.tsmiSpectrum.Name = "tsmiSpectrum";
            this.tsmiSpectrum.Size = new System.Drawing.Size(180, 22);
            this.tsmiSpectrum.Text = "音訊視覺化顯示";
            this.tsmiSpectrum.Click += new System.EventHandler(this.tsmiSpectrum_Click);
            // 
            // tsmiTopMost
            // 
            this.tsmiTopMost.Name = "tsmiTopMost";
            this.tsmiTopMost.Size = new System.Drawing.Size(180, 22);
            this.tsmiTopMost.Text = "最上層顯示";
            this.tsmiTopMost.Click += new System.EventHandler(this.tsmiTopMost_Click);
            // 
            // tsmiOpacity
            // 
            this.tsmiOpacity.Checked = true;
            this.tsmiOpacity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiOpacity.Name = "tsmiOpacity";
            this.tsmiOpacity.Size = new System.Drawing.Size(180, 22);
            this.tsmiOpacity.Text = "透明效果";
            this.tsmiOpacity.Click += new System.EventHandler(this.tsmiOpacity_Click);
            // 
            // tsmiLockLocation
            // 
            this.tsmiLockLocation.Name = "tsmiLockLocation";
            this.tsmiLockLocation.Size = new System.Drawing.Size(180, 22);
            this.tsmiLockLocation.Text = "鎖定位置";
            this.tsmiLockLocation.Click += new System.EventHandler(this.tsmiLockLocation_Click);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(180, 22);
            this.tsmiAbout.Text = "關於";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // tsmiRestart
            // 
            this.tsmiRestart.Name = "tsmiRestart";
            this.tsmiRestart.Size = new System.Drawing.Size(180, 22);
            this.tsmiRestart.Text = "重新啟動";
            this.tsmiRestart.Click += new System.EventHandler(this.tsmiRestart_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Main;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(250, 315);
            this.Controls.Add(this.pbLeftHide);
            this.Controls.Add(this.pbRightHide);
            this.Controls.Add(this.pbSetting);
            this.Controls.Add(this.labelCurrentPlay);
            this.Controls.Add(this.pbPlayer);
            this.Controls.Add(this.pbHelp);
            this.Controls.Add(this.pbRandom);
            this.Controls.Add(this.pbReplay);
            this.Controls.Add(this.pbPlayList);
            this.Controls.Add(this.pbVolume);
            this.Controls.Add(this.pbNext);
            this.Controls.Add(this.pbPrev);
            this.Controls.Add(this.pbStop);
            this.Controls.Add(this.pbPlay);
            this.Controls.Add(this.pbExit);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Miku Miku Player";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRandom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightHide)).EndInit();
            this.cmsRightMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pbExit;
        public System.Windows.Forms.PictureBox pbPlay;
        public System.Windows.Forms.PictureBox pbStop;
        public System.Windows.Forms.PictureBox pbPrev;
        public System.Windows.Forms.PictureBox pbNext;
        public System.Windows.Forms.PictureBox pbVolume;
        public System.Windows.Forms.PictureBox pbPlayList;
        public System.Windows.Forms.PictureBox pbReplay;
        public System.Windows.Forms.PictureBox pbRandom;
        public System.Windows.Forms.PictureBox pbHelp;
        public System.Windows.Forms.PictureBox pbPlayer;
        public System.Windows.Forms.PictureBox pbSetting;
        public System.Windows.Forms.Label labelCurrentPlay;
        private System.Windows.Forms.PictureBox pbLeftHide;
        private System.Windows.Forms.PictureBox pbRightHide;
        public System.Windows.Forms.Timer timerMarquee;
        private System.Windows.Forms.ContextMenuStrip cmsRightMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiTopMost;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpacity;
        private System.Windows.Forms.ToolStripMenuItem tsmiSpectrum;
        private System.Windows.Forms.ToolStripMenuItem tsmiLockLocation;
        private System.Windows.Forms.ToolStripMenuItem tsmiRestart;
    }
}