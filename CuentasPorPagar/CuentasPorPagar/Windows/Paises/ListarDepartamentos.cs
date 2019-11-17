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

namespace CuentasPorPagar.Windows.Paises
{
    public partial class ListarDepartamentos : CuentasPorPagar.Windows.BaseWindow
    {
        Form _parent;
        string _pais;
        private DAL.Models.Paises paisSeleccionado;

        public ListarDepartamentos()
        {
            InitializeComponent();
        }
        
        public ListarDepartamentos(string pais, Form parent)
        {
            InitializeComponent();

            Loaddata(UsuariosBAL.Instance.GetDepartamentos(pais));
            _parent = parent;
            _pais = pais;
            paisSeleccionado = DbContext.Instance.Find<DAL.Models.Paises>($"Select * from Paises where Id={_pais}");

            this.txtTitle.Text = "Pais: ";
            this.textBox1.Text = paisSeleccionado.Nombre;
        }

        protected override void btnCrear_Click(object sender, EventArgs e)
        {
            base.btnCrear_Click(sender, e);

            var crear = new CrearDepartamento(_pais,Loaddata);
            crear.MdiParent = _parent;
            crear.Show();
        }

        protected override void btnActualizar_Click(object sender, EventArgs e)
        {
            base.btnActualizar_Click(sender, e);
            var selectedRow = dataGridView1.SelectedRows[0].Cells[0].Value;
           

            var dp = new MunicipiosLista(int.Parse(selectedRow.ToString()));
            dp.MdiParent = _parent;
            dp.Show();
        }

        protected override void btnEliminar_Click(object sender, EventArgs e)
        {
            base.btnEliminar_Click(sender, e);

            var selectedRow = dataGridView1.SelectedRows[0].Cells[0].Value;

            DbContext.Instance.DeleteCommand($"Delete from Departamentos where id={selectedRow}");
            Loaddata(UsuariosBAL.Instance.GetDepartamentos(_pais));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            paisSeleccionado.Nombre = textBox1.Text;
            DbContext.Instance.Update(paisSeleccionado);

            Loaddata(UsuariosBAL.Instance.GetDepartamentos(_pais));
        }
    }
}
