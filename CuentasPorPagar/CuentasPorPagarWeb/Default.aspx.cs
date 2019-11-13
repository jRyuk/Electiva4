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
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String usuario = txtUser.Text;
            String contra = txtPass.Text;
            var result = DAL.BAL.Login.Instance.LoginUser(usuario,contra);
            if (result && DAL.BAL.Login.Instance.LoginInfo != null)
            {
                lblMessage.Text = "Usuario Valido";
                /*
                poner a donde redireccionara
                */
            }
            else
            {
                lblMessage.Text = "Usuario NO Valido";
            }
        }


    }
}