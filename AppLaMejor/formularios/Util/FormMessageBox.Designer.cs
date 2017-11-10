namespace AppLaMejor.formularios.Util
{
    partial class FormMessageBox
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
            this.tableBotones = new System.Windows.Forms.TableLayoutPanel();
            this.bCancelar = new System.Windows.Forms.Button();
            this.bOk = new System.Windows.Forms.Button();
            this.bAceptar = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.messagePanel = new System.Windows.Forms.Panel();
            this.groupMensaje = new System.Windows.Forms.GroupBox();
            this.panelMessage = new System.Windows.Forms.Panel();
            this.messageBoxLabel = new System.Windows.Forms.Label();
            this.tableBotones.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.messagePanel.SuspendLayout();
            this.groupMensaje.SuspendLayout();
            this.panelMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableBotones
            // 
            this.tableBotones.ColumnCount = 3;
            this.tableBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableBotones.Controls.Add(this.bCancelar, 2, 0);
            this.tableBotones.Controls.Add(this.bOk, 1, 0);
            this.tableBotones.Controls.Add(this.bAceptar, 0, 0);
            this.tableBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableBotones.Location = new System.Drawing.Point(5, 118);
            this.tableBotones.Name = "tableBotones";
            this.tableBotones.RowCount = 1;
            this.tableBotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBotones.Size = new System.Drawing.Size(915, 67);
            this.tableBotones.TabIndex = 0;
            // 
            // bCancelar
            // 
            this.bCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bCancelar.BackColor = System.Drawing.Color.Black;
            this.bCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.bCancelar.FlatAppearance.BorderSize = 2;
            this.bCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.bCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.bCancelar.Font = new System.Drawing.Font("Source Sans Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCancelar.Location = new System.Drawing.Point(662, 3);
            this.bCancelar.MaximumSize = new System.Drawing.Size(250, 40);
            this.bCancelar.MinimumSize = new System.Drawing.Size(200, 40);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(200, 40);
            this.bCancelar.TabIndex = 38;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bCancelar.UseVisualStyleBackColor = false;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // bOk
            // 
            this.bOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bOk.BackColor = System.Drawing.Color.Black;
            this.bOk.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.bOk.FlatAppearance.BorderSize = 2;
            this.bOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.bOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.bOk.Font = new System.Drawing.Font("Source Sans Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bOk.Location = new System.Drawing.Point(357, 3);
            this.bOk.MaximumSize = new System.Drawing.Size(250, 40);
            this.bOk.MinimumSize = new System.Drawing.Size(200, 40);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(200, 40);
            this.bOk.TabIndex = 37;
            this.bOk.Text = "Ok";
            this.bOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bOk.UseVisualStyleBackColor = false;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // bAceptar
            // 
            this.bAceptar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bAceptar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bAceptar.BackColor = System.Drawing.Color.Black;
            this.bAceptar.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.bAceptar.FlatAppearance.BorderSize = 2;
            this.bAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.bAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.bAceptar.Font = new System.Drawing.Font("Source Sans Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAceptar.Location = new System.Drawing.Point(52, 3);
            this.bAceptar.MaximumSize = new System.Drawing.Size(250, 40);
            this.bAceptar.MinimumSize = new System.Drawing.Size(200, 40);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(200, 40);
            this.bAceptar.TabIndex = 36;
            this.bAceptar.Text = "Aceptar";
            this.bAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bAceptar.UseVisualStyleBackColor = false;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.messagePanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(945, 229);
            this.mainPanel.TabIndex = 1;
            // 
            // messagePanel
            // 
            this.messagePanel.Controls.Add(this.groupMensaje);
            this.messagePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.messagePanel.Location = new System.Drawing.Point(0, 0);
            this.messagePanel.Name = "messagePanel";
            this.messagePanel.Padding = new System.Windows.Forms.Padding(10);
            this.messagePanel.Size = new System.Drawing.Size(945, 229);
            this.messagePanel.TabIndex = 0;
            // 
            // groupMensaje
            // 
            this.groupMensaje.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupMensaje.Controls.Add(this.tableBotones);
            this.groupMensaje.Controls.Add(this.panelMessage);
            this.groupMensaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupMensaje.Location = new System.Drawing.Point(10, 10);
            this.groupMensaje.Name = "groupMensaje";
            this.groupMensaje.Padding = new System.Windows.Forms.Padding(5);
            this.groupMensaje.Size = new System.Drawing.Size(925, 209);
            this.groupMensaje.TabIndex = 0;
            this.groupMensaje.TabStop = false;
            this.groupMensaje.Text = "Aviso";
            // 
            // panelMessage
            // 
            this.panelMessage.Controls.Add(this.messageBoxLabel);
            this.panelMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMessage.Location = new System.Drawing.Point(5, 18);
            this.panelMessage.Name = "panelMessage";
            this.panelMessage.Size = new System.Drawing.Size(915, 100);
            this.panelMessage.TabIndex = 1;
            // 
            // messageBoxLabel
            // 
            this.messageBoxLabel.Location = new System.Drawing.Point(3, 11);
            this.messageBoxLabel.Name = "messageBoxLabel";
            this.messageBoxLabel.Size = new System.Drawing.Size(907, 72);
            this.messageBoxLabel.TabIndex = 3;
            this.messageBoxLabel.Text = "label1";
            this.messageBoxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 229);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMessageBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMessageBox";
            this.tableBotones.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.messagePanel.ResumeLayout(false);
            this.groupMensaje.ResumeLayout(false);
            this.panelMessage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableBotones;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bAceptar;
        public System.Windows.Forms.Panel messagePanel;
        private System.Windows.Forms.GroupBox groupMensaje;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Panel panelMessage;
        private System.Windows.Forms.Label messageBoxLabel;
    }
}