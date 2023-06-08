namespace Client
{
    partial class SettingsForm
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
            tbServerIpAddress = new TextBox();
            lblIpAddress = new Label();
            lblServerPort = new Label();
            tbServerPort = new TextBox();
            btnSave = new Button();
            lblNtpPort = new Label();
            tbNtpPort = new TextBox();
            lblNtpHost = new Label();
            tbNtpHost = new TextBox();
            SuspendLayout();
            // 
            // tbServerIpAddress
            // 
            tbServerIpAddress.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbServerIpAddress.Location = new Point(8, 24);
            tbServerIpAddress.Margin = new Padding(2);
            tbServerIpAddress.Name = "tbServerIpAddress";
            tbServerIpAddress.Size = new Size(199, 32);
            tbServerIpAddress.TabIndex = 5;
            // 
            // lblIpAddress
            // 
            lblIpAddress.AutoSize = true;
            lblIpAddress.Location = new Point(8, 7);
            lblIpAddress.Margin = new Padding(2, 0, 2, 0);
            lblIpAddress.Name = "lblIpAddress";
            lblIpAddress.Size = new Size(97, 15);
            lblIpAddress.TabIndex = 6;
            lblIpAddress.Text = "Server IP Address";
            // 
            // lblServerPort
            // 
            lblServerPort.AutoSize = true;
            lblServerPort.Location = new Point(8, 58);
            lblServerPort.Margin = new Padding(2, 0, 2, 0);
            lblServerPort.Name = "lblServerPort";
            lblServerPort.Size = new Size(64, 15);
            lblServerPort.TabIndex = 8;
            lblServerPort.Text = "Server Port";
            // 
            // tbServerPort
            // 
            tbServerPort.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbServerPort.Location = new Point(8, 74);
            tbServerPort.Margin = new Padding(2);
            tbServerPort.Name = "tbServerPort";
            tbServerPort.Size = new Size(199, 32);
            tbServerPort.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(8, 232);
            btnSave.Margin = new Padding(2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(78, 33);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblNtpPort
            // 
            lblNtpPort.AutoSize = true;
            lblNtpPort.Location = new Point(8, 167);
            lblNtpPort.Margin = new Padding(2, 0, 2, 0);
            lblNtpPort.Name = "lblNtpPort";
            lblNtpPort.Size = new Size(54, 15);
            lblNtpPort.TabIndex = 13;
            lblNtpPort.Text = "NTP Port";
            // 
            // tbNtpPort
            // 
            tbNtpPort.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbNtpPort.Location = new Point(8, 183);
            tbNtpPort.Margin = new Padding(2);
            tbNtpPort.Name = "tbNtpPort";
            tbNtpPort.Size = new Size(199, 32);
            tbNtpPort.TabIndex = 12;
            // 
            // lblNtpHost
            // 
            lblNtpHost.AutoSize = true;
            lblNtpHost.Location = new Point(8, 116);
            lblNtpHost.Margin = new Padding(2, 0, 2, 0);
            lblNtpHost.Name = "lblNtpHost";
            lblNtpHost.Size = new Size(57, 15);
            lblNtpHost.TabIndex = 11;
            lblNtpHost.Text = "NTP Host";
            // 
            // tbNtpHost
            // 
            tbNtpHost.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbNtpHost.Location = new Point(8, 133);
            tbNtpHost.Margin = new Padding(2);
            tbNtpHost.Name = "tbNtpHost";
            tbNtpHost.Size = new Size(199, 32);
            tbNtpHost.TabIndex = 10;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(228, 276);
            Controls.Add(lblNtpPort);
            Controls.Add(tbNtpPort);
            Controls.Add(lblNtpHost);
            Controls.Add(tbNtpHost);
            Controls.Add(btnSave);
            Controls.Add(lblServerPort);
            Controls.Add(tbServerPort);
            Controls.Add(lblIpAddress);
            Controls.Add(tbServerIpAddress);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            Load += SettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbServerIpAddress;
        private Label lblIpAddress;
        private Label lblServerPort;
        private TextBox tbServerPort;
        private Button btnSave;
        private Label lblNtpPort;
        private TextBox tbNtpPort;
        private Label lblNtpHost;
        private TextBox tbNtpHost;
    }
}