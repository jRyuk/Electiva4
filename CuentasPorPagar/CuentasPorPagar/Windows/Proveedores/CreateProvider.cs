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

namespace CuentasPorPagar.Windows.Proveedores
{
    public partial class CreateProvider : Form
    {
        Proveedor _proveedor = null;
        ContactoProveedor _contactoProveedor = null;

        Action<DataTable> DoAction;
        public CreateProvider(Action<DataTable> action, Proveedor proveedor= null, ContactoProveedor contactoProveedor= null)
        {
            InitializeComponent();
            this.Load += CreateProvider_Load;
            this.cbxMun.DisplayMember = "Nombre";
            this.cbxMun.ValueMember = "Id";
            this.cbxDep.DisplayMember = "Nombre";
            this.cbxDep.ValueMember = "Id";
            this.cbxPais.DisplayMember = "Nombre";
            this.cbxPais.ValueMember = "Id";
            DoAction = action;
            if (proveedor != null && contactoProveedor != null) {
                _contactoProveedor = contactoProveedor;
                _proveedor = proveedor;
                LoadaProvider(proveedor, contactoProveedor);
            }
        }

        private void LoadaProvider(Proveedor proveedor, ContactoProveedor contactoProveedor)
        {
            cbxPais.SelectedValue = proveedor.IdPais;
            cbxDep.SelectedValue = proveedor.IdDepartamento;
            cbxMun.SelectedValue = proveedor.IdMunicipio;
            txtDescrip.Text= proveedor.Direccion;
            txtNRC.Text=  proveedor.NumeroRegistro ;
            txtNit.Text = proveedor.NIT ;
            txtRazon.Text = proveedor.RazonSocial ;
            txtNombreComercial.Text= proveedor.Nombre;

            txtContactNombre.Text= contactoProveedor.Nombre ;
            txtDUIContact.Text = contactoProveedor.DUI  ;
            txtEmail.Text= contactoProveedor.Email ;
            txtCargo.Text= contactoProveedor.cargo ;
        }

        private void CreateProvider_Load(object sender, EventArgs e)
        {
            LoadData();
        }

      

        private void LoadData()
        {
            var paises = DbContext.Instance.GetAll("Select * from paises");
           
            this.cbxPais.DataSource = paises;
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPais.SelectedIndex >= 0) {
                var dep = DbContext.Instance.GetAll($"Select * from Departamentos where IdPais={cbxPais.SelectedValue}");
               
                this.cbxDep.DataSource = dep;
               
            }
          
        }

        private void cbxDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDep.SelectedIndex >= 0)
            {
                
                var municipios = DbContext.Instance.GetAll($"Select * from Municipios where IdDepartamento={cbxDep.SelectedValue}");
                this.cbxMun.DataSource = municipios;
               
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var proveedor = new Proveedor(); 
            
            proveedor.IdPais = int.Parse(cbxPais.SelectedValue.ToString());
            proveedor.IdDepartamento = int.Parse(cbxDep.SelectedValue.ToString());
            proveedor.IdMunicipio = int.Parse(cbxMun.SelectedValue.ToString());
            proveedor.Direccion = txtDescrip.Text;
            proveedor.NumeroRegistro = txtNRC.Text;
            proveedor.NIT = txtNit.Text;
            proveedor.RazonSocial = txtRazon.Text;
            proveedor.Nombre = txtNombreComercial.Text;
            if (_proveedor == null)
                DbContext.Instance.Add(proveedor);
            else {
                proveedor.Id = _proveedor.Id;
                DbContext.Instance.Update(proveedor);
            }

            var lastProveedor = DbContext.Instance.Find<Proveedor>($"select top 1 * from proveedor where NumeroRegistro='{proveedor.NumeroRegistro}'");

            var contacto = new ContactoProveedor();
            contacto.Nombre = txtContactNombre.Text;
            contacto.DUI = txtDUIContact.Text;
            contacto.Email = txtEmail.Text;
            contacto.cargo = txtCargo.Text;
            contacto.IdProveedor = lastProveedor.Id;
            if (_contactoProveedor == null)
                DbContext.Instance.Add(contacto);
            else {
                contacto.Id = _contactoProveedor.Id;
                DbContext.Instance.Update(contacto);
            }
            DoAction.Invoke(UsuariosBAL.Instance.GetAllProveedores());
            this.Close();
        }
    }
}
