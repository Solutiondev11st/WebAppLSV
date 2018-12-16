using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppLSV.Modelo
{
    public class ControlArchivoViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Seleccione Archivo")]
        public string Nombre { get; set; }
    }
}
