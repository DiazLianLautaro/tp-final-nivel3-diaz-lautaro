using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    //"Modelo de clase u objeto a utilizar"
    public class Artículo
    {
        public int Id { get; set; }


        [DisplayName("Código")] //Nombre que se verá en su columna.
        public string Codigo { get; set; }

        public string Nombre { get; set; }


        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        public Marca Marca {  get; set; }


        [DisplayName("Categoría")]
        public Categoría Categoria { get; set; }
        public string ImagenUrl { get; set; }

        public int Precio { get; set; }

        public int idFavorito { get; set; }
        public int idUser { get; set; }
        public int idArticulo { get; set; }
    }
}
