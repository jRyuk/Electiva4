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

namespace CuentasPorPagar.Windows
{
    public partial class MainAdmin : CuentasPorPagar.Windows.BaseWindow
    {
        readonly Form _mdiParentForm;
        public MainAdmin(Form form)
        {
            InitializeComponent();
            _mdiParentForm = form;
        }

        private void MainAdmin_Load(object sender, EventArgs e)
        {
           Text = this.txtTitle.Text = "Usuarios";

            Loaddata(UsuariosBAL.Instance.GetAll());
        }

        protected override void btnCrear_Click(object sender, EventArgs e)
        {
            base.btnCrear_Click(sender, e);
            var formCreateUser = new CreateUser(null, Loaddata);
            formCreateUser.MdiParent = _mdiParentForm;
            formCreateUser.Show();
        }

        protected override void btnEliminar_Click(object sender, EventArgs e)
        {
            base.btnEliminar_Click(sender, e);

            //todo-> validad que este seleccionado y preguntar si desea eliminar 
            var selectedRow = dataGridView1.SelectedRows[0].Cells[0].Value;

            DbContext.Instance.DeleteCommand($"Delete usuarios where Id='{selectedRow}'");
        }

        protected override void btnActualizar_Click(object sender, EventArgs e)
        {
            base.btnActualizar_Click(sender, e);

            //validar seleccionado 
            var selectedRow = dataGridView1.SelectedRows[0].Cells[0].Value;
            var user = DbContext.Instance.Find<Usuarios>($"select * from Usuarios where Id={selectedRow}");

            var formCreateUser = new CreateUser(user, Loaddata);
            formCreateUser.MdiParent = _mdiParentForm;
            formCreateUser.Show();
        }
    }
}
