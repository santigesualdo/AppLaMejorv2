using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppLaMejor.formularios.Util
{
    public partial class FormMessageBox : Form
    {
        public FormMessageBox()
        {
            InitializeComponent();
            
            ApplicationLookAndFeel.ApplyThemeToAll(this);
            ApplicationLookAndFeel.ApplyTheme(this.tableBotones);
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
