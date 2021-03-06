﻿using System.Windows.Forms;
using System.Drawing;
using AppLaMejor.stylemanager;
using System;
using AppLaMejor.formularios.Util;

public class ApplicationLookAndFeel
{
    // TODO UI: Todos los formularios deben tener solo un boton "Salir".
    // TODO UI: Todos los formularios deben tener el "formBorderStyle" por defecto.

    public static void ApplyTheme(RadioButton c)
    {
        c.Font = StyleManager.Instance().GetCurrentStyle().MainFont;
        c.BackColor = StyleManager.Instance().GetCurrentStyle().BackColor;
        c.ForeColor = StyleManager.Instance().GetCurrentStyle().TextColor;
        HandleTag(c);
    }
    public static void ApplyTheme(TextBox c)
    {
        c.Font = StyleManager.Instance().GetCurrentStyle().MainFont;
        c.BackColor = StyleManager.Instance().GetCurrentStyle().BackColor;
        c.ForeColor = StyleManager.Instance().GetCurrentStyle().TextColor ;
        HandleTag(c);
    }
    public static void ApplyTheme(ComboBox c)
    {
        c.Font = StyleManager.Instance().GetCurrentStyle().MainFont;
        c.BackColor = StyleManager.Instance().GetCurrentStyle().BackColor;
        c.ForeColor = StyleManager.Instance().GetCurrentStyle().TextColor;
    }
    public static void ApplyTheme(CheckBox c)
    {
        c.Font = StyleManager.Instance().GetCurrentStyle().MainFont;
        c.BackColor = StyleManager.Instance().GetCurrentStyle().BackColor;
        c.ForeColor = StyleManager.Instance().GetCurrentStyle().TextColor;
        HandleTag(c);
    }

    public static void ApplyTheme(Label c)
    {
        c.Font = StyleManager.Instance().GetCurrentStyle().MainFontSmall;
        c.BackColor = StyleManager.Instance().GetCurrentStyle().BackColor;
        c.ForeColor = StyleManager.Instance().GetCurrentStyle().TextColor;
        HandleTag(c);
    }
    public static void ApplyTheme(ToolStripStatusLabel c)
    {
        if (c.Name.Equals("mensajeroFormEntityInput"))
        {
            c.BackColor = StyleManager.Instance().GetCurrentStyle().MouseDownBackColor;
        }
        else
        {
            c.Font = StyleManager.Instance().GetCurrentStyle().MainFontBig;
            c.BackColor = StyleManager.Instance().GetCurrentStyle().MainColor;
            c.ForeColor = StyleManager.Instance().GetCurrentStyle().TextColor;
        }
            
    }
    public static void ApplyTheme(StatusStrip c)
    {
        ToolStripStatusLabel label = (ToolStripStatusLabel)c.Items[0];
        if (c.Name.Equals("statusStripFormEntityInput"))
        {
            c.BackColor = StyleManager.Instance().GetCurrentStyle().MouseDownBackColor;
        }else
        {
            c.BackColor = StyleManager.Instance().GetCurrentStyle().MainColor;
        }
        ApplyTheme(label);
    }
    public static void ApplyTheme(Form c)
    {
        c.Font = StyleManager.Instance().GetCurrentStyle().MainFont;
        c.BackColor = StyleManager.Instance().GetCurrentStyle().BackColor;
        c.ForeColor = StyleManager.Instance().GetCurrentStyle().TextColor;
    }
    public static void ApplyTheme(DataGridView c)
    {


        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();

        StyleEntity style = StyleManager.Instance().GetCurrentStyle();

        c.Font = style.MainFont;
        c.BackColor = style.BackColor;
        c.ForeColor = style.TextColor;



        c.RowTemplate.DefaultCellStyle.Font = style.MainFont;
        c.RowTemplate.DefaultCellStyle.ForeColor = c.ForeColor;
        c.RowTemplate.DefaultCellStyle.SelectionBackColor = style.MainColor;
        c.RowTemplate.DefaultCellStyle.SelectionForeColor = c.BackColor;
        c.RowTemplate.Height = 35;

        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle1.BackColor = c.ForeColor;
        dataGridViewCellStyle1.ForeColor = c.BackColor;
        dataGridViewCellStyle1.SelectionBackColor = style.MainColor;
        dataGridViewCellStyle1.SelectionForeColor = c.ForeColor;
        //dataGridViewCellStyle1.BackgroundColor = c.BackColor;

        c.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        c.GridColor = style.MainColor;
        c.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;


        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = c.BackColor;
        dataGridViewCellStyle2.Font = style.MainFont;
        dataGridViewCellStyle2.ForeColor = c.ForeColor;
        dataGridViewCellStyle2.SelectionBackColor = style.MainColor;
        dataGridViewCellStyle2.SelectionForeColor = c.BackColor;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
        c.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        c.ColumnHeadersHeight = 40;
        dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = c.ForeColor;
        dataGridViewCellStyle3.Font = style.MainFont;
        dataGridViewCellStyle3.ForeColor = c.ForeColor;
        dataGridViewCellStyle3.SelectionBackColor = style.MouseDownBackColor;
        dataGridViewCellStyle3.SelectionForeColor = style.MouseOverBackColor;
        dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
        c.DefaultCellStyle = dataGridViewCellStyle3;
        c.Dock = DockStyle.Fill;
        c.EnableHeadersVisualStyles = false;


        c.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
        dataGridViewCellStyle4.Font = style.MainFont;
        dataGridViewCellStyle4.ForeColor = c.ForeColor;
        dataGridViewCellStyle4.SelectionBackColor = style.MouseDownBackColor;
        dataGridViewCellStyle4.SelectionForeColor = style.MouseOverBackColor;
        dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
        c.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
        c.RowHeadersVisible = false;
        c.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        c.RowTemplate.DefaultCellStyle.BackColor = style.BackColor;
        c.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        c.RowTemplate.DefaultCellStyle.Font = style.MainFont;
        c.RowTemplate.DefaultCellStyle.ForeColor = style.TextColor;
        c.RowTemplate.DefaultCellStyle.SelectionBackColor = style.MainColor;
        c.RowTemplate.DefaultCellStyle.SelectionForeColor = c.BackColor;
        c.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        c.RowTemplate.ReadOnly = true;
        c.RowTemplate.Resizable = DataGridViewTriState.False;
        c.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        if (c.Name.Equals("dataGridVentas") || c.Name.Equals("dataGridComprasProdPendientes"))
        {
            c.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }



    }
    public static void ApplyTheme(Panel c)
    {
        if (c.Name.Equals("loginPanel"))
        {
            c.BorderStyle = BorderStyle.FixedSingle;
        }
        else if (c.Name.Equals("bottomPanel"))
        {
            c.BackColor = StyleManager.Instance().GetCurrentStyle().MainColor;
        }
        else
        {
            c.Font = StyleManager.Instance().GetCurrentStyle().MainFont;
            c.BackColor = StyleManager.Instance().GetCurrentStyle().BackColor;
            c.ForeColor = StyleManager.Instance().GetCurrentStyle().TextColor;

            if (c.Tag !=null && c.Tag.Equals("inverted"))
            {
                c.BackColor = StyleManager.Instance().GetCurrentStyle().TextColor;
                c.ForeColor = StyleManager.Instance().GetCurrentStyle().BackColor;
            }
        }

    }
    public static void ApplyTheme(TableLayoutPanel c)
    {
        //c.BackColor = StyleManager.Instance().GetCurrentStyle().BackColor;
    }
    public static void ApplyTheme(Button c)
    {
        if (c.Name.Equals("bBuscar"))
            return;
        c.Size = new Size(120, 50);
        c.UseVisualStyleBackColor = false;
        c.Font = StyleManager.Instance().GetCurrentStyle().MainFont;
        c.BackColor = StyleManager.Instance().GetCurrentStyle().BackColor;
        c.ForeColor = StyleManager.Instance().GetCurrentStyle().TextColor;
        c.FlatStyle = FlatStyle.Flat;
        c.FlatAppearance.BorderSize = 2;
        c.FlatAppearance.BorderColor = StyleManager.Instance().GetCurrentStyle().MainColor;
        c.FlatAppearance.MouseDownBackColor = StyleManager.Instance().GetCurrentStyle().MouseDownBackColor;
        c.FlatAppearance.MouseOverBackColor = StyleManager.Instance().GetCurrentStyle().MouseOverBackColor;

        HandleTag(c);
    }

    public static void ApplyTheme(DateTimePicker c)
    {
        c.Font = StyleManager.Instance().GetCurrentStyle().MainFont;
        c.BackColor = StyleManager.Instance().GetCurrentStyle().BackColor;
        c.ForeColor = StyleManager.Instance().GetCurrentStyle().TextColor;
    }

    public static void ApplyTheme(GroupBox c)
    {
        c.BackColor = StyleManager.Instance().GetCurrentStyle().BackColor;
        c.ForeColor = StyleManager.Instance().GetCurrentStyle().TextColor;
    }

    private static void HandleTag(Control c)
    {
        Boolean bold = false;
        Boolean big = false;
        Boolean title = false;
        Boolean small = false;
        Boolean inverted = false;
        Boolean saldoBien = false;
        Boolean saldoMal = false;

        // Si se ingresa en TAG:  big small titlle rompe todo 
        if (c.Tag != null)
        {
            if (c.Tag.ToString().Contains("bold")) bold = true;
            if (c.Tag.ToString().Contains("title")) title = true;
            if (c.Tag.ToString().Contains("big")) big = true;
            if (c.Tag.ToString().Contains("small")) small = true;
            if (c.Tag.ToString().Contains("inverted")) inverted = true;
            if (c.Tag.ToString().Contains("saldobien")) saldoBien = true;
            if (c.Tag.ToString().Contains("saldomal")) saldoMal = true;

            Font fontSelected = null;
            if (bold)
            {
                if (title)
                {
                    fontSelected = StyleManager.Instance().GetCurrentStyle().MainFontTitleBold;
                }
                else if (big)
                {
                    fontSelected = StyleManager.Instance().GetCurrentStyle().MainFontBigBold;
                }
                else if (small)
                {
                    fontSelected = StyleManager.Instance().GetCurrentStyle().MainFontSmallBold;
                }
            }
            else
            {
                if (title)
                {
                    fontSelected = StyleManager.Instance().GetCurrentStyle().MainFontTitle;
                }
                else if (big)
                {
                    fontSelected = StyleManager.Instance().GetCurrentStyle().MainFontBig;
                }
                else if (small)
                {
                    fontSelected = StyleManager.Instance().GetCurrentStyle().MainFontSmall;
                }
            }
            c.Font = fontSelected;

            if (inverted)
            {
                c.BackColor = StyleManager.Instance().GetCurrentStyle().MainColor;
            }
            else
            {
                c.BackColor = StyleManager.Instance().GetCurrentStyle().BackColor;
            }

            if (saldoBien)
            {
                c.ForeColor = Color.Lime;
            }
            else if (saldoMal)
            {
                c.ForeColor = Color.Red;
            }

            c.ForeColor = StyleManager.Instance().GetCurrentStyle().TextColor;
        }
    }

    private static object GetCurrentStyle()
    {
        throw new System.NotImplementedException();
    }

    public static void ApplyThemeToChild(Control father)
    {        
        foreach (var c in father.Controls)
        {
            Control control;
            switch (c.GetType().ToString().Trim())
            {
                case "System.Windows.Forms.TextBox":
                    ApplyTheme((TextBox)c);
                    control = (Control)c;
                    if (control.Controls.Count > 0)
                        ApplyThemeToChild((Control)c); 
                    break;
                case "System.Windows.Forms.Label":
                    ApplyTheme((Label)c);
                    control = (Control)c;
                    if (control.Controls.Count > 0)
                        ApplyThemeToChild((Control)c);
                    break;
                case "System.Windows.Forms.CheckBox":
                    ApplyTheme((CheckBox)c);
                    control = (Control)c;
                    if (control.Controls.Count > 0)
                        ApplyThemeToChild((Control)c);
                    break;
                case "System.Windows.Forms.DataGridView":
                    ApplyTheme((DataGridView)c);
                    control = (Control)c;
                    if (control.Controls.Count > 0)
                        ApplyThemeToChild((Control)c);
                    break;
                case "System.Windows.Forms.Panel":
                    ApplyTheme((Panel)c);
                    control = (Control)c;
                    if (control.Controls.Count > 0)
                        ApplyThemeToChild((Control)c);
                    break;
                case "System.Windows.Forms.GroupBox":
                    ApplyTheme((GroupBox)c);
                    control = (Control)c;
                    if (control.Controls.Count > 0)
                        ApplyThemeToChild((Control)c);
                    break;
                case "System.Windows.Forms.TableLayoutPanel":
                    control = (TableLayoutPanel)c;
                    if (control.Controls.Count > 0)
                        ApplyThemeToChild((Control)c);
                    break;
                case "System.Windows.Forms.Button":
                    ApplyTheme((Button)c);
                    control = (Control)c;
                    if (control.Controls.Count > 0)
                        ApplyThemeToChild((Control)c);
                    break;
                case "System.Windows.Forms.ComboBox":
                    control = (ComboBox)c;
                    ApplyTheme((ComboBox)control);
                    if (control.Controls.Count > 0)
                        ApplyThemeToChild((Control)c);
                    break;
                case "System.Windows.Forms.DateTimePicker":
                    control = (DateTimePicker)c;
                    ApplyTheme((DateTimePicker)control);
                    if (control.Controls.Count > 0)
                        ApplyThemeToChild((Control)c);
                    break;
                case "System.Windows.Forms.StatusStrip":
                    control = (StatusStrip)c;
                    ApplyTheme((StatusStrip)control);
                    if (control.Controls.Count > 0)
                        ApplyThemeToChild((Control)c);
                    break;
            }
        }
    }

    public static void ApplyThemeToAll(Form f)
    {
        foreach (Control c in f.Controls)
        {
            ApplyThemeToChild(c);
        }
    }

    public static void ShowNames(Form f)
    {
        string text = "";
        foreach (Control c in f.Controls)
        {
            text += " Nombre: " + c.Name + " - " + c.GetType().ToString()+ "\n";
            if (c.Controls.Count > 0)
            {
                for (int j = 0; j < c.Controls.Count; j++)
                {
                    Control child = (Control)c.Controls[j];
                    text += " Nombre: " + child.Name + " - " + child.GetType().ToString() + "\n";
                    if (child.Controls.Count > 0)
                    {
                        for (int h = 0; h < child.Controls.Count; h++)
                        {
                            Control childChild = (Control)child.Controls[h];
                            text += " Nombre: " + childChild.Name + " - " + childChild.GetType().ToString() + "\n";
                            if (childChild.Controls.Count > 0)
                            {
                                for (int s = 0; s < childChild.Controls.Count; s++)
                                {
                                    Control childChildChild = (Control)childChild.Controls[s];
                                    text += " Nombre: " + childChildChild.Name + " - " + childChildChild.GetType().ToString() + "\n";
                                }
                            }
                        }
                    }
                }
            }
        }

		FormMessageBox dialog = new FormMessageBox();
		dialog.ShowErrorDialog(text);
    }

}