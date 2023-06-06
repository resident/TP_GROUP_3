namespace Client
{
    partial class LoginForm
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
            lblPassword = new Label();
            lblLogin = new Label();
            btnLogin = new Button();
            tbPassword = new TextBox();
            tbLogin = new TextBox();
            SuspendLayout();
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(190, 16);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 13;
            lblPassword.Text = "Password";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(8, 16);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(37, 15);
            lblLogin.TabIndex = 12;
            lblLogin.Text = "Login";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(364, 33);
            btnLogin.Margin = new Padding(2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(78, 33);
            btnLogin.TabIndex = 11;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // tbPassword
            // 
            tbPassword.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbPassword.Location = new Point(190, 34);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(169, 32);
            tbPassword.TabIndex = 10;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // tbLogin
            // 
            tbLogin.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbLogin.Location = new Point(8, 34);
            tbLogin.MaxLength = 15;
            tbLogin.Name = "tbLogin";
            tbLogin.Size = new Size(176, 32);
            tbLogin.TabIndex = 9;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(455, 86);
            Controls.Add(lblPassword);
            Controls.Add(lblLogin);
            Controls.Add(btnLogin);
            Controls.Add(tbPassword);
            Controls.Add(tbLogin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPassword;
        private Label lblLogin;
        private Button btnLogin;
        private TextBox tbPassword;
        private TextBox tbLogin;
    }
}