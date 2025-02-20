namespace UI.Formularios.Proyectos
{
    partial class FormDetalleTarjeta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxTitulo = new System.Windows.Forms.TextBox();
            this.comboBoxColumna = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.tabControlTarjeta = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonAddEdit = new System.Windows.Forms.Button();
            this.flowLayoutPanelTareas = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelProgresoTareas = new System.Windows.Forms.Label();
            this.progressBarTareas = new System.Windows.Forms.ProgressBar();
            this.textBoxDescTarjeta = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonEliminarEmpleado = new System.Windows.Forms.Button();
            this.buttonAgregarEmpleado = new System.Windows.Forms.Button();
            this.dataGridViewEmpleados = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControlTarjeta.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmpleados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(173)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.textBoxTitulo);
            this.panel1.Controls.Add(this.comboBoxColumna);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(746, 84);
            this.panel1.TabIndex = 25;
            // 
            // textBoxTitulo
            // 
            this.textBoxTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(173)))), ((int)(((byte)(64)))));
            this.textBoxTitulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold);
            this.textBoxTitulo.Location = new System.Drawing.Point(19, 8);
            this.textBoxTitulo.Name = "textBoxTitulo";
            this.textBoxTitulo.Size = new System.Drawing.Size(633, 39);
            this.textBoxTitulo.TabIndex = 31;
            this.textBoxTitulo.Text = "Titulo";
            // 
            // comboBoxColumna
            // 
            this.comboBoxColumna.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(173)))), ((int)(((byte)(64)))));
            this.comboBoxColumna.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxColumna.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxColumna.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxColumna.FormattingEnabled = true;
            this.comboBoxColumna.Location = new System.Drawing.Point(128, 53);
            this.comboBoxColumna.Name = "comboBoxColumna";
            this.comboBoxColumna.Size = new System.Drawing.Size(194, 25);
            this.comboBoxColumna.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.label2.Location = new System.Drawing.Point(19, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "En la columna:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.buttonGuardar);
            this.panel3.Controls.Add(this.buttonCancelar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 518);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(746, 64);
            this.panel3.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.button1.Location = new System.Drawing.Point(191, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 43);
            this.button1.TabIndex = 14;
            this.button1.Text = "Ocultar tarjeta";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.buttonGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuardar.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.buttonGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonGuardar.Location = new System.Drawing.Point(507, 9);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(195, 43);
            this.buttonGuardar.TabIndex = 12;
            this.buttonGuardar.Text = "Guardar cambios";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.buttonCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.buttonCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonCancelar.Location = new System.Drawing.Point(365, 9);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(126, 43);
            this.buttonCancelar.TabIndex = 13;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // tabControlTarjeta
            // 
            this.tabControlTarjeta.Controls.Add(this.tabPage1);
            this.tabControlTarjeta.Controls.Add(this.tabPage2);
            this.tabControlTarjeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTarjeta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tabControlTarjeta.Location = new System.Drawing.Point(0, 84);
            this.tabControlTarjeta.Name = "tabControlTarjeta";
            this.tabControlTarjeta.SelectedIndex = 0;
            this.tabControlTarjeta.Size = new System.Drawing.Size(746, 434);
            this.tabControlTarjeta.TabIndex = 27;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(48)))), ((int)(((byte)(56)))));
            this.tabPage1.Controls.Add(this.buttonAddEdit);
            this.tabPage1.Controls.Add(this.flowLayoutPanelTareas);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.labelProgresoTareas);
            this.tabPage1.Controls.Add(this.progressBarTareas);
            this.tabPage1.Controls.Add(this.textBoxDescTarjeta);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(738, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Detalles";
            // 
            // buttonAddEdit
            // 
            this.buttonAddEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAddEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonAddEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.buttonAddEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(31)))));
            this.buttonAddEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.buttonAddEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonAddEdit.Location = new System.Drawing.Point(135, 222);
            this.buttonAddEdit.Name = "buttonAddEdit";
            this.buttonAddEdit.Size = new System.Drawing.Size(70, 31);
            this.buttonAddEdit.TabIndex = 29;
            this.buttonAddEdit.Text = "Agregar";
            this.buttonAddEdit.UseVisualStyleBackColor = true;
            this.buttonAddEdit.Click += new System.EventHandler(this.buttonAddEdit_Click);
            // 
            // flowLayoutPanelTareas
            // 
            this.flowLayoutPanelTareas.AutoSize = true;
            this.flowLayoutPanelTareas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(48)))), ((int)(((byte)(56)))));
            this.flowLayoutPanelTareas.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelTareas.Location = new System.Drawing.Point(15, 259);
            this.flowLayoutPanelTareas.MinimumSize = new System.Drawing.Size(327, 123);
            this.flowLayoutPanelTareas.Name = "flowLayoutPanelTareas";
            this.flowLayoutPanelTareas.Padding = new System.Windows.Forms.Padding(0, 5, 15, 5);
            this.flowLayoutPanelTareas.Size = new System.Drawing.Size(327, 123);
            this.flowLayoutPanelTareas.TabIndex = 33;
            this.flowLayoutPanelTareas.WrapContents = false;
            this.flowLayoutPanelTareas.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.flowLayoutPanelTareas_ControlRemoved);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label1.Location = new System.Drawing.Point(11, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 21);
            this.label1.TabIndex = 28;
            this.label1.Text = "Lista de tareas:";
            // 
            // labelProgresoTareas
            // 
            this.labelProgresoTareas.AutoSize = true;
            this.labelProgresoTareas.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelProgresoTareas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.labelProgresoTareas.Location = new System.Drawing.Point(409, 226);
            this.labelProgresoTareas.Name = "labelProgresoTareas";
            this.labelProgresoTareas.Size = new System.Drawing.Size(110, 21);
            this.labelProgresoTareas.TabIndex = 32;
            this.labelProgresoTareas.Text = "Progreso: 0/0";
            // 
            // progressBarTareas
            // 
            this.progressBarTareas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(187)))), ((int)(((byte)(23)))));
            this.progressBarTareas.Location = new System.Drawing.Point(525, 226);
            this.progressBarTareas.Name = "progressBarTareas";
            this.progressBarTareas.Size = new System.Drawing.Size(173, 23);
            this.progressBarTareas.TabIndex = 31;
            // 
            // textBoxDescTarjeta
            // 
            this.textBoxDescTarjeta.Location = new System.Drawing.Point(15, 53);
            this.textBoxDescTarjeta.Multiline = true;
            this.textBoxDescTarjeta.Name = "textBoxDescTarjeta";
            this.textBoxDescTarjeta.Size = new System.Drawing.Size(683, 161);
            this.textBoxDescTarjeta.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label9.Location = new System.Drawing.Point(11, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 21);
            this.label9.TabIndex = 25;
            this.label9.Text = "Descripcion:";
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(48)))), ((int)(((byte)(56)))));
            this.tabPage2.Controls.Add(this.buttonEliminarEmpleado);
            this.tabPage2.Controls.Add(this.buttonAgregarEmpleado);
            this.tabPage2.Controls.Add(this.dataGridViewEmpleados);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(738, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Asignacion";
            // 
            // buttonEliminarEmpleado
            // 
            this.buttonEliminarEmpleado.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonEliminarEmpleado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.buttonEliminarEmpleado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(31)))));
            this.buttonEliminarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEliminarEmpleado.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.buttonEliminarEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonEliminarEmpleado.Location = new System.Drawing.Point(478, 111);
            this.buttonEliminarEmpleado.Name = "buttonEliminarEmpleado";
            this.buttonEliminarEmpleado.Size = new System.Drawing.Size(170, 35);
            this.buttonEliminarEmpleado.TabIndex = 20;
            this.buttonEliminarEmpleado.Text = "Eliminar";
            this.buttonEliminarEmpleado.UseVisualStyleBackColor = true;
            // 
            // buttonAgregarEmpleado
            // 
            this.buttonAgregarEmpleado.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonAgregarEmpleado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.buttonAgregarEmpleado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(31)))));
            this.buttonAgregarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAgregarEmpleado.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.buttonAgregarEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonAgregarEmpleado.Location = new System.Drawing.Point(478, 57);
            this.buttonAgregarEmpleado.Name = "buttonAgregarEmpleado";
            this.buttonAgregarEmpleado.Size = new System.Drawing.Size(170, 35);
            this.buttonAgregarEmpleado.TabIndex = 19;
            this.buttonAgregarEmpleado.Text = "Agregar";
            this.buttonAgregarEmpleado.UseVisualStyleBackColor = true;
            // 
            // dataGridViewEmpleados
            // 
            this.dataGridViewEmpleados.AllowUserToAddRows = false;
            this.dataGridViewEmpleados.AllowUserToDeleteRows = false;
            this.dataGridViewEmpleados.AllowUserToOrderColumns = true;
            this.dataGridViewEmpleados.AllowUserToResizeRows = false;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(39)))), ((int)(((byte)(61)))));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewEmpleados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEmpleados.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.dataGridViewEmpleados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewEmpleados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle22.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEmpleados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridViewEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEmpleados.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridViewEmpleados.EnableHeadersVisualStyles = false;
            this.dataGridViewEmpleados.GridColor = System.Drawing.Color.SteelBlue;
            this.dataGridViewEmpleados.Location = new System.Drawing.Point(19, 57);
            this.dataGridViewEmpleados.MultiSelect = false;
            this.dataGridViewEmpleados.Name = "dataGridViewEmpleados";
            this.dataGridViewEmpleados.ReadOnly = true;
            this.dataGridViewEmpleados.RowHeadersVisible = false;
            this.dataGridViewEmpleados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewEmpleados.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridViewEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEmpleados.Size = new System.Drawing.Size(386, 201);
            this.dataGridViewEmpleados.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label10.Location = new System.Drawing.Point(15, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 21);
            this.label10.TabIndex = 17;
            this.label10.Text = "Empleados asignados:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormDetalleTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 582);
            this.ControlBox = false;
            this.Controls.Add(this.tabControlTarjeta);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "FormDetalleTarjeta";
            this.ShowIcon = false;
            this.Text = "DetalleTarjeta";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tabControlTarjeta.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmpleados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.ComboBox comboBoxColumna;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControlTarjeta;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBoxDescTarjeta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonEliminarEmpleado;
        private System.Windows.Forms.Button buttonAgregarEmpleado;
        private System.Windows.Forms.DataGridView dataGridViewEmpleados;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxTitulo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddEdit;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ProgressBar progressBarTareas;
        private System.Windows.Forms.Label labelProgresoTareas;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTareas;
    }
}