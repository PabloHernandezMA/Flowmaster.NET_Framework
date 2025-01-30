namespace UI.Formularios.Proyectos
{
    partial class UserControlTarjeta
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlTarjeta));
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelFechaFin = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelTarjeta = new System.Windows.Forms.Label();
            this.buttonOpciones = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelFechaFin);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(161, 26);
            this.panel2.TabIndex = 1;
            // 
            // labelFechaFin
            // 
            this.labelFechaFin.BackColor = System.Drawing.Color.Transparent;
            this.labelFechaFin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFechaFin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelFechaFin.ForeColor = System.Drawing.Color.Silver;
            this.labelFechaFin.Location = new System.Drawing.Point(0, 0);
            this.labelFechaFin.Name = "labelFechaFin";
            this.labelFechaFin.Padding = new System.Windows.Forms.Padding(2);
            this.labelFechaFin.Size = new System.Drawing.Size(161, 26);
            this.labelFechaFin.TabIndex = 7;
            this.labelFechaFin.Text = "2002/1/2";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelTarjeta);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(161, 54);
            this.panel3.TabIndex = 2;
            // 
            // labelTarjeta
            // 
            this.labelTarjeta.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTarjeta.ForeColor = System.Drawing.Color.White;
            this.labelTarjeta.Location = new System.Drawing.Point(5, 6);
            this.labelTarjeta.Name = "labelTarjeta";
            this.labelTarjeta.Size = new System.Drawing.Size(150, 43);
            this.labelTarjeta.TabIndex = 6;
            this.labelTarjeta.Text = "labelTarjeta prueba texto";
            // 
            // buttonOpciones
            // 
            this.buttonOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpciones.FlatAppearance.BorderSize = 0;
            this.buttonOpciones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.buttonOpciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.buttonOpciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpciones.Image = ((System.Drawing.Image)(resources.GetObject("buttonOpciones.Image")));
            this.buttonOpciones.Location = new System.Drawing.Point(3, 3);
            this.buttonOpciones.Margin = new System.Windows.Forms.Padding(10);
            this.buttonOpciones.Name = "buttonOpciones";
            this.buttonOpciones.Size = new System.Drawing.Size(38, 43);
            this.buttonOpciones.TabIndex = 6;
            this.buttonOpciones.UseVisualStyleBackColor = true;
            this.buttonOpciones.Click += new System.EventHandler(this.buttonOpciones_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonOpciones);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(161, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(44, 80);
            this.panel1.TabIndex = 0;
            // 
            // UserControlTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(34)))), ((int)(((byte)(43)))));
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "UserControlTarjeta";
            this.Size = new System.Drawing.Size(205, 80);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelFechaFin;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelTarjeta;
        private System.Windows.Forms.Button buttonOpciones;
        private System.Windows.Forms.Panel panel1;
    }
}
