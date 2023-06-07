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
            if (this.Owner is MainForm mainForm)
            {
                lbUsers.DataSource = mainForm.RegisteredUsers;
                foreach (var user in mainForm.CurrentChat.Users) 
                {
                    lbUsers.Items.Contains(user);
                    lbUsers.SelectedItem = user;
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedItems.Count == 0) return;

            if (this.Owner is MainForm mainForm)
            {
                if (null == mainForm.CurrentChat) return;

                List<User> users = lbUsers.SelectedItems.Cast<User>().ToList();
                UsersCollection usersCollection = new UsersCollection();
                usersCollection.AddUsers(users);

                Chat chat = new Chat(tbChatTitle.Text, usersCollection, mainForm.CurrentChat.Messages);

                var request = new Request("UpdateChat");

                request.Payload.Add("newChat", chat);
                request.Payload.Add("oldChat", mainForm.CurrentChat);

                mainForm.Client.SendMessage(request.ToJson());

                var response = Response.FromJson(await mainForm.Client.ReceiveMessage()) ?? new Response();


                if (response.IsStatusOk())
                {
                    mainForm.Chats.RemoveById(mainForm.CurrentChat.Id);
                    mainForm.Chats.Add(chat);
                    mainForm.CurrentChat = chat;
                    lbUsers.DataSource = mainForm.RegisteredUsers;

                }
                else
                    Alert.Error(response.Message);
            }
        }
    }
}
