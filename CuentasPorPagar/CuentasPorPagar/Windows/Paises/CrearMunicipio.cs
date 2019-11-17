using DAL;
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
    public partial class CrearMunicipio : Form
    {
        Action DoAction;
        Municipios _municipios;
    
        int _idDepartamento;
        public CrearMunicipio()
        {
            InitializeComponent();
        }

        public CrearMunicipio(int idDepartamento, Action action, Municipios municipios = null)
        {
            InitializeComponent();
            DoAction = action;
            _idDepartamento = idDepartamento;

            _municipios = municipios;
            if(_municipios != null)
            {
                textBox1.Text = _municipios.Nombre;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(_municipios == null)
            {
                var municipio = new Municipios();
                municipio.IdDepartamento = _idDepartamento;
                municipio.Nombre = textBox1.Text;

                DbContext.Instance.Add(municipio);

            }
            else
            {
                _municipios.Nombre = textBox1.Text;
                DbContext.Instance.Update(_municipios);
            }
           

            DoAction.Invoke();

            Close();
        }

       
    }
}
