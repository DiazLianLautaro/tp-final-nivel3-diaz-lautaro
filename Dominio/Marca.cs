﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Marca
    {
        public int MId { get; set; }
        public string MDescripcion { get; set; }
        public override string ToString()
        {
            return MDescripcion;
        }
    }
}
