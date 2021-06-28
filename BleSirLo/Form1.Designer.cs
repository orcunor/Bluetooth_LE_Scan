namespace BleSirLo
{
    partial class Bluetooth_LE
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
            this.ScanBtn = new System.Windows.Forms.Button();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.WriteBtn = new System.Windows.Forms.Button();
            this.ReadBtn = new System.Windows.Forms.Button();
            this.DevicesComboBox = new System.Windows.Forms.ComboBox();
            this.Response = new System.Windows.Forms.RichTextBox();
            this.InputTxtBox = new System.Windows.Forms.TextBox();
            this.ServiceTxtBox = new System.Windows.Forms.TextBox();
            this.lblDevices = new System.Windows.Forms.Label();
            this.lblServiceUUID = new System.Windows.Forms.Label();
            this.lblCharacteristicUUID = new System.Windows.Forms.Label();
            this.CharacteristicsTxtBox = new System.Windows.Forms.TextBox();
            this.labelConnectedStatus = new System.Windows.Forms.Label();
            this.DisConnectBtn = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.NotifyBtn = new System.Windows.Forms.Button();
            this.IndicateBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ScanBtn
            // 
            this.ScanBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ScanBtn.Location = new System.Drawing.Point(0, 0);
            this.ScanBtn.Name = "ScanBtn";
            this.ScanBtn.Size = new System.Drawing.Size(324, 23);
            this.ScanBtn.TabIndex = 0;
            this.ScanBtn.Text = "Scan";
            this.ScanBtn.UseVisualStyleBackColor = true;
            this.ScanBtn.Click += new System.EventHandler(this.ScanBtn_Click);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(254, 29);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(70, 22);
            this.ConnectBtn.TabIndex = 1;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // WriteBtn
            // 
            this.WriteBtn.Location = new System.Drawing.Point(255, 352);
            this.WriteBtn.Name = "WriteBtn";
            this.WriteBtn.Size = new System.Drawing.Size(62, 23);
            this.WriteBtn.TabIndex = 2;
            this.WriteBtn.Text = "Write";
            this.WriteBtn.UseVisualStyleBackColor = true;
            this.WriteBtn.Click += new System.EventHandler(this.WriteBtn_Click);
            // 
            // ReadBtn
            // 
            this.ReadBtn.Location = new System.Drawing.Point(255, 325);
            this.ReadBtn.Name = "ReadBtn";
            this.ReadBtn.Size = new System.Drawing.Size(62, 23);
            this.ReadBtn.TabIndex = 3;
            this.ReadBtn.Text = "Read";
            this.ReadBtn.UseVisualStyleBackColor = true;
            this.ReadBtn.Click += new System.EventHandler(this.ReadBtn_Click);
            // 
            // DevicesComboBox
            // 
            this.DevicesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DevicesComboBox.FormattingEnabled = true;
            this.DevicesComboBox.Location = new System.Drawing.Point(114, 29);
            this.DevicesComboBox.Name = "DevicesComboBox";
            this.DevicesComboBox.Size = new System.Drawing.Size(134, 21);
            this.DevicesComboBox.TabIndex = 4;
            this.DevicesComboBox.SelectedIndexChanged += new System.EventHandler(this.DevicesComboBox_SelectedIndexChanged);
            // 
            // Response
            // 
            this.Response.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.Response.Location = new System.Drawing.Point(13, 112);
            this.Response.Name = "Response";
            this.Response.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Response.Size = new System.Drawing.Size(304, 182);
            this.Response.TabIndex = 5;
            this.Response.Text = "";
            // 
            // InputTxtBox
            // 
            this.InputTxtBox.Location = new System.Drawing.Point(72, 327);
            this.InputTxtBox.Multiline = true;
            this.InputTxtBox.Name = "InputTxtBox";
            this.InputTxtBox.Size = new System.Drawing.Size(177, 48);
            this.InputTxtBox.TabIndex = 6;
            // 
            // ServiceTxtBox
            // 
            this.ServiceTxtBox.Location = new System.Drawing.Point(113, 55);
            this.ServiceTxtBox.Name = "ServiceTxtBox";
            this.ServiceTxtBox.Size = new System.Drawing.Size(135, 20);
            this.ServiceTxtBox.TabIndex = 7;
            // 
            // lblDevices
            // 
            this.lblDevices.AutoSize = true;
            this.lblDevices.Location = new System.Drawing.Point(65, 33);
            this.lblDevices.Name = "lblDevices";
            this.lblDevices.Size = new System.Drawing.Size(46, 13);
            this.lblDevices.TabIndex = 8;
            this.lblDevices.Text = "Devices";
            // 
            // lblServiceUUID
            // 
            this.lblServiceUUID.AutoSize = true;
            this.lblServiceUUID.Location = new System.Drawing.Point(37, 59);
            this.lblServiceUUID.Name = "lblServiceUUID";
            this.lblServiceUUID.Size = new System.Drawing.Size(73, 13);
            this.lblServiceUUID.TabIndex = 9;
            this.lblServiceUUID.Text = "Service UUID";
            // 
            // lblCharacteristicUUID
            // 
            this.lblCharacteristicUUID.AutoSize = true;
            this.lblCharacteristicUUID.Location = new System.Drawing.Point(4, 83);
            this.lblCharacteristicUUID.Name = "lblCharacteristicUUID";
            this.lblCharacteristicUUID.Size = new System.Drawing.Size(106, 13);
            this.lblCharacteristicUUID.TabIndex = 11;
            this.lblCharacteristicUUID.Text = "Characteristics UUID";
            // 
            // CharacteristicsTxtBox
            // 
            this.CharacteristicsTxtBox.Location = new System.Drawing.Point(113, 80);
            this.CharacteristicsTxtBox.Name = "CharacteristicsTxtBox";
            this.CharacteristicsTxtBox.Size = new System.Drawing.Size(135, 20);
            this.CharacteristicsTxtBox.TabIndex = 10;
            // 
            // labelConnectedStatus
            // 
            this.labelConnectedStatus.AutoSize = true;
            this.labelConnectedStatus.Location = new System.Drawing.Point(13, 297);
            this.labelConnectedStatus.Name = "labelConnectedStatus";
            this.labelConnectedStatus.Size = new System.Drawing.Size(0, 13);
            this.labelConnectedStatus.TabIndex = 14;
            // 
            // DisConnectBtn
            // 
            this.DisConnectBtn.Location = new System.Drawing.Point(255, 53);
            this.DisConnectBtn.Name = "DisConnectBtn";
            this.DisConnectBtn.Size = new System.Drawing.Size(70, 22);
            this.DisConnectBtn.TabIndex = 15;
            this.DisConnectBtn.Text = "Disconnect";
            this.DisConnectBtn.UseVisualStyleBackColor = true;
            this.DisConnectBtn.Click += new System.EventHandler(this.DisConnectBtn_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(254, 80);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(70, 22);
            this.btnRefresh.TabIndex = 16;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // NotifyBtn
            // 
            this.NotifyBtn.Location = new System.Drawing.Point(4, 327);
            this.NotifyBtn.Name = "NotifyBtn";
            this.NotifyBtn.Size = new System.Drawing.Size(62, 23);
            this.NotifyBtn.TabIndex = 17;
            this.NotifyBtn.Text = "Notify";
            this.NotifyBtn.UseVisualStyleBackColor = true;
            this.NotifyBtn.Click += new System.EventHandler(this.NotifyBtn_Click);
            // 
            // IndicateBtn
            // 
            this.IndicateBtn.Location = new System.Drawing.Point(4, 352);
            this.IndicateBtn.Name = "IndicateBtn";
            this.IndicateBtn.Size = new System.Drawing.Size(62, 23);
            this.IndicateBtn.TabIndex = 18;
            this.IndicateBtn.Text = "Indicate";
            this.IndicateBtn.UseVisualStyleBackColor = true;
            this.IndicateBtn.Click += new System.EventHandler(this.IndicateBtn_Click);
            // 
            // Bluetooth_LE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 385);
            this.Controls.Add(this.IndicateBtn);
            this.Controls.Add(this.NotifyBtn);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.DisConnectBtn);
            this.Controls.Add(this.labelConnectedStatus);
            this.Controls.Add(this.CharacteristicsTxtBox);
            this.Controls.Add(this.lblServiceUUID);
            this.Controls.Add(this.lblDevices);
            this.Controls.Add(this.ServiceTxtBox);
            this.Controls.Add(this.InputTxtBox);
            this.Controls.Add(this.Response);
            this.Controls.Add(this.DevicesComboBox);
            this.Controls.Add(this.ReadBtn);
            this.Controls.Add(this.WriteBtn);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.ScanBtn);
            this.Controls.Add(this.lblCharacteristicUUID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Bluetooth_LE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bluetooth LE Scan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ScanBtn;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.Button WriteBtn;
        private System.Windows.Forms.Button ReadBtn;
        private System.Windows.Forms.ComboBox DevicesComboBox;
        private System.Windows.Forms.RichTextBox Response;
        private System.Windows.Forms.TextBox InputTxtBox;
        private System.Windows.Forms.TextBox ServiceTxtBox;
        private System.Windows.Forms.Label lblDevices;
        private System.Windows.Forms.Label lblServiceUUID;
        private System.Windows.Forms.Label lblCharacteristicUUID;
        private System.Windows.Forms.TextBox CharacteristicsTxtBox;
        private System.Windows.Forms.Label labelConnectedStatus;
        private System.Windows.Forms.Button DisConnectBtn;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button NotifyBtn;
        private System.Windows.Forms.Button IndicateBtn;
    }
}

