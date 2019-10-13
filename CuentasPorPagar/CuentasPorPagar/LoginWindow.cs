
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

            

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //todo-> Validate empty fields 

            var result = DAL.BAL.Login.Instance.LoginUser(txtUsuario.Text, txtPassword.Text);

            if (result && DAL.BAL.Login.Instance.LoginInfo != null )
            {
               
                        _current = new MainContainer(this);
                        
                        _current.Show();
                        this.Hide();  
               
            }
            else
            {
                DAL.Utils.Extensions.ShowMessage("Credenciales invalidas");
            }
        }

        private Form _current; 
    }
}
