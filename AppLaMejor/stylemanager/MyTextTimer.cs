using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace AppLaMejor.stylemanager
{
    public static class MyTextTimer
    {

        static Timer _timer;
        public static int tCount = 0;
        public static ToolStripStatusLabel tssl;
        public static int tMax;
        public static void TStart(string mensaje, StatusStrip ss , ToolStripStatusLabel label )
        {
            label.Text = mensaje;
            tCount = 0;
            tMax = 9;
            tssl = label;
            _timer = new Timer();
            _timer.Interval = 300;
            _timer.Tick += _timer_Elapsed;
            _timer.Start();
        }

        public static void TStop()
        {
            _timer.Stop();
        }

        private static void _timer_Elapsed(object sender, EventArgs e)
        {
            tCount++;
            if (tCount < tMax)
            {
                if ((tCount % 2) == 0)
                    tssl.ForeColor = StyleManager.Instance().GetCurrentStyle().TextColor;
                else
                    tssl.ForeColor = StyleManager.Instance().GetCurrentStyle().BackColor;
            }
            else
            {
                tssl.Visible = false;
            }
        }
    }
}

