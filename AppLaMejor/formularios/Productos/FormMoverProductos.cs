using AppLaMejor.controlmanager;
using AppLaMejor.datamanager;
using AppLaMejor.entidades;
using AppLaMejor.formularios.Util;
using AppLaMejor.stylemanager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppLaMejor.formularios.Productos
{
    public partial class FormMoverProductos : Form
    {
        // REGLAS DE FORMULARIO
        // TODO: MODELO Realizar circuito completo para validar. Compras + Mover.
        // TODO: FUNCIONALIDAD Hacer scrolleable el panel de movimientos

        public static int MODO_MOVERMERCADERIA = 0;
        public static int MODO_UBICARMERCADERIACOMPRA = 1;
        int currentModo = -1;

        private static int MODO_PRODUCTO = 0;
        private static int MODO_GARRON = 1;
        int currentMovimientoModo = -1;

        List<MovimientoMercaderia> listMovimientoMercaderia;
        MovimientoMercaderia currentMovimiento;

        List<Ubicacion> listUbicacionOrigen;
        List<Ubicacion> listUbicacionDestino;

        

        ComboBox comboUbicacionOrigen;
        ComboBox comboUbicacionDestino;
        ComboBox comboProdUbicacion;
        BindingSource bindOri;
        TextBox textBoxPesoMover;
        decimal pesoMax;
        Panel currentPanel;

        // MODO UBICAR COMPRA
        List<Producto> listProductos;
        List<Garron> listGarron;
        List<Panel> listPanels;

        Ubicacion globalDestino;

        public FormMoverProductos(int modo, List<Producto> lp, List<Garron> lg)
        {            
            listMovimientoMercaderia = new List<MovimientoMercaderia>();
            InitializeComponent();
            Cargar();

            currentModo = modo;

            if (currentModo.Equals(MODO_UBICARMERCADERIACOMPRA))
            {
                bMoverGarron.Visible = false;
                bMoverPro.Visible = false;

                if (lp != null && lp.Count > 0)
                {
                    listProductos = lp;
                    CargarProductosFromCompra(listProductos);
                }else
                    listProductos = null;
                    
                if (lg != null && lg.Count > 0)
                {
                    listGarron = lg;
                    CargarGarronFromCompra(listGarron);
                }
                else
                    listGarron = null;

                ActiveFirstPanel();
            }
        }

        private void ActiveFirstPanel()
        {
            if (listPanels == null || listPanels.Count.Equals(0))
                return;

            listPanels.Reverse();

            currentPanel = listPanels.First();
            currentPanel.Tag = "activo";
            ActivarComboDestino(currentPanel);
            currentPanel.Enabled = true;

            foreach (Panel p in listPanels)
            {
                if (p.Tag.Equals("pendiente"))
                {
                    p.Enabled = false;
                    p.BackColor = Color.Gray;
                }
            }
        }
        private void CargarGarronFromCompra(List<Garron> listGarron)
        {
            if (listPanels == null)
            {
                listPanels = new List<Panel>();
            }

            foreach (Garron g in listGarron)
            {
                currentMovimiento = new MovimientoMercaderia();
                currentMovimiento.confirmado = false;

                // TODO: MODELO Definir con el cliente ubicacion inicio y ubicacion salida.
                currentMovimiento.origen = TiposManager.Instance().GetUbicacionById(4);
                currentMovimiento.garron = g;
                currentMovimiento.peso = g.Peso;

                Panel panel = new Panel();
                panel.Dock = DockStyle.Top;
                panel.Height = 100;
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Tag = "pendiente";

                TableLayoutPanel tablePanel = new TableLayoutPanel();
                tablePanel.AllowDrop = true;
                tablePanel.AutoSize = true;
                tablePanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                tablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                tablePanel.ColumnCount = 5;
                tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
                tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
                tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
                tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
                tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
                tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
                tablePanel.Location = new System.Drawing.Point(5, 5);
                tablePanel.Name = "tablePanel";
                tablePanel.RowCount = 2;
                tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

                tablePanel.Controls.Add(FuncionesGlobales.StyleLabel("Ubicacion Origen"), 0, 0);

                // label con ubicacion origen 
                Label lUbicacionOrigen = FuncionesGlobales.StyleLabel(currentMovimiento.origen.Descripcion);
                tablePanel.Controls.Add(lUbicacionOrigen, 0, 1);

                tablePanel.Controls.Add(FuncionesGlobales.StyleLabel("Garron a Mover"), 1, 0);

                // label con numero de garron 
                Label lGarron = FuncionesGlobales.StyleLabel("Numero: " + g.Numero);
                tablePanel.Controls.Add(lGarron, 1, 1);

                //label.Text = "Cantidad a mover";
                tablePanel.Controls.Add(FuncionesGlobales.StyleLabel("Cantidad a mover"), 2, 0);

                // text box con cantidad peso disponible
                Label lPesoGarron = FuncionesGlobales.StyleLabel(g.Peso + " kg.");
                tablePanel.Controls.Add(lPesoGarron, 2, 1);

                //label.Text = "Ubicacion Destino";
                tablePanel.Controls.Add(FuncionesGlobales.StyleLabel("Ubicacion Destino"), 3, 0);

                // Ubicaciones destino disponibles.
                listUbicacionDestino = FuncionesProductos.GetUbicacionDestino(currentMovimiento.origen.Id, listMovimientoMercaderia);
                comboUbicacionDestino = new ComboBox();
                comboUbicacionDestino.Anchor = AnchorStyles.None;
                comboUbicacionDestino.Dock = DockStyle.Fill;
                comboUbicacionDestino.Enabled = false;
                comboUbicacionDestino.SelectedValueChanged += ComboUbicacionDestino_SelectedValueChanged;
                // text box con ubicacion destino disponible
                tablePanel.Controls.Add(comboUbicacionDestino, 3, 1);

                // PanelConfirmacion
                Panel p = new Panel();
                p.Dock = DockStyle.Fill;

                // ACEPTAR MOVIMIENTO
                Button bOk = new Button();
                bOk.Text = "Aceptar";
                bOk.TextAlign = ContentAlignment.MiddleCenter;
                bOk.Anchor = AnchorStyles.None;
                bOk.Click += BOk_Click;

                tablePanel.Controls.Add(bOk, 4, 1);

                // ID Auxiliar
                Label lAux = new Label();
                lAux.Text = "IDG: " + g.Id.ToString();
                lAux.Visible = false;

                panel.Controls.Add(lAux);
                listPanels.Add(panel);

                panel.Controls.Add(tablePanel);
                panelLista.Controls.Add(panel);

                listMovimientoMercaderia.Add(currentMovimiento);

            }
        }
        private void CargarProductosFromCompra(List<Producto> listProductos)
        {
            if (listPanels == null)
            {
                listPanels = new List<Panel>();
            }

            foreach (Producto pr in listProductos)
            {
                currentMovimiento = new MovimientoMercaderia();
                currentMovimiento.confirmado = false;

                // HARDCODEADO MESA DE ENTRADA
                currentMovimiento.origen = TiposManager.Instance().GetUbicacionById(4);
                currentMovimiento.producto = pr;
                currentMovimiento.peso = pr.CantidadEntregada;

                Panel panel = new Panel();
                panel.Dock = DockStyle.Top;
                panel.Height = 100;
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Tag = "pendiente";

                TableLayoutPanel tablePanel = new TableLayoutPanel();
                tablePanel.AllowDrop = true;
                tablePanel.AutoSize = true;
                tablePanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                tablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                tablePanel.ColumnCount = 5;
                tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
                tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
                tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
                tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
                tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
                tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
                tablePanel.Location = new System.Drawing.Point(5, 5);
                tablePanel.Name = "tablePanel";
                tablePanel.RowCount = 2;
                tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

                tablePanel.Controls.Add(FuncionesGlobales.StyleLabel("Ubicacion Origen"), 0, 0);

                // label con ubicacion origen 
                Label lUbicacionOrigen = FuncionesGlobales.StyleLabel(currentMovimiento.origen.Descripcion);
                tablePanel.Controls.Add(lUbicacionOrigen, 0, 1);

                tablePanel.Controls.Add(FuncionesGlobales.StyleLabel("Producto a Mover"), 1, 0);

                // label con numero de garron 
                Label lProdcuto = FuncionesGlobales.StyleLabel("Descripcion: " + pr.DescripcionBreve);
                tablePanel.Controls.Add(lProdcuto, 1, 1);

                //label.Text = "Cantidad a mover";
                tablePanel.Controls.Add(FuncionesGlobales.StyleLabel("Cantidad a mover"), 2, 0);

                // text box con cantidad peso disponible
                Label lPesoProducto = FuncionesGlobales.StyleLabel(pr.CantidadEntregada + " kg.");
                tablePanel.Controls.Add(lPesoProducto, 2, 1);

                //label.Text = "Ubicacion Destino";
                tablePanel.Controls.Add(FuncionesGlobales.StyleLabel("Ubicacion Destino"), 3, 0);

                // Ubicaciones destino disponibles.
                listUbicacionDestino = FuncionesProductos.GetUbicacionDestino(currentMovimiento.origen.Id, listMovimientoMercaderia);
                comboUbicacionDestino = new ComboBox();
                comboUbicacionDestino.Anchor = AnchorStyles.None;
                comboUbicacionDestino.Dock = DockStyle.Fill;
                comboUbicacionDestino.Enabled = false;
                comboUbicacionDestino.SelectedValueChanged += ComboUbicacionDestino_SelectedValueChanged;
                // text box con ubicacion destino disponible
                tablePanel.Controls.Add(comboUbicacionDestino, 3, 1);

                // PanelConfirmacion
                Panel p = new Panel();
                p.Dock = DockStyle.Fill;

                // ACEPTAR MOVIMIENTO
                Button bOk = new Button();
                bOk.Text = "Aceptar";
                bOk.TextAlign = ContentAlignment.MiddleCenter;
                bOk.Anchor = AnchorStyles.None;
                bOk.Click += BOk_Click;

                tablePanel.Controls.Add(bOk, 4, 1);

                listPanels.Add(panel);

                // ID Auxiliar
                Label lAux = new Label();
                lAux.Text = "IDP: " + pr.Id.ToString();
                lAux.Visible = false;

                panel.Controls.Add(lAux);
                panel.Controls.Add(tablePanel);
                panelLista.Controls.Add(panel);

                listMovimientoMercaderia.Add(currentMovimiento);
            }
        }
        public void Limpiar()
        {
            if (listUbicacionDestino!=null)
                listUbicacionDestino.Clear();

            if (listUbicacionOrigen != null)
                listUbicacionOrigen.Clear();

            if (listPanels != null)
                listPanels.Clear();

            listUbicacionOrigen = null;
            listUbicacionDestino = null;
            listPanels = null;
            
            comboUbicacionOrigen = null;
            comboUbicacionDestino = null;
            comboProdUbicacion = null;
            textBoxPesoMover = null;
            pesoMax = decimal.Zero;
            currentPanel = null;
            currentModo = -1;
            currentMovimientoModo = -1;
        }
        public void Cargar()
        {
            Limpiar();

            listUbicacionOrigen = TiposManager.Instance().GetUbicacionList();

            panelLista.AutoScroll = false;
            panelLista.HorizontalScroll.Enabled = false;
            panelLista.HorizontalScroll.Visible = false;
            panelLista.HorizontalScroll.Maximum = 0;
            panelLista.AutoScroll = true;

            bConfirmar.Text = "Confirmar Movimientos - Cantidad (0)";

            ApplicationLookAndFeel.ApplyThemeToAll(this);
        }
        private void bMoverPro_Click(object sender, EventArgs e)
        {
            if (currentMovimiento == null)
                CargarControlesMovimiento(MODO_PRODUCTO);
            else
            {
                if (currentMovimiento.confirmado)
                {
                    CargarControlesMovimiento(MODO_PRODUCTO);
                    return;
                }
                FormMessageBox dialog = new FormMessageBox();
                dialog.ShowErrorDialog("Debe confirmar primero el Movimiento actual para crear uno nuevo.");
            }
        }
        private void bMoverGarron_Click(object sender, EventArgs e)
        {
            if (currentMovimiento == null)
                CargarControlesMovimiento(MODO_GARRON);
            else
            {
                if (currentMovimiento.confirmado)
                {
                    CargarControlesMovimiento(MODO_GARRON);
                    return;
                }
                FormMessageBox dialog = new FormMessageBox();
                dialog.ShowErrorDialog("Debe confirmar primero el Movimiento actual para crear uno nuevo.");
            }
        }
        private void CargarControlesMovimiento(int modo)
        {
            currentMovimientoModo = modo;
            currentMovimiento = new MovimientoMercaderia();
            currentMovimiento.confirmado = false;

            Panel panel = new Panel();
            panel.Dock = DockStyle.Top;
            panel.Height = 100;
            panel.BorderStyle = BorderStyle.FixedSingle;

            currentPanel = panel;

            TableLayoutPanel tablePanel = new TableLayoutPanel();
            tablePanel.AllowDrop = true;
            tablePanel.AutoSize = true;
            tablePanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tablePanel.ColumnCount = 5;

            tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));

            tablePanel.Controls.Add(FuncionesGlobales.StyleLabel("Ubicacion Origen"), 0, 0);

            // text con ubicacion origen disponible
            //label.Text = "MESA DE ENTRADA";
            comboUbicacionOrigen = new ComboBox();
            comboUbicacionOrigen.Anchor = AnchorStyles.None;
            comboUbicacionOrigen.Dock = DockStyle.Fill;

            bindOri = new BindingSource();
            bindOri.DataSource = listUbicacionOrigen;
            comboUbicacionOrigen.DataSource = bindOri.DataSource;
            comboUbicacionOrigen.DisplayMember = "descripcion";
            comboUbicacionOrigen.ValueMember = "id";
            comboUbicacionOrigen.SelectedValueChanged += ComboUbicacionOrigen_SelectedValueChanged;
            tablePanel.Controls.Add(comboUbicacionOrigen, 0, 1);

            //label.Text = "Producto a Mover";
            if (modo.Equals(MODO_PRODUCTO))
            {
                tablePanel.Controls.Add(FuncionesGlobales.StyleLabel("Producto a Mover"), 1, 0);
            }
            else
            {
                tablePanel.Controls.Add(FuncionesGlobales.StyleLabel("Garron a Mover"), 1, 0);
            }

            // text con productos/garrones disponibles
            comboProdUbicacion = new ComboBox();
            comboProdUbicacion.Enabled = false;
            comboProdUbicacion.Anchor = AnchorStyles.None;
            comboProdUbicacion.Dock = DockStyle.Fill;
            tablePanel.Controls.Add(comboProdUbicacion, 1, 1);

            //label.Text = "Cantidad a mover";
            tablePanel.Controls.Add(FuncionesGlobales.StyleLabel("Cantidad a mover"), 2, 0);

            // text box con cantidad peso disponible
            //label.Text = "10 kg.";
            textBoxPesoMover = new TextBox();
            textBoxPesoMover.Anchor = AnchorStyles.None;
            textBoxPesoMover.ReadOnly = true;
            textBoxPesoMover.Dock = DockStyle.Fill;
            tablePanel.Controls.Add(textBoxPesoMover, 2, 1);

            //label.Text = "Ubicacion Destino";
            tablePanel.Controls.Add(FuncionesGlobales.StyleLabel("Ubicacion Destino"), 3, 0);

            comboUbicacionDestino = new ComboBox();
            comboUbicacionDestino.Anchor = AnchorStyles.None;
            comboUbicacionDestino.Dock = DockStyle.Fill;
            comboUbicacionDestino.Enabled = false;
            // text box con ubicacion destino disponible
            tablePanel.Controls.Add(comboUbicacionDestino, 3, 1);

            // PanelConfirmacion
            Panel p = new Panel();
            p.Dock = DockStyle.Fill;

            // ACEPTAR MOVIMIENTO
            Button bOk = new Button();
            bOk.Text = "Aceptar";
            bOk.TextAlign = ContentAlignment.MiddleCenter;
            bOk.Anchor = AnchorStyles.None;
            bOk.Click += BOk_Click;

            // CANCELAR MOVIMIENTO
            Button bCancelar = new Button();
            bCancelar.Text = "Descartar";
            bCancelar.TextAlign = ContentAlignment.MiddleCenter;
            bCancelar.Anchor = AnchorStyles.None;
            bCancelar.Click += BCancelar_Click;

            ApplicationLookAndFeel.ApplyThemeToChild(panel);

            tablePanel.Controls.Add(bOk, 4, 0);
            tablePanel.Controls.Add(bCancelar, 4, 1);

            tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            tablePanel.Location = new System.Drawing.Point(5, 5);
            tablePanel.Name = "tablePanel";
            tablePanel.RowCount = 2;
            tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            panel.Controls.Add(tablePanel);
            panelLista.Controls.Add(panel);            
            
        }
        private void BCancelar_Click(object sender, EventArgs e)
        {
            currentPanel.Dispose();
            currentPanel = null;
        }
        private void BOk_Click(object sender, EventArgs e)
        {
            if (currentMovimiento.destino == null)
            {
                FormMessageBox dialog = new FormMessageBox();
                dialog.ShowErrorDialog("Debe seleccionar el destino del movimiento.");
                return;
            }
            
            
            if (currentModo.Equals(MODO_MOVERMERCADERIA))
            {
                // MODO MOVER MERCADERIA BOTON OK
                currentMovimiento.confirmado = true;
                currentMovimiento.fecha = DateTime.Now;

                if (comboUbicacionOrigen != null)
                {
                    string comboValue = currentMovimiento.origen.Descripcion;
                    comboUbicacionOrigen.DataSource = null;
                    comboUbicacionOrigen.Text = comboValue;
                }

                ConfirmarComboDestino(currentPanel);

                listMovimientoMercaderia.Add(currentMovimiento);

                currentPanel.BackColor = StyleManager.Instance().GetCurrentStyle().MouseDownBackColor;
                currentPanel.Enabled = false;
            }
            else
            {
                // MODO UBICAR POR COMPRA MERCADERIA BOTON OK
                // Obtener destino por panel
                foreach (Control c2 in currentPanel.Controls)
                {
                    TableLayoutPanel tlp = c2 as TableLayoutPanel;
                    if (tlp != null)
                    {
                        foreach (Control c3 in tlp.Controls)
                        {
                            ComboBox co = c3 as ComboBox;
                            if (co != null)
                            {
                                String text = ((Ubicacion)co.SelectedItem).Descripcion;
                                co.DataSource = null;
                                co.Text = text;
                            }
                        }
                    }
                }

                currentPanel.BackColor = StyleManager.Instance().GetCurrentStyle().MouseDownBackColor;
                currentPanel.Enabled = false;

                if (currentPanel.Tag.Equals("activo"))
                {
                    currentPanel.Tag = "confirmado";
                }

                foreach (Panel p in listPanels)
                {
                    if (p.Tag.Equals("pendiente"))
                    {
                        currentPanel = p;
                        currentPanel.Tag = "activo";
                        currentPanel.BackColor = StyleManager.Instance().GetCurrentStyle().BackColor;
                        currentPanel.Enabled = true;
                        ActivarComboDestino(currentPanel);
                        break; 
                    }
                }
            }
            
            bConfirmar.Text = "Confirmar Movimientos - Cantidad (" + listMovimientoMercaderia.Count + ")";
            
        }

        private void AgregarDestino()
        {

            foreach(Panel p in listPanels)
            {
                currentPanel = p;
                String index="";
                foreach (Control c in currentPanel.Controls)
                {
                    // sabemos que el unico control que nos interesa es el LABEL de donde guardamos id producto o garron
                    Label l = c as Label;
                    if (l != null)
                    {
                        index = l.Text;
                    }
                    TableLayoutPanel tlp = c as TableLayoutPanel;
                    if (tlp != null)
                    {
                        foreach (Control c3 in tlp.Controls)
                        {
                            ComboBox co = c3 as ComboBox;
                            if (co != null)
                            {
                                globalDestino = FuncionesProductos.GetUbicacionByName(co.Text);
                            }
                        }
                    }
                }
                if (index.Contains("IDG: "))
                {
                    index = index.Replace("IDG: ", "");
                    Garron g = FuncionesGarron.GetGarron(int.Parse(index));
                    foreach (MovimientoMercaderia mm in listMovimientoMercaderia)
                    {
                        if (mm.garron != null && mm.garron.Id.Equals(g.Id))
                        {
                            mm.destino = globalDestino;
                            break;
                        }
                    }
                }
                else if (index.Contains("IDP: "))
                {
                    index = index.Replace("IDP: ", "");
                    Producto pr = FuncionesProductos.GetProducto(int.Parse(index));
                    foreach (MovimientoMercaderia mm2 in listMovimientoMercaderia)
                    {
                        if (mm2.producto != null && mm2.producto.Id.Equals(pr.Id))
                        {
                            mm2.destino = globalDestino;
                            break;
                        }
                    }
                }
            } // foreach list panels

        }
        private void ConfirmarComboDestino(Panel currentPanel)
        {
            bool salir = false;
            foreach (Control c in currentPanel.Controls)
            {
                var myObject = c as TableLayoutPanel;

                if (myObject != null)
                {
                    TableLayoutPanel t = (TableLayoutPanel)c;
                    foreach (Control c2 in t.Controls)
                    {
                        if (salir)
                            break;

                        var myObject2 = c2 as ComboBox;
                        if (myObject2 != null)
                        {
                            ComboBox destino = (ComboBox)c2;
                            string comboValue2 = destino.Text;
                            destino.DataSource = null;
                            destino.Text = comboValue2;
                            salir = true;
                            break;
                        }
                        else
                            continue;

                    }
                }
                else
                    continue;
            }
        }
        private void ActivarComboDestino(Panel currentPanel)
        {
            foreach (Control c in currentPanel.Controls)
            {
                var myObject = c as TableLayoutPanel;

                if (myObject != null)
                {
                    TableLayoutPanel t = (TableLayoutPanel)c;
                    foreach (Control c2 in t.Controls)
                    {
                        var myObject2 = c2 as ComboBox;
                        if (myObject2 != null)
                        {
                            ComboBox destino = (ComboBox)c2;
                            destino.Enabled = true;
                            BindingSource binding = new BindingSource();
                            binding.DataSource = listUbicacionDestino;
                            destino.DataSource = binding.DataSource;
                            destino.DisplayMember = "descripcion";
                            destino.ValueMember = "id";
                        }
                        else
                            continue;

                    }
                }
                else
                    continue;
            }
        }
        private void ComboUbicacionOrigen_SelectedValueChanged(object sender, EventArgs e)
        {
            if (currentMovimiento != null && currentMovimiento.confirmado)
                return;

            FormMessageBox dialog = new FormMessageBox();
            currentMovimiento.origen = (Ubicacion)comboUbicacionOrigen.SelectedItem;

            List<Producto> listProdUbi = null;
            List<Garron> listGarronUbi = null;
            BindingSource binding = new BindingSource();

            if (currentMovimientoModo.Equals(MODO_PRODUCTO))
            {
                listProdUbi = FuncionesProductos.GetProductosByUbicacion(currentMovimiento.origen.Id);
                if (listProdUbi == null)
                {
                    dialog.ShowErrorDialog("No se encontraron productos para mover en ubicacion: " + currentMovimiento.origen.Descripcion);
                    return;
                }
                binding.DataSource = listProdUbi;
                comboProdUbicacion.DataSource = binding.DataSource;
                comboProdUbicacion.DisplayMember = "DescripcionBreve";
                
            }
            else
            {
                listGarronUbi = FuncionesGarron.GetGarronByUbicacion(currentMovimiento.origen.Id);
                if (listGarronUbi == null)
                {
                    dialog.ShowErrorDialog("No se encontraron garrones para mover en ubicacion: " + currentMovimiento.origen.Descripcion);
                    return;
                }
                binding.DataSource = listGarronUbi;
                comboProdUbicacion.DataSource = binding.DataSource;
                comboProdUbicacion.DisplayMember = "numero";
            }

            comboProdUbicacion.ValueMember = "id";
            comboProdUbicacion.Enabled = true;
            comboProdUbicacion.SelectedValueChanged += ComboProdUbicacion_SelectedValueChanged; 
        }
        private void ComboProdUbicacion_SelectedValueChanged(object sender, EventArgs e)
        {
            if (currentMovimientoModo.Equals(MODO_PRODUCTO))
            {
                // MODO PRODUCTO, PASAMOS EL PRODUCTO CON EL PESO QUE SE VA A MOOVER
                currentMovimiento.producto = (Producto)comboProdUbicacion.SelectedItem;
                ProcesarProductoUbicacion(textBoxPesoMover, currentMovimiento.producto, currentMovimiento.origen.Id);
            }else
            {
                // Modo garron, pasamos el garron sin el peso, por que se transfiere siempre completo.
                currentMovimiento.garron = (Garron)comboProdUbicacion.SelectedItem;
                ProcesarProductoUbicacion(textBoxPesoMover, null, currentMovimiento.origen.Id);
            }

        }
        private void ProcesarProductoUbicacion(TextBox textboxPeso, Producto producto, int origenSeleccionado)
        {
            if (currentMovimientoModo.Equals(MODO_PRODUCTO))
            {
                // MODO PRODUCTO
                pesoMax = FuncionesProductos.GetPesoMaxByProdByUbi(producto, origenSeleccionado);

                if (pesoMax.Equals(decimal.Zero))
                {
                    FormMessageBox dialog = new FormMessageBox();
                    dialog.ShowErrorDialog("Ocurrio un error, el peso no puede ser 0.");
                    return;
                }

                // Si ya utilizamos este producto en un movimiento anterior para la misma ubicacion, el peso max disponible cambia
                pesoMax = CheckProductoUbicacionUtilizado(pesoMax, producto, origenSeleccionado);

                textboxPeso.Text = "(CantidadMax: " + pesoMax.ToString() + ")";
                textboxPeso.ReadOnly = false;
                textboxPeso.Enter += TextBoxPesoMover_Enter;
                textboxPeso.KeyPress += textBoxDecimal_KeyPress;
                textboxPeso.Leave += TextBoxPesoMover_Leave;
            }else
            {
                // MODO GARRON
                textboxPeso.Text = currentMovimiento.garron.Peso.ToString();
                textboxPeso.ReadOnly = true;
                currentMovimiento.peso = currentMovimiento.garron.Peso;
                CargarUbicacionDestino();
                comboUbicacionDestino.Focus();
            }

        }
        private decimal CheckProductoUbicacionUtilizado(decimal pesoMax, Producto producto, int origenSeleccionado)
        {
            if (listMovimientoMercaderia.Count.Equals(0))
                return pesoMax;

            decimal pesoMaxNuevo = pesoMax;
            foreach(MovimientoMercaderia m in listMovimientoMercaderia)
            {
                if (m.producto.Id.Equals(producto.Id) && m.origen.Id.Equals(origenSeleccionado))
                {
                    pesoMaxNuevo -= m.peso;
                }
            }
            return pesoMaxNuevo;
        }
        private void TextBoxPesoMover_Enter(object sender, EventArgs e)
        {
            textBoxPesoMover.Text = "";
        }
        private void textBoxDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesGlobales.DecimalTextBox_KeyPress(sender, e);
        }
        private void TextBoxPesoMover_Leave(object sender, EventArgs e)
        {
            CargarUbicacionDestino();
            TextBox textBox = (TextBox)sender;

            if (currentMovimientoModo.Equals(MODO_PRODUCTO))
            {
                if (textBox.Text.Equals("") || textBox.Text.Equals("0"))
                {
                    FormMessageBox dialog = new FormMessageBox();
                    dialog.ShowErrorDialog("El peso ingresado no puede ser 0 o vacio.");
                    ProcesarProductoUbicacion(textBox, currentMovimiento.producto, currentMovimiento.origen.Id);
                    return;
                }
                if (textBoxPesoMover.Text.Contains("Cantidad"))
                {
                    textBox.Focus();
                    return;
                }
                decimal pesoAux = decimal.Parse(textBox.Text);
                if (pesoAux > pesoMax)
                {
                    MessageBox.Show("El peso ingresado es mayor al disponible. Maximo : " + pesoMax.ToString());
                    textBox.Focus();
                    return;
                }

                currentMovimiento.peso = pesoAux;
            }

        }
        private void CargarUbicacionDestino()
        {
            listUbicacionDestino = FuncionesProductos.GetUbicacionDestino(currentMovimiento.origen.Id, listMovimientoMercaderia);
            BindingSource bindingUbiDes = new BindingSource();
            bindingUbiDes.DataSource = listUbicacionDestino;
            comboUbicacionDestino.DataSource = bindingUbiDes.DataSource;
            comboUbicacionDestino.DisplayMember = "descripcion";
            comboUbicacionDestino.ValueMember = "id";
            comboUbicacionDestino.SelectedValueChanged += ComboUbicacionDestino_SelectedValueChanged;
            comboUbicacionDestino.Enabled = true;
        }
        private void ComboUbicacionDestino_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!currentMovimiento.confirmado)
            {
                ComboBox combo = (ComboBox)sender;
                currentMovimiento.destino = (Ubicacion)combo.SelectedItem;
            }
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void bConfirmar_Click(object sender, EventArgs e)
        {
            FormMessageBox dialog = new FormMessageBox();
            if (listMovimientoMercaderia.Count.Equals(0))
            {
                dialog.ShowErrorDialog("No se registro ningun movimiento, no se puede confirmar.");
                return;
            }

            if (dialog.ShowConfirmationDialog("¿Esta seguro que desea mover la mercaderia listada?"))
            {

                if (currentModo.Equals(MODO_UBICARMERCADERIACOMPRA))
                    AgregarDestino();

                if (FuncionesProductos.ConfirmarMovimientosTransaction(listMovimientoMercaderia))
                {
                    dialog.ShowErrorDialog("Se registraron los movimientos cargados con exito.");
                    bLimpiar_Click(null, null);
                }
                else
                {
                    dialog.ShowErrorDialog("Ocurrio un error, no se registro ningun movimiento. ");
                }
            }           
        }

        private void LimpiarMovimientos()
        {
            foreach  (Panel p in panelLista.Controls)
            {
                /*foreach(Control c in p.Controls)
                {
                    TableLayoutPanel tlp = c as TableLayoutPanel;
                    tlp.Controls.Clear();
                    tlp.RowStyles.Clear();
                    tlp.RowCount = 0;
                }*/
                
                p.Dispose();
            }

            panelLista.Controls.Clear();
            currentMovimiento = null;
            listMovimientoMercaderia.Clear();
        }
        private void bLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarMovimientos();
            Cargar();
        }
    }
}
