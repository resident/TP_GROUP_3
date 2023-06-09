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
        private bool _connecting;
        private bool _connected;
        private event EventHandler ConnectingChanged;
        private event EventHandler ConnectionChanged;
        private User? _user;
        private event EventHandler UserChanged;
        public bool LoggedIn;
        private string? _attachedFilePath;
        private bool _fileAttached;
        private event EventHandler AttachedFilePathChanged;
        public readonly UsersCollection RegisteredUsers = new();
        public readonly ChatsCollection Chats = new();
        public readonly MessagesCollection Messages = new();
        public Chat? GeneralChat;
        public Chat? CurrentChat;


        public bool Connecting
        {
            get => _connecting;
            set
            {
                if (_connecting != value)
                {
                    _connecting = value;
                    OnConnectingChanged();
                }
            }
        }

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
                if (!Equals(_user, value))
                {
                    _user = value;

                    OnUserChanged();
                }
            }
        }

        public string? AttachedFilePath
        {
            get => _attachedFilePath;
            set
            {
                if (_attachedFilePath != value)
                {
                    _attachedFilePath = value;
                    OnAttachedFilePathChanged();
                }
            }
        }

        private void OnConnectingChanged()
        {
            ConnectingChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnConnectionChanged()
        {
            ConnectionChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnUserChanged()
        {
            UserChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnAttachedFilePathChanged()
        {
            AttachedFilePathChanged?.Invoke(this, EventArgs.Empty);
        }

        public MainForm()
        {
            Client = GetFreshClient();

            ConnectingChanged += delegate
            {
                statusLabelConnected.Text = Connecting ? "Connecting..." : Connected ? "Connected" : "Disconnected";
                connectToolStripMenuItem.Enabled = !Connected && !Connecting;
                disconnectToolStripMenuItem.Enabled = Connected || Connecting;

                Log.Write(statusLabelConnected.Text, Log.TypeNotice);
            };

            ConnectionChanged += delegate
            {
                statusLabelConnected.Text = Connected ? "Connected" : "Disconnected";

                connectToolStripMenuItem.Enabled = !Connected && !Connecting;
                disconnectToolStripMenuItem.Enabled = Connected || Connecting;
                registerToolStripMenuItem.Enabled = Connected && !LoggedIn;
                loginToolStripMenuItem.Enabled = Connected && !LoggedIn;
                logoutToolStripMenuItem.Enabled = Connected && LoggedIn;
                pnlChat.Enabled = Connected && LoggedIn && User!.IsActive && !User!.IsBanned;

                timerSync.Enabled = Connected;
            };

            UserChanged += delegate
            {
                LoggedIn = User != null;

                if (LoggedIn)
                {
                    Log.Write($"User '{User!.Login}' logged in", Log.TypeNotice);
                    File.WriteAllText("user.json", User!.ToJson());
                }
                else
                {
                    Log.Write($"User logged out", Log.TypeNotice);
                    File.Delete("user.json");
                }

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

            AttachedFilePathChanged += delegate
            {
                _fileAttached = !string.IsNullOrWhiteSpace(AttachedFilePath);

                tbMessage.ReadOnly = _fileAttached;
                tbMessage.Text = _fileAttached ? Path.GetFileName(AttachedFilePath) : string.Empty;

                btnAttachFile.Text = _fileAttached ? "Detach file" : "Attach file";
            };

            InitializeComponent();

            if (File.Exists("user.json")) User = User.Load("user.json");

            lbChats.DataSource = Chats;
            lbMessages.DataSource = Messages;

            lblMessageLength.Text = tbMessage.MaxLength.ToString();

            connectToolStripMenuItem.PerformClick();
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
            if (CurrentChat is null) return;

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

        private async void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Connecting) return;

            Connecting = true;

            while (Connecting)
            {
                try
                {
                    if (Client.IsConnected()) return;

                    Client = GetFreshClient();

                    await Client.ConnectAsync();
                }
                catch
                {
                    // ignored
                }
                finally
                {
                    Connected = Client.IsConnected();

                    Connecting = Connecting ? !Connected : Connected;
                }
            }
        }

        private async void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Connecting = false;

                if (Client.IsConnected())
                    await Client.DisconnectAsync();
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
            Messages.Clear();
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ManageUsersForm();

            form.Owner = this;

            form.ShowDialog();
        }

        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            if (_fileAttached)
            {
                AttachedFilePath = null;
            }
            else
            {

                var openFileDialog = new OpenFileDialog();

                openFileDialog.Multiselect = false;

                AttachedFilePath = openFileDialog.ShowDialog() == DialogResult.OK ? openFileDialog.FileName : null;
            }
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

            var chatFile = AttachedFilePath != null ? new ChatFile(AttachedFilePath) : null;
            var chatMessage = new ChatMessage(User, chat.Id, tbMessage.Text, chatFile);

            var request = new Request("SendChatMessage");
            request.Payload.Add("message", chatMessage);

            Client.SendMessage(request.ToJson());

            if (chatMessage.ChatFile != null) chatMessage.ChatFile.FileContent = Array.Empty<byte>();

            tbMessage.Text = string.Empty;

            AttachedFilePath = null;

            var response = Response.FromJson(await Client.ReceiveMessage()) ?? new Response();

            if (response.IsStatusOk())
            {
                chat.AddMessage(chatMessage);

                Messages.Add(chatMessage);
            }
            else
            {
                Alert.Error($"{response.Message}");
            }
        }

        private void lbChats_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentChat = lbChats.SelectedItem as Chat ?? GeneralChat;

            Messages.Clear();

            if (null == CurrentChat) return;

            foreach (var message in CurrentChat.Messages) Messages.Add(message);

            lbMessages.TopIndex = Messages.Count - 1;
        }

        private async void timerSync_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!Connected) return;

                // KeepAlive
                var request = new Request("KeepAlive");

                Client.SendMessage(request.ToJson());

                _ = Response.FromJson(await Client.ReceiveMessage()) ?? new Response();

                if (null == User) return;

                // Sync
                request = new Request("Sync");

                request.Payload.Add("lastSyncTime", Sync.GetLastChangeTime());
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
                        Messages.Clear();

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

                                Messages.Clear();

                                foreach (var message in CurrentChat.Messages) Messages.Add(message);

                                lbMessages.TopIndex = Messages.Count - 1;
                            }
                        }
                    }

                    Sync.UpdateLastChangeTime();
                }
                else
                {
                    Alert.Error(response.Message);
                }
            }
            catch
            {
                Log.Write("Connection lost", Log.TypeWarning);
                await Client.DisconnectAsync();
                Connected = false;
                connectToolStripMenuItem.PerformClick();
            }
        }

        private void lbMessages_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            var selectedIndex = lbMessages.IndexFromPoint(e.Location);

            if (ListBox.NoMatches == selectedIndex) return;

            lbMessages.SelectedIndex = selectedIndex;

            var contextMenuStrip = new ContextMenuStrip();

            if (lbMessages.SelectedItem is ChatMessage message)
            {
                (contextMenuStrip.Items.Add("Copy Message")).Click += CopyMessageMenuItem_Click;

                if (User is not null && (User.IsAdmin || message.Sender.Id == User.Id))
                    (contextMenuStrip.Items.Add("Delete Message")).Click += DeleteMessageMenuItem_Click;

                if (message.HasFile) (contextMenuStrip.Items.Add("Save File")).Click += SaveChatFileMenuItem_Click;
            }

            contextMenuStrip.Show(lbMessages, e.Location);
        }

        private void CopyMessageMenuItem_Click(object? sender, EventArgs e)
        {
            if (lbMessages.SelectedItem is not ChatMessage message) return;

            Clipboard.SetText(message.Message);
        }

        private async void DeleteMessageMenuItem_Click(object? sender, EventArgs e)
        {
            if (lbMessages.SelectedItem is not ChatMessage message) return;

            var request = new Request("DeleteMessage");

            request.Payload.Add("user", User);
            request.Payload.Add("message", message);

            Client.SendMessage(request.ToJson());

            var response = Response.FromJson(await Client.ReceiveMessage()) ?? new Response();

            if (response.IsStatusError())
                Alert.Error(response.Message);
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
            btnAttachFile.Location = tbMessage.Location with { X = tbMessage.Location.X + tbMessage.Width + 2 };
            btnSend.Location = btnAttachFile.Location with { X = btnAttachFile.Location.X + btnAttachFile.Width + 2 };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ChangeLocation();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            ChangeLocation();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (CurrentChat is null) return;

            var form = new EditChatForm();

            form.Owner = this;

            form.ShowDialog();
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (null == e.Data) return;
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (null == e.Data || !e.Data.GetDataPresent(DataFormats.FileDrop)) return;
            if (e.Data.GetData(DataFormats.FileDrop) is string[] files) AttachedFilePath = files.First();
        }

        private void lbMessages_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) DeleteMessageMenuItem_Click(lbMessages, EventArgs.Empty);
        }

        private void timerNtpSync_Tick(object sender, EventArgs e)
        {
            DateTimeSync.UpdateTimeSpan();
        }
    }
}