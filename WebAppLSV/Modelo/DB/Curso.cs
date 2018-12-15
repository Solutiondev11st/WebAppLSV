using System;
using System.Collections.Generic;

namespace WebAppLSV.Modelo.DB
{
    public partial class Curso
    {
        public Curso()
        {
            Documentosecretaria = new HashSet<Documentosecretaria>();
            Estudiantecurso = new HashSet<Estudiantecurso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Identificador { get; set; }

        public ICollection<Documentosecretaria> Documentosecretaria { get; set; }
        public ICollection<Estudiantecurso> Estudiantecurso { get; set; }
    }
}
