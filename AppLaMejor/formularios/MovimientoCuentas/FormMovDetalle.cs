using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using AppLaMejor.datamanager;
using AppLaMejor.entidades;
using AppLaMejor.formularios.MovimientoCuentas;
using AppLaMejor.stylemanager;
using AppLaMejor.controlmanager;

namespace AppLaMejor.formularios.Util
{
    public partial class FormMovDetalle : Form
    {
        DataTable tableClientes;
        DataTable tableMovCuentas;
        DataTable TableMovCuentasPaginator;
        DataView dv;

        public const int MODO_EDITAR = 0;
        public const int MODO_AGREGAR = 1;
        public const int MODO_VER = 2;
        decimal debe, pago, saldo;
        int currentModo;
        int pageCount;
        int pageSize;
        public int currentPage;
        int totalRegistros;

        string dtDesde, dtHasta;

        MovimientoCuenta movCuenta1 = new MovimientoCuenta();
        Cliente cliente1 = new Cliente();
        int lastClient = 0;

        public FormMovDetalle(Object reflection, int modo, int idCliente)
        {
           

            currentModo = modo;
            _reflection = reflection;
            InitializeComponent();
            ApplicationLookAndFeel.ApplyThemeToAll(this);
            cargar();
            lastClient = idCliente;
            calcular(lastClient);
            fillGrid();
            formatearControles();
            
        }

        private void formatearControles()
        {
            btEnviar.Width = 156;
            btEnviar.Height = 34;
            btFiltrar.Width = 156;
            btFiltrar.Height = 34;
            
            lblDebe.Font = StyleManager.Instance().GetCurrentStyle().MainFont;
            lblPago.Font = StyleManager.Instance().GetCurrentStyle().MainFont;
            lblSaldo.Font = StyleManager.Instance().GetCurrentStyle().MainFont;
            lblImporte.Font = StyleManager.Instance().GetCurrentStyle().MainFont;
            lblTituloDebe.Font = StyleManager.Instance().GetCurrentStyle().MainFont;
            lblTituloPago.Font = StyleManager.Instance().GetCurrentStyle().MainFont;
            lblTituloSaldo.Font = StyleManager.Instance().GetCurrentStyle().MainFont;
            lblCantidad.Font = StyleManager.Instance().GetCurrentStyle().MainFont;
            lblDesde.Font = StyleManager.Instance().GetCurrentStyle().MainFont;
            lblHasta.Font = StyleManager.Instance().GetCurrentStyle().MainFont;
        }

        private Boolean isBrowsable(PropertyInfo info)
        {
            return info.GetCustomAttributes(typeof(BrowsableAttribute), false).Length>-1;
        }

        private Object _reflection;
        private TableLayoutPanel controlsTableLayoutPanel = new TableLayoutPanel { Dock = DockStyle.Fill, CellBorderStyle = TableLayoutPanelCellBorderStyle.None };
        private int Id;

        private void bAceptar_Click(object sender, EventArgs e)
        {
            

            //this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = DialogResult.OK;

            this.Close();
        }
        public Boolean Execute(Object reflection, int entityId)
        {
            Id = entityId;
            _reflection = reflection;
            SelectedObject = _reflection;
            return ShowDialog() == DialogResult.OK;
        }

        public Boolean Execute(Object reflection)
        {
            _reflection = reflection;
            SelectedObject = _reflection;
            return ShowDialog() == DialogResult.OK;
        }

        public Object SelectedObject
        {
            get
            {
                return _reflection;
            }
            set
            {
                
            }
        }


        void calcularBetweenDates(int cliente)
        {
            //cuento cuantos movimientos tiene el cliente

            totalRegistros = FuncionesMovCuentas.contarRegistrosBetweenDates(cliente, dtDesde, dtHasta);

            debe = pago = saldo = 0;
            dv = new DataView(tableMovCuentas);
            dv.RowFilter = "id_cliente_cuenta = " + cliente.ToString();
            DataTable dvTemp = dv.ToTable();
            //calculo a partir de la columna monto
            for (int a = 0; a < dvTemp.Rows.Count; a++)
            {
                if (Convert.ToInt16(dvTemp.Rows[a]["id_movimiento_tipo"]) == 1) //1 - DEBE
                    debe += Convert.ToDecimal(dvTemp.Rows[a]["monto"]);
                //debe es el negativo, lo que me debe el cliente
                if (Convert.ToInt16(dvTemp.Rows[a]["id_movimiento_tipo"]) == 2) //2 - HABER
                    pago += Convert.ToDecimal(dvTemp.Rows[a]["monto"].ToString());
                //pagó es lo que pagó el cliente... daaa
                if (Convert.ToInt16(dvTemp.Rows[a]["id_movimiento_tipo"]) != 2 && Convert.ToInt16(dvTemp.Rows[a]["id_movimiento_tipo"]) != 1)
                    MessageBox.Show("Hay un error de asiento");
            }

            lblDebe.Text = debe.ToString("$ #,##0.00");
            lblPago.Text = pago.ToString("$ #,##0.00");
            saldo = pago - debe;
            lblSaldo.Text = saldo.ToString("$ #,##0.00");

            lblCantidad.Text = "Cantidad de movimientos: " + dvTemp.Rows.Count.ToString();
        }

        void calcular(int cliente)
        {
            //cuento cuantos movimientos tiene el cliente

            totalRegistros = FuncionesMovCuentas.contarRegistros(cliente);

            debe = pago = saldo = 0;
            dv = new DataView(tableMovCuentas);
            dv.RowFilter = "id_cliente_cuenta = " + cliente.ToString();
            DataTable dvTemp = dv.ToTable();
            //calculo a partir de la columna monto
            for (int a = 0; a < dvTemp.Rows.Count; a++)
            {
                if (Convert.ToInt16(dvTemp.Rows[a]["id_movimiento_tipo"]) == 1) //1 - DEBE
                    debe += Convert.ToDecimal(dvTemp.Rows[a]["monto"]);
                //debe es el negativo, lo que me debe el cliente
                if (Convert.ToInt16(dvTemp.Rows[a]["id_movimiento_tipo"]) == 2) //2 - HABER
                    pago += Convert.ToDecimal(dvTemp.Rows[a]["monto"].ToString());
                //pagó es lo que pagó el cliente... daaa
                if (Convert.ToInt16(dvTemp.Rows[a]["id_movimiento_tipo"]) != 2 && Convert.ToInt16(dvTemp.Rows[a]["id_movimiento_tipo"]) != 1)
                    MessageBox.Show("Hay un error de asiento");
            }

            lblDebe.Text = debe.ToString("$ #,##0.00");
            lblPago.Text = pago.ToString("$ #,##0.00");
            saldo = pago - debe;
            lblSaldo.Text = saldo.ToString("$ #,##0.00");

            lblCantidad.Text = "Cantidad de movimientos: " + dvTemp.Rows.Count.ToString();
        }

        private void DisplayPageInfo()
        {
            string cp = (currentPage + 1).ToString();
            // pageCount += 1;
            string pz = pageCount.ToString();
            txtDisplayPageNo.Text = "Pag. " + cp + "/ " + pz;
            //pageCount -= 1;
        }

        private void fillGrid()
        {
            pageCount = 0;
            currentPage = 0;
            pageSize = 12;
            pageCount = (totalRegistros / pageSize) + 1;
            LoadPage(0, pageSize);
            DisplayPageInfo();
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            currentPage -= 1;

            if (currentPage >= 0)
            {
                //Check if you are already at the first page.

                LoadPage(currentPage, pageSize);

            }
            else
            {
                currentPage += 1;

                mensajeEnTimer("Ha llegado al inicio");
            }
        }

        private void LoadPage(int cp, int reg)
        {

            int ini = cp * reg;

            if (ini < totalRegistros)
            {
                TableMovCuentasPaginator = FuncionesMovCuentas.fillPagina(lastClient, ini, reg);

                //            debe = pago = saldo = 0;

                if (TableMovCuentasPaginator.Rows.Count > 0)
                {
                    dgvMovCuentasPaginado.DataSource = TableMovCuentasPaginator;
                    dgvMovCuentasPaginado.AutoResizeColumns();

                    verMenos(false);
                    dgvMovCuentasPaginado.Columns["monto"].Width = 140;
                    dgvMovCuentasPaginado.Columns["monto"].DefaultCellStyle.Format = "c";
                    dgvMovCuentasPaginado.Columns["monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvMovCuentasPaginado.Columns["cobrado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                }
                else
                {
                    currentPage -= 1;
                }
                DisplayPageInfo();

            }
            else
            {
                ini = ini - reg;
                currentPage--;
                mensajeEnTimer("Ha llegado al final");
            }
        }

        private void LoadPage(int cp, int reg, string dDesde, string dHasta)
        {

            int ini = cp * reg;

            if (ini < totalRegistros)
            {
                TableMovCuentasPaginator = FuncionesMovCuentas.fillPaginaBetweenDates(lastClient, ini, reg, dDesde, dHasta);

                //            debe = pago = saldo = 0;

                if (TableMovCuentasPaginator.Rows.Count > 0)
                {
                    dgvMovCuentasPaginado.DataSource = TableMovCuentasPaginator;
                    dgvMovCuentasPaginado.AutoResizeColumns();

                    verMenos(false);
                    dgvMovCuentasPaginado.Columns["monto"].Width = 140;
                    dgvMovCuentasPaginado.Columns["monto"].DefaultCellStyle.Format = "c";
                    dgvMovCuentasPaginado.Columns["monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvMovCuentasPaginado.Columns["cobrado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                }
                else
                {
                    dgvMovCuentasPaginado.DataSource = null;
                    currentPage -= 1;
                }
                DisplayPageInfo();

            }
            else
            {
                ini = ini - reg;
                currentPage--;
                mensajeEnTimer("Ha llegado al final");
            }
        }


        private int counter;

        private void mensajeEnTimer(string mensaje)
        {
            counter = 0;
            tsslMensaje.Text = mensaje;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        void verMenos(bool estado)
        {

            dgvMovCuentasPaginado.Columns[1].Visible = estado;
            dgvMovCuentasPaginado.Columns[2].Visible = estado;
            dgvMovCuentasPaginado.Columns[3].Visible = estado;
            dgvMovCuentasPaginado.Columns[4].Visible = estado;
            dgvMovCuentasPaginado.Columns[5].Visible = estado;
        }

      

        void cargar()
        {
            switch (currentModo)
            {
                case 0: 
                    break;
                case 1:
                    msFiltro.Visible = false;
                    plOperacion.Visible = true;
                    plGridPaginado.Visible = false;
                    
                    break;
                case 2:
                    msFiltro.Visible = true;
                    plOperacion.Visible = false;
                    plGridPaginado.Visible = true;
                    break;
            }
            cmbBoton.SelectedIndex = 0;
            tbImporte.Clear();
            String consulta = null;

            //dtpDesde.Value = new DateTime(2017, 1, 1);

            // Trae clientes con cuenta 
            consulta = QueryManager.Instance().GetClientesWithCuenta();
            tableClientes = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);



            //lleno movCuentas
            tableMovCuentas = FuncionesMovCuentas.fillMovCuentas();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            currentPage += 1;
            LoadPage(currentPage, pageSize);
        }

        

        private void tbImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            //    // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbImporte_TextChanged(object sender, EventArgs e)
        {
            if (tbImporte.Text.Trim() != "") //&& (cmbCuentas.Text != ""))
                btEnviar.Enabled = true;
            else btEnviar.Enabled = false;
        }

        private void cmbBoton_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbBoton.SelectedIndex)
            {
                case 0:
                    btEnviar.Text = "DEBITAR!";
                    break;
                case 1: btEnviar.Text = "ACREDITAR!";
                    break;
            }
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                enviar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error:" + ex.Message);
            }
        }

        void enviar()
        {
            movCuenta1 = new MovimientoCuenta();
            TipoMovimiento tp = new TipoMovimiento();
            Cuenta cuenta = new Cuenta();
            Usuario usuario = new Usuario();
            VariablesGlobales.FormMovCuentas_activo = true;
            cuenta = FuncionesClientes.GetCuentaByIdCliente(lastClient);

            cliente1 = FuncionesClientes.GetClienteById(lastClient);

            if (cliente1 != null)
            {
                tp.Id = cmbBoton.SelectedIndex + 1;
                movCuenta1.TipoMovimiento = tp;

                movCuenta1.Vob = '1';
                
                switch(tp.Id)
                {
                    case 1:
                        cuenta.SaldoActual = saldo - Convert.ToDecimal(tbImporte.Text);
                        break;
                    case 2:
                        cuenta.SaldoActual = saldo + Convert.ToDecimal(tbImporte.Text);
                        break;
                }
                //cuenta.Saldo_actual = saldo + Convert.ToDecimal(tbImporte.Text);
                movCuenta1.Cuenta = cuenta;
                Decimal montoto = Convert.ToDecimal(tbImporte.Text);
                movCuenta1.Monto = montoto;
                movCuenta1.Fecha = DateTime.Now.AddDays(0);
                movCuenta1.Cobrado = 'N';
                usuario.Id = 1;
                //movCuenta1.Usuario = usuario;

                FuncionesMovCuentas.insertarMovimiento(movCuenta1);

                mensajeEnTimer("Hecho");

                cargar();

                tableMovCuentas.AcceptChanges();

                calcular(lastClient);
            }
        }

        private void xzxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            plFiltro.Visible = true;
            msFiltro.Visible = false;
        }

        private void btFiltrar_Click(object sender, EventArgs e)
        {
            calcularBetweenDates(lastClient);
            //hacer el filtro acá
            
            fillGridBetweenDates();
            plFiltro.Visible = false;
            msFiltro.Visible = true;
        }

        private void fillGridBetweenDates()
        {
            pageCount = 0;
            currentPage = 0;
            pageSize = 12;
            pageCount = (totalRegistros / pageSize) + 1;
            LoadPage(0, pageSize, dtDesde, dtHasta);
            DisplayPageInfo();
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            dtDesde = dtpDesde.Value.ToString("yyyy-MM-dd");
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            dtHasta = dtpHasta.Value.ToString("yyyy-MM-dd");
        }

      


    }


}
