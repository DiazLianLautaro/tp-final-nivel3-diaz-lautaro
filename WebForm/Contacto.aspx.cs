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
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            EmailService email = new EmailService();
            email.armarCorreo(tbxEmail.Text, tbxAsunto.Text, tbxMensaje.Text);
            try
            {
                email.enviarEmail();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}