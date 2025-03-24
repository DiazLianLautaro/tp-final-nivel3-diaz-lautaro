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
    public partial class Default : System.Web.UI.Page
    {
        public string user { get; set; }
        public List<Artículo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArtículoConexión negocio = new ArtículoConexión();
            Usuario usuario = (Usuario)Session["usuario"];
            ListaArticulo = negocio.listarConSP();
            
            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaArticulo;
                repRepetidor.DataBind();
            }

            //Uso correo, no nombre, asi que esto no sirve hasta configurar eso, osea agregar el nombre.
            //user = Request.QueryString["nombre"] != null ? Request.QueryString["nombre"].ToString() : "";

            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                if(!string.IsNullOrEmpty(usuario.Nombre))
                {
                    lblUser.Text = "Bienvenido/a " + usuario.Nombre;
                }
            }

        }
    }
}