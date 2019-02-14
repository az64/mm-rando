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
            lVer.Text = AssemblyVersion;
        }

        public string AssemblyVersion
        {
            get
            {
                Version v = Assembly.GetExecutingAssembly().GetName().Version;
                return String.Format("v{0}.{1}", v.Major, v.Minor);
            }
        }
    }
}
