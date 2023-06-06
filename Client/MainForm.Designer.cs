namespace Client
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            lbMessages = new ListBox();
            tbMessage = new TextBox();
            btnSend = new Button();
            lblMessages = new Label();
            btnAttachFile = new Button();
            lblChats = new Label();
            lbChats = new ListBox();
            btnCreateChat = new Button();
            btnRemoveChat = new Button();
            menu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            statusToolStripMenuItem = new ToolStripMenuItem();
            connectToolStripMenuItem = new ToolStripMenuItem();
            disconnectToolStripMenuItem = new ToolStripMenuItem();
            accountToolStripMenuItem = new ToolStripMenuItem();
            registerToolStripMenuItem = new ToolStripMenuItem();
            loginToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            manageUsersToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            status = new StatusStrip();
            statusLabelConnected = new ToolStripStatusLabel();
            statusLabelLoggedAs = new ToolStripStatusLabel();
            userStatus = new ToolStripStatusLabel();
            userBanned = new ToolStripStatusLabel();
            pnlChat = new Panel();
            lblMessageLength = new Label();
            timerSync = new System.Windows.Forms.Timer(components);
            timerKeepAlive = new System.Windows.Forms.Timer(components);
            menu.SuspendLayout();
            status.SuspendLayout();
            pnlChat.SuspendLayout();
            SuspendLayout();
            // 
            // lbMessages
            // 
            lbMessages.FormattingEnabled = true;
            lbMessages.ItemHeight = 15;
            lbMessages.Location = new Point(202, 34);
            lbMessages.Margin = new Padding(2);
            lbMessages.Name = "lbMessages";
            lbMessages.Size = new Size(611, 364);
            lbMessages.TabIndex = 3;
            lbMessages.MouseUp += lbMessages_MouseUp;
            // 
            // tbMessage
            // 
            tbMessage.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbMessage.Location = new Point(202, 402);
            tbMessage.Margin = new Padding(2);
            tbMessage.MaxLength = 50;
            tbMessage.Name = "tbMessage";
            tbMessage.Size = new Size(446, 32);
            tbMessage.TabIndex = 4;
            tbMessage.TextChanged += tbMessage_TextChanged;
            tbMessage.KeyPress += tbMessage_KeyPress;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(733, 400);
            btnSend.Margin = new Padding(2);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(78, 33);
            btnSend.TabIndex = 6;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // lblMessages
            // 
            lblMessages.AutoSize = true;
            lblMessages.Location = new Point(202, 18);
            lblMessages.Margin = new Padding(2, 0, 2, 0);
            lblMessages.Name = "lblMessages";
            lblMessages.Size = new Size(58, 15);
            lblMessages.TabIndex = 10;
            lblMessages.Text = "Messages";
            // 
            // btnAttachFile
            // 
            btnAttachFile.Location = new Point(650, 401);
            btnAttachFile.Margin = new Padding(2);
            btnAttachFile.Name = "btnAttachFile";
            btnAttachFile.Size = new Size(78, 32);
            btnAttachFile.TabIndex = 5;
            btnAttachFile.Text = "Attach File";
            btnAttachFile.UseVisualStyleBackColor = true;
            btnAttachFile.Click += btnAttachFile_Click;
            // 
            // lblChats
            // 
            lblChats.AutoSize = true;
            lblChats.Location = new Point(13, 18);
            lblChats.Margin = new Padding(2, 0, 2, 0);
            lblChats.Name = "lblChats";
            lblChats.Size = new Size(37, 15);
            lblChats.TabIndex = 13;
            lblChats.Text = "Chats";
            // 
            // lbChats
            // 
            lbChats.FormattingEnabled = true;
            lbChats.ItemHeight = 15;
            lbChats.Location = new Point(13, 34);
            lbChats.Margin = new Padding(2);
            lbChats.Name = "lbChats";
            lbChats.Size = new Size(180, 364);
            lbChats.TabIndex = 12;
            lbChats.SelectedIndexChanged += lbChats_SelectedIndexChanged;
            // 
            // btnCreateChat
            // 
            btnCreateChat.Location = new Point(13, 402);
            btnCreateChat.Margin = new Padding(2);
            btnCreateChat.Name = "btnCreateChat";
            btnCreateChat.Size = new Size(84, 31);
            btnCreateChat.TabIndex = 14;
            btnCreateChat.Text = "Create";
            btnCreateChat.UseVisualStyleBackColor = true;
            btnCreateChat.Click += btnCreateChat_Click;
            // 
            // btnRemoveChat
            // 
            btnRemoveChat.Location = new Point(113, 402);
            btnRemoveChat.Margin = new Padding(2);
            btnRemoveChat.Name = "btnRemoveChat";
            btnRemoveChat.Size = new Size(78, 31);
            btnRemoveChat.TabIndex = 15;
            btnRemoveChat.Text = "Remove";
            btnRemoveChat.UseVisualStyleBackColor = true;
            btnRemoveChat.Click += btnRemoveChat_Click;
            // 
            // menu
            // 
            menu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(853, 24);
            menu.TabIndex = 16;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { statusToolStripMenuItem, accountToolStripMenuItem, manageUsersToolStripMenuItem, settingsToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // statusToolStripMenuItem
            // 
            statusToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { connectToolStripMenuItem, disconnectToolStripMenuItem });
            statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            statusToolStripMenuItem.Size = new Size(189, 22);
            statusToolStripMenuItem.Text = "Status";
            // 
            // connectToolStripMenuItem
            // 
            connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            connectToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.C;
            connectToolStripMenuItem.Size = new Size(171, 22);
            connectToolStripMenuItem.Text = "Connect";
            connectToolStripMenuItem.Click += connectToolStripMenuItem_Click;
            // 
            // disconnectToolStripMenuItem
            // 
            disconnectToolStripMenuItem.Enabled = false;
            disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            disconnectToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D;
            disconnectToolStripMenuItem.Size = new Size(171, 22);
            disconnectToolStripMenuItem.Text = "Disconnect";
            disconnectToolStripMenuItem.Click += disconnectToolStripMenuItem_Click;
            // 
            // accountToolStripMenuItem
            // 
            accountToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registerToolStripMenuItem, loginToolStripMenuItem, logoutToolStripMenuItem });
            accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            accountToolStripMenuItem.Size = new Size(189, 22);
            accountToolStripMenuItem.Text = "Account";
            // 
            // registerToolStripMenuItem
            // 
            registerToolStripMenuItem.Enabled = false;
            registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            registerToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.R;
            registerToolStripMenuItem.Size = new Size(175, 22);
            registerToolStripMenuItem.Text = "Register";
            registerToolStripMenuItem.Click += registerToolStripMenuItem_Click;
            // 
            // loginToolStripMenuItem
            // 
            loginToolStripMenuItem.Enabled = false;
            loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            loginToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.L;
            loginToolStripMenuItem.Size = new Size(175, 22);
            loginToolStripMenuItem.Text = "Login";
            loginToolStripMenuItem.Click += loginToolStripMenuItem_Click;
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Enabled = false;
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.L;
            logoutToolStripMenuItem.Size = new Size(175, 22);
            logoutToolStripMenuItem.Text = "Logout";
            logoutToolStripMenuItem.Click += logoutToolStripMenuItem_Click;
            // 
            // manageUsersToolStripMenuItem
            // 
            manageUsersToolStripMenuItem.Enabled = false;
            manageUsersToolStripMenuItem.Name = "manageUsersToolStripMenuItem";
            manageUsersToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.M;
            manageUsersToolStripMenuItem.Size = new Size(189, 22);
            manageUsersToolStripMenuItem.Text = "Manage Users";
            manageUsersToolStripMenuItem.Visible = false;
            manageUsersToolStripMenuItem.Click += manageUsersToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.S;
            settingsToolStripMenuItem.Size = new Size(189, 22);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.E;
            exitToolStripMenuItem.Size = new Size(189, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // status
            // 
            status.Items.AddRange(new ToolStripItem[] { statusLabelConnected, statusLabelLoggedAs, userStatus, userBanned });
            status.Location = new Point(0, 494);
            status.Name = "status";
            status.Size = new Size(853, 22);
            status.TabIndex = 17;
            // 
            // statusLabelConnected
            // 
            statusLabelConnected.Name = "statusLabelConnected";
            statusLabelConnected.Size = new Size(79, 17);
            statusLabelConnected.Text = "Disconnected";
            // 
            // statusLabelLoggedAs
            // 
            statusLabelLoggedAs.Name = "statusLabelLoggedAs";
            statusLabelLoggedAs.Size = new Size(80, 17);
            statusLabelLoggedAs.Text = "Not logged in";
            // 
            // userStatus
            // 
            userStatus.Name = "userStatus";
            userStatus.Size = new Size(0, 17);
            // 
            // userBanned
            // 
            userBanned.Name = "userBanned";
            userBanned.Size = new Size(0, 17);
            // 
            // pnlChat
            // 
            pnlChat.Controls.Add(lblMessageLength);
            pnlChat.Controls.Add(lbMessages);
            pnlChat.Controls.Add(tbMessage);
            pnlChat.Controls.Add(btnRemoveChat);
            pnlChat.Controls.Add(btnSend);
            pnlChat.Controls.Add(btnCreateChat);
            pnlChat.Controls.Add(lblMessages);
            pnlChat.Controls.Add(lblChats);
            pnlChat.Controls.Add(btnAttachFile);
            pnlChat.Controls.Add(lbChats);
            pnlChat.Enabled = false;
            pnlChat.Location = new Point(12, 27);
            pnlChat.Name = "pnlChat";
            pnlChat.Size = new Size(829, 464);
            pnlChat.TabIndex = 18;
            // 
            // lblMessageLength
            // 
            lblMessageLength.AutoSize = true;
            lblMessageLength.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblMessageLength.Location = new Point(202, 436);
            lblMessageLength.Name = "lblMessageLength";
            lblMessageLength.Size = new Size(21, 15);
            lblMessageLength.TabIndex = 16;
            lblMessageLength.Text = "50";
            // 
            // timerSync
            // 
            timerSync.Interval = 2000;
            timerSync.Tick += timerSync_Tick;
            // 
            // timerKeepAlive
            // 
            timerKeepAlive.Interval = 1500;
            timerKeepAlive.Tick += timerKeepAlive_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 516);
            Controls.Add(pnlChat);
            Controls.Add(status);
            Controls.Add(menu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menu;
            Margin = new Padding(2);
            Name = "MainForm";
            Text = "Chat";
            FormClosing += MainForm_FormClosing;
            menu.ResumeLayout(false);
            menu.PerformLayout();
            status.ResumeLayout(false);
            status.PerformLayout();
            pnlChat.ResumeLayout(false);
            pnlChat.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox lbMessages;
        private TextBox tbMessage;
        private Button btnSend;
        private Label lblMessages;
        private Button btnAttachFile;
        private Label lblChats;
        private Button btnCreateChat;
        private Button btnRemoveChat;
        internal ListBox lbChats;
        private MenuStrip menu;
        private StatusStrip status;
        private ToolStripStatusLabel statusLabelConnected;
        private ToolStripStatusLabel statusLabelLoggedAs;
        private Panel pnlChat;
        private System.Windows.Forms.Timer timerSync;
        private ToolStripStatusLabel userStatus;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem statusToolStripMenuItem;
        private ToolStripMenuItem connectToolStripMenuItem;
        private ToolStripMenuItem disconnectToolStripMenuItem;
        private ToolStripMenuItem accountToolStripMenuItem;
        private ToolStripMenuItem registerToolStripMenuItem;
        private ToolStripMenuItem loginToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ToolStripMenuItem manageUsersToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripStatusLabel userBanned;
        private System.Windows.Forms.Timer timerKeepAlive;
        private Label lblMessageLength;
    }
}