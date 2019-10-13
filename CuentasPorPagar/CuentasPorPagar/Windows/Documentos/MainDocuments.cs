using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CuentasPorPagar.Windows.Documentos
{
    public partial class MainDocuments : CuentasPorPagar.Windows.BaseWindow
    {
        public MainDocuments(Form form):base(form)
        {
            InitializeComponent();

            Loaddata(DbContext.Instance.GetAll("Select Documento.Id, NumeroDocumento as '# Documento', ValorTotal, Proveedor.Nombre, CantidadPagos  from Documento inner join PlanPago on Documento.IdPlan = PlanPago.Id "+
                "inner join Proveedor on Proveedor.Id = Documento.IdProveedor"));
        }

        protected override void btnCrear_Click(object sender, EventArgs e)
        {
            base.btnCrear_Click(sender, e);

            var createDocuments = new CreateDocument();
            createDocuments.MdiParent = _mdiParentForm;
            createDocuments.Show();
        }
    }
}
