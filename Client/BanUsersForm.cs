﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Collections;
using Shared;

namespace Client
{
    public partial class BanUsersForm : Form
    {
        private bool _isOtherTimeSpanDays;
        private readonly UsersCollection _users;

        public BanUsersForm(UsersCollection users)
        {
            InitializeComponent();

            _users = users;

            lbUsers.DataSource = _users;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private async void BanUsers(DateTime banExpiration)
        {
            if (this.Owner?.Owner is not MainForm mainForm) return;

            var request = new Request("BanUsers");

            request.Payload.Add("users", _users);
            request.Payload.Add("banExpiration", banExpiration);

            mainForm.Client.SendMessage(request.ToJson());

            var response = Response.FromJson(await mainForm.Client.ReceiveMessage()) ?? new Response();

            if (response.IsStatusOk())
                Alert.Show(response.Message);
            else
                Alert.Error(response.Message);
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            DateTime banExpiration;

            if (rbOther.Checked)
            {
                var timeSpan = int.Parse(tbOtherTimeSpan.Text);

                banExpiration = _isOtherTimeSpanDays ? DateTimeSync.UtcNow.AddDays(timeSpan) : DateTimeSync.UtcNow.AddSeconds(timeSpan);

                BanUsers(banExpiration);

                DialogResult = DialogResult.OK;
                Close();
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

                BanUsers(banExpiration);

                DialogResult = DialogResult.OK;
                Close();
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

        private void tbOtherTimeSpan_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbOtherTimeSpan.Text))
            {
                try
                {
                    _ = int.Parse(tbOtherTimeSpan.Text);
                    btnBan.Enabled = true;
                }
                catch
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
