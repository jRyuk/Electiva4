﻿using CuentasPorPagar.Windows.Documentos;
using CuentasPorPagar.Windows.Pagos;
using CuentasPorPagar.Windows.Paises;
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

        private void paisesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainAdmin = new MainPaises(this);
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
            var mainPagos = new MainPagos(this);
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

                    var menuPaises = new ToolStripMenuItem("Administrar paises", null, paisesToolStripMenuItem_Click);
                    administrarToolStripMenuItem.DropDownItems.Add(menuPaises);

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

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AcercaDe acercaDe = new AcercaDe();
            //acercaDe.MdiParent = this;
            //acercaDe.Show();
        }

        private void allDocumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainPagos = new Reportes.ReporteDocumentos();
            mainPagos.MdiParent = this;
            mainPagos.Show();
        }

        private void proveedoresToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var mainPagos = new Reportes.EstadosDeCuentaProveedor();
            mainPagos.MdiParent = this;
            mainPagos.Show();
        }
    }
}
