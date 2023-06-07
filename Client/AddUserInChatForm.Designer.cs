namespace Client
{
    partial class AddUserInChatForm
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
            lblUsers = new Label();
            lbUsers = new ListBox();
            btnAdd = new Button();
            SuspendLayout();
            // 
            // lblUsers
            // 
            lblUsers.AutoSize = true;
            lblUsers.Location = new Point(12, 18);
            lblUsers.Name = "lblUsers";
            lblUsers.Size = new Size(35, 15);
            lblUsers.TabIndex = 5;
            lblUsers.Text = "Users";
            // 
            // lbUsers
            // 
            lbUsers.FormattingEnabled = true;
            lbUsers.ItemHeight = 15;
            lbUsers.Location = new Point(12, 36);
            lbUsers.Name = "lbUsers";
            lbUsers.SelectionMode = SelectionMode.MultiSimple;
            lbUsers.Size = new Size(260, 304);
            lbUsers.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(100, 345);
            btnAdd.Margin = new Padding(2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(84, 31);
            btnAdd.TabIndex = 17;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // AddUserInChatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(285, 389);
            Controls.Add(btnAdd);
            Controls.Add(lblUsers);
            Controls.Add(lbUsers);
            Name = "AddUserInChatForm";
            Text = "AddUserInChatForm";
            Load += AddUserInChatForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsers;
        private ListBox lbUsers;
        private Button btnAdd;
    }
}