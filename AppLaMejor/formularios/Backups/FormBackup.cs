using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppLaMejor.datamanager;
using AppLaMejor.formularios.Util;
using AppLaMejor.entidades;
using AppLaMejor.controlmanager;
using AppLaMejor.stylemanager;
using System.IO;

namespace AppLaMejor.formularios
{
    public partial class FormBackup : Form
    {

        List<Backup> listBackups;
        DataTable tableBackups;
        internal string i;
      
        public FormBackup()
        {
            InitializeComponent();
            CargarDataGrid();
            CargarFilterComboTipoCliente();

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
        }        

        private void CargarDataGrid()
        {
            // Trae la tabla clientes en DataTable y la mapea a en List<Clientes>
            tableBackups = FuncionesBackups.fillBackups();
            listBackups = FuncionesBackups.listBackups(tableBackups);
            ApplicationLookAndFeel.ApplyTheme(dataGridClientes);


            dataGridClientes.DataSource = tableBackups;
            dataGridClientes.AllowUserToAddRows = false;

            // Hacemos que todas las columnas cambien su tamaño a lo ancho para que se vea toda la info
            for (int i = 0; i < dataGridClientes.Columns.Count; i++)
            {
                dataGridClientes.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                // Hacemos que todas las columnas cambien su tamaño a lo ancho para que se vea toda la info
                string name = dataGridClientes.Columns[i].Name;
                if (name.ToUpper().Equals("ID") || name.ToUpper().Equals("USUARIO") || name.ToUpper().Equals("FECHABAJA"))
                {
                    dataGridClientes.Columns[i].Visible = false;
                    continue;
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

        private void bAgregar_Click(object sender, EventArgs e)
        {
            string path = @"c:\backupBD\sql\MyTest.bat";
            string pathsql = @"C:\backupBD\sql\";
            string sqlfile = i;
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("@echo off");
                    sw.WriteLine("echo Comenzando la Restauración de la Base de Datos en el Servidor");
                    sw.WriteLine("mysql--user = root--password = dd74f695 bdlamejor_dev < " + pathsql + sqlfile + ".sql");
                    sw.WriteLine("echo on");
                    sw.WriteLine("echo Restauración Completa.");
                }
            }
        }

        private void bEditar_Click(object sender, EventArgs e)
        {
            if (dataGridClientes.Rows.Count >= 1)
            {
                preguntarParaRestaurarCopia();
            }
            else MessageBox.Show("No hay backups");
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            // Aplicar filtro a data grid por texto en Razon Social
            if (!filter4TextBox.Text.Equals(""))
            {
                StringBuilder filter = new StringBuilder();
                if (!(string.IsNullOrEmpty(filter4TextBox.Text)))
                {
                    filter.Append("descripcion Like '%" + filter4TextBox.Text + "%'");
                    (dataGridClientes.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
                }
            }
            else
            {
                (dataGridClientes.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
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
                    filter.Append("Fecha = '" + theDate + "'");
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

        private void dataGridClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridClientes.Rows.Count >= 1)
            {
                preguntarParaRestaurarCopia();
            }
            else MessageBox.Show("No hay backups");
        }

        void preguntarParaRestaurarCopia()
        {
            //elemento 1 es la fecha en la que se hizo el backup
            i = FuncionesBackups.obtenerTextFromGrid(dataGridClientes).ElementAt(1);

            FormMessageBox dialog = new FormMessageBox();
            if (dialog.ShowConfirmationDialog("¿Desea restaurar la base de datos a la fecha " + i + " ?"))
            {
                //envío como parametro el nombre del archivo sql para restaurar copia
                FuncionesBackups.restaurarCopia(FuncionesBackups.obtenerTextFromGrid(dataGridClientes).ElementAt(0));
                
                MyTextTimer.TStartFade("Restauración realizada correctamente", statusStrip1, tsslMensaje, MyTextTimer.TIME_SHORT);
                CargarDataGrid();
            }
        }
    }
}
