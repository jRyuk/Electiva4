using CuentasPorPagar.Windows.Documentos;
using CuentasPorPagar.Windows.Pagos;
using CuentasPorPagar.Windows.Proveedores;
using DAL.BAL;
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
    public partial class MainContainer : Form
    {
        Form _loginForm;

        public MainContainer()
        {
            InitializeComponent();
        }

        public MainContainer(Form form)
        {
            InitializeComponent();
            _loginForm = form;
        }

        private void MainContainer_Load(object sender, EventArgs e)
        {
            txtUser.Text = $"¡Bienvenido! {Login.Instance.LoginInfo.Nombre}";
            LoadMenu();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainAdmin mainAdmin = new MainAdmin(this);
            mainAdmin.MdiParent = this;
            mainAdmin.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainAdmin = new MainProveedores(this);
            mainAdmin.MdiParent = this;
            mainAdmin.Show();
        }

        private void documentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainDocuments = new  MainDocuments(this);
            mainDocuments.MdiParent = this;
            mainDocuments.Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _loginForm.Show();
            this.Close();
        }

        private void pagosAdmin(object sender, EventArgs e)
        {
            var mainPagos = new MainPagos();
            mainPagos.MdiParent = this;
            mainPagos.Show();
        }


        private void LoadMenu()
        {

            switch (Login.Instance.LoginInfo.IdRole)
            {
                case 1:

                    var menuUsuarios = new ToolStripMenuItem("Administrar usuarios", null, usuariosToolStripMenuItem_Click);
                    administrarToolStripMenuItem.DropDownItems.Add(menuUsuarios);
                    var menuProveedores = new ToolStripMenuItem("Administrar proveedores", null, proveedoresToolStripMenuItem_Click);
                    administrarToolStripMenuItem.DropDownItems.Add(menuProveedores);
                    break;
                case 2:
                    var menuDocumentos = new ToolStripMenuItem("Administrar Documentos", null, documentosToolStripMenuItem_Click);
                    administrarToolStripMenuItem.DropDownItems.Add(menuDocumentos);
                    break;
                case 3:
                    var menuPagos = new ToolStripMenuItem("Administrar pagos", null, pagosAdmin);
                    administrarToolStripMenuItem.DropDownItems.Add(menuPagos);
                    break;

            }


            var cerrarSesion = new ToolStripMenuItem("Cerrar sesion", null, cerrarSesionToolStripMenuItem_Click);
            administrarToolStripMenuItem.DropDownItems.Add(cerrarSesion);

        }

    }
}
