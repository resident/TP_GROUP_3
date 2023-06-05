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
                Alert.Warning("You need provide login and password");
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
                    Alert.Successful(response.Message);
                    Close();
                }
                else
                {
                    Alert.Error(response.Message);
                }
            }
        }
    }
}
