using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class FormProveedores : Form
    {

        List<Proveedor> listProveedores;
        DataTable tableProveedores;

        public FormProveedores()
        {
            InitializeComponent();
            CargarDataGrid();

            ApplicationLookAndFeel.ApplyTheme(this.tsslMensaje);
            ApplicationLookAndFeel.ApplyThemeToAll(this);
        }

        private void CargarDataGrid()
        {
            // Trae la tabla clientes en DataTable y la mapea a en List<Clientes>
            tableProveedores = FuncionesProveedores.fillProveedores();
            listProveedores = FuncionesProveedores.listProveedores(tableProveedores);
            ApplicationLookAndFeel.ApplyTheme(dataGridProveedores);

            /*for (int j = 0; j < tableProveedores.Rows.Count; j++)
            {
                for (int i = 0; i < tableProveedores.Columns.Count; i++)
                {
                    // Sabemos que el nomenclador es ID Tipo Proveedor
                    if (tableProveedores.Columns[i].ColumnName.Equals("TipoCliente"))
                    {
                        tableProveedores.Rows[j][i] = listProveedores[j].TipoCliente.Descripcion;
                    }
                }
            }*/

            dataGridProveedores.DataSource = tableProveedores;
            dataGridProveedores.AllowUserToAddRows = false;

            // Hacemos que todas las columnas cambien su tamaño a lo ancho para que se vea toda la info
            for (int i = 0; i < dataGridProveedores.Columns.Count; i++)
            {
                dataGridProveedores.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                // Hacemos que todas las columnas cambien su tamaño a lo ancho para que se vea toda la info
                string name = dataGridProveedores.Columns[i].Name;
                if (name.ToUpper().Equals("ID") || name.ToUpper().Equals("USUARIO") || name.ToUpper().Equals("FECHABAJA"))
                {
                    dataGridProveedores.Columns[i].Visible = false;
                    continue;
                }
            }


        }

        private void EliminarRegistro(object sender, EventArgs e)
        {
            // Seteamos fecha baja en el registro por ID de Cliente
            int i = FuncionesGlobales.obtenerIndexDeListFromGrid(dataGridProveedores);
            Proveedor provSelected= listProveedores.First(s => s.Id == i);

            FormMessageBox dialog = new FormMessageBox();
            if (dialog.ShowConfirmationDialog("¿Eliminar registro del Proveedor " + provSelected.RazonSocial + " ?"))
            {
                string consultaEliminar = QueryManager.Instance().GetDeleteProv(provSelected.Id.ToString(), DateTime.Now);
                if (QueryManager.Instance().ExecuteSQL(ConnecionBD.Instance().Connection, consultaEliminar))
                {
                    MyTextTimer.TStartFade("Proveedor eliminado correctamente", statusStrip1, tsslMensaje, MyTextTimer.TIME_SHORT);
                    CargarDataGrid();
                }
            }
        }

        private void ModoEdicion(object sender, EventArgs e)
        {
            /* Obtenemos los datos de la fila seleccionada y la convertimos a entidad Proveedor */
            int i = FuncionesGlobales.obtenerIndexDeListFromGrid(dataGridProveedores);
            Proveedor provSelected = listProveedores.First(s => s.Id == i);

            /* Form Entity Input */
            FormEntityInput dialog = new FormEntityInput(null, FormEntityInput.MODO_EDITAR, formTittleText.Text);
            Boolean result = dialog.Execute(provSelected, provSelected.Id);

            if (result)
            {
                Proveedor prov = (Proveedor)dialog.SelectedObject;
                /* Update en BD */

                if (FuncionesProveedores.UpdateProv(prov))
                {
                    // se actualizo bien
                    CargarDataGrid();
                    MyTextTimer.TStartFade("Proveedor actualizado correctamente", statusStrip1, tsslMensaje, MyTextTimer.TIME_SHORT);
                }
                else
                {
                    // se actualizo mal
                    MyTextTimer.TStartFade("Proveedor NO se actualizo correctamente", statusStrip1, tsslMensaje, MyTextTimer.TIME_SHORT);
                }

            }
        }

        private void ModoVer(object sender, EventArgs e)
        {
            /* Obtenemos los datos de la fila seleccionada y la convertimos a entidad Proveedor */
            int i = FuncionesGlobales.obtenerIndexDeListFromGrid(dataGridProveedores);
            Proveedor provSelected = listProveedores.First(s => s.Id == i);

            /* Form Entity Input */
            FormEntityInput dialog = new FormEntityInput(null, FormEntityInput.MODO_VER, formTittleText.Text);
            Boolean result = dialog.Execute(provSelected, provSelected.Id);
        }

        private void AgregarProveedor()
        {
            Proveedor newProv = FuncionesProveedores.AgregarProveedor(formTittleText.Text);
            if (newProv!= null)
            {
                MyTextTimer.TStartFade("Se guardo Proveedor " + newProv.RazonSocial.ToUpper() + ".", statusStrip1, tsslMensaje, MyTextTimer.TIME_SHORT);
                CargarDataGrid();
            }else
            {
                MyTextTimer.TStartFade("No se guardo el Proveedor. Ocurrio un error.", statusStrip1, tsslMensaje, MyTextTimer.TIME_SHORT);
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
            AgregarProveedor();
        }

        private void bVer_Click(object sender, EventArgs e)
        {
            ModoVer(sender, e);
        }

        private void bEditar_Click(object sender, EventArgs e)
        {
            ModoEdicion(sender, e);
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            // Aplicar filtro a data grid por texto en Razon Social
            if (!filterTextBox.Text.Equals(""))
            {
                StringBuilder filter = new StringBuilder();
                if (!(string.IsNullOrEmpty(filterTextBox.Text)))
                {
                    filter.Append("RazonSocial Like '%" + filterTextBox.Text + "%'");
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
            string theDate = dtpFilter.Value.Date.ToString("yyyy-MM-dd");

            //Aplicar filtro a data grid por texto fecha en Razon Social
            if (!theDate.Equals(""))
            {
                StringBuilder filter = new StringBuilder();
                if (!(string.IsNullOrEmpty(theDate)))
                {
                    filter.Append("FechaDesde = '" + theDate + "'");
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

        private void bAgregarCuenta_Click(object sender, EventArgs e)
        {
            AgregarCuenta();
        }

        private void AgregarCuenta()
        {
            int i = FuncionesGlobales.obtenerIndexDeListFromGrid(dataGridProveedores);
            Proveedor provSelected = listProveedores.First(s => s.Id == i);

            /* Obtenemos los datos de la fila seleccionada y la convertimos a entidad Proveedor */
            Cuenta newCuenta = new Cuenta();
            newCuenta.FechaUltimaActualizacion = DateTime.Now;

            /* Form Entity Input */
            FormEntityInput dialog = new FormEntityInput(null, FormEntityInput.MODO_INSERTAR, "Cuenta de Proveedor. ");
            dialog.SetTitulo("Insertando cuenta a Proveedor: "+ provSelected.RazonSocial);
            Boolean result = dialog.Execute(newCuenta);

            if (result)
            {
                newCuenta = (Cuenta)dialog.SelectedObject;
                /* Insert en BD */               
                if (!FuncionesProveedores.InsertCuenta(newCuenta, provSelected.Id.ToString()).Equals(-1))
                {
                    MyTextTimer.TStartFade("Cuenta se guardo correctamente", statusStrip1, tsslMensaje, MyTextTimer.TIME_SHORT);
                }
                else
                {
                    MyTextTimer.TStartFade("No se guardo cuenta.", statusStrip1, tsslMensaje, MyTextTimer.TIME_SHORT);
                }

            }


        }



    }
}
