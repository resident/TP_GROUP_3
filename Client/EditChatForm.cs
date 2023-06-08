using Collections;
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
            if (this.Owner is not MainForm {CurrentChat.Users: not null} mainForm) return;

            lbUsers.DataSource = mainForm.RegisteredUsers;
            tbChatTitle.Text = mainForm.CurrentChat.Title;

            lbUsers.SelectedItems.Clear();
            foreach (var user in mainForm.CurrentChat.Users)
            {
                if (lbUsers.Items.Contains(user))
                    lbUsers.SelectedItem = user;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Owner is not MainForm {CurrentChat: not null} mainForm) return;

            var users = lbUsers.SelectedItems.Cast<User>().ToList();

            var request = new Request("UpdateChat");

            mainForm.CurrentChat.Users.Clear();
            mainForm.CurrentChat.Users.AddUsers(users);
            mainForm.CurrentChat.Title = tbChatTitle.Text;
            var chat = mainForm.CurrentChat.Clone();

            request.Payload.Add("newChat", chat);

            mainForm.Client.SendMessage(request.ToJson());

            var response = Response.FromJson(await mainForm.Client.ReceiveMessage()) ?? new Response();


            if (response.IsStatusOk())
            {
                this.Close();
            }
            else
                Alert.Error(response.Message);
        }
    }
}
