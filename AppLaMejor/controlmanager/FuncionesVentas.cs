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
                    string consulta;

                    decimal montoTotal = listDetalleVentas.Sum(x => x.Monto);
                    int idVenta = GetNextIdVenta();

                    Venta newVenta = new Venta();
                    newVenta.MontoTotal = montoTotal;
                    newVenta.Id = idVenta;
                    consulta = manager.InsertVenta(newVenta);

                    // Transaccion
                    MySqlCommand command = new MySqlCommand(consulta, connection, tran);
                    if (!manager.ExecuteSQL(command))
                    {
                        tran.Rollback();
                    }

                    foreach (VentaDetalle v in listDetalleVentas)
                    {
                        v.Venta = newVenta;
                        consulta = manager.InsertVentaDetalle(v);
                        command.CommandText = consulta;
                        if (!manager.ExecuteSQL(command))
                        {
                            tran.Rollback();
                        }
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

        public static bool InsertVentaMayorista(List<VentaDetalle> listDetalleVentas, Cliente cliente, MovimientoCuenta movCuenta)
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
                    string consultaVenta, consultaOperacion;

                    decimal montoTotal = listDetalleVentas.Sum(x => x.Monto);

                    // venta

                    int idVenta = GetNextIdVenta();

                    Venta newVenta = new Venta();
                    newVenta.MontoTotal = montoTotal;
                    newVenta.Id = idVenta;
                    consultaVenta = manager.InsertVenta(newVenta);
                    // movcuenta

                    movCuenta.Id = VariablesGlobales.idMovCuenta_VentaMay;

                    //operacion

                    TipoOperacion tipoOperacion = new TipoOperacion();

                    tipoOperacion.Id = 1;

                    int idOperacion = GetNextIdOperacion();

                    Operacion newOperacion = new Operacion();
                    newOperacion.Id = idOperacion;
                    newOperacion.cliente = cliente;
                    newOperacion.venta = newVenta;
                    newOperacion.movCuenta = movCuenta;
                    newOperacion.tipoOperacion = tipoOperacion;
                    consultaOperacion = manager.InsertOperacion(newOperacion);

                    

                    // Transaccion
                    MySqlCommand commandVenta = new MySqlCommand(consultaVenta, connection, tran);
                    
                    if (!manager.ExecuteSQL(commandVenta))
                    {
                        tran.Rollback();
                    }
                    

                    foreach (VentaDetalle v in listDetalleVentas)
                    {
                        v.Venta = newVenta;
                        consultaVenta = manager.InsertVentaDetalle(v);
                        commandVenta.CommandText = consultaVenta;
                        if (!manager.ExecuteSQL(commandVenta))
                        {
                            tran.Rollback();
                        }
                    }

                    tran.Commit();

                    QueryManager.Instance().ExecuteSQL(ConnecionBD.Instance().Connection,consultaOperacion);

                    /*  movCuenta1.TipoMovimiento = tp;

                        movCuenta1.Vob = '1';

                        movCuenta1.Cuenta = cuenta;
                        Decimal montoto = Convert.ToDecimal(tbImporte.Text);
                        movCuenta1.Monto = montoto;
                        movCuenta1.Fecha = DateTime.Now.AddDays(0);
                        movCuenta1.Cobrado = 'N';
                        movCuenta1.idUsuario = VariablesGlobales.userIdLogueado;
                        movCuenta.Vob + "," +

                  movCuenta.Cuenta.Id + "," +
                  movCuenta.TipoMovimiento.Id + "," +
                  movCuenta.Monto + ", NOW(),'" +
                  movCuenta.Cobrado + "'," +
                  movCuenta.idUsuario
                  */

                    MovimientoCuenta mcDebito = new MovimientoCuenta();
                    TipoMovimiento tp = new TipoMovimiento();

                    tp.Id = 1;

                    mcDebito.Vob = '1';
                    mcDebito.TipoMovimiento = tp;
                    mcDebito.Cuenta = movCuenta.Cuenta;
                    mcDebito.Monto = montoTotal;
                    mcDebito.Cobrado = 'N';
                    mcDebito.idUsuario = VariablesGlobales.userIdLogueado;

                    FuncionesMovCuentas.insertarMovimiento(mcDebito);

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
            return Int32.Parse(result.Rows[0][0].ToString());
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
