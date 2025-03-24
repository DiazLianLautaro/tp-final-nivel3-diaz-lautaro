using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexión
{
    public class CategoríaConexión
    {
        public List<Categoría> Catlistar() //Conexión a la table de CATEGORIAS de sql.
        {
            List<Categoría> lista = new List<Categoría>();
            AccesoDatos datos = new AccesoDatos();

            try
			{
                datos.setearConsulta("select Id, Descripcion from CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoría cat = new Categoría();
                    cat.CId = (int)datos.Lector["Id"];
                    cat.CDescripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(cat);
                }
                return lista;
			}
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
