using System.Collections.Immutable;
using System.Data;
using Shared;
using System.Windows.Forms;
using Collections;
using static System.Net.Mime.MediaTypeNames;

namespace Client
{
    public sealed partial class MainForm : Form
    {
        internal ChatTcpClient Client;
        private bool _connected;
        private event EventHandler ConnectionChanged;
        private User? _user;
        private event EventHandler UserChanged;
        public bool LoggedIn;
        private string? _attachedFilePath;
        public readonly UsersCollection RegisteredUsers = new();
        public readonly ChatsCollection Chats = new();
        public Chat? GeneralChat;
        public Chat? CurrentChat;
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

        private void OnConnectionChanged()
        {
            ConnectionChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnUserChanged()
        {
            UserChanged?.Invoke(this, EventArgs.Empty);
        }

        public MainForm()
        {
            Client = GetFreshClient();

            ConnectionChanged += delegate
            {
                statusLabelConnected.Text = Connected ? "Connected" : "Disconnected";

                connectToolStripMenuItem.Enabled = !Connected;
                disconnectToolStripMenuItem.Enabled = Connected;
                registerToolStripMenuItem.Enabled = Connected && !LoggedIn;
                loginToolStripMenuItem.Enabled = Connected && !LoggedIn;
                logoutToolStripMenuItem.Enabled = Connected && LoggedIn;
                pnlChat.Enabled = Connected && LoggedIn && User!.IsActive && !User!.IsBanned;

                timerSync.Enabled = Connected;
            };

            UserChanged += delegate
            {
                LoggedIn = User != null;
                statusLabelLoggedAs.Text = LoggedIn ? $"Logged in as: {User!.Login}" : "Not logged in";

                registerToolStripMenuItem.Enabled = Connected && !LoggedIn;
                loginToolStripMenuItem.Enabled = Connected && !LoggedIn;
                logoutToolStripMenuItem.Enabled = Connected && LoggedIn;
                pnlChat.Enabled = Connected && LoggedIn && User!.IsActive && !User!.IsBanned;

                manageUsersToolStripMenuItem.Enabled = LoggedIn && User!.IsAdmin;
                manageUsersToolStripMenuItem.Visible = LoggedIn && User!.IsAdmin;

                userStatus.Text = LoggedIn ? User!.IsActive ? "Status Active" : "Status Inactive" : "";
                userBanned.Text = LoggedIn && User!.IsBanned ? "Banned" : "";
            };

            InitializeComponent();

            lbChats.DataSource = Chats;

            lblMessageLength.Text = tbMessage.MaxLength.ToString();
        }

        private ChatTcpClient GetFreshClient()
        {
            var serverIpAddress = Settings.Get<string>("server_ip_address");
            var serverPort = Settings.Get<int>("server_port");

            return new ChatTcpClient(serverIpAddress, serverPort);
        }

        private void btnCreateChat_Click(object sender, EventArgs e)
        {
            var form = new CreateChatForm();

            form.Owner = this;

            form.ShowDialog();
        }

        private async void btnRemoveChat_Click(object sender, EventArgs e)
        {
            if (null == CurrentChat) return;

            var request = new Request("RemoveChat");

            request.Payload.Add("user", User!);
            request.Payload.Add("chat", CurrentChat);

            Client.SendMessage(request.ToJson());

            var response = Response.FromJson(await Client.ReceiveMessage()) ?? new Response();

            if (response.IsStatusOk())
                Chats.Remove(CurrentChat);
            else
                Alert.Error(response.Message);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new SettingsForm();

            form.Owner = this;

            form.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Client.IsConnected()) return;

                Client = GetFreshClient();

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

            if (lbChats.SelectedItem is not Chat chat) return;

            var chatFile = _attachedFilePath != null ? new ChatFile(_attachedFilePath) : null;
            var chatMessage = new ChatMessage(User, chat, tbMessage.Text, chatFile);

            var request = new Request("SendChatMessage");
            request.Payload.Add("message", chatMessage);

            Client.SendMessage(request.ToJson());

            if (chatMessage.ChatFile != null) chatMessage.ChatFile.FileContent = Array.Empty<byte>();

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

            if (null == CurrentChat) return;

            foreach (var message in CurrentChat.Messages) lbMessages.Items.Add(message);

            lbMessages.TopIndex = lbMessages.Items.Count - 1;
        }

        private async void timerSync_Tick(object sender, EventArgs e)
        {
            if (!Connected) return;

            try
            {
                var request = new Request("KeepAlive");

                Client.SendMessage(request.ToJson());

                _ = Response.FromJson(await Client.ReceiveMessage()) ?? new Response();
            }
            catch
            {
                //ignored
            }

            if (null == User) return;

            try
            {
                var request = new Request("Sync");

                request.Payload.Add("lastSyncTime", LastSyncTime);
                request.Payload.Add("user", User);

                Client.SendMessage(request.ToJson());

                var response = Response.FromJson(await Client.ReceiveMessage()) ?? new Response();

                if (response.IsStatusOk())
                {
                    var syncStatus = response.GetString("syncStatus");

                    if (syncStatus == "updates")
                    {
                        var users = response.Get<UsersCollection>("users");
                        var chats = response.Get<ChatsCollection>("chats");

                        RegisteredUsers.Clear();

                        RegisteredUsers.AddUsers(users);

                        if (null != User) User = RegisteredUsers.GetById(User.Id);

                        var selectedChat = CurrentChat;

                        Chats.Clear();
                        lbMessages.Items.Clear();

                        if (User is { IsActive: true, IsBanned: false })
                        {
                            Chats.AddChats(chats);

                            if (selectedChat != null) lbChats.SelectedItem = Chats.GetById(selectedChat.Id);

                            if (Chats.Count > 0)
                            {
                                GeneralChat = Chats.ElementAt(0);
                                CurrentChat ??= GeneralChat;

                                CurrentChat = Chats.GetById(CurrentChat.Id) ?? GeneralChat;

                                lbChats.SelectedItem = CurrentChat;

                                lbMessages.Items.Clear();

                                foreach (var message in CurrentChat.Messages) lbMessages.Items.Add(message);

                                lbMessages.TopIndex = lbMessages.Items.Count - 1;
                            }
                        }
                    }

                    LastSyncTime = DateTime.Now;
                }
                else
                {
                    Alert.Error(response.Message);
                }
            }
            catch
            {
                //ignored
            }
        }

        private void lbMessages_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            var selectedIndex = lbMessages.IndexFromPoint(e.Location);

            if (ListBox.NoMatches == selectedIndex) return;

            lbMessages.SelectedIndex = selectedIndex;

            var contextMenuStrip = new ContextMenuStrip();

            if (lbMessages.SelectedItem is ChatMessage) (contextMenuStrip.Items.Add("Copy Message")).Click += CopyMessageMenuItem_Click;
            if (lbMessages.SelectedItem is ChatMessage { HasFile: true }) (contextMenuStrip.Items.Add("Save File")).Click += SaveChatFileMenuItem_Click;

            contextMenuStrip.Show(lbMessages, e.Location);
        }

        private void CopyMessageMenuItem_Click(object? sender, EventArgs e)
        {
            if (lbMessages.SelectedItem is not ChatMessage message) return;

            Clipboard.SetText(message.Message);
        }

        private async void SaveChatFileMenuItem_Click(object? sender, EventArgs e)
        {
            if (lbMessages.SelectedItem is not ChatMessage message) return;

            var chatFile = message.ChatFile ?? throw new NoNullAllowedException();

            var saveFileDialog = new SaveFileDialog()
            {
                CheckWriteAccess = true,
                OverwritePrompt = true,
                AddExtension = true,
                DefaultExt = Path.GetExtension(chatFile.Name),
                FileName = chatFile.Name,
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            var request = new Request("GetChatFile");

            request.Payload.Add("message", message);

            Client.SendMessage(request.ToJson());

            var response = Response.FromJson(await Client.ReceiveMessage()) ?? new Response();

            if (response.IsStatusOk())
            {
                chatFile = response.Get<ChatFile>("chatFile");

                await File.WriteAllBytesAsync(saveFileDialog.FileName, chatFile.FileContent);
            }
            else
            {
                Alert.Error(response.Message);
            }
        }

        private void tbMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSend.PerformClick();
                e.Handled = true;
            }
        }

        private void tbMessage_TextChanged(object sender, EventArgs e)
        {
            lblMessageLength.Text = (tbMessage.MaxLength - tbMessage.Text.Length).ToString();
        }

        private void ChangeLocation()
        {
            btnAttachFile.Location = tbMessage.Location with {X = tbMessage.Location.X + tbMessage.Width + 2};
            btnSend.Location = btnAttachFile.Location with {X = btnAttachFile.Location.X + btnAttachFile.Width + 2};
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ChangeLocation();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            ChangeLocation();
        }
    }
}