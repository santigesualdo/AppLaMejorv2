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
using AppLaMejor.formularios.MovimientoCuentas;

namespace AppLaMejor.formularios
{
    public partial class FormMovCuentas : Form
    {

        List<Cliente> listClients;
        DataTable tableClientes;

        public FormMovCuentas()
        {
            InitializeComponent();
            CargarDataGrid();
            dataGridClientes.Location = new Point(this.ClientSize.Width / 2 - dataGridClientes.Size.Width / 2, this.ClientSize.Height / 2 - dataGridClientes.Size.Height / 2);
            dataGridClientes.Anchor = AnchorStyles.None;
            ApplicationLookAndFeel.ApplyTheme(this.tsslMensaje);
            ApplicationLookAndFeel.ApplyThemeToAll(this);
        }

        private void CargarFilterComboTipoCliente()
        {
            // Ejemplo usar nomenclador para filtro
            TipoCliente tcvacio = new TipoCliente();
            tcvacio.Id = 0;
            tcvacio.Descripcion = "";
            List<TipoCliente> listTipoClientes = TiposManager.Instance().GetTipoClienteList();
            listTipoClientes.Add(tcvacio);
            listTipoClientes = listTipoClientes.OrderBy(x => x.Id).ToList();
            BindingList<TipoCliente> objects = new BindingList<TipoCliente>(listTipoClientes);

            comboTipoFilter.ValueMember = null;
            comboTipoFilter.DisplayMember = "Descripcion";
            comboTipoFilter.DataSource = objects;

            comboTipoFilter.SelectedIndex = -1;
        }

        private void CargarFilterComboClientesSinCuenta()
        {
            tableClientes = FuncionesClientes.fillClientes();
            listClients = FuncionesClientes.listClientes(tableClientes);

            BindingList<Cliente> objects = new BindingList<Cliente>(listClients);

            cmbClientes.ValueMember = null;
            cmbClientes.DisplayMember = "RazonSocial";
            cmbClientes.DataSource = objects;

            cmbClientes.SelectedIndex = -1;

            VariablesGlobales.FormMovCuentas_comboCargado = true;
        }


        public void CargarDataGrid()
        {
            // Trae la tabla clientes en DataTable y la mapea a en List<Clientes>
            tableClientes = FuncionesClientes.fillClientesSaldoActual();
            listClients = FuncionesClientes.listClientes(tableClientes);

            for (int j = 0; j < tableClientes.Rows.Count; j++)
            {
                for (int i = 0; i < tableClientes.Columns.Count; i++)
                {
                    // Sabemos que el nomenclador es ID Tipo Cliente
                    if (tableClientes.Columns[i].ColumnName.Equals("TipoCliente"))
                    {
                        tableClientes.Rows[j][i] = listClients[j].TipoCliente.Descripcion;
                    }
                }
            }

            dataGridClientes.DataSource = tableClientes;
            dataGridClientes.AllowUserToAddRows = false;

            // Hacemos que todas las columnas cambien su tamaño a lo ancho para que se vea toda la info
            for (int i = 0; i < dataGridClientes.Columns.Count; i++)
            {
                dataGridClientes.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                string name = dataGridClientes.Columns[i].Name;
                if (name.ToUpper().Equals("ID") || name.ToUpper().Equals("USUARIO") || name.ToUpper().Equals("FECHABAJA"))
                {
                    dataGridClientes.Columns[i].Visible = false;
                    continue;
                }
            }

            CargarFilterComboTipoCliente();
            CargarFilterComboClientesSinCuenta();

            ApplicationLookAndFeel.ApplyTheme(dataGridClientes);

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
                    filter.Append("`RazonSocial` Like '%" + filterTextBox.Text + "%'");
                    (dataGridClientes.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
                }
            }
            else
            {
                (dataGridClientes.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void comboTipoFilterOnChange(object sender, EventArgs e)
        {
            comboNomencladorFilterChange(sender);
        }

        private void comboNomencladorFilterChange(object sender)
        {
            ComboBox combo = (ComboBox)sender;
            TipoCliente tipoCliente = (TipoCliente)combo.SelectedValue;

            //Aplicar filtro a data grid por texto fecha en Razon Social
            // Si tipo cliente ID = 0 significa que toco espacio vacio, no cuenta.
            if (tipoCliente != null && !string.IsNullOrEmpty(tipoCliente.Descripcion) && !tipoCliente.Id.Equals(0))
            {
                StringBuilder filter = new StringBuilder();
                if (!(string.IsNullOrEmpty(tipoCliente.Descripcion)))
                {
                    filter.Append("`TipoCliente` = '" + tipoCliente.Descripcion + "'");
                    (dataGridClientes.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
                }
            }
            else
            {
                (dataGridClientes.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
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
            int i = FuncionesGlobales.obtenerIndexDeListFromGrid(dataGridClientes);
            Cliente clientSelected = listClients.First(s => s.Id == i);

            /* Form Entity Input */
            FormMovDetalle dialog = new FormMovDetalle(FormMovDetalle.MODO_VER, clientSelected);
            dialog.SetTitulo("Cliente: " + clientSelected.RazonSocial);
            Boolean result = dialog.Execute(clientSelected.Id);
        }

        private void ModoAgregar(object sender, EventArgs e)
        {
            /* Obtenemos los datos de la fila seleccionada y la convertimos a entidad Cliente */
            int i = FuncionesGlobales.obtenerIndexDeListFromGrid(dataGridClientes);
            Cliente clientSelected = listClients.First(s => s.Id == i);

            /* Form Entity Input */
            FormMovDetalle dialog = new FormMovDetalle(FormMovDetalle.MODO_AGREGAR, clientSelected);
            dialog.SetTitulo("Cliente: " + clientSelected.RazonSocial);
            Boolean result = dialog.Execute(clientSelected.Id);
        }

        private void FormMovCuentas_Activated(object sender, EventArgs e)
        {
            if (VariablesGlobales.FormMovCuentas_activo)
            {
                CargarDataGrid();
                VariablesGlobales.FormMovCuentas_activo = false;
            }
        }

        private void cmbClientes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            if (combo.SelectedIndex != -1)
            {
                Cliente client = (Cliente)combo.SelectedValue;
                if (nuevaCuenta(client) != null)
                {
                    CargarDataGrid();
                }
            }
        }

        private void cmbClientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (Char.IsSeparator(e.KeyChar))
                e.Handled = false;
            else e.Handled = true;

        }

        Cuenta nuevaCuenta(Cliente client)
        {
            FormMessageBox fdialog = new FormMessageBox();
            fdialog = new FormMessageBox();


            if (client != null)
            {
                if (fdialog.ShowConfirmationDialog("¿Desea agregarle una nueva cuenta a : " + client.RazonSocial + "?"))
                {
                    /* Obtenemos los datos de la fila seleccionada y la convertimos a entidad Cliente */
                    Cuenta newCuenta = new Cuenta();
                    newCuenta.FechaUltimaActualizacion = DateTime.Now;

                    /* Form Entity Input */
                    FormEntityInput dialog = new FormEntityInput(null, FormEntityInput.MODO_INSERTAR);
                    dialog.SetTitulo("Nueva cuenta para : " + client.RazonSocial);
                    Boolean result = dialog.Execute(newCuenta);
                    if (result)
                    {
                        newCuenta = (Cuenta)dialog.SelectedObject;
                        /* Insert en BD */
                        if (FuncionesClientes.InsertCuenta(newCuenta, client.Id.ToString()))
                        {
                            MyTextTimer.TStartFade("Cuenta se guardo correctamente", statusStrip1, tsslMensaje, MyTextTimer.TIME_LONG);
                            return newCuenta;
                        }
                        else
                        {
                            MyTextTimer.TStartFade("No se guardo cuenta.", statusStrip1, tsslMensaje, MyTextTimer.TIME_LONG);
                            return null;
                        }
                    }
                }
            }
            return null;

        }

        private void cmbClientes_SelectedValueChanged(object sender, EventArgs e)
        {

            //if (VariablesGlobales.FormMovCuentas_comboCargado)
            //{
            //}
        }

        private void FormMovCuentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            VariablesGlobales.FormMovCuentas_activo = false;
            VariablesGlobales.FormMovCuentas_comboCargado = false;
        }

        private void dataGridClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(dataGridClientes[6, dataGridClientes.CurrentCell.RowIndex].Value.ToString());

            //    dataGridView1.CurrentCell.RowIndex,
            //dataGridView1.CurrentCell.ColumnIndex
        }
    }

}
