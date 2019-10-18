using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    class Pagos
    {
        public int IdDocumento { get; set; }
        public int IdUsuario { get; set; }
        public int TipoPago { get; set; }
        public string FechaPago { get; set; }
    }
}
