using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared;

namespace Client
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLogin.Text) || string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                MessageBox.Show("You need provide login and password");
                return;
            }

            if (this.Owner is MainForm mainForm)
            {
                var request = new Request("login");
                var login = tbLogin.Text;
                var password = tbPassword.Text;
                var auth = new Dictionary<string, string>()
                {
                    {"login", login},
                    {"password", password},
                };

                request.Payload.Add("auth", auth);
                mainForm.Client.SendMessage(request.ToString());

                var response = Response.FromJson(await mainForm.Client.ReceiveMessage()) ?? new Response();

                if (response.IsStatusOk() )
                {
                    mainForm.User = new User(login, password);
                    MessageBox.Show(response.Message);
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Error: {response.Message}");
                }
            }
        }
    }
}
