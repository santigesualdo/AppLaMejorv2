using AppLaMejor.stylemanager;
namespace AppLaMejor.formularios.Caja
{
    partial class FormAgregarManual
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.controlsPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbProductos = new System.Windows.Forms.ComboBox();
            this.tbCantidad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.tbPrecio = new System.Windows.Forms.TextBox();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.tableBottomPanel = new System.Windows.Forms.TableLayoutPanel();
            this.bCancelar = new System.Windows.Forms.Button();
            this.bAceptar = new System.Windows.Forms.Button();
            this.statusStripFormEntityInput = new System.Windows.Forms.StatusStrip();
            this.mensajeroFormEntityInput = new System.Windows.Forms.ToolStripStatusLabel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.formTittleText = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbPrecioFinal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.controlsPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.tableBottomPanel.SuspendLayout();
            this.statusStripFormEntityInput.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
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
            this.contentPanel.Controls.Add(this.controlsPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 51);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(15);
            this.contentPanel.Size = new System.Drawing.Size(622, 639);
            this.contentPanel.TabIndex = 3;
            // 
            // controlsPanel
            // 
            this.controlsPanel.Controls.Add(this.tableLayoutPanel2);
            this.controlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlsPanel.Location = new System.Drawing.Point(15, 15);
            this.controlsPanel.Name = "controlsPanel";
            this.controlsPanel.Padding = new System.Windows.Forms.Padding(5);
            this.controlsPanel.Size = new System.Drawing.Size(592, 609);
            this.controlsPanel.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66667F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(582, 220);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Descripción:";
            // 
            // tbCodigo
            // 
            this.tbCodigo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbCodigo.Location = new System.Drawing.Point(31, 27);
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(100, 20);
            this.tbCodigo.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Código:";
            // 
            // cmbProductos
            // 
            this.cmbProductos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbProductos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProductos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProductos.FormattingEnabled = true;
            this.cmbProductos.Location = new System.Drawing.Point(53, 26);
            this.cmbProductos.Name = "cmbProductos";
            this.cmbProductos.Size = new System.Drawing.Size(265, 21);
            this.cmbProductos.TabIndex = 12;
            this.cmbProductos.SelectedIndexChanged += new System.EventHandler(this.cmbProductos_SelectedIndexChanged);
            this.cmbProductos.SelectionChangeCommitted += new System.EventHandler(this.cmbProductos_SelectionChangeCommitted);
            this.cmbProductos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbProductos_KeyPress);
            this.cmbProductos.Leave += new System.EventHandler(this.cmbProductos_Leave);
            // 
            // tbCantidad
            // 
            this.tbCantidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbCantidad.Location = new System.Drawing.Point(31, 36);
            this.tbCantidad.Name = "tbCantidad";
            this.tbCantidad.Size = new System.Drawing.Size(100, 20);
            this.tbCantidad.TabIndex = 7;
            this.tbCantidad.TextChanged += new System.EventHandler(this.tbCantidad_TextChanged);
            this.tbCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCantidad_KeyPress);
            this.tbCantidad.Leave += new System.EventHandler(this.tbCantidad_Leave);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Cantidad:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(215, 20);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(40, 13);
            this.lblPrecio.TabIndex = 9;
            this.lblPrecio.Text = "Precio:";
            // 
            // tbPrecio
            // 
            this.tbPrecio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbPrecio.Location = new System.Drawing.Point(53, 36);
            this.tbPrecio.Name = "tbPrecio";
            this.tbPrecio.Size = new System.Drawing.Size(100, 20);
            this.tbPrecio.TabIndex = 10;
            this.tbPrecio.TextChanged += new System.EventHandler(this.tbPrecio_TextChanged);
            this.tbPrecio.Leave += new System.EventHandler(this.tbPrecio_Leave);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Green;
            this.bottomPanel.Controls.Add(this.tableBottomPanel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 690);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(622, 48);
            this.bottomPanel.TabIndex = 5;
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
            this.tableBottomPanel.Location = new System.Drawing.Point(0, 3);
            this.tableBottomPanel.Name = "tableBottomPanel";
            this.tableBottomPanel.RowCount = 1;
            this.tableBottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBottomPanel.Size = new System.Drawing.Size(622, 45);
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
            this.bCancelar.Location = new System.Drawing.Point(500, 3);
            this.bCancelar.MinimumSize = new System.Drawing.Size(100, 30);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(119, 39);
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
            this.bAceptar.Location = new System.Drawing.Point(376, 3);
            this.bAceptar.MinimumSize = new System.Drawing.Size(100, 30);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(118, 39);
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
            this.statusStripFormEntityInput.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStripFormEntityInput.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mensajeroFormEntityInput});
            this.statusStripFormEntityInput.Location = new System.Drawing.Point(0, 0);
            this.statusStripFormEntityInput.Name = "statusStripFormEntityInput";
            this.statusStripFormEntityInput.Size = new System.Drawing.Size(373, 45);
            this.statusStripFormEntityInput.TabIndex = 23;
            this.statusStripFormEntityInput.Text = "ssMensajero";
            // 
            // mensajeroFormEntityInput
            // 
            this.mensajeroFormEntityInput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mensajeroFormEntityInput.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mensajeroFormEntityInput.ImageTransparentColor = System.Drawing.Color.Green;
            this.mensajeroFormEntityInput.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.mensajeroFormEntityInput.Name = "mensajeroFormEntityInput";
            this.mensajeroFormEntityInput.Size = new System.Drawing.Size(85, 45);
            this.mensajeroFormEntityInput.Text = "Mensajero";
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
            this.formTittleText.Tag = "title bold inverted";
            this.formTittleText.Text = "Agregar Producto Manualmente";
            this.formTittleText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbPrecioFinal);
            this.panel1.Controls.Add(this.lblPrecio);
            this.panel1.Controls.Add(this.tbPrecio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(196, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 104);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbCantidad);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(187, 104);
            this.panel2.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cmbProductos);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(196, 47);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(383, 60);
            this.panel3.TabIndex = 13;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.tbCodigo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 47);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(187, 60);
            this.panel4.TabIndex = 14;
            // 
            // tbPrecioFinal
            // 
            this.tbPrecioFinal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbPrecioFinal.Location = new System.Drawing.Point(218, 36);
            this.tbPrecioFinal.Name = "tbPrecioFinal";
            this.tbPrecioFinal.ReadOnly = true;
            this.tbPrecioFinal.Size = new System.Drawing.Size(100, 20);
            this.tbPrecioFinal.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Precio Sugerido:";
            // 
            // FormAgregarManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(622, 738);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "FormAgregarManual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAgregar";
            this.mainPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.controlsPanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.tableBottomPanel.ResumeLayout(false);
            this.statusStripFormEntityInput.ResumeLayout(false);
            this.statusStripFormEntityInput.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label formTittleText;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel controlsPanel;
        private System.Windows.Forms.TableLayoutPanel tableBottomPanel;
        private System.Windows.Forms.StatusStrip statusStripFormEntityInput;
        private System.Windows.Forms.ToolStripStatusLabel mensajeroFormEntityInput;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbProductos;
        private System.Windows.Forms.TextBox tbCantidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox tbPrecio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbPrecioFinal;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
    }



}