using DAL.BAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CuentasPorPagar.Windows.Paises
{
    public partial class MainPaises : CuentasPorPagar.Windows.BaseWindow
    {
        Form parent;
        public MainPaises(Form form)
        {
            InitializeComponent();

            this.txtTitle.Text = this.Text = "Paises";

            Loaddata(UsuariosBAL.Instance.GetAllPaises());
            parent = form;
            
        }

        public MainPaises()
        {
            InitializeComponent();
        }

        protected override void btnCrear_Click(object sender, EventArgs e)
        {
            base.btnCrear_Click(sender, e);

            CrearPaises crear = new CrearPaises(Loaddata);

            crear.MdiParent = parent;
            crear.Show();
        }
    }
}
