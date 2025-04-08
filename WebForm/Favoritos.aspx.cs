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
        public int idActual { get; set; }
        public List<Artículo> listaFavoritos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string RQSid = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["usuario"]))
                    {
                        ArtículoFavorito articulofavorito = new ArtículoFavorito();
                        Artículo favorito = new Artículo();
                        Usuario usuario = (Usuario)Session["usuario"];

                        favorito.idUser = usuario.Id;
                        listaFavoritos = articulofavorito.listaFavoritosId(favorito.idUser);
                        bool repetidos = false;

                        //Buscar Repetidos.
                        if (!(listaFavoritos.Count < 1))
                        {
                            List<Artículo> for1 = new List<Artículo>();
                            List<Artículo> for2 = new List<Artículo>();

                            for (int i = 0; i < listaFavoritos.Count; i++)
                            {
                                //Repetidos del id que llegó.
                                for1.Add(listaFavoritos[i]);
                                if (RQSid != "") 
                                {
                                    if (for1[i].idArticulo == int.Parse(RQSid))
                                    {
                                        repetidos = true;
                                        Session.Add("error", "No Puedes Agregar Favoritos Repetidos");
                                        Response.Redirect("Error.aspx", false);
                                        return;
                                    }
                                }

                                //Repetidos de id guardados.
                                int c = i + 1;
                                for (int x = c; x < listaFavoritos.Count; x++)
                                {
                                    for2.Add(listaFavoritos[x]);
                                    if (for1[i].idArticulo == for2[x - 1].idArticulo)
                                    {
                                        repetidos = true;
                                        Session.Add("error", "No Puedes Agregar Favoritos Repetidos");
                                        Response.Redirect("Error.aspx", false);
                                        return;
                                    }
                                }
                            }
                            
                            //Agregar a Favoritos si no hay repetidos.
                            if (repetidos == false && RQSid != "")
                            { 
                                    favorito.idArticulo = int.Parse(RQSid);
                                    articulofavorito.agregarFavorito(favorito);
                            }
                        }
                        else //Agregar por primera vez. Osea si la lista está vacía.
                        {
                            favorito.idArticulo = int.Parse(RQSid);
                            articulofavorito.agregarFavorito(favorito);
                        }

                        //Mostrar Favoritos.
                        Session.Add("ArticulosFavoritos", articulofavorito.listaFavoritosId(favorito.idUser));
                        if (Session["ArticulosFavoritos"] != null)
                        {
                            repFavoritos.DataSource = Session["ArticulosFavoritos"];
                            repFavoritos.DataBind();
                        }
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
            Artículo favorito = new Artículo();
            Button btn = sender as Button;
            Usuario usuario = (Usuario)Session["usuario"];
            favorito.idUser = usuario.Id;

            string btnid = btn.CommandArgument;
            fav.eliminarFavorito(int.Parse(btnid));

            Session.Add("ArticulosFavoritos", fav.listaFavoritosId(favorito.idUser));
            repFavoritos.DataSource = Session["ArticulosFavoritos"];
            repFavoritos.DataBind();
        }
    }
}