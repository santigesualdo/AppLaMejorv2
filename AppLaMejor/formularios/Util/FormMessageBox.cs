using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AppLaMejor.formularios.Util
{
    public partial class FormMessageBox : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public FormMessageBox()
        {
            InitializeComponent();

            AddMouseMoveHandler(this);

            ApplicationLookAndFeel.ApplyThemeToAll(this);
            ApplicationLookAndFeel.ApplyTheme(this.tableBotones);
        }
        
        private void AddMouseMoveHandler(Control c)
        {
            c.MouseMove += MouseMoveHandler;
            if (c.Controls.Count > 0)
            {
                foreach (Control ct in c.Controls)
                    AddMouseMoveHandler(ct);
            }
        }

        private void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        
        private void bAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            Label label = this.messageBoxLabel;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public DialogResult ShowErrorDialog(string v)
        {
            messageBoxLabel.Text = v;
            bAceptar.Visible = false;
            bCancelar.Visible =false;
            bOk.Visible = true;
            
            
            return ShowDialog();
        }

        public Boolean ShowConfirmationDialog(string v)
        {
            try
            {
                messageBoxLabel.Text = v;
                bOk.Visible = false;
                bAceptar.Visible = true;
                bCancelar.Visible = true;
                return ShowDialog() == DialogResult.OK;
            }
            catch(Exception e)
            {
                return false;
            }

        }



    }
}
