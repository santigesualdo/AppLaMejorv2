using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;
using AppLaMejor.entidades;
using System.Data;
using System.Windows.Forms;
using AppLaMejor.formularios.Util;

namespace AppLaMejor.controlmanager
{
    public class FuncionesProveedores
    {
        public static DataTable fillProveedores()
        {
            return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, QueryManager.Instance().GetProveedoresData());
        }
        public static DataTable fillProveedoresSaldoActual()
        {
            return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, QueryManager.Instance().GetProveedoresSaldoActual());
        }

        public static List<Proveedor> listProveedores(DataTable table)
        {
            DataNamesMapper<Proveedor> mapper = new DataNamesMapper<Proveedor>();
            return mapper.Map(table).ToList();
        }

        public static bool InsertCuenta(Cuenta newCuenta, string idProveedor)
        {
            QueryManager manager = QueryManager.Instance();
            string consulta = manager.InsertNuevaCuenta(newCuenta, idProveedor);
            return manager.ExecuteSQL(ConnecionBD.Instance().Connection, consulta);
        }

        public static Proveedor GetProveedorById(int id)
        {
            //lleno proveedor
            string consulta = QueryManager.Instance().GetProveedoresWithCuentaById(id);
            DataTable dtw = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            List<Proveedor> listProveedorWithCuenta;

            if (!dtw.Rows.Count.Equals(0))
            {
                // Creamos mapper de clientes
                DataNamesMapper<Proveedor> mapper = new DataNamesMapper<Proveedor>();

                // Mapeamos la datatable y quedan todos los clientes en ListClientes
                listProveedorWithCuenta = mapper.Map(dtw).ToList();

                // Como se busca por ID si o si sabemos que el miembro 0 de la lista es el indicado
                return listProveedorWithCuenta.FirstOrDefault();
            }
            else
            {
				FormMessageBox dialog = new FormMessageBox();
				if (dialog.ShowConfirmationDialog("     No hay cuenta asociada al Proveedor \r\n   ¿Desea crear una cuenta y asociarla?")){
					MessageBox.Show("acá linkear para crear una cuenta"); //do something
				}
                return null;
            }

        }

        public static Cuenta GetCuentaByIdProveedor(int lastProv)
        {
            //lleno proveedor
            string consulta = QueryManager.Instance().GetCuenta(lastProv);
            DataTable dtw = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            List<Cuenta> listCuentas;

            if (!dtw.Rows.Count.Equals(0))
            {
                // Creamos mapper de proveedores
                DataNamesMapper<Cuenta> mapper = new DataNamesMapper<Cuenta>();

                // Mapeamos la datatable y quedan todos los clientes en ListClientes
                listCuentas = mapper.Map(dtw).ToList();

                // Como se busca por ID si o si sabemos que el miembro 0 de la lista es el indicado
                return listCuentas.FirstOrDefault();

            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("     No hay cuenta asociada al proveedor \r\n   ¿Desea crear una cuenta y asociarla?", "Mensaje", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    MessageBox.Show("acá linkear para crear una cuenta"); //do something
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
                return null;
            }
        }
    
    }
}
