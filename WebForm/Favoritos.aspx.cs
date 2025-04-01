using Conexión;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace WebForm
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Artículo> listaFavoritos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string RQSid = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (!IsPostBack)
                {
                    if (RQSid != "" && Seguridad.sesionActiva(Session["usuario"]))
                    {
                        ArtículoFavorito articulofavorito = new ArtículoFavorito();
                        Artículo fav = new Artículo();
                        Usuario usuario = (Usuario)Session["usuario"];

                        fav.idUser = usuario.Id;                        
                        fav.idArticulo = int.Parse(RQSid);
                        articulofavorito.agregarFavorito(fav);

                        Session.Add("ArticulosFavoritos", articulofavorito.listaFavoritosId(fav.idUser));
                    }
                    if (Session["ArticulosFavoritos"] != null)
                    {
                        repFavoritos.DataSource = Session["ArticulosFavoritos"];
                        repFavoritos.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnEliminarFav_Click(object sender, EventArgs e)
        {
            ArtículoFavorito fav = new ArtículoFavorito();
            Button btn = sender as Button;
            string btnid = btn.CommandArgument;
            fav.eliminarFavorito(int.Parse(btnid));
        }
    }
}