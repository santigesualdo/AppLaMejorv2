﻿using System;
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
                    // primera ejecucion 
                    //1. Se cierra el historico anterior con la fecha actual

                    int idCompra = GetNextCompraId();

                    string consulta = "";
                    MySqlCommand command = new MySqlCommand(consulta, connection, tran);

                    OperacionProveedor newOperacion = null;

                    // Si el idCuentaProveedor es diferente de 0 tiene cuenta, creamos operacion con IdCuenta e IdProveedor
                    if (!idCuentaProveedor.Equals(0))
                    {
                        //consulta = manager.
                        newOperacion = new OperacionProveedor();
                        newOperacion.Id = VariablesGlobales.idOperacion;
                        newOperacion.proveedor = provSelec;
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
                    }

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

                    if (!currentMontoPagado.Equals(decimal.Zero))
                    {
                        // Insertar movCuentaProveedor
                        // currentMontoCompra lo que debe
                        
                        MovimientoCuentaProveedor mcDebito = new MovimientoCuentaProveedor();
                        TipoMovimiento tp = new TipoMovimiento();
                        tp.Id = 1;
                        mcDebito.Operacion = newOperacion; //.Vob = '1';
                        mcDebito.TipoMovimiento = tp;
                        mcDebito.Cuenta.Id = idCuentaProveedor;
                        mcDebito.Monto = currentMontoCompra;
                        mcDebito.Cobrado = 'N';
                        mcDebito.idUsuario = VariablesGlobales.userIdLogueado;
                        FuncionesMovCuentas.insertarMovimientoProveedor(mcDebito);
    
                        // currentMontoPagado lo que pago
                        MovimientoCuentaProveedor mcPago = new MovimientoCuentaProveedor();
                        TipoMovimiento tp2 = new TipoMovimiento();
                        tp2.Id = 2;
                        mcDebito.Operacion = newOperacion; //.Vob = '1';
                        mcDebito.TipoMovimiento = tp2;
                        mcDebito.Cuenta.Id = idCuentaProveedor;
                        mcDebito.Monto = currentMontoPagado;
                        mcDebito.Cobrado = 'S';
                        mcDebito.idUsuario = VariablesGlobales.userIdLogueado;
                        FuncionesMovCuentas.insertarMovimientoProveedor(mcPago);
                    }


                    // segunda ejecucion             
                    //2. Se inserta el registro en compraDetalle. (obtener siguiente id de compra)
                    foreach (Garron g in listGarron)
                    {
                        // Insertamos el garron en garron.
                        int idGarron = FuncionesGarron.GetNextGarronId();
                        g.Id = idGarron;

                        consulta = manager.InsertGarron(g);
                        command.CommandText = consulta;
                        if (!manager.ExecuteSQL(command))
                        {
                            tran.Rollback();
                            return -1;
                        }

                        // Se inserta el garron comprado en tabla garron. 
                        
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

                    //4. Los productos se suman en campo "Cantidad". 
                    foreach (Producto p in listProducto)
                    {
                        consulta = manager.UpdateCantidadProducto(p);
                        command.CommandText = consulta;
                        if (!manager.ExecuteSQL(command))
                        {
                            tran.Rollback();
                            return -1;
                        }
                    }

                    //5. Se ubican todos los productos ingresados en MESA DE ENTRADA.
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
                    //6. Se ubican todos los garrones en Mesa de Entrada
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
