using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;
using AppLaMejor.entidades;
using System.Data;
using MySql.Data.MySqlClient;
using AppLaMejor.formularios.Util;
using AppLaMejor.formularios.MovimientoCuentas;
using AppLaMejor.formularios;
using AppLaMejor.Reports;

namespace AppLaMejor.controlmanager
{
    public class FuncionesVentas
    {   
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
                    
                    // Setup
                    tran = connection.BeginTransaction();
                    QueryManager manager = QueryManager.Instance();
                    string consulta="";
                    MySqlCommand command = new MySqlCommand(consulta, connection, tran);

                    // Operacion
                    Operacion newOperacion = new Operacion();
                    VariablesGlobales.idOperacion = FuncionesOperaciones.GetNextIdOperacion();
                    newOperacion.Id = VariablesGlobales.idOperacion;
                    
                    // Venta
                    decimal montoTotal = listDetalleVentas.Sum(x => x.Monto);
                    int idVenta = GetNextIdVenta();
                    Venta newVenta = new Venta();
                    newVenta.MontoTotal = montoTotal;
                    newVenta.Id = idVenta;
                    newVenta.Operacion = newOperacion;

                    consulta = manager.InsertVenta(newVenta);
                    command.CommandText = consulta;
                    if (!manager.ExecuteSQL(command))
                    {
                        tran.Rollback();
                    }
                    
                    // Detalle de Ventas
                    foreach (VentaDetalle v in listDetalleVentas)
                    {
                        v.Venta = newVenta;
                        consulta = manager.InsertVentaDetalle(v);
                        command.CommandText = consulta;
                        if (!manager.ExecuteSQL(command))
                        {
                            tran.Rollback();
                        }

                        TipoProducto tp = TiposManager.Instance().GetTipoProductoKiosco();
                        // Si el producto no es del tipo Kiosco, operamos.
                        // Manejo de cantidades
                        if (!v.Producto.TipoProducto.Id.Equals(tp.Id))
                        {
                            ProductoUbicacion pu = FuncionesProductos.GetProductoUbicacion(v.Producto, FuncionesGlobales.ObtenerUbicacionSalida().Id);
                            // Sabemos que el peso de VentaDetalle nunca puede ser mayor a la cantidad de esa ubicacion, por que esta validado.
                            decimal calculo = decimal.Subtract(pu.peso, v.Peso);
                            if (calculo.Equals(0))
                            {
                                // agrego fecha_egreso y cantidad 0 al productoubicacion
                                consulta = manager.UpdateProductoUbicacionBaja(pu.Id);
                                command.CommandText = consulta;
                                if (!manager.ExecuteSQL(command))
                                {
                                    tran.Rollback();
                                    return false;
                                }
                            }
                            else
                            {
                                // Caso contrario queda un resto de producto y se resta lo retirado
                                consulta = manager.UpdateProductoUbicacion(pu.Id, calculo);
                                command.CommandText = consulta;
                                if (!manager.ExecuteSQL(command))
                                {
                                    tran.Rollback();
                                    return false;
                                }
                            }


                            // Se resta la cantidad del producto vendido en tabla Producto
                            Producto p = FuncionesProductos.GetProducto(v.Producto.Id);
                            decimal pesoRestanteTotal = decimal.Subtract(p.Cantidad, v.Peso);
                            consulta = manager.UpdateCantidadProducto(p.Id, pesoRestanteTotal);
                            command.CommandText = consulta;
                            if (!manager.ExecuteSQL(command))
                            {
                                tran.Rollback();
                                return false;
                            }
                        }
                    }

                    tran.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    FormMessageBox dialog = new FormMessageBox();
                    dialog.ShowErrorDialog("Error: " + e.Message);
                    return false;
                }
            }
        }
        public static bool InsertVentaMayorista(List<VentaDetalle> listDetalleVentas, Cliente cliente, Cuenta cuenta)
        {
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
                    string consulta = "" ;
                    MySqlCommand command = new MySqlCommand(consulta, connection, tran);
                    // Preparamos para registrar Venta
                    decimal montoTotal = listDetalleVentas.Sum(x => x.Monto);
                    int idVenta = GetNextIdVenta();
                    Venta newVenta = new Venta();
                    newVenta.MontoTotal = montoTotal;
                    newVenta.Id = idVenta;

                    // Preparamos la Operacion
                    VariablesGlobales.idOperacion = FuncionesOperaciones.GetNextIdOperacion();
                    Operacion newOperacion = new Operacion();
                    newOperacion.Id = VariablesGlobales.idOperacion;
                    newOperacion.cliente = cliente;
                    TipoOperacion tipoOperacion = new TipoOperacion();
                    tipoOperacion.Id = 1;
                    newOperacion.tipoOperacion = tipoOperacion;
                    // newOperacion.venta = newVenta;
                    // newOperacion.movCuenta = movCuenta;

                    // 1. Insertamos la operacion
                    consulta = manager.InsertOperacion(newOperacion);
                    command.CommandText = consulta;
                    if (!manager.ExecuteSQL(command))
                    {
                        tran.Rollback();
                    }

                    newVenta.Operacion = newOperacion;
                    // 2. Se inserta la venta
                    consulta = manager.InsertVenta(newVenta);
                    command.CommandText = consulta;
                    if (!manager.ExecuteSQL(command))
                    {
                        tran.Rollback();
                    }

                    // Generacion de vista para el reporte de la ultima venta
                    FuncionesReportes.informeVistaUltimaVenta(idVenta);

                    // 3. Se inserta el detalle de la venta.
                    foreach (VentaDetalle v in listDetalleVentas)
                    {
                        // 3.1 Insertamos venta detalle
                        v.Venta = newVenta;
                        consulta = manager.InsertVentaDetalle(v);
                        command.CommandText = consulta;
                        if (!manager.ExecuteSQL(command))
                        {
                            tran.Rollback();
                            return false;
                        }

                        if (v.Garron != null)
                        {
                            // Obtenemos ubicacion del garron
                            // Ubicacion ug = FuncionesGarron.GetUbicacionByGarron(v.Garron);
                            ProductoUbicacion pug = FuncionesGarron.GetProductoUbicacionByGarron(v.Garron.Id);

                            if (pug != null)
                            {
                                // Seteamos el egreso del producto ubicacion
                                consulta = manager.UpdateProductoUbicacionBaja(pug.Id);
                                command.CommandText = consulta;
                                if (!manager.ExecuteSQL(command))
                                {
                                    tran.Rollback();
                                    return false;
                                }

                                // Seteamos la fecha baja en garron
                                consulta = manager.UpdateFechaBajaGarron(v.Garron.Id);
                                command.CommandText = consulta;
                                if (!manager.ExecuteSQL(command))
                                {
                                    tran.Rollback();
                                    return false;
                                }
                            }
                            else
                            {
                                tran.Rollback();
                                return false;
                            }
                        }

                        if (v.Producto != null)
                        {
                            // 3.2 Operamos en producto ubicacion
							// Obtenemos la ubicacion de entrada por defecto.
                            ProductoUbicacion pu = FuncionesProductos.GetProductoUbicacion(v.Producto, FuncionesGlobales.ObtenerUbicacionEntrada().Id);
                            // Sabemos que el peso de VentaDetalle nunca puede ser mayor a la cantidad de esa ubicacion, por que esta validado.
                            decimal calculo = decimal.Subtract(pu.peso, v.Peso);
                            if (calculo.Equals(0))
                            {
                                // agrego fecha_egreso y cantidad 0 al productoubicacion
                                consulta = manager.UpdateProductoUbicacionBaja(pu.Id);
                                command.CommandText = consulta;
                                if (!manager.ExecuteSQL(command))
                                {
                                    tran.Rollback();
                                    return false;
                                }
                            }
                            else
                            {
                                // Caso contrario queda un resto de producto y se resta lo retirado
                                consulta = manager.UpdateProductoUbicacion(pu.Id, calculo);
                                command.CommandText = consulta;
                                if (!manager.ExecuteSQL(command))
                                {
                                    tran.Rollback();
                                    return false;
                                }
                            }

                            // 3.3 Operamos en tabla Producto
                            Producto p = FuncionesProductos.GetProducto(v.Producto.Id);
                            decimal pesoRestanteTotal = decimal.Subtract(p.Cantidad, v.Peso);
                            consulta = manager.UpdateCantidadProducto(p.Id, pesoRestanteTotal);
                            command.CommandText = consulta;
                            if (!manager.ExecuteSQL(command))
                            {
                                tran.Rollback();
                                return false;
                            }
                        }                        
                    }

                    MovimientoCuenta mcDebito = new MovimientoCuenta();
                    TipoMovimiento tp = new TipoMovimiento();
                    tp.Id = 1;

                    mcDebito.Operacion = newOperacion; //.Vob = '1';
                    mcDebito.TipoMovimiento = tp;
                    mcDebito.Cuenta = cuenta;
                    mcDebito.Monto = montoTotal;
                    mcDebito.Cobrado = 'N';

                    consulta = manager.InsertMovCuenta(mcDebito);
                    command.CommandText = consulta;
                    if (!manager.ExecuteSQL(command))
                    {
                        tran.Rollback();
                    }

                    // Modifica vista de reporte ultima venta.
                    consulta = manager.ReportVistaUltimaVenta(cliente.Id, newOperacion.Id);
                    command.CommandText = consulta;
                    if (!manager.ExecuteSQL(command))
                    {
                        tran.Rollback();
                    }

                    // Modifica vista de reporte ultima venta por cliente.
                    consulta = manager.ReportVistaUltimaVentaPorCliente(cliente.Id);
                    command.CommandText = consulta;
                    if (!manager.ExecuteSQL(command))
                    {
                        tran.Rollback();
                    }

                    // Modifica vista de reporte vista seleccionada
                    consulta = manager.ReportVistaVentaSeleccionada(idVenta);
                    command.CommandText = consulta;
                    if (!manager.ExecuteSQL(command))
                    {
                        tran.Rollback();
                    }

                    tran.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    FormMessageBox dialog = new FormMessageBox();
                    dialog.ShowErrorDialog("Error: " + e.Message);
                    if (tran == null)
                    {
                        return false;
                    }
                    tran.Rollback();
                    return false;
                }
            }
        }
        public static int GetNextIdVenta()
        {
            QueryManager manager = QueryManager.Instance();
            string consulta = manager.GetNextVentaId();
            DataTable result = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
            if (result.Rows[0][0].ToString().Length == 0)
                return 1;
            else return Int32.Parse(result.Rows[0][0].ToString());
        }
        public static int GetNextIdOperacion()
        {
            QueryManager manager = QueryManager.Instance();
            string consulta = manager.GetNextOperacionId();
            DataTable result = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);

            if (result.Rows[0][0].ToString().Length == 0)
                return 1;
            else return Int32.Parse(result.Rows[0][0].ToString());
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
