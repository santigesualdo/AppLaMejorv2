using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;
using AppLaMejor.entidades;
using System.Data;
using System.Windows.Forms;

namespace AppLaMejor.controlmanager
{
    public class FuncionesClientes
    {
        public static DataTable fillClientes(){
            return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, QueryManager.Instance().GetClientesData());
        }
        public static DataTable fillClientesSaldoActual(){
			return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, QueryManager.Instance().GetClientesSaldoActual());
        }

        public static List<Cliente> listClientes(DataTable table){
            DataNamesMapper<Cliente> mapper = new DataNamesMapper<Cliente>();
            return mapper.Map(table).ToList();
        }

        public static bool UpdateCliente(Cliente client)
        {
            QueryManager manager =  QueryManager.Instance();
            string consulta = manager.UpdateCliente(client);
            return manager.ExecuteSQL(ConnecionBD.Instance().Connection, consulta);
        }

        public static bool InsertCliente(Cliente client)
        {
            QueryManager manager =  QueryManager.Instance();
            string consulta = manager.InsertNuevoCliente(client);
            return manager.ExecuteSQL(ConnecionBD.Instance().Connection, consulta);
        }

        public static bool InsertCuenta(Cuenta newCuenta, string idCliente)
        {
            QueryManager manager = QueryManager.Instance();
            string consulta = manager.InsertNuevaCuenta(newCuenta, idCliente);
            return manager.ExecuteSQL(ConnecionBD.Instance().Connection, consulta);
        }

        public static Cliente GetClienteById(int id)
        {
            //lleno cliente
            string consulta = QueryManager.Instance().GetClientesWithCuentaById(id);
            DataTable dtw = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            List<Cliente> listClienteWithCuenta;

            ////lleno los tipos de cliente
            //List<TipoCliente> tipoCliente = TiposManager.Instance().GetTipoClienteList();

            ////lleno cuentas
            //string consulta = QueryManager.Instance().GetCuentas();
            //DataTable dtc = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);

            if (!dtw.Rows.Count.Equals(0))
            {
                // Creamos mapper de clientes
                DataNamesMapper<Cliente> mapper = new DataNamesMapper<Cliente>();

                // Mapeamos la datatable y quedan todos los clientes en ListClientes
                listClienteWithCuenta = mapper.Map(dtw).ToList();

                // Como se busca por ID si o si sabemos que el miembro 0 de la lista es el indicado
                return listClienteWithCuenta.FirstOrDefault();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("     No hay cuenta asociada al cliente \r\n   ¿Desea crear una cuenta y asociarla?", "Mensaje", MessageBoxButtons.YesNo);
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

        public static Cuenta GetCuentaByIdCliente(int lastClient)
        {
            //lleno cliente
            string consulta = QueryManager.Instance().GetCuenta(lastClient);
            DataTable dtw = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            List<Cuenta> listCuentas;

            ////lleno los tipos de cliente
            //List<TipoCliente> tipoCliente = TiposManager.Instance().GetTipoClienteList();

            ////lleno cuentas
            //string consulta = QueryManager.Instance().GetCuentas();
            //DataTable dtc = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);

            if (!dtw.Rows.Count.Equals(0))
            {
                // Creamos mapper de clientes
                DataNamesMapper<Cuenta> mapper = new DataNamesMapper<Cuenta>();

                // Mapeamos la datatable y quedan todos los clientes en ListClientes
                listCuentas = mapper.Map(dtw).ToList();

                // Como se busca por ID si o si sabemos que el miembro 0 de la lista es el indicado
                return listCuentas.FirstOrDefault();

            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("     No hay cuenta asociada al cliente \r\n   ¿Desea crear una cuenta y asociarla?", "Mensaje", MessageBoxButtons.YesNo);
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

        public static Cuenta GetCuentaEfectivoByIdCliente(Cliente cliente)
        {
            //lleno cliente
            string consulta = QueryManager.Instance().GetCuentaEfectivoByIdCliente(cliente.Id);
            DataTable dtw = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            List<Cuenta> listCuentas;

            ////lleno los tipos de cliente
            //List<TipoCliente> tipoCliente = TiposManager.Instance().GetTipoClienteList();

            ////lleno cuentas
            //string consulta = QueryManager.Instance().GetCuentas();
            //DataTable dtc = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);

            if (!dtw.Rows.Count.Equals(0))
            {
                // Creamos mapper de clientes
                DataNamesMapper<Cuenta> mapper = new DataNamesMapper<Cuenta>();

                // Mapeamos la datatable y quedan todos los clientes en ListClientes
                listCuentas = mapper.Map(dtw).ToList();

                // Como se busca por ID si o si sabemos que el miembro 0 de la lista es el indicado
                return listCuentas.FirstOrDefault();

            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("     No hay cuenta asociada al cliente \r\n   ¿Desea crear una cuenta y asociarla?", "Mensaje", MessageBoxButtons.YesNo);
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

        public static List<Cliente> GetClientesMayoristasConCuenta()
        {
            string consulta = QueryManager.Instance().GetClientesMayoristasConCuenta();
            DataTable clientesMayoristasTable = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            DataNamesMapper<Cliente> mapper = new DataNamesMapper<Cliente>();
            return mapper.Map(clientesMayoristasTable).ToList();
        }
        public static Cuenta GetCuentaById(int lastCuenta)
        {
            //lleno cliente
            string consulta = QueryManager.Instance().GetCuenta(lastCuenta);
            DataTable dtw = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            List<Cuenta> listCuentas;
            List<Banco> listBancos;
            Banco banco = new Banco();
            consulta = QueryManager.Instance().GetBancoById(Convert.ToInt16(dtw.Rows[0]["id_banco"].ToString()));
            DataTable dtb = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);


            ////lleno cuentas
            //string consulta = QueryManager.Instance().GetCuentas();
            //DataTable dtc = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);

            if (!dtw.Rows.Count.Equals(0))
            {
                // Creamos mapper de clientes
                DataNamesMapper<Cuenta> mapper = new DataNamesMapper<Cuenta>();
                DataNamesMapper<Banco> mapper2 = new DataNamesMapper<Banco>();
                // Mapeamos la datatable y quedan todos los clientes en ListClientes
                listCuentas = mapper.Map(dtw).ToList();

                // Como se busca por ID si o si sabemos que el miembro 0 de la lista es el indicado
                Cuenta gotas = listCuentas.FirstOrDefault();

                listBancos = mapper2.Map(dtb).ToList();


                gotas.Banco = listBancos.FirstOrDefault();

                return gotas;

            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("     No hay cuenta asociada al cliente \r\n   ¿Desea crear una cuenta y asociarla?", "Mensaje", MessageBoxButtons.YesNo);
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

        public static List<Cuenta> GetCuentaEfectivoCliente(int id)
        {
            string consulta = QueryManager.Instance().GetCuentaByIdCliente(id);
            DataTable cuentaClienteTable = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);

            if (cuentaClienteTable.Rows.Count.Equals(0))
                return null;

            DataNamesMapper<Cuenta> mapper = new DataNamesMapper<Cuenta>();
            return mapper.Map(cuentaClienteTable).ToList();
        }
    }
}
