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
    public partial class EditChatForm : Form
    {
        public EditChatForm()
        {
            InitializeComponent();
        }

        private void EditChatForm_Load(object sender, EventArgs e)
        {
            if (this.Owner is MainForm mainForm)
            {
                lbUsers.DataSource = mainForm.CurrentChat?.Users;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedItems.Count == 0) return;

            if (this.Owner is MainForm mainForm)
            {
                if (null == mainForm.CurrentChat) return;

                List<User> users = lbUsers.SelectedItems.Cast<User>().ToList();

                var request = new Request("RemoveUserInChat");

                request.Payload.Add("users", users!);
                request.Payload.Add("chat", mainForm.CurrentChat);

                mainForm.Client.SendMessage(request.ToJson());

                var response = Response.FromJson(await mainForm.Client.ReceiveMessage()) ?? new Response();


                if (response.IsStatusOk())
                {
                    foreach (var user in users)
                    {
                        mainForm.CurrentChat.Users.RemoveById(user.Id);
                        // для обновления списка в lb, иначе очень странно работает
                        lbUsers.DataSource = mainForm.CurrentChat.Users;
                    }

                }
                else
                    Alert.Error(response.Message);

                // lbUsers.DataSource = mainForm.CurrentChat.Users;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new AddUserInChatForm();

            form.Owner = this;

            form.ShowDialog();

            // для обновления списка в lb, иначе очень странно работает
            if (this.Owner is MainForm mainForm)
            {
                lbUsers.DataSource = mainForm.CurrentChat?.Users;
            }
        }
    }
}
