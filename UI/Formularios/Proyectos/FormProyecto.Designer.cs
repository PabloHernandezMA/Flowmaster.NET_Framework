namespace UI.Formularios.Proyectos
{
    partial class FormProyecto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProyecto));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dateTimePickerFechaFinProyecto = new System.Windows.Forms.DateTimePicker();
            this.buttonVerDetalles = new System.Windows.Forms.Button();
            this.comboBoxEstadoProyecto = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNombreProyecto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanelTablero = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAgregarColumna = new System.Windows.Forms.Button();
            this.userControlColumna1 = new UI.Formularios.Proyectos.UserControlColumna();
            this.userControlColumna2 = new UI.Formularios.Proyectos.UserControlColumna();
            this.userControlColumna3 = new UI.Formularios.Proyectos.UserControlColumna();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowLayoutPanelTablero.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(41)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 100);
            this.panel1.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dateTimePickerFechaFinProyecto);
            this.panel3.Controls.Add(this.buttonVerDetalles);
            this.panel3.Controls.Add(this.comboBoxEstadoProyecto);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.textBoxNombreProyecto);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(171, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(719, 100);
            this.panel3.TabIndex = 14;
            // 
            // dateTimePickerFechaFinProyecto
            // 
            this.dateTimePickerFechaFinProyecto.CalendarFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFechaFinProyecto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dateTimePickerFechaFinProyecto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFechaFinProyecto.Location = new System.Drawing.Point(101, 54);
            this.dateTimePickerFechaFinProyecto.Name = "dateTimePickerFechaFinProyecto";
            this.dateTimePickerFechaFinProyecto.Size = new System.Drawing.Size(130, 29);
            this.dateTimePickerFechaFinProyecto.TabIndex = 32;
            // 
            // buttonVerDetalles
            // 
            this.buttonVerDetalles.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonVerDetalles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.buttonVerDetalles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(31)))));
            this.buttonVerDetalles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVerDetalles.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.buttonVerDetalles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonVerDetalles.Location = new System.Drawing.Point(517, 50);
            this.buttonVerDetalles.Name = "buttonVerDetalles";
            this.buttonVerDetalles.Size = new System.Drawing.Size(128, 40);
            this.buttonVerDetalles.TabIndex = 31;
            this.buttonVerDetalles.Text = "Ver detalles";
            this.buttonVerDetalles.UseVisualStyleBackColor = true;
            // 
            // comboBoxEstadoProyecto
            // 
            this.comboBoxEstadoProyecto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(41)))));
            this.comboBoxEstadoProyecto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxEstadoProyecto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboBoxEstadoProyecto.FormattingEnabled = true;
            this.comboBoxEstadoProyecto.Items.AddRange(new object[] {
            "En proceso",
            "Terminado",
            "Pausado",
            "Cancelado"});
            this.comboBoxEstadoProyecto.Location = new System.Drawing.Point(455, 15);
            this.comboBoxEstadoProyecto.Name = "comboBoxEstadoProyecto";
            this.comboBoxEstadoProyecto.Size = new System.Drawing.Size(191, 29);
            this.comboBoxEstadoProyecto.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label4.Location = new System.Drawing.Point(386, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 21);
            this.label4.TabIndex = 26;
            this.label4.Text = "Estado:";
            // 
            // textBoxNombreProyecto
            // 
            this.textBoxNombreProyecto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(41)))));
            this.textBoxNombreProyecto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNombreProyecto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxNombreProyecto.Location = new System.Drawing.Point(101, 19);
            this.textBoxNombreProyecto.Name = "textBoxNombreProyecto";
            this.textBoxNombreProyecto.Size = new System.Drawing.Size(222, 22);
            this.textBoxNombreProyecto.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label2.Location = new System.Drawing.Point(14, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 21);
            this.label2.TabIndex = 14;
            this.label2.Text = "Fecha Fin:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 21);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nombre:";
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 100);
            this.label6.TabIndex = 13;
            this.label6.Text = "Proyecto";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanelTablero
            // 
            this.flowLayoutPanelTablero.AllowDrop = true;
            this.flowLayoutPanelTablero.AutoScroll = true;
            this.flowLayoutPanelTablero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.flowLayoutPanelTablero.Controls.Add(this.userControlColumna1);
            this.flowLayoutPanelTablero.Controls.Add(this.userControlColumna2);
            this.flowLayoutPanelTablero.Controls.Add(this.buttonAgregarColumna);
            this.flowLayoutPanelTablero.Controls.Add(this.userControlColumna3);
            this.flowLayoutPanelTablero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelTablero.Location = new System.Drawing.Point(0, 100);
            this.flowLayoutPanelTablero.Name = "flowLayoutPanelTablero";
            this.flowLayoutPanelTablero.Padding = new System.Windows.Forms.Padding(10, 17, 10, 17);
            this.flowLayoutPanelTablero.Size = new System.Drawing.Size(984, 466);
            this.flowLayoutPanelTablero.TabIndex = 9;
            this.flowLayoutPanelTablero.WrapContents = false;
            // 
            // buttonAgregarColumna
            // 
            this.buttonAgregarColumna.BackColor = System.Drawing.Color.Transparent;
            this.buttonAgregarColumna.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAgregarColumna.FlatAppearance.BorderColor = System.Drawing.Color.CadetBlue;
            this.buttonAgregarColumna.FlatAppearance.BorderSize = 2;
            this.buttonAgregarColumna.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.buttonAgregarColumna.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.buttonAgregarColumna.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAgregarColumna.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgregarColumna.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonAgregarColumna.Image = ((System.Drawing.Image)(resources.GetObject("buttonAgregarColumna.Image")));
            this.buttonAgregarColumna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAgregarColumna.Location = new System.Drawing.Point(495, 17);
            this.buttonAgregarColumna.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonAgregarColumna.Name = "buttonAgregarColumna";
            this.buttonAgregarColumna.Size = new System.Drawing.Size(225, 44);
            this.buttonAgregarColumna.TabIndex = 2;
            this.buttonAgregarColumna.Text = "Agregar columna        ";
            this.buttonAgregarColumna.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAgregarColumna.UseVisualStyleBackColor = false;
            // 
            // userControlColumna1
            // 
            this.userControlColumna1.AutoSize = true;
            this.userControlColumna1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.userControlColumna1.Location = new System.Drawing.Point(17, 17);
            this.userControlColumna1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.userControlColumna1.Name = "userControlColumna1";
            this.userControlColumna1.Size = new System.Drawing.Size(225, 298);
            this.userControlColumna1.TabIndex = 3;
            // 
            // userControlColumna2
            // 
            this.userControlColumna2.AutoSize = true;
            this.userControlColumna2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.userControlColumna2.Location = new System.Drawing.Point(256, 17);
            this.userControlColumna2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.userControlColumna2.Name = "userControlColumna2";
            this.userControlColumna2.Size = new System.Drawing.Size(225, 298);
            this.userControlColumna2.TabIndex = 4;
            // 
            // userControlColumna3
            // 
            this.userControlColumna3.AutoSize = true;
            this.userControlColumna3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.userControlColumna3.Location = new System.Drawing.Point(734, 17);
            this.userControlColumna3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.userControlColumna3.Name = "userControlColumna3";
            this.userControlColumna3.Size = new System.Drawing.Size(225, 298);
            this.userControlColumna3.TabIndex = 5;
            // 
            // FormProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 566);
            this.Controls.Add(this.flowLayoutPanelTablero);
            this.Controls.Add(this.panel1);
            this.Name = "FormProyecto";
            this.Text = "FormProyecto";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.flowLayoutPanelTablero.ResumeLayout(false);
            this.flowLayoutPanelTablero.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonVerDetalles;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTablero;
        private System.Windows.Forms.Button buttonAgregarColumna;
        private UserControlColumna userControlColumna1;
        private UserControlColumna userControlColumna2;
        private UserControlColumna userControlColumna3;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaFinProyecto;
        private System.Windows.Forms.ComboBox comboBoxEstadoProyecto;
        private System.Windows.Forms.TextBox textBoxNombreProyecto;
    }
}