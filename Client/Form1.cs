using Shared;

namespace Client
{
    public partial class Form1 : Form
    {
        private ChatTcpClient _client;

        public Form1()
        {
            _client = new ChatTcpClient("127.0.0.1", 1234);

            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            _client.Connect();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {

            var request = new Request("registration");
            var user = new User("userLogin", "userPassword");
            request.Payload.Add("user", user);
            _client.SendMessage(request.ToString());

            var response = Response.FromJson(await _client.ReceiveMessage()) ?? new Response();
            MessageBox.Show($"Response status: {response.Status} message: {response.Message}");
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var request = new Request("login");
            var auth = new Dictionary<string, string>()
            {
                {"login", "userLogin"},
                {"password", "userPassword"},
            };

            request.Payload.Add("auth", auth);
            _client.SendMessage(request.ToString());

            var response = Response.FromJson(await _client.ReceiveMessage()) ?? new Response();
            MessageBox.Show($"Response status: {response.Status} message: {response.Message}");
        }
    }
}