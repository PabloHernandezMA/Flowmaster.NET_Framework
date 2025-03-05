namespace UI.Formularios.Administracion.Gerencia
{
    partial class FormAuditoriaSesiones
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxEmpleado = new System.Windows.Forms.CheckBox();
            this.comboBoxEmpleado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGenerar = new System.Windows.Forms.Button();
            this.dateTimePickerFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.reportViewerSesiones = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewerSesionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportViewerSesionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxEmpleado);
            this.panel1.Controls.Add(this.comboBoxEmpleado);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePickerFechaFin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonGenerar);
            this.panel1.Controls.Add(this.dateTimePickerFechaInicio);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 170);
            this.panel1.TabIndex = 57;
            // 
            // checkBoxEmpleado
            // 
            this.checkBoxEmpleado.AutoSize = true;
            this.checkBoxEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxEmpleado.Location = new System.Drawing.Point(360, 133);
            this.checkBoxEmpleado.Name = "checkBoxEmpleado";
            this.checkBoxEmpleado.Size = new System.Drawing.Size(12, 11);
            this.checkBoxEmpleado.TabIndex = 65;
            this.checkBoxEmpleado.UseVisualStyleBackColor = true;
            this.checkBoxEmpleado.CheckedChanged += new System.EventHandler(this.checkBoxEmpleado_CheckedChanged);
            // 
            // comboBoxEmpleado
            // 
            this.comboBoxEmpleado.Enabled = false;
            this.comboBoxEmpleado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboBoxEmpleado.FormattingEnabled = true;
            this.comboBoxEmpleado.Location = new System.Drawing.Point(117, 120);
            this.comboBoxEmpleado.Name = "comboBoxEmpleado";
            this.comboBoxEmpleado.Size = new System.Drawing.Size(237, 29);
            this.comboBoxEmpleado.TabIndex = 64;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label2.Location = new System.Drawing.Point(29, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 21);
            this.label2.TabIndex = 63;
            this.label2.Text = "Empleado:";
            // 
            // dateTimePickerFechaFin
            // 
            this.dateTimePickerFechaFin.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePickerFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFechaFin.Location = new System.Drawing.Point(117, 85);
            this.dateTimePickerFechaFin.Name = "dateTimePickerFechaFin";
            this.dateTimePickerFechaFin.Size = new System.Drawing.Size(172, 26);
            this.dateTimePickerFechaFin.TabIndex = 61;
            this.dateTimePickerFechaFin.Value = new System.DateTime(2025, 3, 1, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label1.Location = new System.Drawing.Point(17, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 21);
            this.label1.TabIndex = 60;
            this.label1.Text = "Fecha hasta:";
            // 
            // buttonGenerar
            // 
            this.buttonGenerar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonGenerar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.buttonGenerar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonGenerar.Location = new System.Drawing.Point(396, 116);
            this.buttonGenerar.Name = "buttonGenerar";
            this.buttonGenerar.Size = new System.Drawing.Size(163, 34);
            this.buttonGenerar.TabIndex = 59;
            this.buttonGenerar.Text = "Generar documento";
            this.buttonGenerar.UseVisualStyleBackColor = true;
            this.buttonGenerar.Click += new System.EventHandler(this.buttonGenerar_Click);
            // 
            // dateTimePickerFechaInicio
            // 
            this.dateTimePickerFechaInicio.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePickerFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFechaInicio.Location = new System.Drawing.Point(117, 50);
            this.dateTimePickerFechaInicio.Name = "dateTimePickerFechaInicio";
            this.dateTimePickerFechaInicio.Size = new System.Drawing.Size(172, 26);
            this.dateTimePickerFechaInicio.TabIndex = 55;
            this.dateTimePickerFechaInicio.Value = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label8.Location = new System.Drawing.Point(12, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 21);
            this.label8.TabIndex = 54;
            this.label8.Text = "Fecha desde:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label6.Location = new System.Drawing.Point(7, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(787, 30);
            this.label6.TabIndex = 52;
            this.label6.Text = "Auditoria de inicios y cierres de sesión";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(837, 50);
            this.panel3.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "Auditoria de sesiones";
            // 
            // reportViewerSesiones
            // 
            this.reportViewerSesiones.Dock = System.Windows.Forms.DockStyle.Left;
            this.reportViewerSesiones.LocalReport.ReportEmbeddedResource = "UI.Formularios.Administracion.Gerencia.Reportes.ReportAuditoriaSesiones.rdlc";
            this.reportViewerSesiones.Location = new System.Drawing.Point(0, 220);
            this.reportViewerSesiones.Name = "reportViewerSesiones";
            this.reportViewerSesiones.ServerReport.BearerToken = null;
            this.reportViewerSesiones.Size = new System.Drawing.Size(794, 327);
            this.reportViewerSesiones.TabIndex = 58;
            // 
            // FormAuditoriaSesiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(837, 547);
            this.Controls.Add(this.reportViewerSesiones);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "FormAuditoriaSesiones";
            this.Text = "FormAuditoriaSesiones";
            this.Load += new System.EventHandler(this.FormAuditoriaSesiones_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportViewerSesionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGenerar;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaInicio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxEmpleado;
        private System.Windows.Forms.CheckBox checkBoxEmpleado;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerSesiones;
        private System.Windows.Forms.BindingSource reportViewerSesionesBindingSource;
    }
}