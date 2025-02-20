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
            this.contextMenuStripColumna = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanelDeTarjetas = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAgregarTarjeta = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.contextMenuStripColumna.SuspendLayout();
            this.flowLayoutPanelDeTarjetas.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.panelTop.ContextMenuStrip = this.contextMenuStripColumna;
            this.panelTop.Controls.Add(this.textBoxTituloColumna);
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
            this.textBoxTituloColumna.Leave += new System.EventHandler(this.textBoxTituloColumna_Leave);
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
            // flowLayoutPanelDeTarjetas
            // 
            this.flowLayoutPanelDeTarjetas.AutoSize = true;
            this.flowLayoutPanelDeTarjetas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelDeTarjetas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.flowLayoutPanelDeTarjetas.Controls.Add(this.buttonAgregarTarjeta);
            this.flowLayoutPanelDeTarjetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelDeTarjetas.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelDeTarjetas.Location = new System.Drawing.Point(0, 43);
            this.flowLayoutPanelDeTarjetas.Name = "flowLayoutPanelDeTarjetas";
            this.flowLayoutPanelDeTarjetas.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.flowLayoutPanelDeTarjetas.Size = new System.Drawing.Size(225, 75);
            this.flowLayoutPanelDeTarjetas.TabIndex = 1;
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
            this.buttonAgregarTarjeta.Location = new System.Drawing.Point(10, 15);
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
            this.Size = new System.Drawing.Size(225, 118);
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
        private System.Windows.Forms.Button buttonAgregarTarjeta;
        private System.Windows.Forms.TextBox textBoxTituloColumna;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripColumna;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
    }
}
