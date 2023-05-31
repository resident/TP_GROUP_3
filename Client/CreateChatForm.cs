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
    public partial class CreateChatForm : Form
    {
        public CreateChatForm()
        {
            InitializeComponent();
        }

        private void CreateChatForm_Load(object sender, EventArgs e)
        {
            if (this.Owner is MainForm mainForm)
            {
                lbUsers.DataSource = mainForm.RegisteredUsers;
            }
        }

        private async void btnCreateChat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbChatTitle.Text))
            {
                Alert.Warning("You need provide chat title");
                return;
            }

            if (this.Owner is MainForm mainForm)
            {
                var request = new Request("CreateChat");
                var users = (from KeyValuePair<User, Dictionary<string, object>> pair in lbUsers.SelectedItems select pair.Key).ToList();
                var chat = new Chat(tbChatTitle.Text, users);

                request.Payload.Add("chat", chat);

                mainForm.Client.SendMessage(request.ToJson());

                var response = Response.FromJson(await mainForm.Client.ReceiveMessage()) ?? new Response();

                if (response.IsStatusOk())
                {
                    mainForm.Chats.Add(chat);
                    
                    Close();
                }
                else
                {
                    Alert.Error(response.Error);
                    return;
                }
            }

            this.Close();
        }
    }
}
