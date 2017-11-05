using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;
using AppLaMejor.entidades;
using System.Data;

namespace AppLaMejor.controlmanager
{
    public class FuncionesVentas
    {   
        public static string getDescripcion(string plu)
        {       
            string consulta = QueryManager.Instance().GetProductoFromIdCode(plu);
            string resultado;

            DataTable dtProducto = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            resultado = dtProducto.Rows[0][0].ToString();
            //traigo la descripcion del producto
            return dtProducto.Rows[0][0].ToString();            
        }

        public static Producto GetProductoByCode(string plu)
        {
            QueryManager manager = QueryManager.Instance();
            string consulta = manager.GetProductoFromIdCode(plu);
            DataTable dt = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);

            if (dt.Rows.Count.Equals(0)) return null;

            DataNamesMapper<Producto> mapper = new DataNamesMapper<Producto>();
            Producto product = mapper.Map(dt).ToList().First();
            return product;
        }

        public static bool InsertVenta(List<VentaDetalle> listDetalleVentas)
        {
            try
            {
                QueryManager manager = QueryManager.Instance();
                string consulta;

                decimal montoTotal = listDetalleVentas.Sum(x => x.Monto);
                int idVenta = GetNextIdVenta();

                Venta newVenta = new Venta();
                newVenta.MontoTotal = montoTotal;
                newVenta.Id = idVenta;
                consulta = manager.InsertVenta(newVenta);
                manager.ExecuteSQL(ConnecionBD.Instance().Connection, consulta);

                foreach (VentaDetalle v in listDetalleVentas)
                {
                    v.Venta = newVenta;
                    consulta = manager.InsertVentaDetalle(v);
                    manager.ExecuteSQL(ConnecionBD.Instance().Connection, consulta);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static int GetNextIdVenta()
        {
            QueryManager manager = QueryManager.Instance();
            string consulta = manager.GetNextVentaId();
            DataTable result = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
            return Int32.Parse(result.Rows[0][0].ToString());
        }

        public static List<Venta> ObtenerVentasDelDiaList()
        {
            QueryManager manager = QueryManager.Instance();
            string consulta = manager.GetVentasDelDia();
            DataTable result = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
            DataNamesMapper<Venta> mv = new DataNamesMapper<Venta>();
            List<Venta> listVentasDiarias = mv.Map(result).ToList();
            return listVentasDiarias;
        }

        public static DataTable GetVentas()
        {
            QueryManager manager = QueryManager.Instance();
            string consulta = manager.GetVentas();
            return manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
        }

        public static List<Venta> FillVentas(DataTable dataTableVentas)
        {
            DataNamesMapper<Venta> dv = new DataNamesMapper<Venta>();
            return dv.Map(dataTableVentas).ToList();
        }
    }
}
