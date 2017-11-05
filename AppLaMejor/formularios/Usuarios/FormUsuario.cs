using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppLaMejor.datamanager;
using MySql.Data.MySqlClient;


namespace AppLaMejor.formularios
{
    public partial class FormUsuario : Form
    {

        public FormUsuario()
        {
            InitializeComponent();
            
            //CenterPanel
            loginPanel.Location = new Point(this.ClientSize.Width / 2 - loginPanel.Size.Width / 2,this.ClientSize.Height / 2 - loginPanel.Size.Height / 2);
            loginPanel.Anchor = AnchorStyles.None;

            ApplicationLookAndFeel.ApplyThemeToAll(this);
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string query = QueryManager.Instance().GetUserLogin(textUser.Text, textPass.Text);
                DataTable dtTabla = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, query);

                if (dtTabla.Rows.Count > 0){
                    //MessageBox.Show("Usuario : '" + dtTabla.Rows[0].ItemArray[1].ToString() + "' ingreso con exito");
                    int userIdLogueado = (int)dtTabla.Rows[0].ItemArray[0];
                    FormInicio formInicio = new FormInicio();
                    formInicio.userIdLogueado = userIdLogueado;
                    formInicio.Show();
                }
                else
                    MessageBox.Show("Usuario : '" + dtTabla.Rows[0].ItemArray[1].ToString() + "' ingreso con exito");
            }
            catch (Exception E)
            {
                MessageBox.Show("Ocurrio un error. Motivo: " + E.Message);
            }
        }

        private void FormUsuario_Activated(object sender, EventArgs e)
        {
            if (!ConnecionBD.Instance().IsConnect())
            {
                Application.Exit();
            }
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                bAceptar_Click(sender, e);
            }
        }



    }
}
