using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class ContactoProveedor
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string DUI { get; set; }

        public string Email { get; set; }

        public string cargo { get; set; }

        public int IdProveedor { get; set; }
    }
}
