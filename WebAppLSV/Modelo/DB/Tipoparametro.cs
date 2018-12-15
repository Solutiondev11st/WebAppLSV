using System;
using System.Collections.Generic;

namespace WebAppLSV.Modelo.DB
{
    public partial class Tipoparametro
    {
        public Tipoparametro()
        {
            Parametro = new HashSet<Parametro>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Parametro> Parametro { get; set; }
    }
}
