namespace AppLaMejor.formularios
{
    partial class FormUsuario
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
            this.contentPanel = new System.Windows.Forms.Panel();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.bLoginAceptar = new System.Windows.Forms.Button();
            this.bLoginCancelar = new System.Windows.Forms.Button();
            this.textUser = new System.Windows.Forms.TextBox();
            this.lUser = new System.Windows.Forms.Label();
            this.textPass = new System.Windows.Forms.TextBox();
            this.lPass = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.formTittleText = new System.Windows.Forms.Label();
            this.contentPanel.SuspendLayout();
            this.loginPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.Black;
            this.contentPanel.Controls.Add(this.loginPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 55);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1190, 521);
            this.contentPanel.TabIndex = 3;
            // 
            // loginPanel
            // 
            this.loginPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loginPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginPanel.Controls.Add(this.button1);
            this.loginPanel.Controls.Add(this.buttonPanel);
            this.loginPanel.Controls.Add(this.textUser);
            this.loginPanel.Controls.Add(this.lUser);
            this.loginPanel.Controls.Add(this.textPass);
            this.loginPanel.Controls.Add(this.lPass);
            this.loginPanel.Location = new System.Drawing.Point(227, 33);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(471, 244);
            this.loginPanel.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(391, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Ver Permisos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.bLoginAceptar);
            this.buttonPanel.Controls.Add(this.bLoginCancelar);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 141);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Padding = new System.Windows.Forms.Padding(110, 10, 110, 10);
            this.buttonPanel.Size = new System.Drawing.Size(469, 101);
            this.buttonPanel.TabIndex = 26;
            // 
            // bLoginAceptar
            // 
            this.bLoginAceptar.BackColor = System.Drawing.Color.Black;
            this.bLoginAceptar.CausesValidation = false;
            this.bLoginAceptar.Dock = System.Windows.Forms.DockStyle.Left;
            this.bLoginAceptar.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.bLoginAceptar.FlatAppearance.BorderSize = 2;
            this.bLoginAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLoginAceptar.ForeColor = System.Drawing.Color.White;
            this.bLoginAceptar.Location = new System.Drawing.Point(110, 10);
            this.bLoginAceptar.Margin = new System.Windows.Forms.Padding(0);
            this.bLoginAceptar.MaximumSize = new System.Drawing.Size(150, 50);
            this.bLoginAceptar.Name = "bLoginAceptar";
            this.bLoginAceptar.Size = new System.Drawing.Size(150, 50);
            this.bLoginAceptar.TabIndex = 2;
            this.bLoginAceptar.Text = "Aceptar";
            this.bLoginAceptar.UseVisualStyleBackColor = false;
            this.bLoginAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // bLoginCancelar
            // 
            this.bLoginCancelar.BackColor = System.Drawing.Color.Black;
            this.bLoginCancelar.CausesValidation = false;
            this.bLoginCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.bLoginCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.bLoginCancelar.FlatAppearance.BorderSize = 2;
            this.bLoginCancelar.ForeColor = System.Drawing.Color.White;
            this.bLoginCancelar.Location = new System.Drawing.Point(209, 10);
            this.bLoginCancelar.Margin = new System.Windows.Forms.Padding(0);
            this.bLoginCancelar.MaximumSize = new System.Drawing.Size(150, 50);
            this.bLoginCancelar.Name = "bLoginCancelar";
            this.bLoginCancelar.Size = new System.Drawing.Size(150, 50);
            this.bLoginCancelar.TabIndex = 3;
            this.bLoginCancelar.Text = "Salir";
            this.bLoginCancelar.UseVisualStyleBackColor = false;
            this.bLoginCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // textUser
            // 
            this.textUser.Location = new System.Drawing.Point(162, 55);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(163, 20);
            this.textUser.TabIndex = 0;
            this.textUser.Enter += new System.EventHandler(this.textUser_Enter);
            this.textUser.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textUser_KeyUp);
            this.textUser.Leave += new System.EventHandler(this.textUser_Leave);
            // 
            // lUser
            // 
            this.lUser.AutoSize = true;
            this.lUser.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lUser.ForeColor = System.Drawing.Color.White;
            this.lUser.Location = new System.Drawing.Point(161, 38);
            this.lUser.Name = "lUser";
            this.lUser.Size = new System.Drawing.Size(89, 16);
            this.lUser.TabIndex = 24;
            this.lUser.Tag = "bold";
            this.lUser.Text = "Ingrese Usuario";
            // 
            // textPass
            // 
            this.textPass.Location = new System.Drawing.Point(162, 102);
            this.textPass.Name = "textPass";
            this.textPass.Size = new System.Drawing.Size(163, 20);
            this.textPass.TabIndex = 1;
            this.textPass.Enter += new System.EventHandler(this.textPass_Enter);
            this.textPass.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textPass_KeyUp);
            this.textPass.Leave += new System.EventHandler(this.textPass_Leave);
            // 
            // lPass
            // 
            this.lPass.AutoSize = true;
            this.lPass.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPass.ForeColor = System.Drawing.Color.White;
            this.lPass.Location = new System.Drawing.Point(161, 85);
            this.lPass.Name = "lPass";
            this.lPass.Size = new System.Drawing.Size(99, 16);
            this.lPass.TabIndex = 25;
            this.lPass.Tag = "bold";
            this.lPass.Text = "Ingrese Password";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.bottomPanel);
            this.mainPanel.Controls.Add(this.contentPanel);
            this.mainPanel.Controls.Add(this.topPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1190, 576);
            this.mainPanel.TabIndex = 23;
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Green;
            this.bottomPanel.Controls.Add(this.statusStrip1);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 526);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1190, 50);
            this.bottomPanel.TabIndex = 6;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.Green;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslMensaje});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1190, 50);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "ssMensajero";
            // 
            // tsslMensaje
            // 
            this.tsslMensaje.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsslMensaje.ImageTransparentColor = System.Drawing.Color.Green;
            this.tsslMensaje.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tsslMensaje.Name = "tsslMensaje";
            this.tsslMensaje.Size = new System.Drawing.Size(83, 50);
            this.tsslMensaje.Text = "Mensajero";
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Black;
            this.topPanel.Controls.Add(this.formTittleText);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1190, 55);
            this.topPanel.TabIndex = 1;
            // 
            // formTittleText
            // 
            this.formTittleText.BackColor = System.Drawing.Color.Green;
            this.formTittleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formTittleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formTittleText.Location = new System.Drawing.Point(0, 0);
            this.formTittleText.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.formTittleText.Name = "formTittleText";
            this.formTittleText.Size = new System.Drawing.Size(1190, 55);
            this.formTittleText.TabIndex = 0;
            this.formTittleText.Tag = "bold title inverted";
            this.formTittleText.Text = "Sistema - Carniceria La Mejor";
            this.formTittleText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 576);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FormUsuario";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormUsuario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.FormUsuario_Activated);
            this.Load += new System.EventHandler(this.FormUsuario_Load);
            this.contentPanel.ResumeLayout(false);
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label formTittleText;
        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.Label lUser;
        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.Label lPass;
        private System.Windows.Forms.Button bLoginCancelar;
        private System.Windows.Forms.Button bLoginAceptar;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslMensaje;
        private System.Windows.Forms.Button button1;
    }
}