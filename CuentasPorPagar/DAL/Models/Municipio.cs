using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class Municipios
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int IdDepartamento { get; set; }
    }
}
