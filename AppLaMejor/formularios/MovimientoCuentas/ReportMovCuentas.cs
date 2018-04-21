using AppLaMejor.controlmanager;
using AppLaMejor.formularios.Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppLaMejor.formularios.MovimientoCuentas
{
    public partial class ReportMovCuentas : Form
    {
        public ReportMovCuentas()
        {
            InitializeComponent();
        }

        private void ReportMovCuentas_Load(object sender, EventArgs e)
        {
            AppLaMejor.Reports.DataSet1 DS = new AppLaMejor.Reports.DataSet1();
            
            clienteCR scr = new clienteCR();
            scr.SetDataSource(DS);
            
            this.crystalReportViewer1.ReportSource = scr;
        }
    }
}
