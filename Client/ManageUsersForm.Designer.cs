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
            lbUsers.ItemHeight = 32;
            lbUsers.Location = new Point(22, 75);
            lbUsers.Margin = new Padding(6, 6, 6, 6);
            lbUsers.Name = "lbUsers";
            lbUsers.SelectionMode = SelectionMode.MultiSimple;
            lbUsers.Size = new Size(479, 644);
            lbUsers.TabIndex = 0;
            // 
            // lblUsers
            // 
            lblUsers.AutoSize = true;
            lblUsers.Location = new Point(22, 36);
            lblUsers.Margin = new Padding(6, 0, 6, 0);
            lblUsers.Name = "lblUsers";
            lblUsers.Size = new Size(71, 32);
            lblUsers.TabIndex = 1;
            lblUsers.Text = "Users";
            // 
            // btnApprove
            // 
            btnApprove.Location = new Point(22, 734);
            btnApprove.Margin = new Padding(4, 4, 4, 4);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(156, 66);
            btnApprove.TabIndex = 15;
            btnApprove.Text = "Approve";
            btnApprove.UseVisualStyleBackColor = true;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(186, 734);
            btnRemove.Margin = new Padding(4, 4, 4, 4);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(156, 66);
            btnRemove.TabIndex = 16;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnBan
            // 
            btnBan.Location = new Point(349, 734);
            btnBan.Margin = new Padding(4, 4, 4, 4);
            btnBan.Name = "btnBan";
            btnBan.Size = new Size(156, 66);
            btnBan.TabIndex = 17;
            btnBan.Text = "Ban";
            btnBan.UseVisualStyleBackColor = true;
            // 
            // ManageUsersForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(529, 830);
            Controls.Add(btnBan);
            Controls.Add(btnRemove);
            Controls.Add(btnApprove);
            Controls.Add(lblUsers);
            Controls.Add(lbUsers);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(6, 6, 6, 6);
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