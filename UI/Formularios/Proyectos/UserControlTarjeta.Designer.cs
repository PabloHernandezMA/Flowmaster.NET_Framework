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
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelFechaFin = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelTarjeta = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.contextMenuStripTarjeta = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.contextMenuStripTarjeta.SuspendLayout();
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
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(161, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(44, 80);
            this.panelRight.TabIndex = 0;
            // 
            // contextMenuStripTarjeta
            // 
            this.contextMenuStripTarjeta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.contextMenuStripTarjeta.Name = "contextMenuStripTarjeta";
            this.contextMenuStripTarjeta.ShowImageMargin = false;
            this.contextMenuStripTarjeta.Size = new System.Drawing.Size(93, 48);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click_1);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // UserControlTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(34)))), ((int)(((byte)(43)))));
            this.ContextMenuStrip = this.contextMenuStripTarjeta;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelRight);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "UserControlTarjeta";
            this.Size = new System.Drawing.Size(205, 80);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.contextMenuStripTarjeta.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelFechaFin;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelTarjeta;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTarjeta;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
    }
}
