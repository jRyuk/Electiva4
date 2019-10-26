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

namespace CuentasPorPagar.Windows.Pagos
{
    public partial class GenerarPagos : Form
    {
        Documento _documento;
        Proveedor _proveedor;
        Action _action;

        public GenerarPagos(Documento documento,Proveedor proveedor, Action action)
        {
            InitializeComponent();
            _documento = documento;
            _proveedor = proveedor;
            _action = action;
            
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            txtN.Text = _documento.NumeroDocumento;
            txtTipoDoc.Text = _documento.Tipo == 0 ? "Factura" : "Credito Fiscal";
            txtFecha.Text = _documento.FechaEmision;
            lblVencimiento.Text = _documento.FechaVencimiento;
            txtProveedor.Text = _documento.IdProveedor.ToString();
            txtConcepto.Text = _documento.Concepto;
            txtProveedor.Text = _proveedor.Nombre;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var pago = new DAL.Models.Pagos();
            pago.IdDocumento = _documento.Id;
            pago.FechaPago = DateTime.Now.ToString("yyyy-MM-dd");
            pago.IdUsuario = Login.Instance.LoginInfo.Id;
            pago.TipoPago = txtTipo.Text;
            pago.Monto = decimal.Parse(txtPago.Text);
            pago.Referencia = txtReferencia.Text;
            pago.ConceptoPago = txtConeptoPago.Text;

            DbContext.Instance.Add(pago);
            _action.Invoke();
        }
    }
}
