using System;
using MySql.Data.MySqlClient;
using AppLaMejor.formularios.Util;

namespace AppLaMejor.datamanager
{
     /* Clase singleton para conectar a la bd */
      public class ConnecionBD{

        // TODO: leer string de coneccion desde un archivo
        string connstring = "Server=localhost; database=u570713702_jjdev; password=dd74f695; UID=root; pooling=false;";

        private MySqlConnection connection = null;
        private static ConnecionBD _instance = null;

        private void ConeccionBD()
        {
        }

        public MySqlConnection Connection
        {
            get { return connection; }
        }
        public static ConnecionBD Instance()
        {
            if (_instance == null)
                _instance = new ConnecionBD();
           return _instance;
        }
        public bool IsConnect()
        {
            bool result = true;
            try
            {
                if (connection == null)
                {
                    connection = new MySqlConnection(connstring);
                    connection.Open();
                    result = true;
                }
                
            }
            catch (Exception E)
            {
                FormMessageBox dialog = new FormMessageBox();
                dialog.ShowErrorDialog("No se pudo establecer conexion con la Base de Datos. Saliendo del sistema. \nMotivo: "+E.Message);
                result = false;
            }
            


            return result;
        }

        public void Close()
        {
            connection.Close();
        }   
      }
}
