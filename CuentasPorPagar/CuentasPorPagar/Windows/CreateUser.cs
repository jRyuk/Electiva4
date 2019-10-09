using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CuentasPorPagar.Windows
{
    public partial class CreateUser : Form
    {
        public CreateUser()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //todo-> Validar campos

            var usuario = new Usuarios();
            usuario.Nombre = txtNombre.Text;
            usuario.DUI = txtDui.Text;
            usuario.NIT = txtNit.Text;
            usuario.Direccion = txtDireccion.Text;
            usuario.Email = txtEmail.Text;
            usuario.Usuario = txtUsuario.Text;
            usuario.HashPassword = txtConfimar.Text;
            usuario.IdRole = cbxRole.SelectedIndex+1;
            usuario.Habilitado =  chbxHabilitado.Checked ? (byte)1 :  (byte)0;

            DbContext.Instance.Add(usuario);

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
