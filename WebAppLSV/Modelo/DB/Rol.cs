using System;
using System.Collections.Generic;

namespace WebAppLSV.Modelo
{
    public partial class Rol
    {
        public Rol()
        {
            Rolusuario = new HashSet<Rolusuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Rolusuario> Rolusuario { get; set; }
    }
}
