using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppLaMejor.datamanager;
using AppLaMejor.entidades;


namespace AppLaMejor.formularios.MovimientoCuentas
{
    public partial class cuentasViejo : Form
    {
        public cuentasViejo()
        {
            InitializeComponent();
        }

        decimal debe, pago, saldo;

        
        /*
         * 
         * sección paginación
         * 
         * 
         */

        //SqlDataAdapter da;
        DataTable tableClientes;
        DataTable tableMovCuentas;
        DataTable TableMovCuentasPaginator;
        DataView dv;

        List<Cliente> listClientes;

        //DataTable dtSource;
        int pageCount;
        int pageSize;
        public int currentPage;
        int totalRegistros;

        /*
        * 
        * FIN sección paginación
        * 
        * 
        */

        //char n;
        
        
        MovimientoCuenta movCuenta1 = new MovimientoCuenta();
        Cliente cliente1 = new Cliente();
        int lastClient = 0;

        private void FormMovCuentas_Load(object sender, EventArgs e)
        {
            cargar();
           
        }

       


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //calcular();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            lastClient = (int)cmbClientes.SelectedValue;
            calcular(lastClient);
            fillGrid();
            
        }



        private void button1_Click(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (tbImporte.Text.Trim() != "") //&& (cmbCuentas.Text != ""))
                btEnviar.Enabled = true;
            else btEnviar.Enabled = false;
        }


        /* ************************************************************************
            * *********************************************************************
            * **********************      FUNCIONES    ****************************
            * *********************************************************************
            * *********************************************************************
            * *********************************************************************
            */

        void cargar()
        {
            panel1.Left = (this.Width - panel1.Width) / 2;
            panel1.Top = (this.Height - panel1.Height) / 2;
            cmbBoton.SelectedIndex = 0;
            tbImporte.Clear();
            String consulta = null;
            
            dtpDesde.Value = new DateTime(2017, 1, 1);

            // Trae clientes con cuenta 
            consulta = QueryManager.Instance().GetClientesWithCuenta();
            tableClientes = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            
            DataNamesMapper<Cliente> clientMapper = new DataNamesMapper<Cliente>();
            listClientes = clientMapper.Map(tableClientes).ToList();

            //lleno el combo clientes
            cmbClientes.DataSource = tableClientes.DefaultView;
            cmbClientes.DisplayMember = "RazonSocial";
            cmbClientes.ValueMember = "id";

            //lleno movCuentas
            tableMovCuentas = FuncionesMovCuentas.fillMovCuentas();
        }

        void calcular(int cliente)
        {
            //cuento cuantos movimientos tiene el cliente
            totalRegistros = FuncionesMovCuentas.contarRegistros(cliente);
            
            debe = pago = saldo = 0;
            dv = new DataView(tableMovCuentas);
            dv.RowFilter = "id_cliente_cuenta = " + cliente.ToString();

            

            //calculo a partir de la columna monto
            for (int a = 0; a < dv.Table.Rows.Count - 1; a++)
            {
                if (Convert.ToInt16(dv.Table.Rows[a]["id_movimiento_tipo"]) == 1) //1 - DEBE
                    debe += Convert.ToDecimal(dv.Table.Rows[a]["monto"]);
                //debe es el negativo, lo que me debe el cliente
                if (Convert.ToInt16(dv.Table.Rows[a]["id_movimiento_tipo"]) == 2) //2 - HABER
                    pago += Convert.ToDecimal(dv.Table.Rows[a]["monto"].ToString());
                //pagó es lo que pagó el cliente... daaa
                if (Convert.ToInt16(dv.Table.Rows[a]["id_movimiento_tipo"]) != 2 && Convert.ToInt16(dv.Table.Rows[a]["id_movimiento_tipo"]) != 1)
                    MessageBox.Show("Hay un error de asiento");
            }

            lblDebe.Text = debe.ToString("$ #,##0.00");
            lblPago.Text = pago.ToString("$ #,##0.00");
            saldo = pago - debe;
            lblSaldo.Text = saldo.ToString("$ #,##0.00");
        }

        void calcular(int cliente, DateTime dtDesde, DateTime dtHasta)
        {
            debe = pago = saldo = 0;
            DataView dv = new DataView(tableMovCuentas);

            dv.RowFilter = "id_cliente = " + cliente.ToString();
            //dv.RowFilter = "fecha > #" + dtDesde.ToString("yyyy-MM-dd") + "# AND fecha_<= #" + dtHasta.ToString("yyyy-MM-dd") + "#";

            //dgMovCuentas.DataSource = dv;
            //dgMovCuentas.AutoResizeColumns();

            DateTime miFecha = DateTime.Now.AddDays(0); ;

            if (dv.Table.Columns.Count > 0) verMenos(false);
            //columna monto
            for (int a = 0; a < dv.Table.Rows.Count - 1; a++)
            {
                //REVISAR -> ACA EXPLOTA

                miFecha = Convert.ToDateTime(dv.Table.Rows[a].ItemArray[8].ToString());
              
                if (miFecha >= dtDesde && miFecha <= dtHasta)
                {

                    if (Convert.ToInt16(dv.Table.Rows[a]["id_movimiento_tipo"]) == 1) //1 - DEBE
                        debe += Convert.ToDecimal(dv.Table.Rows[a]["monto"]);
                    //debe es el negativo, lo que me debe el cliente
                    if (Convert.ToInt16(dv.Table.Rows[a]["id_movimiento_tipo"]) == 2) //2 - HABER
                        pago += Convert.ToDecimal(dv.Table.Rows[a]["monto"].ToString());
                    //pagó es lo que pagó el cliente... daaa
                    if (Convert.ToInt16(dv.Table.Rows[a]["id_movimiento_tipo"]) != 2 && Convert.ToInt16(dv.Table.Rows[a]["id_movimiento_tipo"]) != 1)
                        MessageBox.Show("Hay un error de asiento");
                }
            }
            lblDebePeriodo.Text = debe.ToString("$ #,##0.00");
            lblPagoPeriodo.Text = pago.ToString("$ #,##0.00");
            saldo = pago - debe;
            lblSaldoPeriodo.Text = saldo.ToString("$ #,##0.00");
        }

        void verMenos(bool estado)
        {

            dgvMovCuentasPaginado.Columns[1].Visible = estado;
            dgvMovCuentasPaginado.Columns[2].Visible = estado;
            dgvMovCuentasPaginado.Columns[3].Visible = estado;
            dgvMovCuentasPaginado.Columns[4].Visible = estado;
            dgvMovCuentasPaginado.Columns[5].Visible = estado;
        }

        void enviar()
        {
            movCuenta1 = new MovimientoCuenta();
            TipoMovimiento tp = new TipoMovimiento();
            Cuenta cuenta = new Cuenta();
            Usuario usuario = new Usuario();
            
            int puff = (int)cmbClientes.SelectedValue;

            cliente1 = EntityParserManager.Instance().GetClienteById(puff);

            if (cliente1 != null)
            {
                tp.Id = cmbBoton.SelectedIndex + 1;
                movCuenta1.TipoMovimiento = tp;

                movCuenta1.Vob = '1';
                cuenta = cliente1.Cuentas[0];
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

                cmbClientes.SelectedValue = lastClient;
            }
        }

        private void cmbBoton_SelectionChangeCommitted(object sender, EventArgs e)
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

        private void btCalcular_Click(object sender, EventArgs e)
        {
            calcular(lastClient, dtpDesde.Value, dtpHasta.Value);
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            
            if (dtpDesde.Value >= dtpHasta.Value)
                dtpHasta.Value = dtpDesde.Value;
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            if (dtpHasta.Value < dtpDesde.Value)
                dtpDesde.Value = dtpHasta.Value;
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            currentPage += 1;
            LoadPage(currentPage, pageSize);
            
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

        private int counter;

        private void mensajeEnTimer(string mensaje)
        {
            counter = 0;
            tsslMensaje.Text = mensaje;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (counter >= 10)
            {
                timer1.Enabled = false;
                counter = 0;
            }
            else
            {
                counter = counter + 1;
                if ((counter % 2) == 0)
                    tsslMensaje.ForeColor = SystemColors.Control;
                else tsslMensaje.ForeColor = Color.Red;
            }
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
            pageSize = 14;
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

        private void tbImporte_Validated(object sender, EventArgs e)
        {
            if (tbImporte.Text.Trim() == "")
            {
                epMovCuentas.SetError(tbImporte, "Debe ingresar un valor correctamente");
                tbImporte.Focus();
            }
            else epMovCuentas.Clear();
        }
    }
}
