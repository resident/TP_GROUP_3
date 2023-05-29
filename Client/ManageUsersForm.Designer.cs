namespace Client
{
    partial class ManageUsersForm
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
            lbUsers = new ListBox();
            lblUsers = new Label();
            btnApprove = new Button();
            btnRemove = new Button();
            btnBan = new Button();
            SuspendLayout();
            // 
            // lbUsers
            // 
            lbUsers.FormattingEnabled = true;
            lbUsers.ItemHeight = 15;
            lbUsers.Location = new Point(12, 35);
            lbUsers.Name = "lbUsers";
            lbUsers.Size = new Size(260, 304);
            lbUsers.TabIndex = 0;
            // 
            // lblUsers
            // 
            lblUsers.AutoSize = true;
            lblUsers.Location = new Point(12, 17);
            lblUsers.Name = "lblUsers";
            lblUsers.Size = new Size(35, 15);
            lblUsers.TabIndex = 1;
            lblUsers.Text = "Users";
            // 
            // btnApprove
            // 
            btnApprove.Location = new Point(12, 344);
            btnApprove.Margin = new Padding(2);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(84, 31);
            btnApprove.TabIndex = 15;
            btnApprove.Text = "Approve";
            btnApprove.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(100, 344);
            btnRemove.Margin = new Padding(2);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(84, 31);
            btnRemove.TabIndex = 16;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnBan
            // 
            btnBan.Location = new Point(188, 344);
            btnBan.Margin = new Padding(2);
            btnBan.Name = "btnBan";
            btnBan.Size = new Size(84, 31);
            btnBan.TabIndex = 17;
            btnBan.Text = "Ban";
            btnBan.UseVisualStyleBackColor = true;
            // 
            // ManageUsersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(285, 389);
            Controls.Add(btnBan);
            Controls.Add(btnRemove);
            Controls.Add(btnApprove);
            Controls.Add(lblUsers);
            Controls.Add(lbUsers);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ManageUsersForm";
            Text = "Manage Users";
            Load += ManageUsersForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbUsers;
        private Label lblUsers;
        private Button btnApprove;
        private Button btnRemove;
        private Button btnBan;
    }
}