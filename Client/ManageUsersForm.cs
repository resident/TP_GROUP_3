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
    public partial class ManageUsersForm : Form
    {
        public ManageUsersForm()
        {
            InitializeComponent();
        }

        private void ManageUsersForm_Load(object sender, EventArgs e)
        {
            if (this.Owner is MainForm mainForm)
            {
                lbUsers.DataSource = mainForm.RegisteredUsers;
            }
        }

        private async void btnApprove_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedItems.Count == 0) return;

            if (this.Owner is MainForm mainForm)
            {
                var request = new Request("ActivateUsers");

                request.Payload.Add("users", lbUsers.SelectedItems);

                mainForm.Client.SendMessage(request.ToJson());

                var response = Response.FromJson(await mainForm.Client.ReceiveMessage()) ?? new Response();

                if (response.IsStatusOk())
                    Alert.Successful(response.Message);
                else
                    Alert.Error(response.Message);
            }
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedItems.Count == 0) return;

            if (this.Owner is MainForm mainForm)
            {
                var request = new Request("RemoveUsers");

                request.Payload.Add("users", lbUsers.SelectedItems);

                mainForm.Client.SendMessage(request.ToJson());

                var response = Response.FromJson(await mainForm.Client.ReceiveMessage()) ?? new Response();

                if (response.IsStatusOk())
                    Alert.Successful(response.Message);
                else
                    Alert.Error(response.Message);
            }
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            if (this.Owner is MainForm mainForm)
            {
                if (!mainForm.RegisteredUsers[lbUsers.SelectedIndex].IsBanned)
                {
                    BanUserForm ban_form = new BanUserForm(mainForm.RegisteredUsers[lbUsers.SelectedIndex]);
                    ban_form.Owner = this;
                    ban_form.ShowDialog();
                }
                else
                {
                    Alert.Error($"This user are already banned");
                }
            }
        }

        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Owner is MainForm mainForm)
            {
                if (mainForm.RegisteredUsers[lbUsers.SelectedIndex].IsAdmin)
                {
                    btnBan.Enabled = false;
                }
                else
                {
                    btnBan.Enabled = true;
                }
            }
        }
    }
}
