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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            tbServerIpAddress.Text = Settings.Get<string>("server_ip_address");
            tbServerPort.Text = Settings.Get<int>("server_port").ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Settings.Set("server_ip_address", tbServerIpAddress.Text);
            Settings.Set("server_port", int.Parse(tbServerPort.Text));
            Settings.Save();
            Close();
        }
    }
}
