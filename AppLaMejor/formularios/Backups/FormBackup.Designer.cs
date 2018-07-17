using AppLaMejor.stylemanager;

namespace AppLaMejor.formularios
{
    partial class FormBackup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.groupDataGrid = new System.Windows.Forms.GroupBox();
            this.dataGridClientes = new System.Windows.Forms.DataGridView();
            this.navigationPanel = new System.Windows.Forms.Panel();
            this.navTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.bRestaurar = new System.Windows.Forms.Button();
            this.bBackup = new System.Windows.Forms.Button();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.bAceptar = new System.Windows.Forms.Button();
            this.bCancelar = new System.Windows.Forms.Button();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.searchMainPanel = new System.Windows.Forms.Panel();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.filterTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.filtro2Panel = new System.Windows.Forms.Panel();
            this.dtpFilter = new System.Windows.Forms.DateTimePicker();
            this.filter2Text = new System.Windows.Forms.Label();
            this.filtro4Panel = new System.Windows.Forms.Panel();
            this.filter4TextBox = new System.Windows.Forms.TextBox();
            this.filter4Label = new System.Windows.Forms.Label();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.tittleText = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.formTittleText = new System.Windows.Forms.Label();
            this.filtro3Panel = new System.Windows.Forms.Panel();
            this.mainPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.groupDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClientes)).BeginInit();
            this.navigationPanel.SuspendLayout();
            this.navTableLayoutPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.searchMainPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.filterTableLayoutPanel.SuspendLayout();
            this.filtro2Panel.SuspendLayout();
            this.filtro4Panel.SuspendLayout();
            this.titlePanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
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
            this.mainPanel.Size = new System.Drawing.Size(1017, 749);
            this.mainPanel.TabIndex = 4;
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
            this.contentPanel.Size = new System.Drawing.Size(1017, 486);
            this.contentPanel.TabIndex = 3;
            // 
            // groupDataGrid
            // 
            this.groupDataGrid.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupDataGrid.Controls.Add(this.dataGridClientes);
            this.groupDataGrid.ForeColor = System.Drawing.Color.White;
            this.groupDataGrid.Location = new System.Drawing.Point(15, 85);
            this.groupDataGrid.Name = "groupDataGrid";
            this.groupDataGrid.Padding = new System.Windows.Forms.Padding(40, 22, 20, 22);
            this.groupDataGrid.Size = new System.Drawing.Size(987, 386);
            this.groupDataGrid.TabIndex = 1;
            this.groupDataGrid.TabStop = false;
            this.groupDataGrid.Text = "Listado";
            // 
            // dataGridClientes
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridClientes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridClientes.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridClientes.ColumnHeadersHeight = 40;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridClientes.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridClientes.EnableHeadersVisualStyles = false;
            this.dataGridClientes.GridColor = System.Drawing.Color.Green;
            this.dataGridClientes.Location = new System.Drawing.Point(20, 43);
            this.dataGridClientes.Name = "dataGridClientes";
            this.dataGridClientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridClientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridClientes.RowHeadersVisible = false;
            this.dataGridClientes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridClientes.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridClientes.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.dataGridClientes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridClientes.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridClientes.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Green;
            this.dataGridClientes.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridClientes.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridClientes.RowTemplate.Height = 35;
            this.dataGridClientes.RowTemplate.ReadOnly = true;
            this.dataGridClientes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridClientes.Size = new System.Drawing.Size(938, 246);
            this.dataGridClientes.TabIndex = 0;
            this.dataGridClientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridClientes_CellDoubleClick);
            // 
            // navigationPanel
            // 
            this.navigationPanel.Controls.Add(this.navTableLayoutPanel);
            this.navigationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.navigationPanel.Location = new System.Drawing.Point(15, 15);
            this.navigationPanel.Name = "navigationPanel";
            this.navigationPanel.Padding = new System.Windows.Forms.Padding(5);
            this.navigationPanel.Size = new System.Drawing.Size(987, 70);
            this.navigationPanel.TabIndex = 7;
            // 
            // navTableLayoutPanel
            // 
            this.navTableLayoutPanel.AllowDrop = true;
            this.navTableLayoutPanel.AutoSize = true;
            this.navTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.navTableLayoutPanel.ColumnCount = 4;
            this.navTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.navTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.navTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.navTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.navTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.navTableLayoutPanel.Controls.Add(this.bRestaurar, 2, 0);
            this.navTableLayoutPanel.Controls.Add(this.bBackup, 1, 0);
            this.navTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.navTableLayoutPanel.Location = new System.Drawing.Point(5, 5);
            this.navTableLayoutPanel.Name = "navTableLayoutPanel";
            this.navTableLayoutPanel.RowCount = 1;
            this.navTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.navTableLayoutPanel.Size = new System.Drawing.Size(977, 60);
            this.navTableLayoutPanel.TabIndex = 7;
            // 
            // bRestaurar
            // 
            this.bRestaurar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bRestaurar.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.bRestaurar.FlatAppearance.BorderSize = 2;
            this.bRestaurar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.bRestaurar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.bRestaurar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRestaurar.Image = global::AppLaMejor.Properties.Resources.lapiz_icon_30x30_green;
            this.bRestaurar.Location = new System.Drawing.Point(491, 3);
            this.bRestaurar.Name = "bRestaurar";
            this.bRestaurar.Size = new System.Drawing.Size(238, 54);
            this.bRestaurar.TabIndex = 11;
            this.bRestaurar.Text = "Restaurar Copia";
            this.bRestaurar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bRestaurar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bRestaurar.UseVisualStyleBackColor = false;
            this.bRestaurar.Click += new System.EventHandler(this.bEditar_Click);
            // 
            // bBackup
            // 
            this.bBackup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bBackup.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.bBackup.FlatAppearance.BorderSize = 2;
            this.bBackup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.bBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.bBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBackup.Image = global::AppLaMejor.Properties.Resources.add_icon_30x30_green;
            this.bBackup.Location = new System.Drawing.Point(247, 3);
            this.bBackup.Name = "bBackup";
            this.bBackup.Size = new System.Drawing.Size(238, 54);
            this.bBackup.TabIndex = 10;
            this.bBackup.Text = "Crear Backup";
            this.bBackup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bBackup.UseVisualStyleBackColor = false;
            this.bBackup.Click += new System.EventHandler(this.bAgregar_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Green;
            this.bottomPanel.Controls.Add(this.statusStrip1);
            this.bottomPanel.Controls.Add(this.bAceptar);
            this.bottomPanel.Controls.Add(this.bCancelar);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 699);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1017, 50);
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
            this.statusStrip1.Size = new System.Drawing.Size(617, 50);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "ssMensajero";
            // 
            // tsslMensaje
            // 
            this.tsslMensaje.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslMensaje.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsslMensaje.ImageTransparentColor = System.Drawing.Color.Green;
            this.tsslMensaje.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tsslMensaje.Name = "tsslMensaje";
            this.tsslMensaje.Size = new System.Drawing.Size(85, 50);
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
            this.bAceptar.Location = new System.Drawing.Point(617, 0);
            this.bAceptar.MinimumSize = new System.Drawing.Size(150, 30);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(200, 50);
            this.bAceptar.TabIndex = 21;
            this.bAceptar.Text = "Aceptar";
            this.bAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bAceptar.UseVisualStyleBackColor = false;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click_1);
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
            this.bCancelar.Location = new System.Drawing.Point(817, 0);
            this.bCancelar.MinimumSize = new System.Drawing.Size(150, 30);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(200, 50);
            this.bCancelar.TabIndex = 20;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bCancelar.UseVisualStyleBackColor = false;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click_1);
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
            this.searchPanel.Size = new System.Drawing.Size(1017, 163);
            this.searchPanel.TabIndex = 2;
            // 
            // searchMainPanel
            // 
            this.searchMainPanel.AutoSize = true;
            this.searchMainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchMainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchMainPanel.Controls.Add(this.filterPanel);
            this.searchMainPanel.Controls.Add(this.titlePanel);
            this.searchMainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchMainPanel.Location = new System.Drawing.Point(15, 15);
            this.searchMainPanel.Name = "searchMainPanel";
            this.searchMainPanel.Size = new System.Drawing.Size(987, 128);
            this.searchMainPanel.TabIndex = 3;
            // 
            // filterPanel
            // 
            this.filterPanel.Controls.Add(this.filterTableLayoutPanel);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Location = new System.Drawing.Point(0, 64);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(985, 62);
            this.filterPanel.TabIndex = 1;
            // 
            // filterTableLayoutPanel
            // 
            this.filterTableLayoutPanel.AllowDrop = true;
            this.filterTableLayoutPanel.AutoSize = true;
            this.filterTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.filterTableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.filterTableLayoutPanel.ColumnCount = 4;
            this.filterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.filterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.filterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.filterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.filterTableLayoutPanel.Controls.Add(this.filtro2Panel, 0, 0);
            this.filterTableLayoutPanel.Controls.Add(this.filtro3Panel, 0, 0);
            this.filterTableLayoutPanel.Controls.Add(this.filtro4Panel, 2, 0);
            this.filterTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.filterTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.filterTableLayoutPanel.Name = "filterTableLayoutPanel";
            this.filterTableLayoutPanel.RowCount = 1;
            this.filterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.filterTableLayoutPanel.Size = new System.Drawing.Size(985, 62);
            this.filterTableLayoutPanel.TabIndex = 1;
            // 
            // filtro2Panel
            // 
            this.filtro2Panel.Controls.Add(this.dtpFilter);
            this.filtro2Panel.Controls.Add(this.filter2Text);
            this.filtro2Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filtro2Panel.Location = new System.Drawing.Point(250, 4);
            this.filtro2Panel.Name = "filtro2Panel";
            this.filtro2Panel.Padding = new System.Windows.Forms.Padding(5);
            this.filtro2Panel.Size = new System.Drawing.Size(239, 54);
            this.filtro2Panel.TabIndex = 2;
            // 
            // dtpFilter
            // 
            this.dtpFilter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFilter.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilter.Location = new System.Drawing.Point(68, 26);
            this.dtpFilter.MaximumSize = new System.Drawing.Size(140, 30);
            this.dtpFilter.MinimumSize = new System.Drawing.Size(140, 22);
            this.dtpFilter.Name = "dtpFilter";
            this.dtpFilter.Size = new System.Drawing.Size(140, 26);
            this.dtpFilter.TabIndex = 3;
            this.dtpFilter.ValueChanged += new System.EventHandler(this.dtpFilter_ValueChanged);
            // 
            // filter2Text
            // 
            this.filter2Text.Dock = System.Windows.Forms.DockStyle.Top;
            this.filter2Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filter2Text.Location = new System.Drawing.Point(5, 5);
            this.filter2Text.Name = "filter2Text";
            this.filter2Text.Size = new System.Drawing.Size(229, 18);
            this.filter2Text.TabIndex = 1;
            this.filter2Text.Text = "Por Fecha";
            this.filter2Text.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // filtro4Panel
            // 
            this.filtro4Panel.Controls.Add(this.filter4TextBox);
            this.filtro4Panel.Controls.Add(this.filter4Label);
            this.filtro4Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filtro4Panel.Location = new System.Drawing.Point(496, 4);
            this.filtro4Panel.Name = "filtro4Panel";
            this.filtro4Panel.Padding = new System.Windows.Forms.Padding(5);
            this.filtro4Panel.Size = new System.Drawing.Size(239, 54);
            this.filtro4Panel.TabIndex = 4;
            // 
            // filter4TextBox
            // 
            this.filter4TextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.filter4TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filter4TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filter4TextBox.Location = new System.Drawing.Point(53, 26);
            this.filter4TextBox.MaximumSize = new System.Drawing.Size(140, 30);
            this.filter4TextBox.MinimumSize = new System.Drawing.Size(140, 22);
            this.filter4TextBox.Name = "filter4TextBox";
            this.filter4TextBox.Size = new System.Drawing.Size(140, 26);
            this.filter4TextBox.TabIndex = 5;
            this.filter4TextBox.Click += new System.EventHandler(this.filterTextBox_Click);
            this.filter4TextBox.TextChanged += new System.EventHandler(this.filterTextBox_TextChanged);
            // 
            // filter4Label
            // 
            this.filter4Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.filter4Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filter4Label.Location = new System.Drawing.Point(5, 5);
            this.filter4Label.Name = "filter4Label";
            this.filter4Label.Size = new System.Drawing.Size(229, 18);
            this.filter4Label.TabIndex = 4;
            this.filter4Label.Text = "Por Descripción";
            this.filter4Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // titlePanel
            // 
            this.titlePanel.Controls.Add(this.tittleText);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(985, 64);
            this.titlePanel.TabIndex = 0;
            // 
            // tittleText
            // 
            this.tittleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tittleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tittleText.Location = new System.Drawing.Point(0, 0);
            this.tittleText.Name = "tittleText";
            this.tittleText.Size = new System.Drawing.Size(985, 64);
            this.tittleText.TabIndex = 2;
            this.tittleText.Tag = "big ";
            this.tittleText.Text = "Buscador de Backups";
            this.tittleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Black;
            this.topPanel.Controls.Add(this.formTittleText);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1017, 50);
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
            this.formTittleText.Size = new System.Drawing.Size(1017, 50);
            this.formTittleText.TabIndex = 0;
            this.formTittleText.Tag = "title bold inverted";
            this.formTittleText.Text = "Gestor de Backups";
            this.formTittleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // filtro3Panel
            // 
            this.filtro3Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filtro3Panel.Location = new System.Drawing.Point(4, 4);
            this.filtro3Panel.Name = "filtro3Panel";
            this.filtro3Panel.Padding = new System.Windows.Forms.Padding(5);
            this.filtro3Panel.Size = new System.Drawing.Size(239, 54);
            this.filtro3Panel.TabIndex = 1;
            // 
            // FormBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1017, 749);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormClientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.groupDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClientes)).EndInit();
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
            this.filtro4Panel.ResumeLayout(false);
            this.filtro4Panel.PerformLayout();
            this.titlePanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label formTittleText;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.DataGridView dataGridClientes;
        private System.Windows.Forms.GroupBox groupDataGrid;
        private System.Windows.Forms.Panel navigationPanel;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Label tittleText;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.TableLayoutPanel navTableLayoutPanel;
        private System.Windows.Forms.Button bRestaurar;
        private System.Windows.Forms.Button bBackup;
        private System.Windows.Forms.TableLayoutPanel filterTableLayoutPanel;
        private System.Windows.Forms.Panel filtro2Panel;
        private System.Windows.Forms.Label filter2Text;
        private System.Windows.Forms.Panel searchMainPanel;
        private System.Windows.Forms.DateTimePicker dtpFilter;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslMensaje;
        private System.Windows.Forms.Panel filtro4Panel;
        private System.Windows.Forms.TextBox filter4TextBox;
        private System.Windows.Forms.Label filter4Label;
        private System.Windows.Forms.Panel filtro3Panel;
    }
}