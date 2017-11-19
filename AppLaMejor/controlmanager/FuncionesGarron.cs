using AppLaMejor.datamanager;
using AppLaMejor.entidades;
using AppLaMejor.formularios.Util;
using AppLaMejor.stylemanager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppLaMejor.controlmanager
{
    public class FuncionesGarron
    {
        public static Garron GetGarron(int idGarron)
        {
            QueryManager manager = QueryManager.Instance();
            string query = manager.GetGarron(idGarron);
            DataTable result = manager.GetTableResults(ConnecionBD.Instance().Connection, query);
            DataNamesMapper<Garron> mg = new DataNamesMapper<Garron>();
            return mg.Map(result).ToList().First();
        }
        public static ComboBox GetComboTipoGarron(ComboBox cb, List<TipoGarron> list)
        {
            BindingList<TipoGarron> objects = new BindingList<TipoGarron>(list);
            cb.DisplayMember = "Descripcion";
            cb.DataSource = objects;
            cb.SelectedIndex = -1;
            return cb;
        }
        public static TipoGarron GetTipoGarronClicked(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            TipoGarron tipoGarron = (TipoGarron)combo.SelectedValue;
            return tipoGarron;
        }
        public static ComboBox GetComboGarron(ComboBox cb, List<Garron> list)
        {
            BindingList<Garron> objects = new BindingList<Garron>(list);
            cb.DisplayMember = "Numero";
            cb.DataSource = objects;
            cb.SelectedIndex = -1;
            return cb;
        }
        public static Garron GetGarronClicked(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            Garron garron = (Garron)combo.SelectedValue;
            return garron;
        }
        public static List<Garron> GetListGarronByEstadoAndTipo(string estado, string tipo)
        {
            string consulta = QueryManager.Instance().GetGarronByEstadoAndTipo(estado, tipo);
            DataTable dataTablaGarron = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            DataNamesMapper<Garron> mg = new DataNamesMapper<Garron>();
            return mg.Map(dataTablaGarron).ToList();
        }
        public static List<GarronParte> GetIdProductoDeposteByGarron(int idGarron)
        {
            string consulta = QueryManager.Instance().GetGarronProductoByGarron(idGarron.ToString());
            DataTable dataTable = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            DataNamesMapper<GarronParte> mgp = new DataNamesMapper<GarronParte>();
            List<GarronParte> list = mgp.Map(dataTable).ToList();
            return list;
        }
        public static List<int> GetIdProductoDepostado(int idGarron)
        {
            string consulta = QueryManager.Instance().GetGarronProductoDepostadoByGarron(idGarron.ToString());
            DataTable dataTableIds = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            List<int> list = new List<int>();
            foreach (DataRow row in dataTableIds.Rows)
            {
                list.Add((int)row[0]);
            }
            return list;
        }
        public static bool InsertGarron(Garron g)
        {
            // Recibe garron para insertar y devuelve el Id de garron insertado
            try
            {
                QueryManager manager = QueryManager.Instance();
                string consulta = manager.InsertGarron(g);
                if (manager.ExecuteSQL(ConnecionBD.Instance().Connection, consulta))
                {
                    consulta = manager.GetLastInsertedGarron();
                    g.Id = int.Parse(manager.GetTableResults(ConnecionBD.Instance().Connection, consulta).Rows[0][0].ToString());
                    return true;
                };
            }
            catch (Exception e)
            {
				FormMessageBox dialog = new FormMessageBox();
                dialog.ShowErrorDialog("Ocurrio un error : " + e.Message);
                return false;
            }
            return false;
        }

        public static Garron AgregarGarron(string v)
        {
            Garron g = new Garron();
            g.FechaEntrada = DateTime.Now;
            FormEntityInput dialog = new FormEntityInput(g, FormEntityInput.MODO_INSERTAR, v);
            Boolean result = dialog.Execute(g);

            if (result)
            {
                g = (Garron)dialog.SelectedObject;
                // Desde este form solo se carga garron estado COMPLETO = 1
                g.TipoEstadoGarron = TiposManager.Instance().GetTipoEstadoGarron(1);
                /* Insert en BD */
                if (FuncionesGarron.InsertGarron(g))
                {
                    return g;
                }
                else
                {
                    return null;
                }

            }
            return null;
        }
        public static Garron AgregarGarronSinBD(string v)
        {
            Garron g = new Garron();
            g.FechaEntrada = DateTime.Now;
            FormEntityInput dialog = new FormEntityInput(g, FormEntityInput.MODO_INSERTAR, v);
            Boolean result = dialog.Execute(g);

            if (result)
            {
                g = (Garron)dialog.SelectedObject;
                // Desde este form solo se carga garron estado COMPLETO = 1
                g.TipoEstadoGarron = TiposManager.Instance().GetTipoEstadoGarron(1);
                /* Insert en BD */
                    return g;
            }
            return null;
        }

    }
}
