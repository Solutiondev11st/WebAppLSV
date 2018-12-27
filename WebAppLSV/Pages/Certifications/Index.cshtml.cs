using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppLSV.Modelo.DB;

namespace WebAppLSV.Pages.Certifications
{
    public class IndexModel : PageModel
    {
        private readonly WebAppLSV.Modelo.DB.DBLSVContext _context;

        public IndexModel(WebAppLSV.Modelo.DB.DBLSVContext context)
        {
            _context = context;
        }

        public IList<Documentosecretaria> Documentosecretaria { get;set; }

        public async Task OnGetAsync()
        {
            Documentosecretaria = await _context.Documentosecretaria
                .Include(d => d.IdCursoNavigation)
                .Include(d => d.IdEstudianteNavigation).ToListAsync();
        }
    }
}
