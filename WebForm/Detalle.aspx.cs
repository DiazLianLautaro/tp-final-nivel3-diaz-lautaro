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
            try
            {
                string RQSid = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if(RQSid != "")
                {
                    ArtículoConexión conexión = new ArtículoConexión();
                    Artículo artículo = (conexión.lista(RQSid))[0];

                    tbxId.Text = RQSid;
                    tbxCodigo.Text = artículo.Codigo;
                    tbxNombre.Text = artículo.Nombre;
                    tbxDescripcion.Text = artículo.Descripcion;
                    tbxMarca.Text = artículo.Marca.ToString();
                    tbxCategoria.Text = artículo.Categoria.ToString();
                    tbxImagen.Text = artículo.ImagenUrl.ToString();
                    tbxPrecio.Text = artículo.Precio.ToString();

                    if (!string.IsNullOrEmpty(artículo.ImagenUrl) && (artículo.ImagenUrl.StartsWith("http://") || artículo.ImagenUrl.StartsWith("https://")) && !artículo.ImagenUrl.StartsWith("https://www"))
                        imgImagenDetalle.ImageUrl = artículo.ImagenUrl;
                    else
                        imgImagenDetalle.ImageUrl = "https://th.bing.com/th/id/R.ca0f4aeff51ff7e15c440816546f7730?rik=eJ5AEYKPVEnIIA&pid=ImgRaw&r=0&sres=1&sresct=1";
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}