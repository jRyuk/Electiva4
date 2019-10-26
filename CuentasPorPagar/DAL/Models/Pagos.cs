using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class Pagos
    {
        public int IdDocumento { get; set; }
        public int IdUsuario { get; set; }
        public string TipoPago { get; set; }
        public string FechaPago { get; set; }
        public string Referencia { get; set; }
        public string ConceptoPago { get; set; }
        public decimal Monto { get; set; }
    }
}
