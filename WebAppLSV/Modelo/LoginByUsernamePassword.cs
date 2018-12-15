using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLSV.Modelo
{
    public partial class LoginByUsernamePassword
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public int RolID { get; set; }
        public string Rol { get; set; }
        
    }
}
