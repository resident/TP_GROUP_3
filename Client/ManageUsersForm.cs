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
using Collections;

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
            if (this.Owner is not MainForm mainForm) return;

            lbUsers.DataSource = mainForm.RegisteredUsers;
            lbUsers.ClearSelected();
        }

        private async void btnApprove_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedItems.Count == 0 || this.Owner is not MainForm mainForm) return;

            var request = new Request("ActivateUsers");

            request.Payload.Add("users", lbUsers.SelectedItems);

            mainForm.Client.SendMessage(request.ToJson());

            var response = Response.FromJson(await mainForm.Client.ReceiveMessage()) ?? new Response();

            if (response.IsStatusOk())
                Alert.Successful(response.Message);
            else
                Alert.Error(response.Message);
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedItems.Count == 0 || this.Owner is not MainForm mainForm) return;

            var request = new Request("RemoveUsers");

            request.Payload.Add("users", lbUsers.SelectedItems);

            mainForm.Client.SendMessage(request.ToJson());

            var response = Response.FromJson(await mainForm.Client.ReceiveMessage()) ?? new Response();

            if (response.IsStatusOk())
                Alert.Successful(response.Message);
            else
                Alert.Error(response.Message);
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedItems.Count == 0 || this.Owner is not MainForm) return;

            var users = new UsersCollection();

            users.AddUsers(lbUsers.SelectedItems.Cast<User>());

            var banUsersForm = new BanUsersForm(users);

            banUsersForm.Owner = this;
            banUsersForm.ShowDialog();
        }

        private async void btnUnban_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedItems.Count == 0 || this.Owner is not MainForm form) return;

            var users = new UsersCollection();
            users.AddUsers(lbUsers.SelectedItems.Cast<User>());

            var request = new Request("UnbanUsers");
            request.Payload.Add("users", users);
            form.Client.SendMessage(request.ToJson());

            var response = Response.FromJson(await form.Client.ReceiveMessage()) ?? new Response();

            if (response.IsStatusOk())
                Alert.Show(response.Message);
            else
                Alert.Error(response.Message);
        }

        private void btnEditBan_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedItems.Count == 0 || this.Owner is not MainForm form) return;

            bool isEveryOneBanned(UsersCollection users)
            {
                bool ok = true;

                foreach (var user in users)
                {
                    if (!user.IsBanned)
                    {
                        ok = false;
                        break;
                    }
                }

                return ok;
            }

            var users = new UsersCollection();

            users.AddUsers(lbUsers.SelectedItems.Cast<User>());

            if (isEveryOneBanned(users))
            {
                var editUsersBanForm = new EditBanForm(users);

                editUsersBanForm.Owner = this;
                editUsersBanForm.ShowDialog();
            }
            else
            {
                Alert.Error("Not all selected users are banned");
            }
        }
    }
}
