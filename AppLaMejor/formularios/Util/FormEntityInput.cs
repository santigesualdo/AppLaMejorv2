using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using AppLaMejor.entidades;
using AppLaMejor.datamanager;
using AppLaMejor.stylemanager;

namespace AppLaMejor.formularios.Util
{
    public partial class FormEntityInput : Form
    {

        public const int MODO_EDITAR = 0;
        public const int MODO_INSERTAR = 1;
        public const int MODO_VER = 2;

        int currentModo;
        
        public FormEntityInput(Object reflection, int modo)
        {
            currentModo = modo;
            _reflection = reflection;
            InitializeComponent();
            ApplicationLookAndFeel.ApplyThemeToAll(this);
        }
        public FormEntityInput(Object reflection, int modo, string titulo)
        {
            cambiosRealizados = false;
            currentModo = modo;
            _reflection = reflection;
            InitializeComponent();
            SetTitulo(titulo);
            MyTextTimer.TStartFade("Complete todos los campos.", this.statusStripFormEntityInput, this.mensajeroFormEntityInput, MyTextTimer.TIME_FOREVER);
            ApplicationLookAndFeel.ApplyThemeToAll(this);
        }
        private Boolean isBrowsable(PropertyInfo info)
        {
            return info.GetCustomAttributes(typeof(BrowsableAttribute), false).Length>-1;
        }

        private Object _reflection;
        private TableLayoutPanel controlsTableLayoutPanel =  new TableLayoutPanel{Dock=DockStyle.Fill, CellBorderStyle = TableLayoutPanelCellBorderStyle.None};
        private int Id;

        private bool cambiosRealizados;

        List<TipoCliente> listTipoClientes;
        List<TipoProducto> listTipoProductos;
        List<TipoGarron> listTipoGarron;
        List<TipoEstadoGarron> listTipoEstadoGarron;
        List<Banco> listBanco;

        bool first;

        public Object SelectedObject
        {
            get
            {
                return _reflection;
            }
            set
            {
                try
                {
                    //clear all controls from the table
                    controlsTableLayoutPanel.Controls.Clear();

                    controlsTableLayoutPanel.ColumnCount = 2;
                    controlsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
                    controlsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));

                    first = true;

                    foreach (var property in _reflection.GetType().GetProperties())
                    {
                        if (property.Name.Equals("FechaBaja") ||
                            property.Name.Equals("idUsuario") ||
                            property.Name.Equals("Id"))
                            continue;

                        if (isBrowsable(property))
                        {
                            if (property.PropertyType == typeof(int))
	                            TypeInt(property);
                            else
                            if (property.PropertyType == typeof(string))
	                            TypeString(property);
                            else
                            if (property.PropertyType == typeof(Nullable<DateTime>))
	                            TypeNullableDateTime(property);
                            else
                            if (property.PropertyType == typeof(DateTime))
	                            TypeDateTime(property);
                            else
                            if (property.PropertyType == typeof(double))
	                            TypeDouble(property);
                            else
                            if (property.PropertyType == typeof(decimal))
	                            TypeDecimal(property);
                            else
                            if (property.PropertyType == typeof(TipoCliente))
	                            TypeTipoCliente(property);
                            else
                            if (property.PropertyType == typeof(TipoProducto))
	                            TypeTipoProducto(property);                           
                            else
                            if (property.PropertyType == typeof(TipoGarron))
	                            TypeTipoGarron(property);
                            else
                            if (property.PropertyType == typeof(TipoEstadoGarron))
	                            TypeTipoEstadoGarron(property);
                            if (property.PropertyType == typeof(Banco))
                                TypeBanco(property);
                        }
                    }

                    // 
                    var emptyPanel = new Panel { AutoSize = true };
                    emptyPanel.BorderStyle = BorderStyle.FixedSingle;
                    controlsTableLayoutPanel.Controls.Add(emptyPanel, 0, controlsTableLayoutPanel.RowCount += 1);
                    controlsTableLayoutPanel.Controls.Add(emptyPanel, 1, controlsTableLayoutPanel.RowCount);

                    controlsPanel.Controls.Add(controlsTableLayoutPanel);
                    controlsTableLayoutPanel.BringToFront();

                    if (!controlsPanel.Controls.Contains(controlsTableLayoutPanel))
                        Controls.Add(controlsTableLayoutPanel);
             
                }catch (Exception e){
					FormMessageBox dialog = new FormMessageBox();
					dialog.ShowErrorDialog("Error : "+ e.Message);
                }
            }
        }

        public Boolean Execute(Object reflection, int entityId)
        {
            Id = entityId;
            _reflection = reflection;
            SelectedObject = _reflection;
            return ShowDialog() == DialogResult.OK;
        }
        public Boolean Execute(Object reflection)
        {
            try
            {
                _reflection = reflection;
                SelectedObject = _reflection;
                return ShowDialog() == DialogResult.OK;
            }
            catch(Exception e)
            {
                return ShowDialog() == DialogResult.Cancel;
            }
        }

        // Definicion de Controles para cada TIPO
        private void TypeInt(PropertyInfo property)
        {
            TextBox textField = TextBoxCampoInt(property.Name);
            controlsTableLayoutPanel.Controls.Add(GetCampoTitulo(property.Name), 0, controlsTableLayoutPanel.RowCount+=1);
            controlsTableLayoutPanel.Controls.Add(textField, 1, controlsTableLayoutPanel.RowCount );
        }
        private void TypeString(PropertyInfo property)
        {
            TextBox textField = TextBoxCampoString(property.Name);
            controlsTableLayoutPanel.Controls.Add(GetCampoTitulo(property.Name), 0, controlsTableLayoutPanel.RowCount+=1);
            controlsTableLayoutPanel.Controls.Add(textField, 1, controlsTableLayoutPanel.RowCount);
        }
        private void TypeNullableDateTime(PropertyInfo property)
        {
            controlsTableLayoutPanel.Controls.Add(GetCampoTitulo(property.Name), 0, controlsTableLayoutPanel.RowCount += 1);

            Binding binding = new Binding("Text", _reflection, property.Name);
            var textBox = new TextBox { Dock = DockStyle.Fill, AutoSize = true };
            textBox.DataBindings.Add(binding);

            if (!textBox.Text.Equals(""))
            {
                Binding dateBinding = new Binding("Value", _reflection, property.Name);
                DateTimePicker dtp = new DateTimePicker { Dock = DockStyle.Fill, AutoSize = true };
                dtp.DataBindings.Add(dateBinding);
                controlsTableLayoutPanel.Controls.Add(dtp, 1, controlsTableLayoutPanel.RowCount );
            }
            else
            {
                DateTimePicker dtp = new DateTimePicker { Dock = DockStyle.Fill, AutoSize = true };
                Binding dateBinding = new Binding("Value", _reflection, property.Name);
                dtp.DataBindings.Add(dateBinding);
                controlsTableLayoutPanel.Controls.Add(dtp, 1, controlsTableLayoutPanel.RowCount );
            }
        }
        private void TypeDecimal(PropertyInfo property)
        {
            // decimal
            var textField = TextBoxCampoDecimal(property.Name);
            controlsTableLayoutPanel.Controls.Add(GetCampoTitulo(property.Name), 0, controlsTableLayoutPanel.RowCount += 1);
            controlsTableLayoutPanel.Controls.Add(textField, 1, controlsTableLayoutPanel.RowCount );
            
        }
        private void TypeDouble(PropertyInfo property)
        {
            var textField = TextBoxCampoInt(property.Name);
            // Double
            if (currentModo.Equals(MODO_VER))
            {
                textField.ReadOnly = true;
            }
            controlsTableLayoutPanel.Controls.Add(GetCampoTitulo(property.Name), 0, controlsTableLayoutPanel.RowCount += 1);
            controlsTableLayoutPanel.Controls.Add(textField, 1, controlsTableLayoutPanel.RowCount );
            
        }
        private void TypeDateTime(PropertyInfo property)
        {
            Binding binding;
            DateTimePicker dtp;
            binding = new Binding("Value", _reflection, property.Name);
            dtp = new DateTimePicker { Dock = DockStyle.Fill, AutoSize = true };
            dtp.DataBindings.Add(binding);

            controlsTableLayoutPanel.Controls.Add(GetCampoTitulo(property.Name), 0, controlsTableLayoutPanel.RowCount += 1);
            controlsTableLayoutPanel.Controls.Add(dtp, 1, controlsTableLayoutPanel.RowCount);
        }
        private void TypeTipoCliente(PropertyInfo property)
        {
            ComboBox combo = new ComboBox { Dock = DockStyle.Fill, AutoSize = true };
            TipoCliente currentTipoCliente;
            BindingList<TipoCliente> objects;

            controlsTableLayoutPanel.Controls.Add(GetCampoTitulo(property.Name), 0, controlsTableLayoutPanel.RowCount+=1);

            switch (currentModo)
            {
                case MODO_VER:
                    TextBox textField = new TextBox { Dock = DockStyle.Fill, AutoSize = true };
                    textField.Text = TiposManager.Instance().GetTipoClienteByIdCliente(Id).Descripcion;
                    controlsTableLayoutPanel.Controls.Add(textField, 1, controlsTableLayoutPanel.RowCount );
                    textField.ReadOnly = true;
                    break;
                case MODO_INSERTAR:
                    TipoCliente tcvacio = new TipoCliente();
                    tcvacio.Id = 0;
                    tcvacio.Descripcion = "";
                    List<TipoCliente> listTipoClientes = TiposManager.Instance().GetTipoClienteList();
                    listTipoClientes.Add(tcvacio);
                    listTipoClientes = listTipoClientes.OrderBy(x => x.Id).ToList();
                    objects = new BindingList<TipoCliente>(listTipoClientes);
                    combo.SelectedIndexChanged += tipoClienteComboClicked;
                    combo.Leave += comboRequiredLeave;
                    combo.ValueMember = null;
                    combo.DisplayMember = "Descripcion";
                    combo.DataSource = objects;
                    combo.SelectedIndex = -1;
                    controlsTableLayoutPanel.Controls.Add(combo, 1, controlsTableLayoutPanel.RowCount);
                    break;
                case MODO_EDITAR:
                    currentTipoCliente = TiposManager.Instance().GetTipoClienteByIdCliente(Id);
                    listTipoClientes = TiposManager.Instance().GetTipoClienteList().OrderBy(x => x.Descripcion != currentTipoCliente.Descripcion).ToList();
                    objects = new BindingList<TipoCliente>(listTipoClientes);
                    combo.SelectedIndexChanged += tipoClienteComboClicked;
                    combo.ValueMember = null;
                    combo.DisplayMember = "Descripcion";
                    combo.DataSource = objects;
                    controlsTableLayoutPanel.Controls.Add(combo, 1, controlsTableLayoutPanel.RowCount );
                    break;
            }
        }
        private void TypeTipoGarron(PropertyInfo property)
        {
            ComboBox combo = new ComboBox { Dock = DockStyle.Fill, AutoSize = true };
            TipoGarron currentTipoGarron;
            BindingList<TipoGarron> objects;
            switch (currentModo)
            {
                case MODO_VER:
                    currentTipoGarron = TiposManager.Instance().GetTipoGarronById(Id);
                    combo.Enabled = false;
                    combo.ValueMember = null;
                    combo.DisplayMember = "Descripcion";
                    combo.DataSource = currentTipoGarron.Descripcion;
                    break;
                case MODO_INSERTAR:
                    TipoGarron tgvacio = new TipoGarron();
                    tgvacio.Id = 0;
                    tgvacio.Descripcion = "";
                    combo.SelectedIndexChanged += tipoGarronComboClicked;//tipoClienteComboClicked;
                    combo.Leave += comboRequiredLeave;
                    listTipoGarron = TiposManager.Instance().GetTipoGarronList();
                    listTipoGarron.Add(tgvacio);
                    listTipoGarron = listTipoGarron.OrderBy(x => x.Id).ToList();
                    objects = new BindingList<TipoGarron>(listTipoGarron);
                    combo.DisplayMember = "Descripcion";
                    combo.ValueMember = null;
                    combo.DataSource = objects;
                    combo.SelectedIndex = -1;
                    break;
                case MODO_EDITAR:
                    currentTipoGarron = TiposManager.Instance().GetTipoGarronByIdGarron(Id);
                    listTipoGarron = TiposManager.Instance().GetTipoGarronList().OrderBy(x => x.Descripcion != currentTipoGarron.Descripcion).ToList();
                    objects = new BindingList<TipoGarron>(listTipoGarron);
                    combo.SelectedIndexChanged += tipoGarronComboClicked;
                    combo.ValueMember = null;
                    combo.DisplayMember = "Descripcion";
                    combo.DataSource = objects;
                    break;
            }

            controlsTableLayoutPanel.Controls.Add(GetCampoTitulo(property.Name), 0, controlsTableLayoutPanel.RowCount+=1);
            controlsTableLayoutPanel.Controls.Add(combo, 1, controlsTableLayoutPanel.RowCount );
            
        }    
        private void TypeTipoEstadoGarron(PropertyInfo property)
        {
            ComboBox combo = new ComboBox { Dock = DockStyle.Fill, AutoSize = true };
            TipoEstadoGarron currentTipoEstadoGarron;
            BindingList<TipoEstadoGarron> objects;
            switch (currentModo)
            {
                case MODO_VER:
                    currentTipoEstadoGarron = TiposManager.Instance().GetTipoEstadoGarronByIdGarron(Id);
                    combo.Enabled = false;
                    combo.ValueMember = null;
                    combo.DisplayMember = "Descripcion";
                    combo.DataSource = currentTipoEstadoGarron.Descripcion;
                    break;
                case MODO_INSERTAR:
                    TipoEstadoGarron tgvacio = new TipoEstadoGarron();
                    tgvacio.Id = 0;
                    tgvacio.Descripcion = "";
                    combo.Leave += comboRequiredLeave;
                    combo.SelectedIndexChanged += tipoGarronEstadoComboClicked;
                    listTipoEstadoGarron = TiposManager.Instance().GetTipoEstadoGarronList();
                    listTipoEstadoGarron.Add(tgvacio);
                    listTipoEstadoGarron = listTipoEstadoGarron.OrderBy(x => x.Id).ToList();
                    objects = new BindingList<TipoEstadoGarron>(listTipoEstadoGarron);
                    combo.ValueMember = null;
                    combo.DisplayMember = "Descripcion";
                    combo.DataSource = objects;
                    combo.SelectedIndex = -1;
                    break;
                case MODO_EDITAR:
                    currentTipoEstadoGarron = TiposManager.Instance().GetTipoEstadoGarronByIdGarron(Id);
                    listTipoEstadoGarron = TiposManager.Instance().GetTipoEstadoGarronList().OrderBy(x => x.Descripcion != currentTipoEstadoGarron.Descripcion).ToList();
                    objects = new BindingList<TipoEstadoGarron>(listTipoEstadoGarron);
                    combo.SelectedIndexChanged += tipoGarronEstadoComboClicked;
                    combo.ValueMember = null;
                    combo.DisplayMember = "Descripcion";
                    combo.DataSource = objects;
                    break;
            }

            controlsTableLayoutPanel.Controls.Add(GetCampoTitulo(property.Name), 0, controlsTableLayoutPanel.RowCount += 1);
            controlsTableLayoutPanel.Controls.Add(combo, 1, controlsTableLayoutPanel.RowCount);
            
        }
        private void TypeTipoProducto(PropertyInfo property)
        {
            controlsTableLayoutPanel.Controls.Add(GetCampoTitulo(property.Name), 0, controlsTableLayoutPanel.RowCount+=1);

            TipoProducto currentTipoProducto;
            BindingList<TipoProducto> objects;
            switch (currentModo)
            {
                case MODO_VER:
                    TextBox textField = new TextBox { Dock = DockStyle.Fill, AutoSize = true };
                    currentTipoProducto = TiposManager.Instance().GetTipoProductoByIdProducto(Id);
                    textField.Text = currentTipoProducto.Descripcion;
                    controlsTableLayoutPanel.Controls.Add(textField, 1, controlsTableLayoutPanel.RowCount );
                    textField.ReadOnly = true;
                    break;
                case MODO_INSERTAR:
                    TipoProducto tp = new TipoProducto();
                    tp.Id = 0;
                    tp.Descripcion = "";
                    listTipoProductos = TiposManager.Instance().GetTipoProductoList();
                    listTipoProductos.Add(tp);
                    listTipoProductos = listTipoProductos.OrderBy(x => x.Id).ToList();
                    objects = new BindingList<TipoProducto>(listTipoProductos);
                    ComboBox combo = new ComboBox { Dock = DockStyle.Fill, AutoSize = true };
                    combo.SelectedIndexChanged += tipoProductoComboClicked;
                    combo.Leave += comboRequiredLeave;
                    combo.ValueMember = null;
                    combo.DisplayMember = "Descripcion";
                    combo.DataSource = objects;
                    controlsTableLayoutPanel.Controls.Add(combo, 1, controlsTableLayoutPanel.RowCount );
                    combo.SelectedIndex = -1;
                    break;
                case MODO_EDITAR:
                    ComboBox comboE = new ComboBox { Dock = DockStyle.Fill, AutoSize = true };
                    currentTipoProducto = TiposManager.Instance().GetTipoProductoByIdProducto(Id);
                    listTipoProductos = TiposManager.Instance().GetTipoProductoList().OrderBy(x => x.Descripcion != currentTipoProducto.Descripcion).ToList();
                    objects = new BindingList<TipoProducto>(listTipoProductos);
                    comboE.SelectedIndexChanged += tipoProductoComboClicked;
                    comboE.ValueMember = null;
                    comboE.DisplayMember = "Descripcion";
                    comboE.DataSource = objects;
                    controlsTableLayoutPanel.Controls.Add(comboE, 1, controlsTableLayoutPanel.RowCount );
                    break;
            }
            
            
        }  
        private void TypeBanco(PropertyInfo property)
        {
            ComboBox combo = new ComboBox { Dock = DockStyle.Fill, AutoSize = true };
            Banco currentBanco;
            BindingList<Banco> objects;            
            switch (currentModo)
            {
                case MODO_VER:
                    currentBanco = TiposManager.Instance().GetBancoById(Id);
                    combo.Enabled = false;
                    combo.ValueMember = null;
                    combo.DisplayMember = "Descripcion";
                    combo.DataSource = currentBanco.Descripcion;
                    break;
                case MODO_INSERTAR:
                    Banco bvacio = new Banco();
                    bvacio.Id = 0;
                    bvacio.Descripcion = "";
                    combo.SelectedIndexChanged += bancoComboClicked;//tipoClienteComboClicked;
                    combo.Leave += comboRequiredLeave;
                    listBanco = TiposManager.Instance().GetBancoList();
                    listBanco.Add(bvacio);
                    listBanco = listBanco.OrderBy(x => x.Id).ToList();
                    objects = new BindingList<Banco>(listBanco);
                    combo.DisplayMember = "Descripcion";
                    combo.ValueMember = null;
                    combo.DataSource = objects;
                    combo.SelectedIndex = -1;
                    break;
                case MODO_EDITAR:
                    currentBanco = TiposManager.Instance().GetBancoById(Id);
                    listBanco = TiposManager.Instance().GetBancoList().OrderBy(x => x.Descripcion != currentBanco.Descripcion).ToList();
                    objects = new BindingList<Banco>(listBanco);
                    combo.SelectedIndexChanged += bancoComboClicked;
                    combo.ValueMember = null;
                    combo.DisplayMember = "Descripcion";
                    combo.DataSource = objects;
                    break;
            }

            controlsTableLayoutPanel.Controls.Add(GetCampoTitulo(property.Name), 0, controlsTableLayoutPanel.RowCount += 1);
            controlsTableLayoutPanel.Controls.Add(combo, 1, controlsTableLayoutPanel.RowCount);
        }

        // Eventos para cada tipo
        private void tipoClienteComboClicked(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            TipoCliente tipoCliente= (TipoCliente)combo.SelectedValue;
            ((Cliente)_reflection).TipoCliente = tipoCliente;            
        }
        private void tipoGarronComboClicked(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            TipoGarron tipoGarron = (TipoGarron)combo.SelectedValue;
            ((AppLaMejor.entidades.Garron)_reflection).TipoGarron = tipoGarron;            
        }
        private void tipoGarronEstadoComboClicked(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            TipoEstadoGarron tipoEstadoGarron = (TipoEstadoGarron)combo.SelectedValue;
            ((AppLaMejor.entidades.Garron)_reflection).TipoEstadoGarron = tipoEstadoGarron;
        }
        private void tipoProductoComboClicked(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            TipoProducto tipoProducto = (TipoProducto)combo.SelectedValue;
            ((Producto)_reflection).TipoProducto = tipoProducto ;            
        }
        private void tipoProductoEstadoComboClicked(object sender, EventArgs e)
        {
            //ComboBox combo = (ComboBox)sender;
            //TipoProductoEstado tipoProductoEstado = (TipoProductoEstado)combo.SelectedValue;
            //((Producto)_reflection).Estado = tipoProductoEstado;
        }
        private void bancoComboClicked(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            Banco banco= (Banco)combo.SelectedValue;
            ((AppLaMejor.entidades.Cuenta)_reflection).Banco = banco;
        }
        private void KeyDownIntegerTextField(object sender, KeyPressEventArgs e)
        {
            for (int i = 0; i < Text.Length; i++)
            {
                int c = Text[i];
                if (c < '0' || c > '9')
                {
                    Text = Text.Remove(i, 1);
                }
            }
        }
        private void DecimalOnExit(object sender, EventArgs e)
        {
            decimal d;
            string strdecimal = ((TextBox)sender).Text;
            strdecimal.Replace(".", ",");

            if (!decimal.TryParse(strdecimal, out d))
            {
                FormMessageBox dialog = new FormMessageBox();
				dialog.ShowErrorDialog("Por favor ingresa un numero decimal valido.");
            }
            else
            {
                ((TextBox)sender).Text = d.ToString();
            }
        }
        private void DecimalOnPoint(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.Handled = true;
				FormMessageBox dialog = new FormMessageBox();
				dialog.ShowErrorDialog("No se puede escribir punto, escriba coma");
            }
        }
        private void comboRequiredLeave(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            // Cero tiene que ser el campo vacio
            if (combo.SelectedIndex.Equals(-1) || combo.SelectedIndex.Equals(0))
            {
                MyTextTimer.TStartFade("Se requiere que seleccione un valor.", this.statusStripFormEntityInput, this.mensajeroFormEntityInput, MyTextTimer.TIME_LONG);
                combo.Focus();
            }
        }
        
        // Validaciones para tipos de datos
        private TextBox TextBoxCampoString(string p)
        {
            TextBox textField = new TextBox { Dock = DockStyle.Fill, AutoSize = true };
            textField.DataBindings.Add("Text", _reflection, p);
            if (currentModo.Equals(MODO_VER))
            {
                textField.ReadOnly = true;
            }
            return textField;
        }
        private TextBox TextBoxCampoInt(string p)
        {
            TextBox textField = new TextBox { Dock = DockStyle.Fill, AutoSize = true };
            textField.DataBindings.Add("Text", _reflection, p);
            textField.KeyPress += KeyDownIntegerTextField;
            if (currentModo.Equals(MODO_VER))
            {
                textField.ReadOnly = true;
            }
            return textField;
        }
        private TextBox TextBoxCampoDecimal(string p)
        {
            TextBox textField = new TextBox { Dock = DockStyle.Fill, AutoSize = true };
            textField.DataBindings.Add("Text", _reflection, p);
            /*textField.LostFocus += DecimalOnExit;
            textField.KeyPress += DecimalOnPoint;*/
            if (currentModo.Equals(MODO_VER))
            {
                textField.ReadOnly = true;
            }
            return textField;
        }

        // Setear titulo
        public void SetTitulo(string titulo)
        {
            string modo = string.Empty;
            switch (currentModo)
            {
                case MODO_EDITAR: modo = "Editando : "; break;
                case MODO_INSERTAR: modo = "Insertando: "; break;
                case MODO_VER: modo = "Ver: ";  break;
            }
            formTittleText.Text = modo + titulo;
            ApplicationLookAndFeel.ApplyTheme(formTittleText);
        }
        private Label GetCampoTitulo(string propertyName)
        {
            var propertyLabel = new Label
            {
                Text = propertyName,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleRight,
                Margin = new Padding(0, 0, 20, 0),
                Font = StyleManager.Instance().GetCurrentStyle().MainFontSmall
            };
            return propertyLabel;
        }
        private void bAceptar_Click_1(object sender, EventArgs e)
        {
            if (currentModo.Equals(MODO_EDITAR) || currentModo.Equals(MODO_INSERTAR))
            {
                FormMessageBox dialog = new FormMessageBox();
                if (dialog.ShowConfirmationDialog("¿Desea aplicar los cambios?"))
                    this.DialogResult = DialogResult.OK;
                else
                    this.DialogResult = DialogResult.Cancel;
            }
            else
                this.DialogResult = DialogResult.OK;

            this.Close();
        }
        private void bCancelar_Click(object sender, EventArgs e)
        {
            
            if (currentModo.Equals(MODO_EDITAR) || currentModo.Equals(MODO_INSERTAR))
            {
				FormMessageBox dialog = new FormMessageBox();
				if (dialog.ShowConfirmationDialog("¿Desea descartar los cambios?"))
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }            
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }


}
