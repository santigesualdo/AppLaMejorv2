using AppLaMejor.datamanager;

namespace AppLaMejor.controlmanager
{
    public class FuncionesReportes
    {

        //REPORTES

        //VENTAS
        public static bool informeVistaUltimaVenta(int id, int ido)
        {
            string consulta = QueryManager.Instance().ReportVistaUltimaVenta(id, ido);
            return QueryManager.Instance().ExecuteSQL(ConnecionBD.Instance().Connection, consulta);
        }
        public static bool informeVistaUltimaVenta(int idv)
        {
            string consulta = QueryManager.Instance().ReportVistaUltimaVenta(idv);
            return QueryManager.Instance().ExecuteSQL(ConnecionBD.Instance().Connection, consulta);
        }
        public static bool informeVistaUltimaVentaPorCliente(int idc)
        {
            string consulta = QueryManager.Instance().ReportVistaUltimaVentaPorCliente(idc);
            return QueryManager.Instance().ExecuteSQL(ConnecionBD.Instance().Connection, consulta);
        }
        public static bool informeVistaVentaSeleccionada(int idv)
        {
            string consulta = QueryManager.Instance().ReportVistaVentaSeleccionada(idv);
            return QueryManager.Instance().ExecuteSQL(ConnecionBD.Instance().Connection, consulta);
        }
        public static bool informeListadoVentas(string d, string h)
        {
            string consulta = QueryManager.Instance().ReportVistaListadoVentas(d, h);
            return QueryManager.Instance().ExecuteSQL(ConnecionBD.Instance().Connection, consulta);

        }
        public static bool informeListadoMovCuentas(string d, string h)
        {
            string consulta = QueryManager.Instance().ReportVistaListadoMovCuentas(d, h);
            return QueryManager.Instance().ExecuteSQL(ConnecionBD.Instance().Connection, consulta);

        }

        public static bool informeListadoVentaDetalle(string d, string h)
        {
            string consulta = QueryManager.Instance().ReportVistaVentaDetalle(d, h);
            return QueryManager.Instance().ExecuteSQL(ConnecionBD.Instance().Connection, consulta);

        }

        public static bool informeListadoMovCuentasProveedores(string d, string h)
        {
            string consulta = QueryManager.Instance().ReportVistaListadoMovCuentasProveedores(d, h);
            return QueryManager.Instance().ExecuteSQL(ConnecionBD.Instance().Connection, consulta);

        }
        //COMPRAS
        public static bool informeVistaUltimaCompra(int id, int ido)
        {
            string consulta = QueryManager.Instance().ReportVistaUltimaCompra(id, ido);
            return QueryManager.Instance().ExecuteSQL(ConnecionBD.Instance().Connection, consulta);
        }
        //public static bool informeVistaUltimaCompra(int idv)
        //{
        //    string consulta = QueryManager.Instance().ReportVistaUltimaVenta(idv);
        //    return QueryManager.Instance().ExecuteSQL(ConnecionBD.Instance().Connection, consulta);
        //}
        public static bool informeVistaCompraSeleccionada(int idc)
        {
            string consulta = QueryManager.Instance().ReportVistaCompraSeleccionada(idc);
            return QueryManager.Instance().ExecuteSQL(ConnecionBD.Instance().Connection, consulta);
        }

    }
}
