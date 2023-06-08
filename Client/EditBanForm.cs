using Collections;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class EditBanForm : Form
    {
        private bool _isOtherTimeSpanDays;
        private readonly UsersCollection _users;

        public EditBanForm(UsersCollection users)
        {
            InitializeComponent();
            _users = users;

            lbUsers.DataSource = _users;
        }

        private DateTime GetNewExpirationDateSetNew()
        {
            DateTime banExpiration;

            if (rbOther.Checked)
            {
                var timeSpan = int.Parse(tbOtherTimeSpan.Text);

                banExpiration = _isOtherTimeSpanDays ? DateTimeSync.UtcNow.AddDays(timeSpan) : DateTimeSync.UtcNow.AddSeconds(timeSpan);
            }
            else
            {
                if (rb45Sec.Checked) banExpiration = DateTimeSync.UtcNow.AddSeconds(45);
                else if (rb5Min.Checked) banExpiration = DateTimeSync.UtcNow.AddMinutes(5);
                else if (rb10Min.Checked) banExpiration = DateTimeSync.UtcNow.AddMinutes(10);
                else if (rb15Min.Checked) banExpiration = DateTimeSync.UtcNow.AddMinutes(15);
                else if (rb30Min.Checked) banExpiration = DateTimeSync.UtcNow.AddMinutes(30);
                else if (rb1H.Checked) banExpiration = DateTimeSync.UtcNow.AddHours(1);
                else if (rb12H.Checked) banExpiration = DateTimeSync.UtcNow.AddHours(12);
                else if (rb1Day.Checked) banExpiration = DateTimeSync.UtcNow.AddDays(1);
                else if (rb1Week.Checked) banExpiration = DateTimeSync.UtcNow.AddDays(7);
                else if (rb1Month.Checked) banExpiration = DateTimeSync.UtcNow.AddMonths(1);
                else if (rb3Month.Checked) banExpiration = DateTimeSync.UtcNow.AddMonths(3);
                else if (rb6Month.Checked) banExpiration = DateTimeSync.UtcNow.AddMonths(6);
                else if (rb1Year.Checked) banExpiration = DateTimeSync.UtcNow.AddYears(1);
                else if (rb3Year.Checked) banExpiration = DateTimeSync.UtcNow.AddYears(1);
                else banExpiration = DateTime.MaxValue;
            }

            return banExpiration;
        }

        private long GetAddToBan()
        {
            long addToBan;

            if (rbAddOrther.Checked)
            {
                var timeSpan = int.Parse(tbAddOtherTimeSpan.Text);

                addToBan = _isOtherTimeSpanDays ? long.Parse(tbAddOtherTimeSpan.Text) * 86400 : long.Parse(tbAddOtherTimeSpan.Text);
            }
            else
            {
                if (rbAdd45Sec.Checked) addToBan = 45;
                else if (rbAdd5Min.Checked) addToBan = 300;
                else if (rbAdd10Min.Checked) addToBan = 600;
                else if (rbAdd15Min.Checked) addToBan = 900;
                else if (rbAdd30Min.Checked) addToBan = 1800;
                else if (rbAdd1H.Checked) addToBan = 3600;
                else if (rbAdd12H.Checked) addToBan = 43200;
                else if (rbAdd1Day.Checked) addToBan = 86400;
                else if (rbAdd1Week.Checked) addToBan = 604800;
                else if (rbAdd1Month.Checked) addToBan = 2592000;
                else if (rbAdd3Month.Checked) addToBan = 7776000;
                else if (rbAdd6Month.Checked) addToBan = 15552000;
                else if (rbAdd1Year.Checked) addToBan = 31104000;
                else addToBan = 93312000;
            }

            return addToBan;
        }

        private async void btnApply_Click(object sender, EventArgs e)
        {
            if (this.Owner?.Owner is not MainForm form) return;

            if (rbAddToCurrent.Checked)
            {
                var addToBan = GetAddToBan();

                if (addToBan < 0)
                {
                    Alert.Error("Other time span value is too big");
                    return;
                }

                var banExpirations = new List<DateTime>();

                for (int i = 0; i < _users.Count; i++)
                {
                    banExpirations.Add(_users[i].BanExpiration.AddSeconds(addToBan));
                }

                var request = new Request("EditUsersBan");

                request.Payload.Add("users", _users);
                request.Payload.Add("banExpirations", banExpirations);

                form.Client.SendMessage(request.ToJson());

                var response = Response.FromJson(await form.Client.ReceiveMessage()) ?? new Response();

                if (response.IsStatusOk())
                    Alert.Show(response.Message);
                else
                    Alert.Error(response.Message);

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                var newBanExpirationDate = GetNewExpirationDateSetNew();

                var request = new Request("BanUsers");

                request.Payload.Add("users", _users);
                request.Payload.Add("banExpiration", newBanExpirationDate);

                form.Client.SendMessage(request.ToJson());

                var response = Response.FromJson(await form.Client.ReceiveMessage()) ?? new Response();

                if (response.IsStatusOk())
                    Alert.Show(response.Message);
                else
                    Alert.Error(response.Message);

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void rbAddToCurrent_Click(object sender, EventArgs e)
        {
            if (rbAddToCurrent.Checked)
            {
                gbAddToCurrent.Enabled = true;
                gbSetNew.Enabled = false;

                rbSetNew.Checked = false;
            }
            else
            {
                gbAddToCurrent.Enabled = false;
                gbSetNew.Enabled = true;

                rbSetNew.Checked = true;
            }
        }

        private void rbSetNew_Click(object sender, EventArgs e)
        {
            if (rbSetNew.Checked)
            {
                gbAddToCurrent.Enabled = false;
                gbSetNew.Enabled = true;

                rbAddToCurrent.Checked = false;
            }
            else
            {
                gbAddToCurrent.Enabled = true;
                gbSetNew.Enabled = false;

                rbAddToCurrent.Checked = true;
            }
        }

        private void btnOtherTimeDays_Click(object sender, EventArgs e)
        {
            _isOtherTimeSpanDays = true;
            btnOtherTimeDays.Enabled = false;
            btnOtherTimeSec.Enabled = true;
        }

        private void btnOtherTimeSec_Click(object sender, EventArgs e)
        {
            _isOtherTimeSpanDays = false;
            btnOtherTimeDays.Enabled = true;
            btnOtherTimeSec.Enabled = false;
        }

        private void btnAddOtherTimeDays_Click(object sender, EventArgs e)
        {
            _isOtherTimeSpanDays = true;
            btnAddOtherTimeDays.Enabled = false;
            btnAddOtherTimeSec.Enabled = true;
        }

        private void btnAddOtherTimeSec_Click(object sender, EventArgs e)
        {
            _isOtherTimeSpanDays = false;
            btnAddOtherTimeDays.Enabled = true;
            btnAddOtherTimeSec.Enabled = false;
        }

        private void RadioButtonChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            tbOtherTimeSpan.Text = "";
            tbOtherTimeSpan.Enabled = false;
            btnOtherTimeDays.Enabled = false;
            btnOtherTimeSec.Enabled = false;
        }

        private void RadioButtonAddChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            tbAddOtherTimeSpan.Text = "";
            tbAddOtherTimeSpan.Enabled = false;
            btnAddOtherTimeDays.Enabled = false;
            btnAddOtherTimeSec.Enabled = false;
        }

        private void rbAddOrther_CheckedChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = false;
            tbAddOtherTimeSpan.Enabled = true;
            btnAddOtherTimeDays.Enabled = true;
        }

        private void rbOther_CheckedChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = false;
            tbOtherTimeSpan.Enabled = true;
            btnOtherTimeDays.Enabled = true;
        }

        private void tbAddOtherTimeSpan_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbAddOtherTimeSpan.Text))
            {
                try
                {
                    _ = int.Parse(tbAddOtherTimeSpan.Text);
                    btnApply.Enabled = true;
                }
                catch
                {
                    tbAddOtherTimeSpan.Text = "";
                    btnApply.Enabled = false;
                }
            }
            else
            {
                tbAddOtherTimeSpan.Text = "";
                btnApply.Enabled = false;
            }
        }

        private void tbOtherTimeSpan_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbOtherTimeSpan.Text))
            {
                try
                {
                    _ = int.Parse(tbOtherTimeSpan.Text);
                    btnApply.Enabled = true;
                }
                catch
                {
                    tbOtherTimeSpan.Text = "";
                    btnApply.Enabled = false;
                }
            }
            else
            {
                tbOtherTimeSpan.Text = "";

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
