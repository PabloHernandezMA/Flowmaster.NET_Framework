namespace UI.Formularios.Administracion.Gerencia
{
    partial class FormReporteProyectos
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reporteProyectosProgresoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonGenerar = new System.Windows.Forms.Button();
            this.comboBoxEstadoProyecto = new System.Windows.Forms.ComboBox();
            this.dateTimePickerFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.reportViewerProyectos = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.reporteProyectosProgresoBindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reporteProyectosProgresoBindingSource
            // 
            this.reporteProyectosProgresoBindingSource.DataSource = typeof(Modelo.Aplicacion.ReporteProyectosProgreso);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 50);
            this.panel3.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "Reporte de proyectos";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonGenerar);
            this.panel1.Controls.Add(this.comboBoxEstadoProyecto);
            this.panel1.Controls.Add(this.dateTimePickerFechaInicio);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 140);
            this.panel1.TabIndex = 53;
            // 
            // buttonGenerar
            // 
            this.buttonGenerar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonGenerar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.buttonGenerar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerar.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.buttonGenerar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonGenerar.Location = new System.Drawing.Point(369, 42);
            this.buttonGenerar.Name = "buttonGenerar";
            this.buttonGenerar.Size = new System.Drawing.Size(195, 43);
            this.buttonGenerar.TabIndex = 59;
            this.buttonGenerar.Text = "Generar reporte";
            this.buttonGenerar.UseVisualStyleBackColor = true;
            this.buttonGenerar.Click += new System.EventHandler(this.buttonGenerar_Click_1);
            // 
            // comboBoxEstadoProyecto
            // 
            this.comboBoxEstadoProyecto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(41)))));
            this.comboBoxEstadoProyecto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxEstadoProyecto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboBoxEstadoProyecto.ForeColor = System.Drawing.SystemColors.Window;
            this.comboBoxEstadoProyecto.FormattingEnabled = true;
            this.comboBoxEstadoProyecto.Items.AddRange(new object[] {
            "Todos",
            "En proceso",
            "Terminado",
            "Pausado",
            "Cancelado"});
            this.comboBoxEstadoProyecto.Location = new System.Drawing.Point(105, 52);
            this.comboBoxEstadoProyecto.Name = "comboBoxEstadoProyecto";
            this.comboBoxEstadoProyecto.Size = new System.Drawing.Size(191, 29);
            this.comboBoxEstadoProyecto.TabIndex = 58;
            // 
            // dateTimePickerFechaInicio
            // 
            this.dateTimePickerFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFechaInicio.Location = new System.Drawing.Point(117, 100);
            this.dateTimePickerFechaInicio.Name = "dateTimePickerFechaInicio";
            this.dateTimePickerFechaInicio.Size = new System.Drawing.Size(140, 26);
            this.dateTimePickerFechaInicio.TabIndex = 55;
            this.dateTimePickerFechaInicio.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label8.Location = new System.Drawing.Point(12, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 21);
            this.label8.TabIndex = 54;
            this.label8.Text = "Fecha desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 21);
            this.label2.TabIndex = 53;
            this.label2.Text = "Estado:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label6.Location = new System.Drawing.Point(7, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(787, 45);
            this.label6.TabIndex = 52;
            this.label6.Text = "Mostrar el progreso de los proyectos segun su cantidad y estado de tareas";
            // 
            // reportViewerProyectos
            // 
            this.reportViewerProyectos.Dock = System.Windows.Forms.DockStyle.Left;
            reportDataSource1.Name = "DataSetProyectos";
            reportDataSource1.Value = this.reporteProyectosProgresoBindingSource;
            this.reportViewerProyectos.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerProyectos.LocalReport.ReportEmbeddedResource = "UI.Formularios.Administracion.Gerencia.Reportes.ReportProyectosXEmpleado.rdlc";
            this.reportViewerProyectos.Location = new System.Drawing.Point(0, 190);
            this.reportViewerProyectos.Name = "reportViewerProyectos";
            this.reportViewerProyectos.ServerReport.BearerToken = null;
            this.reportViewerProyectos.Size = new System.Drawing.Size(771, 513);
            this.reportViewerProyectos.TabIndex = 54;
            // 
            // FormReporteProyectos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(800, 703);
            this.Controls.Add(this.reportViewerProyectos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "FormReporteProyectos";
            this.Text = "FormReporteProyectos";
            this.Load += new System.EventHandler(this.FormReporteProyectos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reporteProyectosProgresoBindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonGenerar;
        private System.Windows.Forms.ComboBox comboBoxEstadoProyecto;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaInicio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerProyectos;
        private System.Windows.Forms.BindingSource reporteProyectosProgresoBindingSource;
    }
}