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
            this.txtTitle.Text = "Usuarios";

            Loaddata(UsuariosBAL.Instance.GetAll());
        }

        protected override void btnCrear_Click(object sender, EventArgs e)
        {
            base.btnCrear_Click(sender, e);
            var formCreateUser = new CreateUser();
            formCreateUser.MdiParent = _mdiParentForm;
            formCreateUser.Show();
        }

        protected override void btnEliminar_Click(object sender, EventArgs e)
        {
            base.btnEliminar_Click(sender, e);
        }

        protected override void btnActualizar_Click(object sender, EventArgs e)
        {
            base.btnActualizar_Click(sender, e);
        }
    }
}
