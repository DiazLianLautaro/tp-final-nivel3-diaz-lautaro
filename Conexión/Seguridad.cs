using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using static Dominio.Usuario;
using Conexión;

namespace Conexión
{
    public static class Seguridad
    {
        public static bool sesionActiva(object user)
        {
                            //if "user != null" entonces hay "usuario" sino "null"
            Usuario usuario = user != null ? (Usuario)user : null;
            if (usuario != null && usuario.Id != 0)
                return true;
            else
                return false;
        }

        public static bool esAdmin(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            return usuario != null ? usuario.Admin : false;
        }
    }
}
