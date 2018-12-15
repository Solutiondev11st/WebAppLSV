using System;
using System.Collections.Generic;

namespace WebAppLSV.Modelo.DB
{
    public partial class Valorparametro
    {
        public int Id { get; set; }
        public string Valor { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Usuario { get; set; }
        public string Estado { get; set; }
        public int IdParametro { get; set; }

        public Parametro IdParametroNavigation { get; set; }
    }
}
