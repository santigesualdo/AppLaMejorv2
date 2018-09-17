using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.entidades;
using MySql.Data.MySqlClient;
using AppLaMejor.datamanager;
using System.Data;
using AppLaMejor.formularios.Util;

namespace AppLaMejor.controlmanager
{
    public class FuncionesCompras
    {
        // Parametros:
        // montoCompra
        // proveedorSeleccioado (puede ser null)
        // listaGarron
        // listProducto
        // Resultado:
        // ERROR : -1 
        // EXITO : id de la Compra para mostrar

        public static int ConfirmarCompraTransaction(decimal currentMontoCompra, decimal currentMontoPagado, Proveedor provSelec, List<Garron> listGarron, List<Producto> listProducto, int idCuentaProveedor, bool total)
        {
            //0. begin transaction
            //1. Se inserta el registro en compra.
            //2. Se inserta el registro en compraDetalle. (obtener siguiente id de compra)
            //3. Se inserta el garron comprado en tabla garron. (TODO: TIPO UBICACION)
            //4. Los productos se suman en campo "Cantidad". 
            //4. end transaction

            MySqlConnection connection = new MySqlConnection(ConnecionBD.Instance().connstring);
            using (connection)
            {
                MySqlTransaction tran = null;
                MySqlCommand command = null;
                try
                {
                    if (connection.State.Equals(ConnectionState.Closed))
                    {
                        // el BeginTransaction necesita la conexion abierta.
                        connection.Open();
                    }

                    int idCompra = -1;

                    tran = connection.BeginTransaction();
                    QueryManager manager = QueryManager.Instance();
                    string consulta = "";
                    command = new MySqlCommand(consulta, connection, tran);

                    // 1. Registrar operacion.
                    OperacionProveedor newOperacion = new OperacionProveedor();
                    // Si el provedor != null creamos operacion con IdCuenta e IdProveedor
                    // Si el proveedor == null registramos la operacion pero el idProveedor en 0 y no referencia a ninguna cuenta.
                    if (provSelec != null)
                    {
                        newOperacion.proveedor = provSelec;
                    }
                    else
                    {
                        newOperacion.proveedor = new Proveedor();
                        newOperacion.proveedor.Id = 0;
                    }

                    TipoOperacion to = new TipoOperacion();
                    to.Id = 3; //(Compra Proveedor)
                    newOperacion.tipoOperacion = to;
                    
                    consulta = manager.InsertOperacionProveedor(newOperacion);
                    command.CommandText = consulta;
                    command.ExecuteNonQuery();

                    int idOperacion = FuncionesGlobales.GetLastInsertId(command);
                    newOperacion.Id = idOperacion;
                    VariablesGlobales.idOperacion = newOperacion.Id;
                    // 2. Registramos compra con idOperacion.
                    // Si el currentMontoPagado = 0 signfica que pago todo, insertamos todo el monto de la compra como pagado.
                    // Sino, pago una parte, registramos lo que pago y el total.
                    if (!currentMontoPagado.Equals(decimal.Zero))
                    {
                        // Si monto pagado es cero, se pago todo
                        consulta = manager.InsertNuevaCompra(provSelec, newOperacion, currentMontoCompra, currentMontoPagado);
                    }                        
                    else
                    {
                        // Si monto pagado es diferente de cero, se inserta el monto pagado.
                      
                        consulta = manager.InsertNuevaCompra(provSelec, newOperacion, currentMontoCompra, currentMontoCompra);
                    }

                    command.CommandText = consulta;
                    command.ExecuteNonQuery();
                    idCompra = FuncionesGlobales.GetLastInsertId(command);
                    // 3. Movimiento Cuenta Proveedor
                    // Insertamos el el total del monto de la compra en el debe de la cuenta.
                    // 15/9/2018 CORRECCIÓN: NO VA EN EL DEBE, VA EN EL PAGO (DADO QUE  ES UN PROVEEDOR ESTO EQUIVALE A "COMPRADO")
                    MovimientoCuentaProveedor mcDebito = new MovimientoCuentaProveedor();
                    TipoMovimiento tp = new TipoMovimiento();
                    tp.Id = 2;
                    mcDebito.Operacion = newOperacion; //.Vob = '1';
                    mcDebito.TipoMovimiento = tp;
                    mcDebito.Cuenta = new Cuenta();
                    mcDebito.Cuenta.Id = idCuentaProveedor;
                    mcDebito.Monto = currentMontoCompra;
                    mcDebito.Cobrado = 'N';

                    consulta = manager.InsertMovCuentaProveedor(mcDebito);
                    command.CommandText = consulta;
                    command.ExecuteNonQuery();

                    // Si pago una parte, insertamos en el haber la parte que pago.
                    // Sino insertamos el total en el haber de la cuenta.
                    // 15/9/2018 CORRECCIÓN: NO VA EN EL PAGO, VA EN EL DEBE (DADO QUE  ES UN PROVEEDOR ESTO EQUIVALE A "PAGADO")
                    if (!currentMontoPagado.Equals(decimal.Zero))
                    {  
                        // currentMontoPagado lo que pago
                        MovimientoCuentaProveedor mcPago = new MovimientoCuentaProveedor();
                        TipoMovimiento tp2 = new TipoMovimiento();
                        tp2.Id = 1;
                        mcPago.Operacion = newOperacion; 
                        mcPago.TipoMovimiento = tp2;
                        mcPago.Cuenta = new Cuenta();
                        mcPago.Cuenta.Id = idCuentaProveedor;
                        mcPago.Monto = currentMontoPagado;
                        mcPago.Cobrado = 'S';
                        consulta = manager.InsertMovCuentaProveedor(mcPago);
                        command.CommandText = consulta;
                        command.ExecuteNonQuery();
                    }
                    else{
                        if (total)
                        {
                            MovimientoCuentaProveedor mcPago2 = new MovimientoCuentaProveedor();
                            TipoMovimiento tp2 = new TipoMovimiento();
                            tp2.Id = 1;
                            mcPago2.Operacion = newOperacion;
                            mcPago2.TipoMovimiento = tp2;
                            mcPago2.Cuenta = new Cuenta();
                            mcPago2.Cuenta.Id = idCuentaProveedor;
                            mcPago2.Monto = currentMontoCompra;
                            mcPago2.Cobrado = 'S';
                            consulta = manager.InsertMovCuentaProveedor(mcPago2);
                            command.CommandText = consulta;
                            command.ExecuteNonQuery();
                        }
                    }

                    //4. Se inserta el registro en compraDetalle. (obtener siguiente id de compra)
                    foreach (Garron g in listGarron)
                    {
                        // Se inserta el garron comprado en tabla garron. 
                        consulta = manager.InsertGarron(g);
                        command.CommandText = consulta;
                        command.ExecuteNonQuery();

                        g.Id = FuncionesGlobales.GetLastInsertId(command);
                        // Garron en compra detalle
                        consulta = manager.InsertCompraDetalle(idCompra, g);
                        command.CommandText = consulta;
                        command.ExecuteNonQuery();
                        // Se ubican todos los garrones en Mesa de Entrada
                        consulta = manager.UbicarCompraDetalleUbicacionEntrada(g);
                        command.CommandText = consulta;
                        command.ExecuteNonQuery();
                    }

                    foreach (Producto p in listProducto)
                    {
                        // Registro compra detalle.
                        consulta = manager.InsertCompraDetalle(idCompra, p);
                        command.CommandText = consulta;
                        command.ExecuteNonQuery();

                        // Se suma cantidadEntregada en tabla productos se suman en campo "Cantidad". 
                        consulta = manager.SumarCantidadProducto(p);
                        command.CommandText = consulta;
                        command.ExecuteNonQuery();

                        // Se ubican todos los productos ingresados en MESA DE ENTRADA.
                        // Verificamos que ese producto no exista en ubicacion entrada.
                        ProductoUbicacion puD = FuncionesProductos.GetProductoUbicacion(p, FuncionesGlobales.ObtenerUbicacionEntrada().Id);

                        // Si no existe el producto en destino, insertamos productoUbicacion.
                        if (puD == null)
                        {
                            // Se inserta la nueva ubicacion en ProductoUbicacion
                            consulta = manager.InsertProductoUbicacion(p.Id, FuncionesGlobales.ObtenerUbicacionEntrada().Id, p.CantidadEntregada);
                            command.CommandText = consulta;
                            command.ExecuteNonQuery();
                        }
                        else
                        // Caso contrario sumamos el peso.
                        {
                            decimal nuevoPeso = puD.peso + p.CantidadEntregada;
                            consulta = manager.UpdatePesoProductoDestino(puD.Id, nuevoPeso);
                            command.CommandText = consulta;
                            command.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                    return idCompra;
                }
                catch (Exception e)
                {
                    FormMessageBox dialog = new FormMessageBox();
                    try
                    {   
                        if (tran!=null)
                            tran.Rollback();
                    }
                    catch (InvalidOperationException ioe)
                    {
                        dialog.ShowErrorDialog(ioe.Message);
                    }
                    catch (MySqlException es)
                    {
                        dialog.ShowErrorDialog(es.Message);
                    }
                    return -1;
                }
            }
        }

        public static bool ConfirmarEntregaProductosRestantesTransaction(int idCompra)
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

                    Ubicacion destino = FuncionesCompras.obtenerUbicacionEntradaProductos();

                    // Transaccion - 
                    string consulta = "";
                    MySqlCommand command = new MySqlCommand(consulta, connection, tran);

                    // 1. Obtener la lista de productos faltantes.
                    List<Producto> listProductos = obtenerProductosFaltantesEntrega(idCompra);
                    if (listProductos==null || listProductos.Count.Equals(0))
                    {
                        tran.Rollback();
                        return false;
                    }
                    
                    foreach (Producto p in listProductos)
                    {
                        p.CantidadEntregada = p.Cantidad;

                        // 2. Insertar en producto ubicacion (origen) los productos entregados.
                        ProductoUbicacion puD = FuncionesProductos.GetProductoUbicacion(p, destino.Id);
                        // Si no existe el producto en destino, insertamos productoUbicacion.
                        if (puD == null)
                        {
                            // Se inserta la nueva ubicacion en ProductoUbicacion
                            consulta = manager.InsertProductoUbicacion(p.Id, destino.Id, p.CantidadEntregada);
                            command.CommandText = consulta;
                            command.ExecuteNonQuery();
                        }
                        else
                        // Si ese productoUbicacion, ya tiene ese producto sumamos el peso.
                        {
                            decimal nuevoPeso = puD.peso + p.CantidadEntregada;
                            consulta = manager.UpdatePesoProductoDestino(puD.Id, nuevoPeso);
                            command.CommandText = consulta;
                            command.ExecuteNonQuery();
                        }

                        // 3. Sumar a la cantidad total de productos en Productos.
                        Producto pr = FuncionesProductos.GetProducto(p.Id);
                        decimal nuevoPesoProducto = decimal.Add(pr.Cantidad, p.CantidadEntregada);
                        consulta = manager.UpdateCantidadProducto(p.Id, nuevoPesoProducto);
                        command.CommandText = consulta;
                        command.ExecuteNonQuery();
                    }

                    // 4. Marcar en compra detalle los productos entregados en 0.
                    consulta = manager.UpdateCompraDetalleEntregada(idCompra);
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
                            tran.Rollback();
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

        private static Ubicacion obtenerUbicacionEntradaProductos()
        {
            string consulta = QueryManager.Instance().GetUbicacionEntrada();
            DataTable tableUbicacion = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            DataNamesMapper<Ubicacion> dnmU = new DataNamesMapper<Ubicacion>();
            return dnmU.Map(tableUbicacion).ToList().First();
        }

        public static List<Producto> obtenerProductosFaltantesEntrega(int idCompra)
        {
            string consulta = QueryManager.Instance().GetProductoFaltanteData(idCompra);
            DataTable dt = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            DataNamesMapper<Producto> mapperProd = new DataNamesMapper<Producto>();
            return mapperProd.Map(dt).ToList();
        }

        public static DataTable GetCompras()
        {
            QueryManager manager = QueryManager.Instance();
            string consulta = manager.GetCompras();
            return manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
        }

        public static int GetNextCompraId()
        {
            QueryManager manager = QueryManager.Instance();
            string consulta = manager.GetNextCompraId();
            DataTable result = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
            return Int32.Parse(result.Rows[0][0].ToString());
        }

    }
}
