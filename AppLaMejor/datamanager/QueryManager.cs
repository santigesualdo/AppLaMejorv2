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

        public string GetModulosFaltantesPorUsuario(int idUsuarioSelected)
        {
            return "select* from modulo m " +
            "where m.id not in (select mo.id from usuario u " +
            "left join usuariomodulo um on um.id_usuario = u.id " +
            "left join modulo mo on mo.id = um.id_modulo " +
            "where um.id_usuario = "+idUsuarioSelected+")";
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

        public string GetTipoProductoKiosco()
        {
            return "select * from productotipo where descripcion like '%kiosco%'";
        }

        /* Recibe conexion y consulta y ejecuta update. Retorna true o false, exito o error */
        public bool ExecuteSQL(MySqlConnection conn, string query)
        {
            MySqlCommand sqlCommand = new MySqlCommand(query, conn);
            try
            {                
                if (conn.State.Equals(ConnectionState.Closed))
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

        /* Operaciones Generales END*/

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
                " '" + cliente.FechaDesde.ToString(VariablesGlobales.dateFormat) + "'," +
                VariablesGlobales.userIdLogueado.ToString() + ");";

            return consulta;
        }
        public string GetCuentaEfectivoByCliente(int idCliente)
        {
            throw new NotImplementedException();
        }
        public string UpdateCliente(Cliente cliente)
        {
            string query = "call actualizarCliente(" + cliente.Id.ToString() + ",'" + cliente.CodCliente + "',  " +
                "'" + cliente.RazonSocial + "','" + cliente.Domicilio + "','" + cliente.Localidad + "',  " +
                "'" + cliente.Iva + "','" + cliente.TipoCliente.Id + "','" + cliente.NombreLocal + "',  " +
                "'" + cliente.Telefono + "','" + cliente.Cuit + "','" + cliente.NombreResponsable + "',  " +
                "'" + cliente.FechaDesde.ToString(VariablesGlobales.dateFormat) + "','" + VariablesGlobales.userIdLogueado.ToString() + "');";
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
            return " SELECT c.id, c.cod_cliente as CodCliente, c.razon_social AS RazonSocial, c.domicilio AS Domicilio, c.localidad AS Localidad, cast(c.id_tipo_cliente as CHAR(50)) AS TipoCliente, " +
                " c.fecha_desde as FechaDesde, c.civa AS IVA, c.cuit AS CUIT, c.nombre_responsable AS NombreResponsable, c.nombre_local AS NombreLocal, c.telefono AS Telefono, "+
                " c.fecha_baja AS FechaBaja FROM cliente c order by c.id";
        }
        //trae el saldo actual y algunos datos de referencia para el form de MovCuentas
        public string GetClientesSaldoActual()
        {
           // return "CALL obtenerClientesSaldoActual()";
            return "SELECT cliente.id, cliente.cod_cliente as CodCliente, cliente.razon_social AS `RazonSocial`, cliente.nombre_local AS `NombreLocal`, cliente.civa AS IVA, cast(cliente.id_tipo_cliente as CHAR(50)) AS TipoCliente,count(cuenta.id) AS CantidadCuentas FROM cliente inner join clientecuenta cuenta on cliente.id = cuenta.id_cliente       INNER JOIN banco ON cuenta.id_banco = banco.id INNER JOIN clientetipo ct ON ct.id = cliente.id_tipo_cliente group by cliente.id order by cliente.id";

        }
        public string GetDeleteClient(string idCliente, DateTime fechaBaja)
        {
            return "CALL borrarCliente(" + idCliente.ToString() + ",'" + fechaBaja.ToString(VariablesGlobales.dateFormat) + "')";
        }
        public string GetClientesMayoristasConCuenta()
        {
            return "SELECT c.id,c.cod_cliente AS CodCliente,c.razon_social AS RazonSocial, c.domicilio AS Domicilio,c.localidad AS Localidad,cast(ct.id AS CHAR(50)) AS TipoCliente, "+
            "cu.id AS IdCuenta,c.fecha_desde AS FechaDesde,	c.civa AS IVA,c.cuit AS CUIT,c.nombre_responsable AS NombreResponsable,	c.nombre_local AS NombreLocal,c.telefono AS Telefono "+
            "FROM cliente c INNER JOIN clientetipo ct ON ct.id = c.id_tipo_cliente INNER JOIN clientecuenta cu ON cu.id_cliente = c.id where c.id_tipo_cliente = 1 and cu.descripcion = 'EFECTIVO'" ;
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
                " '" + Proveedor.FechaDesde.ToString(VariablesGlobales.dateFormat) + "', " +
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
        public string GetProveedoresSaldoActual()
        {
            return "call obtenerProveedoresSaldoActual()";
        }
        public string GetDeleteProv(string idProveedor, DateTime fechaBaja)
        {
            return "call borrarProveedor('" + idProveedor.ToString() + "','" + fechaBaja.ToString(VariablesGlobales.dateFormat) + "')";
        }
        public string GetProveedoresCuentaBanco()
        {
            return "SELECT concat('',c.razon_social,' - CBU: ',cu.cbu, ' - Banco: ', b.descripcion, ' - idCuenta:  ', cu.id) FROM proveedor c INNER JOIN proveedorcuenta cu ON cu.id_proveedor = c.id INNER JOIN banco b ON b.id = cu.id_banco WHERE c.fecha_baja IS NULL ORDER BY c.id;";
        }
        public string UpdateCompraDetalleEntregada(int idCompra)
        {
            return "update compradetalle set peso_faltaentregar = 0 where id_compra = " + idCompra + "";
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
                "'" + proveedor.FechaDesde.ToString(VariablesGlobales.dateFormat) + "', " +
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


            string hini = "SELECT banco.descripcion as Banco,  c.id AS id_cuenta,  c.cbu,  c.descripcion as Descripcion,  c.fecha_updated as FechaUltimaActualizacion " +
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
                    "cm.id_operacion," +
                    "gc.id," +
                    "gc.id_cliente," +
                    "cm.id_cuenta, " +
                    "cm.id_movimiento_tipo," +
                    "mt.descripcion, " +
                    "gc.id_banco, " +
                    "round(cm.monto, 2) AS monto, " +
                    "DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS Fecha," +
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
                    "cm.id_operacion," +
                    "cc.id," +
                    "cc.id_cliente," +
                    "banco.descripcion as Banco, " +
                    "cm.id_movimiento_tipo," +
                    "mt.descripcion as Descripcion, " +
                    "banco.descripcion as Banco, " +
                    "concat('$ ' , round(cm.monto, 2)) AS Monto, " +
                    "DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS Fecha" +
                    " FROM clientecuentamovimiento cm INNER JOIN clientecuenta cc ON cm.id_cuenta = cc.id " +
                    "INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id " +
                    "INNER JOIN banco ON banco.id = cc.id_banco WHERE cc.id_cliente =" + id.ToString() + " ORDER BY banco.descripcion DESC LIMIT " +
                    pInicio.ToString() + ", " + registros.ToString() + ";";
        }        
        public string GetMovCuentasBetweenDates(int id, int pInicio, int registros, string fdesde, string fhasta)
        {
            /* trae paginando los movimiento de cuentas de un solo cliente*/

            return "SELECT " +
                    "cm.id, " +
                    "cm.id_operacion," +
                    "gc.id," +
                    "gc.id_cliente," +
                    "cm.id_cuenta, " +
                    "cm.id_movimiento_tipo," +
                    "mt.descripcion as Descripcion, " +
                    "banco.descripcion as Banco, " +
                    "round(cm.monto, 2) AS Monto, " +
                    "DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS FechaUltimaActualizacion" +

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
                "id_operacion," +
                "id_cuenta," +
                "id_movimiento_tipo," +
                "monto," +
                "fecha," +
                "cobrado," +
                "usuario)" +
                "VALUES (" +

                movCuenta.Operacion.Id + "," +
                movCuenta.Cuenta.Id + "," +
                movCuenta.TipoMovimiento.Id + "," +
                movCuenta.Monto + ", NOW(),'" +
                movCuenta.Cobrado + "'," +
                VariablesGlobales.userIdLogueado+ ");";
        }			
        /* Movimiento Cuentas proveedores */
        public string GetMovCuentasProveedores()
        {
            /* trae todos los movimiento de cuentas de todos los proveedores*/
            return "SELECT cm.id, cm.id_operacion, gc.id, gc.id_proveedor, cm.id_cuenta, cm.id_movimiento_tipo, mt.descripcion as Descripcion, gc.id_banco, round(cm.monto, 2) AS Monto, DATE_FORMAT(cm.fecha, '%Y-%m-%d') AS FechaUltimaActualizacion,  cm.cobrado, cm.usuario FROM proveedorcuentamovimiento cm INNER JOIN proveedorcuenta gc ON cm.id_cuenta = gc.id INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id WHERE gc.id_proveedor IS NOT NULL ORDER BY cm.id DESC;";
        }		
		public string GetMovCuentasProveedor(int id, int pInicio, int registros)
        {
            /* trae paginando los movimiento de cuentas de un solo cliente*/

            return "SELECT " +
                    "cm.id, " +
                    "cm.id_operacion," +
                    "gc.id," +
                    "gc.id_proveedor," +
                    "banco.descripcion as Banco, " +
                    "cm.id_movimiento_tipo," +
                    "mt.descripcion as Descripcion, " +
                    "banco.descripcion as Banco, " +
                    "round(cm.monto, 2) AS Monto, " +
                    "DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS FechaUltimaActualizacion" +
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
                    "cm.id_operacion," +
                    "gc.id," +
                    "gc.id_proveedor," +
                    "cm.id_cuenta, " +
                    "cm.id_movimiento_tipo," +
                    "mt.descripcion as Descripcion, " +
                    "banco.descripcion as Banco, " +
                    "round(cm.monto, 2) AS Monto, " +
                    "DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS FechaUltimaActualizacion " +
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
                "id_operacion," +
                "id_cuenta," +
                "id_movimiento_tipo," +
                "monto," +
                "fecha," +
                "cobrado," +
                "usuario)" +
                "VALUES (" +

                movCuenta.Operacion.Id + "," +
                movCuenta.Cuenta.Id + "," +
                movCuenta.TipoMovimiento.Id + "," +
                movCuenta.Monto + ", NOW(),'" +
                movCuenta.Cobrado + "'," +
                VariablesGlobales.userIdLogueado + ");";
        }
        public string InsertMovCuentaProveedor(MovimientoCuentaProveedor movCuentaProveedor)
        {
            /* persiste el movimiento de cuenta*/
            return "INSERT INTO proveedorcuentamovimiento(" +
                "id_operacion," +
                "id_cuenta," +
                "id_movimiento_tipo," +
                "monto," +
                "fecha," +
                "cobrado," +
                "usuario)" +
                "VALUES (" +

                movCuentaProveedor.Operacion.Id + "," +
                movCuentaProveedor.Cuenta.Id + "," +
                movCuentaProveedor.TipoMovimiento.Id + "," +
                movCuentaProveedor.Monto + ", NOW(),'" +
                movCuentaProveedor.Cobrado + "'," +
                VariablesGlobales.userIdLogueado+ ");";
        }
        public string GetNextMovCuentaId()
        {
            return "SELECT MAX(id)+1 as nextid from clientecuentamovimiento;";
        }
        /* Ventas */
        public string GetProductoFromIdCode(string idCode)
        {
            return GetProductoUbicacionData() +
                " and id_codigo_barra like '%" + idCode + "%'";
        }
        public string GetProductoById(int id){
            return "select * From producto where id = "+id+";";
        }
        public string GetProductosDeposte()
        {
            // Retorna los productos de Venta Minorista y Venta Mayorista (estado 2 y 3)
            return GetProductoUbicacionData() + " and id_producto_tipo in (2,3)";
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
			if (vd.Producto!=null){
				return "INSERT INTO ventadetalle (id_venta, id_producto, monto, peso, usuario) VALUES ('" +
					vd.Venta.Id + "', '" +
					vd.Producto.Id + "', '" +
					vd.Monto + "', '" +
					vd.Peso + "', '" +
					VariablesGlobales.userIdLogueado.ToString() + "');";				
			}else if (vd.Garron!=null){
				return "INSERT INTO ventadetalle (id_venta, id_garron, monto, peso, usuario) VALUES ('" +
					vd.Venta.Id + "', '" +
					vd.Garron.Id + "', '" +
					vd.Monto + "', '" +
					vd.Peso + "', '" +
					VariablesGlobales.userIdLogueado.ToString() + "');";				
			}
            return "";

        }
        public string InsertVenta(Venta v)
        {
            return "INSERT INTO venta (monto_total, fecha, usuario, id_operacion) VALUES ('" +
                v.MontoTotal + "', " +
                " NOW() , '" +
                VariablesGlobales.userIdLogueado.ToString() + "'," + v.Operacion.Id + ");";
        }
        public string InsertOperacion(Operacion o)
        {
            return "INSERT INTO operacion (id_tipo_operacion, id_cliente, fecha, usuario) VALUES (" +
                o.tipoOperacion.Id + "," + o.cliente.Id + ", NOW()," +	   
                VariablesGlobales.userIdLogueado.ToString() + ");";
        }
        public string InsertOperacionProveedor(OperacionProveedor o)
        {
            return "INSERT INTO operacionproveedor (id_tipo_operacion, id_proveedor, fecha, usuario) VALUES (" +
                o.tipoOperacion.Id + "," + o.proveedor.Id + ", NOW()," +
                VariablesGlobales.userIdLogueado.ToString() + ");";
        }
        public string GetVentaById(int p)
        {
            return "select * from venta where id = '" + p.ToString() + "';";
        }
        public string GetVentaEntreFechas(DateTime desde, DateTime hasta)
        {
            return " select distinct v.* " +
            " from venta v " +
            " inner join ventadetalle vd on vd.id_venta = v.id " +
            " inner join producto p on p.id = vd.id_producto " +
            " WHERE " +
            " v.fecha between '" + desde.ToString(VariablesGlobales.dateFormat) + "' and '" + hasta.ToString(VariablesGlobales.dateFormat) + "' ;";

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
            " p.descripcion_breve like '%" + descrip + "'% ';";
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
        /* Operacion */
        public string GetNextOperacionId()
        {
            return "SELECT MAX(id)+1 as nextid from operacion;";
        }
        public string GetNextOperacionProveedorId()
        {
            return "SELECT MAX(id)+1 as nextid from operacionproveedor;";
        }
        /* Productos */
        public string GetProductoUbicacionData()
        {
            return " SELECT" +
            " p.id," +
            " p.id_codigo_barra as CodigoBarra," +
            " p.descripcion_breve AS DescripcionBreve," +
            " cast(p.id_producto_tipo AS CHAR (50)) AS TipoProducto," +
            " p.precio as Precio," +
            " p.cantidad AS Cantidad " +
            " FROM " +
            " producto p " +
            " where p.fecha_baja is null ";
        }
        public string GetProductoUbicacionTotal()
        {
            return "select case when g.id is null then concat('Producto: ', p.descripcion_breve, ' ',COALESCE(substr(p.id_codigo_barra,2,4), 'SIN PLU')) else concat('Garron: ', g.numero, ' ', g.peso, ' kg. ', gt.descripcion) end as mercaderia, " +
            "u.descripcion as ubicacion, pu.peso as peso,  pt.descripcion AS TipoProducto from productoubicacion pu " +
            "left join garron g on pu.id_garron is not null and g.id = pu.id_garron " +
            "left join producto p on pu.id_producto is not null and p.id = pu.id_producto " +
            "left join garrontipo gt on gt.id = g.id_tipo_garron " +
            "left join productotipo pt on pt.id = p.id_producto_tipo " +
            "inner join ubicacion u on u.id = pu.id_ubicacion " +
            "and fecha_egreso is null " +
            "order by pu.id_ubicacion, pu.id_producto, pu.id_garron ";
        }
        public string GetProducto(int idProducto)
        {
            return GetProductoUbicacionData() +
            " and id  = '" + idProducto + "';";
        }
        public string GetProductosDataByTipo(int tp)
        {
            return " SELECT" +
            " p.id," +
            " p.id_codigo_barra as CodigoBarra," +
            " p.descripcion_breve AS DescripcionBreve," +
            " cast(p.id_producto_tipo AS CHAR (50)) AS TipoProducto," +
            " p.precio as Precio," +
            " p.cantidad AS Cantidad " +
            " FROM " +
            " producto p " +
            " where p.fecha_baja is null AND p.id_producto_tipo = " + tp.ToString();
        }
        public string GetProductosSearchDataConPlu()
        {
            return " SELECT" +
            " p.id," +
            " substring(p.id_codigo_barra,2,4) as CodigoBarra," +
            " p.descripcion_breve AS DescripcionBreve "+
            " FROM " +
            " producto p " +
            " where p.fecha_baja is null and p.id_codigo_barra is not null ";
        }
        public string GetProductosSearchDataKiosco()
        {
            return "select p.id,p.descripcion_breve from productoubicacion pu inner join producto p on p.id = pu.id_producto where pu.fecha_egreso is NULL " +
            " and pu.id_ubicacion = '" + FuncionesGlobales.ObtenerUbicacionSalida().Id + "' and p.fecha_baja is null and p.id_producto_tipo = 4 ;";
        }
        public string GetProductosSearchDataAll()
        {
            return " SELECT" +
            " p.id," +
            " p.descripcion_breve " +
            " FROM " +
            " producto p " +
            " where p.fecha_baja is null  ";
        }

        public string GetProductoByPLU(string plu)
        {
            return GetProductoUbicacionData() +
                " and substr(p.id_codigo_barra,2,4)  = '" + plu + "';";
        }
        public string GetProductoByDescripBreve(string descripbreve)
        {
            return GetProductoUbicacionData() +
                " and p.descripcion_breve LIKE '%" + descripbreve + "%';";
        }
        public string GetDeleteProd(string idProd, DateTime fechaBaja)
        {
            return "update producto set fecha_baja ='" + fechaBaja.ToString() + "' where id = " + idProd + ";";
        }
        public string InsertNuevoProducto(Producto producto)
        {
            return " INSERT INTO producto ( id_producto_tipo,  id_codigo_barra, precio, cantidad, descripcion_breve,  usuario, fecha_baja) " +
                " VALUES ('" +producto.TipoProducto.Id + "', '" +
                    producto.CodigoBarra + "', '" +
                    producto.Precio + "', '" +
                    producto.Cantidad + "', '" +
                    producto.DescripcionBreve + "', '" +
                    VariablesGlobales.userIdLogueado.ToString() + "', " +
                    "null );";
        }
        public string UpdateProducto(Producto producto)
        {
            return "UPDATE producto SET " +
                    " descripcion_breve ='" + producto.DescripcionBreve+ "',  " +
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
                    " p.cantidad AS Cantidad " +
                    " FROM " +
                    " producto p " +
                    " where p.fecha_baja is null and p.id = '" + id.ToString()+"';";
        }
        public string GetProductosMayoristaSalonDeposito()
        {
            return " SELECT" +
                " p.id," +
                " p.id_codigo_barra as CodigoBarra," +
                " p.descripcion_breve AS DescripcionBreve," +
                " cast(p.id_producto_tipo AS CHAR (50)) AS TipoProducto," +
                " p.precio as Precio," +
                " pu.peso AS Cantidad " +
                " FROM " +
                " producto p " +
                " inner join productoubicacion pu on pu.id_producto = p.id " +
                " where p.id_producto_tipo = 3 " +
                " and pu.id_ubicacion = 4 " +
                " and pu.fecha_egreso is null ";
        }       
        public string GetProductoFaltanteData(int idCompra)
        {
            return " SELECT" +
            " p.id," +
            " p.id_codigo_barra as CodigoBarra," +
            " p.descripcion_breve AS DescripcionBreve," +
            " cast(p.id_producto_tipo AS CHAR (50)) AS TipoProducto," +
            " p.precio as Precio," +
            " cd.peso_faltaentregar AS Cantidad " +
            " FROM " +
            " producto p " +
            " inner join compradetalle cd on cd.id_producto = p.id " +
            " where cd.id_compra = "+idCompra+" and cd.peso_faltaentregar > 0 ";
        }
        public string CheckProductExistUbicacionSalida(int idProducto)
        {
            return "select * from productoubicacion pu inner join producto p on p.id = pu.id_producto where pu.fecha_egreso is NULL "+
            " and pu.id_producto = '"+idProducto+"' and pu.id_ubicacion = '"+ FuncionesGlobales.ObtenerUbicacionSalida().Id+"';";
        }
        public string CheckCodigoBarraExist(string PLU)
        {
           return "select 1 from producto where id_codigo_barra like '%" + PLU + "%';";
        }
        /* Garron */
        public string GetGarron(int idGarron)
        {
            return "select id, numero, id_tipo_garron, id_tipo_estado, fecha_entrada, peso, mes from garron where id = '" + idGarron.ToString() + "';";
        }
        public string GetTipoGarron()
        {
            return "select * from garrontipo;";
        }
        public string GetGarronByNumberSearchData(Ubicacion u , TipoEstadoGarron teg , TipoGarron tg, string numero, string listIdGarronExcluir)
        {
            string consulta = "select  concat(' ',g.numero,'/',g.mes, '- Peso: ',g.peso,' kg. - Ubicacion: ', u.descripcion, '- Estado: ', ge.descripcion, ' - Tipo: ' , gt.descripcion,' - ID: ',g.id) as text " +
            "from garron g inner join productoubicacion pu on pu.id_Garron = g.id " +
            "inner join ubicacion u on pu.id_ubicacion = u.id "+
            "inner join garronestado ge on ge.id = g.id_tipo_estado "+
            "inner join garrontipo gt on gt.id = g.id_tipo_garron "+
            " where pu.fecha_egreso is null and g.fecha_baja is null ";
            if (u != null)
            {
                consulta += " and pu.id_ubicacion = '" + u.Id + "' ";
            }
            if (teg != null)
            {
                consulta += " and g.id_tipo_estado= '" + teg.Id + "' ";
            }
            if (tg != null)
            {
                consulta+=" and g.id_tipo_garron = '" +tg.Id+ "' ";
            }
            if (numero!=null)
            {
                consulta += " and g.numero like '%" + numero + "%' ";
            }
            if (listIdGarronExcluir != null)
            {
                consulta+= " and g.id not in ("+ listIdGarronExcluir +") ";
            }
            return consulta;
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
            return " INSERT INTO garron(numero, id_tipo_garron, id_tipo_estado, fecha_entrada, peso, mes, observacion, usuario, fecha_baja) " +
                " VALUES ('" + g.Numero + "', '" +
                    g.TipoGarron.Id + "', '" +
                    g.TipoEstadoGarron.Id + "', '" +
                    g.FechaEntrada.ToString(VariablesGlobales.dateTimeFormat)+"', '"+
                    g.Peso + "', '" +
                    g.Mes + "', '"+
                    g.Observacion + "', '" +
                    VariablesGlobales.userIdLogueado.ToString() + "', " +                    
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
        public string GetTipoEstadoGarron()
        {
            return "select * from garronestado; ";
        }
        public string GetNextGarronId()
        {
            return "SELECT MAX(id)+1 as nextid from garron;";
        }
        public string InsertGarronDeposte(GarronDeposte gd)
        {
            return "insert into garrondeposte (id_garron, id_producto, peso, fecha, usuario, fecha_baja) VALUES ('" + gd.Garron.Id + "', '" + gd.Producto.Id + "', '" + gd.Peso + "', NOW() , '" + VariablesGlobales.userIdLogueado + "', NULL);";
        }
        public string UpdatePesoGarron(int idGarron , decimal pesoTotalDepostado)
        {
            return "update garron set id_tipo_estado = 2 , peso = peso - '"+pesoTotalDepostado+"' where id = '" +idGarron +"'";
        }
        public string GetGarronDeposteAnterior(int id)
        {
            return "select * from garrondeposte where id_garron  =  '" + id.ToString() + "';";
        }
        public string UpdateFechaBajaGarron(int id)
        {
            return "update garron set fecha_baja = '" + DateTime.Now.ToString(VariablesGlobales.dateTimeFormat) +"' where id = " + id + ";";
        }
        public string GetProductoUbicacionByGarron(int idGarron)
        {
            return "SELECT * FROM productoubicacion pu where fecha_egreso is null and id_garron = '" + idGarron + "';";
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
        /* Precios */
        public string GetPrecioHistoricoData()
        {
            return "select id, cast(id_producto as char) as Producto, desde as FechaDesde, hasta as FechaHasta, precio as Precio, id_usuario, fecha_baja from preciohistorico " +
                   "order by id_producto, hasta";
        }
        public string GetPrecioHistoricoByProducto(int idProducto)
        {
            return "select id, cast(id_producto as char) as Producto, desde as FechaDesde, hasta as FechaHasta, precio as Precio, id_usuario, fecha_baja from preciohistorico " +
                   " where id_producto = '" + idProducto.ToString() + "' " +
                   " order by desde desc";
        }
        public string ClosePrecioHistorico(int id)
        {
            return " UPDATE preciohistorico set hasta = DATE_SUB(now(),interval 1 day) where id = '" + id.ToString() + "'";
        }
        public string CreateHistoricoNuevo(decimal precioNuevo, int idProducto)
        {
            return " INSERT INTO preciohistorico(id_producto, desde, hasta, precio, id_usuario, fecha_baja) " +
                " VALUES('" + idProducto.ToString() + "', NOW(), NULL, '" + precioNuevo.ToString() + "',  '" + VariablesGlobales.userIdLogueado.ToString() + "', NULL);";
        }
        public string UpdateProductoPrecio(decimal precioNuevo, int idProducto)
        {
            return " UPDATE producto set precio = '" + precioNuevo + "' WHERE id = '" + idProducto.ToString() + "';";
        }
        public string UpdatePrecioHistorico(decimal precioNuevo, int idProducto)
        {
            return " UPDATE preciohistorico set precio = '" + precioNuevo + "' WHERE hasta is null and id_producto = '" + idProducto.ToString() + "';";
        }
        public string GetPreciosToExport()
        {
            return "SELECT CONCAT('CARNICERIA;',cast(SUBSTR(p.id_codigo_barra, 2, 4) AS UNSIGNED),';',p.descripcion_breve,';',cast(SUBSTR(p.id_codigo_barra, 2, 4) AS UNSIGNED),';',p.precio,';','0.00;P;0;;'	) " +
                    "FROM producto p where 	p.id_codigo_barra is not null order by p.id_codigo_barra";
        }
        public string GetParametroByName(string name)
        {
            return "SELECT value FROM parametros where name = '" + name + "';";
        }
        /* Operaciones */
        public string GetOperacionesData()
        {
            return "select o.id, o.fecha, o.id_cliente, too.descripcion, v.monto_total, c.cod_cliente, c.razon_social, v.id as id_venta from operacion o " +
            " inner join operaciontipo too on o.id_tipo_operacion = too.id " +
            " inner join cliente c on c.id = o.id_cliente " +
            " inner join venta v on v.id_operacion = o.id order by o.id desc ";
        }
        public string GetOperacionesProveedoresData()
																 
        {
            return "select o.id, o.fecha, o.id_proveedor, too.descripcion, v.monto_total, c.razon_social , v.id as id_compra " +
            "from operacionproveedor o  inner join operaciontipo too on o.id_tipo_operacion = too.id " +
            "inner join proveedor c on c.id = o.id_proveedor " +
            "inner join compra v on v.id_operacion = o.id " +
            "order by o.id desc ";
        }
        /* Reportes */
        /* ----------> Ultima Operacion Venta */
        public string ReportVistaUltimaVenta(int id, int ido)
        {
            return
            "    ALTER VIEW vistaultimaventa AS " +
            "SELECT " +
            "  `c`.`id`, " +
            "  `c`.`cod_cliente`, " +
            "  `c`.`razon_social`, " +
            " 	`c`.`domicilio`," +
            "  `c`.`cuit`, " +
            "  `cc`.`id` AS 'id_cliente_cuenta', " +
            "  `cc`.`descripcion`, " +
            "  `cc`.`id_banco`, " +
            "  `ccm`.`id_operacion`, " +
            " `mt`.`descripcion` AS 'tipo', " +
            "  `ccm`.`fecha`, " +
            "  IF((`ccm`.`id_movimiento_tipo` = 2), `ccm`.`monto`, (`ccm`.`monto` *-(1))) AS 'saldo' " +
            " FROM " +
            "      (((`clientecuenta` cc " +
            "    JOIN `cliente` c ON((`cc`.`id_cliente` = `c`.`id`))) " +
            "    JOIN `clientecuentamovimiento` ccm ON ((`ccm`.`id_cuenta` = `cc`.`id`))) " +
            "    JOIN `movimientotipo` mt ON ((`ccm`.`id_movimiento_tipo` = `mt`.`id`))) " +
            "WHERE  (`ccm`.`id_operacion` = " + ido.ToString() + "); " +
            " ALTER VIEW vistasaldoporidcliente AS SELECT   `c`.`id`,   `c`.`cod_cliente`,   `c`.`razon_social`,   `c`.`cuit`,   `cc`.`id` AS 'id_cliente_cuenta',   `cc`.`descripcion`,   `cc`.`id_banco`," +
            " `ccm`.`id_operacion`,   `mt`.`descripcion` AS 'tipo',   `ccm`.`fecha`,   IF((`ccm`.`id_movimiento_tipo` = 2), `ccm`.`monto`, (`ccm`.`monto` *-(1))) AS 'saldo' " +
            " FROM(((`clientecuenta` cc    JOIN `cliente` c ON ((`cc`.`id_cliente` = `c`.`id`)))    JOIN `clientecuentamovimiento` ccm ON ((`ccm`.`id_cuenta` = `cc`.`id`)))    JOIN `movimientotipo` mt ON ((`ccm`.`id_movimiento_tipo` = `mt`.`id`))) " +
            " WHERE(`c`.`id` = " + id.ToString() + ") ; " +
            " ALTER VIEW vistasaldocliente AS SELECT   `id`, `razon_social`, SUM(`saldo`) * - (1) AS 'saldo' FROM   `vistasaldoporidcliente` GROUP BY   `id`;";
            //" ALTER VIEW vistapagadoporidcliente AS select `vistasaldoporidcliente`.`id` AS `id`,`vistasaldoporidcliente`.`cod_cliente` AS `cod_cliente`,`vistasaldoporidcliente`.`razon_social` AS `razon_social`,`vistasaldoporidcliente`.`cuit` AS `cuit`,`vistasaldoporidcliente`.`id_cliente_cuenta` AS `id_cliente_cuenta`,`vistasaldoporidcliente`.`descripcion` AS `descripcion`,`vistasaldoporidcliente`.`id_banco` AS `id_banco`,`vistasaldoporidcliente`.`id_operacion` AS `id_operacion`,`vistasaldoporidcliente`.`tipo` AS `tipo`,`vistasaldoporidcliente`.`fecha` AS `fecha`,`vistasaldoporidcliente`.`saldo` AS `saldo` from `vistasaldoporidcliente` where(`vistasaldoporidcliente`.`tipo` = 'PAGO' and `id_operacion` =" + ido.ToString() + ");" +
            //" select `vsc`.`id` AS `id`,(`vvs`.`monto_total` - `vsc`.`saldo`) AS `total` " +
            //" from(`vistaventaseleccionada` `vvs` " +
            //" join `vistasaldocliente` `vsc` on((`vvs`.`id_cliente` = `vsc`.`id`))) ";
            //order by `ccm`.`fecha` desc limit 1,8932173897
        }
        public string ReportVistaUltimaVenta(int idv)
        {
            //string consulta = " ALTER VIEW vistaventa AS SELECT  `v`.`id`,  `o`.`id_cliente` AS `id_cliente`,`v`.`id_operacion`,  `p`.`id_codigo_barra` AS 'codigo',  `p`.`descripcion_breve` AS 'descripcion', " +
            //" `vd`.`peso`,  `vd`.`monto`,  `v`.`monto_total`FROM  (((`venta` v    JOIN `ventadetalle` vd ON((`v`.`id` = `vd`.`id_venta`)))    JOIN `producto` p ON ((`vd`.`id_producto` = `p`.`id`))) " +
            //"  JOIN `operacion` o ON ((`v`.`id_operacion` = `o`.`id`))) WHERE  (`v`.`id` = " + idv.ToString() + ");";

            string consulta = "ALTER VIEW vistaventa AS SELECT v.id AS id,o.id_cliente AS id_cliente,v.id_operacion AS id_operacion,p.id_codigo_barra AS codigo,CASE WHEN p.id IS NULL THEN " +
            " concat('Garron #', g.numero, ' ID:', g.id) ELSE  p.descripcion_breve END AS descripcion, " +
            " vd.peso AS peso,  vd.monto AS monto, v.monto_total AS monto_total " +
            " FROM venta v JOIN ventadetalle vd ON v.id = vd.id_venta " +
            " LEFT JOIN producto p ON((vd.id_producto = p.id       AND p.id IS NOT NULL)) " +
            " LEFT JOIN garron g ON((vd.id_garron = g.id     AND g.id IS NOT NULL)) " +
            " JOIN operacion o ON v.id_operacion = o.id WHERE  v.id = " + idv.ToString() + ";";

            return consulta;
        }
        public string ReportVistaUltimaVentaPorCliente(int idC)
        {
            string consulta =
        "ALTER VIEW vistaultimaventaporcliente AS SELECT  `v`.`id`, " +
        "`v`.`id_operacion`,  " +
        "o.id_cliente, " +
        "`p`.`id_codigo_barra` AS 'codigo',   " +
        "`p`.`descripcion_breve` AS 'descripcion',  " +
        "`vd`.`peso`,   " +
        "`vd`.`monto`, " +
        "`v`.`monto_total` " +

        "FROM(((`venta` v " +
        "JOIN `ventadetalle` vd ON((`v`.`id` = `vd`.`id_venta`)))     " +
        "JOIN `producto` p ON((`vd`.`id_producto` = `p`.`id`)))  " +
        "JOIN `operacion` o ON((`v`.`id_operacion` = `o`.`id`))) " +
        "where v.id =( SELECT  `v`.`id` AS id_ultima_venta " +

        "FROM  (((`venta` v " +
        "JOIN `ventadetalle` vd ON((`v`.`id` = `vd`.`id_venta`)))     " +
        "JOIN `producto` p ON((`vd`.`id_producto` = `p`.`id`)))  " +
        "JOIN `operacion` o ON((`v`.`id_operacion` = `o`.`id`))) " +
        "where o.id_cliente = " + idC.ToString() + " order by v.id desc limit 1); ";
            return consulta;
        }
        public string ReportVistaVentaSeleccionada(int idV)
        {
        //    string consulta = "ALTER VIEW vistaventaseleccionada AS  SELECT  `v`.`id`, `v`.`id_operacion`, o.id_cliente, `p`.`id_codigo_barra` AS 'codigo',  `p`.`descripcion_breve` AS 'descripcion', " +
        //"`vd`.`peso`,  `vd`.`monto`,  `v`.`monto_total` FROM(((`venta` v JOIN `ventadetalle` vd ON((`v`.`id` = `vd`.`id_venta`)))    " +
        // "JOIN `producto` p ON((`vd`.`id_producto` = `p`.`id`)))  JOIN `operacion` o ON((`v`.`id_operacion` = `o`.`id`))) " +
        //"where v.id = " + idV.ToString();

            string consulta = "ALTER VIEW vistaventaseleccionada AS  SELECT 	`v`.`id` AS `id`, 	`v`.`id_operacion` AS `id_operacion`, 	`o`.`id_cliente` AS `id_cliente`, " +
    " (CASE        WHEN isnull(`p`.`id`) THEN          concat('Garron #',             `g`.`numero`, ' ID:',             `g`.`id`			) ELSE			`p`.`descripcion_breve`		END) AS `descripcion`, " +
    " `vd`.`peso` AS `peso`,	`vd`.`monto` AS `monto`,	`v`.`monto_total` AS `monto_total` " +
    "			FROM    `venta` `v`					JOIN `ventadetalle` `vd` ON `v`.`id` = `vd`.`id_venta` " +
    "			LEFT JOIN `producto` `p` ON `vd`.`id_producto` = `p`.`id`				AND `p`.`id` IS NOT NULL " +
    "           LEFT JOIN `garron` `g` ON `vd`.`id_garron` = `g`.`id`					AND `g`.`id` IS NOT NULL " +
    "                    JOIN `operacion` `o` ON `v`.`id_operacion` = `o`.`id` " +
    "		WHERE   `v`.`id` = " + idV.ToString();

            return consulta;
        }
        public string ReportVistaListadoVentas(string d, string h)
        {
            string consulta = "ALTER VIEW vistalistadoventas AS  SELECT " +
	" `v`.`id` AS `id`," +
    " dayofmonth(`v`.`fecha`) AS `dia`," +
    " ELT(DATE_FORMAT(`v`.`fecha`, '%m')," +
        "'Enero'," +
        "'Febrero'," +
        "'Marzo'," +
        "'Abril'," +
        "'Mayo'," +
        "'Junio'," +
        "'Julio'," +
        "'Agosto'," +
        "'Septiembre'," +
        "'Octubre'," +
        "'Noviembre', " +
		"'Diciembre') AS `mes`, "+
                    " YEAR(`v`.`fecha`) AS `año`," + 
	" date_format(`v`.`fecha`, '%d/%m/%Y') AS `fecha`," +
    " date_format(`v`.`fecha`, '%H:%i') AS `hora`," +
	" `v`.`monto_total` AS `monto`," +
	" `v`.`id_operacion` AS `operacion`," +
	" `c`.`razon_social` AS `cliente`," +
    "           `c`.`cuit` AS `cuit`" +
    " FROM    ((	`venta` `v`   JOIN `operacion` `o` ON((	`o`.`id` = `v`.`id_operacion`)))" +
      "  JOIN `cliente` `c` ON((`o`.`id_cliente` = `c`.`id`))) "+
	" WHERE    (		`v`.`fecha` BETWEEN '" + d + "' AND DATE_ADD('" + h + "',INTERVAL 1 DAY));";
            return consulta;
        }


        public string ReportVistaListadoMovCuentas(string d, string h)
        {
            string consulta = "ALTER VIEW vistalistadomovimientosclientes AS SELECT"+
            " cm.id,"+

            "dayofmonth(cm.`fecha`) AS `dia`,"+

            "ELT("+
            "DATE_FORMAT(cm.fecha, '%m'),"+
            "'Enero',"+
            "'Febrero',"+
            "'Marzo',"+
            "'Abril',"+
            "'Mayo',"+
            "'Junio',"+
            "'Julio',"+
            "'Agosto',"+
            "'Septiembre',"+
            "'Octubre',"+
            "'Noviembre',"+
            "'Diciembre'"+
            ") AS mes,"+
            " YEAR (cm.fecha) AS año,"+
            " DATE_FORMAT(cm.fecha, '%d-%m-%Y') AS fecha,"+
            " DATE_FORMAT(cm.fecha, '%H:%i') AS hora,"+
            " c.razon_social,"+
            " c.cuit,"+
            " gc.descripcion,"+
            " cm.id_cuenta AS cuenta,"+
            " cm.id_movimiento_tipo AS id_tipo,"+
            " mt.descripcion AS tipo,"+
            " gc.id_banco,"+
            " cm.id_operacion AS operacion,"+
            " IF((`cm`.`id_movimiento_tipo` = 2),"+
            " `cm`.`monto`,(`cm`.`monto` *-(1))) AS `monto`"+
            " FROM"+
            " clientecuentamovimiento cm"+
            " INNER JOIN clientecuenta gc ON cm.id_cuenta = gc.id"+
            " INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id"+
            " INNER JOIN cliente c ON gc.id_cliente = c.id"+
            " WHERE gc.id_cliente IS NOT NULL AND " +
            " cm.`fecha` BETWEEN '" + d + "' AND DATE_ADD('" + h + "',INTERVAL 1 DAY)" +
            " ORDER BY cm.id DESC;";

            return consulta;
        }

        public string ReportVistaListadoMovCuentasProveedores(string d, string h)
        {
            string consulta = "ALTER VIEW vistalistadomovimientosproveedores AS " +
        "SELECT " +
	"`cm`.`id` AS `id`, " +
    "dayofmonth(`cm`.`fecha`) AS `dia`, " +
    "elt(date_format(`cm`.`fecha`, '%m'), " +
        "'Enero', " +
        "'Febrero', " +
        "'Marzo', " +
        "'Abril', " +
        "'Mayo', " +
        "'Junio', " +
        "'Julio', " +
        "'Agosto', " +
        "'Septiembre', " +
        "'Octubre', " +
        "'Noviembre', " +
        "'Diciembre' " +
    ") AS `mes`, " +
    "YEAR(`cm`.`fecha`) AS `año`, " +
    "date_format(`cm`.`fecha`, '%d-%m-%Y') AS `fecha`, " +
    "date_format(`cm`.`fecha`, '%H:%i') AS `hora`, " +
    "`c`.`razon_social` AS `razon_social`, " +
    "`c`.`cuit` AS `cuit`, " +
    "`gc`.`descripcion` AS `descripcion`, " +
    "`cm`.`id_cuenta` AS `cuenta`, " +
    "`cm`.`id_movimiento_tipo` AS `id_tipo`, " +
    "`mt`.`descripcion` AS `tipo`, " +
    "`gc`.`id_banco` AS `id_banco`, " +
    "`cm`.`id_operacion` AS `operacion`, " +
    "IF ((`cm`.`id_movimiento_tipo` = 2),`cm`.`monto`,(`cm`.`monto` * -(1))) AS `monto` " +
    "FROM " +
        " (((`proveedorcuentamovimiento` `cm` " +
              "  JOIN `proveedorcuenta` `gc` ON ((`cm`.`id_cuenta` = `gc`.`id`))) " +
            " JOIN `movimientotipo` `mt` ON((`cm`.`id_movimiento_tipo` = `mt`.`id`))) " +
        " JOIN `proveedor` `c` ON((`gc`.`id_proveedor` = `c`.`id`))) " +
    " WHERE " +
    " `gc`.`id_proveedor` IS NOT NULL AND `cm`.`fecha` BETWEEN '" + d + "' AND DATE_ADD('" + h + "',INTERVAL 1 DAY)" +
            " ORDER BY cm.id DESC;";
            return consulta;
        }
        /* ----------> Ultima Operacion Compra */
        public string ReportVistaUltimaCompra(int id, int ido)
        {
            string consulta =

         "ALTER VIEW vistaultimacompra AS SELECT " +
		 " c.id, " +
		 " c.razon_social, " +
		 " c.domicilio," +
		 " c.cuit, " +
		 " cc.id AS 'id_proveedor_cuenta', " +
		 " cc.descripcion, " +
		 " cc.id_banco, " +
		 " ccm.id_operacion, " +												 
		 " mt.descripcion AS 'tipo', " +
		 " ccm.fecha, " +
		 " IF((ccm.id_movimiento_tipo = 2), ccm.monto, (ccm.monto *-(1))) AS 'saldo' " +
		 " FROM " +
		 "   (((proveedorcuenta cc " +
		 "   JOIN proveedor c ON((cc.id_proveedor = c.id))) " +
		 "   JOIN proveedorcuentamovimiento ccm ON ((ccm.id_cuenta = cc.id))) " +
		 "   JOIN movimientotipo mt ON ((ccm.id_movimiento_tipo = mt.id))) " +
		 " WHERE " +	 
		 " (ccm.id_operacion = " + id.ToString() + "); " +
         " ALTER VIEW vistasaldoporidProveedor AS SELECT   c.id,   c.razon_social,   c.cuit,   cc.id AS 'id_proveedor_cuenta',    cc.descripcion,   cc.id_banco,   ccm.id_operacion,  " +
         " mt.descripcion AS 'tipo', ccm.fecha, IF((ccm.id_movimiento_tipo = 2), ccm.monto, (ccm.monto *-(1))) AS 'saldo'  FROM(((proveedorcuenta cc    JOIN proveedor c ON((cc.id_proveedor = c.id)))   " +
         " JOIN proveedorcuentamovimiento ccm ON ((ccm.id_cuenta = cc.id))) JOIN movimientotipo mt ON ((ccm.id_movimiento_tipo = mt.id)))   WHERE(c.id = " + id.ToString() + " ); " +
         " ALTER VIEW vistasaldoproveedor AS SELECT id, razon_social, SUM(saldo) AS 'saldo'   FROM   vistasaldoporidproveedor GROUP BY   id; ";
          return consulta;																																									
        }
        public string ReportVistaCompraSeleccionada(int idC)
        {
            //    string consulta = "ALTER VIEW vistacompraseleccionada AS SELECT  `v`.`id`, `v`.`id_operacion`, o.id_proveedor, `p`.`id_codigo_barra` AS 'codigo',  `p`.`descripcion_breve` AS 'descripcion',  " +
            //"`vd`.`peso`,  `vd`.`monto`,  `v`.`monto_total` FROM(((`compra` v JOIN `compradetalle` vd ON((`v`.`id` = `vd`.`id_compra`)))    " +
            //" JOIN `producto` p ON((`vd`.`id_producto` = `p`.`id`)))  JOIN `operacionproveedor` o ON((`v`.`id_operacion` = `o`.`id`))) " +
            //"where v.id = " + idC.ToString();

            string consulta =
            "ALTER VIEW vistacompraseleccionada AS SELECT v.id AS id, v.id_operacion AS id_operacion, o.id_proveedor AS id_proveedor, p.id_codigo_barra AS codigo, " +
            " (CASE WHEN isnull(p.id) THEN concat('Garron #', g.numero, ' ID:', g.id ) " +
            " ELSE p.descripcion_breve END ) AS descripcion, vd.peso AS peso, vd.monto AS monto, v.monto_total AS monto_total " +
            " FROM compra v " +
            " JOIN compradetalle vd ON v.id = vd.id_compra " +
            " LEFT JOIN producto p ON vd.id_producto = p.id AND p.id IS NOT NULL " +
            " LEFT JOIN garron g ON vd.id_garron = g.id AND g.id IS NOT NULL " +
            " JOIN operacionproveedor o ON v.id_operacion = o.id WHERE v.id =" + idC.ToString() + ";";
            return consulta;
        }
        /* Compras */
        public string GetNextCompraId()
        {
            return "SELECT case when MAX(id)+1 is not null then MAX(id)+1  else 1 end as nextid from compra";
        }
        public string InsertNuevaCompra(Proveedor provSelec, OperacionProveedor newOperacion, decimal currentMontoCompra, decimal currentMontoPagado)
        {
            if (provSelec == null)
            {
                return " INSERT INTO compra (id_proveedor, id_operacion, monto_total, monto_pagado, fecha, usuario, fecha_baja) VALUES (NULL, '" + newOperacion.Id + "', '" + currentMontoCompra + "','" + currentMontoPagado + "', NOW(), '" + VariablesGlobales.userIdLogueado.ToString() + "', NULL); ";
            }
            else
            {
                return " INSERT INTO compra (id_proveedor, id_operacion, monto_total, monto_pagado, fecha, usuario, fecha_baja) VALUES ('" + provSelec.Id + "', '"+ newOperacion.Id + "' , '" + currentMontoCompra + "','" + currentMontoPagado + "', NOW(), '" + VariablesGlobales.userIdLogueado.ToString() + "', NULL); ";
            }

        }
        public string InsertCompraDetalle(int idCompra, Garron g)
        {
            return "INSERT INTO compradetalle (id_compra, id_garron, id_producto, monto, peso, usuario, fecha_baja)  VALUES ('" + idCompra.ToString() + "', '" + g.Id + "', NULL , '" + g.MontoCompra + "', '"+g.Peso+ "', '" + VariablesGlobales.userIdLogueado.ToString() + "', NULL)";
        }
        public string InsertCompraDetalle(int idCompra, Producto p)
        {
            if (p.CantidadEntregada.Equals(p.Cantidad))
                return "INSERT INTO compradetalle (id_compra, id_garron, id_producto, monto, peso, usuario, fecha_baja)  VALUES ('" + idCompra.ToString() + "',NULL ,  '" + p.Id + "', '" + p.Precio + "',  '" + p.Cantidad + "', '" + VariablesGlobales.userIdLogueado.ToString() + "', NULL)";

            return "INSERT INTO compradetalle (id_compra, id_garron, id_producto, monto, peso, peso_faltaentregar, usuario, fecha_baja)  VALUES ('" + idCompra.ToString() + "',NULL ,  '" + p.Id + "', '" + p.Precio + "',  '" + p.Cantidad + "', '" + (p.Cantidad - p.CantidadEntregada) + "', '" + VariablesGlobales.userIdLogueado.ToString() + "', NULL)";
        }
        public string SumarCantidadProducto(Producto p)
        {
            return " UPDATE producto set cantidad = cantidad + '" + p.Cantidad + "' where id = '" + p.Id + "'";
        }
        public string UpdateCantidadProducto(int idProducto, decimal nuevoPeso)
        {
            return " UPDATE producto set cantidad = '" + nuevoPeso + "' where id = '" + idProducto + "'";
        }
        public string UbicarCompraDetalleUbicacionEntrada(Producto p)
        {
            return "INSERT INTO productoubicacion (id_producto, id_garron, id_ubicacion, peso, fecha_egreso, fecha_ingreso, id_usuario)" +
            "VALUES('"+p.Id+"', NULL, '"+ FuncionesGlobales.ObtenerUbicacionEntrada().Id + "', '"+p.CantidadEntregada+ "', NULL, NOW(), '"+VariablesGlobales.userIdLogueado+"');";
        }
        public string UbicarCompraDetalleUbicacionEntrada(Garron g)
        {
            return "INSERT INTO productoubicacion (id_producto, id_garron, id_ubicacion, peso, fecha_egreso, fecha_ingreso, id_usuario)" +
            "VALUES( NULL , '" + g.Id + "', '" + FuncionesGlobales.ObtenerUbicacionEntrada().Id + "', '" + g.Peso + "', NULL, NOW(), '" + VariablesGlobales.userIdLogueado + "');";
        }
        public string GetComprasProductosFaltantes()
        {
            return "select c.id, pr.razon_social as Proveedor, c.fecha as Fecha, c.monto_total as MontoCompra, GROUP_CONCAT(CONCAT('(', p.id_codigo_barra, ') ', " +
                " p.descripcion_breve, ' ', cd.peso_faltaentregar, ' kg') SEPARATOR ' || ') as FaltaEntregar " +
                " from compra c inner join compradetalle cd on cd.id_compra = c.id  inner join producto p on p.id = cd.id_producto "+
                " inner join proveedor pr on pr.id = c.id_proveedor where cd.peso_faltaentregar <> 0 group by c.id; ";
        }
        /* Ubicacion */
        public string GetUbicacion()
        {
            return "select * from ubicacion;";
        }
        public string GetUbicacionById(int v)
        {
            return "select * from ubicacion where id = '"+v.ToString()+"';";
        }
        public string GetUbicacionByName(string name)
        {
            return "select * from ubicacion where descripcion = '"+name+"';";
        }
        public string GetUbicacionEntrada()
        {
            return "select * from ubicacion where entrada = 1";
        }
        public string GetUbicacionSalida()
        {
            return "select * from ubicacion where salida = 1";
        }
        public string GetProductosByUbicacion(int idUbicacion)
        {
            return " SELECT" +
            " p.id," +
            " p.id_codigo_barra as CodigoBarra," +
            " p.descripcion_breve AS DescripcionBreve," +
            " cast(p.id_producto_tipo AS CHAR (50)) AS TipoProducto," +
            " p.precio as Precio," +
            " p.cantidad AS Cantidad " +
            " FROM productoubicacion pu inner join producto p on p.id = pu.id_producto where pu.id_ubicacion = '" + idUbicacion.ToString() + "' and pu.fecha_egreso is null;";
            
        }
        public string GetProductoUbicacion(Producto producto, int origenSeleccionado)
        {
            return "select * from productoubicacion pu where pu.id_producto = '" + producto.Id.ToString() + "' and pu.id_ubicacion = '" + origenSeleccionado.ToString() + "' and pu.fecha_egreso is null";
        }
        public string GetProductoUbicacion(Garron garron, int origenSeleccionado)
        {
            return "select * from productoubicacion pu where pu.id_garron = '" + garron.Id.ToString() + "' and pu.id_ubicacion = '" + origenSeleccionado.ToString() + "' and pu.fecha_egreso is null";
        }
        public string CheckExistProductoUbicacion(Producto producto, int idOrigen, int idDestino)
        {
            return "select * from productoubicacion pu where pu.id_producto = '"+producto.Id+"' and id_ubicacion not in ('"+idOrigen.ToString()+"') and id_ubicacion in ('"+idDestino.ToString()+"');";
        }
        public string GetGarronByUbicacion(int idUbicacion)
        {
            return "SELECT g.* FROM productoubicacion pu inner join garron g on g.id = pu.id_garron where pu.fecha_egreso is null and pu.id_ubicacion ='" + idUbicacion.ToString() + "';";
        }
        public string GetUbicacionByGarron(int id)
        {
            return "SELECT u.* FROM productoubicacion pu inner join ubicacion u  on u.id = pu.id_ubicacion WHERE id_garron = '"+id.ToString()+ "' and pu.fecha_egreso is null ";
        }
        public string GetUbicacionDestino(int idOrigen)
        {
            return "select * from ubicacion where id <> '"+idOrigen.ToString()+"';";
        }
        public string InsertarMovimientoMercaderia(MovimientoMercaderia m)
        {
            if (m.producto != null)
            {
                return 
                "INSERT INTO movimientomercaderia(fecha, id_ubicacion_origen, id_ubicacion_destino, peso, id_producto, id_garron, usuario, fecha_baja) " +
                " VALUES(now(), '"+m.origen.Id+"', '"+m.destino.Id+"', '"+m.peso+"', '"+m.producto.Id+"', NULL, '"+VariablesGlobales.userIdLogueado+"', NULL); ";
            }else if (m.garron != null)
            {
                return 
                "INSERT INTO movimientomercaderia(fecha, id_ubicacion_origen, id_ubicacion_destino, peso, id_producto, id_garron, usuario, fecha_baja) " +
                " VALUES(now(), '" + m.origen.Id + "', '" + m.destino.Id + "', '" + m.peso + "', NULL , '"+m.garron.Id+"', '" + VariablesGlobales.userIdLogueado + "', NULL); ";
            }
            return "";

        }
        public string UpdateProductoUbicacionBaja(int idProductoUbicacion)
        {
            return "update productoubicacion set peso = 0 , fecha_egreso = now(), fecha_baja = NULL where id = '" + idProductoUbicacion.ToString() + "';";
        }
        public string UpdateProductoUbicacion(int idProductoUbicacion, decimal pesoRestante)
        {
            return " update productoubicacion set peso = '"+ pesoRestante + "', fecha_baja = NULL where id = '"+idProductoUbicacion.ToString()+"' ;";
        }
        public string InsertProductoUbicacion(MovimientoMercaderia m)
        {
            if (m.producto != null)
            {
                return "INSERT INTO productoubicacion(id_producto, id_garron, id_ubicacion, peso, fecha_egreso, fecha_ingreso, id_usuario, fecha_baja) " +
                "VALUES('"+m.producto.Id+"', NULL, '"+m.destino.Id+"', '"+m.peso+"', NULL, now() ,'"+VariablesGlobales.userIdLogueado+"' , NULL);";
            }else if (m.garron != null)
            {
                return "INSERT INTO productoubicacion(id_producto, id_garron, id_ubicacion, peso, fecha_egreso, fecha_ingreso, id_usuario, fecha_baja) " +
                "VALUES( NULL , '"+m.garron.Id+"', '" + m.destino.Id + "', '" + m.peso + "', NULL, now() ,'" + VariablesGlobales.userIdLogueado + "' , NULL);";
            }
            return "";   
        }

        public string InsertProductoUbicacion(int idProducto, int idUbicacion, decimal peso)
        {
            return "INSERT INTO productoubicacion(id_producto, id_garron, id_ubicacion, peso, fecha_egreso, fecha_ingreso, id_usuario, fecha_baja) " +
            "VALUES('" +idProducto+ "', NULL, '" + idUbicacion + "', '" + peso + "', NULL, now() ,'" + VariablesGlobales.userIdLogueado + "' , NULL);";
        }

        public string UpdatePesoProductoDestino(int id, decimal nuevoPeso)
        {
            return "update productoubicacion set peso = '"+nuevoPeso+"', fecha_baja = null where id = '"+id.ToString()+"';";
        }

        /* Usuarios y Modulos */
        public string GetModulosPorUsuario(int idUsuarioSelected)
        {
            return "select m.*from usuario u inner join usuariomodulo um on um.id_usuario = u.id inner join modulo m on m.id = um.id_modulo where u.id = "+idUsuarioSelected+"; ";
        }
        public string GetUsuario(int v)
        {
            return "select * from usuario where id=" + v;
        }
        public string GetModulo(int v)
        {
            return "select * from modulo where id=" + v;
        }
    }

}