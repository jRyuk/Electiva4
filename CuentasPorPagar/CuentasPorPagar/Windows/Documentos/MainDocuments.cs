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

namespace CuentasPorPagar.Windows.Documentos
{
    public partial class MainDocuments : CuentasPorPagar.Windows.BaseWindow
    {
        public MainDocuments(Form form):base(form)
        {
            InitializeComponent();

            Loaddata(UsuariosBAL.Instance.GetAllDocuments());
        }

        protected override void btnCrear_Click(object sender, EventArgs e)
        {
            base.btnCrear_Click(sender, e);

            var createDocuments = new CreateDocument(Loaddata,null);
            createDocuments.MdiParent = _mdiParentForm;
            createDocuments.Show();


        }


        protected override void btnActualizar_Click(object sender, EventArgs e)
        {
            base.btnActualizar_Click(sender, e);

            var selectedRow = dataGridView1.SelectedRows[0].Cells[0].Value;
            var documento = DbContext.Instance.Find<Documento>($"select * from Documento where Id={selectedRow}");                              
            var crearForm = new CreateDocument(Loaddata, documento);
            crearForm.MdiParent = _mdiParentForm;
            crearForm.Show();

        }


        protected override void btnEliminar_Click(object sender, EventArgs e)
        {
            base.btnEliminar_Click(sender, e);                    
            var selectedRow = dataGridView1.SelectedRows[0].Cells[0].Value;     
            DbContext.Instance.DeleteCommand($"Delete Documento where Id='{selectedRow}'");
            Loaddata(UsuariosBAL.Instance.GetAllDocuments());
        }
    }
}
