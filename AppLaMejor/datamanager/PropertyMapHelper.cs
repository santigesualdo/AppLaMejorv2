using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using AppLaMejor.entidades;
using System.Windows.Forms;
using AppLaMejor.formularios.Util;

namespace AppLaMejor.datamanager
{
    public static class PropertyMapHelper
    {
        public static void Map(Type type, DataRow row, PropertyInfo prop, object entity)
        {
            List<string> columnNames = AttributeHelper.GetDataNames(type, prop.Name);

            foreach (var columnName in columnNames)
            {
                if (!"".Equals(columnName) && row.Table.Columns.Contains(columnName))
                {
                    var propertyValue = row[columnName];
                    if (propertyValue != DBNull.Value)
                    {
                        ParsePrimitive(prop, entity, row[columnName]);
                        break;
                    }
                }
            }
        }

        private static void ParsePrimitive(PropertyInfo prop, object entity, object value)
        {
            try
            {
                if (prop.PropertyType == typeof(string))
                {
                    prop.SetValue(entity, value.ToString().Trim(), null);
                }
                else if (prop.PropertyType == typeof(bool) || prop.PropertyType == typeof(bool?))
                {
                    if (value == null)
                    {
                        prop.SetValue(entity, null, null);
                    }
                    else
                    {
                        prop.SetValue(entity, ParseBoolean(value.ToString()), null);
                    }
                }
                else if (prop.PropertyType == typeof(long))
                {
                    prop.SetValue(entity, long.Parse(value.ToString()), null);
                }
                else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?))
                {
                    if (value == null)
                    {
                        prop.SetValue(entity, null, null);
                    }
                    else
                    {
                        prop.SetValue(entity, int.Parse(value.ToString()), null);
                    }
                }
                else if (prop.PropertyType == typeof(decimal))
                {
                    prop.SetValue(entity, decimal.Parse(value.ToString()), null);
                }
                else if (prop.PropertyType == typeof(double) || prop.PropertyType == typeof(double?))
                {
                    double number;
                    bool isValid = double.TryParse(value.ToString(), out number);
                    if (isValid)
                    {
                        prop.SetValue(entity, double.Parse(value.ToString()), null);
                    }
                }
                else if (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(Nullable<DateTime>))
                {
                    DateTime date;
                    bool isValid = DateTime.TryParse(value.ToString(), out date);
                    if (isValid)
                    {
                        prop.SetValue(entity, date, null);
                    }
                    else
                    {
                        isValid = DateTime.TryParseExact(value.ToString(), "MMddyyyy", new CultureInfo("en-US"), DateTimeStyles.AssumeLocal, out date);
                        if (isValid)
                        {
                            prop.SetValue(entity, date, null);
                        }
                    }
                }
                else if (prop.PropertyType == typeof(TipoCliente))
                {
                    TipoCliente tc = TiposManager.Instance().GetTipoCliente(int.Parse(value.ToString()));
                    prop.SetValue(entity, tc, null);
                }
                else if (prop.PropertyType == typeof(TipoGarron))
                {
                    TipoGarron tg = TiposManager.Instance().GetTipoGarron(int.Parse(value.ToString()));
                    prop.SetValue(entity, tg, null);
                }
                else if (prop.PropertyType == typeof(TipoMovimiento))
                {
                    TipoMovimiento tm = TiposManager.Instance().GetTipoMovimiento(int.Parse(value.ToString()));
                    prop.SetValue(entity, tm, null);
                }
                else if (prop.PropertyType == typeof(TipoProducto))
                {
                    TipoProducto tp = TiposManager.Instance().GetTipoProducto(int.Parse(value.ToString()));
                    prop.SetValue(entity, tp, null);
                }
                else if (prop.PropertyType == typeof(Producto))
                {
                    int rowValue = int.Parse(value.ToString());
                    DataTable productoDataTable = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, QueryManager.Instance().GetProductoDataById(rowValue));
                    DataNamesMapper<Producto> m = new DataNamesMapper<Producto>();
                    Producto p = m.Map(productoDataTable).ToList().First();
                    prop.SetValue(entity, p, null);
                }
                else if (prop.PropertyType == typeof(Venta))
                {
                    DataTable ventaDataTable = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, QueryManager.Instance().GetVentaById(int.Parse(value.ToString())));
                    DataNamesMapper<Venta> m = new DataNamesMapper<Venta>();
                    Venta v = m.Map(ventaDataTable).ToList().First();
                    prop.SetValue(entity, v, null);
                }
                else if (prop.PropertyType == typeof(List<Cuenta>))
                {
                    DataTable cuentaDataTable = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, QueryManager.Instance().GetCuenta(int.Parse(value.ToString())));
                    DataNamesMapper<Cuenta> cuentaMapper = new DataNamesMapper<Cuenta>();
                    List<Cuenta> listCuentas = cuentaMapper.Map(cuentaDataTable).ToList();
                    prop.SetValue(entity, listCuentas, null);
                }
            }
            catch(InvalidOperationException e)
            {
				FormMessageBox dialog = new FormMessageBox();
				dialog.ShowErrorDialog("Error: " + e.Message);
            }
        }

        public static bool ParseBoolean(object value)
        {
            if (value == null || value == DBNull.Value) return false;

            switch (value.ToString().ToLowerInvariant())
            {
                case "1":
                case "y":
                case "yes":
                case "true":
                    return true;

                case "0":
                case "n":
                case "no":
                case "false":
                default:
                    return false;
            }
        }
    }
}
