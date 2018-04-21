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
        public static int ConfirmarCompraTransaction(decimal currentMontoCompra, decimal currentMontoPagado, Proveedor provSelec, List<Garron> listGarron, List<Producto> listProducto, int idCuentaProveedor)
        {
            //0. begin transaction
            //1. Se inserta el registro en compra.
            //2. Se inserta el registro en compraDetalle. (obtener siguiente id de compra)
            //3. Se inserta el garron comprado en tabla garron. (TODO: TIPO UBICACION)
            //4. Los productos se suman en campo "Cantidad". 
            //4. end transaction

            MySqlConnection connection = ConnecionBD.Instance().Connection;
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
                    int idCompra = GetNextCompraId();
                    string consulta = "";
                    MySqlCommand command = new MySqlCommand(consulta, connection, tran);

                    // 1. Registrar operacion.
                    OperacionProveedor newOperacion = new OperacionProveedor();
                    newOperacion.Id = FuncionesOperaciones.GetNextIdOperacionProveedor();
                    VariablesGlobales.idOperacion = newOperacion.Id;

                    // Si el provedor != null creamos operacion con IdCuenta e IdProveedor
                    // Si el proveedor == null registramos la operacion pero el idProveedor en 0 y no referencia a ninguna cuenta.
                    if (provSelec!=null)
                    {
                        newOperacion.proveedor = provSelec;
                    }else
                    {
                        newOperacion.proveedor = new Proveedor();
                        newOperacion.proveedor.Id = 0;
                    }
                    
                    // Tipo Operacion = 3 (Compra Proveedor)
                    TipoOperacion to = new TipoOperacion();
                    to.Id = 3;
                    newOperacion.tipoOperacion = to;

                    consulta = manager.InsertOperacion(newOperacion);
                    command.CommandText = consulta;
                    if (!manager.ExecuteSQL(command))
                    {
                        tran.Rollback();
                        return -1;
                    }

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
                    if (!manager.ExecuteSQL(command))
                    {
                        tran.Rollback();
                        return -1;
                    }


                    // 3. Movimiento Cuenta Proveedor
                    // Insertamos el el total del monto de la compra en el debe de la cuenta.
                    MovimientoCuentaProveedor mcDebito = new MovimientoCuentaProveedor();
                    TipoMovimiento tp = new TipoMovimiento();
                    tp.Id = 1;
                    mcDebito.Operacion = newOperacion; //.Vob = '1';
                    mcDebito.TipoMovimiento = tp;
                    mcDebito.Cuenta = new Cuenta();
                    mcDebito.Cuenta.Id = idCuentaProveedor;
                    mcDebito.Monto = currentMontoCompra;
                    mcDebito.Cobrado = 'N';

                    consulta = QueryManager.Instance().InsertMovCuentaProveedor(mcDebito);
                    command.CommandText = consulta;
                    if (!manager.ExecuteSQL(command))
                    {
                        tran.Rollback();
                        return -1;
                    }

                    // Si pago una parte, insertamos en el haber la parte que pago.
                    // Sino insertamos el total en el haber de la cuenta.
                    if (!currentMontoPagado.Equals(decimal.Zero))
                    {  
                        // currentMontoPagado lo que pago
                        MovimientoCuentaProveedor mcPago = new MovimientoCuentaProveedor();
                        TipoMovimiento tp2 = new TipoMovimiento();
                        tp2.Id = 2;
                        mcPago.Operacion = newOperacion; 
                        mcPago.TipoMovimiento = tp2;
                        mcPago.Cuenta = new Cuenta();
                        mcPago.Cuenta.Id = idCuentaProveedor;
                        mcPago.Monto = currentMontoPagado;
                        mcPago.Cobrado = 'S';
                        consulta = QueryManager.Instance().InsertMovCuentaProveedor(mcPago);
                        command.CommandText = consulta;
                        if (!manager.ExecuteSQL(command))
                        {
                            tran.Rollback();
                            return -1;
                        }
                    }
                    else{
                        MovimientoCuentaProveedor mcPago2 = new MovimientoCuentaProveedor();
                        TipoMovimiento tp2 = new TipoMovimiento();
                        tp2.Id = 2;
                        mcPago2.Operacion = newOperacion;
                        mcPago2.TipoMovimiento = tp2;
                        mcPago2.Cuenta = new Cuenta();
                        mcPago2.Cuenta.Id = idCuentaProveedor;
                        mcPago2.Monto = currentMontoCompra;
                        mcPago2.Cobrado = 'S';
                        consulta = QueryManager.Instance().InsertMovCuentaProveedor(mcPago2);
                        command.CommandText = consulta;
                        if (!manager.ExecuteSQL(command))
                        {
                            tran.Rollback();
                            return -1;
                        }
                    }

                    //4. Se inserta el registro en compraDetalle. (obtener siguiente id de compra)
                    foreach (Garron g in listGarron)
                    {
                        // Insertamos el garron en garron.
                        int idGarron = FuncionesGarron.GetNextGarronId();
                        g.Id = idGarron;
                        // Se inserta el garron comprado en tabla garron. 
                        consulta = manager.InsertGarron(g);
                        command.CommandText = consulta;
                        if (!manager.ExecuteSQL(command))
                        {
                            tran.Rollback();
                            return -1;
                        }

                        consulta = manager.InsertCompraDetalle(idCompra, g);
                        command.CommandText = consulta;
                        if (!manager.ExecuteSQL(command))
                        {
                            tran.Rollback();
                            return -1;
                        }
                    }

                    foreach (Producto p in listProducto)
                    {
                        consulta = manager.InsertCompraDetalle(idCompra, p);
                        command.CommandText = consulta;
                        if (!manager.ExecuteSQL(command))
                        {
                            tran.Rollback();
                            return -1;
                        }
                    }

                    //5. Los productos se suman en campo "Cantidad". 
                    foreach (Producto p in listProducto)
                    {
                        consulta = manager.SumarCantidadProducto(p);
                        command.CommandText = consulta;
                        if (!manager.ExecuteSQL(command))
                        {
                            tran.Rollback();
                            return -1;
                        }
                    }

                    //6. Se ubican todos los productos ingresados en MESA DE ENTRADA.
                    foreach (Producto p in listProducto)
                    {
                        consulta = manager.UbicarCompraDetalleMesaEntrada(p);
                        command.CommandText = consulta;
                        if (!manager.ExecuteSQL(command))
                        {
                            tran.Rollback();
                            return -1;
                        }
                    }
                    //7. Se ubican todos los garrones en Mesa de Entrada
                    foreach (Garron g in listGarron)
                    {
                        consulta = manager.UbicarCompraDetalleMesaEntrada(g);
                        command.CommandText = consulta;
                        if (!manager.ExecuteSQL(command))
                        {
                            tran.Rollback();
                            return -1;
                        }
                    }

                    tran.Commit();
                    // Transaccion 
                    return idCompra;
                }
                catch (Exception e)
                {
                    FormMessageBox dialog = new FormMessageBox();
                    dialog.ShowErrorDialog("Error: " + e.Message);
                    return -1;
                }
            }
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
