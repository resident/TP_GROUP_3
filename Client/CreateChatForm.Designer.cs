namespace Client
{
    partial class CreateChatForm
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
            tbChatTitle = new TextBox();
            lblChatTitle = new Label();
            btnCreateChat = new Button();
            SuspendLayout();
            // 
            // lblUsers
            // 
            lblUsers.AutoSize = true;
            lblUsers.Location = new Point(8, 57);
            lblUsers.Margin = new Padding(2, 0, 2, 0);
            lblUsers.Name = "lblUsers";
            lblUsers.Size = new Size(35, 15);
            lblUsers.TabIndex = 10;
            lblUsers.Text = "Users";
            // 
            // lbUsers
            // 
            lbUsers.FormattingEnabled = true;
            lbUsers.ItemHeight = 15;
            lbUsers.Location = new Point(8, 74);
            lbUsers.Margin = new Padding(2);
            lbUsers.Name = "lbUsers";
            lbUsers.SelectionMode = SelectionMode.MultiSimple;
            lbUsers.Size = new Size(180, 319);
            lbUsers.TabIndex = 9;
            // 
            // tbChatTitle
            // 
            tbChatTitle.Location = new Point(8, 25);
            tbChatTitle.Margin = new Padding(2);
            tbChatTitle.Name = "tbChatTitle";
            tbChatTitle.Size = new Size(180, 23);
            tbChatTitle.TabIndex = 11;
            // 
            // lblChatTitle
            // 
            lblChatTitle.AutoSize = true;
            lblChatTitle.Location = new Point(8, 8);
            lblChatTitle.Margin = new Padding(2, 0, 2, 0);
            lblChatTitle.Name = "lblChatTitle";
            lblChatTitle.Size = new Size(29, 15);
            lblChatTitle.TabIndex = 12;
            lblChatTitle.Text = "Title";
            // 
            // btnCreateChat
            // 
            btnCreateChat.Location = new Point(8, 397);
            btnCreateChat.Margin = new Padding(2);
            btnCreateChat.Name = "btnCreateChat";
            btnCreateChat.Size = new Size(180, 29);
            btnCreateChat.TabIndex = 13;
            btnCreateChat.Text = "Create";
            btnCreateChat.UseVisualStyleBackColor = true;
            btnCreateChat.Click += btnCreateChat_Click;
            // 
            // CreateChatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(195, 435);
            Controls.Add(btnCreateChat);
            Controls.Add(lblChatTitle);
            Controls.Add(tbChatTitle);
            Controls.Add(lblUsers);
            Controls.Add(lbUsers);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            Name = "CreateChatForm";
            StartPosition = FormStartPosition.CenterParent;
            Load += CreateChatForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsers;
        private ListBox lbUsers;
        private TextBox tbChatTitle;
        private Label lblChatTitle;
        private Button btnCreateChat;
    }
}