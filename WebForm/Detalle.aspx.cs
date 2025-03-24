using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Conexión;
using Dominio;

namespace WebForm
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!Seguridad.sesionActiva(Session["usuario"]))
            //    {
            //        Response.Redirect("Login.aspx", false);
            //        Session.Add("error", "Debes ingresar sesión para");
            //    }
            //}
            //catch (Exception ex)
            //{

            //    Session.Add("error", ex.ToString());
            //}
        }
    }
}