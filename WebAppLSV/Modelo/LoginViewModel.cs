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

        /// <summary>  
        /// Gets or sets to username address.  
        /// </summary>  
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Usuario")]
        public string Username { get; set; }

        /// <summary>  
        /// Gets or sets to password address.  
        /// </summary>  
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        #endregion
    }
}
