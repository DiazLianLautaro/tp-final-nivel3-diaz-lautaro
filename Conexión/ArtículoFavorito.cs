using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Conexión;

namespace Conexión
{
    public class ArtículoFavorito
    {
        public List<Artículo> listaFavoritosId(int idUsuario)
        {
            List<Artículo> lista = new List<Artículo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Tipo, A.IdMarca, A.IdCategoria, A.ImagenUrl, A.Precio, F.Id Idfav, F.IdUser, F.IdArticulo, S.Id from ARTICULOS A, CATEGORIAS C, MARCAS M, FAVORITOS F, USERS S Where M.Id = IdMarca And C.Id = IdCategoria And A.Id = F.IdArticulo And F.IdUser = S.Id And S.Id = @idUser");
                datos.setearParametro("@idUser", idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {//e
                    Artículo artículo = new Artículo();
                    artículo.idFavorito = int.Parse(datos.Lector["Idfav"].ToString());
                    artículo.idUser = int.Parse(datos.Lector["IdUser"].ToString());
                    artículo.idArticulo = int.Parse(datos.Lector["IdArticulo"].ToString());
                    artículo.Nombre = datos.Lector["Nombre"].ToString();
                    artículo.Descripcion = datos.Lector["Descripcion"].ToString();
                    artículo.ImagenUrl = datos.Lector["ImagenUrl"].ToString();
                    artículo.Precio = (int)datos.Lector.GetDecimal(9);

                    artículo.Marca = new Marca();
                    artículo.Marca.MId = int.Parse(datos.Lector["IdMarca"].ToString());
                    artículo.Marca.MDescripcion = datos.Lector["Marca"].ToString();

                    artículo.Categoria = new Categoría();
                    artículo.Categoria.CId = int.Parse(datos.Lector["IdCategoria"].ToString());
                    artículo.Categoria.CDescripcion = datos.Lector["Tipo"].ToString();

                    lista.Add(artículo);
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

        public void agregarFavorito(Artículo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into FAVORITOS (IdUser, IdArticulo) OUTPUT INSERTED.ID VALUES (@idUser, @idArticulo)");
                datos.setearParametro("@idUser", nuevo.idUser);
                datos.setearParametro("@IdArticulo", nuevo.idArticulo);
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

        public void eliminarFavorito(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from FAVORITOS where Id = @idFavorito");
                datos.setearParametro("@idFavorito", id);
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
    }
}
