using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias agregadas.
using System.Data.SqlClient;
using Dominio;
using System.Globalization;
using static System.Net.WebRequestMethods;

namespace Conexión
{
    public class ArtículoConexión
    {
        public List<Artículo> lista(string id = "")
        {
            List<Artículo> lista = new List<Artículo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;                          

            try
            {
                //Cadena de conexión
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Tipo, IdMarca, IdCategoria, ImagenUrl, Precio from ARTICULOS A, CATEGORIAS C, MARCAS M Where M.Id = IdMarca And C.Id = IdCategoria ";
                if (id != "")
                    comando.CommandText += " and A.Id = " + id;
                comando.Connection = conexion;

                //Inicia la conexión
                conexion.Open();
                lector = comando.ExecuteReader();

                //While de Primera carga de Artículos al dgv
                //PENDIENTE el id no entra en los nuevos artículos agregados
                while (lector.Read())
                {
                    Artículo art = new Artículo();
                    art.Id = (int)lector["Id"];
                    art.Codigo = (string)lector["Codigo"];
                    art.Nombre = (string)lector["Nombre"];
                    art.Descripcion = (string)lector["Descripcion"];
                    art.Precio = (int)lector.GetDecimal(9);
                    if (!(lector["ImagenUrl"] is DBNull))
                        art.ImagenUrl = (string)lector["ImagenUrl"];
                    else
                        art.ImagenUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.shutterstock.com%2Fes%2Fsearch%2Fdefault-image-icon&psig=AOvVaw3rCp-r51u5MwSm9v93tEJv&ust=1736290000819000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCODB_biW4ooDFQAAAAAdAAAAABAE";
                    //solucionar imagen default


                    art.Marca = new Marca();
                    art.Marca.MId = (int)lector["IdMarca"];
                    art.Marca.MDescripcion = (string)lector["Marca"];

                    art.Categoria = new Categoría();
                    art.Categoria.CId = (int)lector["IdCategoria"];
                    art.Categoria.CDescripcion = (string)lector["Tipo"];

                    lista.Add(art);
                }

                //Cierra la conexión
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Artículo> listarConSP()
        {
            List<Artículo> lista = new List<Artículo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Tipo, IdMarca, IdCategoria, ImagenUrl, Precio from ARTICULOS A, CATEGORIAS C, MARCAS M Where M.Id = IdMarca And C.Id = IdCategoria";
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                //While de datos a filtrar
                while (datos.Lector.Read())
                {
                    Artículo art = new Artículo();
                    art.Id = (int)datos.Lector["Id"];
                    art.Codigo = (string)datos.Lector["Codigo"];
                    art.Nombre = (string)datos.Lector["Nombre"];
                    art.Descripcion = (string)datos.Lector["Descripcion"];
                    art.Precio = (int)datos.Lector.GetDecimal(9);
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        art.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    //else
                    //    art.ImagenUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.shutterstock.com%2Fes%2Fsearch%2Fdefault-image-icon&psig=AOvVaw3rCp-r51u5MwSm9v93tEJv&ust=1736290000819000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCODB_biW4ooDFQAAAAAdAAAAABAE";

                    art.Marca = new Marca();
                    art.Marca.MId = (int)datos.Lector["IdMarca"];
                    art.Marca.MDescripcion = (string)datos.Lector["Marca"];

                    art.Categoria = new Categoría();
                    art.Categoria.CId = (int)datos.Lector["IdCategoria"];
                    art.Categoria.CDescripcion = (string)datos.Lector["Tipo"];


                    lista.Add(art);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Métodods de acciones en Formulario
        public void agregar(Artículo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio)values(@codigo, @nombre, @desc, @idmarca, @idcat, @img, @precio)");
                datos.setearParametro("@codigo", nuevo.Codigo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@desc", nuevo.Descripcion);
                datos.setearParametro("@idmarca", nuevo.Marca.MId);
                datos.setearParametro("@idcat", nuevo.Categoria.CId);
                datos.setearParametro("@img", nuevo.ImagenUrl);
                datos.setearParametro("@precio", nuevo.Precio);
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

        public void modificar(Artículo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @desc, IdMarca = @idMarca, IdCategoria = @idCat, ImagenUrl = @imagenurl, Precio = @precio Where Id = @id");
                datos.setearParametro("@codigo", nuevo.Codigo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@desc", nuevo.Descripcion);
                datos.setearParametro("@idMarca", nuevo.Marca.MId);
                datos.setearParametro("@idCat", nuevo.Categoria.CId);
                datos.setearParametro("@imagenurl", nuevo.ImagenUrl);
                datos.setearParametro("@precio", nuevo.Precio);
                datos.setearParametro("@id", nuevo.Id);

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

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("delete from ARTICULOS where id = @id");
            datos.setearParametro("@id", id);
            datos.ejecutarAccion();

        }

        public List<Artículo> filtrar(string campo, string criterio, string filtro)
        {
            List<Artículo> lista = new List<Artículo> ();
            AccesoDatos datos = new AccesoDatos ();
            try
            {
                string consulta = "select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Tipo, IdMarca, IdCategoria, ImagenUrl, Precio from ARTICULOS A, CATEGORIAS C, MARCAS M Where M.Id = IdMarca And C.Id = IdCategoria And ";

                if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "' ";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%' ";
                            break;
                    }
                }
                else if (campo == "Código") 
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Codigo like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Codigo like '%" + filtro + "' ";
                            break;
                        default:
                            consulta += "Codigo like '%" + filtro + "%' ";
                            break;
                    }
                }
                else if (campo == "Marca") //M.descripcion es de Marca Descripción.
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "M.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "M.Descripcion like '%" + filtro + "' ";
                            break;
                        default:
                            consulta += "M.Descripcion like '%" + filtro + "%' ";
                            break;
                    }
                }
                else if (campo == "Categoría") //C.descripcion es de Categoría Descripción.
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "C.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "C.Descripcion like '%" + filtro + "' ";
                            break;
                        default:
                            consulta += "C.Descripcion like '%" + filtro + "%' ";
                            break;
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                //While de datos a filtrar
                while (datos.Lector.Read())
                {
                    Artículo art = new Artículo();
                    art.Id = (int)datos.Lector["Id"];
                    art.Codigo = (string)datos.Lector["Codigo"];
                    art.Nombre = (string)datos.Lector["Nombre"];
                    art.Descripcion = (string)datos.Lector["Descripcion"];
                    art.Precio = (int)datos.Lector.GetDecimal(9);
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        art.ImagenUrl = (string)datos.Lector["ImagenUrl"];


                    art.Marca = new Marca();
                    art.Marca.MId = (int)datos.Lector["IdMarca"];
                    art.Marca.MDescripcion = (string)datos.Lector["Marca"];

                    art.Categoria = new Categoría();
                    art.Categoria.CId = (int)datos.Lector["IdCategoria"];
                    art.Categoria.CDescripcion = (string)datos.Lector["Tipo"];


                    lista.Add(art);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
