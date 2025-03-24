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
    public partial class Registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                Response.Redirect("Perfil.aspx");
            }
        }
        protected void btnAceptarRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario user = new Usuario();
                UsuarioConexión conec = new UsuarioConexión();
                EmailService emailService = new EmailService();

                //Proceso para registrar al usuario.
                user.Nombre = tbxNombre.Text;
                user.Apellido = tbxApellido.Text;
                user.Email = tbxEmailRegistrar.Text;
                user.Pass = tbxPassRegistrar.Text;
                user.Id = conec.Registrar(user);    //id que devuelve SQL

                //Ya registrado, iniciamos su sesión automáticamente.
                Session.Add("usuario", user);

                //Enviamos el correo
                emailService.armarCorreo(user.Email, "Bienvenido", "Hola que tal");
                emailService.enviarEmail();
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }

        protected void btnCancelarRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }


        //Funcion de Registrar y demàs
        //Guardar "nombre" en Session para poder saludar al inicio de la pàgina.
    }
}