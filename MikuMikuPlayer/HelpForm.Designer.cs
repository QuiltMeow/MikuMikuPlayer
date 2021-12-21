namespace MikuMikuPlayer
{
    partial class HelpForm
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
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.labelHelp = new System.Windows.Forms.Label();
            this.labelHelpContent = new System.Windows.Forms.Label();
            this.pbPlayList = new System.Windows.Forms.PictureBox();
            this.pbReplay = new System.Windows.Forms.PictureBox();
            this.pbRandom = new System.Windows.Forms.PictureBox();
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            this.labelPlayList = new System.Windows.Forms.Label();
            this.labelReplay = new System.Windows.Forms.Label();
            this.labelRandom = new System.Windows.Forms.Label();
            this.labelPlayer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRandom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // pbExit
            // 
            this.pbExit.BackColor = System.Drawing.Color.Transparent;
            this.pbExit.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Exit;
            this.pbExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbExit.Location = new System.Drawing.Point(220, 10);
            this.pbExit.Margin = new System.Windows.Forms.Padding(2);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(25, 25);
            this.pbExit.TabIndex = 2;
            this.pbExit.TabStop = false;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // labelHelp
            // 
            this.labelHelp.AutoSize = true;
            this.labelHelp.BackColor = System.Drawing.Color.Transparent;
            this.labelHelp.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelHelp.Location = new System.Drawing.Point(20, 30);
            this.labelHelp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(40, 16);
            this.labelHelp.TabIndex = 0;
            this.labelHelp.Text = "說明";
            // 
            // labelHelpContent
            // 
            this.labelHelpContent.AutoSize = true;
            this.labelHelpContent.BackColor = System.Drawing.Color.Transparent;
            this.labelHelpContent.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelHelpContent.Location = new System.Drawing.Point(20, 60);
            this.labelHelpContent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHelpContent.Name = "labelHelpContent";
            this.labelHelpContent.Size = new System.Drawing.Size(72, 16);
            this.labelHelpContent.TabIndex = 1;
            this.labelHelpContent.Text = "說明內容";
            // 
            // pbPlayList
            // 
            this.pbPlayList.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayList.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.PlayList;
            this.pbPlayList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPlayList.Location = new System.Drawing.Point(24, 115);
            this.pbPlayList.Margin = new System.Windows.Forms.Padding(2);
            this.pbPlayList.Name = "pbPlayList";
            this.pbPlayList.Size = new System.Drawing.Size(25, 25);
            this.pbPlayList.TabIndex = 5;
            this.pbPlayList.TabStop = false;
            this.pbPlayList.Visible = false;
            // 
            // pbReplay
            // 
            this.pbReplay.BackColor = System.Drawing.Color.Transparent;
            this.pbReplay.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Replay;
            this.pbReplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbReplay.Location = new System.Drawing.Point(24, 155);
            this.pbReplay.Margin = new System.Windows.Forms.Padding(2);
            this.pbReplay.Name = "pbReplay";
            this.pbReplay.Size = new System.Drawing.Size(25, 25);
            this.pbReplay.TabIndex = 6;
            this.pbReplay.TabStop = false;
            this.pbReplay.Visible = false;
            // 
            // pbRandom
            // 
            this.pbRandom.BackColor = System.Drawing.Color.Transparent;
            this.pbRandom.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Random;
            this.pbRandom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbRandom.Location = new System.Drawing.Point(24, 195);
            this.pbRandom.Margin = new System.Windows.Forms.Padding(2);
            this.pbRandom.Name = "pbRandom";
            this.pbRandom.Size = new System.Drawing.Size(25, 25);
            this.pbRandom.TabIndex = 7;
            this.pbRandom.TabStop = false;
            this.pbRandom.Visible = false;
            // 
            // pbPlayer
            // 
            this.pbPlayer.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayer.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Player;
            this.pbPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPlayer.Location = new System.Drawing.Point(24, 235);
            this.pbPlayer.Margin = new System.Windows.Forms.Padding(2);
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.Size = new System.Drawing.Size(25, 25);
            this.pbPlayer.TabIndex = 8;
            this.pbPlayer.TabStop = false;
            this.pbPlayer.Visible = false;
            // 
            // labelPlayList
            // 
            this.labelPlayList.AutoSize = true;
            this.labelPlayList.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayList.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelPlayList.Location = new System.Drawing.Point(60, 115);
            this.labelPlayList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPlayList.Name = "labelPlayList";
            this.labelPlayList.Size = new System.Drawing.Size(120, 16);
            this.labelPlayList.TabIndex = 2;
            this.labelPlayList.Text = "可開啟播放清單";
            this.labelPlayList.Visible = false;
            // 
            // labelReplay
            // 
            this.labelReplay.AutoSize = true;
            this.labelReplay.BackColor = System.Drawing.Color.Transparent;
            this.labelReplay.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelReplay.Location = new System.Drawing.Point(60, 155);
            this.labelReplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelReplay.Name = "labelReplay";
            this.labelReplay.Size = new System.Drawing.Size(152, 16);
            this.labelReplay.TabIndex = 3;
            this.labelReplay.Text = "可選擇是否重複播放";
            this.labelReplay.Visible = false;
            // 
            // labelRandom
            // 
            this.labelRandom.AutoSize = true;
            this.labelRandom.BackColor = System.Drawing.Color.Transparent;
            this.labelRandom.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelRandom.Location = new System.Drawing.Point(60, 195);
            this.labelRandom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRandom.Name = "labelRandom";
            this.labelRandom.Size = new System.Drawing.Size(152, 16);
            this.labelRandom.TabIndex = 4;
            this.labelRandom.Text = "可選擇是否隨機播放";
            this.labelRandom.Visible = false;
            // 
            // labelPlayer
            // 
            this.labelPlayer.AutoSize = true;
            this.labelPlayer.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayer.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelPlayer.Location = new System.Drawing.Point(60, 235);
            this.labelPlayer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPlayer.Name = "labelPlayer";
            this.labelPlayer.Size = new System.Drawing.Size(136, 16);
            this.labelPlayer.TabIndex = 5;
            this.labelPlayer.Text = "可顯示播放器介面";
            this.labelPlayer.Visible = false;
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.BgPlayList;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(250, 315);
            this.Controls.Add(this.labelPlayer);
            this.Controls.Add(this.labelRandom);
            this.Controls.Add(this.labelReplay);
            this.Controls.Add(this.labelPlayList);
            this.Controls.Add(this.pbPlayer);
            this.Controls.Add(this.pbRandom);
            this.Controls.Add(this.pbReplay);
            this.Controls.Add(this.pbPlayList);
            this.Controls.Add(this.labelHelpContent);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.pbExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HelpForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Help";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HelpForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRandom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelHelp;
        public System.Windows.Forms.Label labelHelpContent;
        public System.Windows.Forms.PictureBox pbExit;
        public System.Windows.Forms.PictureBox pbPlayList;
        public System.Windows.Forms.PictureBox pbReplay;
        public System.Windows.Forms.PictureBox pbRandom;
        public System.Windows.Forms.PictureBox pbPlayer;
        public System.Windows.Forms.Label labelPlayList;
        public System.Windows.Forms.Label labelReplay;
        public System.Windows.Forms.Label labelRandom;
        public System.Windows.Forms.Label labelPlayer;
    }
}