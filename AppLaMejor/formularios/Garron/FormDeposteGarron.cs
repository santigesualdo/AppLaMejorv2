
using AppLaMejor.entidades;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using AppLaMejor.datamanager;
using AppLaMejor.controlmanager;
using System.Data;
using AppLaMejor.formularios.Util;
using System.Drawing;
using AppLaMejor.stylemanager;
using AppLaMejor.formularios.Caja;
using System.Linq;

namespace AppLaMejor.formularios
{
    public partial class FormDeposteGarron : Form
    {
        public static int MODO_GARRONCOMPLETO = 0;
        public static int MODO_GARRONDEPOSTADO = 1;
        int currentModo;

        Garron garronDeposte;
        bool currentDeposteConfirmado;
        decimal pesoMax;
        decimal pesoAcumulado;

        List<GarronDeposte> listDeposte;

        List<Ubicacion> listUbicacionDestino;
        BindingSource bindingDes;
        List<Producto> listProductosDeposte;
        BindingSource bindingPro;

        Ubicacion origenGarron;

        TextBox textBoxPesoMover;
        TextBox textBoxPrecio;

        Panel currentPanel;

        ComboBox comboProductoDeposte;
        ComboBox comboUbicacionDestino;

        public FormDeposteGarron(int modo, Garron g, string garronData)
        {
            if (g == null || garronData == null)
            {
                Close();
            }

            InitializeComponent();

            lGarronData.Text = garronData;
            garronDeposte = g;

            currentModo = modo;

            ApplicationLookAndFeel.ApplyThemeToAll(this);

            Cargar();

            //1. Click en boton nuevo deposte
            //2. Se muestra fila de nuevo deposte
            //3. Contiene: tipo producto a depostar, peso, destino
            // DOS MODOS : GARRON COMPLETO Y GARRON DEPOSTADO

        }

        private void Cargar()
        {
            LoadLists();

            pesoMax = garronDeposte.Peso;
            pesoAcumulado = 0;
            currentDeposteConfirmado = true;

            if (currentModo.Equals(MODO_GARRONDEPOSTADO))
            {   
                // Cargar las partes ya depostadas.
                List<GarronDeposte> listDepostado = FuncionesGarron.GetDeposteAnterior(garronDeposte.Id);
                foreach( GarronDeposte gd in listDepostado)
                {
                    CargarControlDepostado(gd);
                    gd.yaDepostado = true;
                    if (listDeposte == null)
                        listDeposte = new List<GarronDeposte>();

                    listDeposte.Add(gd);
                }
            }
        }

        private void CargarControlDepostado(GarronDeposte gd)
        {
            Panel panel = new Panel();
            panel.Dock = DockStyle.Top;
            panel.Height = 100;
            panel.BorderStyle = BorderStyle.FixedSingle;

            TableLayoutPanel tablePanel = new TableLayoutPanel();
            tablePanel.AllowDrop = true;
            tablePanel.AutoSize = true;
            tablePanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tablePanel.ColumnCount = 4;

            tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));

            tablePanel.Controls.Add(FuncionesGlobales.StyleLabel("Producto Deposte"), 0, 0);
            tablePanel.Controls.Add(FuncionesGlobales.StyleLabel(gd.Producto.DescripcionBreve), 0, 1);

            tablePanel.Controls.Add(FuncionesGlobales.StyleLabel("Peso Producto"), 1, 0);
            tablePanel.Controls.Add(FuncionesGlobales.StyleLabel(gd.Peso.ToString()), 1, 1);

            tablePanel.Controls.Add(FuncionesGlobales.StyleLabel("Fecha Deposte"), 2, 0);
            tablePanel.Controls.Add(FuncionesGlobales.StyleLabel(gd.Fecha.ToString(VariablesGlobales.dateTimeFormat)), 2, 1);

            Panel p = new Panel();
            p.Dock = DockStyle.Fill;

            tablePanel.Controls.Add(p, 3, 0);
            tablePanel.Controls.Add(p, 3, 1);

            tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            tablePanel.Location = new System.Drawing.Point(5, 5);
            tablePanel.Name = "tablePanel";
            tablePanel.RowCount = 2;
            tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            ApplicationLookAndFeel.ApplyThemeToChild(panel);

            panel.BackColor = StyleManager.Instance().GetCurrentStyle().MouseDownBackColor;
            panel.Enabled = false;

            panel.Controls.Add(tablePanel);
            panelLista.Controls.Add(panel);
        }

        private void bAgregarDeposte_Click(object sender, EventArgs e)
        {
            if (currentDeposteConfirmado)
                CargarControlesDeposte();
        }

        private void CargarControlesDeposte()
        {
            if (listDeposte== null)
            {
                listDeposte = new List<GarronDeposte>();
            }

            Panel panel = new Panel();
            panel.Dock = DockStyle.Top;
            panel.Height = 100;
            panel.BorderStyle = BorderStyle.FixedSingle;

            currentPanel = panel;

            currentDeposteConfirmado = false;

            TableLayoutPanel tablePanel = new TableLayoutPanel();
            tablePanel.AllowDrop = true;
            tablePanel.AutoSize = true;
            tablePanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tablePanel.ColumnCount = 5;

            tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));

            tablePanel.Controls.Add(FuncionesGlobales.StyleLabel("Producto Deposte"), 0, 0);
            comboProductoDeposte= new ComboBox();
            comboProductoDeposte.Anchor = AnchorStyles.None;
            comboProductoDeposte.Dock = DockStyle.Fill;

            bindingPro = new BindingSource();
            bindingPro.DataSource = listProductosDeposte;
            comboProductoDeposte.DataSource = bindingPro.DataSource;
            comboProductoDeposte.DisplayMember = "DescripcionBreve";
            comboProductoDeposte.ValueMember = "id";
            comboProductoDeposte.SelectedIndex = -1;
            comboProductoDeposte.SelectionChangeCommitted += ComboProductoDeposte_SelectionChangeCommitted;
            tablePanel.Controls.Add(comboProductoDeposte, 0, 1);

            tablePanel.Controls.Add(FuncionesGlobales.StyleLabel("Peso Producto"), 1, 0);
            textBoxPesoMover = new TextBox();
            textBoxPesoMover.Anchor = AnchorStyles.None;
            textBoxPesoMover.KeyPress += FuncionesGlobales.DecimalTextBox_KeyPress;
            textBoxPesoMover.KeyDown += FuncionesGlobales.TextBoxLeaveOnEnter_KeyDown;
            textBoxPesoMover.Dock = DockStyle.Fill;
            tablePanel.Controls.Add(textBoxPesoMover, 1, 1);

            //label.Text = "Ubicacion Destino";
            tablePanel.Controls.Add(FuncionesGlobales.StyleLabel("Ubicacion Destino"), 2, 0);
            bindingDes = new BindingSource();
            bindingDes.DataSource = listUbicacionDestino;
            comboUbicacionDestino = new ComboBox();
            comboUbicacionDestino.DataSource = bindingDes.DataSource;
            comboUbicacionDestino.DisplayMember = "Descripcion";
            comboUbicacionDestino.ValueMember = "Id";
            comboUbicacionDestino.Anchor = AnchorStyles.None;
            comboUbicacionDestino.Dock = DockStyle.Fill;
            comboUbicacionDestino.SelectedValueChanged += ComboUbicacionDeposte_SelectedValueChanged;
            comboUbicacionDestino.SelectedIndex = -1;
            
            // text box con ubicacion destino disponible
            tablePanel.Controls.Add(comboUbicacionDestino, 2, 1);

            tablePanel.Controls.Add(FuncionesGlobales.StyleLabel("Precio Venta"), 3, 0);
            textBoxPrecio = new TextBox();
            textBoxPrecio.Anchor = AnchorStyles.None;
            textBoxPrecio.KeyPress += FuncionesGlobales.DecimalTextBox_KeyPress;
            textBoxPrecio.Dock = DockStyle.Fill;
            tablePanel.Controls.Add(textBoxPrecio, 3, 1);

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

            tablePanel.Controls.Add(bOk, 4, 0);
            tablePanel.Controls.Add(bCancelar, 4, 1);

            tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            tablePanel.Location = new System.Drawing.Point(5, 5);
            tablePanel.Name = "tablePanel";
            tablePanel.RowCount = 2;
            tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            ApplicationLookAndFeel.ApplyThemeToChild(panel);

            panel.Controls.Add(tablePanel);
            panelLista.Controls.Add(panel);

        }

        private void ComboProductoDeposte_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBoxPesoMover.Focus();
        }
        private void ComboUbicacionDeposte_SelectedValueChanged(object sender, EventArgs e)
        {
            textBoxPrecio.Focus();
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            FormMessageBox dialog = new FormMessageBox();
            if (dialog.ShowConfirmationDialog("¿Seguro desea descartar el deposte actual?")) 
            {
                currentPanel.Dispose();
            }
        }

        private void BOk_Click(object sender, EventArgs e)
        {
            // Validaciones
            FormMessageBox dialog = new FormMessageBox();
            decimal peso;
            decimal.TryParse(textBoxPesoMover.Text, out peso);

            if (peso.ToString().Equals("0") || peso.ToString().Equals(""))
            {
                dialog.ShowErrorDialog("El peso del deposte no puede ser 0 o vacio.");
                return;
            }

            decimal precioOpcional;
            if (!decimal.TryParse(textBoxPrecio.Text, out precioOpcional))
            {
                dialog.ShowErrorDialog("Debe indicar un precio para el producto depostado.");
                return;
            }

            if (pesoAcumulado + peso > garronDeposte.Peso)
            {
                dialog.ShowErrorDialog("No se puede generar un producto con peso mayor al garron origen. Peso maximo: " + garronDeposte.Peso);
                return;
            }
            
            if (comboProductoDeposte.SelectedIndex.Equals(-1))
            {
                dialog.ShowErrorDialog("Debe seleccionar un producto.");
                return;
            }   

            if (comboUbicacionDestino.SelectedIndex.Equals(-1))
            {
                dialog.ShowErrorDialog("Debe seleccionar un destino para el producto depostado.");
                return;
            }

            pesoAcumulado += peso;

            GarronDeposte gd = new GarronDeposte();

            gd.Fecha = DateTime.Now;
            gd.Garron = garronDeposte;
            gd.Peso = peso;
            gd.Precio = precioOpcional;
            gd.Producto = (Producto)comboProductoDeposte.SelectedItem;
            gd.Destino = (Ubicacion)comboUbicacionDestino.SelectedItem;
            listDeposte.Add(gd);

            ConfirmarCombos(currentPanel);

            currentDeposteConfirmado = true;

            currentPanel.BackColor = StyleManager.Instance().GetCurrentStyle().MouseDownBackColor;
            currentPanel.Enabled = false;

            int count = listDeposte.Where(o => o.yaDepostado.Equals(false)).ToList().Count;

            bConfirmar.Text = "Confirmar Deposte (Cantidad: " +count + ")";
        }

        private void ConfirmarCombos(Panel currentPanel)
        {
            // Quitar datasource de combo producto y combo destino

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
                            ComboBox combo = (ComboBox)c2;
                            Ubicacion u = combo.SelectedItem as Ubicacion;
                            if (u != null)
                            {
                                string comboValue2 = combo.Text;
                                combo.DataSource = null;
                                combo.Text = comboValue2;
                            }

                            Producto p = combo.SelectedItem as Producto;
                            if (p != null)
                            {
                                string comboValue3 = combo.Text;
                                combo.DataSource = null;
                                combo.Text = comboValue3;
                            }
                        }
                        else
                            continue;
                    }
                }
                else
                    continue;
            }
        }

        private void LoadLists()
        {
            origenGarron = FuncionesGarron.GetUbicacionByGarron(garronDeposte);
            listUbicacionDestino = TiposManager.Instance().GetUbicacionList();
            listProductosDeposte = FuncionesProductos.GetProductosDeposte();
        }

        private void bConfirmar_Click(object sender, EventArgs e)
        {
            ConfirmarDepostes();
        }

        private void ConfirmarDepostes()
        {
            if (listDeposte != null && listDeposte.Count > 0)
            {
                FormMessageBox dialog = new FormMessageBox();
                if (dialog.ShowConfirmationDialog("¿Esta seguro que desea confirmar los depostes seleccionados?"))
                {
                    if (FuncionesGarron.ConfirmarDeposte(listDeposte, garronDeposte, origenGarron))
                    {
                        dialog.ShowErrorDialog("Depostes de garron registrados exitosamente.");
                        if (dialog.ShowConfirmationDialog("¿Desea incluir el deposte en una nueva venta mayorista?"))
                        {
                            FormCajaMayorista cajaMayorista = new FormCajaMayorista(listDeposte);
                            cajaMayorista.ShowDialog();
                        }

                        this.Close();
                    }
                }
            }            
        }
    }
}
