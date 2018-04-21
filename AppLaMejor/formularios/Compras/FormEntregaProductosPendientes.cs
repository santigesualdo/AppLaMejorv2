using AppLaMejor.controlmanager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppLaMejor.formularios.Compras
{
    public partial class FormEntregaProductosPendientes : Form
    {

        DataTable tableProductosFaltantes;

        public FormEntregaProductosPendientes()
        {
            InitializeComponent();
            CargarDataGrid();
            ApplicationLookAndFeel.ApplyThemeToAll(this);
        }

        private void CargarDataGrid()
        {
            // Trae la tabla Productos en DataTable y la mapea a en List<Productos>
            tableProductosFaltantes = FuncionesProductos.fillComprasProductosFaltantes();

            dataGridComprasProdPendientes.DataSource = tableProductosFaltantes;
            dataGridComprasProdPendientes.AllowUserToAddRows = false;
            dataGridComprasProdPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Hacemos que todas las columnas cambien su tamaño a lo ancho para que se vea toda la info
            for (int i = 0; i < dataGridComprasProdPendientes.Columns.Count; i++)
            {
                string name = dataGridComprasProdPendientes.Columns[i].Name;
                if (name.ToUpper().Equals("ID") || name.ToUpper().Equals("USUARIO") || name.ToUpper().Equals("FECHA_BAJA"))
                {
                    dataGridComprasProdPendientes.Columns[i].Visible = false;
                    continue;
                }
                
                dataGridComprasProdPendientes.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            ApplicationLookAndFeel.ApplyTheme(dataGridComprasProdPendientes);
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
