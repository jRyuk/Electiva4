using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class Usuarios
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string DUI { get; set; }

        public string NIT { get; set; }

        public string Email { get; set; }

        public string Direccion { get; set; }

        public string Usuario { get; set; }

        public string HashPassword { get; set; }

        public byte Habilitado { get; set; }

        public int IdRole { get; set; }
    }
}
