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
    public partial class MunicipiosLista : CuentasPorPagar.Windows.BaseWindow
    {
        int _idDep;
        private Departamentos departamento;

        public MunicipiosLista()
        {
            InitializeComponent();
        }

        public MunicipiosLista(int idDep)
        {
            InitializeComponent();
            _idDep = idDep;

            Load();
        }

        public void Load()
        {
            Loaddata(UsuariosBAL.Instance.ObtenerMunicipios(_idDep));
             departamento = DbContext.Instance.Find<Departamentos>($"Select * from Departamentos where id={_idDep}");
            this.txtTitle.Text = "Departamento:";
            this.textBox1.Text = departamento.Nombre;
        }

        protected override void btnCrear_Click(object sender, EventArgs e)
        {
            base.btnCrear_Click(sender, e);

            var crear = new CrearMunicipio(_idDep, Load);
            crear.MdiParent = this.MdiParent;
            crear.Show();
        }


        protected override void btnActualizar_Click(object sender, EventArgs e)
        {
            base.btnActualizar_Click(sender, e);
            var selectedRow = dataGridView1.SelectedRows[0].Cells[0].Value;

            var municipio = DbContext.Instance.Find<Municipios>($"Select * from Municipios where Id={selectedRow}");

            var crear = new CrearMunicipio(_idDep, Load, municipio);
            crear.MdiParent = this.MdiParent;
            crear.Show();
        }


        protected override void btnEliminar_Click(object sender, EventArgs e)
        {
            base.btnEliminar_Click(sender, e);
            var selectedRow = dataGridView1.SelectedRows[0].Cells[0].Value;

            DbContext.Instance.DeleteCommand($"Delete from Municipios where Id={selectedRow}");
            Load();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            departamento.Nombre = textBox1.Text;
            DbContext.Instance.Update(departamento);
            Load();
        }
    }
}
