using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppLSV.Modelo
{
    /// <summary>  
    /// Login view model class.  
    /// </summary>  
    public class LoginViewModel
    {
        #region Properties  
 
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Usuario")]
        public string Username { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        #endregion
    }
}
