using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL.BAL
{
    public class UsuariosBAL : BaseLogic
    {
       private UsuariosBAL() { }

        private static UsuariosBAL _instance;

        public static UsuariosBAL Instance
        {
            get
            {
                _instance = _instance ?? new UsuariosBAL();
                return _instance;
            }
        }

        public override DataTable GeAllFromTable(string command= null)
        {
            return base.GeAllFromTable("Select Id, Nombre, DUI,NIT, Email, Habilitado  from usuarios");
        }

        public  DataTable GetAllProveedores(string command = null)
        {
            return base.GeAllFromTable("select Distinct proveedor.Id, proveedor.Nombre, Proveedor.Direccion, Proveedor.Nombre, " +
                "ContactoProveedor.Nombre  as Contacto,contactoProveedor.Email , Paises.Nombre, Departamentos.Nombre as Departamento from proveedor right join contactoProveedor on proveedor.id = contactoProveedor.IdProveedor " +
"inner join Paises on Paises.Id = Proveedor.IdPais inner join Departamentos on Departamentos.Id = Proveedor.IdDepartamento inner join Municipios on Municipios.Id = Proveedor.IdMunicipio");
        }


        public DataTable GetAllDocuments(string command = null)
        {
            return base.GeAllFromTable("Select Documento.Id, NumeroDocumento as '# Documento', ValorTotal, Proveedor.Nombre, CantidadPagos  from Documento inner join PlanPago on Documento.IdPlan = PlanPago.Id "+
                "inner join Proveedor on Proveedor.Id = Documento.IdProveedor");
        }

    }
}
