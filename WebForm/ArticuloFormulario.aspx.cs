using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Conexión;
using System.Runtime.Remoting.Contexts;

namespace WebForm
{
    public partial class ArticuloFormulario : System.Web.UI.Page
    {
        public bool confirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Si hay sesión y si es admin
            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                if (!Seguridad.esAdmin(Session["usuario"]))
                {
                    Session.Add("error", "Se requieren permisos de admin.");
                    Response.Redirect("Error.aspx");
                }
            }
            else
            {
                Session.Add("error", "Debe iniciar Sesión");
                Response.Redirect("Login.aspx");
            }


            confirmaEliminacion = false;
            try
            {
                if (!IsPostBack)
                {
                    //Cargar y mostrar DropDownList desde Base de Datos
                    CategoríaConexión cate = new CategoríaConexión();
                    List<Categoría> listCate = cate.Catlistar();
                    MarcaConexión mar = new MarcaConexión();
                    List<Marca> listMar = mar.Marlistar();

                    ddlCategoria.DataSource = listCate;
                    ddlCategoria.DataValueField = "CId";
                    ddlCategoria.DataTextField = "CDescripcion";
                    ddlCategoria.DataBind();

                    ddlMarca.DataSource = listMar;
                    ddlMarca.DataValueField = "MId";
                    ddlMarca.DataTextField = "MDescripcion";
                    ddlMarca.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }


            //Modificar un Artículo si id contiene algo.
            try
            {
                      //rqId (Request Query Id)
                string rqId = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (rqId != "" && !IsPostBack)
                {
                    
                    ArtículoConexión connect = new ArtículoConexión();
                    Artículo seleccionado = (connect.lista(rqId))[0];

                    txtId.Text = rqId;
                    txtId.ReadOnly = true;
                    txtCodigo.Text = seleccionado.Codigo.ToString();
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    txtaImagen.Text = seleccionado.ImagenUrl.ToString();
                    ddlMarca.Text = seleccionado.Marca.MId.ToString();
                    ddlCategoria.Text = seleccionado.Categoria.CId.ToString();


                    if (!string.IsNullOrEmpty(seleccionado.ImagenUrl) && (seleccionado.ImagenUrl.StartsWith("http://") || seleccionado.ImagenUrl.StartsWith("https://") && !seleccionado.ImagenUrl.StartsWith("https://www")))
                        imgArticulo.ImageUrl = seleccionado.ImagenUrl.ToString();
                    else
                        imgArticulo.ImageUrl = "https://th.bing.com/th/id/R.ca0f4aeff51ff7e15c440816546f7730?rik=eJ5AEYKPVEnIIA&pid=ImgRaw&r=0&sres=1&sresct=1";


                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }

        }


        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ArtículoConexión artic = new ArtículoConexión();
                Artículo nuevo = new Artículo();


                //nuevo.Id = int.Parse(txtId.Text);  El id es automático
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Precio = int.Parse(txtPrecio.Text);
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ImagenUrl = txtaImagen.Text;

                nuevo.Marca = new Marca();
                nuevo.Marca.MId = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Categoría();
                nuevo.Categoria.CId = int.Parse(ddlCategoria.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    artic.modificar(nuevo);
                }
                else
                    artic.agregar(nuevo);

                Response.Redirect("Productos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx");
        }

        protected void txtaImagen_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtaImagen.Text) && (txtaImagen.Text.StartsWith("http://") || txtaImagen.Text.StartsWith("https://") && !txtaImagen.Text.StartsWith("https://www")))
                imgArticulo.ImageUrl = txtaImagen.Text;
            else
                imgArticulo.ImageUrl = "https://th.bing.com/th/id/R.ca0f4aeff51ff7e15c440816546f7730?rik=eJ5AEYKPVEnIIA&pid=ImgRaw&r=0&sres=1&sresct=1";


        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            confirmaEliminacion = true;
        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chbxConfirmarEliminar.Checked)
                {
                    ArtículoConexión conexión = new ArtículoConexión();
                    conexión.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("Productos.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", "Error al eliminar el artículo");
                Response.Redirect("Error.aspx");
            }
        }
    }
}