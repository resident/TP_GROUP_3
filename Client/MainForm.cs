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
            };

            UserChanged += (sender, args) =>
            {
                LoggedIn = User != null;
                statusLabelLoggedAs.Text = LoggedIn ? $"Logged in as: {User.Login}" : "Not logged in";

                registerToolStripMenuItem.Enabled = Connected && !LoggedIn;
                loginToolStripMenuItem.Enabled = Connected && !LoggedIn;
                logoutToolStripMenuItem.Enabled = Connected && LoggedIn;
                pnlChat.Enabled = Connected && LoggedIn;

                manageUsersToolStripMenuItem.Enabled = LoggedIn && User.IsAdmin;
                manageUsersToolStripMenuItem.Visible = LoggedIn && User.IsAdmin;
            };

            InitializeComponent();
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
            catch (Exception ex)
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
            catch (Exception ex)
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
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ManageUsersForm();

            form.Owner = this;

            form.ShowDialog();
        }
    }
}