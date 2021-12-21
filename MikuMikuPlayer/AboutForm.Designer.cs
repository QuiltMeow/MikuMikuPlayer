namespace MikuMikuPlayer
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.smallru8 = new System.Windows.Forms.PictureBox();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.pbBackground = new System.Windows.Forms.PictureBox();
            this.pbExit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.smallru8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).BeginInit();
            this.pbBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            this.SuspendLayout();
            // 
            // smallru8
            // 
            this.smallru8.BackColor = System.Drawing.Color.Transparent;
            this.smallru8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("smallru8.BackgroundImage")));
            this.smallru8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smallru8.Location = new System.Drawing.Point(12, 12);
            this.smallru8.Name = "smallru8";
            this.smallru8.Size = new System.Drawing.Size(100, 100);
            this.smallru8.TabIndex = 0;
            this.smallru8.TabStop = false;
            this.smallru8.Click += new System.EventHandler(this.smallru8_Click);
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.BackColor = System.Drawing.Color.Transparent;
            this.labelAuthor.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelAuthor.ForeColor = System.Drawing.Color.Purple;
            this.labelAuthor.Location = new System.Drawing.Point(130, 25);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(149, 60);
            this.labelAuthor.TabIndex = 1;
            this.labelAuthor.Text = "Miku Miku 播放器\r\n原始作者 : smallru8\r\n程式重構 : 棉被";
            // 
            // pbBackground
            // 
            this.pbBackground.BackColor = System.Drawing.Color.Transparent;
            this.pbBackground.BackgroundImage = global::MikuMikuPlayer.ExtraResource.BeastTamer;
            this.pbBackground.Controls.Add(this.labelAuthor);
            this.pbBackground.Controls.Add(this.smallru8);
            this.pbBackground.Controls.Add(this.pbExit);
            this.pbBackground.Location = new System.Drawing.Point(12, 12);
            this.pbBackground.Name = "pbBackground";
            this.pbBackground.Size = new System.Drawing.Size(616, 336);
            this.pbBackground.TabIndex = 2;
            this.pbBackground.TabStop = false;
            this.pbBackground.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbBackground_MouseDown);
            // 
            // pbExit
            // 
            this.pbExit.BackColor = System.Drawing.Color.Transparent;
            this.pbExit.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Exit;
            this.pbExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbExit.Location = new System.Drawing.Point(591, 0);
            this.pbExit.Margin = new System.Windows.Forms.Padding(2);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(25, 25);
            this.pbExit.TabIndex = 3;
            this.pbExit.TabStop = false;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.BgPlayer;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(640, 360);
            this.Controls.Add(this.pbBackground);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "About";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AboutForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.smallru8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).EndInit();
            this.pbBackground.ResumeLayout(false);
            this.pbBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox smallru8;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.PictureBox pbBackground;
        public System.Windows.Forms.PictureBox pbExit;
    }
}