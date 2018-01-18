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
using AppLaMejor.formularios.Productos;
using System.IO;
using System.Diagnostics;

namespace AppLaMejor.formularios
{
    public partial class FormProductos : Form
    {

        List<Producto> listProds;
        DataTable tableProductos;

        public FormProductos()
        {
            InitializeComponent();
            CargarDataGrid();
            CargarFilterComboTipoProducto();

            ApplicationLookAndFeel.ApplyTheme(this.tsslMensaje);
            ApplicationLookAndFeel.ApplyThemeToAll(this);
        }

        private void CargarFilterComboTipoProducto()
        {
            // Ejemplo usar nomenclador para filtro
            TipoProducto tpvacio = new TipoProducto();
            tpvacio.Id = 0;
            tpvacio.Descripcion = "";
            List<TipoProducto> listTipoProductos = TiposManager.Instance().GetTipoProductoList();
            listTipoProductos.Add(tpvacio);
            listTipoProductos = listTipoProductos.OrderBy(x => x.Id).ToList();
            BindingList<TipoProducto> objects = new BindingList<TipoProducto>(listTipoProductos);

            comboTipoFilter.ValueMember = null;
            comboTipoFilter.DisplayMember = "Descripcion";
            comboTipoFilter.DataSource = objects;

            comboTipoFilter.SelectedIndex = -1;
        }        

        private void CargarDataGrid()
        {
            // Trae la tabla Productos en DataTable y la mapea a en List<Productos>
            tableProductos = FuncionesProductos.fillProductos();
            listProds = FuncionesProductos.listProductos(tableProductos);

            dataGridProductos.AllowUserToAddRows = false;

            for (int j = 0; j < tableProductos.Rows.Count; j++)
            {
                for (int i = 0; i < tableProductos.Columns.Count; i++)
                {
                    // Sabemos que el nomenclador es ID Tipo Producto
                    if (tableProductos.Columns[i].ColumnName.Equals("TipoProducto"))
                    {
                        tableProductos.Rows[j][i] = listProds[j].TipoProducto.Descripcion;
                    }
                }
            }          
            
            dataGridProductos.DataSource = tableProductos;

            // Hacemos que todas las columnas cambien su tamaño a lo ancho para que se vea toda la info
            for (int i = 0; i < dataGridProductos.Columns.Count; i++)
            {
                string name = dataGridProductos.Columns[i].Name;
                if (name.ToUpper().Equals("ID") || name.ToUpper().Equals("USUARIO") || name.ToUpper().Equals("FECHA_BAJA"))
                {
                    dataGridProductos.Columns[i].Visible = false;
                    continue;
                }
                dataGridProductos.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            ApplicationLookAndFeel.ApplyTheme(dataGridProductos);
        }

        private void EliminarRegistro(object sender, EventArgs e)
        {       
            // Seteamos fecha baja en el registro por ID de Producto
            int selectedrowindex = dataGridProductos.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridProductos.Rows[selectedrowindex];
            string descripcion = Convert.ToString(selectedRow.Cells["DescripcionBreve"].Value);
            string idProducto = Convert.ToString(selectedRow.Cells["ID"].Value);

			FormMessageBox dialog = new FormMessageBox();
			if (dialog.ShowConfirmationDialog("¿Eliminar registro del Producto " + descripcion + " ?")){
                    string consultaEliminar = QueryManager.Instance().GetDeleteProd(idProducto, new DateTime());
                    if (QueryManager.Instance().ExecuteSQL(ConnecionBD.Instance().Connection, consultaEliminar))
                    {
						dialog = new FormMessageBox();
						dialog.ShowErrorDialog("Registro exitosamente eliminado.");
                        CargarDataGrid();
                    }                   				
			}
        }

        private void ModoEdicion(object sender, EventArgs e)
        {
            /* Obtenemos los datos de la fila seleccionada y tomamos los datos de la lista de productos */
            int i = FuncionesGlobales.obtenerIndexDeListFromGrid(dataGridProductos);
            Producto ProdSelected = listProds.First(s => s.Id == i);
            int idProducto = ProdSelected.Id;

            /* Form Entity Input */
            FormEntityInput dialog = new FormEntityInput(null, FormEntityInput.MODO_EDITAR, formTittleText.Text);
            Boolean result = dialog.Execute(ProdSelected, idProducto);

            if (result)
            {
                Producto Prod = (Producto)dialog.SelectedObject;
                /* Update en BD */

                if (FuncionesProductos.UpdateProducto(Prod))
                {
                    // se actualizo bien
                    CargarDataGrid();
                    MyTextTimer.TStart("Producto actualizado correctamente", statusStrip1, tsslMensaje);         
                }
                else
                {
                    MyTextTimer.TStart("Producto no se pudo actualizar actualizado correctamente.", statusStrip1, tsslMensaje);         
                }
                
            }
        }

        private void ModoVer(object sender, EventArgs e)
        {
            /* Obtenemos los datos de la fila seleccionada y la convertimos a entidad Producto */
            int i = FuncionesGlobales.obtenerIndexDeListFromGrid(dataGridProductos);
            Producto ProdSelected = listProds.First(s => s.Id == i);
            int idProducto = ProdSelected.Id;

            /* Form Entity Input */
            FormEntityInput dialog = new FormEntityInput(null,FormEntityInput.MODO_VER, formTittleText.Text);
            Boolean result = dialog.Execute(ProdSelected, idProducto);
        }

        private void AgregarProducto()
        {
            /* Obtenemos los datos de la fila seleccionada y la convertimos a entidad Producto */
            Producto newProd = new Producto();
            //newProd.FechaVencimiento = DateTime.Now;

            /* Form Entity Input */
            FormEntityInput dialog = new FormEntityInput(null, FormEntityInput.MODO_INSERTAR, formTittleText.Text);
            Boolean result = dialog.Execute(newProd);

            if (result)
            {
                newProd = (Producto)dialog.SelectedObject;
                /* Insert en BD */

                if (FuncionesProductos.InsertProducto(newProd))
                {
                    CargarDataGrid();
                    MyTextTimer.TStart("Producto '" +  newProd.DescripcionBreve + "' creado correctamente", statusStrip1, tsslMensaje);         
                }
                else
                {
                    MyTextTimer.TStart("Producto '" + newProd.DescripcionBreve + "' actualizado correctamente", statusStrip1, tsslMensaje);         
                }   
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
            AgregarProducto();
        }

        private void bVer_Click(object sender, EventArgs e)
        {
            ModoVer(sender, e);
        }

        private void bEditar_Click(object sender, EventArgs e)
        {
            ModoEdicion(sender, e);
        }

        private void comboTipoFilterOnChange(object sender, EventArgs e)
        {
            comboNomencladorFilterChange(sender);
        }

        private void comboNomencladorFilterChange(object sender)
        {
            ComboBox combo = (ComboBox)sender;
            TipoProducto tipoProducto = (TipoProducto)combo.SelectedValue;

            //Aplicar filtro a data grid por texto fecha en Razon Social
            if ( tipoProducto!=null && !string.IsNullOrEmpty(tipoProducto.Descripcion))
            {
                StringBuilder filter = new StringBuilder();
                if (!(string.IsNullOrEmpty(tipoProducto.Descripcion)))
                {
                    filter.Append("TipoProducto = '" + tipoProducto.Descripcion + "'");
                    (dataGridProductos.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
                }
            }
            else
            {
                (dataGridProductos.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
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

        private void filter2TextBox_Click(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = string.Empty;
        }

        private void filter2TextBox_TextChanged(object sender, EventArgs e)
        {
            // Aplicar filtro a data grid por texto en Razon Social
            TextBox textBox = (TextBox)sender;

            if (!textBox.Text.Equals(""))
            {
                StringBuilder filter = new StringBuilder();
                if (!(string.IsNullOrEmpty(textBox.Text)))
                {
                    filter.Append("DescripcionBreve Like '%" + textBox.Text + "%'");
                    (dataGridProductos.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
                }
            }
            else
            {
                (dataGridProductos.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            // Aplicar filtro a data grid por texto en Razon Social
            if (!textBox.Text.Equals(""))
            {
                StringBuilder filter = new StringBuilder();
                if (!(string.IsNullOrEmpty(textBox.Text)))
                {
                    filter.Append("CodigoBarra Like '%" + textBox.Text + "%'");
                    (dataGridProductos.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
                }
            }
            else
            {
                (dataGridProductos.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void bHistoricoPrecios_Click(object sender, EventArgs e)
        {
            ShowHistoricoPrecios();
        }

        private void bActualizarPrecios_Click(object sender, EventArgs e)
        {
            FormActualizarPrecios formActualizarPrecios = new FormActualizarPrecios();
            formActualizarPrecios.ShowDialog();
        }

        private void dataGridProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowHistoricoPrecios();
            // TODO: ir al modificado en la grilla
        }

        private void ShowHistoricoPrecios()
        {
            // HistoricoPrecio

            int index = dataGridProductos.CurrentRow.Index;
            
            int i = FuncionesGlobales.obtenerIndexDeListFromGrid(dataGridProductos);
            Producto ProdSelected = listProds.First(s => s.Id == i);
            int idProducto = ProdSelected.Id;

            VariablesGlobales.idProductoHistorico = idProducto;

            FormHistoricoPrecios formHistoricoPrecios = new FormHistoricoPrecios();
            formHistoricoPrecios.ShowDialog();

            CargarDataGrid();

            dataGridProductos.Rows[0].Selected = false;
            dataGridProductos.Rows[index].Selected = true;
            dataGridProductos.FirstDisplayedScrollingRowIndex = dataGridProductos.SelectedRows[0].Index;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportarPreciosCsv();
        }

        private void ExportarPreciosCsv()
        {
            FormMessageBox dialog = new FormMessageBox();
            try
            {
                // Confirmamos que el usuario este seguro 

                if (dialog.ShowConfirmationDialog("¿Esta seguro de guardar los precios en Balanza Digital?"))
                {
                    // Exigimos que Qendra este abierto. Sino, lo abrimos.
                    if (!FuncionesGlobales.IsProccessOpen("Qendra"))
                    {
                        dialog.ShowConfirmationDialog("Es necesario abrir la App QENDRA para actualizar precios. \nAbriendo QENDRA, intente nuevamente cuando la aplicacion este abierta.");
                        String path = FuncionesGlobales.GetParametro(VariablesGlobales.QENDRAPATH_PARAMNAME);

                        // Abrimos la aplicacion y cortamos la exportación hasta que Qendra este activo.
                        Process.Start(path);
                        return;
                    }
                    else
                    {
                        dialog.ShowConfirmationDialog("Qendra abierto. Exportando.. ");
                    }
                }
                else
                    return;


                // Quendra esta activo, creamos el CSV.
                StringBuilder sb = new StringBuilder();
                DataTable dt = FuncionesPrecios.GetPreciosToExport();
                foreach (DataRow row in dt.Rows)
                {
                    string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                    sb.AppendLine(string.Join(",", fields));
                }

                string savePath = FuncionesGlobales.GetParametro(VariablesGlobales.FILEPRECIOSSAVE_PARAMNAME);
                File.WriteAllText(savePath + "applamejorprecios.csv", sb.ToString());
                MyTextTimer.TStart("Precios exportados correctamente. Aguarde el mensaje de confirmación.", statusStrip1, tsslMensaje);

            }
            catch (Exception E)
            {
                dialog.ShowErrorDialog("Ocurrio un problema. Motivo: " + E.Message);
            }
        }
    }
}
