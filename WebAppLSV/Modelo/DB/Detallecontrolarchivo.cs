using System;
using System.Collections.Generic;

namespace WebAppLSV.Modelo
{
    public partial class Detallecontrolarchivo
    {
        public int Id { get; set; }
        public string NumeroOrden { get; set; }
        public string OficinaOrigen { get; set; }
        public string DescOficinaOrigen { get; set; }
        public string Proyecto { get; set; }
        public string ValorMovilizado { get; set; }
        public string ValorComision { get; set; }
        public string Curso { get; set; }
        public string FechaFacturacion { get; set; }
        public string OficinaDestino { get; set; }
        public string ValorIva { get; set; }
        public string FechaCreps { get; set; }
        public string Codestudiante { get; set; }
        public string Documento { get; set; }
        public string Tipodoc { get; set; }
        public string Nombres { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int IdControlarchivo { get; set; }

        public Controlarchivo IdControlarchivoNavigation { get; set; }
    }
}
