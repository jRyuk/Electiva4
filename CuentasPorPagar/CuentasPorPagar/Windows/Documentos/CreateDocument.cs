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
        Action<DataTable> DoAction;
        Documento _documento;
        private DateTime vencimiento=default(DateTime);

        public CreateDocument(Action<DataTable>  action, Documento documento)
        {
            InitializeComponent();
            DoAction = action;

            if(documento != null)
            {
                _documento = documento;
                LoadDocument();
            }
        }

        private void LoadDocument()
        {
            txtNoDocumento.Text =_documento.NumeroDocumento  ;
            txtTipo.SelectedIndex = _documento.Tipo;
            checkBox1.Checked = _documento.AplicaIVA == 1 ? true : false;
            dtPickerFecha.Value = DateTime.Parse(_documento.FechaPago);
            txtNumeroCuotas.Text= _documento.CantidadPagos.ToString();
            txtMonto.Text = _documento.ValorTotal.ToString();
            // document.FechaEmision = dtPickerFecha.Value.ToString("yyyy-MM-dd");
          
            txtConcepto.Text = _documento.Concepto  ;
            cbxProveedor.SelectedValue = _documento.IdProveedor;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var document = new Documento();
            document.NumeroDocumento = txtNoDocumento.Text;
            document.Tipo = txtTipo.SelectedIndex;
            document.AplicaIVA = checkBox1.Checked ? (byte)1 : (byte)0;
            document.FechaPago = dtPickerFecha.Value.ToString("yyyy-MM-dd");
            document.CantidadPagos = int.Parse(txtNumeroCuotas.Text);
            document.ValorTotal = decimal.Parse(txtMonto.Text);
            document.FechaEmision = dtPickerFecha.Value.ToString("yyyy-MM-dd");
            document.FechaVencimiento = vencimiento.ToString("yyyy-MM-dd");
            document.IdPlan = int.Parse(cbxPlazo.SelectedValue.ToString());
            document.Concepto = txtConcepto.Text;
            document.IdProveedor = int.Parse(cbxProveedor.SelectedValue.ToString());
            document.IdUsuario = Login.Instance.LoginInfo.Id;
            if(_documento != null)
            {
                document.Id = _documento.Id;
                DbContext.Instance.Update(document);
            }
            else 
            DbContext.Instance.Add(document);

            DoAction.Invoke(UsuariosBAL.Instance.GetAllDocuments());
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


            if(_documento != null)
            {
                cbxPlazo.SelectedIndex = _documento.IdPlan - 1;
            }
          
        }

        private void dtPickerFecha_ValueChanged(object sender, EventArgs e)
        {

            if (cbxPlazo.SelectedValue == null) return;
            calcularFecha();
        }

        private void calcularFecha()
        {
            var plan = int.Parse(cbxPlazo.SelectedValue.ToString());

            DateTime date = dtPickerFecha.Value.Date;

            if (plan == 1)
            {
                vencimiento = date.AddDays(7);
            }
            else if (plan == 2)
            {
                vencimiento = date.AddDays(15);
            }
            else if (plan == 3)
            {
                vencimiento = date.AddDays(30);
            }
            else if (plan == 4)
            {
                vencimiento = date.AddDays(90);
            }

            if (vencimiento != default(DateTime))
                lblVencimiento.Text = vencimiento.ToShortDateString();
        }

        private void cbxPlazo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPlazo.SelectedIndex < 0) return;
            calcularFecha();
        }
    }
}
