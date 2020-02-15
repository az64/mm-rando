using MMR.Randomizer.Asm;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MMR.UI.Forms
{
    public partial class HudConfigForm : Form
    {
        /// <summary>
        /// Dialog for selecting colors.
        /// </summary>
        ColorDialog ColorDialog { get; set; } = new ColorDialog();

        /// <summary>
        /// Default HUD colors.
        /// </summary>
        HudColors DefaultColors { get; set; } = new HudColors();

        public HudConfigForm()
        {
            InitializeComponent();
            InitializeColorDialog();
            InitializeContextMenu();
        }

        /// <summary>
        /// Initialize the <see cref="System.Windows.Forms.ColorDialog"/>.
        /// </summary>
        void InitializeColorDialog()
        {
            var dialog = this.ColorDialog;
            dialog.AllowFullOpen = true;
        }

        /// <summary>
        /// Update the current colors and show as a dialog.
        /// </summary>
        /// <param name="owner">Owner</param>
        /// <param name="config">Config</param>
        /// <returns>Result</returns>
        public DialogResult ShowDialog(IWin32Window owner, HudColorsConfig config)
        {
            FromColors(config.Colors);
            return ShowDialog(owner);
        }

        /// <summary>
        /// Update all component colors from <see cref="HudColors"/>.
        /// </summary>
        /// <param name="colors">Colors</param>
        void FromColors(HudColors colors)
        {
            btn_a.BackColor = colors.ButtonA;
            btn_b.BackColor = colors.ButtonB;
            btn_c.BackColor = colors.ButtonC;
            btn_start.BackColor = colors.ButtonStart;
            btn_clockemblem.BackColor = colors.ClockEmblem;
            btn_inverted.BackColor = colors.ClockEmblemInverted1;
            btn_inverted2.BackColor = colors.ClockEmblemInverted2;
            btn_clockminutes.BackColor = colors.ClockEmblemSun;
            btn_clockmoon.ForeColor = colors.ClockMoon;
            btn_clocksun.ForeColor = colors.ClockSun;
            btn_hearts.ForeColor = colors.Heart;
            btn_hearts2.ForeColor = colors.HeartDD;
            btn_magic.BackColor = colors.Magic;
            btn_chateau.BackColor = colors.MagicInf;
            btn_map.BackColor = colors.Map;
            btn_mapentrance.ForeColor = colors.MapEntranceCursor;
            btn_mapplayer.ForeColor = colors.MapPlayerCursor;
            btn_wallet99.BackColor = colors.RupeeIcon1;
            btn_wallet200.BackColor = colors.RupeeIcon2;
            btn_wallet500.BackColor = colors.RupeeIcon3;
        }

        /// <summary>
        /// Get all component colors as <see cref="HudColors"/>.
        /// </summary>
        /// <returns>HUD colors</returns>
        public HudColors ToColors()
        {
            var colors = new HudColors();
            colors.ButtonA = btn_a.BackColor;
            colors.ButtonB = btn_b.BackColor;
            colors.ButtonC = btn_c.BackColor;
            colors.ButtonStart = btn_start.BackColor;
            colors.ClockEmblem = btn_clockemblem.BackColor;
            colors.ClockEmblemInverted1 = btn_inverted.BackColor;
            colors.ClockEmblemInverted2 = btn_inverted2.BackColor;
            colors.ClockEmblemSun = btn_clockminutes.BackColor;
            colors.ClockMoon = btn_clockmoon.ForeColor;
            colors.ClockSun = btn_clocksun.ForeColor;
            colors.Heart = btn_hearts.ForeColor;
            colors.HeartDD = btn_hearts2.ForeColor;
            colors.Magic = btn_magic.BackColor;
            colors.MagicInf = btn_chateau.BackColor;
            colors.Map = btn_map.BackColor;
            colors.MapEntranceCursor = btn_mapentrance.ForeColor;
            colors.MapPlayerCursor = btn_mapplayer.ForeColor;
            colors.RupeeIcon1 = btn_wallet99.BackColor;
            colors.RupeeIcon2 = btn_wallet200.BackColor;
            colors.RupeeIcon3 = btn_wallet500.BackColor;
            return colors;
        }

        /// <summary>
        /// Show the <see cref="System.Windows.Forms.ColorDialog"/> to select the color for a specific <see cref="Component"/>.
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="isForeColor">True if ForeColor, false if BackColor</param>
        private void SelectColor(Control control, bool isForeColor = false)
        {
            var dialog = this.ColorDialog;
            dialog.Color = isForeColor ? control.ForeColor : control.BackColor;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                if (isForeColor)
                    control.ForeColor = dialog.Color;
                else
                    control.BackColor = dialog.Color;
            }
        }

        #region Context Menu

        /// <summary>
        /// Initialize the <see cref="ContextMenuStrip"/>.
        /// </summary>
        void InitializeContextMenu()
        {
            var menu = ctxtMenu;
            menu.Opening += new CancelEventHandler(ctxtMenu_Opening);

            var resetAllMenuItem = new ToolStripMenuItem("Reset &All Colors", null, ctxtMenu_ResetAllColors);
            menu.Items.Add(resetAllMenuItem);
        }

        void ctxtMenu_Opening(object sender, CancelEventArgs e)
        {
            // Todo: May use later for adding menu items for restoring default value of selected button
            e.Cancel = false;
        }

        void ctxtMenu_ResetAllColors(object sender, EventArgs e)
        {
            FromColors(DefaultColors);
        }

        #endregion

        #region Button Events

        private void btn_a_Click(object sender, EventArgs e)
        {
            SelectColor((Button)sender);
        }

        private void btn_b_Click(object sender, EventArgs e)
        {
            SelectColor((Button)sender);
        }

        private void btn_c_Click(object sender, EventArgs e)
        {
            SelectColor((Button)sender);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            SelectColor((Button)sender);
        }

        private void btn_clockemblem_Click(object sender, EventArgs e)
        {
            SelectColor((Button)sender);
        }

        private void btn_inverted_Click(object sender, EventArgs e)
        {
            SelectColor((Button)sender);
        }

        private void btn_inverted2_Click(object sender, EventArgs e)
        {
            SelectColor((Button)sender);
        }

        private void btn_clockminutes_Click(object sender, EventArgs e)
        {
            SelectColor((Button)sender);
        }

        private void btn_clockmoon_Click(object sender, EventArgs e)
        {
            SelectColor((Button)sender, true);
        }

        private void btn_clocksun_Click(object sender, EventArgs e)
        {
            SelectColor((Button)sender, true);
        }

        private void btn_hearts_Click(object sender, EventArgs e)
        {
            SelectColor((Button)sender, true);
        }

        private void btn_hearts2_Click(object sender, EventArgs e)
        {
            SelectColor((Button)sender, true);
        }

        private void btn_magic_Click(object sender, EventArgs e)
        {
            SelectColor((Button)sender);
        }

        private void btn_chateau_Click(object sender, EventArgs e)
        {
            SelectColor((Button)sender);
        }

        private void btn_map_Click(object sender, EventArgs e)
        {
            SelectColor((Button)sender);
        }

        private void btn_mapentrance_Click(object sender, EventArgs e)
        {
            SelectColor((Button)sender, true);
        }

        private void btn_mapplayer_Click(object sender, EventArgs e)
        {
            SelectColor((Button)sender, true);
        }

        private void btn_wallet99_Click(object sender, EventArgs e)
        {
            SelectColor((Button)sender);
        }

        private void btn_wallet200_Click(object sender, EventArgs e)
        {
            SelectColor((Button)sender);
        }

        private void btn_wallet500_Click(object sender, EventArgs e)
        {
            SelectColor((Button)sender);
        }

        #endregion
    }
}
