using System;
using System.Collections.Generic;

namespace WebAppLSV.Modelo.DB
{
    public partial class Controlarchivo
    {
        public Controlarchivo()
        {
            Detallecontrolarchivo = new HashSet<Detallecontrolarchivo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCargar { get; set; }
        public DateTime FechaProceso { get; set; }
        public string Usuario { get; set; }

        public ICollection<Detallecontrolarchivo> Detallecontrolarchivo { get; set; }
    }
}
