
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

namespace CuentasPorPagar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DbContext.Instance.Init("default");

            //DbContext.Instance.Add<Roles>(new Roles() { Nombre = "Administrador" });
            /////*DbContext.Instance.Add<Roles>(new Roles() { Nombre = "Compras" });
            ////DbContext.Instance.Add<Roles>(new Roles() { Nombre = "Tesoreria" });*/

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

            var result = Login.Instance.LoginUser(txtUsuario.Text, txtPassword.Text);

            if (result && Login.Instance.LoginInfo != null ) {
                //todo-> go to next window
            }
        }
    }
}
