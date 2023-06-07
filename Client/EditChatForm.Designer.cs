namespace Client
{
    partial class EditChatForm
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
            btnSave = new Button();
            lblChatTitle = new Label();
            tbChatTitle = new TextBox();
            SuspendLayout();
            // 
            // lblUsers
            // 
            lblUsers.AutoSize = true;
            lblUsers.Location = new Point(12, 38);
            lblUsers.Name = "lblUsers";
            lblUsers.Size = new Size(35, 15);
            lblUsers.TabIndex = 3;
            lblUsers.Text = "Users";
            // 
            // lbUsers
            // 
            lbUsers.FormattingEnabled = true;
            lbUsers.ItemHeight = 15;
            lbUsers.Location = new Point(12, 56);
            lbUsers.Name = "lbUsers";
            lbUsers.SelectionMode = SelectionMode.MultiSimple;
            lbUsers.Size = new Size(260, 304);
            lbUsers.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(100, 365);
            btnSave.Margin = new Padding(2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(84, 31);
            btnSave.TabIndex = 18;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblChatTitle
            // 
            lblChatTitle.AutoSize = true;
            lblChatTitle.Location = new Point(61, 11);
            lblChatTitle.Margin = new Padding(2, 0, 2, 0);
            lblChatTitle.Name = "lblChatTitle";
            lblChatTitle.Size = new Size(29, 15);
            lblChatTitle.TabIndex = 20;
            lblChatTitle.Text = "Title";
            // 
            // tbChatTitle
            // 
            tbChatTitle.Location = new Point(61, 28);
            tbChatTitle.Margin = new Padding(2);
            tbChatTitle.MaxLength = 15;
            tbChatTitle.Name = "tbChatTitle";
            tbChatTitle.Size = new Size(180, 23);
            tbChatTitle.TabIndex = 19;
            // 
            // EditChatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(285, 405);
            Controls.Add(lblChatTitle);
            Controls.Add(tbChatTitle);
            Controls.Add(btnSave);
            Controls.Add(lblUsers);
            Controls.Add(lbUsers);
            Name = "EditChatForm";
            Text = "EditChatForm";
            Load += EditChatForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsers;
        private ListBox lbUsers;
        private Button btnSave;
        private Label lblChatTitle;
        private TextBox tbChatTitle;
    }
}