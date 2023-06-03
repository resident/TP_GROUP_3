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
            pnlChat = new Panel();
            timerSync = new System.Windows.Forms.Timer(components);
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
            lbMessages.SelectionMode = SelectionMode.None;
            lbMessages.Size = new Size(611, 364);
            lbMessages.TabIndex = 3;
            // 
            // tbMessage
            // 
            tbMessage.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbMessage.Location = new Point(202, 402);
            tbMessage.Margin = new Padding(2);
            tbMessage.Name = "tbMessage";
            tbMessage.Size = new Size(446, 32);
            tbMessage.TabIndex = 4;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(733, 400);
            btnSend.Margin = new Padding(2);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(78, 33);
            btnSend.TabIndex = 5;
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
            btnAttachFile.TabIndex = 11;
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
            menu.Items.AddRange(new ToolStripItem[] { statusToolStripMenuItem, accountToolStripMenuItem, manageUsersToolStripMenuItem, settingsToolStripMenuItem, exitToolStripMenuItem });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(853, 24);
            menu.TabIndex = 16;
            // 
            // statusToolStripMenuItem
            // 
            statusToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { connectToolStripMenuItem, disconnectToolStripMenuItem });
            statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            statusToolStripMenuItem.Size = new Size(51, 20);
            statusToolStripMenuItem.Text = "Status";
            // 
            // connectToolStripMenuItem
            // 
            connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            connectToolStripMenuItem.Size = new Size(133, 22);
            connectToolStripMenuItem.Text = "Connect";
            connectToolStripMenuItem.Click += connectToolStripMenuItem_Click;
            // 
            // disconnectToolStripMenuItem
            // 
            disconnectToolStripMenuItem.Enabled = false;
            disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            disconnectToolStripMenuItem.Size = new Size(133, 22);
            disconnectToolStripMenuItem.Text = "Disconnect";
            disconnectToolStripMenuItem.Click += disconnectToolStripMenuItem_Click;
            // 
            // accountToolStripMenuItem
            // 
            accountToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registerToolStripMenuItem, loginToolStripMenuItem, logoutToolStripMenuItem });
            accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            accountToolStripMenuItem.Size = new Size(64, 20);
            accountToolStripMenuItem.Text = "Account";
            // 
            // registerToolStripMenuItem
            // 
            registerToolStripMenuItem.Enabled = false;
            registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            registerToolStripMenuItem.Size = new Size(116, 22);
            registerToolStripMenuItem.Text = "Register";
            registerToolStripMenuItem.Click += registerToolStripMenuItem_Click;
            // 
            // loginToolStripMenuItem
            // 
            loginToolStripMenuItem.Enabled = false;
            loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            loginToolStripMenuItem.Size = new Size(116, 22);
            loginToolStripMenuItem.Text = "Login";
            loginToolStripMenuItem.Click += loginToolStripMenuItem_Click;
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Enabled = false;
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(116, 22);
            logoutToolStripMenuItem.Text = "Logout";
            logoutToolStripMenuItem.Click += logoutToolStripMenuItem_Click;
            // 
            // manageUsersToolStripMenuItem
            // 
            manageUsersToolStripMenuItem.Enabled = false;
            manageUsersToolStripMenuItem.Name = "manageUsersToolStripMenuItem";
            manageUsersToolStripMenuItem.Size = new Size(93, 20);
            manageUsersToolStripMenuItem.Text = "Manage Users";
            manageUsersToolStripMenuItem.Visible = false;
            manageUsersToolStripMenuItem.Click += manageUsersToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(38, 20);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // status
            // 
            status.Items.AddRange(new ToolStripItem[] { statusLabelConnected, statusLabelLoggedAs, userStatus });
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
            // pnlChat
            // 
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
            pnlChat.Size = new Size(829, 450);
            pnlChat.TabIndex = 18;
            // 
            // timerSync
            // 
            timerSync.Interval = 2000;
            timerSync.Tick += timerSync_Tick;
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
        private ToolStripMenuItem statusToolStripMenuItem;
        private ToolStripMenuItem connectToolStripMenuItem;
        private ToolStripMenuItem disconnectToolStripMenuItem;
        private ToolStripMenuItem accountToolStripMenuItem;
        private ToolStripMenuItem registerToolStripMenuItem;
        private ToolStripMenuItem loginToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private StatusStrip status;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripStatusLabel statusLabelConnected;
        private ToolStripStatusLabel statusLabelLoggedAs;
        private Panel pnlChat;
        private ToolStripMenuItem manageUsersToolStripMenuItem;
        private System.Windows.Forms.Timer timerSync;
        private ToolStripStatusLabel userStatus;
        private ToolStripMenuItem settingsToolStripMenuItem;
    }
}