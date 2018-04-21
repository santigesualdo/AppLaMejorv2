using AppLaMejor.controlmanager;
using AppLaMejor.formularios.Reports;
using AppLaMejor.Reports;
using System;
using System.Windows.Forms;


namespace AppLaMejor.Reports
{
    public partial class FormReportes : Form
    {
        public Reports.DataSet1 DS = new Reports.DataSet1();
        public FormReportes()
        {
            InitializeComponent();
        }
        
        public FormReportes(crRemito cr)
        {
            InitializeComponent();
            cr.SetDataSource(DS);
            crVisor.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            crVisor.ReportSource = cr;
        }

        private void crVisor_Load(object sender, EventArgs e)
        {
            crVisor.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
        }

        private void ultimaOperaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormModalReportes fmr = new FormModalReportes("Cliente");
            if (fmr.ShowDialog() == DialogResult.OK)
            {
                FuncionesReportes.informeVistaUltimaVenta(fmr.idCliente, fmr.idOperacion);
                FuncionesReportes.informeVistaUltimaVentaPorCliente(fmr.idCliente);
                FuncionesReportes.informeVistaVentaSeleccionada(fmr.idVenta);
                crSaldoPorCliente scr = new crSaldoPorCliente();
                scr.SetDataSource(DS);
                this.crVisor.ReportSource = scr;
            }
        }

        //public Boolean Execute(int entityId)
        //{
        //    Id = entityId;
        //    return ShowDialog() == DialogResult.OK;
        //}

        private void ultimaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crVentas scr = new crVentas();
            scr.SetDataSource(DS);
            this.crVisor.ReportSource = scr;
            



        }

        private void ultimaOperaciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormModalReportes fmr = new FormModalReportes("Proveedor");
            if (fmr.ShowDialog() == DialogResult.OK)
            {
               

                FuncionesReportes.informeVistaUltimaCompra(fmr.idProveedor, fmr.idOperacion);
                FuncionesReportes.informeVistaCompraSeleccionada(fmr.idCompra);
                crSaldoPorProveedor scr = new crSaldoPorProveedor();
                scr.SetDataSource(DS);
                this.crVisor.ReportSource = scr;
            }
        }

        private void remitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
                FormModalReportes fmr = new FormModalReportes("Cliente");
                if (fmr.ShowDialog() == DialogResult.OK)
                {
                    FuncionesReportes.informeVistaUltimaVenta(fmr.idCliente, fmr.idOperacion);
                    FuncionesReportes.informeVistaUltimaVentaPorCliente(fmr.idCliente);
                    FuncionesReportes.informeVistaVentaSeleccionada(fmr.idVenta);
                    crRemito scr = new crRemito();
                    scr.SetDataSource(DS);
                    this.crVisor.ReportSource = scr;
                }
        }

        private void resumenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormModalReportes fmr = new FormModalReportes("Resumen");
            if (fmr.ShowDialog() == DialogResult.OK)
            {
                
                crListadoVentas scr = new crListadoVentas();
                scr.SetDataSource(DS);
                this.crVisor.ReportSource = scr;
            }
        }

        private void agruparPorFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormModalReportes fmr = new FormModalReportes("MovClientes");
            if (fmr.ShowDialog() == DialogResult.OK)
            {

                crListadoMovClientes scr = new crListadoMovClientes();
                scr.SetDataSource(DS);
                this.crVisor.ReportSource = scr;
            }
        }

        private void agruparPorFechaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormModalReportes fmr = new FormModalReportes("MovProveedores");
            if (fmr.ShowDialog() == DialogResult.OK)
            {

                crListadoMovProveedores scr = new crListadoMovProveedores();
                scr.SetDataSource(DS);
                this.crVisor.ReportSource = scr;
            }
        }

        private void agruparPorClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormModalReportes fmr = new FormModalReportes("MovClientes");
            if (fmr.ShowDialog() == DialogResult.OK)
            {

                crListadoMovClientes2 scr = new crListadoMovClientes2();
                scr.SetDataSource(DS);
                this.crVisor.ReportSource = scr;
            }
        }

        private void agruparPorProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormModalReportes fmr = new FormModalReportes("MovProveedores");
            if (fmr.ShowDialog() == DialogResult.OK)
            {

                crListadoMovProveedores2 scr = new crListadoMovProveedores2();
                scr.SetDataSource(DS);
                this.crVisor.ReportSource = scr;
            }
        }
    }
}

