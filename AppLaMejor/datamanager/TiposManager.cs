﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.entidades;
using System.Data;

namespace AppLaMejor.datamanager
{
    class TiposManager
    {
        private static TiposManager _instance = null;

        /* Lista de Tipos Incluidos */
        List<String> listTipos = null;
        private TiposManager(){
            listTipos = new List<String>();
            listTipos.Add("TipoCliente");
            listTipos.Add("TipoMovimiento");
            listTipos.Add("TipoProducto");
            listTipos.Add("TipoProductoEstado");
            listTipos.Add("TipoPrecio");
            listTipos.Add("Medida");
            listTipos.Add("TipoUbicacion");

        }

        public List<String> ListTipos
        {
            get { return listTipos; }
            set { listTipos = value; }
        }

        /* Clase singleton que retorna tipos en una lista */
        public static TiposManager Instance()
        {
            if (_instance == null)
                _instance = new TiposManager();
            return _instance;
        }

        /* Nomenclador TipoCliente*/
        List<TipoCliente> listTipoCliente;
        public List<TipoCliente> GetTipoClienteList()
        {
            QueryManager manager = QueryManager.Instance();
            String consulta = manager.GetTipoCliente();
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
            listTipoCliente = new List<TipoCliente>();

            DataNamesMapper<TipoCliente> mapperTipoClientes = new DataNamesMapper<TipoCliente>();
            listTipoCliente = mapperTipoClientes.Map(table).ToList();

            return listTipoCliente;
        }
        public TipoCliente GetTipoCliente(int id)
        {
            if (listTipoCliente == null)
            {
                listTipoCliente = GetTipoClienteList();
            }

            TipoCliente result = null;

            foreach (TipoCliente t in listTipoCliente)
            {
                if (result == null)
                {
                    if (t.Id.Equals(id))
                    {
                        result = t;
                    }
                }
                else break;
            }
            return result;
        }
        public TipoCliente GetTipoClienteByIdCliente(int idCliente)
        {
            QueryManager manager = QueryManager.Instance();
            String consulta = manager.GetTipoClienteByIdCliente(idCliente);
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
            int idTipoCliente = table.Rows[0].Field<int>("id_tipo_cliente");
            return GetTipoCliente(idTipoCliente);
        }
        public TipoCliente GetTipoClienteByName(string tipoCliente)
        {
            foreach (TipoCliente tipo in listTipoCliente)
            {
                if (tipo.Equals(tipoCliente))
                {
                    return tipo;
                }
            }
            return null;
        }

        /* Nomenclador TipoMovimiento*/
        List<TipoMovimiento> listTipoMovimiento;
        public TipoMovimiento GetTipoMovimiento(int p)
        {
            if (listTipoMovimiento == null)
            {
                listTipoMovimiento = GetTipoMovimientoList();
            }

            TipoMovimiento result = null;

            foreach (TipoMovimiento t in listTipoMovimiento)
            {
                if (result == null)
                {
                    if (t.Id.Equals(p))
                    {
                        result = t;
                    }
                }
                else break;
            }
            return result;
        }
        private List<TipoMovimiento> GetTipoMovimientoList()
        {
            QueryManager manager = QueryManager.Instance();
            String consulta = manager.GetTipoMovimiento();
            DataTable tableTipoMovimiento = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
            listTipoMovimiento = new List<TipoMovimiento>();

            DataNamesMapper<TipoMovimiento> mapper = new DataNamesMapper<TipoMovimiento>();

            listTipoMovimiento = mapper.Map(tableTipoMovimiento).ToList();

            return listTipoMovimiento;
        }
    
        /* Nomenclador TipoProducto*/
        List<TipoProducto> listTipoProducto;
        public List<TipoProducto> GetTipoProductoList()
        {
            QueryManager manager = QueryManager.Instance();
            String consulta = manager.GetTipoProducto();
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
            listTipoProducto = new List<TipoProducto>();

            DataNamesMapper<TipoProducto> m = new DataNamesMapper<TipoProducto>();
            listTipoProducto = m.Map(table).ToList();

            return listTipoProducto;
        }
        public TipoProducto GetTipoProducto(int id)
        {
            if (listTipoProducto == null) listTipoProducto = GetTipoProductoList();
            
            foreach (TipoProducto t in listTipoProducto)
            {
                if (t.Id.Equals(id))
                {
                    return t;
                }
            }
            return null;
        }
        public TipoProducto GetTipoProductoByIdProducto(int idProducto)
        {
            QueryManager manager = QueryManager.Instance();
            String consulta = manager.GetProductoDataById(idProducto);
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
            int idTipoProducto = table.Rows[0].Field<int>("id_producto_tipo");
            return GetTipoProducto(idTipoProducto);
        }
        public TipoProducto GetTipoProductoByName(string tipoProducto)
        {
            if (listTipoProducto == null) GetTipoProductoList();

            foreach (TipoProducto tipo in listTipoProducto)
            {
                if (tipo.Equals(tipoProducto))
                {
                    return tipo;
                }
            }
            return null;
        }

        /* Nomenclador TipoPrecio*/
        List<TipoPrecio> listTipoPrecio;
        public List<TipoPrecio> GetTipoPrecioList()
        {
            QueryManager manager = QueryManager.Instance();
            String consulta = manager.GetTipoPrecio();
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
            listTipoPrecio = new List<TipoPrecio>();

            DataNamesMapper<TipoPrecio> m = new DataNamesMapper<TipoPrecio>();
            listTipoPrecio = m.Map(table).ToList();

            return listTipoPrecio;
        }
        public TipoPrecio GetTipoPrecioByIdProducto(int Id)
        {
            QueryManager manager = QueryManager.Instance();
            String consulta = manager.GetTipoPrecioByIdProducto(Id);
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
            int idTipoPrecio = table.Rows[0].Field<int>("id_tipo_precio");
            return GetTipoPrecio(idTipoPrecio);
        }
        public TipoPrecio GetTipoPrecio(int idTipoPrecio)
        {
            if (listTipoPrecio == null) GetTipoPrecioList();

            foreach (TipoPrecio tipopre in listTipoPrecio)
            {
                if (tipopre.Id.Equals(idTipoPrecio))
                {
                    return tipopre;
                }
            }
            return null;
        }
        public TipoPrecio GetTipoPrecioByName(string tipoPrecio)
        {
            if (listTipoPrecio == null) GetTipoPrecioList();

            foreach (TipoPrecio tipo in listTipoPrecio)
            {
                if (tipo.Equals(tipoPrecio))
                {
                    return tipo;
                }
            }
            return null;
        }
        
        /* Nomenclador Medida*/
        List<Medida> listMedida;
        public List<Medida> GetMedidaList()
        {
            QueryManager manager = QueryManager.Instance();
            String consulta = manager.GetMedidas();
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
            listMedida = new List<Medida>();

            DataNamesMapper<Medida> m = new DataNamesMapper<Medida>();
            listMedida = m.Map(table).ToList();

            return listMedida;
        }
        public Medida GetMedidaById(int idMedida)
        {
            if (listMedida == null) GetMedidaList();

            foreach (Medida medida in listMedida)
            {
                if (medida.Id.Equals(idMedida))
                {
                    return medida;
                }
            }
            return null;
        }
        public Medida GetMedidaByName(string medidaName)
        {
            if (listMedida == null) GetMedidaList();

            foreach (Medida tipo in listMedida)
            {
                if (tipo.Equals(medidaName))
                {
                    return tipo;
                }
            }
            return null;
        }
        public Medida GetMedidaByIdProducto(int idProducto)
        {
            QueryManager manager = QueryManager.Instance();
            String consulta = manager.GetProductoDataById(idProducto);
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
            int idMedida = table.Rows[0].Field<int>("id_medida");
            return GetMedidaById(idMedida);
        }

        /* Nomenclador TipoGarron*/
        List<TipoGarron> listTipoGarron;
        public TipoGarron GetTipoGarron(int p)
        {
            if (listTipoGarron == null) listTipoGarron = GetTipoGarronList();

            foreach (TipoGarron t in listTipoGarron)
            {
                if (t.Id.Equals(p))
                {
                    return t;
                }
            }
            return null;
        }
        public List<TipoGarron> GetTipoGarronList()
        {
            QueryManager manager = QueryManager.Instance();
            String consulta = manager.GetTipoGarron();
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
            listTipoGarron = new List<TipoGarron>();

            DataNamesMapper<TipoGarron> m = new DataNamesMapper<TipoGarron>();
            listTipoGarron = m.Map(table).ToList();

            return listTipoGarron;
        }
        public TipoGarron GetTipoGarronById(int id)
        {
            if (listTipoGarron == null) GetTipoGarronList();

            foreach (TipoGarron tipo in listTipoGarron)
            {
                if (tipo.Id.Equals(id))
                {
                    return tipo;
                }
            }
            return null;
        }
        public TipoGarron GetTipoGarronByIdGarron(int Id)
        {
            QueryManager manager = QueryManager.Instance();
            String consulta = manager.GetTipoGarronByIdGarron(Id);
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
            int idTipoGarron = table.Rows[0].Field<int>("id_tipo_garron");
            return GetTipoGarron(idTipoGarron);
        }

        /* Nomenclador TipoEstadoGarron */
        List<TipoEstadoGarron> listTipoEstadoGarron;
        public TipoEstadoGarron GetTipoEstadoGarronByGarronId(int id)
        {
            QueryManager manager = QueryManager.Instance();
            String consulta = manager.GetTipoEstadoGarronByIdGarron(id);
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
            int idTipoEstadoGarron = table.Rows[0].Field<int>("id_tipo_estado");
            return GetTipoEstadoGarron(idTipoEstadoGarron);
            //return "select * from garronestado where id = '" + id.ToString() + "';";
        }
        public TipoEstadoGarron GetTipoEstadoGarron(int idTipoGarron)
        {
            if (listTipoEstadoGarron == null) listTipoEstadoGarron = GetTipoEstadoGarronList();

            foreach (TipoEstadoGarron t in listTipoEstadoGarron)
            {
                if (t.Id.Equals(idTipoGarron))
                {
                    return t;
                }
            }
            return null;
        }
        public List<TipoEstadoGarron> GetTipoEstadoGarronList()
        {
            QueryManager manager = QueryManager.Instance();
            String consulta = manager.GetTipoEstadoGarron();
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
            listTipoEstadoGarron = new List<TipoEstadoGarron>();

            DataNamesMapper<TipoEstadoGarron> m = new DataNamesMapper<TipoEstadoGarron>();
            listTipoEstadoGarron = m.Map(table).ToList();

            return listTipoEstadoGarron;
        }
        public TipoEstadoGarron GetTipoEstadoGarronByIdGarron(int id)
        {
            throw new NotImplementedException();
        }
    }
}