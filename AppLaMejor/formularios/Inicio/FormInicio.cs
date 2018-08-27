using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppLaMejor.datamanager;
using AppLaMejor.controlmanager;
using AppLaMejor.stylemanager;
using AppLaMejor.formularios.Compras;
using AppLaMejor.formularios.Productos;
using AppLaMejor.formularios.Caja;
using AppLaMejor.Reports;
using AppLaMejor.formularios.Util;
using System.Threading;

namespace AppLaMejor.formularios
{
    public partial class FormInicio : Form
    {
        TableLayoutPanel tablePanel;

        public FormInicio()
        {
            InitializeComponent();

            ApplicationLookAndFeel.ApplyThemeToAll(this);

            MyTextTimer.TStartFade("Seleccione Modulo.", this.statusStrip1, this.tsslMensaje, MyTextTimer.TIME_FOREVER);


            //consulta si se ha creado un backup en el dia, si es falso (0)
            //se crea un backup de la base de datos
            if (FuncionesBackups.ConsultaBackupDelDia() == 0)
                FuncionesBackups.crearBackUp();
            
        }

        private void CargarFormInicio()
        {
            // Obtenemos tabla con la consulta ejecutada
            QueryManager manager = QueryManager.Instance();
            string query = manager.GetUsuariosModulos(VariablesGlobales.userIdLogueado);
            DataTable dtTablaModulos = manager.GetTableResults(ConnecionBD.Instance().Connection, query);

            // Preparamos table layout para mostrar los modulos disponibles
            tablePanel = new TableLayoutPanel();
            tablePanel.Name = "tablePanel";
            contentPanel.Controls.Add(tablePanel);
            tablePanel.Dock = DockStyle.Fill;
            tablePanel.ColumnCount = 1;
            tablePanel.RowCount = 0;
            tablePanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // Obtenemos los modulos disponibles
            for (int i = 0; i < dtTablaModulos.Rows.Count; i++)
            {
                string moduleName = dtTablaModulos.Rows[i].ItemArray[1].ToString();
                AddRowToTablePanel(tablePanel, moduleName);
            }

            tablePanel.HorizontalScroll.Maximum = 0;
            tablePanel.AutoScroll = false;
            tablePanel.VerticalScroll.Visible = false;
            tablePanel.AutoScroll = true;
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {
            CargarFormInicio();
        }

        private void AddRowToTablePanel(TableLayoutPanel tpanel, string moduloName)
        {
            tpanel.RowCount+=1;
            
            Button b1 = new Button();
            b1 = AddEventToButton(b1, moduloName);

            b1.Name = "b" + moduloName;
            b1.AutoSize = false;
            b1.SetBounds(0, 0, 0, 60);
            b1.Dock = DockStyle.Top;
            b1.Text = moduloName;
            ApplicationLookAndFeel.ApplyTheme(b1);           

            tpanel.Controls.Add(b1, 0, tpanel.Controls.Count);
        }

        private void Button1Click(object sender, EventArgs e)
        {
            AddRowToTablePanel(tablePanel,"");
        }

        private Button AddEventToButton(Button boton, String moduleName)
        {
            switch (moduleName)
            {
                case "Clientes": boton.Click += new System.EventHandler(IniciarClientes); break;
                case "Proveedores": boton.Click += new System.EventHandler(IniciarProveedores); break;
                case "Productos": boton.Click += new System.EventHandler(IniciarProductos); break;
                case "Caja": boton.Click += new System.EventHandler(IniciarCaja); break;
                case "Movimiento Cuentas Clientes": boton.Click += new System.EventHandler(IniciarMovimientoCuentas); break;
                case "Movimiento Cuentas Proveedores": boton.Click += new System.EventHandler(IniciarMovimientoCuentasProveedores); break;
                case "Ventas": boton.Click += new System.EventHandler(IniciarVentasCaja); break;
                case "Carga Nueva Compra": boton.Click += new System.EventHandler(IniciarCargaCompras); break;
                case "Caja Mayorista": boton.Click += new System.EventHandler(IniciarCajaMay); break;
                case "Ubicacion de Productos": boton.Click += new System.EventHandler(IniciarUbicacionProductos); break;
                case "Deposte": boton.Click += new System.EventHandler(IniciarDeposte); break;
				case "Reportes": boton.Click += new System.EventHandler(IniciarReportes); break;
                case "Compras con Productos a Entregar": boton.Click+= new System.EventHandler(IniciarComprasConProduFaltante); break;
                case "Compras": boton.Click += new System.EventHandler(IniciarCompras); break;
                case "Backups": boton.Click += new System.EventHandler(IniciarBackups); break;
            }
            return boton;
        }
        private void IniciarBackups(object sender, EventArgs e)
        {
            FormBackup formbackup = new FormBackup();
            formbackup.ShowDialog();
        }
        private void IniciarCompras(object sender, EventArgs e)
        {
            FormCompras formCompras = new FormCompras();
            formCompras.ShowDialog();
        }

        private void IniciarComprasConProduFaltante(object sender, EventArgs e)
        {
            FormEntregaProductosPendientes form = new FormEntregaProductosPendientes();
            form.ShowDialog();
        }

        private void IniciarDeposte(object sender, EventArgs e)
        {
            FormDeposte formDeposte = new FormDeposte(FormDeposte.MODO_SELECCIONAR_GARRON_PARA_DEPOSTE);
            formDeposte.ShowDialog();
        }

        private void IniciarClientes(object sender, EventArgs e)
        {
            FormClientes formClientes = new FormClientes();
            formClientes.ShowDialog();
        }
        private void IniciarProveedores(object sender, EventArgs e)
        {
            FormProveedores formProveedores = new FormProveedores();
            formProveedores.ShowDialog();
        }
        private void IniciarProductos(object sender, EventArgs e)
        {
            FormProductos formProductos = new FormProductos();
            formProductos.ShowDialog();
        }
        private void IniciarMovimientoCuentas(object sender, EventArgs e)
        {
            FormMovCuentas formMovCuentas = new FormMovCuentas();
            formMovCuentas.ShowDialog();
        }
        private void IniciarCaja(object sender, EventArgs e)
        {
            FormCaja formCaja = new FormCaja();
            formCaja.ShowDialog();
        }

        private void IniciarCajaMay(object sender, EventArgs e)
        {
            FormCajaMayorista formCajaMay = new FormCajaMayorista();
            formCajaMay.ShowDialog();
        }
        private void IniciarVentasCaja(object sender, EventArgs e)
        {
            FormVentas formVentasCaja = new FormVentas();
            formVentasCaja.ShowDialog();
        }
        private void IniciarMovimientoCuentasProveedores(object sender, EventArgs e)
        {
            FormMovCuentasProveedores formMovCuentasProveedores = new FormMovCuentasProveedores();
            formMovCuentasProveedores.ShowDialog();
        }
        private void IniciarCargaCompras(object sender, EventArgs e)
        {
            FormCargaCompras formCompras = new FormCargaCompras();
            formCompras.ShowDialog();
        }

        private void IniciarUbicacionProductos(object sender, EventArgs e)
        {
            FormUbicacion formUbicacion = new FormUbicacion();
            formUbicacion.ShowDialog();
        }
		private void IniciarReportes(object sender, EventArgs e)
        {
            FormReportes formReportes = new FormReportes();
            formReportes.ShowDialog();

         //   FormModalReportes fmr = new FormModalReportes();
         //   fmr.ShowDialog();
        }
        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
