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
        public static int TIME_SHORT = 20;
        public static int TIME_LONG = 40;
        public static int TIME_FOREVER = 0;

        public static int currentTimeMode = 0;


        static Timer _timer;
        public static int tCount = 0;
        public static ToolStripStatusLabel tssl;
        public static int tMax;
        public static int r, g, b;
        public static int targetFadeOutR, targetFadeOutG, targetFadeOutB;
        public static int targetFadeInR, targetFadeInG, targetFadeInB;
        public static int startR, startG, startB;
        public static bool mVisible = false;

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
        public static void TStartFade(string mensaje, StatusStrip ss, ToolStripStatusLabel label, int timeMode)
        {
            currentTimeMode = timeMode;

            mVisible = false;

            r = label.BackColor.R;
            g = label.BackColor.G;
            b = label.BackColor.B;

            targetFadeOutR = label.BackColor.R;
            targetFadeOutG = label.BackColor.G;
            targetFadeOutB = label.BackColor.B;

            targetFadeInR = label.ForeColor.R;
            targetFadeInG = label.ForeColor.G;
            targetFadeInB = label.ForeColor.B;

            tssl = label;
            tssl.Text= mensaje;
            tssl.ForeColor = label.BackColor;
            tCount = 0;

            if (currentTimeMode.Equals(TIME_SHORT))
            {
                tMax = 20;
            }
            else if(currentTimeMode.Equals(TIME_LONG))
            {
                tMax = 40;
            }
            else if (currentTimeMode.Equals(TIME_FOREVER))
            {
                tMax = 0;
            }
            
            tssl = label;
            _timer = new Timer();
            _timer.Interval = 5;
            _timer.Tick += _timer_Elapsed_fadeInFadeOut;
            _timer.Start();
        }

        public static void TStaticMessage(string mensaje, StatusStrip ss, ToolStripStatusLabel label)
        {
            label.Text = mensaje;
            tssl = label;
        }

        public static void TStop()
        {
            _timer.Stop();
        }

        private static void _timer_Elapsed_fadeInFadeOut(object sender, EventArgs e)
        {
            if (!tCount.Equals(-1))
            {
                if (!mVisible)
                    fadeIn();
                else
                {
                    if (!tMax.Equals(0))
                    {
                        if (tCount < tMax)
                        {
                            tCount++;
                        }
                        else
                        {
                            fadeOut();
                        }
                    }
                }
            }   
        }

        private static void fadeIn()
        {
            if (r < targetFadeInR) r++; // increase r value with each tick
            else if (r > targetFadeInR) r--;
            if (g > targetFadeInG) g--; // decrease g value with each tick
            else if (g < targetFadeInG) g++;
            if (b > targetFadeInB) b--; // decrease b value with each tick
            else if (b < targetFadeInB) b++;
            tssl.ForeColor = Color.FromArgb(255, r, g, b);
            if (r == targetFadeInR && g == targetFadeInG && b == targetFadeInB) // arrived at target values
            {
                // fade in complete
                mVisible = true;

                tssl.ForeColor = Color.FromArgb(255, r, g, b);

                tCount = 0;
                
                targetFadeOutR = tssl.BackColor.R;
                targetFadeOutG = tssl.BackColor.G;
                targetFadeOutB = tssl.BackColor.B;
            }
        }
        
        private static void fadeOut()
        {
            // objetivo: que todo lo rgb del color tienda al targetRgb. 
            // TargetRgb es el backColor del statusStrip

            if (r < targetFadeOutR) r++; // increase r value with each tick
            else if (r > targetFadeOutR) r--;
            if (g > targetFadeOutG) g--; // decrease g value with each tick
            else if (g < targetFadeOutG) g++;
            if (b > targetFadeOutB) b--; // decrease b value with each tick
            else if (b < targetFadeOutB) b++;
            tssl.ForeColor = Color.FromArgb(255, r, g, b);
            if (r == targetFadeOutR && g == targetFadeOutG && b == targetFadeOutB) // arrived at target values
            {
                EndTimerAndResetValues();
            }
        }

        public static void EndTimerAndResetValues()
        {
            if (!tCount.Equals(-1))
            {
                tssl.ForeColor = Color.FromArgb(255, targetFadeInR, targetFadeInG, targetFadeInB);
                tssl.Text = string.Empty;
                mVisible = true;
                _timer.Stop();
                _timer.Dispose();
                tCount = -1;
                _timer.Tick -= _timer_Elapsed_fadeInFadeOut;
            }

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

