using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppLSV.Modelo.DB;

namespace WebAppLSV.Pages.Home
{
    public class HistoricoCargarArchivoModel : PageModel
    {
        private readonly WebAppLSV.Modelo.DB.DBLSVContext _context;

        public HistoricoCargarArchivoModel(WebAppLSV.Modelo.DB.DBLSVContext context)
        {
            _context = context;
        }

        public IList<Controlarchivo> Controlarchivo { get;set; }

        public async Task OnGetAsync()
        {
             

            DateTime fechaconsultaFIN = DateTime.Today;

            DateTime fechaconsultaINI = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            Controlarchivo = await _context.Controlarchivo
                                    .Where(c => c.Estado == "Procesado")
                                    .Where(f => f.FechaCargar > fechaconsultaINI && f.FechaCargar < fechaconsultaFIN)
                                    .ToListAsync();
        }
    }
}
