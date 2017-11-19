using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AppLaMejor.datamanager;
using AppLaMejor.controlmanager;
using AppLaMejor.entidades;
using AppLaMejor.stylemanager;

namespace AppLaMejor.formularios
{
    public partial class FormCargaGarron : Form
    {

        List<TipoGarron> listTipoGarron;
        TipoGarron selectedTipoGarron;
        List<Garron> listGarronCompleto;
        List<Garron> listGarronParcial;
        Garron selectedGarron;
        

        public FormCargaGarron()
        {
            InitializeComponent();
            Cargar();
            ApplicationLookAndFeel.ApplyThemeToAll(this);
        }

        void Cargar()
        {
            // Cargar TipoGarron (sino seleccionada nada, no se destraban los otros combos
            listTipoGarron = TiposManager.Instance().GetTipoGarronList();
            comboTipoGarron = FuncionesGarron.GetComboTipoGarron(comboTipoGarron, listTipoGarron);

            //int idGarron = 1;

            // Obtener lista de garrones del tipo seleccionado
            //List<Garron> listGarronTipo = FuncionesGarron.GetListGarronByEstadoAndTipo()


            
            ////List<int> listIdProducto = FuncionesGarron.GetIdProductoDeposteByGarron(idGarron);
            ////List<int> listIdProductoDepostado = FuncionesGarron.GetIdProductoDepostado(idGarron);

            ////listIdProducto.Clear();
            ////listIdProductoDepostado.Clear();

            ////listIdProducto = FuncionesGarron.GetIdProductoDeposteByGarron(idGarron);
            ////listIdProductoDepostado = FuncionesGarron.GetIdProductoDepostado(idGarron);

        }

        private void CargarComboBoxEstadoGarron()
        {
            // Cargar GarronCompleto
            listGarronCompleto = FuncionesGarron.GetListGarronByEstadoAndTipo("1", selectedTipoGarron.Id.ToString());
            if (listGarronCompleto.Count > 0)
            {
                comboGarronCompleto = FuncionesGarron.GetComboGarron(comboGarronCompleto, listGarronCompleto);
                comboGarronCompleto.Enabled = true;
            }
            else
            {
                listGarronCompleto.Clear();
                comboGarronCompleto.SelectedIndex = -1;
            }
            
            // Cargar GarronParcial
            listGarronParcial = FuncionesGarron.GetListGarronByEstadoAndTipo("2", selectedTipoGarron.Id.ToString());
            if (listGarronParcial.Count > 0)
            {
                comboGarronParcial = FuncionesGarron.GetComboGarron(comboGarronParcial, listGarronParcial);
                comboGarronParcial.Enabled = true;
            }
            else
            {
                listGarronParcial.Clear();
                comboGarronParcial.SelectedIndex = -1;
            }
                
        }

        private void AnularComboBoxEstadoGarron()
        {
            comboGarronCompleto.Enabled = false;
            comboGarronCompleto.DataSource = null;
            comboGarronParcial.Enabled = false;
            comboGarronParcial.DataSource = null;
        }

        private void comboTipoGarron_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!((ComboBox)sender).SelectedIndex.Equals(-1))
            {
                selectedTipoGarron = FuncionesGarron.GetTipoGarronClicked(sender, e);
                if (selectedTipoGarron!=null)
                    CargarComboBoxEstadoGarron();
            }
            else
            {
                AnularComboBoxEstadoGarron();
            }
        }

        private void comboGarronCompleto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!((ComboBox)sender).SelectedIndex.Equals(-1))
            {
                selectedGarron = FuncionesGarron.GetGarronClicked(sender, e);
            }
        }

        private void comboGarronParcial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!((ComboBox)sender).SelectedIndex.Equals(-1))
            {
                selectedGarron = FuncionesGarron.GetGarronClicked(sender, e);
            }
        }

        private void bAgregarGarron_Click(object sender, EventArgs e)
        {
            AgregarGarron();
        }

        private void AgregarGarron()
        {
            //Garron g = new Garron();
            //g.FechaEntrada = DateTime.Now;
            //FormEntityInput dialog = new FormEntityInput(g, FormEntityInput.MODO_INSERTAR);
            //Boolean result = dialog.Execute(g);

            //if (result)
            //{
            //    g = (Garron)dialog.SelectedObject;
            //    // Desde este form solo se carga garron estado COMPLETO = 1
            //    g.TipoEstadoGarron = TiposManager.Instance().GetTipoEstadoGarron(1);
            //    /* Insert en BD */
            //    if (FuncionesGarron.InsertGarron(g))
            //    {
            //        MyTextTimer.TStart("Cuenta se guardo correctamente", statusStrip1, tsslMensaje);
            //        CargarGarronCompletoEnTablePanel(g);
            //    }
            //    else
            //    {
            //        MyTextTimer.TStart("No se guardo cuenta.", statusStrip1, tsslMensaje);
            //    }

            //}

            // TODO: borrar hardcodeada carga garron
            Garron g = FuncionesGarron.GetGarron(5);
            CargarGarronCompletoEnTablePanel(g);
        }

        private void CargarGarronCompletoEnTablePanel(Garron g)
        {
            List<GarronParte> listPartes = FuncionesGarron.GetIdProductoDeposteByGarron(g.Id);

            int rowIndex = 0;
            int columnIndex = 0;
            int controlAddedCount = 0;

            this.tablePanel.Dock = DockStyle.Fill;

            this.tablePanel.RowStyles.Clear();
            this.tablePanel.ColumnStyles.Clear();

            this.tablePanel.ColumnCount = 5;
            float percentValue = 100 / this.tablePanel.ColumnCount;
            for (int i = 0; i < tablePanel.ColumnCount; i++)
            {
                this.tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percentValue));
            }

            this.tablePanel.RowCount = 1;
            this.tablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));

            foreach (GarronParte gp in listPartes)
            {
                gp.Garron = g;

                Random rnd = new Random();
                Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                Panel panel = new Panel();
                panel.BackColor = randomColor;
                panel.Name = gp.Garron.Id.ToString() +"-"+ gp.Producto.Id.ToString();
                panel.Dock = DockStyle.Fill;

                Label productoTitulo = new Label();
                productoTitulo.Name = panel.Name + "titulo";
                productoTitulo.Text = "Ingrese Peso de " + gp.Producto.DescripcionBreve.ToUpper();
                productoTitulo.AutoSize = true;
                productoTitulo.Anchor = AnchorStyles.None;
                productoTitulo.Dock = DockStyle.Top;
                
                /*productoTitulo.Location = new Point(panel.Width / 2 - productoTitulo.Size.Width / 2, panel.Height / 2 - productoTitulo.Size.Height / 2 - 20);
                productoTitulo.Anchor = AnchorStyles.None;*/

                TextBox productoPeso = new TextBox();
                productoPeso.Name = panel.Name + "peso";
                
                productoPeso.MaximumSize = new Size(100,40);
                productoPeso.MinimumSize = new Size(100,30);
                productoPeso.Leave += leavePesoBox;

                productoPeso.Location = new Point(panel.Width / 2 - productoPeso.Size.Width / 2, panel.Height / 2 - productoPeso.Size.Height / 2);
                productoPeso.Anchor = AnchorStyles.None;

                panel.Controls.Add(productoTitulo);
                panel.Controls.Add(productoPeso);

                tablePanel.Controls.Add(panel); //, columnIndex, rowIndex);
                controlAddedCount++;

                // int div = a / b; //div is 1
                //int mod = a % b; //mod is 2
                int mod = controlAddedCount % tablePanel.ColumnCount;

                if (mod.Equals(0))
                {
                    this.tablePanel.RowCount ++;
                    this.tablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
                }
            }
        }

        private void leavePesoBox(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            decimal test;
            if (!decimal.TryParse(textbox.Text, out test))
            {
                MyTextTimer.TStart("El peso ingresado es incorrecto. ", this.statusStrip1, this.tsslMensaje);
            }
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
