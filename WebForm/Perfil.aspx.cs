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
    public partial class Perfil : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["usuario"]))
                    {
                        Usuario usuario = (Usuario)Session["usuario"];
                        tbxApellido.Text = usuario.Apellido;
                        tbxNombre.Text = usuario.Nombre;
                        tbxEmail.Text = usuario.Email;
                        imgImagenPerfil.ImageUrl = usuario.UrlImagenPerfil;
                        tbxEmail.ReadOnly = true;

                        if(!string.IsNullOrEmpty(usuario.UrlImagenPerfil))
                            imgImagenPerfil.ImageUrl = "~/Images/ImagenPerfil/" + usuario.UrlImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();

                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                UsuarioConexión conexión = new UsuarioConexión();
                Usuario usuario = (Usuario)Session["usuario"];
                //Escribir Imagen si se cargó
                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/ImagenPerfil/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");
                    usuario.UrlImagenPerfil = "perfil-" + usuario.Id + ".jpg";
                }

                usuario.Apellido = tbxApellido.Text;
                usuario.Nombre = tbxNombre.Text;
                conexión.actualizarPerfil(usuario);

                
                //Leer Imagen
                Image img = (Image)Master.FindControl("imgPerfil");
                img.ImageUrl = "~/Images/ImagenPerfil/" + usuario.UrlImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                imgImagenPerfil.ImageUrl = img.ImageUrl;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());

            }
        }
    }
}