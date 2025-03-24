using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexión
{
    public class MarcaConexión
    {
        public List<Marca> Marlistar() //Conexión a la table de MARCAS de sql.
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Id, Descripcion from MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca mar = new Marca();
                    mar.MId = (int)datos.Lector["Id"];
                    mar.MDescripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(mar);
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
