using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace WebForm
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            EmailService email = new EmailService();
            try
            {
                if (!(tbxEmail.Text == "" || tbxAsunto.Text == "" || tbxMensaje.Text == ""))
                {
                    email.armarCorreo(tbxEmail.Text, tbxAsunto.Text, tbxMensaje.Text);
                    email.enviarEmail();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}