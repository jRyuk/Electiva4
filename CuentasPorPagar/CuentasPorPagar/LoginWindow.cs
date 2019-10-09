
using CuentasPorPagar.Windows;
using DAL;
using DAL.BAL;
using DAL.Models;
using DAL.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CuentasPorPagar
{
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
            DbContext.Instance.Init("default");

            //DbContext.Instance.Update<Usuarios>(new Usuarios()
            //{
            //    Id = 1,
            //    Nombre = "GranTest",
            //    DUI = "2345678",
            //    Direccion = "aqui",
            //    Email = "asdsad",
            //    Habilitado = 1,
            //    HashPassword = "admin",
            //    IdRole = 1,
            //    NIT = "1234",
            //    Usuario = "Admin"
            //});

            //DbContext.Instance.Add<Roles>(new Roles() { Nombre = "Administrador" });
            /////////*DbContext.Instance.Add<Roles>(new Roles() { Nombre = "Compras" });
            ////////DbContext.Instance.Add<Roles>(new Roles() { Nombre = "Tesoreria" });*/

            //DbContext.Instance.Add<Usuarios>(new Usuarios()
            //{
            //    Nombre = "Test",
            //    DUI = "sadsadsad",
            //    Direccion = "asdsad",
            //    Email = "asdsad",
            //    Habilitado = 1,
            //    HashPassword = "Declicforever",
            //    IdRole = 1,
            //    NIT = "sadsad",
            //    Usuario = "Addmin"

            //});

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //todo-> Validate empty fields 

            var result = DAL.BAL.Login.Instance.LoginUser(txtUsuario.Text, txtPassword.Text);

            if (result && DAL.BAL.Login.Instance.LoginInfo != null )
            {
                switch (DAL.BAL.Login.Instance.LoginInfo.IdRole)
                {
                    case (int)UserType.Admin:
                        _current = new MainContainer();
                        
                        _current.Show();
                        this.Hide();
                        break;
                }
            }
            else
            {
                DAL.Utils.Extensions.ShowMessage("Credenciales invalidas");
            }
        }

        private Form _current; 
    }
}
