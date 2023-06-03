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
            tbServerIpAddress.Location = new Point(12, 40);
            tbServerIpAddress.Name = "tbServerIpAddress";
            tbServerIpAddress.Size = new Size(283, 45);
            tbServerIpAddress.TabIndex = 5;
            // 
            // lblIpAddress
            // 
            lblIpAddress.AutoSize = true;
            lblIpAddress.Location = new Point(12, 12);
            lblIpAddress.Name = "lblIpAddress";
            lblIpAddress.Size = new Size(151, 25);
            lblIpAddress.TabIndex = 6;
            lblIpAddress.Text = "Server IP Address";
            // 
            // lblServerPort
            // 
            lblServerPort.AutoSize = true;
            lblServerPort.Location = new Point(12, 96);
            lblServerPort.Name = "lblServerPort";
            lblServerPort.Size = new Size(98, 25);
            lblServerPort.TabIndex = 8;
            lblServerPort.Text = "Server Port";
            // 
            // tbServerPort
            // 
            tbServerPort.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbServerPort.Location = new Point(12, 124);
            tbServerPort.Name = "tbServerPort";
            tbServerPort.Size = new Size(283, 45);
            tbServerPort.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 175);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(111, 55);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(326, 255);
            Controls.Add(btnSave);
            Controls.Add(lblServerPort);
            Controls.Add(tbServerPort);
            Controls.Add(lblIpAddress);
            Controls.Add(tbServerIpAddress);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "SettingsForm";
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