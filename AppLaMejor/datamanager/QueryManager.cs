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
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dtTabla = new DataTable();
                da.Fill(dtTabla);
                return dtTabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetTableResults: " + ex.Message);
                return null;
            }
        }
        /* Recibe conexion y consulta y ejecuta update. Retorna true o false, exito o error */
        public bool ExecuteSQL(MySqlConnection conn, string query )
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
                MessageBox.Show("ExecuteUpdateFallo: " + ex.Message);
                return false;
            }
        }

        /* Tipos */
        public string GetTipoMovimiento()
        {
            return "select * from movimientotipo order by id;";
        }
        public string GetTipoCliente()
        {
            return "select * from clientetipo order by id;";
        }
        public string GetTipoClienteByIdCliente(int idCliente)
        {
            return "select id_tipo_cliente from cliente where id = " + idCliente.ToString();
        }
        public string GetTipoProducto()
        {
            return "select * from productotipo order by id;";
        }
        public string GetTipoProductoByIdProducto(int idProducto)
        {
            return "select id_producto_tipo from producto where id = " + idProducto.ToString();
        }
        
        /* Usuarios */
        public string GetUsuarioByName(string name){
            return "select * from usuario where username = '" + name + "' ;";
        }
        public string GetUsuariosModulos(int idUsuario)

        {
            return "SELECT m.* FROM usuariomodulo um " +
            "inner join modulo m on m.id = um.id_modulo "+
            " where um.id_usuario = " + idUsuario + ";";
        }
        public string GetUserLogin(string userName, string pass)
        {
            return "select * from usuario where username = '" + userName + "'  and  pass ='" + pass + "'";
        }
        
        /* Clientes */
        public string InsertNuevoCliente(Cliente cliente)
        {
            return "INSERT INTO cliente ( razon_social, domicilio, localidad, civa, id_tipo_cliente, nombre_local, cuit, telefono, nombre_responsable, fecha_desde, fecha_baja, usuario) " +
                " VALUES ( '" + cliente.RazonSocial + "', " +
                " '" + cliente.Domicilio + "', " +
                " '" + cliente.Localidad + "', " +
                " '" + cliente.Iva + "', " +
                " " + cliente.TipoCliente.Id + ", " +
                " '" + cliente.NombreLocal + "', " +
                " '" + cliente.Cuit + "', " +
                " '" + cliente.Telefono+ "', " +
                " '" + cliente.NombreResponsable + "', " +
                " '" + cliente.FechaDesde.ToString("yyyy-MM-dd") + "', " +
                " null ," + 
                cliente.idUsuario + ");";

        }
        public string UpdateCliente(Cliente cliente)
        {
            string query = "UPDATE cliente SET " +
                "razon_social ='" + cliente.RazonSocial + "',  " +
                "domicilio ='" + cliente.Domicilio + "',  " +
                "localidad ='" + cliente.Localidad + "',  " +
                "civa ='" + cliente.Iva + "',  " +
                "id_tipo_cliente ='" + cliente.TipoCliente.Id + "',  " +
                "nombre_local ='" + cliente.NombreLocal + "',  " +
                "telefono ='" + cliente.Telefono + "',  " +
                "cuit ='" + cliente.Cuit + "',  " +
                "nombre_responsable ='" + cliente.NombreResponsable + "',  " +
                "fecha_desde ='" + cliente.FechaDesde.ToString("yyyy-MM-dd") + "', " +
                "usuario ='" + cliente.idUsuario + "' "+
                "WHERE id= " + cliente.Id+"";
            return query;
        }
        public string GetClientes()
        {
            return "SELECT * FROM cliente ORDER BY razon_social;";
        }
        public string GetClientes(int id)
        {
            return "SELECT * FROM cliente  WHERE id = " + id + " ORDER BY razon_social;";
        }
        public string GetClientesData()
        {
            return
                " SELECT " +
             "	c.id , " +
             "	c.razon_social AS RazonSocial, " +
             "	c.domicilio AS Domicilio, " +
             "	c.localidad AS Localidad, " +										  
             "	cast(c.id_tipo_cliente as CHAR(50)) AS TipoCliente, " +
             "  c.fecha_desde as FechaDesde, " +
             "	c.civa AS IVA, " +
             "	c.cuit AS CUIT, " +
             "	c.nombre_responsable AS NombreResponsable, " +
             "	c.nombre_local AS NombreLocal, " +
             "	c.telefono AS Telefono," +
             "	c.fecha_baja AS FechaBaja " +
             " FROM " +
             "	cliente c " +
             "   order by c.id  ";
        }
        //trae el saldo actual y algunos datos de referencia para el form de MovCuentas
         public string GetClientesSaldoActual()
        {
            return "SELECT cliente.id, cliente.razon_social AS `razon social`, cliente.nombre_local AS `nombre local`, cast(ct.descripcion as CHAR(50)) AS `Tipo Cliente`, cliente.civa AS iva," +
        " cliente.cuit AS cuit, cuenta.cbu, cuenta.nro_cuenta AS `nro cuenta`, cuenta.saldo_actual AS `saldo actual`, cuenta.fecha_updated AS actualizado, " +
        " cuenta.usuario, cuenta.fecha_baja FROM cliente inner join cuenta on cliente.id = cuenta.id_cliente INNER JOIN clientetipo ct ON ct.id = cliente.id_tipo_cliente order by cliente.id  ";
        }
		
		public string GetDeleteClient(string idCliente, DateTime fechaBaja)
        {
            return "update cliente set fecha_baja ='" + fechaBaja.ToString() + "' where id = "+ idCliente+";";
        }

        /* Proveedores */
        public string InsertNuevoProveedor(Proveedor Proveedor)
        {
            //revisar
            return "INSERT INTO Proveedor ( razon_social, domicilio, localidad, civa, id_tipo_cliente, nombre_local, cuit, telefono, nombre_responsable, fecha_desde, fecha_baja, usuario) " +
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
                Proveedor.idUsuario + ");";

        }
        //public string UpdateProveedor(Proveedor Proveedor)
        //{
        //    string query = "UPDATE cliente SET " +
        //        "razon_social ='" + cliente.RazonSocial + "',  " +
        //        "domicilio ='" + cliente.Domicilio + "',  " +
        //        "localidad ='" + cliente.Localidad + "',  " +
        //        "civa ='" + cliente.Iva + "',  " +
        //        "id_tipo_cliente ='" + cliente.TipoCliente.Id + "',  " +
        //        "nombre_local ='" + cliente.NombreLocal + "',  " +
        //        "telefono ='" + cliente.Telefono + "',  " +
        //        "cuit ='" + cliente.Cuit + "',  " +
        //        "nombre_responsable ='" + cliente.NombreResponsable + "',  " +
        //        "fecha_desde ='" + cliente.FechaDesde.ToString("yyyy-MM-dd") + "', " +
        //        "usuario ='" + cliente.idUsuario + "' " +
        //        "WHERE id= " + cliente.Id + "";
        //    return query;
        //}
        public string GetProveedores()
        {
            return "SELECT * FROM proveedor ORDER BY razon_social;";
        }
        public string GetProveedores(int id)
        {
            return "SELECT * FROM proveedor  WHERE id = " + id + " ORDER BY razon_social;";
        }
        public string GetProveedoresData()
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
             "   order by c.id  ";
        }        
        public string GetProveedoresSaldoActual()
        {
            //trae el saldo actual y algunos datos de referencia para el form de MovCuentas
            return "SELECT proveedor.id, proveedor.razon_social AS `razon social`, proveedor.nombre_local AS `nombre local`," +
        " proveedor.cuit AS cuit,banco.descripcion AS Banco, cuenta.cbu, cuenta.nro_cuenta AS `nro cuenta`, cuenta.saldo_actual AS `saldo actual`, cuenta.fecha_updated AS actualizado, " +
        " cuenta.usuario, cuenta.fecha_baja FROM proveedor inner join cuentaproveedor cuenta on proveedor.id = cuenta.id_proveedor INNER JOIN banco ON cuenta.id_banco = banco.id order by proveedor.id  ";
        }
        
        /* Cuentas */
        public string GetClientesWithCuentaById(int id){
            return "SELECT c.id , " +
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
             " INNER JOIN clientetipo ct ON ct.id = c.id_tipo_cliente INNER JOIN cuenta cu ON cu.id_cliente = c.id " +
             " WHERE c.id =" + id +
             "   AND c.fecha_baja is null  " +
             "   order by c.id  ";
        }
        public string GetClientesWithCuenta()
        {
            return "SELECT c.id , " +
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
             " INNER JOIN clientetipo ct ON ct.id = c.id_tipo_cliente INNER JOIN cuenta cu ON cu.id_cliente = c.id " +
             " WHERE " +
             "   c.fecha_baja is null  " +
             "   order by c.id  ";
        }
        public string GetCuentaByIdCliente(int id)
        {
            return "select * from cuenta where id_cliente = " + id.ToString() ;
        }
		
        public string GetCuenta(int id)
        {
            return "select * from cuenta where id = " + id.ToString() ;
        }
        public string GetCuentas()
        {
            return "select * from cuenta order by id;";
        }
        public string GetCuentas(int idCliente)
        {
            return "select * from cuenta where id_cliente_cuenta = " + idCliente + " order by id;";
        }
        public string InsertNuevaCuenta(Cuenta newCuenta, string idCliente)
        {
            return "INSERT INTO cuenta ( cbu, nro_cuenta, saldo_actual, id_cliente, fecha_updated, usuario, fecha_baja) " +
            " VALUES ('" + newCuenta.Cbu + "', '" +
            newCuenta.Numerocuenta + "', '" +
            newCuenta.SaldoActual + "', '" +
            idCliente + "', " +
            " NOW() , 0 , null );";
        }

        /* Cuentas proveedores */
        /* Movimiento Cuentas proveedores */
        public string GetMovCuentasProveedores()
        {/* trae todos los movimiento de cuentas de todos los proveedores*/
            return "SELECT " +
                    "cm.id, " +
                    "cm.vob," +
                    "gc.id," +
                    "gc.id_proveedor," +
                    "cm.id_cliente, " +
                    "cm.id_movimiento_tipo," +
                    "mt.descripcion, " +
                    "round(cm.monto, 2) AS monto, " +
                    "DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS fecha_," +
                    "cm.cobrado, " +
                    "cm.usuario " +
                    "FROM proveedorcuentamovimiento cm INNER JOIN proveedorcuenta gc ON cm.id_cuenta = gc.id " +
                    "INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id " +
                    "WHERE gc.id_proveedor IS NOT NULL ORDER BY cm.id DESC;";
        }
        public string GetProveedoresWithCuentaById(int id)
        {
            return "SELECT c.id , " +
             "	c.razon_social AS RazonSocial, " +
             "	c.domicilio AS Domicilio, " +
             "	c.localidad AS Localidad, " +
             "	cu.id AS IdCuenta, " +
             "  c.fecha_desde as FechaDesde, " +
             "	c.civa AS IVA, " +
             "	c.cuit AS CUIT, " +
             "	c.nombre_responsable AS NombreResponsable, " +
             "	c.nombre_local AS NombreLocal, " +
             "	c.telefono AS Telefono " +
             " FROM " +
             "	proveedor c " +
             " INNER JOIN cuentaproveedor cu ON cu.id_proveedor = c.id " +
             " WHERE c.id =" + id +
             "   AND c.fecha_baja is null  " +
             "   order by c.id  ";
        }
        public string GetProveedoresWithCuenta()
        {
            return "SELECT c.id , " +
             "	c.razon_social AS RazonSocial, " +
             "	c.domicilio AS Domicilio, " +
             "	c.localidad AS Localidad, " +
             "	cu.id AS IdCuenta, " +
             "  c.fecha_desde as FechaDesde, " +
             "	c.civa AS IVA, " +
             "	c.cuit AS CUIT, " +
             "	c.nombre_responsable AS NombreResponsable, " +
             "	c.nombre_local AS NombreLocal, " +
             "	c.telefono AS Telefono " +
             " FROM " +
             "	proveedor c " +
             " INNER JOIN cuentaproveedor cu ON cu.id_proveedor = c.id " +
             " WHERE " +
             "   c.fecha_baja is null  " +
             "   order by c.id  ";
        }
        public string GetCuentaByIdProveedor(int id)
        {
            return "select * from cuentaproveedor where id_proveedor = " + id.ToString();
        }
        public string GetCuentaProveedor(int id)
        {
            return "select * from cuentaproveedor where id = " + id.ToString();
        }
        public string GetCuentasProveedor()
        {
            return "select * from cuentaproveedor order by id;";
        }
        public string GetCuentasProveedores(int idProveedor)
        {
            return "select * from cuentaproveedor where id_proveedor = " + idProveedor + " order by id;";
        }
        public string InsertNuevaCuentaProveedor(Cuenta newCuenta, string idProveedor)
        {
            return "INSERT INTO cuentaproveedor ( cbu, nro_cuenta, saldo_actual, id_proveedor, fecha_updated, usuario, fecha_baja) " +
            " VALUES ('" + newCuenta.Cbu + "', '" +
            newCuenta.Numerocuenta + "', '" +
            newCuenta.SaldoActual + "', '" +
            idProveedor + "', " +
            " NOW() , 0 , null );";
        }
        public string GetMovCuentasProveedor(int id, int pInicio, int registros)
        {
            /* trae paginando los movimiento de cuentas de un solo cliente*/

            return "SELECT " +
                    "cm.id, " +
                    "cm.vob," +
                    "gc.id," +
                    "gc.id_proveedor," +

                    "cm.id_movimiento_tipo," +
                    "mt.descripcion, " +
                    "round(cm.monto, 2) AS monto, " +
                    "DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS fecha_," +
                    "cm.cobrado, " +
                    "cm.usuario " +
                    "FROM cuentamovimientoproveedor cm INNER JOIN cuentaproveedor gc ON cm.id_proveedor = gc.id " +
                    "INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id " +
                    "WHERE gc.id_proveedor =" + id.ToString() + " ORDER BY cm.id DESC LIMIT " +
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

                    "cm.id_movimiento_tipo," +
                    "mt.descripcion, " +
                    "round(cm.monto, 2) AS monto, " +
                    "DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS fecha_," +
                    "cm.cobrado, " +
                    "cm.usuario " +
                    "FROM cuentamovimientoproveedor cm INNER JOIN cuentaproveedor gc ON cm.id_proveedor = gc.id " +
                    "INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id " +
                    "WHERE gc.id_proveedor =" + id.ToString() + " AND cm.fecha BETWEEN '" + fdesde +
                    "' AND '" + fhasta + "' ORDER BY cm.id DESC LIMIT " +
                    pInicio.ToString() + ", " + registros.ToString() + ";";
        }

        public string GetMovCuentasProveedorContar(int id)
        {
            /* cuenta cuantos registros hay en total */

            return "SELECT count(*) " +
                    "FROM cuentamovimientoproveedor cm INNER JOIN cuentaproveedor gc ON cm.id_cliente = gc.id " +
                    "INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id " +
                    "WHERE gc.id_proveedor =" + id.ToString() + " ORDER BY cm.id DESC;";
        }
        public string InsertMovCuentaProveedor(MovimientoCuenta movCuenta)
        {
            /* persiste el movimiento de cuenta*/
            return "INSERT INTO cuentamovimientoproveedor(" +
                "vob," +
                "id_cliente_cuenta," +
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
        public string ActualizaSaldoProveedor(Cuenta Cuenta)
        {
            /* persiste el saldo actual de la cuenta*/
            return "UPDATE cuentaproveedor set saldo_actual = " +
                Cuenta.SaldoActual + ", fecha_updated = now() WHERE id = " + Cuenta.Id + ";";
        }

        /* Movimiento Cuentas */
        public string GetMovCuentas()
        {/* trae todos los movimiento de cuentas de todos los clientes*/
            return "SELECT " +
                    "cm.id, " +
                    "cm.vob," +
                    "gc.id," +
                    "gc.id_cliente," +
                    "cm.id_cliente_cuenta, " +
                    "cm.id_movimiento_tipo," +
                    "mt.descripcion, " +
                    "round(cm.monto, 2) AS monto, " +
                    "DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS fecha_," +
                    "cm.cobrado, " +
                    "cm.usuario " +
                    "FROM cuentamovimiento cm INNER JOIN cuenta gc ON cm.id_cliente_cuenta = gc.id " +
                    "INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id " +
                    "WHERE gc.id_cliente IS NOT NULL ORDER BY cm.id DESC;";
        }        
        public string GetMovCuentas(int id, int pInicio, int registros)
        {
            /* trae paginando los movimiento de cuentas de un solo cliente*/

            return "SELECT " +
                    "cm.id, " +
                    "cm.vob," +
                    "gc.id," +
                    "gc.id_cliente," +
                    "cm.id_cliente_cuenta, " +
                    "cm.id_movimiento_tipo," +
                    "mt.descripcion, " +
                    "round(cm.monto, 2) AS monto, " +
                    "DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS fecha_," +
                    "cm.cobrado, " +
                    "cm.usuario " +
                    "FROM cuentamovimiento cm INNER JOIN cuenta gc ON cm.id_cliente_cuenta = gc.id " +
                    "INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id " +
                    "WHERE gc.id_cliente =" + id.ToString() + " ORDER BY cm.id DESC LIMIT " +
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
                    "cm.id_cliente_cuenta, " +
                    "cm.id_movimiento_tipo," +
                    "mt.descripcion, " +
                    "round(cm.monto, 2) AS monto, " +
                    "DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS fecha_," +
                    "cm.cobrado, " +
                    "cm.usuario " +
                    "FROM cuentamovimiento cm INNER JOIN cuenta gc ON cm.id_cliente_cuenta = gc.id " +
                    "INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id " +
                    "WHERE gc.id_cliente =" + id.ToString() + " AND cm.fecha BETWEEN '" + fdesde + 
                    "' AND '" + fhasta  + "' ORDER BY cm.id DESC LIMIT " +
                    pInicio.ToString() + ", " + registros.ToString() + ";";
        }
        public string GetMovCuentasContarBetweenDates(int idCliente, string fdesde, string fhasta)
        {
            /* cuenta cuantos registros hay en total */

            return "SELECT count(*) " +
                    "FROM cuentamovimiento cm INNER JOIN cuenta gc ON cm.id_cliente_cuenta = gc.id " +
                    "INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id " +
                    "WHERE gc.id_cliente =" + idCliente.ToString() + " AND cm.fecha BETWEEN '" + fdesde +
                    "' AND '" + fhasta + "' ORDER BY cm.id DESC;";
        }
        public string GetMovCuentasProveedoresContarBetweenDates(int idProveedor, string fdesde, string fhasta)
        {
            /* cuenta cuantos registros hay en total */

            return "SELECT count(*) " +
                    "FROM cuentamovimiento cm INNER JOIN cuentaproveedor gc ON cm.id_cliente_cuenta = gc.id " +
                    "INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id " +
                    "WHERE gc.id_proveedor =" + idProveedor.ToString() + " AND cm.fecha BETWEEN '" + fdesde +
                    "' AND '" + fhasta + "' ORDER BY cm.id DESC;";
        }
        public string GetMovCuentasContar(int id)
        {
            /* cuenta cuantos registros hay en total */

            return "SELECT count(*) " +
                    "FROM cuentamovimiento cm INNER JOIN cuenta gc ON cm.id_cliente_cuenta = gc.id " +
                    "INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id " +
                    "WHERE gc.id_cliente =" + id.ToString() + " ORDER BY cm.id DESC;";
        }
        public string InsertMovCuenta(MovimientoCuenta movCuenta)
        {
            /* persiste el movimiento de cuenta*/
            return "INSERT INTO cuentamovimiento(" +
                "vob," +
                "id_cliente_cuenta," +
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
        public string ActualizaSaldo(Cuenta Cuenta)
        {
            /* persiste el saldo actual de la cuenta*/
            return "UPDATE cuenta set saldo_actual = " +
                Cuenta.SaldoActual + ", fecha_updated = now() WHERE id = " + Cuenta.Id + ";";
        }
        /* Ventas */
        public string GetProductoFromIdCode(string idCode)
        {
            return GetProductosData() +
                " and id_codigo_barra like '" + idCode + "'";
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
                vd.Peso + "', " +
                vd.idUsuario + ");";
        }
        public string InsertVenta(Venta v)
        {
            return "INSERT INTO venta (monto_total, fecha, usuario) VALUES ('" +
                v.MontoTotal + "', " +
                " NOW() , " +
                v.idUsuario + ");";
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
            return "SELECT * FROM venta v where v.fecha between curdate() and ADDDATE(curdate(),1);";
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
                    producto.idUsuario +", " +
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
        public string GetProductoById(int id)
        {
            return "select * From producto where id = " + id + ";";
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
                    g.Mes + "', '1', " +
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

    }



}