using Conexión;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class MiMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgPerfil.ImageUrl = "https://th.bing.com/th/id/OIP.pIm4Tk65DS4OCZdg3QESFgHaHa?w=740&h=740&rs=1&pid=ImgDetMain";
            if (!((Page is Login) || (Page is Default) || (Page is Registrar) || (Page is Contacto) || (Page is Error) || (Page is Detalle)))
            {
                if (!(Seguridad.sesionActiva(Session["usuario"])))
                    Response.Redirect("Login.aspx", false);
            }
            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                Usuario usuario = (Usuario)Session["usuario"];

                //si la UrlImagenPerfil no es null o vacía. entonces asignamos imagen.
                if (!string.IsNullOrEmpty(usuario.UrlImagenPerfil))
                imgPerfil.ImageUrl = "~/Images/ImagenPerfil/" + ((Usuario)Session["usuario"]).UrlImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
            }

        }
        protected void mrIngresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void mrRegistrarme_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrar.aspx");
        }

        protected void mrPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx");
        }

        protected void mrCerrar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}