using System;
using System.Collections.Generic;

namespace WebAppLSV.Modelo.DB
{
    public partial class Rolusuario
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }

        public Rol IdRolNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
    }
}
