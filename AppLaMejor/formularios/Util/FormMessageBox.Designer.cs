namespace AppLaMejor.formularios.Util
{
    partial class FormMessageBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMessageBox));
            this.tableBotones = new System.Windows.Forms.TableLayoutPanel();
            this.bCancelar = new System.Windows.Forms.Button();
            this.bOk = new System.Windows.Forms.Button();
            this.bAceptar = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.messagePanel = new System.Windows.Forms.Panel();
            this.groupMensaje = new System.Windows.Forms.GroupBox();
            this.panelMessage = new System.Windows.Forms.Panel();
            this.messageBoxLabel = new System.Windows.Forms.Label();
            this.tableBotones.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.messagePanel.SuspendLayout();
            this.groupMensaje.SuspendLayout();
            this.panelMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableBotones
            // 
            resources.ApplyResources(this.tableBotones, "tableBotones");
            this.tableBotones.Controls.Add(this.bCancelar, 2, 0);
            this.tableBotones.Controls.Add(this.bOk, 1, 0);
            this.tableBotones.Controls.Add(this.bAceptar, 0, 0);
            this.tableBotones.Name = "tableBotones";
            // 
            // bCancelar
            // 
            resources.ApplyResources(this.bCancelar, "bCancelar");
            this.bCancelar.BackColor = System.Drawing.Color.Black;
            this.bCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.bCancelar.FlatAppearance.BorderSize = 2;
            this.bCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.bCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.UseVisualStyleBackColor = false;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // bOk
            // 
            resources.ApplyResources(this.bOk, "bOk");
            this.bOk.BackColor = System.Drawing.Color.Black;
            this.bOk.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.bOk.FlatAppearance.BorderSize = 2;
            this.bOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.bOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.bOk.Name = "bOk";
            this.bOk.UseVisualStyleBackColor = false;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // bAceptar
            // 
            resources.ApplyResources(this.bAceptar, "bAceptar");
            this.bAceptar.BackColor = System.Drawing.Color.Black;
            this.bAceptar.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.bAceptar.FlatAppearance.BorderSize = 2;
            this.bAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.bAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.UseVisualStyleBackColor = false;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // mainPanel
            // 
            resources.ApplyResources(this.mainPanel, "mainPanel");
            this.mainPanel.Controls.Add(this.messagePanel);
            this.mainPanel.Name = "mainPanel";
            // 
            // messagePanel
            // 
            resources.ApplyResources(this.messagePanel, "messagePanel");
            this.messagePanel.Controls.Add(this.groupMensaje);
            this.messagePanel.Name = "messagePanel";
            // 
            // groupMensaje
            // 
            resources.ApplyResources(this.groupMensaje, "groupMensaje");
            this.groupMensaje.Controls.Add(this.tableBotones);
            this.groupMensaje.Controls.Add(this.panelMessage);
            this.groupMensaje.Name = "groupMensaje";
            this.groupMensaje.TabStop = false;
            this.groupMensaje.Tag = "big";
            // 
            // panelMessage
            // 
            resources.ApplyResources(this.panelMessage, "panelMessage");
            this.panelMessage.Controls.Add(this.messageBoxLabel);
            this.panelMessage.Name = "panelMessage";
            // 
            // messageBoxLabel
            // 
            resources.ApplyResources(this.messageBoxLabel, "messageBoxLabel");
            this.messageBoxLabel.Name = "messageBoxLabel";
            this.messageBoxLabel.Tag = "big";
            // 
            // FormMessageBox
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMessageBox";
            this.ShowInTaskbar = false;
            this.tableBotones.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.messagePanel.ResumeLayout(false);
            this.messagePanel.PerformLayout();
            this.groupMensaje.ResumeLayout(false);
            this.groupMensaje.PerformLayout();
            this.panelMessage.ResumeLayout(false);
            this.panelMessage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableBotones;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bAceptar;
        public System.Windows.Forms.Panel messagePanel;
        private System.Windows.Forms.GroupBox groupMensaje;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Panel panelMessage;
        private System.Windows.Forms.Label messageBoxLabel;
    }
}