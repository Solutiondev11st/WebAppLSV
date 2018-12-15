using System;
using System.Collections.Generic;

namespace WebAppLSV.Modelo.DB
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Documentosecretaria = new HashSet<Documentosecretaria>();
            Estudiantecurso = new HashSet<Estudiantecurso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Tipodoc { get; set; }
        public string Estado { get; set; }

        public ICollection<Documentosecretaria> Documentosecretaria { get; set; }
        public ICollection<Estudiantecurso> Estudiantecurso { get; set; }
    }
}
