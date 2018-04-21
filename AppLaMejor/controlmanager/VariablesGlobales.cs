using AppLaMejor.entidades;

namespace AppLaMejor.controlmanager
{
    static class VariablesGlobales
    {
        public static bool FormMovCuentas_activo = false;
        public static bool FormMovCuentas_comboCargado = false;
        public static int idProductoHistorico = -1;
        public static int userIdLogueado;

        public static string QENDRAPATH_PARAMNAME = "QENDRA_PATH";
        public static string FILEPRECIOSSAVE_PARAMNAME = "FILE_PRECIOS_SAVE";

        //operacion
        public static int idMovCuenta_VentaMay = 0;
		public static int idOperacion = 0;
        public static Cuenta Cuenta_VentaMay = new Cuenta();

        // Formatos de fecha
        public static string dateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        public static string dateFormat = "yyyy-MM-dd";

        // Ubicacion
        public static string ubicacionInicialCompra = "4"; // Mesa de Entrada

    }
}
