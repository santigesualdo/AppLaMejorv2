using AppLaMejor.controlmanager;
using AppLaMejor.formularios.reportes;
using System;
using System.Windows.Forms;


namespace AppLaMejor.reportes
{
    public partial class FormReportes : Form
    {
        public FormReportes()
        {
            InitializeComponent();
        }

        public FormReportes(string inicio)
        {
          
                
        }

        public DataSet1 DS = new DataSet1();

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
    }
}

