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

namespace CuentasPorPagar.Windows.Documentos
{
    public partial class CreateDocument : Form
    {
        public CreateDocument()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var document = new Documento();
            document.NumeroDocumento = txtNoDocumento.Text;
            document.Tipo = txtTipo.SelectedIndex;
            document.AplicaIVA = checkBox1.Checked ? (byte)1 : (byte)0;
            document.FechaPago = "";
            document.CantidadPagos = int.Parse(txtNumeroCuotas.Text);
            document.ValorTotal = decimal.Parse(txtMonto.Text);
            document.FechaEmision = dtPickerFecha.Value.ToString("yyyy-MM-dd");
            document.IdPlan = int.Parse(cbxPlazo.SelectedValue.ToString());
            document.Concepto = txtConcepto.Text;
            document.IdProveedor = int.Parse(cbxProveedor.SelectedValue.ToString());
            document.IdUsuario = Login.Instance.LoginInfo.Id;

            DbContext.Instance.Add(document);
            this.Close();

        }

        private void CreateDocument_Load(object sender, EventArgs e)
        {
            txtTipo.SelectedIndex = 0;
            var proveedores = DbContext.Instance.GetAll("Select * from Proveedor");
            var plans = DbContext.Instance.GetAll("Select * from PlanPago");
            cbxProveedor.DisplayMember = cbxPlazo.DisplayMember = "Nombre";
            cbxProveedor.ValueMember = cbxPlazo.ValueMember= "Id";

            cbxProveedor.DataSource = proveedores;
            cbxPlazo.DataSource = plans;
        }
    }
}
