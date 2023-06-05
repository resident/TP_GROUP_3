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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Client
{
    public partial class BanUserForm : Form
    {
        private bool is_other_time_span_days = true;
        User user;

        public BanUserForm(User user)
        {
            InitializeComponent();

            this.user = user;
            tbSelectedUser.Text = user.Login;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void BanUser(DateTime ban)
        {           
            if (this.Owner.Owner is MainForm form)
            {                
                Request request = new Request("BanUser");
                request.Payload.Add("login", user.Login);
                request.Payload.Add("passwordHash", user.PasswordHash);
                request.Payload.Add("bannedExpiration", ban);

                form.Client.SendMessage(request.ToJson());

                var response = Response.FromJson(await form.Client.ReceiveMessage()) ?? new Response();
                
                if (response.IsStatusOk())
                {
                    Alert.Show($"User {user.Login} banned successfully");
                }
                else
                {
                    Alert.Error($"{response.Message}");
                }
            }          
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            if (rbOther.Checked)
            {           
                DateTime ban;

                if (is_other_time_span_days)
                {
                    ban = DateTime.Now.AddDays(int.Parse(tbOtherTimeSpan.Text));
                }
                else
                {
                    ban = DateTime.Now.AddSeconds(int.Parse(tbOtherTimeSpan.Text));
                }

                BanUser(ban);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                DateTime ban;

                if (rb45Sec.Checked) ban = DateTime.Now.AddSeconds(45);
                else if (rb5Min.Checked) ban = DateTime.Now.AddMinutes(5);
                else if (rb10Min.Checked) ban = DateTime.Now.AddMinutes(10);
                else if (rb15Min.Checked) ban = DateTime.Now.AddMinutes(15);
                else if (rb30Min.Checked) ban = DateTime.Now.AddMinutes(30);
                else if (rb1H.Checked) ban = DateTime.Now.AddHours(1);
                else if (rb12H.Checked) ban = DateTime.Now.AddHours(12);
                else if (rb1Day.Checked) ban = DateTime.Now.AddDays(1);
                else if (rb1Week.Checked) ban = DateTime.Now.AddDays(7);
                else if (rb1Month.Checked) ban = DateTime.Now.AddMonths(1);
                else if (rb3Month.Checked) ban = DateTime.Now.AddMonths(3);
                else if (rb6Month.Checked) ban = DateTime.Now.AddMonths(6);
                else if (rb1Year.Checked) ban = DateTime.Now.AddYears(1);
                else if (rb3Year.Checked) ban = DateTime.Now.AddYears(1);
                else ban = DateTime.Now.AddYears(300);
               
                BanUser(ban);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void RadioButtonChanged(object sender, EventArgs e)
        {
            btnBan.Enabled = true;
            tbOtherTimeSpan.Text = "";
            tbOtherTimeSpan.Enabled = false;
            btnOtherTimeDays.Enabled = false;
            btnOtherTimeSec.Enabled = false;
        }

        private void rbOther_CheckedChanged(object sender, EventArgs e)
        {
            btnBan.Enabled = false;
            tbOtherTimeSpan.Enabled = true;
            btnOtherTimeDays.Enabled = true;
        }

        private void btnOtherTimeDays_Click(object sender, EventArgs e)
        {
            is_other_time_span_days = true;
            btnOtherTimeDays.Enabled = false;
            btnOtherTimeSec.Enabled = true;
        }

        private void btnOtherTimeSec_Click(object sender, EventArgs e)
        {
            is_other_time_span_days = false;
            btnOtherTimeDays.Enabled = true;
            btnOtherTimeSec.Enabled = false;
        }

        private void tbOtherTimeSpan_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbOtherTimeSpan.Text))
            {
                try
                {
                    int x = int.Parse(tbOtherTimeSpan.Text);
                    btnBan.Enabled = true;
                }
                catch (Exception ex)
                {
                    tbOtherTimeSpan.Text = "";
                    btnBan.Enabled = false;
                }
            }
            else
            {
                tbOtherTimeSpan.Text = "";
                btnBan.Enabled = false;
            }
        }
    }
}
