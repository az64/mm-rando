using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MMRando
{
    public partial class fAbout : Form
    {
        public fAbout()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/8qbreUM");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void discordLabelText_Click(object sender, EventArgs e)
        {

        }
    }
}
