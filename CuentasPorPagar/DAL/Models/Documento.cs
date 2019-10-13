using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class Documento
    {
        public int Id { get; set; }

        public string NumeroDocumento { get; set; }

        public int Tipo { get; set;  }

        public byte AplicaIVA { get; set; }

        public string FechaPago { get; set; }

        public int CantidadPagos { get; set; }

        public decimal ValorTotal { get; set; }

        public string FechaEmision { get; set; }

        public int IdPlan { get; set; }

        public string Concepto { get; set; }

        public int IdProveedor { get; set; }

        public int IdUsuario { get; set; }
    }
}
