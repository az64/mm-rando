using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMR.UI.Forms
{
    public partial class HudConfigForm : Form
    {
        public HudConfigForm()
        {
            InitializeComponent();

            btn_a.BackColor = Color.FromArgb(0x64, 0xC8, 0xFF);
            btn_b.BackColor = Color.FromArgb(0x64, 0xFF, 0x78);
            btn_c.BackColor = Color.FromArgb(0xFF, 0xF0, 0x00);
            btn_start.BackColor = Color.FromArgb(0xFF, 0x82, 0x3C);
            btn_clockemblem.BackColor = Color.FromArgb(0x00, 0xAA, 0x64);
            btn_inverted.BackColor = Color.FromArgb(0x64, 0xCD, 0xFF);
            btn_inverted2.BackColor = Color.FromArgb(0x00, 0x9B, 0xFF);
            btn_clockminutes.BackColor = Color.FromArgb(0xFF, 0xFF, 0x6E);
            btn_clockmoon.ForeColor = Color.FromArgb(0xFF, 0xFF, 0x37);
            btn_clocksun.ForeColor = Color.FromArgb(0xFF, 0x64, 0x6E);
            btn_hearts.ForeColor = Color.FromArgb(0xFF, 0x46, 0x32);
            btn_hearts2.ForeColor = Color.FromArgb(0xC8, 0x00, 0x00);
            btn_magic.BackColor = Color.FromArgb(0x00, 0xC8, 0x00);
            btn_chateau.BackColor = Color.FromArgb(0x00, 0x00, 0xC8);
            btn_map.BackColor = Color.FromArgb(0x00, 0xFF, 0xFF);
            btn_mapentrance.ForeColor = Color.FromArgb(0xC8, 0x00, 0x00);
            btn_mapplayer.ForeColor = Color.FromArgb(0xC8, 0xFF, 0x00);
            btn_wallet99.BackColor = Color.FromArgb(0xC8, 0xFF, 0x64);
            btn_wallet200.BackColor = Color.FromArgb(0xAA, 0xAA, 0xFF);
            btn_wallet500.BackColor = Color.FromArgb(0xFF, 0x69, 0x69);

        }
    }
}
