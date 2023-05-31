using System;
using System.ComponentModel;
using Newtonsoft.Json;
using Shared;

namespace Client
{
    public partial class MainForm : Form
    {
        internal readonly ChatTcpClient Client;
        private bool _connected;
        private event EventHandler ConnectionChanged;
        private User? _user;
        private event EventHandler UserChanged;
        public bool LoggedIn;
        private string? _attachedFilePath;
        public readonly UsersCollection RegisteredUsers = new UsersCollection();
        public readonly ChatsCollection Chats = new ChatsCollection();
        public Chat GeneralChat;
        public Chat CurrentChat;
        public DateTime LastSyncTime = DateTime.MinValue;

        public bool Connected
        {
            get => _connected;
            set
            {
                if (_connected != value)
                {
                    _connected = value;
                    OnConnectionChanged();
                }
            }
        }

        public User? User
        {
            get => _user;
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnUserChanged();
                }
            }
        }

        protected virtual void OnConnectionChanged()
        {
            ConnectionChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnUserChanged()
        {
            UserChanged?.Invoke(this, EventArgs.Empty);
        }

        public MainForm()
        {
            Client = new ChatTcpClient("127.0.0.1", 1234);

            ConnectionChanged += (sender, args) =>
            {
                statusLabelConnected.Text = Connected ? "Connected" : "Disconnected";

                connectToolStripMenuItem.Enabled = !Connected;
                disconnectToolStripMenuItem.Enabled = Connected;
                registerToolStripMenuItem.Enabled = Connected && !LoggedIn;
                loginToolStripMenuItem.Enabled = Connected && !LoggedIn;
                logoutToolStripMenuItem.Enabled = Connected && LoggedIn;
                pnlChat.Enabled = Connected && LoggedIn;

                timerSync.Enabled = Connected && LoggedIn;
            };

            UserChanged += (sender, args) =>
            {
                LoggedIn = User != null;
                statusLabelLoggedAs.Text = LoggedIn ? $"Logged in as: {User!.Login}" : "Not logged in";

                registerToolStripMenuItem.Enabled = Connected && !LoggedIn;
                loginToolStripMenuItem.Enabled = Connected && !LoggedIn;
                logoutToolStripMenuItem.Enabled = Connected && LoggedIn;
                pnlChat.Enabled = Connected && LoggedIn;

                timerSync.Enabled = Connected && LoggedIn;

                manageUsersToolStripMenuItem.Enabled = LoggedIn && User!.IsAdmin;
                manageUsersToolStripMenuItem.Visible = LoggedIn && User!.IsAdmin;
            };

            InitializeComponent();

            lbChats.DataSource = Chats;
        }

        private void btnCreateChat_Click(object sender, EventArgs e)
        {
            var form = new CreateChatForm();

            form.Owner = this;

            form.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Client.IsDisconnected())
                    Client.Connect();
            }
            catch
            {
                // ignored
            }
            finally
            {
                Connected = Client.IsConnected();
            }

        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Client.IsConnected())
                    Client.Disconnect();
            }
            catch
            {
                // ignored
            }
            finally
            {
                Connected = Client.IsConnected();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Client.Close();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new RegisterForm();

            form.Owner = this;

            form.ShowDialog();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new LoginForm();

            form.Owner = this;

            form.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User = null;
            Chats.Clear();
            lbMessages.Items.Clear();
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ManageUsersForm();

            form.Owner = this;

            form.ShowDialog();
        }

        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            openFileDialog.Multiselect = false;

            _attachedFilePath = openFileDialog.ShowDialog() == DialogResult.OK ? openFileDialog.FileName : null;
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbMessage.Text) || User == null) return;

            if (null == lbChats.SelectedItem)
            {
                Alert.Error("Select chat");
                return;
            }

            var chat = lbChats.SelectedItem as Chat ?? GeneralChat;
            var chatFile = _attachedFilePath != null ? new ChatFile(_attachedFilePath) : null;
            var chatMessage = new ChatMessage(User, chat, tbMessage.Text, chatFile);

            var request = new Request("SendChatMessage");
            request.Payload.Add("message", chatMessage);

            Client.SendMessage(request.ToJson());

            tbMessage.Text = string.Empty;

            _attachedFilePath = null;

            var response = Response.FromJson(await Client.ReceiveMessage()) ?? new Response();

            if (response.IsStatusOk())
            {
                chat.AddMessage(chatMessage);

                lbMessages.Items.Add(chatMessage);
            }
            else
            {
                Alert.Error($"{response.Message}");
            }
        }

        private void lbChats_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentChat = lbChats.SelectedItem as Chat ?? GeneralChat;

            lbMessages.Items.Clear();

            foreach (var message in CurrentChat.Messages)
            {
                lbMessages.Items.Add(message);
            }
        }

        private async void timerSync_Tick(object sender, EventArgs e)
        {
            if (!Connected) return;

            var request = new Request("Sync");

            request.Payload.Add("lastSyncTime", LastSyncTime);
            request.Payload.Add("user", User);

            Client.SendMessage(request.ToJson());

            var response = Response.FromJson(await Client.ReceiveMessage()) ?? new Response();

            if (response.IsStatusOk())
            {
                var users = response.Get<List<User>>("users");
                var chats = response.Get<List<Chat>>("chats");

                RegisteredUsers.Clear();
                RegisteredUsers.AddUsers(users!);

                Chats.Clear();
                Chats.AddChats(chats!);

                if (Chats.Count > 0)
                {
                    GeneralChat = Chats.ElementAt(0);
                    CurrentChat = GeneralChat;
                }
            }
            else
            {
                Alert.Error($"{response.Message}");
            }

            LastSyncTime = DateTime.Now;
        }
    }
}