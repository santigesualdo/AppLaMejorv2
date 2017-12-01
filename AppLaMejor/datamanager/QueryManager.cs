using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using AppLaMejor.entidades;
using AppLaMejor.formularios.Util;
using System.Threading;
using System.Globalization;
using System.Data.SqlClient;
using AppLaMejor.controlmanager;

namespace AppLaMejor.datamanager
{
    class QueryManager 
    {
        private static QueryManager _instance = null;

        /* Clase singleton que retorna consultas sql en un string */
        public static QueryManager Instance()
        {
            if (_instance == null)
                _instance = new QueryManager();
            return _instance;
        }

        /* Operaciones Generales */
        /* Recibe coneccion y consulta, y retorna data table llena */
        public DataTable GetTableResults(MySqlConnection conn, string query)
        {
            try
            {
                using (conn)
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dtTabla = new DataTable();
                    da.Fill(dtTabla);
                    return dtTabla;
                }
            }
            catch (Exception ex)
            {
                FormMessageBox dialog = new FormMessageBox();
                dialog.ShowErrorDialog("Ocurrio un fallor en la BD: " + ex.Message);
                return null;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public AutoCompleteStringCollection GetAutoCompleteCollection(MySqlConnection conn, string query, int sourceIndex)
        {
            try
            {
                using (conn)
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        // Campo RazonSocial
                        collection.Add(reader.GetString(sourceIndex));
                    }

                    return collection;
                }
            }
            catch (Exception ex)
            {
                FormMessageBox dialog = new FormMessageBox();
                dialog.ShowErrorDialog("Ocurrio un fallor en la BD: " + ex.Message);
                return null;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        /* Recibe conexion y consulta y ejecuta update. Retorna true o false, exito o error */
        public bool ExecuteSQL(MySqlConnection conn, string query)
        {
            MySqlCommand sqlCommand = new MySqlCommand(query, conn);
            try
            {                
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                FormMessageBox dialog = new FormMessageBox();
                dialog.ShowErrorDialog("Ocurrio un fallor en la BD: " + ex.Message);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        // Se usa para transacciones, en caso de escribir varias tablas, si falla alguna, no se escribe nada.
        public bool ExecuteSQL(MySqlCommand sqlCommand)
        {
            try { 
             if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                FormMessageBox dialog = new FormMessageBox();
                dialog.ShowErrorDialog("Ocurrio un fallor en la BD: " + ex.Message);
                return false;
            }
        }

        /* Tipos */
        public string GetTipoMovimiento()
        {
            return "CALL listarMovimientoTipo();";
        }
        public string GetTipoCliente()
        {
            return "CALL listarTipoCliente();";
        }
        public string GetTipoClienteByIdCliente(int idCliente)
        {
            return "CALL obtenerTipoClientePorIdCliente( " + idCliente.ToString() + ");";
        }
        public string GetTipoProducto()
        {
            return "CALL listarTipoProducto();";
        }
        public string GetTipoProductoByIdProducto(int idProducto)
        {
            return "CALL obtenerTipoProdutoPorIdProducto(" + idProducto.ToString() + ");";
        }
        
        /* Usuarios */
        public string GetUsuarioByName(string name){
            return "CALL obtenerUsuarioPorNombre('" + name + "';";
        }
        public string GetUsuariosModulos(int idUsuario)

        {
            return "CALL obtenerUsuariosModulos(" + idUsuario.ToString() + ");";
        }
        public string GetUserLogin(string userName, string pass)
        {
            return "select * from usuario where username = '" + userName + "'  and  pass ='" + pass + "'";
            //CALL obtenerUsuarioLogin no anda, problema de collattion
        }
        
        /* Clientes */
        public string InsertNuevoCliente(Cliente cliente)
        {
            string consulta;
            consulta = "call grabarNuevoCLiente('" + cliente.CodCliente + "','" + cliente.RazonSocial + "', " +
                " '" + cliente.Domicilio + "', " +
                " '" + cliente.Localidad + "', " +
                " '" + cliente.Iva + "', " +
                " " + cliente.TipoCliente.Id + ", " +
                " '" + cliente.NombreLocal + "', " +
                " '" + cliente.Cuit + "', " +
                " '" + cliente.Telefono+ "', " +
                " '" + cliente.NombreResponsable + "', " +
                " '" + cliente.FechaDesde.ToString("yyyy-MM-dd") + "'," +
                VariablesGlobales.userIdLogueado.ToString() + ");";

            return consulta;
        }
        public string UpdateCliente(Cliente cliente)
        {
            string query = "call actualizarCliente(" + cliente.Id.ToString() + ",'" + cliente.CodCliente + "',  " +
                "'" + cliente.RazonSocial + "','" + cliente.Domicilio + "','" + cliente.Localidad + "',  " +
                "'" + cliente.Iva + "','" + cliente.TipoCliente.Id + "','" + cliente.NombreLocal + "',  " +
                "'" + cliente.Telefono + "','" + cliente.Cuit + "','" + cliente.NombreResponsable + "',  " +
                "'" + cliente.FechaDesde.ToString("yyyy-MM-dd") + "','" + VariablesGlobales.userIdLogueado.ToString() + "');";
            return query;
        }
        public string GetClientes()
        {
            return "call obtenerClientes();";
        }
        public string GetClientes(int id)
        {
            return "call obtenerClientes(" + id + ");";
        }
        public string GetClientesData()
        {
            return "CALL obtenerClientesData();";
        }
        //trae el saldo actual y algunos datos de referencia para el form de MovCuentas
        public string GetClientesSaldoActual()
        {
           // return "CALL obtenerClientesSaldoActual()";
            return "SELECT cliente.id, cliente.cod_cliente as CodCliente, cliente.razon_social AS `RazonSocial`, cliente.nombre_local AS `NombreLocal`, cliente.civa AS IVA, cast(cliente.id_tipo_cliente as CHAR(50)) AS TipoCliente,count(cuenta.id) AS CantidadCuentas FROM cliente inner join clientecuenta cuenta on cliente.id = cuenta.id_cliente       INNER JOIN banco ON cuenta.id_banco = banco.id INNER JOIN clientetipo ct ON ct.id = cliente.id_tipo_cliente group by cliente.id order by cliente.id";

        }

        public string GetDeleteClient(string idCliente, DateTime fechaBaja)
        {
            //return "update cliente set fecha_baja ='" + fechaBaja.ToString("yyyy-MM-dd") + "' where id = "+ idCliente+";";
            return "CALL borrarCliente(" + idCliente.ToString() + ",'" + fechaBaja.ToString("yyyy-MM-dd") + "')";
        }

        /* Proveedores */
        public string InsertNuevoProveedor(Proveedor Proveedor)
        {
            //revisar
            return "INSERT INTO Proveedor ( razon_social, domicilio, localidad, civa, nombre_local, cuit, telefono, nombre_responsable, fecha_desde, fecha_baja, usuario) " +
                " VALUES ( '" + Proveedor.RazonSocial + "', " +
                " '" + Proveedor.Domicilio + "', " +
                " '" + Proveedor.Localidad + "', " +
                " '" + Proveedor.Iva + "', " +
                " '" + Proveedor.NombreLocal + "', " +
                " '" + Proveedor.Cuit + "', " +
                " '" + Proveedor.Telefono + "', " +
                " '" + Proveedor.NombreResponsable + "', " +
                " '" + Proveedor.FechaDesde.ToString("yyyy-MM-dd") + "', " +
                " null ," +
                VariablesGlobales.userIdLogueado.ToString() + ");";

        }
    
        public string GetProveedores()
        {
            return "CALL obtenerProveedores();";
        }
        public string GetProveedores(int id)
        {
            return "CALL obtenerProveedoresPorId(" + id + ");";
        }
        public string GetProveedoresData()
        {
            return "CALL obtenerProveedoresData();";
        }        
        //trae el saldo actual y algunos datos de referencia para el form de MovCuentas
        public string GetProveedoresSaldoActual()
        {
            return "call obtenerProveedoresSaldoActual()";
        }
        public string GetDeleteProv(string idProveedor, DateTime fechaBaja)
        {
            return "call borrarProveedor('" + idProveedor.ToString() + "','" + fechaBaja.ToString("yyyy-MM-dd") + "')";
        }
        public string UpdateProveedor(Proveedor proveedor)
        {
            string query = "call actualizarProveedor(" +
                "'" + proveedor.Id + "',  " +
                "'" + proveedor.RazonSocial + "',  " +
                "'" + proveedor.Domicilio + "',  " +
                "'" + proveedor.Localidad + "',  " +
                "'" + proveedor.Iva + "',  " +
                "'" + proveedor.NombreLocal + "',  " +
                "'" + proveedor.Telefono + "',  " +
                "'" + proveedor.Cuit + "',  " +
                "'" + proveedor.NombreResponsable + "',  " +
                "'" + proveedor.FechaDesde.ToString("yyyy-MM-dd") + "', " +
                "'" + proveedor.idUsuario + "');";
            return query;
        }
        

        public string GetProveedorByName(string text)
        {
            return
                " SELECT " +
             "	c.id , " +
             "	c.razon_social AS RazonSocial, " +
             "	c.domicilio AS Domicilio, " +
             "	c.localidad AS Localidad, " +
             "  c.fecha_desde as FechaDesde, " +
             "	c.civa AS IVA, " +
             "	c.cuit AS CUIT, " +
             "	c.nombre_responsable AS NombreResponsable, " +
             "	c.nombre_local AS NombreLocal, " +
             "	c.telefono AS Telefono," +
             "	c.fecha_baja AS FechaBaja " +
             " FROM " +
             "	Proveedor c " +
             "  WHERE c.fecha_baja is null " +
             "  AND c.razon_social LIKE '%"+text+"%'";

            /*
             * CALL obtenerProveedorPorNombre tiene problemas de collation
             * 
                select id, razon_social AS RazonSocial, domicilio AS Domicilio, localidad AS Localidad, fecha_desde as FechaDesde,
                civa AS IVA, cuit AS CUIT, nombre_responsable AS NombreResponsable, nombre_local AS NombreLocal,
                telefono AS Telefono, fecha_baja AS FechaBaja FROM proveedor WHERE fecha_baja is NULL
                AND razon_social LIKE CONCAT('%',name_,'%')
             */
        }

        /* Cuentas */
        public string GetClientesWithCuentaById(int id){
            return "SELECT c.id , " +
            "	c.cod_cliente AS CodCliente, " +
            "	c.razon_social AS 'Razon Social', " +
            "	c.domicilio AS Domicilio, " +
            "	c.localidad AS Localidad, " +
            "	cast(ct.id as CHAR(50)) AS TipoCliente, " +
            "	cu.id AS IdCuenta, " +
            "  c.fecha_desde as FechaDesde, " +
            "	c.civa AS IVA, " +
            "	c.cuit AS CUIT, " +
            "	c.nombre_responsable AS NombreResponsable, " +
            "	c.nombre_local AS NombreLocal, " +
            "	c.telefono AS Telefono " +
            " FROM " +
            "	cliente c " +
            " INNER JOIN clientetipo ct ON ct.id = c.id_tipo_cliente INNER JOIN clientecuenta cu ON cu.id_cliente = c.id " +
            " WHERE c.id =" + id +
            "   AND c.fecha_baja is null  " +
            "   order by c.id  ";

        }

        public string GetClientesWithCuenta()
        {
            //return "CALL obtenerClientesConCuenta()";
            //POR ALGUNA RAZON ESTO EN SP NO FUNCIONA
            return "SELECT c.id , " +
             "	c.cod_cliente AS CodCliente, " +
             "	c.razon_social AS RazonSocial, " +
             "	c.domicilio AS Domicilio, " +
             "	c.localidad AS Localidad, " +
             "	cast(ct.id as CHAR(50)) AS TipoCliente, " +
             "	cu.id AS IdCuenta, " +
             "  c.fecha_desde as FechaDesde, " +
             "	c.civa AS IVA, " +
             "	c.cuit AS CUIT, " +
             "	c.nombre_responsable AS NombreResponsable, " +
             "	c.nombre_local AS NombreLocal, " +
             "	c.telefono AS Telefono " +
             " FROM " +
             "	cliente c " +
             " INNER JOIN clientetipo ct ON ct.id = c.id_tipo_cliente INNER JOIN clientecuenta cu ON cu.id_cliente = c.id " +
             " WHERE " +
             "   c.fecha_baja is null  " +
             "   order by c.id  ";
        }
        public string GetCuentaByIdCliente(int id)
        {
            return "CALL obtenerCuentasPorIdCliente(" + id.ToString() + ");";
        }
  
        public string GetCuenta(int id)
        {
            return "CALL obtenerClienteCuentaPorId(" + id.ToString() + ");";
        }
        public string GetCuentas()
        {
            return "CALL obtenerClienteCuentas();";
        }
        public string GetCuentas(int idCliente)
        {
            //string hini = "CALL obtenerTodasCuentasPorCliente(" + idCliente.ToString() + ");"; //es muy bueeeeno string-hini

            //string hini = "SELECT banco.descripcion, cuenta.id as id_cuenta, cuenta.cbu, cuenta.nro_cuenta, cuenta.fecha_updated " +
            //    " FROM cliente inner join clientecuenta cuenta on cliente.id = cuenta.id_cliente" +
            //    " INNER JOIN banco ON cuenta.id_banco = banco.id INNER JOIN clientetipo ct ON ct.id = cliente.id_tipo_cliente where cliente.id = " + idCliente + " order by cuenta.id;";


            string hini = "SELECT banco.descripcion as Banco,  c.id AS id_cuenta,  c.cbu,  c.descripcion,  c.fecha_updated " +
                " FROM cliente INNER JOIN clientecuenta c ON cliente.id = c.id_cliente " + 
                " INNER JOIN banco ON c.id_banco = banco.id INNER JOIN clientetipo ct ON ct.id = cliente.id_tipo_cliente WHERE cliente.id = "+ idCliente +" ORDER BY c.id ";

            return hini;
        }
        public string InsertNuevaCuenta(Cuenta newCuenta, string idCliente)
        {
            return "CALL grabarNuevaClienteCuenta('" + newCuenta.Cbu + "', '" +
            newCuenta.Descripcion + "', '" +
            idCliente + "', '" +
            newCuenta.Banco.Id+"','"+ VariablesGlobales.userIdLogueado.ToString() + "');";
        }

        /* Cuentas proveedores */
        /* Movimiento Cuentas proveedores */
        public string GetProveedoresWithCuentaById(int id)
        {
            string hini = "CALL obtenerProveedorConCuentasPorIdProveedor(" + id.ToString() + ");";
            return hini;
        }
        public string GetProveedoresWithCuenta()
        {
            string hini = "CALL obtenerProveedoresConCuenta();";
            return hini;
        }
        public string GetCuentaByIdProveedor(int id)
        {
            string hini = "CALL obtenerProveedoresConCuenta(" + id.ToString() + ");";
            return hini;
        }

        public string GetCuentaProveedor(int id)
        {
            string hini = "CALL obtenerProveedorCuentaPorId(" + id.ToString() + ");";
            return hini;
        }
        public string GetCuentasProveedor()
        {
            string hini = "CALL obtenerProveedorCuentas();";
            return hini;
        }
        public string GetCuentasProveedores(int idProveedor)
        {
            string hini = "CALL obtenerProveedorConCuentasPorIdProveedor(" + idProveedor.ToString() + "); ";
            return hini;
        }

        //HASTA ACAAAAAAAAAA PAPAAAAAAAAA
        public string InsertNuevaCuentaProveedor(Cuenta newCuenta, string idProveedor)
        {
            return "INSERT INTO proveedorcuenta ( cbu, descripcion, id_proveedor, fecha_updated, usuario, fecha_baja) " +
            " VALUES ('" + newCuenta.Cbu + "', '" +
            newCuenta.Descripcion + "', '" +
											
            idProveedor + "', " +
            " NOW() , 0 , null );";
        }

        /* Movimiento Cuentas */
        public string GetMovCuentas()
        {/* trae todos los movimiento de cuentas de todos los clientes*/
            return "SELECT " +
                    "cm.id, " +
                    "cm.vob," +
                    "gc.id," +
                    "gc.id_cliente," +
                    "cm.id_cuenta, " +
                    "cm.id_movimiento_tipo," +
                    "mt.descripcion, " +
                    "gc.id_banco, " +
                    "round(cm.monto, 2) AS monto, " +
                    "DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS fecha_," +
                    "cm.cobrado, " +
                    "cm.usuario " +
                    "FROM clientecuentamovimiento cm INNER JOIN clientecuenta gc ON cm.id_cuenta = gc.id " +
                    "INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id " +
                    "WHERE gc.id_cliente IS NOT NULL ORDER BY cm.id DESC;";
        }      												   
		public string GetMovCuentas(int id, int pInicio, int registros)
        {
            /* trae paginando los movimiento de cuentas de un solo cliente*/

            return "SELECT " +
                    "cm.id, " +
                    "cm.vob," +
                    "cc.id," +
                    "cc.id_cliente," +
                    "banco.descripcion as Banco, " +
                    "cm.id_movimiento_tipo," +
                    "mt.descripcion, " +
                    "banco.descripcion as Banco, " +
                    "round(cm.monto, 2) AS monto, " +
                    "DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS fecha_" +
                    " FROM clientecuentamovimiento cm INNER JOIN clientecuenta cc ON cm.id_cuenta = cc.id " +
                    "INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id " +
                    "INNER JOIN banco ON banco.id = cc.id_banco WHERE cc.id_cliente =" + id.ToString() + " ORDER BY cm.id DESC LIMIT " +
                    pInicio.ToString() + ", " + registros.ToString() + ";";
        }        
        public string GetMovCuentasBetweenDates(int id, int pInicio, int registros, string fdesde, string fhasta)
        {
            /* trae paginando los movimiento de cuentas de un solo cliente*/

            return "SELECT " +
                    "cm.id, " +
                    "cm.vob," +
                    "gc.id," +
                    "gc.id_cliente," +
                    "cm.id_cuenta, " +
                    "cm.id_movimiento_tipo," +
                    "mt.descripcion, " +
                    "banco.descripcion as Banco, " +
                    "round(cm.monto, 2) AS monto, " +
                    "DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS fecha_" +

                    " FROM clientecuentamovimiento cm INNER JOIN clientecuenta gc ON cm.id_cuenta = gc.id " +
                    "INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id " +
                    "INNER JOIN banco ON banco.id = gc.id_banco WHERE gc.id_cliente =" + id.ToString() + " AND DATE_FORMAT(cm.fecha, '%Y-%m-%d') BETWEEN '" + fdesde + 
                    "' AND '" + fhasta  + "' ORDER BY cm.id DESC LIMIT " +
                    pInicio.ToString() + ", " + registros.ToString() + ";";
        } 		
		public string GetMovCuentasContarBetweenDates(int idCliente, string fdesde, string fhasta)				
        {
            /* cuenta cuantos registros hay en total */

            return "SELECT count(*) FROM clientecuentamovimiento cm INNER JOIN clientecuenta gc ON cm.id_cuenta = gc.id INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id WHERE gc.id_cliente = " + idCliente.ToString() + " AND DATE(cm.fecha) BETWEEN '" + fdesde +
                    "' AND '" + fhasta + "' ORDER BY cm.id DESC;";
        }
        public string GetMovCuentasProveedoresContarBetweenDates(int idProveedor, string fdesde, string fhasta)
        {
            /* cuenta cuantos registros hay en total */

            return "SELECT count(*) FROM proveedorcuentamovimiento cm INNER JOIN proveedorcuenta gc ON cm.id_cuenta = gc.id INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id WHERE gc.id_proveedor = " + idProveedor.ToString() + " AND DATE(cm.fecha) BETWEEN '" + fdesde +
                    "' AND '" + fhasta + "' ORDER BY cm.id DESC;";           
        }		
        public string GetMovCuentasContar(int id)
														  
        {
            /* cuenta cuantos registros hay en total */

            return "SELECT count(*) " +
                    "FROM clientecuentamovimiento cm INNER JOIN clientecuenta gc ON cm.id_cuenta = gc.id " +
                    "INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id " +
                    "WHERE gc.id_cliente =" + id.ToString() + " ORDER BY cm.id DESC;";
        }       
        public string InsertMovCuenta(MovimientoCuenta movCuenta)
        {
            /* persiste el movimiento de cuenta*/
            return "INSERT INTO clientecuentamovimiento(" +
                "vob," +
                "id_cuenta," +
                "id_movimiento_tipo," +
                "monto," +
                "fecha," +
                "cobrado," +
                "usuario)" +
                "VALUES (" +

                movCuenta.Vob + "," +
                movCuenta.Cuenta.Id + "," +
                movCuenta.TipoMovimiento.Id + "," +
                movCuenta.Monto + ", NOW(),'" +
                movCuenta.Cobrado + "'," +
                movCuenta.idUsuario + ");";
        }			
        /* Movimiento Cuentas proveedores */
        public string GetMovCuentasProveedores()
        {
            /* trae todos los movimiento de cuentas de todos los proveedores*/
            return "SELECT cm.id, cm.vob, gc.id, gc.id_proveedor, cm.id_cuenta, cm.id_movimiento_tipo, mt.descripcion, gc.id_banco, round(cm.monto, 2) AS monto, DATE_FORMAT(cm.fecha, '%Y-%m-%d') AS fecha_,  cm.cobrado, cm.usuario FROM proveedorcuentamovimiento cm INNER JOIN proveedorcuenta gc ON cm.id_cuenta = gc.id INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id WHERE gc.id_proveedor IS NOT NULL ORDER BY cm.id DESC;";
        }		
		public string GetMovCuentasProveedor(int id, int pInicio, int registros)												   
        {
            /* trae paginando los movimiento de cuentas de un solo cliente*/

            return "SELECT " +
                    "cm.id, " +
                    "cm.vob," +
                    "gc.id," +
                    "gc.id_proveedor," +
                    "banco.descripcion as Banco, " +
                    "cm.id_movimiento_tipo," +
                    "mt.descripcion, " +
                    "banco.descripcion as Banco, " +
                    "round(cm.monto, 2) AS monto, " +
                    "DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS fecha_" +
                    " FROM proveedorcuentamovimiento cm INNER JOIN proveedorcuenta gc ON cm.id_cuenta = gc.id " +
                    "INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id " +
                    "INNER JOIN banco ON banco.id = gc.id_banco WHERE gc.id_proveedor = " + id.ToString() + " ORDER BY cm.id DESC LIMIT " +
                    pInicio.ToString() + ", " + registros.ToString() + ";";
        }
        public string GetMovCuentasProveedorBetweenDates(int id, int pInicio, int registros, string fdesde, string fhasta)															   
        {
            /* trae paginando los movimiento de cuentas de un solo proveedor*/

            return "SELECT " +
                    "cm.id, " +
                    "cm.vob," +
                    "gc.id," +
                    "gc.id_proveedor," +
                    "cm.id_cuenta, " +
                    "cm.id_movimiento_tipo," +
                    "mt.descripcion, " +
                    "banco.descripcion as Banco, " +
                    "round(cm.monto, 2) AS monto, " +
                    "DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS fecha_ " +
                    "FROM proveedorcuentamovimiento cm INNER JOIN proveedorcuenta gc ON cm.id_cuenta = gc.id " +
                    "INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id " +															  
                    "INNER JOIN banco ON banco.id = gc.id_banco WHERE gc.id_proveedor =" + id.ToString() + " AND DATE_FORMAT(cm.fecha, '%Y-%m-%d') BETWEEN '" + fdesde +
                    "' AND '" + fhasta + "' ORDER BY cm.id DESC LIMIT " +
                    pInicio.ToString() + ", " + registros.ToString() + ";";
        }		
        public string GetMovCuentasProveedorContar(int id)
        {
            /* cuenta cuantos registros hay en total */

            return "SELECT count(*) " +
                    "FROM proveedorcuentamovimiento cm INNER JOIN proveedorcuenta gc ON cm.id_cuenta = gc.id " +
                    "INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id " +
                    "WHERE gc.id_proveedor =" + id.ToString() + " ORDER BY cm.id DESC;";
																  
        }
        public string InsertMovCuentaProveedor(MovimientoCuenta movCuenta)
        {
            /* persiste el movimiento de cuenta*/
            return "INSERT INTO proveedorcuentamovimiento(" +
                "vob," +
                "id_cuenta," +
                "id_movimiento_tipo," +
                "monto," +
                "fecha," +
                "cobrado," +
                "usuario)" +
                "VALUES (" +

                movCuenta.Vob + "," +
                movCuenta.Cuenta.Id + "," +
                movCuenta.TipoMovimiento.Id + "," +
                movCuenta.Monto + ", NOW(),'" +
                movCuenta.Cobrado + "'," +
                movCuenta.idUsuario + ");";
        }		
        /* Ventas */
        public string GetProductoFromIdCode(string idCode)
        {
            return GetProductosData() +
                " and id_codigo_barra like '" + idCode + "'";
        }
        public string GetProductoById(int id){
            return "select * From producto where id = "+id+";";
        }
        public string GetTipoProductoEstado()
        {
            return "select * From productoestadotipo ;";
        }
        public string GetTipoProductoEstadoByIdProducto(int idProducto)
        {
            return "select * from producto where idProducto = ";
        }
        public string InsertVentaDetalle(VentaDetalle vd)
        {
            return "INSERT INTO ventadetalle (id_venta, id_producto, monto, peso, usuario) VALUES ('" +
                vd.Venta.Id + "', '" +
                vd.Producto.Id + "', '" +
                vd.Monto + "', '" +
                vd.Peso + "', '" +
                VariablesGlobales.userIdLogueado.ToString() + "');";
        }
        public string InsertVenta(Venta v)
        {
            return "INSERT INTO venta (monto_total, fecha, usuario) VALUES ('" +
                v.MontoTotal + "', " +
                " NOW() , '" +
                VariablesGlobales.userIdLogueado.ToString() + "');";
        }
        public string GetMedidas()
        {
            return "select * From medida;";
        }
        public string GetVentaById(int p)
        {
            return "select * from venta where id = '" + p.ToString() +"';";
        }
        public string GetVentaEntreFechas(DateTime desde, DateTime hasta)
        {
            return " select distinct v.* " +
            " from venta v " +
            " inner join ventadetalle vd on vd.id_venta = v.id " +
            " inner join producto p on p.id = vd.id_producto " +
            " WHERE " +
            " v.fecha between '" + desde.ToString("yyyy-MM-dd") + "' and '" + hasta.ToString("yyyy-MM-dd") + "' ;";

        }
        public string GetVentaByPlu(string plu)
        {
            return " select distinct v.* " +
            " from venta v " +
            " inner join ventadetalle vd on vd.id_venta = v.id " +
            " inner join producto p on p.id = vd.id_producto " +
            " WHERE " +
            " p.id_codigo_barra like '%" + plu + "%'; ";
        }
        public string GetVentaByDescripProducto(string descrip)
        {
            return " select distinct v.* " +
            " from venta v " +
            " inner join ventadetalle vd on vd.id_venta = v.id " +
            " inner join producto p on p.id = vd.id_producto " +
            " WHERE " +
            " p.descripcion_larga like '%" + descrip + "'% ';";
        }
        public string GetVentaEntreMontos(decimal montoDesde, decimal montoHasta)
        {
            return " select distinct v.* " +
            " from venta v " +
            " WHERE " +
            " v.monto_total between '" + montoDesde + "' and '" + montoHasta + "'; ";
        }
        public string GetVentaEntreCantidades(decimal cantidadDesde, decimal cantidadHasta)
        {
            return " select distinct v.* " +
            " from venta v " +
            " inner join ventadetalle vd on vd.id_venta = v.id " +
            " inner join producto p on p.id = vd.id_producto " +
            " WHERE " +
            " vd.peso BETWEEN '" + cantidadDesde + "' AND '" + cantidadHasta + "'; ";
        }
        public string GetVentasDelDia()
        {
            return "SELECT * FROM venta v where v.fecha between curdate() and ADDDATE(curdate(),1) order by v.fecha desc;";
        }
        public string GetVentas()
        {
            return " SELECT v.id , v.monto_total as MontoTotal, v.fecha as Fecha, v.usuario, v.fecha_baja, GROUP_CONCAT(CONCAT('(', p.id_codigo_barra,') ',  p.descripcion_breve, ' ', vd.peso, ' kg') SEPARATOR ' || ') as Descripcion FROM venta v " +
            " inner join ventadetalle vd on vd.id_venta = v.id " +
            " inner join producto p on p.id = vd.id_producto " +
            " where v.fecha_baja is null " +
            " GROUP BY v.id; ";
        }
        public string GetNextVentaId()
        {
            return "SELECT MAX(id)+1 as nextid from venta;";
        }

        /* Productos */
        public string GetProductosData()
        {
            return " SELECT" +
            " p.id," +
            " p.id_codigo_barra as CodigoBarra," +
            " p.descripcion_breve AS DescripcionBreve," +
            " cast(p.id_producto_tipo AS CHAR (50)) AS TipoProducto," +
            " p.precio as Precio," +
            " p.cantidad AS Cantidad, " +
            " p.descripcion_larga AS DescripcionLarga " +
            " FROM " +
            " producto p " +
            " where p.fecha_baja is null ";
        }

        public string GetProductosSearchData()
        {
            return " SELECT" +
            " p.id," +
            " substring(p.id_codigo_barra,2,4) as CodigoBarra," +
            " p.descripcion_breve AS DescripcionBreve "+
            " FROM " +
            " producto p " +
            " where p.fecha_baja is null ";
        }

        public string GetProductoByPLU(string plu)
        {
            return GetProductosData() +
                " and substr(p.id_codigo_barra,2,4) = '" + plu +"';";
        }

        public string GetProductoByDescripBreve(string descripbreve)
        {
            return GetProductosData() +
                " and p.descripcion_breve LIKE '%" + descripbreve + "%';";
        }

        public string GetDeleteProd(string idProd, DateTime fechaBaja)
        {
            return "update producto set fecha_baja ='" + fechaBaja.ToString() + "' where id = " + idProd + ";";
        }
        public string InsertNuevoProducto(Producto producto)
        {
            return " INSERT INTO producto ( id_producto_tipo,  id_codigo_barra, precio, cantidad, descripcion_breve, descripcion_larga, usuario, fecha_baja) " +
                " VALUES ('" +producto.TipoProducto.Id + "', '" +
                    producto.CodigoBarra + "', '" +
                    producto.Precio + "', '" +
                    producto.Cantidad + "', '" +
                    producto.DescripcionBreve + "', '" +
                    producto.DescripcionLarga + "', '" +
                    VariablesGlobales.userIdLogueado.ToString() + "', " +
                    "null );";
        }
        public string UpdateProducto(Producto producto)
        {
            return "UPDATE producto SET " +
                    " descripcion_breve ='" + producto.DescripcionBreve+ "',  " +
                    " descripcion_larga ='" + producto.DescripcionLarga+ "',  " +
                    " id_producto_tipo ='" + producto.TipoProducto.Id+ "',  " +
                    " precio ='" + producto.Precio + "',  " +
                    " cantidad ='" + producto.Cantidad +"' " +
                    " WHERE id= " + producto.Id + "";
        }
        public string GetProductoDataById(int id)
        {
            return " SELECT" +
                    " p.id," +
                    " p.id_codigo_barra as CodigoBarra," +
                    " p.descripcion_breve AS DescripcionBreve," +
                    " cast(p.id_producto_tipo AS CHAR (50)) AS TipoProducto," +
                    " p.precio as Precio," +
                    " p.cantidad AS Cantidad, " +
                    " p.descripcion_larga AS DescripcionLarga " +
                    " FROM " +
                    " producto p " +
                    " where p.fecha_baja is null and p.id = '" + id.ToString()+"';";
        }
        
        /* Precios */
        public string GetTipoPrecioByIdProducto(int Id)
        {
            return "select id_tipo_precio from producto where id = " + Id + ";";
        }
        public string GetTipoPrecioById(int p)
        {
            return "select * from preciotipo where id = " + p;
        }
        public string GetTipoPrecio()
        {
            return "select * from preciotipo;";
        }

        /* Garron */
        public string GetGarron(int idGarron)
        {
            return "select * from garron where id = '" + idGarron.ToString() + "';";
        }
        public string GetTipoGarron()
        {
            return "select * from garrontipo;";
        }
        public string GetGarronData()
        {
            return "select * from garron;";
        }
        public string GetTipoGarronByIdGarron(int Id)
        {
            return "select g.id_tipo_garron from garron g inner join garrontipo gt on gt.id = g.id_tipo_garron where g.id = '" + Id + "';";
        }
        public string GetGarronByTipoGarron(int idTipoGarron)
        {
            return "select * from garron where id_tipo_garron ='" + idTipoGarron.ToString() + "';";
        }    
        public string InsertGarron(Garron g)
        {
            return " INSERT INTO garron(numero, id_tipo_garron, id_tipo_estado, fecha_entrada, peso, mes, usuario, fecha_baja) " +
                " VALUES ('" + g.Numero + "', '" +
                    g.TipoGarron.Id + "', '" +
                    g.TipoEstadoGarron.Id + "', '" +
                    g.FechaEntrada.ToString("yyyy-MM-dd")+"', '"+
                    g.Peso + "', '" +
                    g.Mes + "', '"+ VariablesGlobales.userIdLogueado.ToString() + "', " +
                    "null );";
        }
        public string GetLastInsertedGarron()
        {
            return "select max(id) as id from garron;";
        }
        public string GetTipoEstadoGarronByIdGarron(int id)
        {
            return "select id_tipo_estado from garron where id = '" + id.ToString() + "';";
        }        
        public string GetGarronByEstadoAndTipo(string estado, string tipo)
        {
            return "select * from garron where id_tipo_estado = '" + estado + "' and id_tipo_garron = '" + tipo + "'; ";
        }
        public string GetGarronProductoByGarron(string p)
        {
            /* Obtener id productos que se deben depostar de garron */
            return "select gpd.* from garron g " +
            " inner join garronproductodef gpd on gpd.id_tipo_garron = g.id_tipo_garron " +
            " where g.id = '"+p+"';";
        }
        public string GetGarronProductoDepostadoByGarron(string p)
        {
            /* Obtener productos ya depostados de garron*/
            return "select gdp.id_producto from garron g " +
            "inner join garronproductodef gpd on gpd.id_tipo_garron = g.id_tipo_garron " +
            "left join garrondeposteparcial gdp on gdp.id_producto = gpd.id_producto and gdp.id_garron = g.id " +
            "where g.id = '"+p+"' and " +
            "gdp.id is not null ;";
        }
        public string GetTipoEstadoGarron()
        {
            return "select * from garronestado; ";
        }

        /* Banco */
        public string GetBanco()
        {
            return "select * from banco order by id;";
        }
        public string GetBancoById(int idBanco)
        {
            return "select * from banco where id = " + idBanco + ";";
        }
        public string GetBancoByIdCuentaCliente(int idCuenta)
        {
            return "select id_banco from clientecuenta where id = '" + idCuenta.ToString() + "';";
        }
        public string GetBancoByIdCuentaProveedor(int idCuenta)
        {
            return "select id_banco from proveedorcuenta where id = '" + idCuenta.ToString() + "';";
        }

    }



}