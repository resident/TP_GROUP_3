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

        private void btnCreateChat_Click(object sender, EventArgs e)
        {
            if (this.Owner is MainForm mainForm)
            {
                var users = lbUsers.SelectedItems.Cast<User>().ToList();
                var chat = new Chat(tbChatTitle.Text, users);

                mainForm.Chats.Add(chat);
            }

            this.Close();
        }
    }
}
