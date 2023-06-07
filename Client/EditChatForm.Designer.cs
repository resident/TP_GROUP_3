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
            btnAdd = new Button();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // lblUsers
            // 
            lblUsers.AutoSize = true;
            lblUsers.Location = new Point(12, 14);
            lblUsers.Name = "lblUsers";
            lblUsers.Size = new Size(35, 15);
            lblUsers.TabIndex = 3;
            lblUsers.Text = "Users";
            // 
            // lbUsers
            // 
            lbUsers.FormattingEnabled = true;
            lbUsers.ItemHeight = 15;
            lbUsers.Location = new Point(12, 32);
            lbUsers.Name = "lbUsers";
            lbUsers.SelectionMode = SelectionMode.MultiSimple;
            lbUsers.Size = new Size(260, 304);
            lbUsers.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 341);
            btnAdd.Margin = new Padding(2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(84, 31);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(190, 341);
            btnDelete.Margin = new Padding(2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(84, 31);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // EditChatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(285, 389);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
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
        private Button btnAdd;
        private Button btnDelete;
    }
}