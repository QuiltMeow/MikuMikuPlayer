namespace MikuMikuPlayer
{
    partial class PlayListForm
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
            this.pbLoadList = new System.Windows.Forms.PictureBox();
            this.pbSaveList = new System.Windows.Forms.PictureBox();
            this.pbHelp = new System.Windows.Forms.PictureBox();
            this.lbPlayList = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSaveList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // pbExit
            // 
            this.pbExit.BackColor = System.Drawing.Color.Transparent;
            this.pbExit.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Exit;
            this.pbExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbExit.Location = new System.Drawing.Point(149, 1);
            this.pbExit.Margin = new System.Windows.Forms.Padding(2);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(25, 25);
            this.pbExit.TabIndex = 1;
            this.pbExit.TabStop = false;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // pbLoadList
            // 
            this.pbLoadList.BackColor = System.Drawing.Color.Transparent;
            this.pbLoadList.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.LoadList;
            this.pbLoadList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbLoadList.Location = new System.Drawing.Point(20, 270);
            this.pbLoadList.Margin = new System.Windows.Forms.Padding(2);
            this.pbLoadList.Name = "pbLoadList";
            this.pbLoadList.Size = new System.Drawing.Size(55, 15);
            this.pbLoadList.TabIndex = 2;
            this.pbLoadList.TabStop = false;
            this.pbLoadList.Click += new System.EventHandler(this.pbLoadList_Click);
            // 
            // pbSaveList
            // 
            this.pbSaveList.BackColor = System.Drawing.Color.Transparent;
            this.pbSaveList.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.SaveList;
            this.pbSaveList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbSaveList.Location = new System.Drawing.Point(125, 270);
            this.pbSaveList.Margin = new System.Windows.Forms.Padding(2);
            this.pbSaveList.Name = "pbSaveList";
            this.pbSaveList.Size = new System.Drawing.Size(55, 15);
            this.pbSaveList.TabIndex = 3;
            this.pbSaveList.TabStop = false;
            this.pbSaveList.Click += new System.EventHandler(this.pbSaveList_Click);
            // 
            // pbHelp
            // 
            this.pbHelp.BackColor = System.Drawing.Color.Transparent;
            this.pbHelp.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Help;
            this.pbHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbHelp.Location = new System.Drawing.Point(120, 1);
            this.pbHelp.Margin = new System.Windows.Forms.Padding(2);
            this.pbHelp.Name = "pbHelp";
            this.pbHelp.Size = new System.Drawing.Size(25, 25);
            this.pbHelp.TabIndex = 4;
            this.pbHelp.TabStop = false;
            this.pbHelp.Click += new System.EventHandler(this.pbHelp_Click);
            // 
            // lbPlayList
            // 
            this.lbPlayList.AllowDrop = true;
            this.lbPlayList.BackColor = System.Drawing.Color.LightCyan;
            this.lbPlayList.FormattingEnabled = true;
            this.lbPlayList.HorizontalScrollbar = true;
            this.lbPlayList.ItemHeight = 12;
            this.lbPlayList.Location = new System.Drawing.Point(25, 30);
            this.lbPlayList.Name = "lbPlayList";
            this.lbPlayList.Size = new System.Drawing.Size(150, 232);
            this.lbPlayList.TabIndex = 0;
            // 
            // PlayListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.BgPlayList;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(200, 300);
            this.Controls.Add(this.lbPlayList);
            this.Controls.Add(this.pbHelp);
            this.Controls.Add(this.pbSaveList);
            this.Controls.Add(this.pbLoadList);
            this.Controls.Add(this.pbExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlayListForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Play List";
            this.TransparencyKey = System.Drawing.Color.Azure;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayListForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSaveList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pbExit;
        public System.Windows.Forms.PictureBox pbLoadList;
        public System.Windows.Forms.PictureBox pbSaveList;
        public System.Windows.Forms.PictureBox pbHelp;
        public System.Windows.Forms.ListBox lbPlayList;
    }
}