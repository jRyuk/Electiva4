using DAL.BAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CuentasPorPagar.Windows
{
    public partial class MainAdmin : CuentasPorPagar.Windows.BaseWindow
    {
        public MainAdmin()
        {
            InitializeComponent();
        }

        private void MainAdmin_Load(object sender, EventArgs e)
        {
            this.txtTitle.Text = "Usuarios";

            Loaddata(UsuariosBAL.Instance.GetAll());
        }
    }
}
