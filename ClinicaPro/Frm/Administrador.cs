﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frm
{
    public partial class Administrador : Form
    {
        private int _IdTipoUsuario;
        public Administrador(int idTipoUsuario)
        {
            InitializeComponent();
            this._IdTipoUsuario = idTipoUsuario;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new MantenimientoUsuarios().Show();
        }

        private void Administrador_Load(object sender, EventArgs e)
        {

        }
    }
}
