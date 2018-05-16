using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;
using AppLaMejor.entidades;
using System.Data;
using MySql.Data.MySqlClient;
using AppLaMejor.formularios.Util;

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
            return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, QueryManager.Instance().GetProductoUbicacionData());
        }

        public static DataTable fillComprasProductosFaltantes()
        {
            return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, QueryManager.Instance().GetComprasProductosFaltantes());
        }

        public static DataTable fillProductos(int tipoProducto)
        {
            return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, QueryManager.Instance().GetProductosDataByTipo(tipoProducto));
        }

        public static DataTable fillProductosVentaMayoristaDeposito()
        {
            return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, QueryManager.Instance().GetProductosMayoristaSalonDeposito());
        }

        internal static List<ProductoUbicacion> listProductoUbicacion(DataTable tableUbicacion)
        {
            DataNamesMapper<ProductoUbicacion> mapper = new DataNamesMapper<ProductoUbicacion>();
            return mapper.Map(tableUbicacion).ToList();
        }

        public static DataTable fillProductoUbicacion()
        {
            return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, QueryManager.Instance().GetProductoUbicacionTotal());
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

        public static List<Producto> GetProductosByUbicacion(int idUbicacion)
        {
            QueryManager manager = QueryManager.Instance();
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, manager.GetProductosByUbicacion(idUbicacion));
            DataNamesMapper<Producto> mapperProd = new DataNamesMapper<Producto>();
            return mapperProd.Map(table).ToList();
        }

        public static decimal GetPesoMaxByProdByUbi(Producto producto, int origenSeleccionado)
        {
            QueryManager manager = QueryManager.Instance();
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, manager.GetProductoUbicacion(producto, origenSeleccionado));
            DataNamesMapper<ProductoUbicacion> mapperProd = new DataNamesMapper<ProductoUbicacion>();
            return mapperProd.Map(table).ToList().First().peso;
        }

        public static bool CheckProductExistUbicacionSalida(int idProducto)
        {
            QueryManager manager = QueryManager.Instance();
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, manager.CheckProductExistUbicacionSalida(idProducto));
            return table.Rows.Count > 0;
        }

        public static List<Ubicacion> GetUbicacionDestino(int idOrigen, List<MovimientoMercaderia> listMovimientoMercaderia)
        {
            List<Ubicacion> listUbicacion = TiposManager.Instance().GetUbicacionListDestino(idOrigen);
            List<Ubicacion> uRemover = new List<Ubicacion>();
            foreach (Ubicacion u in listUbicacion)
            {
                if (u.Id.Equals(idOrigen))
                {
                    uRemover.Add(u);
                }
                foreach(MovimientoMercaderia mm in listMovimientoMercaderia)
                {
                    if (mm.origen.Id.Equals(idOrigen) && mm.destino!=null &&mm.destino.Id.Equals(u.Id))
                    {
                        uRemover.Add(u);
                    }
                }
            }
            if (!uRemover.Count.Equals(0))
            {
                foreach(Ubicacion ur in uRemover)
                {
                    listUbicacion = CheckUbicacionDestino(ur, listUbicacion);
                }
            }   

            return listUbicacion;
        }

        private static List<Ubicacion> CheckUbicacionDestino(Ubicacion uRem, List<Ubicacion> list)
        {
            foreach (Ubicacion u in list)
            {
                if (u.Id.Equals(uRem.Id))
                {
                    list.Remove(u);
                    return list;
                }
            }
            return list;
        }

        public static ProductoUbicacion GetProductoUbicacion(Producto producto, int idUbicacion)
        {
            QueryManager manager = QueryManager.Instance();
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, manager.GetProductoUbicacion(producto, idUbicacion));
            DataNamesMapper<ProductoUbicacion> mapperProd = new DataNamesMapper<ProductoUbicacion>();
            if (table.Rows.Count > 0)
            {
                return mapperProd.Map(table).ToList().First();
            }else
            {
                return null;
            }
        }

        public static ProductoUbicacion GetProductoUbicacion(Garron garron, int idUbicacion)
        {
            QueryManager manager = QueryManager.Instance();
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, manager.GetProductoUbicacion(garron, idUbicacion));
            DataNamesMapper<ProductoUbicacion> mapperProd = new DataNamesMapper<ProductoUbicacion>();
            return mapperProd.Map(table).ToList().First();
        }

        public static Ubicacion GetUbicacionByName(string name)
        {
            QueryManager manager = QueryManager.Instance();
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, manager.GetUbicacionByName(name));
            DataNamesMapper<Ubicacion> mapperProd = new DataNamesMapper<Ubicacion>();
            return mapperProd.Map(table).ToList().First();
        }

        public static bool ConfirmarMovimientosTransaction(List<MovimientoMercaderia> listMercaderiaMov)
        {
            MySqlConnection connection = new MySqlConnection(ConnecionBD.Instance().connstring);
            using (connection)
            {
                MySqlTransaction tran = null;
                try
                {
                    if (connection.State.Equals(ConnectionState.Closed))
                    {
                        connection.Open();
                    }

                    tran = connection.BeginTransaction();

                    QueryManager manager = QueryManager.Instance();

                    // Transaccion - 
                    // primera ejecucion 
                    string consulta = "";
                    MySqlCommand command = new MySqlCommand(consulta, connection, tran);

                    foreach (MovimientoMercaderia m in listMercaderiaMov)
                    {
                        ProductoUbicacion pu = null;
                        ProductoUbicacion puD = null;
                        // Si el movimiento es de un garron
                        if (m.garron != null)
                        {
                            // Obtenemos producto ubicacion
                            pu = GetProductoUbicacion(m.garron, m.origen.Id);
                            // Se actualiza la fecha_egreso y se marca peso 0
                            consulta = manager.UpdateProductoUbicacionBaja(pu.Id);
                            command.CommandText = consulta;
                            command.ExecuteNonQuery();
                        }

                        // Solo para los productos, chequeamos que la mercaderia que movemos sea el total de ese productoubicacion
                        if (m.producto != null)
                        {
                            pu = GetProductoUbicacion(m.producto, m.origen.Id);
                            // Sabemos que el peso del movimiento nunca puede ser mayor a la cantidad de esa ubicacion, por que esta validado
                            decimal calculo = decimal.Subtract(m.peso, pu.peso);
                            if (calculo.Equals(0))
                            {
                                // agrego fecha_egreso y cantidad 0 al productoubicacion
                                consulta = manager.UpdateProductoUbicacionBaja(pu.Id);
                                command.CommandText = consulta;
                                command.ExecuteNonQuery();
                            }
                            else
                            {
                                // Caso contrario queda un resto de producto y se resta lo retirado
                                decimal pesoRestante = pu.peso - m.peso;
                                consulta = manager.UpdateProductoUbicacion(pu.Id, pesoRestante);
                                command.CommandText = consulta;
                                command.ExecuteNonQuery();
                            }

                            // Chequeamos si ya existe un productoubicacion con ese idProducto e idUbicacion(destino)
                            puD = GetProductoUbicacion(m.producto, m.destino.Id);
                        }

                        // Se inserta el movimiento en MovimientoMercaderia
                        consulta = manager.InsertarMovimientoMercaderia(m);
                        command.CommandText = consulta;
                        command.ExecuteNonQuery();

                        // Si no existe el producto en destino, insertamos productoUbicacion.
                        if (puD == null)
                        {
                            // Se inserta la nueva ubicacion en ProductoUbicacion
                            consulta = manager.InsertProductoUbicacion(m);
                            command.CommandText = consulta;
                            command.ExecuteNonQuery();
                        }
                        else
                        // Caso contrario sumamos el peso.
                        {
                            decimal nuevoPeso = puD.peso + m.peso;
                            consulta = manager.UpdatePesoProductoDestino(puD.Id, nuevoPeso);
                            command.CommandText = consulta;
                            command.ExecuteNonQuery();
                        }

                    }
                    tran.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    FormMessageBox dialog = new FormMessageBox();
                    dialog.ShowErrorDialog("Ocurrio un error: " + e.Message);
                    if (tran != null)
                    {
                        tran.Rollback();
                    }
                    
                    return false;
                }
            }
        }

        public static bool CheckPluExists(string PLU)
        {
            string consulta = QueryManager.Instance().CheckCodigoBarraExist(PLU);
            DataTable table = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            DataNamesMapper<Producto> mapperProd = new DataNamesMapper<Producto>();
            if (table.Rows.Count > 0)
                return true;
            else
                return false;
            
        }

        public static List<Producto> GetProductosDeposte()
        {
            string consulta = QueryManager.Instance().GetProductosDeposte();
            DataTable table = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            DataNamesMapper<Producto> mapperProd = new DataNamesMapper<Producto>();
            if (table.Rows.Count > 0)
            {
                return mapperProd.Map(table).ToList();
            }
            else
            {
                return null;
            }
        }

        public static Producto GetProducto(int idProducto)
        {
            QueryManager manager = QueryManager.Instance();
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, manager.GetProducto(idProducto));
            DataNamesMapper<Producto> mapperProd = new DataNamesMapper<Producto>();
            if (table.Rows.Count > 0)
            {
                return mapperProd.Map(table).ToList().First();
            }
            else
            {
                return null;
            }
        }
    }
}
