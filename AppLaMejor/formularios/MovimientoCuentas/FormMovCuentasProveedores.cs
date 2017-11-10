using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppLaMejor.datamanager;
using AppLaMejor.formularios.Util;
using AppLaMejor.entidades;
using AppLaMejor.controlmanager;

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

        //private void CargarFilterComboTipoCliente()
        //{
        //    // Ejemplo usar nomenclador para filtro
        //    TipoCliente tcvacio = new TipoCliente();
        //    tcvacio.Id = 0;
        //    tcvacio.Descripcion = "";
        //    List<TipoCliente> listTipoClientes = TiposManager.Instance().GetTipoClienteList();
        //    listTipoClientes.Add(tcvacio);
        //    listTipoClientes = listTipoClientes.OrderBy(x => x.Id).ToList();
        //    BindingList<TipoCliente> objects = new BindingList<TipoCliente>(listTipoClientes);

        //    comboTipoFilter.ValueMember = null;
        //    comboTipoFilter.DisplayMember = "Descripcion";
        //    comboTipoFilter.DataSource = objects;

        //    comboTipoFilter.SelectedIndex = -1;
        //}        

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

        private void EliminarRegistro(object sender, EventArgs e)
        {       
            // Seteamos fecha baja en el registro por ID de Cliente
            int selectedrowindex = dataGridProveedores.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridProveedores.Rows[selectedrowindex];
            string razonSocial = Convert.ToString(selectedRow.Cells["RazonSocial"].Value);
            string idProveedor = Convert.ToString(selectedRow.Cells["ID"].Value);

            DialogResult dr = MessageBox.Show("¿Eliminar registro del proveedor " + razonSocial + " ?", "Confirmar", MessageBoxButtons.YesNo);
            switch(dr){
               case DialogResult.Yes:
                    string consultaEliminar = QueryManager.Instance().GetDeleteClient(idProveedor, DateTime.Now);
                    if (QueryManager.Instance().ExecuteSQL(ConnecionBD.Instance().Connection, consultaEliminar))
                    {
                        MessageBox.Show("Registro exitosamente eliminado.");
                        CargarDataGrid();
                    }                   

                   break;
               case DialogResult.No: break;
            }
        }

        

        private void bAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
           EliminarRegistro(sender, e);
        }
        
        private void bAgregar_Click(object sender, EventArgs e)
        {
            ModoAgregar(sender, e);
        }

        

        private void bVer_Click(object sender, EventArgs e)
        {
            ModoVer(sender, e);
        }

        private void bEditar_Click(object sender, EventArgs e)
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

        private void dtpFilter_ValueChanged(object sender, EventArgs e)
        {
            

            
            
            //Aplicar filtro a data grid por texto fecha en Razon Social
            //if (!theDate.Equals(""))
            //{
            //    StringBuilder filter = new StringBuilder();
            //    if (!(string.IsNullOrEmpty(theDate)))
            //    {
            //        filter.Append("FechaDesde = '" + theDate + "'");
            //        (dataGridClientes.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
            //    }
            //}
            //else
            //{
            //    (dataGridClientes.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            //}
        }

        //private void comboTipoFilterOnChange(object sender, EventArgs e)
        //{
        //    comboNomencladorFilterChange(sender);
        //}

        //private void comboNomencladorFilterChange(object sender)
        //{
        //    ComboBox combo = (ComboBox)sender;
        //    TipoCliente tipoCliente = (TipoCliente)combo.SelectedValue;

        //    //Aplicar filtro a data grid por texto fecha en Razon Social
        //    if ( tipoCliente!=null && !string.IsNullOrEmpty(tipoCliente.Descripcion))
        //    {
        //        StringBuilder filter = new StringBuilder();
        //        if (!(string.IsNullOrEmpty(tipoCliente.Descripcion)))
        //        {
        //            filter.Append("`Tipo Cliente` = '" + tipoCliente.Descripcion + "'");
        //            (dataGridProveedores.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
        //        }
        //    }
        //    else
        //    {
        //        (dataGridProveedores.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
        //    }
        //}

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
            int selectedrowindex = dataGridProveedores.SelectedCells[0].RowIndex;
            Proveedor provSelected = listProvs[selectedrowindex];
            int idProveedor = provSelected.Id;

            /* Form Entity Input */
            FormMovDetalle dialog = new FormMovDetalle(null, FormMovDetalle.MODO_VER, idProveedor, 1);
            Boolean result = dialog.Execute(provSelected, idProveedor);
        }

        private void ModoAgregar(object sender, EventArgs e)
        {
            /* Obtenemos los datos de la fila seleccionada y la convertimos a entidad Cliente */
            int selectedrowindex = dataGridProveedores.SelectedCells[0].RowIndex;
            Proveedor provSelected = listProvs[selectedrowindex];
            int idProveedor = provSelected.Id;

            /* Form Entity Input */
            FormMovDetalle dialog = new FormMovDetalle(null, FormMovDetalle.MODO_AGREGAR, idProveedor, 1);
            Boolean result = dialog.Execute(provSelected, idProveedor);
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
