namespace AppLaMejor.formularios.Productos
{
    partial class FormMoverProductos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelLista = new System.Windows.Forms.Panel();
            this.bottomContentPanel = new System.Windows.Forms.Panel();
            this.bConfirmar = new System.Windows.Forms.Button();
            this.navPanel = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.bAceptar = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.formTittleText = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bMoverPro = new System.Windows.Forms.Button();
            this.bMoverGarron = new System.Windows.Forms.Button();
            this.bLimpiar = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.bottomContentPanel.SuspendLayout();
            this.navPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.mainPanel.Size = new System.Drawing.Size(1350, 729);
            this.mainPanel.TabIndex = 6;
            // 
            // contentPanel
            // 
            this.contentPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contentPanel.Controls.Add(this.groupBox1);
            this.contentPanel.Controls.Add(this.bottomContentPanel);
            this.contentPanel.Controls.Add(this.navPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 50);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(15);
            this.contentPanel.Size = new System.Drawing.Size(1350, 629);
            this.contentPanel.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelLista);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(15, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1320, 502);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Movimientos Actuales";
            // 
            // panelLista
            // 
            this.panelLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLista.Location = new System.Drawing.Point(3, 16);
            this.panelLista.Name = "panelLista";
            this.panelLista.Size = new System.Drawing.Size(1314, 483);
            this.panelLista.TabIndex = 0;
            // 
            // bottomContentPanel
            // 
            this.bottomContentPanel.Controls.Add(this.bConfirmar);
            this.bottomContentPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomContentPanel.Location = new System.Drawing.Point(15, 562);
            this.bottomContentPanel.Name = "bottomContentPanel";
            this.bottomContentPanel.Size = new System.Drawing.Size(1320, 52);
            this.bottomContentPanel.TabIndex = 0;
            this.bottomContentPanel.Tag = "inverted";
            // 
            // bConfirmar
            // 
            this.bConfirmar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bConfirmar.Location = new System.Drawing.Point(0, 0);
            this.bConfirmar.Name = "bConfirmar";
            this.bConfirmar.Size = new System.Drawing.Size(1320, 52);
            this.bConfirmar.TabIndex = 0;
            this.bConfirmar.Text = "Confirmar Movimientos (Cantidad: 0)";
            this.bConfirmar.UseVisualStyleBackColor = true;
            this.bConfirmar.Click += new System.EventHandler(this.bConfirmar_Click);
            // 
            // navPanel
            // 
            this.navPanel.Controls.Add(this.tableLayoutPanel1);
            this.navPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.navPanel.Location = new System.Drawing.Point(15, 15);
            this.navPanel.Name = "navPanel";
            this.navPanel.Size = new System.Drawing.Size(1320, 45);
            this.navPanel.TabIndex = 1;
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Green;
            this.bottomPanel.Controls.Add(this.statusStrip1);
            this.bottomPanel.Controls.Add(this.bAceptar);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 679);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1350, 50);
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
            this.statusStrip1.Size = new System.Drawing.Size(1150, 50);
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
            this.bAceptar.Location = new System.Drawing.Point(1150, 0);
            this.bAceptar.MinimumSize = new System.Drawing.Size(150, 30);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(200, 50);
            this.bAceptar.TabIndex = 21;
            this.bAceptar.Text = "Aceptar";
            this.bAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bAceptar.UseVisualStyleBackColor = false;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Black;
            this.topPanel.Controls.Add(this.formTittleText);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1350, 50);
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
            this.formTittleText.Size = new System.Drawing.Size(1350, 50);
            this.formTittleText.TabIndex = 0;
            this.formTittleText.Tag = "title bold inverted";
            this.formTittleText.Text = "Mover Productos";
            this.formTittleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.bLimpiar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bMoverGarron, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bMoverPro, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1320, 45);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // bMoverPro
            // 
            this.bMoverPro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bMoverPro.Location = new System.Drawing.Point(3, 3);
            this.bMoverPro.MinimumSize = new System.Drawing.Size(200, 0);
            this.bMoverPro.Name = "bMoverPro";
            this.bMoverPro.Size = new System.Drawing.Size(434, 39);
            this.bMoverPro.TabIndex = 4;
            this.bMoverPro.Text = "Mover Productos Carniceria";
            this.bMoverPro.UseVisualStyleBackColor = true;
            this.bMoverPro.Click += new System.EventHandler(this.bMoverPro_Click);
            // 
            // bMoverGarron
            // 
            this.bMoverGarron.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bMoverGarron.Location = new System.Drawing.Point(443, 3);
            this.bMoverGarron.Name = "bMoverGarron";
            this.bMoverGarron.Size = new System.Drawing.Size(434, 39);
            this.bMoverGarron.TabIndex = 7;
            this.bMoverGarron.Text = "Mover Garron";
            this.bMoverGarron.UseVisualStyleBackColor = true;
            this.bMoverGarron.Click += new System.EventHandler(this.bMoverGarron_Click);
            // 
            // bLimpiar
            // 
            this.bLimpiar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLimpiar.Location = new System.Drawing.Point(883, 3);
            this.bLimpiar.Name = "bLimpiar";
            this.bLimpiar.Size = new System.Drawing.Size(434, 39);
            this.bLimpiar.TabIndex = 8;
            this.bLimpiar.Text = "Limpiar";
            this.bLimpiar.UseVisualStyleBackColor = true;
            this.bLimpiar.Click += new System.EventHandler(this.bLimpiar_Click);
            // 
            // FormMoverProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.mainPanel);
            this.Name = "FormMoverProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMoverProductos";
            this.mainPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.bottomContentPanel.ResumeLayout(false);
            this.navPanel.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslMensaje;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label formTittleText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelLista;
        private System.Windows.Forms.Panel navPanel;
        private System.Windows.Forms.Panel bottomContentPanel;
        private System.Windows.Forms.Button bConfirmar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button bMoverGarron;
        private System.Windows.Forms.Button bLimpiar;
        private System.Windows.Forms.Button bMoverPro;
    }
}