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
            btnSave.Location = new Point(8, 110);
            btnSave.Margin = new Padding(2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(78, 33);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(228, 153);
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
    }
}