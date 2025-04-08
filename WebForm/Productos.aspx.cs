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
    public partial class Productos : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
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

            ArtículoConexión conexion = new ArtículoConexión();
            if (!IsPostBack)
            {
                //Campos del filtro avanzado
                ddlCampo.SelectedIndex = 0;
                ddlCriterio.Items.Clear();
                if (ddlCampo.SelectedIndex >= 0)
                {
                    ddlCriterio.Items.Add("Empieza con");
                    ddlCriterio.Items.Add("Termina con");
                    ddlCriterio.Items.Add("Contiene con");
                }
                Session.Add("listaArticulos", conexion.lista());
            }
            //Cargar el dgv 
            dgvArticulos.DataSource = conexion.filtrar(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), tbxFiltroAvanzado.Text);
            dgvArticulos.DataBind();

        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dgvId = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("ArticuloFormulario.aspx?id=" + dgvId);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void tbxFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Artículo> lista = (List<Artículo>)Session["listaArticulos"];
            List<Artículo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(tbxFiltro.Text.ToUpper()));
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }

        protected void chxFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chxFiltroAvanzado.Checked;
            tbxFiltro.Enabled = !FiltroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedIndex >= 0)
            {
                ddlCriterio.Items.Add("Empieza con");
                ddlCriterio.Items.Add("Termina con");
                ddlCriterio.Items.Add("Contiene con");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ArtículoConexión conec = new ArtículoConexión();
                dgvArticulos.DataSource = conec.filtrar(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), tbxFiltroAvanzado.Text);
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                tbxFiltroAvanzado.Text = "";
                ddlCampo.SelectedIndex = 0;
                ddlCriterio.SelectedIndex = 0;
                ArtículoConexión conec = new ArtículoConexión();
                dgvArticulos.DataSource = conec.filtrar(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), tbxFiltroAvanzado.Text);
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }

        }
    }
}