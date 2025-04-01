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
                //datos.setearConsulta("select Id, IdUser, IdArticulo from FAVORITOS where IdUser = @idUser");
                //datos.setearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Tipo, A.IdMarca, A.IdCategoria, A.ImagenUrl, A.Precio, F.Id, F.IdUser, F.IdArticulo, S.Id from ARTICULOS A,@idUser CATEGORIAS C, MARCAS M, FAVORITOS F, USERS S Where M.Id = IdMarca And C.Id = IdCategoria And A.Id = F.IdArticulo And S.Id = @idUser");
                datos.setearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.Precio, F.Id Idfav, F.IdUser, F.IdArticulo, S.Id from ARTICULOS A, FAVORITOS F, USERS S Where A.Id = F.IdArticulo And F.IdUser = S.Id And S.Id = @idUser");
                datos.setearParametro("idUser", idUsuario);
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    Artículo artículo = new Artículo();
                    artículo.idFavorito = int.Parse(datos.Lector["Idfav"].ToString());
                    artículo.idUser = int.Parse(datos.Lector["IdUser"].ToString());
                    artículo.idArticulo = int.Parse(datos.Lector["IdArticulo"].ToString());
                    lista.Add(artículo);
                }
                datos.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
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

                //if (datos.Lector.Read())
                //{
                //    int cantidad = Convert.ToInt32(datos.Lector[0]);
                //    if (cantidad > 0)
                //    {
                //        datos.cerrarConexion();
                //        return;
                //    }
                //}
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
            datos.setearConsulta("DELETE FROM FAVORITOS WHERE IdArticulo = @idArticulo"); //PENDIENTE: id articulo y id usuario
            datos.setearParametro("@idArticulo", id);
            datos.ejecutarAccion();
        }
    }
}
