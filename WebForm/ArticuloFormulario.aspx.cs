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
                    Session.Add("error", "Se requieren permisos de admin");
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
                    /*int idTemp = int.Parse(Request.QueryString["id"]);*/                    //Traemos y guardamos el "id" a modificar en "idTemp".
                    /*List<Artículo> temporal = (List<Artículo>)Session["listaArticulos"];*/  //Guardamos la "listaArticulos" que estén en sesión en "temporal".
                    /*Artículo seleccionado = temporal.Find(x => x.Id == idTemp);*/           //Luego guardamos en "seleccionado" la busqueda en del Id de "temporal" que coincida con el Id de "idTemp".
                                                                                              //Resumen, traemos ambas para buscar el Id que coincida y mostrar.

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


                    if (!string.IsNullOrEmpty(seleccionado.ImagenUrl) && (seleccionado.ImagenUrl.StartsWith("http://") || seleccionado.ImagenUrl.StartsWith("https://")))
                        imgArticulo.ImageUrl = seleccionado.ImagenUrl.ToString();
                    else
                        imgArticulo.ImageUrl = "https://png.pngtree.com/png-clipart/20230812/original/pngtree-photo-gallery-image-element-vector-picture-image_10495065.png";


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
            imgArticulo.ImageUrl = txtaImagen.Text;
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