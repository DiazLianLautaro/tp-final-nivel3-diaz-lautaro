using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Categoría
    {
        public int CId { get; set; }
        public string CDescripcion { get; set; }
        public override string ToString()
        {
            return CDescripcion;
        }
    }
}
