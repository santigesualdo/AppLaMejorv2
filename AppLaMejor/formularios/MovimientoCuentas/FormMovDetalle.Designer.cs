using AppLaMejor.stylemanager;
namespace AppLaMejor.formularios.Util
{
    partial class FormMovDetalle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.plResumen = new System.Windows.Forms.Panel();
            this.lblTituloPago = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.lblDebe = new System.Windows.Forms.Label();
            this.lblTituloSaldo = new System.Windows.Forms.Label();
            this.lblPago = new System.Windows.Forms.Label();
            this.lblTituloDebe = new System.Windows.Forms.Label();
            this.plOperacion = new System.Windows.Forms.Panel();
            this.btEnviar = new System.Windows.Forms.Button();
            this.tbImporte = new System.Windows.Forms.TextBox();
            this.cmbBoton = new System.Windows.Forms.ComboBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.plGridPaginado = new System.Windows.Forms.Panel();
            this.plNavegacion = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.txtDisplayPageNo = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.dgvMovCuentasPaginado = new System.Windows.Forms.DataGridView();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.bAceptar = new System.Windows.Forms.Button();
            this.bCancelar = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.formTittleText = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.epMovCuentas = new System.Windows.Forms.ErrorProvider(this.components);
            this.msFiltro = new System.Windows.Forms.MenuStrip();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.xzxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plFiltro = new System.Windows.Forms.Panel();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btFiltrar = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.plResumen.SuspendLayout();
            this.plOperacion.SuspendLayout();
            this.plGridPaginado.SuspendLayout();
            this.plNavegacion.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovCuentasPaginado)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epMovCuentas)).BeginInit();
            this.msFiltro.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.plFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.contentPanel);
            this.mainPanel.Controls.Add(this.bottomPanel);
            this.mainPanel.Controls.Add(this.topPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(622, 738);
            this.mainPanel.TabIndex = 4;
            // 
            // contentPanel
            // 
            this.contentPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contentPanel.Controls.Add(this.plFiltro);
            this.contentPanel.Controls.Add(this.toolStripContainer1);
            this.contentPanel.Controls.Add(this.plResumen);
            this.contentPanel.Controls.Add(this.plOperacion);
            this.contentPanel.Controls.Add(this.plGridPaginado);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 51);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(15);
            this.contentPanel.Size = new System.Drawing.Size(622, 655);
            this.contentPanel.TabIndex = 3;
            // 
            // plResumen
            // 
            this.plResumen.Controls.Add(this.lblTituloPago);
            this.plResumen.Controls.Add(this.lblSaldo);
            this.plResumen.Controls.Add(this.lblDebe);
            this.plResumen.Controls.Add(this.lblTituloSaldo);
            this.plResumen.Controls.Add(this.lblPago);
            this.plResumen.Controls.Add(this.lblTituloDebe);
            this.plResumen.Location = new System.Drawing.Point(12, 512);
            this.plResumen.Name = "plResumen";
            this.plResumen.Size = new System.Drawing.Size(273, 100);
            this.plResumen.TabIndex = 33;
            // 
            // lblTituloPago
            // 
            this.lblTituloPago.AutoSize = true;
            this.lblTituloPago.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPago.Location = new System.Drawing.Point(39, 39);
            this.lblTituloPago.Name = "lblTituloPago";
            this.lblTituloPago.Size = new System.Drawing.Size(51, 18);
            this.lblTituloPago.TabIndex = 27;
            this.lblTituloPago.Text = "Pagó:";
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.Location = new System.Drawing.Point(160, 61);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(74, 23);
            this.lblSaldo.TabIndex = 29;
            this.lblSaldo.Text = "$ 0.00";
            // 
            // lblDebe
            // 
            this.lblDebe.AutoSize = true;
            this.lblDebe.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebe.Location = new System.Drawing.Point(146, 18);
            this.lblDebe.Name = "lblDebe";
            this.lblDebe.Size = new System.Drawing.Size(0, 18);
            this.lblDebe.TabIndex = 26;
            // 
            // lblTituloSaldo
            // 
            this.lblTituloSaldo.AutoSize = true;
            this.lblTituloSaldo.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloSaldo.Location = new System.Drawing.Point(37, 61);
            this.lblTituloSaldo.Name = "lblTituloSaldo";
            this.lblTituloSaldo.Size = new System.Drawing.Size(75, 23);
            this.lblTituloSaldo.TabIndex = 30;
            this.lblTituloSaldo.Text = "Saldo:";
            // 
            // lblPago
            // 
            this.lblPago.AutoSize = true;
            this.lblPago.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPago.Location = new System.Drawing.Point(146, 39);
            this.lblPago.Name = "lblPago";
            this.lblPago.Size = new System.Drawing.Size(0, 18);
            this.lblPago.TabIndex = 25;
            // 
            // lblTituloDebe
            // 
            this.lblTituloDebe.AutoSize = true;
            this.lblTituloDebe.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloDebe.Location = new System.Drawing.Point(39, 18);
            this.lblTituloDebe.Name = "lblTituloDebe";
            this.lblTituloDebe.Size = new System.Drawing.Size(53, 18);
            this.lblTituloDebe.TabIndex = 28;
            this.lblTituloDebe.Text = "Debe:";
            // 
            // plOperacion
            // 
            this.plOperacion.Controls.Add(this.btEnviar);
            this.plOperacion.Controls.Add(this.tbImporte);
            this.plOperacion.Controls.Add(this.cmbBoton);
            this.plOperacion.Controls.Add(this.lblImporte);
            this.plOperacion.Location = new System.Drawing.Point(18, 18);
            this.plOperacion.Name = "plOperacion";
            this.plOperacion.Size = new System.Drawing.Size(576, 300);
            this.plOperacion.TabIndex = 22;
            // 
            // btEnviar
            // 
            this.btEnviar.FlatAppearance.BorderSize = 2;
            this.btEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEnviar.Location = new System.Drawing.Point(226, 170);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(156, 34);
            this.btEnviar.TabIndex = 29;
            this.btEnviar.Text = "DEBITAR!";
            this.btEnviar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btEnviar.UseVisualStyleBackColor = true;
            this.btEnviar.Click += new System.EventHandler(this.btEnviar_Click);
            // 
            // tbImporte
            // 
            this.tbImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbImporte.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbImporte.Location = new System.Drawing.Point(226, 124);
            this.tbImporte.Name = "tbImporte";
            this.tbImporte.Size = new System.Drawing.Size(178, 26);
            this.tbImporte.TabIndex = 3;
            this.tbImporte.TextChanged += new System.EventHandler(this.tbImporte_TextChanged);
            this.tbImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbImporte_KeyPress);
            // 
            // cmbBoton
            // 
            this.cmbBoton.DisplayMember = "1";
            this.cmbBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBoton.FormattingEnabled = true;
            this.cmbBoton.Items.AddRange(new object[] {
            "DEBITAR!",
            "ACREDITAR!"});
            this.cmbBoton.Location = new System.Drawing.Point(226, 171);
            this.cmbBoton.Name = "cmbBoton";
            this.cmbBoton.Size = new System.Drawing.Size(178, 33);
            this.cmbBoton.TabIndex = 13;
            this.cmbBoton.ValueMember = "1";
            this.cmbBoton.SelectedIndexChanged += new System.EventHandler(this.cmbBoton_SelectedIndexChanged);
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporte.Location = new System.Drawing.Point(149, 126);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(70, 18);
            this.lblImporte.TabIndex = 10;
            this.lblImporte.Text = "Importe:";
            // 
            // plGridPaginado
            // 
            this.plGridPaginado.Controls.Add(this.plNavegacion);
            this.plGridPaginado.Controls.Add(this.dgvMovCuentasPaginado);
            this.plGridPaginado.Location = new System.Drawing.Point(21, 32);
            this.plGridPaginado.Name = "plGridPaginado";
            this.plGridPaginado.Size = new System.Drawing.Size(573, 573);
            this.plGridPaginado.TabIndex = 32;
            // 
            // plNavegacion
            // 
            this.plNavegacion.Controls.Add(this.tableLayoutPanel1);
            this.plNavegacion.Controls.Add(this.lblCantidad);
            this.plNavegacion.Location = new System.Drawing.Point(320, 470);
            this.plNavegacion.Name = "plNavegacion";
            this.plNavegacion.Size = new System.Drawing.Size(226, 100);
            this.plNavegacion.TabIndex = 32;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.06202F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.93798F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.Controls.Add(this.btnPreviousPage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNextPage, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDisplayPageNo, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 49);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(197, 48);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPreviousPage.FlatAppearance.BorderSize = 2;
            this.btnPreviousPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousPage.Location = new System.Drawing.Point(7, 11);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(45, 26);
            this.btnPreviousPage.TabIndex = 28;
            this.btnPreviousPage.Text = "<<";
            this.btnPreviousPage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNextPage.FlatAppearance.BorderSize = 2;
            this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPage.Location = new System.Drawing.Point(137, 11);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(45, 26);
            this.btnNextPage.TabIndex = 27;
            this.btnNextPage.Text = ">>";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // txtDisplayPageNo
            // 
            this.txtDisplayPageNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDisplayPageNo.AutoSize = true;
            this.txtDisplayPageNo.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisplayPageNo.Location = new System.Drawing.Point(82, 12);
            this.txtDisplayPageNo.Name = "txtDisplayPageNo";
            this.txtDisplayPageNo.Size = new System.Drawing.Size(17, 23);
            this.txtDisplayPageNo.TabIndex = 29;
            this.txtDisplayPageNo.Text = "-";
            this.txtDisplayPageNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(-3, 22);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(165, 18);
            this.lblCantidad.TabIndex = 31;
            this.lblCantidad.Text = "Cantidad de registro";
            this.lblCantidad.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dgvMovCuentasPaginado
            // 
            this.dgvMovCuentasPaginado.AllowUserToAddRows = false;
            this.dgvMovCuentasPaginado.AllowUserToDeleteRows = false;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvMovCuentasPaginado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle29;
            this.dgvMovCuentasPaginado.BackgroundColor = System.Drawing.Color.Black;
            this.dgvMovCuentasPaginado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle30.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMovCuentasPaginado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle30;
            this.dgvMovCuentasPaginado.ColumnHeadersHeight = 40;
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle31.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle31.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMovCuentasPaginado.DefaultCellStyle = dataGridViewCellStyle31;
            this.dgvMovCuentasPaginado.EnableHeadersVisualStyles = false;
            this.dgvMovCuentasPaginado.GridColor = System.Drawing.Color.Green;
            this.dgvMovCuentasPaginado.Location = new System.Drawing.Point(3, -9);
            this.dgvMovCuentasPaginado.Name = "dgvMovCuentasPaginado";
            this.dgvMovCuentasPaginado.ReadOnly = true;
            this.dgvMovCuentasPaginado.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMovCuentasPaginado.RowHeadersDefaultCellStyle = dataGridViewCellStyle32;
            this.dgvMovCuentasPaginado.RowHeadersVisible = false;
            this.dgvMovCuentasPaginado.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvMovCuentasPaginado.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvMovCuentasPaginado.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.dgvMovCuentasPaginado.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMovCuentasPaginado.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMovCuentasPaginado.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Green;
            this.dgvMovCuentasPaginado.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvMovCuentasPaginado.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMovCuentasPaginado.RowTemplate.Height = 35;
            this.dgvMovCuentasPaginado.RowTemplate.ReadOnly = true;
            this.dgvMovCuentasPaginado.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMovCuentasPaginado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovCuentasPaginado.Size = new System.Drawing.Size(543, 419);
            this.dgvMovCuentasPaginado.TabIndex = 1;
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Green;
            this.bottomPanel.Controls.Add(this.statusStrip1);
            this.bottomPanel.Controls.Add(this.bAceptar);
            this.bottomPanel.Controls.Add(this.bCancelar);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 706);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(622, 32);
            this.bottomPanel.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslMensaje});
            this.statusStrip1.Location = new System.Drawing.Point(0, 9);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(222, 23);
            this.statusStrip1.TabIndex = 30;
            this.statusStrip1.Text = "ssMensajero";
            // 
            // tsslMensaje
            // 
            this.tsslMensaje.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsslMensaje.Name = "tsslMensaje";
            this.tsslMensaje.Size = new System.Drawing.Size(85, 18);
            this.tsslMensaje.Text = "Mensajero";
            // 
            // bAceptar
            // 
            this.bAceptar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bAceptar.BackColor = System.Drawing.Color.Black;
            this.bAceptar.Dock = System.Windows.Forms.DockStyle.Right;
            this.bAceptar.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.bAceptar.FlatAppearance.BorderSize = 2;
            this.bAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.bAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.bAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAceptar.Location = new System.Drawing.Point(222, 0);
            this.bAceptar.MinimumSize = new System.Drawing.Size(150, 30);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(200, 32);
            this.bAceptar.TabIndex = 21;
            this.bAceptar.Text = "Aceptar";
            this.bAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bAceptar.UseVisualStyleBackColor = false;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.BackColor = System.Drawing.Color.Black;
            this.bCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.bCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.bCancelar.FlatAppearance.BorderSize = 2;
            this.bCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.bCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.bCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCancelar.Location = new System.Drawing.Point(422, 0);
            this.bCancelar.MinimumSize = new System.Drawing.Size(150, 30);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(200, 32);
            this.bCancelar.TabIndex = 20;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bCancelar.UseVisualStyleBackColor = false;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.topPanel.Controls.Add(this.formTittleText);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(622, 51);
            this.topPanel.TabIndex = 1;
            // 
            // formTittleText
            // 
            this.formTittleText.BackColor = System.Drawing.Color.Green;
            this.formTittleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formTittleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formTittleText.Location = new System.Drawing.Point(0, 0);
            this.formTittleText.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.formTittleText.Name = "formTittleText";
            this.formTittleText.Size = new System.Drawing.Size(622, 51);
            this.formTittleText.TabIndex = 0;
            this.formTittleText.Text = "Detalle";
            this.formTittleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            // 
            // epMovCuentas
            // 
            this.epMovCuentas.ContainerControl = this;
            // 
            // msFiltro
            // 
            this.msFiltro.Dock = System.Windows.Forms.DockStyle.None;
            this.msFiltro.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.msFiltro.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xzxToolStripMenuItem});
            this.msFiltro.Location = new System.Drawing.Point(0, 0);
            this.msFiltro.Name = "msFiltro";
            this.msFiltro.Size = new System.Drawing.Size(619, 24);
            this.msFiltro.TabIndex = 34;
            this.msFiltro.Text = "menuStrip1";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(619, 2);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(619, 26);
            this.toolStripContainer1.TabIndex = 5;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.msFiltro);
            // 
            // xzxToolStripMenuItem
            // 
            this.xzxToolStripMenuItem.Name = "xzxToolStripMenuItem";
            this.xzxToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.xzxToolStripMenuItem.Text = "Filtrar por fechas";
            this.xzxToolStripMenuItem.Click += new System.EventHandler(this.xzxToolStripMenuItem_Click);
            // 
            // plFiltro
            // 
            this.plFiltro.Controls.Add(this.btFiltrar);
            this.plFiltro.Controls.Add(this.dtpHasta);
            this.plFiltro.Controls.Add(this.dtpDesde);
            this.plFiltro.Controls.Add(this.lblHasta);
            this.plFiltro.Controls.Add(this.lblDesde);
            this.plFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plFiltro.Location = new System.Drawing.Point(15, 15);
            this.plFiltro.Name = "plFiltro";
            this.plFiltro.Size = new System.Drawing.Size(592, 625);
            this.plFiltro.TabIndex = 30;
            this.plFiltro.Visible = false;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesde.Location = new System.Drawing.Point(13, 161);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(62, 18);
            this.lblDesde.TabIndex = 10;
            this.lblDesde.Text = "Desde:";
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHasta.Location = new System.Drawing.Point(323, 159);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(57, 18);
            this.lblHasta.TabIndex = 11;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(114, 159);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(133, 20);
            this.dtpDesde.TabIndex = 12;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(419, 159);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(133, 20);
            this.dtpHasta.TabIndex = 13;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // btFiltrar
            // 
            this.btFiltrar.FlatAppearance.BorderSize = 2;
            this.btFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFiltrar.Location = new System.Drawing.Point(229, 364);
            this.btFiltrar.Name = "btFiltrar";
            this.btFiltrar.Size = new System.Drawing.Size(133, 34);
            this.btFiltrar.TabIndex = 30;
            this.btFiltrar.Text = "Filtrar";
            this.btFiltrar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btFiltrar.UseVisualStyleBackColor = true;
            this.btFiltrar.Click += new System.EventHandler(this.btFiltrar_Click);
            // 
            // FormMovDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(622, 738);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.MainMenuStrip = this.msFiltro;
            this.Name = "FormMovDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormClientes";
            this.mainPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.plResumen.ResumeLayout(false);
            this.plResumen.PerformLayout();
            this.plOperacion.ResumeLayout(false);
            this.plOperacion.PerformLayout();
            this.plGridPaginado.ResumeLayout(false);
            this.plNavegacion.ResumeLayout(false);
            this.plNavegacion.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovCuentasPaginado)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epMovCuentas)).EndInit();
            this.msFiltro.ResumeLayout(false);
            this.msFiltro.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.plFiltro.ResumeLayout(false);
            this.plFiltro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label formTittleText;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslMensaje;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ErrorProvider epMovCuentas;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label lblTituloSaldo;
        private System.Windows.Forms.Label lblTituloPago;
        private System.Windows.Forms.Label lblPago;
        private System.Windows.Forms.Label lblDebe;
        private System.Windows.Forms.Label lblTituloDebe;
        private System.Windows.Forms.TextBox tbImporte;
        private System.Windows.Forms.ComboBox cmbBoton;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Panel plOperacion;
        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.Panel plGridPaginado;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Label txtDisplayPageNo;
        private System.Windows.Forms.DataGridView dgvMovCuentasPaginado;
        private System.Windows.Forms.Panel plNavegacion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel plResumen;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip msFiltro;
        private System.Windows.Forms.ToolStripMenuItem xzxToolStripMenuItem;
        private System.Windows.Forms.Panel plFiltro;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btFiltrar;

        }



}