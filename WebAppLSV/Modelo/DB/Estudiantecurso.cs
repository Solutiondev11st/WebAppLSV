using System;
using System.Collections.Generic;

namespace WebAppLSV.Modelo.DB
{
    public partial class Estudiantecurso
    {
        public int Id { get; set; }
        public int IdEstudiante { get; set; }
        public int IdCurso { get; set; }
        public string Estado { get; set; }

        public Curso IdCursoNavigation { get; set; }
        public Estudiante IdEstudianteNavigation { get; set; }
    }
}
