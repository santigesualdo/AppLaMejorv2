namespace AppLaMejor.formularios
{
    partial class FormDeposteGarron
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
            this.bottomContentPanel = new System.Windows.Forms.Panel();
            this.bConfirmar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelLista = new System.Windows.Forms.Panel();
            this.navPanel = new System.Windows.Forms.Panel();
            this.bLimpiar = new System.Windows.Forms.Button();
            this.bAgregarDeposte = new System.Windows.Forms.Button();
            this.lGarronData = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.bAceptar = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.formTittleText = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.bottomContentPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.navPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.topPanel.SuspendLayout();
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
            this.mainPanel.Size = new System.Drawing.Size(1155, 613);
            this.mainPanel.TabIndex = 7;
            // 
            // contentPanel
            // 
            this.contentPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contentPanel.Controls.Add(this.bottomContentPanel);
            this.contentPanel.Controls.Add(this.groupBox1);
            this.contentPanel.Controls.Add(this.navPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 50);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(15);
            this.contentPanel.Size = new System.Drawing.Size(1155, 513);
            this.contentPanel.TabIndex = 3;
            // 
            // bottomContentPanel
            // 
            this.bottomContentPanel.Controls.Add(this.bConfirmar);
            this.bottomContentPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomContentPanel.Location = new System.Drawing.Point(15, 446);
            this.bottomContentPanel.Name = "bottomContentPanel";
            this.bottomContentPanel.Size = new System.Drawing.Size(1125, 52);
            this.bottomContentPanel.TabIndex = 0;
            this.bottomContentPanel.Tag = "inverted";
            // 
            // bConfirmar
            // 
            this.bConfirmar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bConfirmar.Location = new System.Drawing.Point(0, 0);
            this.bConfirmar.Name = "bConfirmar";
            this.bConfirmar.Size = new System.Drawing.Size(1125, 52);
            this.bConfirmar.TabIndex = 0;
            this.bConfirmar.Text = "Confirmar Deposte (Cantidad: 0)";
            this.bConfirmar.UseVisualStyleBackColor = true;
            this.bConfirmar.Click += new System.EventHandler(this.bConfirmar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelLista);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(15, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1125, 417);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Deposte Actual";
            // 
            // panelLista
            // 
            this.panelLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLista.Location = new System.Drawing.Point(3, 16);
            this.panelLista.Name = "panelLista";
            this.panelLista.Size = new System.Drawing.Size(1119, 398);
            this.panelLista.TabIndex = 0;
            // 
            // navPanel
            // 
            this.navPanel.Controls.Add(this.bLimpiar);
            this.navPanel.Controls.Add(this.bAgregarDeposte);
            this.navPanel.Controls.Add(this.lGarronData);
            this.navPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.navPanel.Location = new System.Drawing.Point(15, 15);
            this.navPanel.Name = "navPanel";
            this.navPanel.Size = new System.Drawing.Size(1125, 66);
            this.navPanel.TabIndex = 1;
            // 
            // bLimpiar
            // 
            this.bLimpiar.Dock = System.Windows.Forms.DockStyle.Right;
            this.bLimpiar.Location = new System.Drawing.Point(965, 27);
            this.bLimpiar.Name = "bLimpiar";
            this.bLimpiar.Size = new System.Drawing.Size(160, 39);
            this.bLimpiar.TabIndex = 5;
            this.bLimpiar.Text = "Limpiar";
            this.bLimpiar.UseVisualStyleBackColor = true;
            // 
            // bAgregarDeposte
            // 
            this.bAgregarDeposte.Dock = System.Windows.Forms.DockStyle.Left;
            this.bAgregarDeposte.Location = new System.Drawing.Point(0, 27);
            this.bAgregarDeposte.MinimumSize = new System.Drawing.Size(200, 0);
            this.bAgregarDeposte.Name = "bAgregarDeposte";
            this.bAgregarDeposte.Size = new System.Drawing.Size(204, 39);
            this.bAgregarDeposte.TabIndex = 3;
            this.bAgregarDeposte.Text = "Nuevo Deposte";
            this.bAgregarDeposte.UseVisualStyleBackColor = true;
            this.bAgregarDeposte.Click += new System.EventHandler(this.bAgregarDeposte_Click);
            // 
            // lGarronData
            // 
            this.lGarronData.Dock = System.Windows.Forms.DockStyle.Top;
            this.lGarronData.Location = new System.Drawing.Point(0, 0);
            this.lGarronData.Name = "lGarronData";
            this.lGarronData.Size = new System.Drawing.Size(1125, 27);
            this.lGarronData.TabIndex = 6;
            this.lGarronData.Text = "label1";
            this.lGarronData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Green;
            this.bottomPanel.Controls.Add(this.statusStrip1);
            this.bottomPanel.Controls.Add(this.bAceptar);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 563);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1155, 50);
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
            this.statusStrip1.Size = new System.Drawing.Size(955, 50);
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
            this.bAceptar.Location = new System.Drawing.Point(955, 0);
            this.bAceptar.MinimumSize = new System.Drawing.Size(150, 30);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(200, 50);
            this.bAceptar.TabIndex = 21;
            this.bAceptar.Text = "Aceptar";
            this.bAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bAceptar.UseVisualStyleBackColor = false;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Black;
            this.topPanel.Controls.Add(this.formTittleText);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1155, 50);
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
            this.formTittleText.Size = new System.Drawing.Size(1155, 50);
            this.formTittleText.TabIndex = 0;
            this.formTittleText.Tag = "title bold inverted";
            this.formTittleText.Text = "Depostar Garron";
            this.formTittleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormDeposteGarron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 613);
            this.Controls.Add(this.mainPanel);
            this.Name = "FormDeposteGarron";
            this.Text = "FormDeposteGarron";
            this.mainPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.bottomContentPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.navPanel.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel bottomContentPanel;
        private System.Windows.Forms.Button bConfirmar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelLista;
        private System.Windows.Forms.Panel navPanel;
        private System.Windows.Forms.Button bLimpiar;
        private System.Windows.Forms.Button bAgregarDeposte;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslMensaje;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label formTittleText;
        private System.Windows.Forms.Label lGarronData;
    }
}