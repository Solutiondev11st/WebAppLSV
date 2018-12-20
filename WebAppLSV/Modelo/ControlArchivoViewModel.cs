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
        [DataType(DataType.Upload)]
        [Display(Name = "Seleccione Archivo")]
        public string Nombre { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "IdArahivo")]
        public int IdArchivo { get; set; }
    }
}
