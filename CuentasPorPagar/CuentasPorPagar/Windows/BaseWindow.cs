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
    public partial class BaseWindow : Form
    {
        public BaseWindow()
        {
            InitializeComponent();
        }

        private void BaseWindow_Load(object sender, EventArgs e)
        {
         
        }

        protected void Loaddata(DataTable table)
        {
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.DataSource = table;
           
           
        }

        protected virtual void btnCrear_Click(object sender, EventArgs e)
        {

        }

        protected virtual void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected virtual void btnActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
