using DAL;
using DAL.BAL;
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
        bool editMode = false;
        Usuarios _usuario;
        Action<DataTable> DoAction;
        public CreateUser(Usuarios usuario = null, Action<DataTable> action=null)
        {
            InitializeComponent();
            _usuario = usuario ?? new Usuarios();
            editMode = usuario != null;

            if (editMode)
                LoadData();

            DoAction = action;
        }

        private void LoadData()
        {
            txtNombre.Text = _usuario.Nombre;
           txtDui.Text = _usuario.DUI ;
           txtNit.Text = _usuario.NIT ;
           txtDireccion.Text = _usuario.Direccion;
            txtEmail.Text =_usuario.Email  ;
            txtUsuario.Text= _usuario.Usuario ;
            txtConfimar.Text ="";
            cbxRole.SelectedIndex = _usuario.IdRole-1;
            chbxHabilitado.Checked = _usuario.Habilitado == 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //todo-> Validar campos

            
            _usuario.Nombre = txtNombre.Text;
            _usuario.DUI = txtDui.Text;
            _usuario.NIT = txtNit.Text;
            _usuario.Direccion = txtDireccion.Text;
            _usuario.Email = txtEmail.Text;
            _usuario.Usuario = txtUsuario.Text;
            _usuario.HashPassword = txtConfimar.Text;
            _usuario.IdRole = cbxRole.SelectedIndex+1;
            _usuario.Habilitado =  chbxHabilitado.Checked ? (byte)1 :  (byte)0;

            if (!editMode)
                DbContext.Instance.Add(_usuario);
            else
                DbContext.Instance.Update(_usuario);

            DoAction?.Invoke(UsuariosBAL.Instance.GetAllUsuarios());
            this.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
