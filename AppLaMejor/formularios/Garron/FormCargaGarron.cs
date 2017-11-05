using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppLaMejor.datamanager;
using AppLaMejor.controlmanager;
using AppLaMejor.entidades;
using AppLaMejor.formularios.Util;
using AppLaMejor.stylemanager;

namespace AppLaMejor.formularios
{
    public partial class FormCargaGarron : Form
    {

        List<TipoGarron> listTipoGarron;
        TipoGarron selectedTipoGarron;
        List<Garron> listGarronCompleto;
        List<Garron> listGarronParcial;
        Garron selectedGarron;
        

        public FormCargaGarron()
        {
            InitializeComponent();
            Cargar();
            ApplicationLookAndFeel.ApplyThemeToAll(this);
        }

        void Cargar()
        {
            // Cargar TipoGarron (sino seleccionada nada, no se destraban los otros combos
            listTipoGarron = TiposManager.Instance().GetTipoGarronList();
            comboTipoGarron = FuncionesGarron.GetComboTipoGarron(comboTipoGarron, listTipoGarron);

            //int idGarron = 1;

            // Obtener lista de garrones del tipo seleccionado
            //List<Garron> listGarronTipo = FuncionesGarron.GetListGarronByEstadoAndTipo()


            
            ////List<int> listIdProducto = FuncionesGarron.GetIdProductoDeposteByGarron(idGarron);
            ////List<int> listIdProductoDepostado = FuncionesGarron.GetIdProductoDepostado(idGarron);

            ////listIdProducto.Clear();
            ////listIdProductoDepostado.Clear();

            ////listIdProducto = FuncionesGarron.GetIdProductoDeposteByGarron(idGarron);
            ////listIdProductoDepostado = FuncionesGarron.GetIdProductoDepostado(idGarron);

        }

        private void CargarComboBoxEstadoGarron()
        {
            // Cargar GarronCompleto
            listGarronCompleto = FuncionesGarron.GetListGarronByEstadoAndTipo("1", selectedTipoGarron.Id.ToString());
            if (listGarronCompleto.Count > 0)
            {
                comboGarronCompleto = FuncionesGarron.GetComboGarron(comboGarronCompleto, listGarronCompleto);
                comboGarronCompleto.Enabled = true;
            }
            else
            {
                listGarronCompleto.Clear();
                comboGarronCompleto.SelectedIndex = -1;
            }
            
            // Cargar GarronParcial
            listGarronParcial = FuncionesGarron.GetListGarronByEstadoAndTipo("2", selectedTipoGarron.Id.ToString());
            if (listGarronParcial.Count > 0)
            {
                comboGarronParcial = FuncionesGarron.GetComboGarron(comboGarronParcial, listGarronParcial);
                comboGarronParcial.Enabled = true;
            }
            else
            {
                listGarronParcial.Clear();
                comboGarronParcial.SelectedIndex = -1;
            }
                
        }

        private void AnularComboBoxEstadoGarron()
        {
            comboGarronCompleto.Enabled = false;
            comboGarronCompleto.DataSource = null;
            comboGarronParcial.Enabled = false;
            comboGarronParcial.DataSource = null;
        }

        private void comboTipoGarron_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!((ComboBox)sender).SelectedIndex.Equals(-1))
            {
                selectedTipoGarron = FuncionesGarron.GetTipoGarronClicked(sender, e);
                if (selectedTipoGarron!=null)
                    CargarComboBoxEstadoGarron();
            }
            else
            {
                AnularComboBoxEstadoGarron();
            }
        }

        private void comboGarronCompleto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!((ComboBox)sender).SelectedIndex.Equals(-1))
            {
                selectedGarron = FuncionesGarron.GetGarronClicked(sender, e);
            }
        }

        private void comboGarronParcial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!((ComboBox)sender).SelectedIndex.Equals(-1))
            {
                selectedGarron = FuncionesGarron.GetGarronClicked(sender, e);
            }
        }

        private void bAgregarGarron_Click(object sender, EventArgs e)
        {
            AgregarGarron();
        }

        private void AgregarGarron()
        {
            Garron g = new Garron();
            g.FechaEntrada = DateTime.Now;
            FormEntityInput dialog= new FormEntityInput(g, FormEntityInput.MODO_INSERTAR);
            Boolean result = dialog.Execute(g);

            if (result)
            {
                g = (Garron)dialog.SelectedObject;
                // Desde este form solo se carga garron estado COMPLETO = 1
                g.TipoEstadoGarron = TiposManager.Instance().GetTipoEstadoGarron(1);
                /* Insert en BD */
                if (FuncionesGarron.InsertGarron(g))
                {
                    MyTextTimer.TStart("Cuenta se guardo correctamente", statusStrip1, tsslMensaje);
                    CargarGarronCompletoEnTablePanel(g);
                }
                else
                {
                    MyTextTimer.TStart("No se guardo cuenta.", statusStrip1, tsslMensaje);
                }

            }
        }

        private void CargarGarronCompletoEnTablePanel(Garron g)
        {
            List<GarronParte> listPartes = FuncionesGarron.GetIdProductoDeposteByGarron(g.Id);
        }

    }
}
