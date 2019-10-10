using DAL;
using DAL.BAL;
using DAL.Models;
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
        public MainProveedores(Form form) : base(form)
        {
            InitializeComponent();

            Text = this.txtTitle.Text = "Proveedores";

            Loaddata(UsuariosBAL.Instance.GetAllProveedores());
        }

        protected override void btnActualizar_Click(object sender, EventArgs e)
        {
            base.btnActualizar_Click(sender, e);
            var selectedRow = dataGridView1.SelectedRows[0].Cells[0].Value;
            var proveedor = DbContext.Instance.Find<Proveedor>($"select * from Proveedor where Id={selectedRow}");
            var contacto = DbContext.Instance.Find<ContactoProveedor>($"select top 1 * from ContactoProveedor where IdProveedor={proveedor.Id}");
            var crearForm = new CreateProvider(Loaddata, proveedor, contacto);
            crearForm.MdiParent = _mdiParentForm;
            crearForm.Show();
        }

        protected override void btnCrear_Click(object sender, EventArgs e)
        {
            base.btnCrear_Click(sender, e);

            var crearForm = new CreateProvider(Loaddata);
            crearForm.MdiParent = _mdiParentForm;
            crearForm.Show();
        }

        protected override void btnEliminar_Click(object sender, EventArgs e)
        {
            base.btnEliminar_Click(sender, e);

            //todo-> validad que este seleccionado y preguntar si desea eliminar 
            var selectedRow = dataGridView1.SelectedRows[0].Cells[0].Value;

            DbContext.Instance.DeleteCommand($"Delete ContactoProveedor where IdProveedor='{selectedRow}'");
            DbContext.Instance.DeleteCommand($"Delete proveedor where Id='{selectedRow}'");
            Loaddata(UsuariosBAL.Instance.GetAllProveedores());
        }
    }
}
