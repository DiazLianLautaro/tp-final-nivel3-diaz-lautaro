using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Conexión;

namespace WebForm
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                Response.Redirect("Perfil.aspx");
            }
        }

        protected void brnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioConexión conexión = new UsuarioConexión();
            try
            {
                if (Validacion.validTextoVacio(tbxEmail.Text) || Validacion.validTextoVacio(tbxPass.Text))
                {
                    Session.Add("error", "Debes completar ambos campos");
                    Response.Redirect("Error.aspx");
                }
                usuario.Email = tbxEmail.Text;
                usuario.Pass = tbxPass.Text;
                if (conexión.Loguear(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("Perfil.aspx", false);
                }
                else
                {
                    Session.Add("error","Email o Contraseña incorrecto");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}