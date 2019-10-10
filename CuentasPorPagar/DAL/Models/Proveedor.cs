using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdPais { get; set; }
        public int IdDepartamento { get; set; }
        public int IdMunicipio {get;set; }
        public string Direccion { get; set; }
        public string NumeroRegistro { get; set; }
        public string NIT { get; set; }
        public string RazonSocial { get; set; }
    }
}
