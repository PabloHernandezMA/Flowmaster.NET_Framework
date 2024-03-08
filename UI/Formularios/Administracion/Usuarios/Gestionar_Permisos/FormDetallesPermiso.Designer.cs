namespace UI.Formularios.Administracion.Usuarios.Gestionar_Permisos
{
    partial class FormDetallesPermiso
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetallesPermiso));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewDisponibles = new System.Windows.Forms.DataGridView();
            this.dataGridViewAsociados = new System.Windows.Forms.DataGridView();
            this.treeViewPermisos = new System.Windows.Forms.TreeView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonQuitarPermiso = new System.Windows.Forms.Button();
            this.buttonDarPermiso = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.checkBoxSoloHabilitados = new System.Windows.Forms.CheckBox();
            this.checkBoxGrupos = new System.Windows.Forms.CheckBox();
            this.checkBoxUsuarios = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.labelPermiso = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisponibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAsociados)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(173)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1050, 61);
            this.panel1.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asignación de permisos";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.panel2.Controls.Add(this.buttonCancelar);
            this.panel2.Controls.Add(this.buttonGuardar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 596);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1050, 80);
            this.panel2.TabIndex = 24;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.buttonCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.buttonCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonCancelar.Location = new System.Drawing.Point(616, 20);
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
            this.buttonGuardar.Location = new System.Drawing.Point(748, 20);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(195, 43);
            this.buttonGuardar.TabIndex = 12;
            this.buttonGuardar.Text = "Guardar cambios";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(48)))), ((int)(((byte)(56)))));
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1050, 535);
            this.panel3.TabIndex = 25;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewDisponibles, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewAsociados, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.treeViewPermisos, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel8, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1050, 535);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 50);
            this.label2.TabIndex = 27;
            this.label2.Text = "Permisos:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewDisponibles
            // 
            this.dataGridViewDisponibles.AllowUserToAddRows = false;
            this.dataGridViewDisponibles.AllowUserToDeleteRows = false;
            this.dataGridViewDisponibles.AllowUserToOrderColumns = true;
            this.dataGridViewDisponibles.AllowUserToResizeRows = false;
            this.dataGridViewDisponibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDisponibles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.dataGridViewDisponibles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewDisponibles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDisponibles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDisponibles.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewDisponibles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDisponibles.EnableHeadersVisualStyles = false;
            this.dataGridViewDisponibles.GridColor = System.Drawing.Color.SteelBlue;
            this.dataGridViewDisponibles.Location = new System.Drawing.Point(435, 345);
            this.dataGridViewDisponibles.MultiSelect = false;
            this.dataGridViewDisponibles.Name = "dataGridViewDisponibles";
            this.dataGridViewDisponibles.ReadOnly = true;
            this.dataGridViewDisponibles.RowHeadersVisible = false;
            this.dataGridViewDisponibles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewDisponibles.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewDisponibles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDisponibles.Size = new System.Drawing.Size(612, 187);
            this.dataGridViewDisponibles.TabIndex = 18;
            // 
            // dataGridViewAsociados
            // 
            this.dataGridViewAsociados.AllowUserToAddRows = false;
            this.dataGridViewAsociados.AllowUserToDeleteRows = false;
            this.dataGridViewAsociados.AllowUserToOrderColumns = true;
            this.dataGridViewAsociados.AllowUserToResizeRows = false;
            this.dataGridViewAsociados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAsociados.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.dataGridViewAsociados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewAsociados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAsociados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewAsociados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAsociados.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewAsociados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAsociados.EnableHeadersVisualStyles = false;
            this.dataGridViewAsociados.GridColor = System.Drawing.Color.SteelBlue;
            this.dataGridViewAsociados.Location = new System.Drawing.Point(435, 103);
            this.dataGridViewAsociados.MultiSelect = false;
            this.dataGridViewAsociados.Name = "dataGridViewAsociados";
            this.dataGridViewAsociados.ReadOnly = true;
            this.dataGridViewAsociados.RowHeadersVisible = false;
            this.dataGridViewAsociados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewAsociados.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewAsociados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAsociados.Size = new System.Drawing.Size(612, 186);
            this.dataGridViewAsociados.TabIndex = 17;
            // 
            // treeViewPermisos
            // 
            this.treeViewPermisos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.treeViewPermisos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewPermisos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewPermisos.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.treeViewPermisos.LineColor = System.Drawing.Color.SteelBlue;
            this.treeViewPermisos.Location = new System.Drawing.Point(3, 103);
            this.treeViewPermisos.Name = "treeViewPermisos";
            this.tableLayoutPanel1.SetRowSpan(this.treeViewPermisos, 3);
            this.treeViewPermisos.Size = new System.Drawing.Size(406, 429);
            this.treeViewPermisos.TabIndex = 1;
            this.treeViewPermisos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewPermisos_AfterSelect);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.buttonQuitarPermiso);
            this.panel4.Controls.Add(this.buttonDarPermiso);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(435, 295);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(612, 44);
            this.panel4.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(310, 30);
            this.label3.TabIndex = 24;
            this.label3.Text = "Usuarios y Grupos sin permiso:";
            // 
            // buttonQuitarPermiso
            // 
            this.buttonQuitarPermiso.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.buttonQuitarPermiso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.buttonQuitarPermiso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuitarPermiso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonQuitarPermiso.Image = ((System.Drawing.Image)(resources.GetObject("buttonQuitarPermiso.Image")));
            this.buttonQuitarPermiso.Location = new System.Drawing.Point(537, 5);
            this.buttonQuitarPermiso.Name = "buttonQuitarPermiso";
            this.buttonQuitarPermiso.Size = new System.Drawing.Size(42, 33);
            this.buttonQuitarPermiso.TabIndex = 23;
            this.buttonQuitarPermiso.UseVisualStyleBackColor = true;
            this.buttonQuitarPermiso.Click += new System.EventHandler(this.buttonQuitarPermiso_Click);
            // 
            // buttonDarPermiso
            // 
            this.buttonDarPermiso.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.buttonDarPermiso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.buttonDarPermiso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDarPermiso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonDarPermiso.Image = ((System.Drawing.Image)(resources.GetObject("buttonDarPermiso.Image")));
            this.buttonDarPermiso.Location = new System.Drawing.Point(484, 5);
            this.buttonDarPermiso.Name = "buttonDarPermiso";
            this.buttonDarPermiso.Size = new System.Drawing.Size(42, 33);
            this.buttonDarPermiso.TabIndex = 22;
            this.buttonDarPermiso.UseVisualStyleBackColor = true;
            this.buttonDarPermiso.Click += new System.EventHandler(this.buttonDarPermiso_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(435, 53);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(612, 44);
            this.panel5.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label4.Location = new System.Drawing.Point(6, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(319, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "Usuarios y Grupos con permiso:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.checkBoxSoloHabilitados);
            this.panel6.Controls.Add(this.checkBoxGrupos);
            this.panel6.Controls.Add(this.checkBoxUsuarios);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(435, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(612, 44);
            this.panel6.TabIndex = 25;
            this.panel6.Visible = false;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 42);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(612, 2);
            this.panel7.TabIndex = 5;
            // 
            // checkBoxSoloHabilitados
            // 
            this.checkBoxSoloHabilitados.AutoSize = true;
            this.checkBoxSoloHabilitados.Enabled = false;
            this.checkBoxSoloHabilitados.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.checkBoxSoloHabilitados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.checkBoxSoloHabilitados.Location = new System.Drawing.Point(417, 6);
            this.checkBoxSoloHabilitados.Name = "checkBoxSoloHabilitados";
            this.checkBoxSoloHabilitados.Size = new System.Drawing.Size(189, 34);
            this.checkBoxSoloHabilitados.TabIndex = 4;
            this.checkBoxSoloHabilitados.Text = "Sólo Habilitados";
            this.checkBoxSoloHabilitados.UseVisualStyleBackColor = true;
            this.checkBoxSoloHabilitados.Visible = false;
            this.checkBoxSoloHabilitados.CheckedChanged += new System.EventHandler(this.FiltrarDataGridView);
            // 
            // checkBoxGrupos
            // 
            this.checkBoxGrupos.AutoSize = true;
            this.checkBoxGrupos.Checked = true;
            this.checkBoxGrupos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGrupos.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.checkBoxGrupos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.checkBoxGrupos.Location = new System.Drawing.Point(285, 6);
            this.checkBoxGrupos.Name = "checkBoxGrupos";
            this.checkBoxGrupos.Size = new System.Drawing.Size(102, 34);
            this.checkBoxGrupos.TabIndex = 3;
            this.checkBoxGrupos.Text = "Grupos";
            this.checkBoxGrupos.UseVisualStyleBackColor = true;
            this.checkBoxGrupos.CheckedChanged += new System.EventHandler(this.FiltrarDataGridView);
            // 
            // checkBoxUsuarios
            // 
            this.checkBoxUsuarios.AutoSize = true;
            this.checkBoxUsuarios.Checked = true;
            this.checkBoxUsuarios.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUsuarios.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.checkBoxUsuarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.checkBoxUsuarios.Location = new System.Drawing.Point(136, 6);
            this.checkBoxUsuarios.Name = "checkBoxUsuarios";
            this.checkBoxUsuarios.Size = new System.Drawing.Size(114, 34);
            this.checkBoxUsuarios.TabIndex = 2;
            this.checkBoxUsuarios.Text = "Usuarios";
            this.checkBoxUsuarios.UseVisualStyleBackColor = true;
            this.checkBoxUsuarios.CheckedChanged += new System.EventHandler(this.FiltrarDataGridView);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label5.Location = new System.Drawing.Point(10, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 30);
            this.label5.TabIndex = 1;
            this.label5.Text = "Mostrar:";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.labelPermiso);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(406, 44);
            this.panel8.TabIndex = 26;
            // 
            // labelPermiso
            // 
            this.labelPermiso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPermiso.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelPermiso.ForeColor = System.Drawing.Color.Goldenrod;
            this.labelPermiso.Location = new System.Drawing.Point(201, 0);
            this.labelPermiso.Name = "labelPermiso";
            this.labelPermiso.Size = new System.Drawing.Size(205, 44);
            this.labelPermiso.TabIndex = 23;
            this.labelPermiso.Text = "Nada seleccionado";
            this.labelPermiso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 44);
            this.label6.TabIndex = 22;
            this.label6.Text = "Permiso seleccionado:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormDetallesPermiso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 676);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDetallesPermiso";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDetallesPermiso";
            this.Load += new System.EventHandler(this.FormDetallesPermiso_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisponibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAsociados)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView treeViewPermisos;
        private System.Windows.Forms.DataGridView dataGridViewDisponibles;
        private System.Windows.Forms.DataGridView dataGridViewAsociados;
        private System.Windows.Forms.Button buttonDarPermiso;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonQuitarPermiso;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.CheckBox checkBoxSoloHabilitados;
        private System.Windows.Forms.CheckBox checkBoxGrupos;
        private System.Windows.Forms.CheckBox checkBoxUsuarios;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelPermiso;
    }
}