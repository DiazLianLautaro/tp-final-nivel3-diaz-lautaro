using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Conexión
{
    public static class Validacion
    {
        public static bool validTextoVacio(object control)
        {
            if(control is TextBox texto)
            {
                //if(string.IsNullOrEmpty(((TextBox)control).Text))
                if(string.IsNullOrEmpty(texto.Text))
                        return false;
                else
                    return true;    
            }
            return false;
        }
    }
}
