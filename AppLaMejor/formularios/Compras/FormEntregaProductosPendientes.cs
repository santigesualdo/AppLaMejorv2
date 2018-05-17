using AppLaMejor.controlmanager;
using AppLaMejor.formularios.Util;
using System;
using System.Data;
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

            ApplicationLookAndFeel.ApplyTheme(dataGridComprasProdPendientes);

            // Hacemos que todas las columnas cambien su tamaño a lo ancho para que se vea toda la info
            for (int i = 0; i < dataGridComprasProdPendientes.Columns.Count; i++)
            {
                string name = dataGridComprasProdPendientes.Columns[i].Name;
                if (name.ToUpper().Equals("ID") || name.ToUpper().Equals("USUARIO") || name.ToUpper().Equals("FECHA_BAJA"))
                {
                    dataGridComprasProdPendientes.Columns[i].Visible = false;
                    continue;
                }
                
                dataGridComprasProdPendientes.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (i.Equals(dataGridComprasProdPendientes.Columns.Count - 1))
                {
                  //  dataGridComprasProdPendientes.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dataGridComprasProdPendientes.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bAgregar_Click(object sender, EventArgs e)
        {
            FormMessageBox dialog = new FormMessageBox();
            if (dataGridComprasProdPendientes.RowCount > 0)
            {
                int idCompra = FuncionesGlobales.obtenerIndexDeListFromGrid(dataGridComprasProdPendientes);
                if (dialog.ShowConfirmationDialog("¿Desea marcar los productos no entregados en la compra #" + idCompra + " como entregados?"))
                {
                    if (FuncionesCompras.ConfirmarEntregaProductosRestantesTransaction(idCompra))
                    {
                        dialog.ShowErrorDialog("Los productos que faltaban entregar de la compra #" + idCompra + " fueron registrados \ncon exito y ubicados en Deposito");
                        CargarDataGrid();
                    }
                }
            }else
            {
                dialog.ShowErrorDialog("No existe ninguna compra con productos pendientes de entrega.");
            }
        }

    }
}
