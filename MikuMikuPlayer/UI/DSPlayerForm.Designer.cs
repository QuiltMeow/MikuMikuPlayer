namespace MikuMikuPlayer
{
    partial class DSPlayerForm
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
            this.panelPlayer = new System.Windows.Forms.Panel();
            this.tbDuration = new Winamp.Components.WinampTrackBar();
            this.sbStatus = new System.Windows.Forms.StatusBar();
            this.sbpPlayerStatus = new System.Windows.Forms.StatusBarPanel();
            this.sbpCurrentTime = new System.Windows.Forms.StatusBarPanel();
            this.sbpDuration = new System.Windows.Forms.StatusBarPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).BeginInit();
            this.panelPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sbpPlayerStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpCurrentTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPlayer
            // 
            this.panelPlayer.BackColor = System.Drawing.Color.Black;
            this.panelPlayer.Controls.Add(this.tbDuration);
            this.panelPlayer.Controls.Add(this.sbStatus);
            this.panelPlayer.Location = new System.Drawing.Point(12, 12);
            this.panelPlayer.Name = "panelPlayer";
            this.panelPlayer.Size = new System.Drawing.Size(621, 346);
            this.panelPlayer.TabIndex = 0;
            // 
            // tbDuration
            // 
            this.tbDuration.BackColor = System.Drawing.Color.LightBlue;
            this.tbDuration.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbDuration.EmptyTrackColor = System.Drawing.Color.Azure;
            this.tbDuration.Location = new System.Drawing.Point(0, 314);
            this.tbDuration.Maximum = 0;
            this.tbDuration.Name = "tbDuration";
            this.tbDuration.ScaleType = Winamp.Components.WinampTrackBar.WinampTrackBarScaleType.None;
            this.tbDuration.Size = new System.Drawing.Size(621, 10);
            this.tbDuration.TabIndex = 1;
            this.tbDuration.UseSeeking = false;
            // 
            // sbStatus
            // 
            this.sbStatus.Location = new System.Drawing.Point(0, 324);
            this.sbStatus.Name = "sbStatus";
            this.sbStatus.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.sbpPlayerStatus,
            this.sbpCurrentTime,
            this.sbpDuration});
            this.sbStatus.ShowPanels = true;
            this.sbStatus.Size = new System.Drawing.Size(621, 22);
            this.sbStatus.TabIndex = 2;
            // 
            // sbpPlayerStatus
            // 
            this.sbpPlayerStatus.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.sbpPlayerStatus.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.sbpPlayerStatus.Name = "sbpPlayerStatus";
            this.sbpPlayerStatus.Text = "準備";
            this.sbpPlayerStatus.Width = 466;
            // 
            // sbpCurrentTime
            // 
            this.sbpCurrentTime.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.sbpCurrentTime.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.sbpCurrentTime.Name = "sbpCurrentTime";
            this.sbpCurrentTime.Text = "00 : 00 : 00";
            this.sbpCurrentTime.Width = 69;
            // 
            // sbpDuration
            // 
            this.sbpDuration.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.sbpDuration.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.sbpDuration.Name = "sbpDuration";
            this.sbpDuration.Text = "00 : 00 : 00";
            this.sbpDuration.Width = 69;
            // 
            // DSPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(645, 370);
            this.Controls.Add(this.panelPlayer);
            this.KeyPreview = true;
            this.Name = "DSPlayerForm";
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.SizeChanged += new System.EventHandler(this.DSPlayerForm_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DSPlayerForm_KeyDown);
            this.Controls.SetChildIndex(this.pbClose, 0);
            this.Controls.SetChildIndex(this.pbMax, 0);
            this.Controls.SetChildIndex(this.pbMin, 0);
            this.Controls.SetChildIndex(this.panelPlayer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).EndInit();
            this.panelPlayer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sbpPlayerStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpCurrentTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpDuration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.StatusBarPanel sbpCurrentTime;
        public System.Windows.Forms.Panel panelPlayer;
        public System.Windows.Forms.StatusBarPanel sbpPlayerStatus;
        public System.Windows.Forms.StatusBarPanel sbpDuration;
        public System.Windows.Forms.StatusBar sbStatus;
        public Winamp.Components.WinampTrackBar tbDuration;
    }
}