namespace MikuMikuPlayer
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.cbFont = new System.Windows.Forms.ComboBox();
            this.labelSetting = new System.Windows.Forms.Label();
            this.labelFont = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.labelCurrentFont = new System.Windows.Forms.Label();
            this.labelPreview = new System.Windows.Forms.Label();
            this.btnResetSetting = new System.Windows.Forms.Button();
            this.chkLockUI = new System.Windows.Forms.CheckBox();
            this.labelLockStatus = new System.Windows.Forms.Label();
            this.btnResetUI = new System.Windows.Forms.Button();
            this.pbMikuIcon = new System.Windows.Forms.PictureBox();
            this.labelSkin = new System.Windows.Forms.Label();
            this.cbSkin = new System.Windows.Forms.ComboBox();
            this.labelCurrentSkin = new System.Windows.Forms.Label();
            this.btnSkinLocation = new System.Windows.Forms.Button();
            this.btnSaveSkin = new System.Windows.Forms.Button();
            this.btnUpdateList = new System.Windows.Forms.Button();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.btnUndo = new System.Windows.Forms.Button();
            this.llCodec = new System.Windows.Forms.LinkLabel();
            this.labelPlayerType = new System.Windows.Forms.Label();
            this.cbPlayerType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMikuIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            this.SuspendLayout();
            // 
            // cbFont
            // 
            this.cbFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFont.FormattingEnabled = true;
            this.cbFont.Location = new System.Drawing.Point(135, 87);
            this.cbFont.Margin = new System.Windows.Forms.Padding(2);
            this.cbFont.Name = "cbFont";
            this.cbFont.Size = new System.Drawing.Size(150, 20);
            this.cbFont.TabIndex = 4;
            this.cbFont.SelectedIndexChanged += new System.EventHandler(this.cbFont_SelectedIndexChanged);
            // 
            // labelSetting
            // 
            this.labelSetting.AutoSize = true;
            this.labelSetting.BackColor = System.Drawing.Color.Transparent;
            this.labelSetting.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelSetting.Location = new System.Drawing.Point(25, 25);
            this.labelSetting.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSetting.Name = "labelSetting";
            this.labelSetting.Size = new System.Drawing.Size(40, 16);
            this.labelSetting.TabIndex = 0;
            this.labelSetting.Text = "設定";
            // 
            // labelFont
            // 
            this.labelFont.AutoSize = true;
            this.labelFont.BackColor = System.Drawing.Color.Transparent;
            this.labelFont.Location = new System.Drawing.Point(26, 90);
            this.labelFont.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFont.Name = "labelFont";
            this.labelFont.Size = new System.Drawing.Size(29, 12);
            this.labelFont.TabIndex = 3;
            this.labelFont.Text = "字型";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(145, 355);
            this.btnApply.Margin = new System.Windows.Forms.Padding(2);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(90, 21);
            this.btnApply.TabIndex = 17;
            this.btnApply.Text = "套用並儲存";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // labelCurrentFont
            // 
            this.labelCurrentFont.AutoSize = true;
            this.labelCurrentFont.BackColor = System.Drawing.Color.Transparent;
            this.labelCurrentFont.Location = new System.Drawing.Point(45, 115);
            this.labelCurrentFont.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCurrentFont.Name = "labelCurrentFont";
            this.labelCurrentFont.Size = new System.Drawing.Size(35, 12);
            this.labelCurrentFont.TabIndex = 5;
            this.labelCurrentFont.Text = "NULL";
            // 
            // labelPreview
            // 
            this.labelPreview.AutoSize = true;
            this.labelPreview.BackColor = System.Drawing.Color.Transparent;
            this.labelPreview.Location = new System.Drawing.Point(45, 140);
            this.labelPreview.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPreview.Name = "labelPreview";
            this.labelPreview.Size = new System.Drawing.Size(140, 12);
            this.labelPreview.TabIndex = 6;
            this.labelPreview.Text = "預覽 ABCDEF 0123456789";
            // 
            // btnResetSetting
            // 
            this.btnResetSetting.Location = new System.Drawing.Point(239, 355);
            this.btnResetSetting.Margin = new System.Windows.Forms.Padding(2);
            this.btnResetSetting.Name = "btnResetSetting";
            this.btnResetSetting.Size = new System.Drawing.Size(72, 21);
            this.btnResetSetting.TabIndex = 18;
            this.btnResetSetting.Text = "全部重置";
            this.btnResetSetting.UseVisualStyleBackColor = true;
            this.btnResetSetting.Click += new System.EventHandler(this.btnResetSetting_Click);
            // 
            // chkLockUI
            // 
            this.chkLockUI.AutoSize = true;
            this.chkLockUI.BackColor = System.Drawing.Color.Transparent;
            this.chkLockUI.Checked = true;
            this.chkLockUI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLockUI.Location = new System.Drawing.Point(28, 175);
            this.chkLockUI.Margin = new System.Windows.Forms.Padding(2);
            this.chkLockUI.Name = "chkLockUI";
            this.chkLockUI.Size = new System.Drawing.Size(72, 16);
            this.chkLockUI.TabIndex = 7;
            this.chkLockUI.Text = "鎖定介面";
            this.chkLockUI.UseVisualStyleBackColor = false;
            this.chkLockUI.CheckedChanged += new System.EventHandler(this.chkLockUI_CheckedChanged);
            // 
            // labelLockStatus
            // 
            this.labelLockStatus.AutoSize = true;
            this.labelLockStatus.BackColor = System.Drawing.Color.Transparent;
            this.labelLockStatus.Location = new System.Drawing.Point(120, 176);
            this.labelLockStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLockStatus.Name = "labelLockStatus";
            this.labelLockStatus.Size = new System.Drawing.Size(41, 12);
            this.labelLockStatus.TabIndex = 8;
            this.labelLockStatus.Text = "已鎖定";
            // 
            // btnResetUI
            // 
            this.btnResetUI.Location = new System.Drawing.Point(185, 172);
            this.btnResetUI.Margin = new System.Windows.Forms.Padding(2);
            this.btnResetUI.Name = "btnResetUI";
            this.btnResetUI.Size = new System.Drawing.Size(72, 21);
            this.btnResetUI.TabIndex = 9;
            this.btnResetUI.Text = "預設位置";
            this.btnResetUI.UseVisualStyleBackColor = true;
            this.btnResetUI.Click += new System.EventHandler(this.btnResetUI_Click);
            // 
            // pbMikuIcon
            // 
            this.pbMikuIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbMikuIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbMikuIcon.BackgroundImage")));
            this.pbMikuIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMikuIcon.Location = new System.Drawing.Point(305, 270);
            this.pbMikuIcon.Margin = new System.Windows.Forms.Padding(2);
            this.pbMikuIcon.Name = "pbMikuIcon";
            this.pbMikuIcon.Size = new System.Drawing.Size(66, 70);
            this.pbMikuIcon.TabIndex = 13;
            this.pbMikuIcon.TabStop = false;
            // 
            // labelSkin
            // 
            this.labelSkin.AutoSize = true;
            this.labelSkin.BackColor = System.Drawing.Color.Transparent;
            this.labelSkin.Location = new System.Drawing.Point(26, 220);
            this.labelSkin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSkin.Name = "labelSkin";
            this.labelSkin.Size = new System.Drawing.Size(29, 12);
            this.labelSkin.TabIndex = 10;
            this.labelSkin.Text = "外觀";
            // 
            // cbSkin
            // 
            this.cbSkin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSkin.FormattingEnabled = true;
            this.cbSkin.Location = new System.Drawing.Point(135, 217);
            this.cbSkin.Margin = new System.Windows.Forms.Padding(2);
            this.cbSkin.Name = "cbSkin";
            this.cbSkin.Size = new System.Drawing.Size(150, 20);
            this.cbSkin.TabIndex = 11;
            // 
            // labelCurrentSkin
            // 
            this.labelCurrentSkin.AutoSize = true;
            this.labelCurrentSkin.BackColor = System.Drawing.Color.Transparent;
            this.labelCurrentSkin.Location = new System.Drawing.Point(45, 245);
            this.labelCurrentSkin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCurrentSkin.Name = "labelCurrentSkin";
            this.labelCurrentSkin.Size = new System.Drawing.Size(35, 12);
            this.labelCurrentSkin.TabIndex = 13;
            this.labelCurrentSkin.Text = "NULL";
            // 
            // btnSkinLocation
            // 
            this.btnSkinLocation.Location = new System.Drawing.Point(28, 270);
            this.btnSkinLocation.Margin = new System.Windows.Forms.Padding(2);
            this.btnSkinLocation.Name = "btnSkinLocation";
            this.btnSkinLocation.Size = new System.Drawing.Size(170, 21);
            this.btnSkinLocation.TabIndex = 14;
            this.btnSkinLocation.Text = "開啟檔案位置";
            this.btnSkinLocation.UseVisualStyleBackColor = true;
            this.btnSkinLocation.Click += new System.EventHandler(this.btnSkinLocation_Click);
            // 
            // btnSaveSkin
            // 
            this.btnSaveSkin.Location = new System.Drawing.Point(28, 295);
            this.btnSaveSkin.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveSkin.Name = "btnSaveSkin";
            this.btnSaveSkin.Size = new System.Drawing.Size(170, 21);
            this.btnSaveSkin.TabIndex = 15;
            this.btnSaveSkin.Text = "儲存目前 UI 設定到外觀包";
            this.btnSaveSkin.UseVisualStyleBackColor = true;
            this.btnSaveSkin.Click += new System.EventHandler(this.btnSaveSkin_Click);
            // 
            // btnUpdateList
            // 
            this.btnUpdateList.Location = new System.Drawing.Point(300, 216);
            this.btnUpdateList.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateList.Name = "btnUpdateList";
            this.btnUpdateList.Size = new System.Drawing.Size(72, 21);
            this.btnUpdateList.TabIndex = 12;
            this.btnUpdateList.Text = "更新列表";
            this.btnUpdateList.UseVisualStyleBackColor = true;
            this.btnUpdateList.Click += new System.EventHandler(this.btnUpdateList_Click);
            // 
            // pbExit
            // 
            this.pbExit.BackColor = System.Drawing.Color.Transparent;
            this.pbExit.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.Exit;
            this.pbExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbExit.Location = new System.Drawing.Point(370, 10);
            this.pbExit.Margin = new System.Windows.Forms.Padding(2);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(25, 25);
            this.pbExit.TabIndex = 18;
            this.pbExit.TabStop = false;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(315, 355);
            this.btnUndo.Margin = new System.Windows.Forms.Padding(2);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(72, 21);
            this.btnUndo.TabIndex = 19;
            this.btnUndo.Text = "取消設定";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // llCodec
            // 
            this.llCodec.AutoSize = true;
            this.llCodec.BackColor = System.Drawing.Color.Transparent;
            this.llCodec.Location = new System.Drawing.Point(26, 359);
            this.llCodec.Name = "llCodec";
            this.llCodec.Size = new System.Drawing.Size(89, 12);
            this.llCodec.TabIndex = 16;
            this.llCodec.TabStop = true;
            this.llCodec.Text = "下載萬用解碼器";
            this.llCodec.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCodec_LinkClicked);
            // 
            // labelPlayerType
            // 
            this.labelPlayerType.AutoSize = true;
            this.labelPlayerType.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayerType.Location = new System.Drawing.Point(26, 60);
            this.labelPlayerType.Name = "labelPlayerType";
            this.labelPlayerType.Size = new System.Drawing.Size(89, 12);
            this.labelPlayerType.TabIndex = 1;
            this.labelPlayerType.Text = "播放器渲染方式";
            // 
            // cbPlayerType
            // 
            this.cbPlayerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlayerType.FormattingEnabled = true;
            this.cbPlayerType.Items.AddRange(new object[] {
            "WMP (Windows Media Player)",
            "DSP (Direct Show Player)"});
            this.cbPlayerType.Location = new System.Drawing.Point(135, 57);
            this.cbPlayerType.Margin = new System.Windows.Forms.Padding(2);
            this.cbPlayerType.Name = "cbPlayerType";
            this.cbPlayerType.Size = new System.Drawing.Size(200, 20);
            this.cbPlayerType.TabIndex = 2;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MikuMikuPlayer.Properties.Resources.BgPlayer;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(400, 390);
            this.Controls.Add(this.cbPlayerType);
            this.Controls.Add(this.labelPlayerType);
            this.Controls.Add(this.llCodec);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.pbExit);
            this.Controls.Add(this.btnUpdateList);
            this.Controls.Add(this.btnSaveSkin);
            this.Controls.Add(this.btnSkinLocation);
            this.Controls.Add(this.labelCurrentSkin);
            this.Controls.Add(this.cbSkin);
            this.Controls.Add(this.labelSkin);
            this.Controls.Add(this.pbMikuIcon);
            this.Controls.Add(this.btnResetUI);
            this.Controls.Add(this.labelLockStatus);
            this.Controls.Add(this.chkLockUI);
            this.Controls.Add(this.btnResetSetting);
            this.Controls.Add(this.labelPreview);
            this.Controls.Add(this.labelCurrentFont);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.labelFont);
            this.Controls.Add(this.labelSetting);
            this.Controls.Add(this.cbFont);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Setting";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SettingForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbMikuIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMikuIcon;
        public System.Windows.Forms.ComboBox cbSkin;
        public System.Windows.Forms.Label labelCurrentSkin;
        public System.Windows.Forms.ComboBox cbFont;
        public System.Windows.Forms.Label labelSetting;
        public System.Windows.Forms.Label labelFont;
        public System.Windows.Forms.Button btnApply;
        public System.Windows.Forms.Label labelPreview;
        public System.Windows.Forms.Button btnResetSetting;
        public System.Windows.Forms.CheckBox chkLockUI;
        public System.Windows.Forms.Label labelLockStatus;
        public System.Windows.Forms.Button btnResetUI;
        public System.Windows.Forms.Label labelSkin;
        public System.Windows.Forms.Button btnSkinLocation;
        public System.Windows.Forms.Button btnSaveSkin;
        public System.Windows.Forms.Label labelCurrentFont;
        public System.Windows.Forms.Button btnUpdateList;
        public System.Windows.Forms.PictureBox pbExit;
        public System.Windows.Forms.Button btnUndo;
        public System.Windows.Forms.LinkLabel llCodec;
        public System.Windows.Forms.ComboBox cbPlayerType;
        public System.Windows.Forms.Label labelPlayerType;
    }
}