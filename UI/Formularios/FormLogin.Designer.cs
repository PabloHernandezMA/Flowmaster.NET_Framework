namespace UI
{
    partial class FormLogin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelErrorMessage = new System.Windows.Forms.Label();
            this.linkLabelRestablecerContrasena = new System.Windows.Forms.LinkLabel();
            this.buttonIniciarSesion = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.labelCodigo = new System.Windows.Forms.Label();
            this.buttonCambiarPassword = new System.Windows.Forms.Button();
            this.buttonMostrar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 80);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(550, 80);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flowmaster";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 443);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(550, 54);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.panel3.Controls.Add(this.buttonMostrar);
            this.panel3.Controls.Add(this.buttonCambiarPassword);
            this.panel3.Controls.Add(this.textBoxCodigo);
            this.panel3.Controls.Add(this.labelCodigo);
            this.panel3.Controls.Add(this.labelErrorMessage);
            this.panel3.Controls.Add(this.linkLabelRestablecerContrasena);
            this.panel3.Controls.Add(this.buttonIniciarSesion);
            this.panel3.Controls.Add(this.textBoxPassword);
            this.panel3.Controls.Add(this.textBoxUsername);
            this.panel3.Controls.Add(this.labelPassword);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(550, 363);
            this.panel3.TabIndex = 2;
            // 
            // labelErrorMessage
            // 
            this.labelErrorMessage.AutoSize = true;
            this.labelErrorMessage.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelErrorMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.labelErrorMessage.Image = ((System.Drawing.Image)(resources.GetObject("labelErrorMessage.Image")));
            this.labelErrorMessage.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labelErrorMessage.Location = new System.Drawing.Point(28, 244);
            this.labelErrorMessage.Name = "labelErrorMessage";
            this.labelErrorMessage.Size = new System.Drawing.Size(128, 21);
            this.labelErrorMessage.TabIndex = 6;
            this.labelErrorMessage.Text = "Mensaje de error";
            // 
            // linkLabelRestablecerContrasena
            // 
            this.linkLabelRestablecerContrasena.AutoSize = true;
            this.linkLabelRestablecerContrasena.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.linkLabelRestablecerContrasena.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(166)))), ((int)(((byte)(255)))));
            this.linkLabelRestablecerContrasena.Location = new System.Drawing.Point(182, 326);
            this.linkLabelRestablecerContrasena.Name = "linkLabelRestablecerContrasena";
            this.linkLabelRestablecerContrasena.Size = new System.Drawing.Size(170, 21);
            this.linkLabelRestablecerContrasena.TabIndex = 5;
            this.linkLabelRestablecerContrasena.TabStop = true;
            this.linkLabelRestablecerContrasena.Text = "Restablecer contraseña";
            this.linkLabelRestablecerContrasena.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRestablecerContrasena_LinkClicked);
            // 
            // buttonIniciarSesion
            // 
            this.buttonIniciarSesion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonIniciarSesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.buttonIniciarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(31)))));
            this.buttonIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIniciarSesion.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.buttonIniciarSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonIniciarSesion.Location = new System.Drawing.Point(186, 273);
            this.buttonIniciarSesion.Name = "buttonIniciarSesion";
            this.buttonIniciarSesion.Size = new System.Drawing.Size(162, 43);
            this.buttonIniciarSesion.TabIndex = 4;
            this.buttonIniciarSesion.Text = "Iniciar sesión";
            this.buttonIniciarSesion.UseVisualStyleBackColor = true;
            this.buttonIniciarSesion.Click += new System.EventHandler(this.buttonIniciarSesion_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.textBoxPassword.Location = new System.Drawing.Point(32, 108);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(457, 32);
            this.textBoxPassword.TabIndex = 3;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.textBoxUsername.Location = new System.Drawing.Point(32, 37);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(457, 32);
            this.textBoxUsername.TabIndex = 2;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.labelPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.labelPassword.Location = new System.Drawing.Point(27, 72);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(127, 30);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Contraseña:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label2.Location = new System.Drawing.Point(27, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Usuario o Email:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.textBoxCodigo.Location = new System.Drawing.Point(32, 181);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(457, 32);
            this.textBoxCodigo.TabIndex = 8;
            this.textBoxCodigo.Visible = false;
            // 
            // labelCodigo
            // 
            this.labelCodigo.AutoSize = true;
            this.labelCodigo.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.labelCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.labelCodigo.Location = new System.Drawing.Point(27, 145);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(174, 30);
            this.labelCodigo.TabIndex = 7;
            this.labelCodigo.Text = "Codigo recibido:";
            this.labelCodigo.Visible = false;
            // 
            // buttonCambiarPassword
            // 
            this.buttonCambiarPassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonCambiarPassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.buttonCambiarPassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(31)))));
            this.buttonCambiarPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCambiarPassword.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.buttonCambiarPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonCambiarPassword.Location = new System.Drawing.Point(159, 280);
            this.buttonCambiarPassword.Name = "buttonCambiarPassword";
            this.buttonCambiarPassword.Size = new System.Drawing.Size(229, 43);
            this.buttonCambiarPassword.TabIndex = 9;
            this.buttonCambiarPassword.Text = "Cambiar contraseña";
            this.buttonCambiarPassword.UseVisualStyleBackColor = true;
            this.buttonCambiarPassword.Visible = false;
            this.buttonCambiarPassword.Click += new System.EventHandler(this.buttonCambiarPassword_Click);
            // 
            // buttonMostrar
            // 
            this.buttonMostrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonMostrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.buttonMostrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(31)))));
            this.buttonMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMostrar.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.buttonMostrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonMostrar.Location = new System.Drawing.Point(495, 108);
            this.buttonMostrar.Name = "buttonMostrar";
            this.buttonMostrar.Size = new System.Drawing.Size(29, 32);
            this.buttonMostrar.TabIndex = 10;
            this.buttonMostrar.Text = "*";
            this.buttonMostrar.UseVisualStyleBackColor = true;
            this.buttonMostrar.Click += new System.EventHandler(this.buttonMostrar_Click);
            // 
            // FormLogin
            // 
            this.AcceptButton = this.buttonIniciarSesion;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 497);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(566, 536);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(566, 536);
            this.Name = "FormLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flowmaster - Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonIniciarSesion;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabelRestablecerContrasena;
        private System.Windows.Forms.Label labelErrorMessage;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.Label labelCodigo;
        private System.Windows.Forms.Button buttonCambiarPassword;
        private System.Windows.Forms.Button buttonMostrar;
    }
}

