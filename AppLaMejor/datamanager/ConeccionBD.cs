using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace AppLaMejor.datamanager
{
     /* Clase singleton para conectar a la bd */
      public class ConnecionBD{


        //string connstring = "Server=localhost; database=u570713702_jjdev; UID=root; pooling=false";
        string connstring = "Server=localhost; database=u570713702_jjdev; UID=root;Password=dd74f695; Pooling=false";
        //string connstring = "Server=sql52.main-hosting.eu; database=u570713702_jjdev; UID=u570713702_jjdev; Password=dd74f695; Pooling=false";

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
                MessageBox.Show("No se pudo establecer conexion con la Base de Datos. Saliendo...");
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
