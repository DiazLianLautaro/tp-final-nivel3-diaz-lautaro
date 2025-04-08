using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Conexión
{
    public class UsuarioConexión
    {
        public void actualizarPerfil(Usuario usuario)
        {
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearConsulta("Update USERS set apellido = @apellido, nombre = @nombre, urlImagenPerfil = @imagen Where Id = @id");
				datos.setearParametro("@id", usuario.Id);
				datos.setearParametro("@apellido", usuario.Apellido);
				datos.setearParametro("@nombre", usuario.Nombre);
				//Validar imagen 
				datos.setearParametro("@imagen", usuario.UrlImagenPerfil != null ? usuario.UrlImagenPerfil : (object)DBNull.Value);   //NULL Coalescing: (objet)usuario.UrlImagenPerfil ?? DBNull.value
                datos.ejecutarAccion();
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

        public bool Loguear(Usuario usuario)
        {
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearConsulta("select id, email, pass, nombre, apellido, urlImagenPerfil, admin from USERS where email = @email AND pass = @pass");
				datos.setearParametro("@email", usuario.Email);
				datos.setearParametro("@pass", usuario.Pass);
                datos.ejecutarLectura();

				if (datos.Lector.Read())
				{
                    usuario.Id = (int)datos.Lector["id"];
                    usuario.Admin = (bool)datos.Lector["admin"];
					if (!(datos.Lector["urlImagenPerfil"] is DBNull))
						usuario.UrlImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
                    if (!(datos.Lector["Apellido"] is DBNull))
                        usuario.Apellido = (string)datos.Lector["Apellido"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["Nombre"];

                    return true;
				}
				return false;
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

		public int Registrar(Usuario nuevo) 
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearConsulta("insert into USERS (email, pass, nombre, apellido, admin) output inserted.id values (@email, @pass, @nombre, @apellido, 0)");
				datos.setearParametro("@nombre", nuevo.Nombre);
				datos.setearParametro("@apellido", nuevo.Apellido);
				datos.setearParametro("@email", nuevo.Email);
				datos.setearParametro("@pass", nuevo.Pass);
				return datos.ejecutarAccionScalar();
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
