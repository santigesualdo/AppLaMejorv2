using AppLaMejor.controlmanager;
using AppLaMejor.datamanager;
using AppLaMejor.entidades;
using AppLaMejor.formularios.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AppLaMejor.formularios
{
    public partial class FormDeposte : Form
    {
        List<Ubicacion> listUbicacion;
        List<TipoGarron> listTipoGarron;
        List<TipoEstadoGarron> listTipoEstadoGarron;

        List<VentaDetalle> listExcluirGarron;
        string currentNotInGarronIds;

        public static int MODO_SELECCIONAR_GARRON_PARA_DEPOSTE = 1;
        public static int MODO_SELECCIONAR_GARRON = 2;
        int currentModo;

        const int TIPO_ESTADO_GARRON_COMPLETO = 1;

        public Garron garronSelected;

        Ubicacion currentUbicacion = null;
        TipoEstadoGarron currentTipoEstadoGarron = null;
        TipoGarron currentTipoGarron = null;
        private string currentNumero = null;
        private string currentGarronData;

        public FormDeposte(int modo, List<VentaDetalle> list)
        {
            listExcluirGarron = list;
            LoadDeposte(modo);
        }

        public FormDeposte(int modo )
        {
            LoadDeposte(modo);
        }

        private void LoadDeposte(int modo)
        {
            InitializeComponent();
            CargarCombos();

            ApplicationLookAndFeel.ApplyThemeToAll(this);

            currentModo = modo;

            if (modo.Equals(MODO_SELECCIONAR_GARRON))
            {
                bDepostar.Text = "(Seleccionar Garron)";
            }
            else if (modo.Equals(MODO_SELECCIONAR_GARRON_PARA_DEPOSTE))
            {
                bDepostar.Text = "(Depostar)";
            }
        }

        private void CargarCombos()
        {
            
            BindingSource bs = new BindingSource();
            listUbicacion = TiposManager.Instance().GetUbicacionList();
            bs.DataSource = listUbicacion;
            comboUbicacion.DataSource = bs.DataSource;
            comboUbicacion.DisplayMember = "descripcion";
            comboUbicacion.ValueMember = "id";
            comboUbicacion.SelectedIndex = -1;
            comboUbicacion.SelectedIndexChanged += ComboUbicacion_SelectedIndexChanged;

            BindingSource bs2 = new BindingSource();
            listTipoGarron = TiposManager.Instance().GetTipoGarronList();
            bs2.DataSource = listTipoGarron;
            comboTipoGarron.DataSource = bs2.DataSource;
            comboTipoGarron.DisplayMember = "descripcion";
            comboTipoGarron.ValueMember = "id";
            comboTipoGarron.SelectedIndex = -1;
            comboTipoGarron.SelectedIndexChanged += ComboTipoGarron_SelectedIndexChanged;

            BindingSource bs3 = new BindingSource();
            listTipoEstadoGarron = TiposManager.Instance().GetTipoEstadoGarronList();
            bs3.DataSource = listTipoEstadoGarron;
            comboEstadoGarron.DataSource = bs3.DataSource;
            comboEstadoGarron.DisplayMember = "descripcion";
            comboEstadoGarron.ValueMember = "id";
            comboEstadoGarron.SelectedIndex = -1;
            comboEstadoGarron.SelectedIndexChanged += ComboEstadoGarron_SelectedIndexChanged;

            comboNumeroGarron.SelectedIndex = -1;

            currentNotInGarronIds = "";
            if (listExcluirGarron!= null && listExcluirGarron.Count > 0)
            {
                foreach (VentaDetalle vd in listExcluirGarron)
                {
                    if (vd.Garron != null)
                    {
                        currentNotInGarronIds += "'" + vd.Garron.Id + "',";
                    }
                }
                if (!currentNotInGarronIds.Equals(""))
                {
                    currentNotInGarronIds = currentNotInGarronIds.Remove(currentNotInGarronIds.Length - 1);
                }
            }

            if (currentNotInGarronIds.Equals("")){
                currentNotInGarronIds = null;
            }

            LoadTextBoxGarronByNumero(null, null, null, null, currentNotInGarronIds);
        }

        private void ComboEstadoGarron_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboEstadoGarron.SelectedIndex.Equals(-1))
            {
                currentTipoEstadoGarron = (TipoEstadoGarron)comboEstadoGarron.SelectedItem;
            }
        }

        private void ComboTipoGarron_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboTipoGarron.SelectedIndex.Equals(-1))
            {
                currentTipoGarron = (TipoGarron)comboTipoGarron.SelectedItem;
            }
        }

        private void ComboUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboUbicacion.SelectedIndex.Equals(-1))
            {
                currentUbicacion = (Ubicacion)comboUbicacion.SelectedItem;
            }
        }

        private void LoadTextBoxGarronByNumero(Ubicacion u, TipoEstadoGarron teg, TipoGarron tg, string numero, string listIdGarronExcluir)
        {
            string consulta = QueryManager.Instance().GetGarronByNumberSearchData(u,teg,tg, numero, listIdGarronExcluir);
            DataTable table = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            if (table.Rows.Count.Equals(0))
            {
                FormMessageBox dialog = new FormMessageBox();
                dialog.ShowErrorDialog("No se encontro garron con los filtros seleccionados.");
                LimpiarFiltros();
            }else
            {
                lResultados.Text = "Resultados: " + table.Rows.Count.ToString();
                comboNumeroGarron.DataSource = table.DefaultView;
                comboNumeroGarron.DisplayMember= "text";
                comboNumeroGarron.SelectedIndex = -1;
                comboNumeroGarron.Text = "(Seleccionar)";
            }
        }

        private void LimpiarFiltros()
        {
            comboUbicacion.SelectedIndex = -1;
            comboTipoGarron.SelectedIndex = -1;
            comboEstadoGarron.SelectedIndex = -1;
            
            currentUbicacion = null;
            currentTipoEstadoGarron = null;
            currentTipoGarron = null;
            currentNumero = "";
        }

        private void bDepostar_Click(object sender, EventArgs e)
        {
            if (currentModo.Equals(MODO_SELECCIONAR_GARRON_PARA_DEPOSTE))
            {
                FormDeposteGarron fdg = null;
                if (garronSelected.TipoEstadoGarron.Id.ToString().Equals(TIPO_ESTADO_GARRON_COMPLETO))
                {
                    fdg = new FormDeposteGarron(FormDeposteGarron.MODO_GARRONCOMPLETO, garronSelected, currentGarronData);
                }
                else
                {
                    fdg = new FormDeposteGarron(FormDeposteGarron.MODO_GARRONDEPOSTADO, garronSelected, currentGarronData);
                }

                fdg.ShowDialog();
                CargarCombos();
                bCancelSeleccion_Click(null, null);
            }else if (currentModo.Equals(MODO_SELECCIONAR_GARRON))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void bCancelSeleccion_Click(object sender, EventArgs e)
        {
            garronSelected = null;
            currentGarronData = null;
            bDepostar.Enabled = false;
            lGarronData.Text = "(sin seleccionar)";
            LimpiarFiltros();
            LoadTextBoxGarronByNumero(null, null, null, null, null);
        }

        private void bAplicarFiltros_Click(object sender, EventArgs e)
        {
            // Si se aplico algun filtro, cambiamos la consulta
            if (currentUbicacion != null || currentTipoEstadoGarron!= null || currentTipoGarron != null || currentNumero!=null || currentNotInGarronIds!=null)
                LoadTextBoxGarronByNumero(currentUbicacion, currentTipoEstadoGarron, currentTipoGarron, currentNumero, currentNotInGarronIds);
        }

        private void textNumero_Leave(object sender, EventArgs e)
        {
            TextBox textb = (TextBox)sender;
            if (!(textb.Text.Trim().Equals("") || textb.Text.Trim().Equals(string.Empty)))
            {
                // Si el text no esta vacio
                currentNumero = textb.Text;
            }else
            {
                currentNumero = null;
            }
        }

        private void textNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesGlobales.KeyPressIntegerTextField(sender, e);
        }

        private void comboNumeroGarron_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!comboNumeroGarron.SelectedIndex.Equals(-1))
            {
                ComboBox combo = ((ComboBox)sender);
                String text = ((DataRowView)combo.SelectedValue).Row["text"].ToString();
                string result = text.Substring(text.LastIndexOf("ID:") + 3);
                currentGarronData = text;
                garronSelected = FuncionesGarron.GetGarron(int.Parse(result));
                bDepostar.Enabled = true;
                lGarronData.Text = text;
            }
        }
    }
}
