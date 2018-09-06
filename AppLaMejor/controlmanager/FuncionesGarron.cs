using AppLaMejor.datamanager;
using AppLaMejor.entidades;
using AppLaMejor.formularios.Util;
using AppLaMejor.stylemanager;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppLaMejor.controlmanager
{
    public class FuncionesGarron
    {
        public static Garron GetGarron(int idGarron)
        {
            QueryManager manager = QueryManager.Instance();
            string query = manager.GetGarron(idGarron);
            DataTable result = manager.GetTableResults(ConnecionBD.Instance().Connection, query);
            DataNamesMapper<Garron> mg = new DataNamesMapper<Garron>();
            return mg.Map(result).ToList().First();
        }
        public static bool InsertGarron(Garron g)
        {
            // Recibe garron para insertar y devuelve el Id de garron insertado
            try
            {
                QueryManager manager = QueryManager.Instance();
                string consulta = manager.InsertGarron(g);
                if (manager.ExecuteSQL(ConnecionBD.Instance().Connection, consulta))
                {
                    consulta = manager.GetLastInsertedGarron();
                    g.Id = int.Parse(manager.GetTableResults(ConnecionBD.Instance().Connection, consulta).Rows[0][0].ToString());
                    return true;
                };
            }
            catch (Exception e)
            {
				FormMessageBox dialog = new FormMessageBox();
                dialog.ShowErrorDialog("Ocurrio un error : " + e.Message);
                return false;
            }
            return false;
        }
        public static Garron AgregarGarronSinBD(string v)
        {
            Garron g = new Garron();
            g.FechaEntrada = DateTime.Now;
            FormEntityInput dialog = new FormEntityInput(g, FormEntityInput.MODO_INSERTAR, v);
            Boolean result = dialog.Execute(g);

            if (result)
            {
                g = (Garron)dialog.SelectedObject;
                // Desde este form solo se carga garron estado COMPLETO = 1
                g.TipoEstadoGarron = TiposManager.Instance().GetTipoEstadoGarron(1);
                /* Insert en BD */
                return g;
            }
            return null;
        }
        public static int GetNextGarronId()
        {
        
            QueryManager manager = QueryManager.Instance();
            string consulta = manager.GetNextGarronId();
            DataTable result = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
            return Int32.Parse(result.Rows[0][0].ToString());
        }
        public static List<Garron> GetGarronByUbicacion(int idUbicacion)
        {
            string consulta = QueryManager.Instance().GetGarronByUbicacion(idUbicacion);
            DataTable dataTablaGarron = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            DataNamesMapper<Garron> mg = new DataNamesMapper<Garron>();
            return mg.Map(dataTablaGarron).ToList();
        }
        public static Ubicacion GetUbicacionByGarron(Garron garronDeposte)
        {
            string consulta = QueryManager.Instance().GetUbicacionByGarron(garronDeposte.Id);
            DataTable dataTableUbicacion = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            DataNamesMapper<Ubicacion> mg = new DataNamesMapper<Ubicacion>();
            return mg.Map(dataTableUbicacion).ToList().First();
        }

        public static ProductoUbicacion GetGarronUbicacion(int idGarron)
        {
            QueryManager manager = QueryManager.Instance();
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, manager.GetGarronUbicacion(idGarron));
            DataNamesMapper<ProductoUbicacion> mapperProd = new DataNamesMapper<ProductoUbicacion>();
            return mapperProd.Map(table).ToList().First();
        }

        public static bool ConfirmarDeposte(List<GarronDeposte> listDeposte, Garron garronDeposte, Ubicacion origenGarron)
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

                    decimal pesoTotal = 0;

                    // Objetivos: 
                    // 1 Registro de cada deposte individualmente y sumar el peso total de los productos generados.
                    // 2 Insertar en producto ubicacion, considerando que si ya existe el producto en esa ubicacion, solo se actualiza la cantidad.
                    // 3 Garron debe restar el peso total de lo depostado y cambiar a estado DEPOSTE PARCIAL.

                    foreach (GarronDeposte gd in listDeposte)
                    {
                        if (gd.yaDepostado)
                            continue;

                        pesoTotal += gd.Peso;

                        ProductoUbicacion pu = FuncionesProductos.GetProductoUbicacion(gd.Producto , gd.Destino.Id);
                        // Si no existe el producto en destino, insertamos productoUbicacion.
                        if (pu == null)
                        {
                            // Se inserta la nueva ubicacion en ProductoUbicacion
                            // Creamos movimiento mercaderia solo por que InsertProductoUbicacion lo toma asi.
                            MovimientoMercaderia m = new MovimientoMercaderia();
                            m.destino = gd.Destino;
                            m.peso = gd.Peso;
                            m.producto = gd.Producto;

                            consulta = manager.InsertProductoUbicacion(m);
                            command.CommandText = consulta;
                            command.ExecuteNonQuery();
                        }
                        else
                        // Caso contrario sumamos el peso.
                        {
                            decimal nuevoPeso = pu.peso + gd.Peso;
                            consulta = manager.UpdatePesoProductoDestino(pu.Id, nuevoPeso);
                            command.CommandText = consulta;
                            command.ExecuteNonQuery();
                        }

                        consulta = manager.InsertGarronDeposte(gd);
                        command.CommandText = consulta;
                        command.ExecuteNonQuery();

                        Producto p = FuncionesProductos.GetProducto(gd.Producto.Id);
                        decimal cantidadTotal = p.Cantidad + gd.Peso;
                        consulta = manager.UpdateCantidadProducto(gd.Producto.Id, cantidadTotal);
                        command.CommandText = consulta;
                        command.ExecuteNonQuery();

                    }

                    consulta = manager.UpdatePesoGarron(garronDeposte.Id,  pesoTotal);
                    command.CommandText = consulta;
                    command.ExecuteNonQuery();



                    tran.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    FormMessageBox dialog = new FormMessageBox();
                    try
                    {
                        if (tran != null)
                        {
                            tran.Rollback();
                            dialog.ShowErrorDialog(e.Message);
                        }
                            
                    }
                    catch (InvalidOperationException ioe)
                    {
                        dialog.ShowErrorDialog(ioe.Message);
                    }
                    catch (MySqlException es)
                    {
                        dialog.ShowErrorDialog(es.Message);
                    }
                    return false;
                }
            }
        }

        public static ProductoUbicacion GetProductoUbicacionByGarron(int idGarron)
        {
            QueryManager manager = QueryManager.Instance();
            string consulta = manager.GetProductoUbicacionByGarron(idGarron);
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
            DataNamesMapper<ProductoUbicacion> dtmpu = new DataNamesMapper<ProductoUbicacion>();
            return dtmpu.Map(table).ToList().First();
        }

        public static List<GarronDeposte> GetDeposteAnterior(int id)
        {
            string consulta = QueryManager.Instance().GetGarronDeposteAnterior(id);
            DataTable dataTablaGarron = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            DataNamesMapper<GarronDeposte> mg = new DataNamesMapper<GarronDeposte>();
            return mg.Map(dataTablaGarron).ToList();
        }
    }
}
