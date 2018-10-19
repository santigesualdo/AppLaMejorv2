using System;
using System.Data;
using System.Windows.Forms;
using AppLaMejor.datamanager;
using AppLaMejor.entidades;
using AppLaMejor.formularios.MovimientoCuentas;
using AppLaMejor.stylemanager;
using AppLaMejor.controlmanager;
using System.Drawing;

namespace AppLaMejor.formularios.Util
{
    public partial class FormMovDetalle : Form
    {

        DataTable table, tableCuentas, tableMovCuentas, tableMovCuentasPaginator;
        DataView dv;

        public const int MODO_EDITAR = 0;
        public const int MODO_AGREGAR = 1;
        public const int MODO_VER = 2;

        public const int ROWCOUNTPAGINATION = 10;

        decimal debe, pago, saldo;
        int currentModo;
        int pageCount;
        int pageSize;
        public int currentPage;
        int totalRegistros;

        string tipo;

        int lastEntityId = 0;
        int lastCuenta = 1;

        public FormMovDetalle(int modo, Cliente client)
        {
            Iniciar(modo, client);

            Size actualSize = this.Size;
            this.Size = new Size(actualSize.Width, Screen.PrimaryScreen.Bounds.Height - 25);
        }

        public FormMovDetalle(int modo, Cliente client, string importe)
        {
            Iniciar(modo, client, importe);

            Size actualSize = this.Size;
            this.Size = new Size(actualSize.Width, Screen.PrimaryScreen.Bounds.Height - 25);
        }

        public FormMovDetalle(int modo, Proveedor proveedor)
        {
            Iniciar(modo, proveedor);

            Size actualSize = this.Size;
            this.Size = new Size(actualSize.Width, Screen.PrimaryScreen.Bounds.Height - 25);
        }

        public void SetTitulo(string titulo)
        {
            this.formTittleText.Text = titulo;
        }

        private void Iniciar(int modo, Cliente client)
        {
            currentModo = modo;
            tipo = "Cliente";

            InitializeComponent();
            lblTituloDebe.Text = "Debe";
            lblTituloPago.Text = "Pagó";
            rDebitar.Text = "Debitar";
            rAcreditar.Text = "Acreditar";
            cargar();
            lastEntityId = client.Id;

            calcular(lastEntityId);
            fillGrid();
            fillGridCuentas(lastEntityId);
            ApplicationLookAndFeel.ApplyThemeToAll(this);
        }

        private void Iniciar(int modo, Cliente client, string importe)
        {
            currentModo = modo;
            tipo = "Cliente";
            lblTituloDebe.Text = "Debe";
            lblTituloPago.Text = "Pagó";
            rDebitar.Text = "Debitar";
            rAcreditar.Text = "Acreditar";
            InitializeComponent();

            cargar();
            tbImporte.Text = importe;
            lastEntityId = client.Id;
            rAcreditar.Checked = true;
            rDebitar.Checked = false;
            rDebitar.Enabled = false;
            calcular(lastEntityId);
            fillGrid();
            fillGridCuentas(lastEntityId);
            ApplicationLookAndFeel.ApplyThemeToAll(this);
        }

        private void Iniciar(int modo, Proveedor proveedor)
        {
            currentModo = modo;
            tipo = "Proveedor";
            InitializeComponent();
            lblTituloDebe.Text = "Pagado";
            lblTituloPago.Text = "Comprado";
            rDebitar.Text = "Pagar";
            rAcreditar.Text = "Comprar";
            cargar();
            lastEntityId = proveedor.Id;

            calcular(lastEntityId);
            fillGrid();
            fillGridCuentas(lastEntityId);
            ApplicationLookAndFeel.ApplyThemeToAll(this);
        }
        private int Id;

        private void bAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public Boolean Execute(int entityId)
        {
            Id = entityId;
            return ShowDialog() == DialogResult.OK;
        }

        void calcularBetweenDates(int entityId,  string desde, string hasta)
        {
            if (tipo.Equals("Cliente"))
            {
                //cuento cuantos movimientos tiene el cliente

                totalRegistros = FuncionesMovCuentas.contarRegistrosBetweenDates(entityId, desde, hasta);

                debe = pago = saldo = 0;
                dv = new DataView(tableMovCuentas);
                dv.RowFilter = "id_cliente = " + entityId.ToString();


            }
            else if (tipo.Equals("Proveedor"))
            {
                totalRegistros = FuncionesMovCuentas.contarRegistrosProveedoresBetweenDates(entityId, desde, hasta);

                debe = pago = saldo = 0;
                dv = new DataView(tableMovCuentas);
                dv.RowFilter = "id_proveedor = " + entityId.ToString();
            }

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
                {
                    FormMessageBox dialog = new FormMessageBox();
                    dialog.ShowErrorDialog("Hay un error de asiento");
                }
            }

            lblDebe.Text = debe.ToString("$ #,##0.00");
            lblPago.Text = pago.ToString("$ #,##0.00");
            saldo = pago - debe;
            lblSaldo.Text = saldo.ToString("$ #,##0.00");

            lblCantidad.Text = "Cantidad de movimientos: " + totalRegistros.ToString();
            DisplayPageInfo();

        }

        void calcular(int entitiId)
        {
            if (tipo.Equals("Cliente"))
            {
                //cuento cuantos movimientos tiene el cliente
                totalRegistros = FuncionesMovCuentas.contarRegistros(entitiId);
                debe = pago = saldo = 0;
                dv = new DataView(tableMovCuentas);
                dv.RowFilter = "id_cliente = " + entitiId.ToString();
            }
            else if (tipo.Equals("Proveedor"))
            {
                //cuento cuantos movimientos tiene el proveedor
                totalRegistros = FuncionesMovCuentas.contarRegistrosProveedores(entitiId);
                debe = pago = saldo = 0;
                dv = new DataView(tableMovCuentas);
                dv.RowFilter = "id_proveedor = " + entitiId.ToString();                
            }

            DataTable dvTemp = dv.ToTable();            

            //calculo a partir de la columna monto
            for (int a = 0; a < dvTemp.Rows.Count; a++)
            {
                if (Convert.ToInt16(dvTemp.Rows[a]["id_movimiento_tipo"]) == 1) //1 - DEBE
                    debe += Convert.ToDecimal(dvTemp.Rows[a]["monto"]);
                //debe es el negativo, lo que me debe 
                if (Convert.ToInt16(dvTemp.Rows[a]["id_movimiento_tipo"]) == 2) //2 - HABER
                    pago += Convert.ToDecimal(dvTemp.Rows[a]["monto"].ToString());
                //pagó es lo que pagó 
                if (Convert.ToInt16(dvTemp.Rows[a]["id_movimiento_tipo"]) != 2 && Convert.ToInt16(dvTemp.Rows[a]["id_movimiento_tipo"]) != 1)
				{
					FormMessageBox dialog = new FormMessageBox();
					dialog.ShowErrorDialog("Hay un error de asiento");
				}
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
            pageSize = ROWCOUNTPAGINATION;
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
                MyTextTimer.TStartFade("Ha llegado al inicio.", this.statusStripFormEntityInput, this.mensajeroFormEntityInput, MyTextTimer.TIME_SHORT);
            }
        }

        private void LoadPage(int cp, int reg)
        {
            if (tipo.Equals("Cliente"))
            {
                int ini = cp * reg;

                if (ini < totalRegistros)
                {
                    tableMovCuentasPaginator = FuncionesMovCuentas.fillPagina(lastEntityId, ini, reg);

                    //            debe = pago = saldo = 0;

                    if (tableMovCuentasPaginator.Rows.Count > 0)
                    {

                        dgvMovCuentasPaginado.DataSource = tableMovCuentasPaginator;
                        dgvMovCuentasPaginado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        for (int i = 0; i < dgvMovCuentasPaginado.Columns.Count; i++)
                        {
                            //dgvMovCuentasPaginado.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dgvMovCuentasPaginado.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            string name = dgvMovCuentasPaginado.Columns[i].Name;
                            if (name.ToUpper().Equals("ID") ||
                                name.ToUpper().Equals("USUARIO") ||
                                name.ToUpper().Equals("FECHABAJA") ||
                                name.ToUpper().Equals("ID_OPERACION") ||
                                name.ToUpper().Equals("ID1") ||
                                name.ToUpper().Equals("ID_CLIENTE") ||
                                name.ToUpper().Equals("ID_MOVIMIENTO_TIPO") ||
                                name.ToUpper().Equals("BANCO1") ||
                                name.ToUpper().Equals("ID_CUENTA") ||
                                name.ToUpper().Equals("ID_PROVEEDOR"))
                            {
                                dgvMovCuentasPaginado.Columns[i].Visible = false;
                                continue;
                            }
                        }

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
                    MyTextTimer.TStartFade("Ha llegado al final", this.statusStripFormEntityInput, this.mensajeroFormEntityInput, MyTextTimer.TIME_SHORT);
                }
            }
            else if (tipo.Equals("Proveedor"))
            {
                int ini = cp * reg;

                if (ini < totalRegistros)
                {
                    tableMovCuentasPaginator = FuncionesMovCuentas.fillPaginaProveedores(lastEntityId, ini, reg);

                    //            debe = pago = saldo = 0;

                    if (tableMovCuentasPaginator.Rows.Count > 0)
                    {

                        dgvMovCuentasPaginado.DataSource = tableMovCuentasPaginator;
                        dgvMovCuentasPaginado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        for (int i = 0; i < dgvMovCuentasPaginado.Columns.Count; i++)
                        {
                            //dgvMovCuentasPaginado.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dgvMovCuentasPaginado.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            string name = dgvMovCuentasPaginado.Columns[i].Name;
                            if (name.ToUpper().Equals("ID") ||
                                name.ToUpper().Equals("USUARIO") ||
                                name.ToUpper().Equals("FECHABAJA") ||
                                name.ToUpper().Equals("ID_OPERACION") ||
                                name.ToUpper().Equals("ID1") ||
                                name.ToUpper().Equals("ID_CLIENTE") ||
                                name.ToUpper().Equals("ID_MOVIMIENTO_TIPO") ||
                                name.ToUpper().Equals("BANCO1") ||
                                name.ToUpper().Equals("BANCO1") ||
                                name.ToUpper().Equals("ID_CUENTA") ||
                                name.ToUpper().Equals("ID_PROVEEDOR"))
                            {
                                dgvMovCuentasPaginado.Columns[i].Visible = false;
                                continue;
                            }
                        }

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
                    MyTextTimer.TStartFade("Ha llegado al final", this.statusStripFormEntityInput, this.mensajeroFormEntityInput, MyTextTimer.TIME_SHORT);
                }
            }


        }

        private void LoadPage(int cp, int reg, string dDesde, string dHasta)
        {
            if (tipo.Equals("Cliente"))
            {
                int ini = cp * reg;

                if (ini < totalRegistros)
                {
                    tableMovCuentasPaginator = FuncionesMovCuentas.fillPaginaBetweenDates(lastEntityId, ini, reg, dDesde, dHasta);

                    //            debe = pago = saldo = 0;

                    if (tableMovCuentasPaginator.Rows.Count > 0)
                    {
                        dgvMovCuentasPaginado.DataSource = tableMovCuentasPaginator;
                        dgvMovCuentasPaginado.AutoResizeColumns();

                        verMenos(false);
                        dgvMovCuentasPaginado.Columns["monto"].Width = 140;
                        dgvMovCuentasPaginado.Columns["monto"].DefaultCellStyle.Format = "c";
                        dgvMovCuentasPaginado.Columns["monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        //dgvMovCuentasPaginado.Columns["cobrado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
                    MyTextTimer.TStartFade("Ha llegado al final", this.statusStripFormEntityInput, this.mensajeroFormEntityInput, MyTextTimer.TIME_SHORT);
                }
            }
            else if (tipo.Equals("Proveedor"))
            {
                int ini = cp * reg;

                if (ini < totalRegistros)
                {
                    tableMovCuentasPaginator = FuncionesMovCuentas.fillPaginaProveedoresBetweenDates(lastEntityId, ini, reg, dDesde, dHasta);

                    //            debe = pago = saldo = 0;

                    if (tableMovCuentasPaginator.Rows.Count > 0)
                    {
                        dgvMovCuentasPaginado.DataSource = tableMovCuentasPaginator;
                        dgvMovCuentasPaginado.AutoResizeColumns();

                        verMenos(false);
                        dgvMovCuentasPaginado.Columns["monto"].Width = 140;
                        dgvMovCuentasPaginado.Columns["monto"].DefaultCellStyle.Format = "c";
                        dgvMovCuentasPaginado.Columns["monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        //dgvMovCuentasPaginado.Columns["cobrado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
                    MyTextTimer.TStartFade("Ha llegado al final", this.statusStripFormEntityInput, this.mensajeroFormEntityInput, MyTextTimer.TIME_SHORT);
                }
            }
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
            tbImporte.Clear();

            string consulta = string.Empty;
            if (tipo.Equals("Cliente"))
            {
                // Trae clientes con cuenta 
                //consulta = QueryManager.Instance().GetClientesWithCuenta();
                //table = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);

                //lleno movCuentas
                tableMovCuentas = FuncionesMovCuentas.fillMovCuentas();
            }
            else if (tipo.Equals("Proveedor"))
            {
                //consulta = QueryManager.Instance().GetProveedoresWithCuenta();
                //table = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);

                //lleno movCuentas
                tableMovCuentas = FuncionesMovCuentas.fillMovCuentasProveedores();
            }

            switch (currentModo)
            {
                case 0:
                    break;
                case 1:
                    labelTitulo.Text = "Agregar nuevo movimiento.";
                    tableAgregarMovimiento.BringToFront();
                    msFiltro.Visible = false;
                    break;
                case 2:
                    labelTitulo.Text = "Ver Operaciones";
                    plGridPaginado.BringToFront();
                    msFiltro.Visible = true;
                    break;
            }           
        }

        void fillGridCuentas(int entityId)
        {
            if (tipo.Equals("Cliente"))
            {
                tableCuentas = FuncionesMovCuentas.fillCuentasByCliente(entityId);
                dgvCuentas.DataSource = tableCuentas;
                dgvCuentas.AllowUserToAddRows = false;
                for (int i = 0; i < dgvCuentas.ColumnCount; i++)
                {
                    dgvCuentas.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    if (dgvCuentas.Columns[i].Name.ToUpper().Equals("ID_CUENTA"))
                    {
                        dgvCuentas.Columns[i].Visible = false;
                    }
                }
            }else if (tipo.Equals("Proveedor"))
            {
                tableCuentas = FuncionesMovCuentas.fillCuentasByProveedor(entityId);
                dgvCuentas.DataSource = tableCuentas;
                dgvCuentas.AllowUserToAddRows = false;
                for (int i = 0; i < dgvCuentas.ColumnCount; i++)
                {
                    dgvCuentas.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    if (dgvCuentas.Columns[i].Name.ToUpper().Equals("ID_CUENTA"))
                    {
                        dgvCuentas.Columns[i].Visible = false;
                    }
                }
            }
            
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

        private void btFiltroFecha_Click(object sender, EventArgs e)
        {

            if (btFiltroFecha.Text.Equals("Aplicar"))
            {
                string d = dtpDesde.Value.ToString("yyyy-MM-dd");
                string h = dtpHasta.Value.ToString("yyyy-MM-dd");
                calcularBetweenDates(lastEntityId,d,h);
                fillGridBetweenDates(d,h);
                btFiltroFecha.Text = "Quitar";
            }else if (btFiltroFecha.Text.Equals("Quitar"))
            {
                calcular(lastEntityId);
                fillGrid();
                btFiltroFecha.Text = "Aplicar";
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
				FormMessageBox dialog = new FormMessageBox();
				dialog.ShowErrorDialog("Ha ocurrido un error: " + ex.Message);				
            }
        }
        void enviar()
        {
            // Se toma el valor que este seleccionado en la grid para tomar la cuenta
            lastCuenta = (int)dgvCuentas["id_cuenta", dgvCuentas.CurrentCell.RowIndex].Value;

            if (tipo.Equals("Cliente"))
            {
                MovimientoCuenta movCuenta1 = new MovimientoCuenta();
                TipoMovimiento tp = new TipoMovimiento();
                Cuenta cuenta = new Cuenta();
                Operacion newOperacion = new Operacion();
                TipoOperacion to = new TipoOperacion();

                to.Id = 2;

                VariablesGlobales.idOperacion = FuncionesOperaciones.GetNextIdOperacion();

                newOperacion.Id = VariablesGlobales.idOperacion;

                newOperacion.tipoOperacion = to;
                
                newOperacion.idUsuario = VariablesGlobales.userIdLogueado;

                VariablesGlobales.FormMovCuentas_activo = true;

                cuenta = FuncionesClientes.GetCuentaById(lastCuenta);

                Cliente cliente = FuncionesClientes.GetClienteById(lastEntityId);

                newOperacion.cliente = cliente;

                if (cliente != null)
                {
                    string op = string.Empty;
                    if (rDebitar.Checked)
                    {
                        op = "debitar";
                        tp.Id = 1;
                    }
                    else
                    {
                        op = "acreditar";
                        tp.Id = 2;
                    }

                    string textDialog = "¿Esta seguro que desea " + op + " $" + tbImporte.Text + " al cliente: " + cliente.RazonSocial + " ?";
                    FormMessageBox dialog = new FormMessageBox();
                    if (dialog.ShowConfirmationDialog(textDialog))
                    {
                        movCuenta1.TipoMovimiento = tp;

                        movCuenta1.Operacion = newOperacion;

                        movCuenta1.Cuenta = cuenta;
                        Decimal montoto = Convert.ToDecimal(tbImporte.Text);
                        movCuenta1.Monto = montoto;
                        movCuenta1.Fecha = DateTime.Now.AddDays(0);
                        movCuenta1.Cobrado = 'N';
                        movCuenta1.idUsuario = VariablesGlobales.userIdLogueado;


                        if (FuncionesMovCuentas.insertarMovimiento(movCuenta1))
                        {
                            //inserto la operacion

                            if (FuncionesOperaciones.insertarOperacion(newOperacion))
                            {
                                if (tp.Id.Equals(1))
                                {
                                    MyTextTimer.TStartFade("Debito realizado. ", this.statusStripFormEntityInput, this.mensajeroFormEntityInput, MyTextTimer.TIME_LONG);
                                }
                                else
                                {
                                    MyTextTimer.TStartFade("Acreditacion realizada.", this.statusStripFormEntityInput, this.mensajeroFormEntityInput, MyTextTimer.TIME_LONG);
                                }
                            }
                            cargar();

                            tableMovCuentas.AcceptChanges();

                            calcular(lastEntityId);

                            //obtengo el idMovCuenta para Venta Mayorista

                            VariablesGlobales.idMovCuenta_VentaMay = FuncionesMovCuentas.GetNextIdMovCuenta();
                            VariablesGlobales.Cuenta_VentaMay = cuenta;
                        };

                        


                    }
                }
            }
            else if (tipo.Equals("Proveedor"))
            {
                MovimientoCuenta movCuenta1 = new MovimientoCuenta();
                TipoMovimiento tp = new TipoMovimiento();
                Cuenta cuenta = new Cuenta();

                VariablesGlobales.FormMovCuentas_activo = true;

                cuenta = FuncionesClientes.GetCuentaById(lastCuenta);
                Operacion newOperacion = new Operacion();

                newOperacion.Id = VariablesGlobales.idOperacion;

                Proveedor prov = FuncionesProveedores.GetProveedorById(lastEntityId);

                if (prov != null)
                {
                    string op = string.Empty;
                    if (rDebitar.Checked)
                    {
                        op = "debitar";
                        tp.Id = 1;
                    }
                    else
                    {
                        op = "acreditar";
                        tp.Id = 2;
                    }

                    string textDialog = "¿Esta seguro que desea " + op + " $" + tbImporte.Text + " al proveedor: " + prov.RazonSocial + " ?";
                    FormMessageBox dialog = new FormMessageBox();
                    if (dialog.ShowConfirmationDialog(textDialog))
                    {
                        movCuenta1.TipoMovimiento = tp;

                        movCuenta1.Operacion = newOperacion;

                        movCuenta1.Cuenta = cuenta;
                        Decimal montoto = Convert.ToDecimal(tbImporte.Text);
                        movCuenta1.Monto = montoto;
                        movCuenta1.Fecha = DateTime.Now.AddDays(0);
                        movCuenta1.Cobrado = 'N';
                        movCuenta1.idUsuario = VariablesGlobales.userIdLogueado;

                        if (FuncionesMovCuentas.insertarMovimientoProveedor(movCuenta1))
                        {
                            if (tp.Id.Equals(1))
                            {
                                MyTextTimer.TStartFade("Debito realizado. ", this.statusStripFormEntityInput, this.mensajeroFormEntityInput, MyTextTimer.TIME_LONG);
                            }
                            else
                            {
                                MyTextTimer.TStartFade("Acreditacion realizada.", this.statusStripFormEntityInput, this.mensajeroFormEntityInput, MyTextTimer.TIME_LONG);
                            }

                            cargar();

                            tableMovCuentas.AcceptChanges();

                            calcular(lastEntityId);
                        };
                    }
                }
            }

        }

       

        private void dgvCuentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lastCuenta = (int)dgvCuentas["id_cuenta", dgvCuentas.CurrentCell.RowIndex].Value;
        }
        
        private void fillGridBetweenDates(string fechaDesde, string fechaHasta)
        {
            pageCount = 0;
            currentPage = 0;
            pageSize = ROWCOUNTPAGINATION;
            pageCount = (totalRegistros / pageSize) + 1;
            LoadPage(0, pageSize, fechaDesde, fechaHasta);
            DisplayPageInfo();
        }

      


    }


}
