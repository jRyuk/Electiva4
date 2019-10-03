
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CuentasPorPagar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DbContext.Instance.Init("default");

            DbContext.Instance.Add<Roles>(new Roles() { Name= "Hola mundirijillo"});

        }
    }
}
