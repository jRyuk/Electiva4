using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using DAL.BAL;
using DAL.Models;

namespace CuentasPorPagar.Windows.Paises
{
    public partial class CrearPaises : Form
    {
        Action<DataTable> DoAction;
        public CrearPaises()
        {
            InitializeComponent();
        }

        public CrearPaises(Action<DataTable> action)
        {
            InitializeComponent();
            DoAction = action;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text)) return;

            DAL.Models.Paises p = new DAL.Models.Paises();
            p.Nombre = txtNombre.Text;
            DbContext.Instance.Add(p);
            DoAction.Invoke(UsuariosBAL.Instance.GetAllPaises());
            this.Close();
        }
    }
}
