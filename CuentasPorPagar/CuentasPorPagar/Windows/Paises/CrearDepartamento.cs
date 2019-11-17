using DAL;
using DAL.BAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CuentasPorPagar.Windows.Paises
{
    public partial class CrearDepartamento : Form
    {
        private string _idPais;
        Action<DataTable> DoAction;
        Departamentos _dep;
        public CrearDepartamento()
        {
            InitializeComponent();
        }

        public CrearDepartamento(string idPais, Action<DataTable> action, Departamentos departamentos = null)
        {
            InitializeComponent();

            _idPais = idPais;
            DoAction = action;
            _dep = departamentos;

            if(_dep != null)
            {
                textBox1.Text = _dep.Nombre;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(_dep == null)
            {
                DbContext.Instance.Add(new Departamentos()
                {
                    Nombre = textBox1.Text,
                    IdPais = int.Parse(_idPais)
                });

            }
            else
            {
                _dep.Nombre = textBox1.Text;
                DbContext.Instance.Update(_dep);
            }

            

            DoAction.Invoke(UsuariosBAL.Instance.GetDepartamentos(_idPais));
            this.Close();
        }
    }
}
