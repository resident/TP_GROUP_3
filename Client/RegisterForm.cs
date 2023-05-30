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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLogin.Text) || string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                MessageBox.Show("You need provide login and password");
                return;
            }

            if (this.Owner is MainForm mainForm)
            {
                var request = new Request("registration");
                var login = tbLogin.Text;
                var password = tbPassword.Text;
                var user = new User(login, password);
                request.Payload.Add("user", user);
                mainForm.Client.SendMessage(request.ToJson());

                var response = Response.FromJson(await mainForm.Client.ReceiveMessage()) ?? new Response();

                if (response.IsStatusOk())
                {
                    mainForm.User = user;
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
