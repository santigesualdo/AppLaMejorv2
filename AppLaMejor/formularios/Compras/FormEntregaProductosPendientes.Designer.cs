namespace AppLaMejor.formularios.Compras
{
    partial class FormEntregaProductosPendientes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.tittleText = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.groupDataGrid = new System.Windows.Forms.GroupBox();
            this.dataGridComprasProdPendientes = new System.Windows.Forms.DataGridView();
            this.navigationPanel = new System.Windows.Forms.Panel();
            this.navTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.bAgregar = new System.Windows.Forms.Button();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.bCancelar = new System.Windows.Forms.Button();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.searchMainPanel = new System.Windows.Forms.Panel();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.filterTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.filtro2Panel = new System.Windows.Forms.Panel();
            this.filter2TextBox = new System.Windows.Forms.TextBox();
            this.filter2Text = new System.Windows.Forms.Label();
            this.filtro3Panel = new System.Windows.Forms.Panel();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.filter3Text = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.formTittleText = new System.Windows.Forms.Label();
            this.titlePanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.groupDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridComprasProdPendientes)).BeginInit();
            this.navigationPanel.SuspendLayout();
            this.navTableLayoutPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.searchMainPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.filterTableLayoutPanel.SuspendLayout();
            this.filtro2Panel.SuspendLayout();
            this.filtro3Panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.Controls.Add(this.tittleText);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(1000, 64);
            this.titlePanel.TabIndex = 0;
            // 
            // tittleText
            // 
            this.tittleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tittleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tittleText.Location = new System.Drawing.Point(0, 0);
            this.tittleText.Name = "tittleText";
            this.tittleText.Size = new System.Drawing.Size(1000, 64);
            this.tittleText.TabIndex = 2;
            this.tittleText.Tag = "big ";
            this.tittleText.Text = "Buscador de Productos";
            this.tittleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.contentPanel);
            this.mainPanel.Controls.Add(this.bottomPanel);
            this.mainPanel.Controls.Add(this.searchPanel);
            this.mainPanel.Controls.Add(this.topPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1032, 630);
            this.mainPanel.TabIndex = 5;
            // 
            // contentPanel
            // 
            this.contentPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contentPanel.Controls.Add(this.groupDataGrid);
            this.contentPanel.Controls.Add(this.navigationPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 213);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(15);
            this.contentPanel.Size = new System.Drawing.Size(1032, 367);
            this.contentPanel.TabIndex = 3;
            // 
            // groupDataGrid
            // 
            this.groupDataGrid.Controls.Add(this.dataGridComprasProdPendientes);
            this.groupDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupDataGrid.ForeColor = System.Drawing.Color.White;
            this.groupDataGrid.Location = new System.Drawing.Point(15, 85);
            this.groupDataGrid.Name = "groupDataGrid";
            this.groupDataGrid.Padding = new System.Windows.Forms.Padding(40, 22, 20, 22);
            this.groupDataGrid.Size = new System.Drawing.Size(1002, 267);
            this.groupDataGrid.TabIndex = 1;
            this.groupDataGrid.TabStop = false;
            this.groupDataGrid.Text = "Listado";
            // 
            // dataGridComprasProdPendientes
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridComprasProdPendientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridComprasProdPendientes.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridComprasProdPendientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridComprasProdPendientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridComprasProdPendientes.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridComprasProdPendientes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridComprasProdPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridComprasProdPendientes.EnableHeadersVisualStyles = false;
            this.dataGridComprasProdPendientes.GridColor = System.Drawing.Color.Green;
            this.dataGridComprasProdPendientes.Location = new System.Drawing.Point(40, 35);
            this.dataGridComprasProdPendientes.Name = "dataGridComprasProdPendientes";
            this.dataGridComprasProdPendientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridComprasProdPendientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridComprasProdPendientes.RowHeadersVisible = false;
            this.dataGridComprasProdPendientes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridComprasProdPendientes.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.dataGridComprasProdPendientes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridComprasProdPendientes.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridComprasProdPendientes.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Green;
            this.dataGridComprasProdPendientes.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridComprasProdPendientes.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridComprasProdPendientes.RowTemplate.Height = 35;
            this.dataGridComprasProdPendientes.RowTemplate.ReadOnly = true;
            this.dataGridComprasProdPendientes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridComprasProdPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridComprasProdPendientes.Size = new System.Drawing.Size(942, 210);
            this.dataGridComprasProdPendientes.TabIndex = 0;
            // 
            // navigationPanel
            // 
            this.navigationPanel.Controls.Add(this.navTableLayoutPanel);
            this.navigationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.navigationPanel.Location = new System.Drawing.Point(15, 15);
            this.navigationPanel.Name = "navigationPanel";
            this.navigationPanel.Padding = new System.Windows.Forms.Padding(5);
            this.navigationPanel.Size = new System.Drawing.Size(1002, 70);
            this.navigationPanel.TabIndex = 7;
            // 
            // navTableLayoutPanel
            // 
            this.navTableLayoutPanel.AllowDrop = true;
            this.navTableLayoutPanel.AutoSize = true;
            this.navTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.navTableLayoutPanel.ColumnCount = 5;
            this.navTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.navTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.navTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.navTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.navTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.navTableLayoutPanel.Controls.Add(this.bAgregar, 0, 0);
            this.navTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.navTableLayoutPanel.Location = new System.Drawing.Point(5, 5);
            this.navTableLayoutPanel.Name = "navTableLayoutPanel";
            this.navTableLayoutPanel.RowCount = 1;
            this.navTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.navTableLayoutPanel.Size = new System.Drawing.Size(992, 60);
            this.navTableLayoutPanel.TabIndex = 7;
            // 
            // bAgregar
            // 
            this.bAgregar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bAgregar.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.bAgregar.FlatAppearance.BorderSize = 2;
            this.bAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.bAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.bAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAgregar.Image = global::AppLaMejor.Properties.Resources.add_icon_30x30_green;
            this.bAgregar.Location = new System.Drawing.Point(3, 3);
            this.bAgregar.Name = "bAgregar";
            this.bAgregar.Size = new System.Drawing.Size(390, 54);
            this.bAgregar.TabIndex = 10;
            this.bAgregar.Text = "Marcar Productos de Compra como Recibido";
            this.bAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bAgregar.UseVisualStyleBackColor = false;
            this.bAgregar.Click += new System.EventHandler(this.bAgregar_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Green;
            this.bottomPanel.Controls.Add(this.statusStrip1);
            this.bottomPanel.Controls.Add(this.bCancelar);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 580);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1032, 50);
            this.bottomPanel.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.Green;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslMensaje});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(832, 50);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "ssMensajero";
            // 
            // tsslMensaje
            // 
            this.tsslMensaje.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsslMensaje.ImageTransparentColor = System.Drawing.Color.Green;
            this.tsslMensaje.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tsslMensaje.Name = "tsslMensaje";
            this.tsslMensaje.Size = new System.Drawing.Size(83, 50);
            this.tsslMensaje.Text = "Mensajero";
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
            this.bCancelar.Location = new System.Drawing.Point(832, 0);
            this.bCancelar.MinimumSize = new System.Drawing.Size(150, 30);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(200, 50);
            this.bCancelar.TabIndex = 20;
            this.bCancelar.Text = "Salir";
            this.bCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bCancelar.UseVisualStyleBackColor = false;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // searchPanel
            // 
            this.searchPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchPanel.Controls.Add(this.searchMainPanel);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(0, 50);
            this.searchPanel.Margin = new System.Windows.Forms.Padding(10);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Padding = new System.Windows.Forms.Padding(15);
            this.searchPanel.Size = new System.Drawing.Size(1032, 163);
            this.searchPanel.TabIndex = 2;
            // 
            // searchMainPanel
            // 
            this.searchMainPanel.AutoSize = true;
            this.searchMainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchMainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchMainPanel.Controls.Add(this.filterPanel);
            this.searchMainPanel.Controls.Add(this.panel1);
            this.searchMainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchMainPanel.Location = new System.Drawing.Point(15, 15);
            this.searchMainPanel.Name = "searchMainPanel";
            this.searchMainPanel.Size = new System.Drawing.Size(1002, 128);
            this.searchMainPanel.TabIndex = 3;
            // 
            // filterPanel
            // 
            this.filterPanel.Controls.Add(this.filterTableLayoutPanel);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Location = new System.Drawing.Point(0, 64);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(1000, 62);
            this.filterPanel.TabIndex = 1;
            // 
            // filterTableLayoutPanel
            // 
            this.filterTableLayoutPanel.AllowDrop = true;
            this.filterTableLayoutPanel.AutoSize = true;
            this.filterTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.filterTableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.filterTableLayoutPanel.ColumnCount = 2;
            this.filterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.filterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.filterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.filterTableLayoutPanel.Controls.Add(this.filtro2Panel, 0, 0);
            this.filterTableLayoutPanel.Controls.Add(this.filtro3Panel, 0, 0);
            this.filterTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.filterTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.filterTableLayoutPanel.Name = "filterTableLayoutPanel";
            this.filterTableLayoutPanel.RowCount = 1;
            this.filterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.filterTableLayoutPanel.Size = new System.Drawing.Size(1000, 62);
            this.filterTableLayoutPanel.TabIndex = 1;
            // 
            // filtro2Panel
            // 
            this.filtro2Panel.Controls.Add(this.filter2TextBox);
            this.filtro2Panel.Controls.Add(this.filter2Text);
            this.filtro2Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filtro2Panel.Location = new System.Drawing.Point(503, 4);
            this.filtro2Panel.Name = "filtro2Panel";
            this.filtro2Panel.Padding = new System.Windows.Forms.Padding(5);
            this.filtro2Panel.Size = new System.Drawing.Size(493, 54);
            this.filtro2Panel.TabIndex = 2;
            // 
            // filter2TextBox
            // 
            this.filter2TextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.filter2TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filter2TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filter2TextBox.Location = new System.Drawing.Point(182, 26);
            this.filter2TextBox.MaximumSize = new System.Drawing.Size(140, 30);
            this.filter2TextBox.MinimumSize = new System.Drawing.Size(140, 22);
            this.filter2TextBox.Name = "filter2TextBox";
            this.filter2TextBox.Size = new System.Drawing.Size(140, 26);
            this.filter2TextBox.TabIndex = 6;
            this.filter2TextBox.Text = "-";
            // 
            // filter2Text
            // 
            this.filter2Text.Dock = System.Windows.Forms.DockStyle.Top;
            this.filter2Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filter2Text.Location = new System.Drawing.Point(5, 5);
            this.filter2Text.Name = "filter2Text";
            this.filter2Text.Size = new System.Drawing.Size(483, 18);
            this.filter2Text.TabIndex = 1;
            this.filter2Text.Text = "Por Compra";
            this.filter2Text.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // filtro3Panel
            // 
            this.filtro3Panel.Controls.Add(this.filterTextBox);
            this.filtro3Panel.Controls.Add(this.filter3Text);
            this.filtro3Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filtro3Panel.Location = new System.Drawing.Point(4, 4);
            this.filtro3Panel.Name = "filtro3Panel";
            this.filtro3Panel.Padding = new System.Windows.Forms.Padding(5);
            this.filtro3Panel.Size = new System.Drawing.Size(492, 54);
            this.filtro3Panel.TabIndex = 1;
            // 
            // filterTextBox
            // 
            this.filterTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.filterTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filterTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterTextBox.Location = new System.Drawing.Point(177, 26);
            this.filterTextBox.MaximumSize = new System.Drawing.Size(140, 30);
            this.filterTextBox.MinimumSize = new System.Drawing.Size(140, 22);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(140, 26);
            this.filterTextBox.TabIndex = 5;
            this.filterTextBox.Text = "-";
            // 
            // filter3Text
            // 
            this.filter3Text.Dock = System.Windows.Forms.DockStyle.Top;
            this.filter3Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filter3Text.Location = new System.Drawing.Point(5, 5);
            this.filter3Text.Name = "filter3Text";
            this.filter3Text.Size = new System.Drawing.Size(482, 18);
            this.filter3Text.TabIndex = 4;
            this.filter3Text.Text = "Por Proveedor";
            this.filter3Text.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 64);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(985, 64);
            this.label1.TabIndex = 2;
            this.label1.Tag = "big ";
            this.label1.Text = "Buscador de Compras con Productos Pendientes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Black;
            this.topPanel.Controls.Add(this.formTittleText);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1032, 50);
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
            this.formTittleText.Size = new System.Drawing.Size(1032, 50);
            this.formTittleText.TabIndex = 0;
            this.formTittleText.Tag = "title bold inverted";
            this.formTittleText.Text = "Productos Pendientes";
            this.formTittleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormEntregaProductosPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 630);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormEntregaProductosPendientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEntregaProductosPendientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.titlePanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.groupDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridComprasProdPendientes)).EndInit();
            this.navigationPanel.ResumeLayout(false);
            this.navigationPanel.PerformLayout();
            this.navTableLayoutPanel.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.searchMainPanel.ResumeLayout(false);
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.filterTableLayoutPanel.ResumeLayout(false);
            this.filtro2Panel.ResumeLayout(false);
            this.filtro2Panel.PerformLayout();
            this.filtro3Panel.ResumeLayout(false);
            this.filtro3Panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Label tittleText;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.GroupBox groupDataGrid;
        private System.Windows.Forms.DataGridView dataGridComprasProdPendientes;
        private System.Windows.Forms.Panel navigationPanel;
        private System.Windows.Forms.TableLayoutPanel navTableLayoutPanel;
        private System.Windows.Forms.Button bAgregar;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslMensaje;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Panel searchMainPanel;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.TableLayoutPanel filterTableLayoutPanel;
        private System.Windows.Forms.Panel filtro2Panel;
        private System.Windows.Forms.TextBox filter2TextBox;
        private System.Windows.Forms.Label filter2Text;
        private System.Windows.Forms.Panel filtro3Panel;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.Label filter3Text;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label formTittleText;
    }
}