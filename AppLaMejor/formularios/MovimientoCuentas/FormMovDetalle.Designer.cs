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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.plOperacion = new System.Windows.Forms.Panel();
            this.tableAgregarMovimiento = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvCuentas = new System.Windows.Forms.DataGridView();
            this.panelImporte = new System.Windows.Forms.Panel();
            this.btEnviar = new System.Windows.Forms.Button();
            this.rAcreditar = new System.Windows.Forms.RadioButton();
            this.rDebitar = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbImporte = new System.Windows.Forms.TextBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.plGridPaginado = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.plNavegacion = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.txtDisplayPageNo = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.dgvMovCuentasPaginado = new System.Windows.Forms.DataGridView();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.plResumen = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDebe = new System.Windows.Forms.Label();
            this.lblTituloDebe = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPago = new System.Windows.Forms.Label();
            this.lblTituloPago = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.lblTituloSaldo = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.msFiltro = new System.Windows.Forms.Panel();
            this.filter2Panel = new System.Windows.Forms.Panel();
            this.tableFiltroFecha = new System.Windows.Forms.TableLayoutPanel();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.btFiltroFecha = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.tableBottomPanel = new System.Windows.Forms.TableLayoutPanel();
            this.bCancelar = new System.Windows.Forms.Button();
            this.bAceptar = new System.Windows.Forms.Button();
            this.statusStripFormEntityInput = new System.Windows.Forms.StatusStrip();
            this.mensajeroFormEntityInput = new System.Windows.Forms.ToolStripStatusLabel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.formTittleText = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.epMovCuentas = new System.Windows.Forms.ErrorProvider(this.components);
            this.mainPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.plOperacion.SuspendLayout();
            this.tableAgregarMovimiento.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).BeginInit();
            this.panelImporte.SuspendLayout();
            this.plGridPaginado.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.plNavegacion.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovCuentasPaginado)).BeginInit();
            this.plResumen.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.msFiltro.SuspendLayout();
            this.filter2Panel.SuspendLayout();
            this.tableFiltroFecha.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.tableBottomPanel.SuspendLayout();
            this.statusStripFormEntityInput.SuspendLayout();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epMovCuentas)).BeginInit();
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
            this.mainPanel.Size = new System.Drawing.Size(737, 741);
            this.mainPanel.TabIndex = 4;
            // 
            // contentPanel
            // 
            this.contentPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contentPanel.Controls.Add(this.plOperacion);
            this.contentPanel.Controls.Add(this.plResumen);
            this.contentPanel.Controls.Add(this.msFiltro);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 51);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(15);
            this.contentPanel.Size = new System.Drawing.Size(737, 648);
            this.contentPanel.TabIndex = 3;
            // 
            // plOperacion
            // 
            this.plOperacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.plOperacion.Controls.Add(this.tableAgregarMovimiento);
            this.plOperacion.Controls.Add(this.plGridPaginado);
            this.plOperacion.Controls.Add(this.labelTitulo);
            this.plOperacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plOperacion.Location = new System.Drawing.Point(15, 93);
            this.plOperacion.Name = "plOperacion";
            this.plOperacion.Size = new System.Drawing.Size(707, 425);
            this.plOperacion.TabIndex = 22;
            // 
            // tableAgregarMovimiento
            // 
            this.tableAgregarMovimiento.ColumnCount = 1;
            this.tableAgregarMovimiento.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableAgregarMovimiento.Controls.Add(this.groupBox1, 0, 0);
            this.tableAgregarMovimiento.Controls.Add(this.panelImporte, 0, 1);
            this.tableAgregarMovimiento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableAgregarMovimiento.Location = new System.Drawing.Point(0, 33);
            this.tableAgregarMovimiento.Name = "tableAgregarMovimiento";
            this.tableAgregarMovimiento.RowCount = 2;
            this.tableAgregarMovimiento.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableAgregarMovimiento.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableAgregarMovimiento.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableAgregarMovimiento.Size = new System.Drawing.Size(707, 392);
            this.tableAgregarMovimiento.TabIndex = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvCuentas);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(701, 111);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de Cuentas";
            // 
            // dgvCuentas
            // 
            this.dgvCuentas.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCuentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCuentas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCuentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCuentas.Location = new System.Drawing.Point(3, 16);
            this.dgvCuentas.Name = "dgvCuentas";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCuentas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCuentas.Size = new System.Drawing.Size(695, 92);
            this.dgvCuentas.TabIndex = 33;
            this.dgvCuentas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCuentas_CellClick);
            // 
            // panelImporte
            // 
            this.panelImporte.Controls.Add(this.btEnviar);
            this.panelImporte.Controls.Add(this.rAcreditar);
            this.panelImporte.Controls.Add(this.rDebitar);
            this.panelImporte.Controls.Add(this.label2);
            this.panelImporte.Controls.Add(this.label1);
            this.panelImporte.Controls.Add(this.tbImporte);
            this.panelImporte.Controls.Add(this.lblImporte);
            this.panelImporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImporte.Location = new System.Drawing.Point(3, 120);
            this.panelImporte.Name = "panelImporte";
            this.panelImporte.Size = new System.Drawing.Size(701, 269);
            this.panelImporte.TabIndex = 31;
            // 
            // btEnviar
            // 
            this.btEnviar.AutoSize = true;
            this.btEnviar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btEnviar.BackColor = System.Drawing.Color.Black;
            this.btEnviar.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btEnviar.FlatAppearance.BorderSize = 2;
            this.btEnviar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEnviar.Location = new System.Drawing.Point(13, 233);
            this.btEnviar.MinimumSize = new System.Drawing.Size(100, 30);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Padding = new System.Windows.Forms.Padding(10);
            this.btEnviar.Size = new System.Drawing.Size(182, 50);
            this.btEnviar.TabIndex = 39;
            this.btEnviar.Text = "Confirmar operacion";
            this.btEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btEnviar.UseVisualStyleBackColor = false;
            this.btEnviar.Click += new System.EventHandler(this.btEnviar_Click);
            // 
            // rAcreditar
            // 
            this.rAcreditar.AutoSize = true;
            this.rAcreditar.Location = new System.Drawing.Point(157, 95);
            this.rAcreditar.Name = "rAcreditar";
            this.rAcreditar.Size = new System.Drawing.Size(67, 17);
            this.rAcreditar.TabIndex = 38;
            this.rAcreditar.Text = "Acreditar";
            this.rAcreditar.UseVisualStyleBackColor = true;
            // 
            // rDebitar
            // 
            this.rDebitar.AutoSize = true;
            this.rDebitar.Checked = true;
            this.rDebitar.Location = new System.Drawing.Point(51, 95);
            this.rDebitar.Name = "rDebitar";
            this.rDebitar.Size = new System.Drawing.Size(59, 17);
            this.rDebitar.TabIndex = 37;
            this.rDebitar.TabStop = true;
            this.rDebitar.Text = "Debitar";
            this.rDebitar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 25);
            this.label2.TabIndex = 36;
            this.label2.Tag = "bold big";
            this.label2.Text = "Completar Operación";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 30;
            this.label1.Tag = "big";
            this.label1.Text = "Tipo Movimiento";
            // 
            // tbImporte
            // 
            this.tbImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbImporte.Location = new System.Drawing.Point(51, 166);
            this.tbImporte.Name = "tbImporte";
            this.tbImporte.Size = new System.Drawing.Size(178, 26);
            this.tbImporte.TabIndex = 3;
            this.tbImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbImporte_KeyPress);
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporte.Location = new System.Drawing.Point(10, 134);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(64, 20);
            this.lblImporte.TabIndex = 10;
            this.lblImporte.Text = "Importe";
            // 
            // plGridPaginado
            // 
            this.plGridPaginado.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.plGridPaginado.BackColor = System.Drawing.Color.Silver;
            this.plGridPaginado.Controls.Add(this.tableLayoutPanel2);
            this.plGridPaginado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plGridPaginado.Location = new System.Drawing.Point(0, 33);
            this.plGridPaginado.Name = "plGridPaginado";
            this.plGridPaginado.Size = new System.Drawing.Size(707, 392);
            this.plGridPaginado.TabIndex = 33;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.plNavegacion, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.dgvMovCuentasPaginado, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(707, 392);
            this.tableLayoutPanel2.TabIndex = 33;
            // 
            // plNavegacion
            // 
            this.plNavegacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.plNavegacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.plNavegacion.BackColor = System.Drawing.Color.LightSalmon;
            this.plNavegacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plNavegacion.Controls.Add(this.tableLayoutPanel1);
            this.plNavegacion.Controls.Add(this.lblCantidad);
            this.plNavegacion.Location = new System.Drawing.Point(240, 316);
            this.plNavegacion.Name = "plNavegacion";
            this.plNavegacion.Size = new System.Drawing.Size(226, 73);
            this.plNavegacion.TabIndex = 33;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.06F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.94F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.Controls.Add(this.btnPreviousPage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNextPage, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDisplayPageNo, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(224, 48);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.AutoSize = true;
            this.btnPreviousPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPreviousPage.FlatAppearance.BorderSize = 2;
            this.btnPreviousPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousPage.Location = new System.Drawing.Point(3, 3);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(68, 42);
            this.btnPreviousPage.TabIndex = 28;
            this.btnPreviousPage.Text = "<<";
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.AutoSize = true;
            this.btnNextPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNextPage.FlatAppearance.BorderSize = 2;
            this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPage.Location = new System.Drawing.Point(153, 3);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(68, 42);
            this.btnNextPage.TabIndex = 27;
            this.btnNextPage.Text = ">>";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // txtDisplayPageNo
            // 
            this.txtDisplayPageNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDisplayPageNo.AutoSize = true;
            this.txtDisplayPageNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisplayPageNo.Location = new System.Drawing.Point(102, 11);
            this.txtDisplayPageNo.Name = "txtDisplayPageNo";
            this.txtDisplayPageNo.Size = new System.Drawing.Size(20, 25);
            this.txtDisplayPageNo.TabIndex = 29;
            this.txtDisplayPageNo.Text = "-";
            this.txtDisplayPageNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCantidad
            // 
            this.lblCantidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(10, 2);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(203, 18);
            this.lblCantidad.TabIndex = 31;
            this.lblCantidad.Text = "Cantidad de registros";
            this.lblCantidad.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dgvMovCuentasPaginado
            // 
            this.dgvMovCuentasPaginado.AllowUserToAddRows = false;
            this.dgvMovCuentasPaginado.AllowUserToDeleteRows = false;
            this.dgvMovCuentasPaginado.AllowUserToResizeColumns = false;
            this.dgvMovCuentasPaginado.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvMovCuentasPaginado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMovCuentasPaginado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvMovCuentasPaginado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMovCuentasPaginado.BackgroundColor = System.Drawing.Color.Black;
            this.dgvMovCuentasPaginado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMovCuentasPaginado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMovCuentasPaginado.ColumnHeadersHeight = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMovCuentasPaginado.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMovCuentasPaginado.EnableHeadersVisualStyles = false;
            this.dgvMovCuentasPaginado.GridColor = System.Drawing.Color.Green;
            this.dgvMovCuentasPaginado.Location = new System.Drawing.Point(3, 3);
            this.dgvMovCuentasPaginado.MultiSelect = false;
            this.dgvMovCuentasPaginado.Name = "dgvMovCuentasPaginado";
            this.dgvMovCuentasPaginado.ReadOnly = true;
            this.dgvMovCuentasPaginado.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMovCuentasPaginado.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
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
            this.dgvMovCuentasPaginado.Size = new System.Drawing.Size(701, 307);
            this.dgvMovCuentasPaginado.TabIndex = 2;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitulo.Location = new System.Drawing.Point(0, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Padding = new System.Windows.Forms.Padding(10);
            this.labelTitulo.Size = new System.Drawing.Size(75, 33);
            this.labelTitulo.TabIndex = 40;
            this.labelTitulo.Tag = "bold big ";
            this.labelTitulo.Text = "labelTitulo";
            // 
            // plResumen
            // 
            this.plResumen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.plResumen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plResumen.Controls.Add(this.tableLayoutPanel3);
            this.plResumen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plResumen.Location = new System.Drawing.Point(15, 518);
            this.plResumen.Name = "plResumen";
            this.plResumen.Size = new System.Drawing.Size(707, 115);
            this.plResumen.TabIndex = 33;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel3.Controls.Add(this.lblDebe, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblTituloDebe, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblPago, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblTituloPago, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel3, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblSaldo, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblTituloSaldo, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.panel4, 2, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(705, 113);
            this.tableLayoutPanel3.TabIndex = 31;
            // 
            // lblDebe
            // 
            this.lblDebe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDebe.AutoSize = true;
            this.lblDebe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebe.Location = new System.Drawing.Point(334, 6);
            this.lblDebe.Name = "lblDebe";
            this.lblDebe.Size = new System.Drawing.Size(0, 20);
            this.lblDebe.TabIndex = 30;
            // 
            // lblTituloDebe
            // 
            this.lblTituloDebe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTituloDebe.AutoSize = true;
            this.lblTituloDebe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloDebe.Location = new System.Drawing.Point(79, 6);
            this.lblTituloDebe.Name = "lblTituloDebe";
            this.lblTituloDebe.Size = new System.Drawing.Size(52, 20);
            this.lblTituloDebe.TabIndex = 29;
            this.lblTituloDebe.Text = "Debe:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(460, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(242, 27);
            this.panel2.TabIndex = 31;
            // 
            // lblPago
            // 
            this.lblPago.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPago.AutoSize = true;
            this.lblPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPago.Location = new System.Drawing.Point(334, 39);
            this.lblPago.Name = "lblPago";
            this.lblPago.Size = new System.Drawing.Size(0, 20);
            this.lblPago.TabIndex = 33;
            // 
            // lblTituloPago
            // 
            this.lblTituloPago.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTituloPago.AutoSize = true;
            this.lblTituloPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPago.Location = new System.Drawing.Point(80, 39);
            this.lblTituloPago.Name = "lblTituloPago";
            this.lblTituloPago.Size = new System.Drawing.Size(50, 20);
            this.lblTituloPago.TabIndex = 32;
            this.lblTituloPago.Text = "Pagó:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(460, 36);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(242, 27);
            this.panel3.TabIndex = 34;
            // 
            // lblSaldo
            // 
            this.lblSaldo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.Location = new System.Drawing.Point(295, 77);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(78, 25);
            this.lblSaldo.TabIndex = 36;
            this.lblSaldo.Tag = "bold big";
            this.lblSaldo.Text = "$ 0.00";
            // 
            // lblTituloSaldo
            // 
            this.lblTituloSaldo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTituloSaldo.AutoSize = true;
            this.lblTituloSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloSaldo.Location = new System.Drawing.Point(66, 77);
            this.lblTituloSaldo.Name = "lblTituloSaldo";
            this.lblTituloSaldo.Size = new System.Drawing.Size(79, 25);
            this.lblTituloSaldo.TabIndex = 35;
            this.lblTituloSaldo.Text = "Saldo:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(460, 69);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(242, 41);
            this.panel4.TabIndex = 37;
            // 
            // msFiltro
            // 
            this.msFiltro.BackColor = System.Drawing.Color.LightCoral;
            this.msFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msFiltro.Controls.Add(this.filter2Panel);
            this.msFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.msFiltro.Location = new System.Drawing.Point(15, 15);
            this.msFiltro.Name = "msFiltro";
            this.msFiltro.Size = new System.Drawing.Size(707, 78);
            this.msFiltro.TabIndex = 34;
            // 
            // filter2Panel
            // 
            this.filter2Panel.Controls.Add(this.tableFiltroFecha);
            this.filter2Panel.Controls.Add(this.label6);
            this.filter2Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filter2Panel.Location = new System.Drawing.Point(0, 0);
            this.filter2Panel.MaximumSize = new System.Drawing.Size(0, 75);
            this.filter2Panel.Name = "filter2Panel";
            this.filter2Panel.Padding = new System.Windows.Forms.Padding(5);
            this.filter2Panel.Size = new System.Drawing.Size(705, 75);
            this.filter2Panel.TabIndex = 3;
            // 
            // tableFiltroFecha
            // 
            this.tableFiltroFecha.ColumnCount = 3;
            this.tableFiltroFecha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.85714F));
            this.tableFiltroFecha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.85714F));
            this.tableFiltroFecha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableFiltroFecha.Controls.Add(this.dtpHasta, 1, 0);
            this.tableFiltroFecha.Controls.Add(this.dtpDesde, 0, 0);
            this.tableFiltroFecha.Controls.Add(this.btFiltroFecha, 2, 0);
            this.tableFiltroFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableFiltroFecha.Location = new System.Drawing.Point(5, 23);
            this.tableFiltroFecha.Name = "tableFiltroFecha";
            this.tableFiltroFecha.RowCount = 1;
            this.tableFiltroFecha.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableFiltroFecha.Size = new System.Drawing.Size(695, 47);
            this.tableFiltroFecha.TabIndex = 7;
            // 
            // dtpHasta
            // 
            this.dtpHasta.CustomFormat = "dd/MM/yyyy";
            this.dtpHasta.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(307, 10);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(10);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(183, 20);
            this.dtpHasta.TabIndex = 1;
            // 
            // dtpDesde
            // 
            this.dtpDesde.CustomFormat = "dd/MM/yyyy";
            this.dtpDesde.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(104, 10);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(10);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(183, 20);
            this.dtpDesde.TabIndex = 0;
            // 
            // btFiltroFecha
            // 
            this.btFiltroFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btFiltroFecha.Location = new System.Drawing.Point(597, 3);
            this.btFiltroFecha.Name = "btFiltroFecha";
            this.btFiltroFecha.Size = new System.Drawing.Size(95, 41);
            this.btFiltroFecha.TabIndex = 2;
            this.btFiltroFecha.Text = "Aplicar";
            this.btFiltroFecha.UseVisualStyleBackColor = true;
            this.btFiltroFecha.Click += new System.EventHandler(this.btFiltroFecha_Click);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(695, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "Filtro Entre Fechas";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Green;
            this.bottomPanel.Controls.Add(this.tableBottomPanel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 699);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(737, 42);
            this.bottomPanel.TabIndex = 6;
            // 
            // tableBottomPanel
            // 
            this.tableBottomPanel.ColumnCount = 3;
            this.tableBottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableBottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableBottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableBottomPanel.Controls.Add(this.bCancelar, 0, 0);
            this.tableBottomPanel.Controls.Add(this.bAceptar, 0, 0);
            this.tableBottomPanel.Controls.Add(this.statusStripFormEntityInput, 0, 0);
            this.tableBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableBottomPanel.Location = new System.Drawing.Point(0, -3);
            this.tableBottomPanel.Name = "tableBottomPanel";
            this.tableBottomPanel.RowCount = 1;
            this.tableBottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBottomPanel.Size = new System.Drawing.Size(737, 45);
            this.tableBottomPanel.TabIndex = 26;
            // 
            // bCancelar
            // 
            this.bCancelar.BackColor = System.Drawing.Color.Black;
            this.bCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.bCancelar.FlatAppearance.BorderSize = 2;
            this.bCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.bCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.bCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCancelar.Location = new System.Drawing.Point(592, 3);
            this.bCancelar.MinimumSize = new System.Drawing.Size(100, 30);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(142, 39);
            this.bCancelar.TabIndex = 26;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bCancelar.UseVisualStyleBackColor = false;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // bAceptar
            // 
            this.bAceptar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bAceptar.BackColor = System.Drawing.Color.Black;
            this.bAceptar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bAceptar.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.bAceptar.FlatAppearance.BorderSize = 2;
            this.bAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.bAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.bAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAceptar.Location = new System.Drawing.Point(445, 3);
            this.bAceptar.MinimumSize = new System.Drawing.Size(100, 30);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(141, 39);
            this.bAceptar.TabIndex = 25;
            this.bAceptar.Text = "Aceptar";
            this.bAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bAceptar.UseVisualStyleBackColor = false;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // statusStripFormEntityInput
            // 
            this.statusStripFormEntityInput.AutoSize = false;
            this.statusStripFormEntityInput.BackColor = System.Drawing.Color.Green;
            this.statusStripFormEntityInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStripFormEntityInput.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mensajeroFormEntityInput});
            this.statusStripFormEntityInput.Location = new System.Drawing.Point(0, 0);
            this.statusStripFormEntityInput.Name = "statusStripFormEntityInput";
            this.statusStripFormEntityInput.Size = new System.Drawing.Size(442, 45);
            this.statusStripFormEntityInput.TabIndex = 23;
            this.statusStripFormEntityInput.Text = "ssMensajero";
            // 
            // mensajeroFormEntityInput
            // 
            this.mensajeroFormEntityInput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mensajeroFormEntityInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mensajeroFormEntityInput.ImageTransparentColor = System.Drawing.Color.Green;
            this.mensajeroFormEntityInput.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.mensajeroFormEntityInput.Name = "mensajeroFormEntityInput";
            this.mensajeroFormEntityInput.Size = new System.Drawing.Size(83, 45);
            this.mensajeroFormEntityInput.Text = "Mensajero";
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.topPanel.Controls.Add(this.formTittleText);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(737, 51);
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
            this.formTittleText.Size = new System.Drawing.Size(737, 51);
            this.formTittleText.TabIndex = 0;
            this.formTittleText.Tag = "title bold inverted";
            this.formTittleText.Text = "Detalle Cuentas";
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
            // FormMovDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(737, 741);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMovDetalle";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMovDetalle";
            this.mainPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.plOperacion.ResumeLayout(false);
            this.plOperacion.PerformLayout();
            this.tableAgregarMovimiento.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).EndInit();
            this.panelImporte.ResumeLayout(false);
            this.panelImporte.PerformLayout();
            this.plGridPaginado.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.plNavegacion.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovCuentasPaginado)).EndInit();
            this.plResumen.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.msFiltro.ResumeLayout(false);
            this.filter2Panel.ResumeLayout(false);
            this.tableFiltroFecha.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.tableBottomPanel.ResumeLayout(false);
            this.statusStripFormEntityInput.ResumeLayout(false);
            this.statusStripFormEntityInput.PerformLayout();
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epMovCuentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label formTittleText;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ErrorProvider epMovCuentas;
        private System.Windows.Forms.TextBox tbImporte;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Panel plOperacion;
        private System.Windows.Forms.Panel plResumen;
        private System.Windows.Forms.TableLayoutPanel tableAgregarMovimiento;
        private System.Windows.Forms.Panel panelImporte;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblDebe;
        private System.Windows.Forms.Label lblTituloDebe;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblPago;
        private System.Windows.Forms.Label lblTituloPago;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label lblTituloSaldo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.TableLayoutPanel tableBottomPanel;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.StatusStrip statusStripFormEntityInput;
        private System.Windows.Forms.ToolStripStatusLabel mensajeroFormEntityInput;
        private System.Windows.Forms.Panel msFiltro;
        private System.Windows.Forms.Panel filter2Panel;
        private System.Windows.Forms.TableLayoutPanel tableFiltroFecha;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel plGridPaginado;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel plNavegacion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Label txtDisplayPageNo;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.DataGridView dgvMovCuentasPaginado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rAcreditar;
        private System.Windows.Forms.RadioButton rDebitar;
        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Button btFiltroFecha;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvCuentas;
    }



}