using DAL.BAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CuentasPorPagar.Windows.Pagos
{
    public partial class MainPagos : CuentasPorPagar.Windows.BaseWindow
    {
        public MainPagos()
        {
            InitializeComponent();

            Loaddata(UsuariosBAL.Instance.GetDocumentsToPay());
        }
    }
}
