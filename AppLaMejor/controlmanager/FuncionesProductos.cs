using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;
using AppLaMejor.entidades;
using System.Data;

namespace AppLaMejor.controlmanager
{
    public class FuncionesProductos
    {
        public const string PRECIO_TIPO_PORKG = "por kg";
        public const string PRECIO_TIPO_POR_ALGO = "por algo";

        public static decimal GetPesoProductoPrecio(decimal montoTicket, Producto pro)
        {
            decimal peso = Decimal.Zero;
            peso = montoTicket / pro.Precio;
            return Math.Truncate(peso * 1000) / 1000;
        }

        public static DataTable fillProductos()
        {
            return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, QueryManager.Instance().GetProductosData());
        }

        public static DataTable fillProductos(int tipoProducto)
        {
            return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, QueryManager.Instance().GetProductosDataByTipo(tipoProducto));
        }

        public static List<Producto> listProductos(DataTable table)
        {
            DataNamesMapper<Producto> mapper = new DataNamesMapper<Producto>();
            return mapper.Map(table).ToList();
        }
        public static bool UpdateProducto(Producto prod)
        {
            QueryManager manager = QueryManager.Instance();
            string consulta = manager.UpdateProducto(prod);
            return manager.ExecuteSQL(ConnecionBD.Instance().Connection, consulta);
        }

        public static bool InsertProducto(Producto prod)
        {
            QueryManager manager = QueryManager.Instance();
            string consulta = manager.InsertNuevoProducto(prod);
            return manager.ExecuteSQL(ConnecionBD.Instance().Connection, consulta);
        }

        public static Producto GetProductoByPlu(string text)
        {
            QueryManager manager = QueryManager.Instance();
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, manager.GetProductoByPLU(text));
            DataNamesMapper<Producto> mapperProd = new DataNamesMapper<Producto>();
            return mapperProd.Map(table).ToList().First();
        }

        public static Producto GetProductoByDescrip(string text)
        {
            QueryManager manager = QueryManager.Instance();
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, manager.GetProductoByDescripBreve(text));
            DataNamesMapper<Producto> mapperProd = new DataNamesMapper<Producto>();
            return mapperProd.Map(table).ToList().First();
        }
    }
}
