using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CuentasPorPagarWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DbContext.Instance.Init("default");
            var result = DAL.BAL.Login.Instance.LoginUser("admin","Declicforever");
        }
    }
}