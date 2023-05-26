namespace Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lb_messages = new ListBox();
            btn_add_file = new Button();
            btn_send = new Button();
            tb_message = new TextBox();
            label_chats = new Label();
            btn_chat_user = new Button();
            btn_chat_all_users = new Button();
            btn_chat_general = new Button();
            lb_users = new ListBox();
            label_users = new Label();
            SuspendLayout();
            // 
            // lb_messages
            // 
            lb_messages.FormattingEnabled = true;
            lb_messages.ItemHeight = 15;
            lb_messages.Location = new Point(157, 12);
            lb_messages.Name = "lb_messages";
            lb_messages.SelectionMode = SelectionMode.None;
            lb_messages.Size = new Size(387, 559);
            lb_messages.TabIndex = 0;
            // 
            // btn_add_file
            // 
            btn_add_file.Location = new Point(157, 584);
            btn_add_file.Name = "btn_add_file";
            btn_add_file.Size = new Size(75, 23);
            btn_add_file.TabIndex = 1;
            btn_add_file.Text = "Add File";
            btn_add_file.UseVisualStyleBackColor = true;
            // 
            // btn_send
            // 
            btn_send.Location = new Point(486, 584);
            btn_send.Name = "btn_send";
            btn_send.Size = new Size(58, 23);
            btn_send.TabIndex = 2;
            btn_send.Text = "Send";
            btn_send.UseVisualStyleBackColor = true;
            // 
            // tb_message
            // 
            tb_message.Location = new Point(238, 585);
            tb_message.Name = "tb_message";
            tb_message.Size = new Size(242, 23);
            tb_message.TabIndex = 3;
            // 
            // label_chats
            // 
            label_chats.AutoSize = true;
            label_chats.Location = new Point(58, 12);
            label_chats.Name = "label_chats";
            label_chats.Size = new Size(37, 15);
            label_chats.TabIndex = 4;
            label_chats.Text = "Chats";
            // 
            // btn_chat_user
            // 
            btn_chat_user.BackColor = SystemColors.Control;
            btn_chat_user.Location = new Point(26, 30);
            btn_chat_user.Name = "btn_chat_user";
            btn_chat_user.Size = new Size(104, 23);
            btn_chat_user.TabIndex = 5;
            btn_chat_user.Text = "User";
            btn_chat_user.UseVisualStyleBackColor = false;
            // 
            // btn_chat_all_users
            // 
            btn_chat_all_users.Location = new Point(26, 88);
            btn_chat_all_users.Name = "btn_chat_all_users";
            btn_chat_all_users.Size = new Size(104, 23);
            btn_chat_all_users.TabIndex = 6;
            btn_chat_all_users.Text = "All Users";
            btn_chat_all_users.UseVisualStyleBackColor = true;
            // 
            // btn_chat_general
            // 
            btn_chat_general.Location = new Point(26, 59);
            btn_chat_general.Name = "btn_chat_general";
            btn_chat_general.Size = new Size(104, 23);
            btn_chat_general.TabIndex = 7;
            btn_chat_general.Text = "General";
            btn_chat_general.UseVisualStyleBackColor = true;
            // 
            // lb_users
            // 
            lb_users.FormattingEnabled = true;
            lb_users.ItemHeight = 15;
            lb_users.Location = new Point(12, 137);
            lb_users.Name = "lb_users";
            lb_users.Size = new Size(129, 469);
            lb_users.TabIndex = 8;
            // 
            // label_users
            // 
            label_users.AutoSize = true;
            label_users.Location = new Point(58, 114);
            label_users.Name = "label_users";
            label_users.Size = new Size(35, 15);
            label_users.TabIndex = 9;
            label_users.Text = "Users";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 619);
            Controls.Add(label_users);
            Controls.Add(lb_users);
            Controls.Add(btn_chat_general);
            Controls.Add(btn_chat_all_users);
            Controls.Add(btn_chat_user);
            Controls.Add(label_chats);
            Controls.Add(tb_message);
            Controls.Add(btn_send);
            Controls.Add(btn_add_file);
            Controls.Add(lb_messages);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lb_messages;
        private Button btn_add_file;
        private Button btn_send;
        private TextBox tb_message;
        private Label label_chats;
        private Button btn_chat_user;
        private Button btn_chat_all_users;
        private Button btn_chat_general;
        private ListBox lb_users;
        private Label label_users;
    }
}