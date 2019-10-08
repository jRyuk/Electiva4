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

        public override DataTable GetAll(string command= null)
        {
            return base.GetAll("Select Id, Nombre, DUI,NIT, Email, Habilitado  from usuarios");
        }

    }
}
