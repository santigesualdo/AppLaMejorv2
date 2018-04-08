namespace AppLaMejor.Reports
{
    partial class FormReportes
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
            this.crVisor = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tlpReportes = new System.Windows.Forms.TableLayoutPanel();
            this.lblReporteTitulo = new System.Windows.Forms.Label();
            this.msReportes = new System.Windows.Forms.MenuStrip();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ultimaOperaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remitoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ultimaOperaciónToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpReportes.SuspendLayout();
            this.msReportes.SuspendLayout();
            this.SuspendLayout();
            // 
            // crVisor
            // 
            this.crVisor.ActiveViewIndex = -1;
            this.crVisor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crVisor.Cursor = System.Windows.Forms.Cursors.Default;
            this.crVisor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crVisor.Location = new System.Drawing.Point(109, 59);
            this.crVisor.Name = "crVisor";
            this.crVisor.ShowGroupTreeButton = false;
            this.crVisor.Size = new System.Drawing.Size(948, 499);
            this.crVisor.TabIndex = 0;
            this.crVisor.Load += new System.EventHandler(this.crVisor_Load);
            // 
            // tlpReportes
            // 
            this.tlpReportes.BackColor = System.Drawing.Color.Black;
            this.tlpReportes.ColumnCount = 2;
            this.tlpReportes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpReportes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpReportes.Controls.Add(this.crVisor, 1, 1);
            this.tlpReportes.Controls.Add(this.lblReporteTitulo, 1, 0);
            this.tlpReportes.Controls.Add(this.msReportes, 0, 1);
            this.tlpReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpReportes.Location = new System.Drawing.Point(0, 0);
            this.tlpReportes.Name = "tlpReportes";
            this.tlpReportes.RowCount = 2;
            this.tlpReportes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpReportes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpReportes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpReportes.Size = new System.Drawing.Size(1060, 561);
            this.tlpReportes.TabIndex = 1;
            // 
            // lblReporteTitulo
            // 
            this.lblReporteTitulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblReporteTitulo.AutoSize = true;
            this.lblReporteTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblReporteTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReporteTitulo.ForeColor = System.Drawing.Color.Green;
            this.lblReporteTitulo.Location = new System.Drawing.Point(482, 15);
            this.lblReporteTitulo.Name = "lblReporteTitulo";
            this.lblReporteTitulo.Size = new System.Drawing.Size(201, 25);
            this.lblReporteTitulo.TabIndex = 1;
            this.lblReporteTitulo.Text = "Visor de Reportes";
            // 
            // msReportes
            // 
            this.msReportes.BackColor = System.Drawing.Color.White;
            this.msReportes.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.msReportes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasToolStripMenuItem,
            this.comprasToolStripMenuItem});
            this.msReportes.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.msReportes.Location = new System.Drawing.Point(0, 56);
            this.msReportes.Name = "msReportes";
            this.msReportes.Padding = new System.Windows.Forms.Padding(0);
            this.msReportes.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.msReportes.Size = new System.Drawing.Size(106, 52);
            this.msReportes.TabIndex = 2;
            this.msReportes.Text = "msReportes";
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ultimaOperaciónToolStripMenuItem,
            this.remitoToolStripMenuItem});
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(105, 25);
            this.ventasToolStripMenuItem.Text = "Ventas";
            // 
            // ultimaOperaciónToolStripMenuItem
            // 
            this.ultimaOperaciónToolStripMenuItem.Name = "ultimaOperaciónToolStripMenuItem";
            this.ultimaOperaciónToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.ultimaOperaciónToolStripMenuItem.Text = "Operaciones";
            this.ultimaOperaciónToolStripMenuItem.Click += new System.EventHandler(this.ultimaOperaciónToolStripMenuItem_Click);
            // 
            // remitoToolStripMenuItem
            // 
            this.remitoToolStripMenuItem.Name = "remitoToolStripMenuItem";
            this.remitoToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.remitoToolStripMenuItem.Text = "Remito";
            this.remitoToolStripMenuItem.Click += new System.EventHandler(this.remitoToolStripMenuItem_Click);
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ultimaOperaciónToolStripMenuItem1});
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(105, 25);
            this.comprasToolStripMenuItem.Text = "Compras";
            // 
            // ultimaOperaciónToolStripMenuItem1
            // 
            this.ultimaOperaciónToolStripMenuItem1.Name = "ultimaOperaciónToolStripMenuItem1";
            this.ultimaOperaciónToolStripMenuItem1.Size = new System.Drawing.Size(167, 26);
            this.ultimaOperaciónToolStripMenuItem1.Text = "Operaciones";
            this.ultimaOperaciónToolStripMenuItem1.Click += new System.EventHandler(this.ultimaOperaciónToolStripMenuItem1_Click);
            // 
            // FormReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 561);
            this.Controls.Add(this.tlpReportes);
            this.MainMenuStrip = this.msReportes;
            this.Name = "FormReportes";
            this.Text = "FormReportes";
            this.tlpReportes.ResumeLayout(false);
            this.tlpReportes.PerformLayout();
            this.msReportes.ResumeLayout(false);
            this.msReportes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crVisor;
        private System.Windows.Forms.TableLayoutPanel tlpReportes;
        private System.Windows.Forms.Label lblReporteTitulo;
        private System.Windows.Forms.MenuStrip msReportes;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ultimaOperaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ultimaOperaciónToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem remitoToolStripMenuItem;
    }
}