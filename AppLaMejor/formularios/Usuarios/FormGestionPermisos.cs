using AppLaMejor.controlmanager;
using AppLaMejor.entidades;
using AppLaMejor.formularios.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppLaMejor.formularios.Usuarios
{
    public partial class FormGestionPermisos : Form
    {
        int idUsuarioSelected;

        public FormGestionPermisos(int idUsuario)
        {
            InitializeComponent();
            ApplicationLookAndFeel.ApplyThemeToAll(this);

            idUsuarioSelected = idUsuario;

            Cargar();
        }

        private void Cargar()
        {
            Usuario user = FuncionesUsuarios.ObtenerUsuario(idUsuarioSelected);
            labelUserName.Text += user.UserName + " (" + user.Nombre + ")";

            // Cargar permisos de Usuario
            List<Modulo> listModulosUser = FuncionesUsuarios.ObtenerModulosPorUsuario(idUsuarioSelected);
            List<Modulo> listModulosFaltantesUser = FuncionesUsuarios.ObtenerModulosFaltantesPorUsuario(idUsuarioSelected);


            listBoxPermisosFaltantes.DataSource = listModulosFaltantesUser;
            listBoxPermisosFaltantes.DisplayMember = "Descripcion";
            listBoxPermisosFaltantes.ValueMember = "Id";
            listBoxPermisosFaltantes.SelectedIndex = -1;
            listBoxPermisosFaltantes.SelectedIndexChanged += ListBoxPermisosFaltantes_SelectedIndexChanged;

            listBoxPermisosActuales.DataSource = listModulosUser;
            listBoxPermisosActuales.DisplayMember = "Descripcion";
            listBoxPermisosActuales.ValueMember = "Id";
            listBoxPermisosActuales.SelectedIndex = -1;
            listBoxPermisosActuales.SelectedIndexChanged += ListBoxPermisosActuales_SelectedIndexChanged;

        }

        private void ListBoxPermisosActuales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!listBoxPermisosFaltantes.SelectedIndex.Equals(-1))
            {
                int aux = listBoxPermisosActuales.SelectedIndex;
                listBoxPermisosFaltantes.SelectedIndex = -1;
                listBoxPermisosActuales.SelectedIndex = aux;
                butAgregarPermisoSelec.Enabled = false;
            }


            if (listBoxPermisosActuales.SelectedIndex.Equals(-1))
            {
                butAgregarPermisoSelec.Enabled = true;
            }
            
                
        }

        private void ListBoxPermisosFaltantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!listBoxPermisosActuales.SelectedIndex.Equals(-1))
            {
                int aux = listBoxPermisosFaltantes.SelectedIndex;
                listBoxPermisosActuales.SelectedIndex = -1;
                listBoxPermisosFaltantes.SelectedIndex = aux;
                bRemovePermisoSelec.Enabled = false;
            }

            if (listBoxPermisosFaltantes.SelectedIndex.Equals(-1))
            {
                bRemovePermisoSelec.Enabled = true;
            }
        }

        private void butAgregarPermisoSelec_Click(object sender, EventArgs e)
        {
            AgregarPermiso(sender, e);
        }

        private void AgregarPermiso(object sender, EventArgs e)
        {
            int a = listBoxPermisosFaltantes.SelectedIndex;
            string b = ((Modulo)listBoxPermisosFaltantes.SelectedItem).Descripcion;
            FormMessageBox dialog = new FormMessageBox();
            dialog.ShowErrorDialog("a: " + a + " -  b: " + b);

        }

        private void bRemovePermisoSelec_Click(object sender, EventArgs e)
        {
            int a = listBoxPermisosActuales.SelectedIndex;
            string b = ((Modulo)listBoxPermisosActuales.SelectedItem).Descripcion;
            FormMessageBox dialog = new FormMessageBox();
            dialog.ShowErrorDialog("a: " + a + " -  b: " + b);
        }
    }
}
