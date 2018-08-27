using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;
using AppLaMejor.entidades;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace AppLaMejor.controlmanager
{
    public class FuncionesBackups
    {
        public static DataTable fillBackups()
        {
            return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, QueryManager.Instance().GetBackupsData());
        }
        public static List<Backup> listBackups(DataTable table)
        {
            DataNamesMapper<Backup> mapper = new DataNamesMapper<Backup>();
            return mapper.Map(table).ToList();
        }
        public static bool InsertBackup(Backup bkp)
        {
            QueryManager manager = QueryManager.Instance();
            string consulta = manager.InsertNuevoBackup(bkp);
            return manager.ExecuteSQL(ConnecionBD.Instance().Connection, consulta);
        }
        public static int ConsultaBackupDelDia()
        {
            //el sql compara la fecha del ultimo backup, con la fecha de now()
            //true 1 o sea que hay backup hecho en el dia
            //false 0 o sea aun no hay backup
            QueryManager manager = QueryManager.Instance();
            string consulta = manager.GetLastBackup();
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
            if (table.Rows.Count.Equals(0))
                return 0;

            return Int32.Parse(table.Rows[0][0].ToString());
        }

       

        //obtiene el proximo id backup
        public static int GetNextIdBackup()
        {
            QueryManager manager = QueryManager.Instance();
            string consulta = manager.GetNextBackupId();
            DataTable result = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);

            if (result.Rows[0][0].ToString().Length == 0)
                return 1;
            else return Int32.Parse(result.Rows[0][0].ToString());
        }

        //obtiene la info de la fila del backup para saber el nombre del archivo sql a restaurar
        public static string[] obtenerTextFromGrid(DataGridView grid)
        {
            // para que funcione la query tiene que tener un campo "id"
            BindingManagerBase bm = grid.BindingContext[grid.DataSource, grid.DataMember];
            DataRow dr = ((DataRowView)bm.Current).Row;

            string[] arr1 = new string[] { dr.Field<string>("descripcion"), dr.Field<DateTime>("fecha").ToString() };
            return arr1; 
        }
        public static void crearBackUp()
        {
            string comando = "mysqldump --routines -u root -pdd74f695  bdlamejor_dev > ";
            string path = @"c:\backupBD\sql\bkpfile.bat";
            string pathsql = @"C:\backupBD\sql\";
            string sqlfile = "bdlamejor_dev_" + DateTime.Now.AddDays(0).ToString("yyyy_MM_dd") + ".sql";
            File.Delete(path);
            if (!File.Exists(path))
            {
                // 
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("@echo off");
                    sw.WriteLine("echo Comenzando el backup de la Base de Datos en el Servidor");
                    sw.WriteLine(comando + pathsql + sqlfile);
                    sw.WriteLine("echo on");
                    sw.WriteLine("echo Backup Completo");
                }
                Process myProcess = new Process();
                myProcess.StartInfo.Verb = "runas";
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = "c:\\backupBD\\sql\\bkpfile.bat";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.Arguments = "";
                myProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
                myProcess.Start();

                Backup bkp = new Backup();
                bkp.Id = GetNextIdBackup();
                bkp.Descripcion = sqlfile;

                InsertBackup(bkp);
            }
        }
        public static void restaurarCopia(string descripcion)
        {
            string path = @"c:\backupBD\sql\rtrfile.bat";
            string pathsql = @"C:\backupBD\sql\";
            string sqlfile = descripcion;

            File.Delete(path);

            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("@echo off");
                    sw.WriteLine("echo Comenzando la Restauración de la Base de Datos en el Servidor");
                    sw.WriteLine("mysql --user=root --password=dd74f695 bdlamejor_dev < " + pathsql + sqlfile);
                    sw.WriteLine("echo on");
                    sw.WriteLine("echo Restauración Completa.");
                }
                Process myProcess = new Process();
                myProcess.StartInfo.Verb = "runas";
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = "c:\\backupBD\\sql\\rtrfile.bat";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.Arguments = "";
                myProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
                myProcess.Start();
            }

        }
    }
        
}
