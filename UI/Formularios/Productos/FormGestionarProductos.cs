﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Productos
{
    public partial class FormGestionarProductos : Form
    {
        private static FormGestionarProductos instance;

        private FormGestionarProductos()
        {
            InitializeComponent();
        }

        public static FormGestionarProductos GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FormGestionarProductos();
            }
            return instance;
        }
    }
}
