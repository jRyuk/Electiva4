using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CuentasPorPagar.Windows.Proveedores
{
    public partial class MainProveedores : CuentasPorPagar.Windows.BaseWindow
    {
        public MainProveedores()
        {
            InitializeComponent();
            
            Text = this.txtTitle.Text = "Proveedores";
        }
    }
}
