namespace UI.Formularios.Proyectos
{
    partial class UserControlColumna
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlColumna));
            this.panelTop = new System.Windows.Forms.Panel();
            this.textBoxTituloColumna = new System.Windows.Forms.TextBox();
            this.buttonOpciones = new System.Windows.Forms.Button();
            this.contextMenuStripColumna = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonMover = new System.Windows.Forms.Button();
            this.flowLayoutPanelDeTarjetas = new System.Windows.Forms.FlowLayoutPanel();
            this.userControlTarjeta2 = new UI.Formularios.Proyectos.UserControlTarjeta();
            this.userControlTarjeta1 = new UI.Formularios.Proyectos.UserControlTarjeta();
            this.buttonAgregarTarjeta = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.contextMenuStripColumna.SuspendLayout();
            this.flowLayoutPanelDeTarjetas.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.panelTop.Controls.Add(this.textBoxTituloColumna);
            this.panelTop.Controls.Add(this.buttonOpciones);
            this.panelTop.Controls.Add(this.buttonMover);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(225, 43);
            this.panelTop.TabIndex = 0;
            // 
            // textBoxTituloColumna
            // 
            this.textBoxTituloColumna.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.textBoxTituloColumna.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTituloColumna.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.textBoxTituloColumna.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxTituloColumna.Location = new System.Drawing.Point(10, 12);
            this.textBoxTituloColumna.Name = "textBoxTituloColumna";
            this.textBoxTituloColumna.Size = new System.Drawing.Size(138, 22);
            this.textBoxTituloColumna.TabIndex = 6;
            this.textBoxTituloColumna.Text = "textBox Titulo";
            this.textBoxTituloColumna.WordWrap = false;
            // 
            // buttonOpciones
            // 
            this.buttonOpciones.ContextMenuStrip = this.contextMenuStripColumna;
            this.buttonOpciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonOpciones.FlatAppearance.BorderSize = 0;
            this.buttonOpciones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.buttonOpciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.buttonOpciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpciones.Image = ((System.Drawing.Image)(resources.GetObject("buttonOpciones.Image")));
            this.buttonOpciones.Location = new System.Drawing.Point(149, 0);
            this.buttonOpciones.Margin = new System.Windows.Forms.Padding(10);
            this.buttonOpciones.Name = "buttonOpciones";
            this.buttonOpciones.Size = new System.Drawing.Size(38, 43);
            this.buttonOpciones.TabIndex = 5;
            this.buttonOpciones.UseVisualStyleBackColor = true;
            // 
            // contextMenuStripColumna
            // 
            this.contextMenuStripColumna.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarToolStripMenuItem});
            this.contextMenuStripColumna.Name = "contextMenuStripColumna";
            this.contextMenuStripColumna.ShowImageMargin = false;
            this.contextMenuStripColumna.Size = new System.Drawing.Size(93, 26);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // buttonMover
            // 
            this.buttonMover.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMover.FlatAppearance.BorderSize = 0;
            this.buttonMover.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.buttonMover.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.buttonMover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMover.Image = ((System.Drawing.Image)(resources.GetObject("buttonMover.Image")));
            this.buttonMover.Location = new System.Drawing.Point(187, 0);
            this.buttonMover.Margin = new System.Windows.Forms.Padding(10);
            this.buttonMover.Name = "buttonMover";
            this.buttonMover.Size = new System.Drawing.Size(38, 43);
            this.buttonMover.TabIndex = 3;
            this.buttonMover.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelDeTarjetas
            // 
            this.flowLayoutPanelDeTarjetas.AutoSize = true;
            this.flowLayoutPanelDeTarjetas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelDeTarjetas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.flowLayoutPanelDeTarjetas.Controls.Add(this.userControlTarjeta2);
            this.flowLayoutPanelDeTarjetas.Controls.Add(this.userControlTarjeta1);
            this.flowLayoutPanelDeTarjetas.Controls.Add(this.buttonAgregarTarjeta);
            this.flowLayoutPanelDeTarjetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelDeTarjetas.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelDeTarjetas.Location = new System.Drawing.Point(0, 43);
            this.flowLayoutPanelDeTarjetas.Name = "flowLayoutPanelDeTarjetas";
            this.flowLayoutPanelDeTarjetas.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.flowLayoutPanelDeTarjetas.Size = new System.Drawing.Size(225, 255);
            this.flowLayoutPanelDeTarjetas.TabIndex = 1;
            // 
            // userControlTarjeta2
            // 
            this.userControlTarjeta2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(34)))), ((int)(((byte)(43)))));
            this.userControlTarjeta2.descripcion = null;
            this.userControlTarjeta2.id_Columna = 0;
            this.userControlTarjeta2.id_Tarjeta = 0;
            this.userControlTarjeta2.Location = new System.Drawing.Point(10, 10);
            this.userControlTarjeta2.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.userControlTarjeta2.Name = "userControlTarjeta2";
            this.userControlTarjeta2.nombre = null;
            this.userControlTarjeta2.posicion = 0;
            this.userControlTarjeta2.Size = new System.Drawing.Size(205, 80);
            this.userControlTarjeta2.TabIndex = 5;
            this.userControlTarjeta2.visible = false;
            // 
            // userControlTarjeta1
            // 
            this.userControlTarjeta1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(34)))), ((int)(((byte)(43)))));
            this.userControlTarjeta1.descripcion = null;
            this.userControlTarjeta1.id_Columna = 0;
            this.userControlTarjeta1.id_Tarjeta = 0;
            this.userControlTarjeta1.Location = new System.Drawing.Point(10, 100);
            this.userControlTarjeta1.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.userControlTarjeta1.Name = "userControlTarjeta1";
            this.userControlTarjeta1.nombre = null;
            this.userControlTarjeta1.posicion = 0;
            this.userControlTarjeta1.Size = new System.Drawing.Size(205, 80);
            this.userControlTarjeta1.TabIndex = 4;
            this.userControlTarjeta1.visible = false;
            // 
            // buttonAgregarTarjeta
            // 
            this.buttonAgregarTarjeta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAgregarTarjeta.BackColor = System.Drawing.Color.Transparent;
            this.buttonAgregarTarjeta.FlatAppearance.BorderColor = System.Drawing.Color.CadetBlue;
            this.buttonAgregarTarjeta.FlatAppearance.BorderSize = 2;
            this.buttonAgregarTarjeta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.buttonAgregarTarjeta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.buttonAgregarTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAgregarTarjeta.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgregarTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonAgregarTarjeta.Image = ((System.Drawing.Image)(resources.GetObject("buttonAgregarTarjeta.Image")));
            this.buttonAgregarTarjeta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAgregarTarjeta.Location = new System.Drawing.Point(10, 195);
            this.buttonAgregarTarjeta.Margin = new System.Windows.Forms.Padding(10);
            this.buttonAgregarTarjeta.Name = "buttonAgregarTarjeta";
            this.buttonAgregarTarjeta.Size = new System.Drawing.Size(205, 45);
            this.buttonAgregarTarjeta.TabIndex = 3;
            this.buttonAgregarTarjeta.Text = "Agregar tarjeta        ";
            this.buttonAgregarTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAgregarTarjeta.UseVisualStyleBackColor = false;
            this.buttonAgregarTarjeta.Click += new System.EventHandler(this.buttonAgregarTarjeta_Click);
            // 
            // UserControlColumna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanelDeTarjetas);
            this.Controls.Add(this.panelTop);
            this.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.Name = "UserControlColumna";
            this.Size = new System.Drawing.Size(225, 298);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.contextMenuStripColumna.ResumeLayout(false);
            this.flowLayoutPanelDeTarjetas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDeTarjetas;
        private System.Windows.Forms.Button buttonMover;
        private System.Windows.Forms.Button buttonOpciones;
        private System.Windows.Forms.Button buttonAgregarTarjeta;
        private UserControlTarjeta userControlTarjeta1;
        private UserControlTarjeta userControlTarjeta2;
        private System.Windows.Forms.TextBox textBoxTituloColumna;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripColumna;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
    }
}
