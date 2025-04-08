using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Error"] != null)
                    lblError.Text = Session["Error"].ToString();
                else
                    lblError.Text = "error desconocido";

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}