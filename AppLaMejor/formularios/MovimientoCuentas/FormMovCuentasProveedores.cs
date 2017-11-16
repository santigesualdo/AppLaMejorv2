using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppLaMejor.datamanager;
using AppLaMejor.formularios.Util;
using AppLaMejor.entidades;
using AppLaMejor.controlmanager;
using AppLaMejor.stylemanager;

namespace AppLaMejor.formularios
{
    public partial class FormMovCuentasProveedores : Form
    {

        List<Proveedor> listProvs;
        DataTable tableProveedores;


        public FormMovCuentasProveedores()
        {
            InitializeComponent();
            CargarDataGrid();
            //CargarFilterComboTipoCliente();
            dataGridProveedores.Location = new Point(this.ClientSize.Width / 2 - dataGridProveedores.Size.Width / 2, this.ClientSize.Height / 2 - dataGridProveedores.Size.Height / 2);
            dataGridProveedores.Anchor = AnchorStyles.None;
            ApplicationLookAndFeel.ApplyTheme(this.tsslMensaje);
            ApplicationLookAndFeel.ApplyThemeToAll(this);
            VariablesGlobales.FormMovCuentas_activo = true;
        }

        public void CargarDataGrid()
        {
            // Trae la tabla clientes en DataTable y la mapea a en List<Proveedores>
            tableProveedores = FuncionesProveedores.fillProveedoresSaldoActual();
            listProvs = FuncionesProveedores.listProveedores(tableProveedores);   
            
            dataGridProveedores.DataSource = tableProveedores;

            // Hacemos que todas las columnas cambien su tamaño a lo ancho para que se vea toda la info
            for (int i = 0; i < dataGridProveedores.Columns.Count; i++)
            {
                dataGridProveedores.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            ApplicationLookAndFeel.ApplyTheme(dataGridProveedores);
        }
    

        private void bAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void bAgregar_Click(object sender, EventArgs e)
        {
            ModoAgregar(sender, e);
        }
        
        private void bVer_Click(object sender, EventArgs e)
        {
            ModoVer(sender, e);
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            // Aplicar filtro a data grid por texto en Razon Social
            if (!filterTextBox.Text.Equals(""))
            {
                StringBuilder filter = new StringBuilder();
                if (!(string.IsNullOrEmpty(filterTextBox.Text)))
                {
                    filter.Append("`Razon Social` Like '%" + filterTextBox.Text + "%'");
                    (dataGridProveedores.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
                }
            }
            else
            {
                (dataGridProveedores.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void filterTextBox_Click(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = string.Empty;
        }

        private void bCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bAceptar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModoVer(object sender, EventArgs e)
        {
            /* Obtenemos los datos de la fila seleccionada y la convertimos a entidad Cliente */
            int i = FuncionesGlobales.obtenerIndexDeListFromGrid(dataGridProveedores);
            Proveedor provSelected = listProvs.First(s => s.Id == i);

            /* Form Entity Input */
            FormMovDetalle dialog = new FormMovDetalle(FormMovDetalle.MODO_VER, provSelected);
            dialog.SetTitulo("Ver Movimientos - Proveedor: " + provSelected.RazonSocial);
            Boolean result = dialog.Execute(provSelected.Id);
        }

        private void ModoAgregar(object sender, EventArgs e)
        {
            /* Obtenemos los datos de la fila seleccionada y la convertimos a entidad Cliente */
            int i = FuncionesGlobales.obtenerIndexDeListFromGrid(dataGridProveedores);
            Proveedor provSelected = listProvs.First(s => s.Id == i);

            /* Form Entity Input */
            FormMovDetalle dialog = new FormMovDetalle(FormMovDetalle.MODO_AGREGAR, provSelected);
            dialog.SetTitulo("Agregar Movimiento - Proveedor: " + provSelected.RazonSocial);
            Boolean result = dialog.Execute(provSelected.Id);
        }

        private void FormMovCuentas_Activated(object sender, EventArgs e)
        {
            if (VariablesGlobales.FormMovCuentas_activo)
            {
                CargarDataGrid();
                VariablesGlobales.FormMovCuentas_activo = false;
            }
        }
    }
}
