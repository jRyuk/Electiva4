using DAL.BAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CuentasPorPagar.Windows.Pagos
{
    public partial class MainPagos : CuentasPorPagar.Windows.BaseWindow
    {
        Form _form;
        public MainPagos(Form form)
        {
            InitializeComponent();

            Loaddata(UsuariosBAL.Instance.GetDocumentsToPay());

            this.btnCrear.Text = "Pago";
            this.btnActualizar.Visible = btnEliminar.Visible = false;
            _form = form;
        }

       public MainPagos()
        {
            InitializeComponent();
        }

        protected override void btnCrear_Click(object sender, EventArgs e)
        {
            base.btnCrear_Click(sender, e);

            var pago = new GenerarPagos();

            pago.MdiParent = _form;
            pago.Show();
        }
    }
}
