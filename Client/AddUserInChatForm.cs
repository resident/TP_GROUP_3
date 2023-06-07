using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class AddUserInChatForm : Form
    {
        public AddUserInChatForm()
        {
            InitializeComponent();
        }

        private void AddUserInChatForm_Load(object sender, EventArgs e)
        {
            if (this.Owner.Owner is MainForm mainForm)
            {
                lbUsers.DataSource = mainForm.RegisteredUsers;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedItems.Count == 0) return;

            if (this.Owner.Owner is MainForm mainForm)
            {
                if (null == mainForm.CurrentChat) return;

                List<User> users = lbUsers.SelectedItems.Cast<User>().ToList();

                var request = new Request("AddUserInChat");

                request.Payload.Add("users", users);
                request.Payload.Add("chat", mainForm.CurrentChat);

                mainForm.Client.SendMessage(request.ToJson());

                var response = Response.FromJson(await mainForm.Client.ReceiveMessage()) ?? new Response();


                if (response.IsStatusOk())
                {
                    mainForm.CurrentChat.Users.AddUsers(users);
                    lbUsers.DataSource = mainForm.RegisteredUsers;
                }
                else
                    Alert.Error(response.Message);
            }
        }
    }
}
