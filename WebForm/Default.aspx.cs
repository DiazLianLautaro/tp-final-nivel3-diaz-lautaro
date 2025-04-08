using Conexión;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using System.Net.Security;

namespace WebForm
{
    public partial class Default : System.Web.UI.Page
    {
        public string user { get; set; }
        public List<Artículo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                ArtículoConexión negocio = new ArtículoConexión();
                Usuario usuario = (Usuario)Session["usuario"];
                ListaArticulo = negocio.lista();
            
                if (!IsPostBack)
                {
                    repRepetidor.DataSource = ListaArticulo;
                    repRepetidor.DataBind();
                }
                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    if (!string.IsNullOrEmpty(usuario.Nombre))
                    {
                        lblUser.Text = "Bienvenido/a " + usuario.Nombre;
                    }
                }


            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
    }
}