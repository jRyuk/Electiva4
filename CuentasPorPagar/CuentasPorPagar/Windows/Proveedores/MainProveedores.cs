using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CuentasPorPagar.Windows.Proveedores
{
    public partial class MainProveedores : CuentasPorPagar.Windows.BaseWindow
    {
        public MainProveedores(Form form):base(form)
        {
            InitializeComponent();
            
            Text = this.txtTitle.Text = "Proveedores";
        }

        protected override void btnActualizar_Click(object sender, EventArgs e)
        {
            base.btnActualizar_Click(sender, e);
        }

        protected override void btnCrear_Click(object sender, EventArgs e)
        {
            base.btnCrear_Click(sender, e);

            var crearForm = new CreateProvider();
            crearForm.MdiParent = _mdiParentForm;
            crearForm.Show();
        }

        protected override void btnEliminar_Click(object sender, EventArgs e)
        {
            base.btnEliminar_Click(sender, e);
        }
    }
}
