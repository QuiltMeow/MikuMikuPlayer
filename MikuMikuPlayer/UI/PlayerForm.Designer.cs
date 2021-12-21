namespace MikuMikuPlayer
{
    partial class PlayerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerForm));
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.pbMax = new System.Windows.Forms.PictureBox();
            this.pbMin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).BeginInit();
            this.SuspendLayout();
            // 
            // pbClose
            // 
            this.pbClose.BackColor = System.Drawing.Color.Transparent;
            this.pbClose.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Close;
            this.pbClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbClose.Location = new System.Drawing.Point(595, 0);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(40, 12);
            this.pbClose.TabIndex = 1;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // pbMax
            // 
            this.pbMax.BackColor = System.Drawing.Color.Transparent;
            this.pbMax.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Max;
            this.pbMax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMax.Location = new System.Drawing.Point(555, 0);
            this.pbMax.Name = "pbMax";
            this.pbMax.Size = new System.Drawing.Size(40, 12);
            this.pbMax.TabIndex = 2;
            this.pbMax.TabStop = false;
            this.pbMax.Click += new System.EventHandler(this.pbMax_Click);
            // 
            // pbMin
            // 
            this.pbMin.BackColor = System.Drawing.Color.Transparent;
            this.pbMin.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Min;
            this.pbMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMin.Location = new System.Drawing.Point(515, 0);
            this.pbMin.Name = "pbMin";
            this.pbMin.Size = new System.Drawing.Size(40, 12);
            this.pbMin.TabIndex = 3;
            this.pbMin.TabStop = false;
            this.pbMin.Click += new System.EventHandler(this.pbMin_Click);
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.BgPlayer;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(645, 370);
            this.Controls.Add(this.pbMin);
            this.Controls.Add(this.pbMax);
            this.Controls.Add(this.pbClose);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 550);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "PlayerForm";
            this.Text = "Player";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerForm_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.formLocationMouseDownEvent);
            this.Resize += new System.EventHandler(this.PlayerForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pbClose;
        public System.Windows.Forms.PictureBox pbMax;
        public System.Windows.Forms.PictureBox pbMin;
    }
}