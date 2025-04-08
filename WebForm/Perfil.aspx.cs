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
                        tbxEmail.ReadOnly = true;

                        if(!string.IsNullOrEmpty(usuario.UrlImagenPerfil))
                            imgImagenPerfil.ImageUrl = "~/Images/ImagenPerfil/" + usuario.UrlImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                        else
                        { 
                            imgImagenPerfil.ImageUrl = "https://t4.ftcdn.net/jpg/04/70/29/97/360_F_470299797_UD0eoVMMSUbHCcNJCdv2t8B2g1GVqYgs.jpg";
                        }

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

                    //Leer Imagen

                    Image img = (Image)Master.FindControl("imgPerfil");
                    img.ImageUrl = "~/Images/ImagenPerfil/" + usuario.UrlImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                    imgImagenPerfil.ImageUrl = img.ImageUrl;
                }   
                else if(imgImagenPerfil.ImageUrl == "")
                {
                    imgImagenPerfil.ImageUrl = "https://t4.ftcdn.net/jpg/04/70/29/97/360_F_470299797_UD0eoVMMSUbHCcNJCdv2t8B2g1GVqYgs.jpg";
                }
                
                   

                usuario.Apellido = tbxApellido.Text;
                usuario.Nombre = tbxNombre.Text;
                conexión.actualizarPerfil(usuario);

                
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());

            }
        }
    }
}