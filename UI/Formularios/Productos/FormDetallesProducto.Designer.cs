﻿namespace UI.Formularios.Productos
{
    partial class FormDetallesProducto
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelNumeroID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBoxTipo = new System.Windows.Forms.ComboBox();
            this.comboBoxCategoria = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxHabilitado = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxStockMinimo = new System.Windows.Forms.TextBox();
            this.textBoxExistencias = new System.Windows.Forms.TextBox();
            this.labelExistencias = new System.Windows.Forms.Label();
            this.textBoxPrecioVenta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxProveedor = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.panel2.Controls.Add(this.buttonCancelar);
            this.panel2.Controls.Add(this.buttonGuardar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 475);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(698, 80);
            this.panel2.TabIndex = 3;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.buttonCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.buttonCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonCancelar.Location = new System.Drawing.Point(348, 16);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(126, 43);
            this.buttonCancelar.TabIndex = 13;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.buttonGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuardar.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.buttonGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonGuardar.Location = new System.Drawing.Point(480, 16);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(195, 43);
            this.buttonGuardar.TabIndex = 12;
            this.buttonGuardar.Text = "Guardar cambios";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(173)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.labelNumeroID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(698, 61);
            this.panel1.TabIndex = 2;
            // 
            // labelNumeroID
            // 
            this.labelNumeroID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumeroID.Location = new System.Drawing.Point(528, 24);
            this.labelNumeroID.Name = "labelNumeroID";
            this.labelNumeroID.Size = new System.Drawing.Size(158, 23);
            this.labelNumeroID.TabIndex = 2;
            this.labelNumeroID.Text = "0000001";
            this.labelNumeroID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.label2.Location = new System.Drawing.Point(439, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Número:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detalle de producto";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(48)))), ((int)(((byte)(56)))));
            this.panel3.Controls.Add(this.comboBoxProveedor);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.textBoxPrecioVenta);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.textBoxExistencias);
            this.panel3.Controls.Add(this.labelExistencias);
            this.panel3.Controls.Add(this.textBoxStockMinimo);
            this.panel3.Controls.Add(this.comboBoxTipo);
            this.panel3.Controls.Add(this.comboBoxCategoria);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.checkBoxHabilitado);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.textBoxNombre);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(698, 414);
            this.panel3.TabIndex = 4;
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.Location = new System.Drawing.Point(113, 97);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(237, 29);
            this.comboBoxTipo.TabIndex = 30;
            // 
            // comboBoxCategoria
            // 
            this.comboBoxCategoria.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboBoxCategoria.FormattingEnabled = true;
            this.comboBoxCategoria.Location = new System.Drawing.Point(113, 141);
            this.comboBoxCategoria.Name = "comboBoxCategoria";
            this.comboBoxCategoria.Size = new System.Drawing.Size(237, 29);
            this.comboBoxCategoria.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label5.Location = new System.Drawing.Point(394, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 21);
            this.label5.TabIndex = 27;
            this.label5.Text = "Stock minimo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label3.Location = new System.Drawing.Point(15, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 21);
            this.label3.TabIndex = 26;
            this.label3.Text = "Tipo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label6.Location = new System.Drawing.Point(15, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 21);
            this.label6.TabIndex = 25;
            this.label6.Text = "Categoría:";
            // 
            // checkBoxHabilitado
            // 
            this.checkBoxHabilitado.AutoSize = true;
            this.checkBoxHabilitado.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.checkBoxHabilitado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.checkBoxHabilitado.Location = new System.Drawing.Point(24, 374);
            this.checkBoxHabilitado.Name = "checkBoxHabilitado";
            this.checkBoxHabilitado.Size = new System.Drawing.Size(131, 34);
            this.checkBoxHabilitado.TabIndex = 24;
            this.checkBoxHabilitado.Text = "Habilitado";
            this.checkBoxHabilitado.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label4.Location = new System.Drawing.Point(14, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 30);
            this.label4.TabIndex = 22;
            this.label4.Text = "Nombre:";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.textBoxNombre.Location = new System.Drawing.Point(19, 46);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(651, 32);
            this.textBoxNombre.TabIndex = 23;
            // 
            // textBoxStockMinimo
            // 
            this.textBoxStockMinimo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxStockMinimo.Location = new System.Drawing.Point(514, 186);
            this.textBoxStockMinimo.Name = "textBoxStockMinimo";
            this.textBoxStockMinimo.Size = new System.Drawing.Size(83, 29);
            this.textBoxStockMinimo.TabIndex = 31;
            // 
            // textBoxExistencias
            // 
            this.textBoxExistencias.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxExistencias.Location = new System.Drawing.Point(514, 140);
            this.textBoxExistencias.Name = "textBoxExistencias";
            this.textBoxExistencias.Size = new System.Drawing.Size(83, 29);
            this.textBoxExistencias.TabIndex = 33;
            // 
            // labelExistencias
            // 
            this.labelExistencias.AutoSize = true;
            this.labelExistencias.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelExistencias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.labelExistencias.Location = new System.Drawing.Point(394, 146);
            this.labelExistencias.Name = "labelExistencias";
            this.labelExistencias.Size = new System.Drawing.Size(92, 21);
            this.labelExistencias.TabIndex = 32;
            this.labelExistencias.Text = "Existencias:";
            // 
            // textBoxPrecioVenta
            // 
            this.textBoxPrecioVenta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxPrecioVenta.Location = new System.Drawing.Point(514, 97);
            this.textBoxPrecioVenta.Name = "textBoxPrecioVenta";
            this.textBoxPrecioVenta.Size = new System.Drawing.Size(156, 29);
            this.textBoxPrecioVenta.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label7.Location = new System.Drawing.Point(381, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 21);
            this.label7.TabIndex = 34;
            this.label7.Text = "Precio de venta:";
            // 
            // comboBoxProveedor
            // 
            this.comboBoxProveedor.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboBoxProveedor.FormattingEnabled = true;
            this.comboBoxProveedor.Location = new System.Drawing.Point(113, 186);
            this.comboBoxProveedor.Name = "comboBoxProveedor";
            this.comboBoxProveedor.Size = new System.Drawing.Size(237, 29);
            this.comboBoxProveedor.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label8.Location = new System.Drawing.Point(15, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 21);
            this.label8.TabIndex = 36;
            this.label8.Text = "Proveedor:";
            // 
            // FormDetallesProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 555);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDetallesProducto";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDetallesProducto";
            this.Load += new System.EventHandler(this.FormDetallesProducto_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelNumeroID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkBoxHabilitado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.ComboBox comboBoxTipo;
        private System.Windows.Forms.ComboBox comboBoxCategoria;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPrecioVenta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxExistencias;
        private System.Windows.Forms.Label labelExistencias;
        private System.Windows.Forms.TextBox textBoxStockMinimo;
        private System.Windows.Forms.ComboBox comboBoxProveedor;
        private System.Windows.Forms.Label label8;
    }
}