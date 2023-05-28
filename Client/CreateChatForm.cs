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
    public partial class CreateChatForm : Form
    {
        public CreateChatForm()
        {
            InitializeComponent();
        }

        private void btnCreateChat_Click(object sender, EventArgs e)
        {
            if (this.Owner is MainForm mainForm)
            {
                mainForm.lbChats.Items.Add(tbChatTitle.Text);
            }

            this.Close();
        }
    }
}
