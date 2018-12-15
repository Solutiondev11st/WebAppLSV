using System;
using System.Collections.Generic;

namespace WebAppLSV.Modelo.DB
{
    public partial class Parametro
    {
        public Parametro()
        {
            Valorparametro = new HashSet<Valorparametro>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdTipoParametro { get; set; }

        public Tipoparametro IdTipoParametroNavigation { get; set; }
        public ICollection<Valorparametro> Valorparametro { get; set; }
    }
}
