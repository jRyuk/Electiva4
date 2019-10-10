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
        public MainContainer()
        {
            InitializeComponent();
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

            }
        }

    }
}
