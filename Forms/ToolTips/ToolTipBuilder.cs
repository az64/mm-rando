using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMRando.Forms.ToolTips
{
    public static class ToolTipBuilder
    {
        public static void SetToolTip(Control control, string text)
        {
            var toolTip = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip.ShowAlways = true;

            toolTip.SetToolTip(control, text);
        }
    }
}
