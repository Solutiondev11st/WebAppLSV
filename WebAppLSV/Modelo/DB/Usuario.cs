using System;
using System.Collections.Generic;

namespace WebAppLSV.Modelo
{
    public partial class Usuario
    {
        public Usuario()
        {
            Rolusuario = new HashSet<Rolusuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Usuario1 { get; set; }
        public string Passwd { get; set; }

        public ICollection<Rolusuario> Rolusuario { get; set; }
    }
}
