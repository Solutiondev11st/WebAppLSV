using System;
using System.Collections.Generic;

namespace WebAppLSV.Modelo.DB
{
    public partial class Documentosecretaria
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public int IdCurso { get; set; }
        public int IdEstudiante { get; set; }
        public string ValorAño { get; set; }
        public string Observaciones { get; set; }
        public string NombreSolicitante { get; set; }
        public string TelefonosSolicitante { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Valor { get; set; }
        public string Cantidad { get; set; }
        public string Usuario { get; set; }

        public Curso IdCursoNavigation { get; set; }
        public Estudiante IdEstudianteNavigation { get; set; }
    }
}
