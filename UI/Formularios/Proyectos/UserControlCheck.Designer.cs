namespace UI.Formularios.Proyectos
{
    partial class UserControlCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlCheck));
            this.checkBoxCompletada = new System.Windows.Forms.CheckBox();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.buttonEliminarTarea = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxCompletada
            // 
            this.checkBoxCompletada.AutoSize = true;
            this.checkBoxCompletada.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxCompletada.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCompletada.Location = new System.Drawing.Point(2, 2);
            this.checkBoxCompletada.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxCompletada.Name = "checkBoxCompletada";
            this.checkBoxCompletada.Size = new System.Drawing.Size(15, 14);
            this.checkBoxCompletada.TabIndex = 45;
            this.checkBoxCompletada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxCompletada.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.checkBoxCompletada.UseVisualStyleBackColor = true;
            this.checkBoxCompletada.CheckedChanged += new System.EventHandler(this.checkBoxCompletada_CheckedChanged);
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxDescripcion.Location = new System.Drawing.Point(19, -3);
            this.textBoxDescripcion.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxDescripcion.MaximumSize = new System.Drawing.Size(188, 16);
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxDescripcion.Size = new System.Drawing.Size(177, 25);
            this.textBoxDescripcion.TabIndex = 44;
            // 
            // buttonEliminarTarea
            // 
            this.buttonEliminarTarea.BackColor = System.Drawing.Color.Transparent;
            this.buttonEliminarTarea.FlatAppearance.BorderColor = System.Drawing.Color.CadetBlue;
            this.buttonEliminarTarea.FlatAppearance.BorderSize = 0;
            this.buttonEliminarTarea.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.buttonEliminarTarea.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.buttonEliminarTarea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEliminarTarea.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminarTarea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonEliminarTarea.Image = ((System.Drawing.Image)(resources.GetObject("buttonEliminarTarea.Image")));
            this.buttonEliminarTarea.Location = new System.Drawing.Point(224, -3);
            this.buttonEliminarTarea.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEliminarTarea.MaximumSize = new System.Drawing.Size(35, 16);
            this.buttonEliminarTarea.Name = "buttonEliminarTarea";
            this.buttonEliminarTarea.Size = new System.Drawing.Size(35, 16);
            this.buttonEliminarTarea.TabIndex = 46;
            this.buttonEliminarTarea.UseVisualStyleBackColor = false;
            this.buttonEliminarTarea.Click += new System.EventHandler(this.buttonEliminarTarea_Click);
            // 
            // UserControlCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(48)))), ((int)(((byte)(56)))));
            this.Controls.Add(this.checkBoxCompletada);
            this.Controls.Add(this.textBoxDescripcion);
            this.Controls.Add(this.buttonEliminarTarea);
            this.MaximumSize = new System.Drawing.Size(278, 14);
            this.Name = "UserControlCheck";
            this.Size = new System.Drawing.Size(254, 14);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxCompletada;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.Button buttonEliminarTarea;
    }
}
