using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CuentasPorPagar.Windows.Proveedores
{
    public partial class CreateProvider : Form
    {
        public CreateProvider()
        {
            InitializeComponent();
            this.Load += CreateProvider_Load;
        }

        private void CreateProvider_Load(object sender, EventArgs e)
        {
            LoadData();
        }

      

        private void LoadData()
        {
            var paises = DbContext.Instance.GetAll("Select * from paises");
            this.cbxPais.DisplayMember = "Nombre";
            this.cbxPais.ValueMember = "Id";
            this.cbxPais.DataSource = paises;
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPais.SelectedIndex >= 0) {
                var dep = DbContext.Instance.GetAll($"Select * from Departamentos where IdPais={cbxPais.SelectedValue}");
                this.cbxDep.DisplayMember = "Nombre";
                this.cbxDep.ValueMember = "Id";
                this.cbxDep.DataSource = dep;
               
            }
          
        }

        private void cbxDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDep.SelectedIndex >= 0)
            {
                this.cbxMun.DisplayMember = "Nombre";
                this.cbxMun.ValueMember = "Id";
                var municipios = DbContext.Instance.GetAll($"Select * from Municipios where IdDepartamento={cbxDep.SelectedValue}");
                this.cbxMun.DataSource = municipios;
               
            }
        }
    }
}
