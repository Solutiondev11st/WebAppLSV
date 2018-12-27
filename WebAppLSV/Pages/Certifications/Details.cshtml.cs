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
    public class DetailsModel : PageModel
    {
        private readonly WebAppLSV.Modelo.DB.DBLSVContext _context;

        public DetailsModel(WebAppLSV.Modelo.DB.DBLSVContext context)
        {
            _context = context;
        }

        public Documentosecretaria Documentosecretaria { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Documentosecretaria = await _context.Documentosecretaria
                .Include(d => d.IdCursoNavigation)
                .Include(d => d.IdEstudianteNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (Documentosecretaria == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
