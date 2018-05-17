using AppLaMejor.controlmanager;
using AppLaMejor.datamanager;
using AppLaMejor.entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppLaMejor.formularios.Productos
{
    public partial class FormUbicacion : Form
    {
        DataTable tableUbicacion;
        List<ProductoUbicacion> listProdUbicacion;

        public FormUbicacion()
        {
            InitializeComponent();
            CargarGrid();
            LoadComboUbicacion();
            LoadComboTipoProducto();
            ApplicationLookAndFeel.ApplyThemeToAll(this);
            
        }

        private void LoadComboUbicacion()
        {
            // Ejemplo usar nomenclador para filtro
            Ubicacion tpvacio = new Ubicacion();
            tpvacio.Id = 0;
            tpvacio.Descripcion = "";
            List<Ubicacion> listUbicacion = TiposManager.Instance().GetUbicacionList();
            listUbicacion.Add(tpvacio);
            listUbicacion = listUbicacion.OrderBy(x => x.Id).ToList();
            BindingList<Ubicacion> objects = new BindingList<Ubicacion>(listUbicacion);
            comboTipoFilter.ValueMember = null;
            comboTipoFilter.DisplayMember = "Descripcion";
            comboTipoFilter.DataSource = objects;
            comboTipoFilter.SelectedIndex = -1;
        }

        private void LoadComboTipoProducto()
        {
            // Ejemplo usar nomenclador para filtro
            TipoProducto tpvacio = new TipoProducto();
            tpvacio.Id = 0;
            tpvacio.Descripcion = "";
            List<TipoProducto> listTipoProductos = TiposManager.Instance().GetTipoProductoList();
            listTipoProductos.Add(tpvacio);
            listTipoProductos = listTipoProductos.OrderBy(x => x.Id).ToList();
            BindingList<TipoProducto> objects = new BindingList<TipoProducto>(listTipoProductos);
            comboTipoProducto.ValueMember = null;
            comboTipoProducto.DisplayMember = "Descripcion";
            comboTipoProducto.DataSource = objects;
            comboTipoProducto.SelectedIndex = -1;
        }

        private void CargarGrid()
        {
            // Trae la tabla Productos en DataTable y la mapea a en List<Productos>
            tableUbicacion = FuncionesProductos.fillProductoUbicacion();
            listProdUbicacion = FuncionesProductos.listProductoUbicacion(tableUbicacion);

            dataGridPU.AllowUserToAddRows = false;

            /*for (int j = 0; j < tableUbicacion.Rows.Count; j++)
            {
                for (int i = 0; i < tableUbicacion.Columns.Count; i++)
                {
                    // Sabemos que el nomenclador es ID Tipo Producto
                    if (tableUbicacion.Columns[i].ColumnName.Equals("TipoProducto"))
                    {
                        tableUbicacion.Rows[j][i] = listProdUbicacion[j].TipoProducto.Descripcion;
                    }
                }
            }*/

            dataGridPU.DataSource = tableUbicacion;

            // Hacemos que todas las columnas cambien su tamaño a lo ancho para que se vea toda la info
            for (int i = 0; i < dataGridPU.Columns.Count; i++)
            {
                string name = dataGridPU.Columns[i].Name;
                if (name.ToUpper().Equals("ID") || name.ToUpper().Equals("USUARIO") || name.ToUpper().Equals("FECHA_BAJA"))
                {
                    dataGridPU.Columns[i].Visible = false;
                    continue;
                }
                dataGridPU.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            ApplicationLookAndFeel.ApplyTheme(dataGridPU);
        }

        private void bMoverProducto_Click(object sender, EventArgs e)
        {
            FormMoverProductos formMoverProductos = new FormMoverProductos(FormMoverProductos.MODO_MOVERMERCADERIA, null, null);
            formMoverProductos.ShowDialog();

            CargarGrid();
        }

        private void filterProductoPLU_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            // Aplicar filtro a data grid por texto en Razon Social
            if (!textBox.Text.Equals(""))
            {
                StringBuilder filter = new StringBuilder();
                if (!(string.IsNullOrEmpty(textBox.Text)))
                {
                    filter.Append("mercaderia Like '%" + textBox.Text + "%'");
                    (dataGridPU.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
                }
            }
            else
            {
                (dataGridPU.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void filterGarronText_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            // Aplicar filtro a data grid por texto en Razon Social
            if (!textBox.Text.Equals(""))
            {
                StringBuilder filter = new StringBuilder();
                if (!(string.IsNullOrEmpty(textBox.Text)))
                {
                    filter.Append("mercaderia Like '%" + textBox.Text + "%'");
                    (dataGridPU.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
                }
            }
            else
            {
                (dataGridPU.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void comboTipoFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            Ubicacion ubicacion= (Ubicacion)combo.SelectedValue;

            //Aplicar filtro a data grid por texto fecha en Razon Social
            if (ubicacion != null && !string.IsNullOrEmpty(ubicacion.Descripcion))
            {
                StringBuilder filter = new StringBuilder();
                if (!(string.IsNullOrEmpty(ubicacion.Descripcion)))
                {
                    filter.Append(" ubicacion like '%" + ubicacion.Descripcion + "%'");
                    (dataGridPU.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
                }
            }
            else
            {
                (dataGridPU.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            TipoProducto tipoProducto = (TipoProducto)combo.SelectedValue;

            //Aplicar filtro a data grid por texto fecha en Razon Social
            if (tipoProducto != null && !string.IsNullOrEmpty(tipoProducto.Descripcion))
            {
                StringBuilder filter = new StringBuilder();
                if (!(string.IsNullOrEmpty(tipoProducto.Descripcion)))
                {
                    filter.Append("TipoProducto = '" + tipoProducto.Descripcion + "'");
                    (dataGridPU.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
                }
            }
            else
            {
                (dataGridPU.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }
    }

}
