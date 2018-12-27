using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppLSV.Modelo.DB;

namespace WebAppLSV.Pages.Certifications
{
    public class EditModel : PageModel
    {
        private readonly WebAppLSV.Modelo.DB.DBLSVContext _context;

        public EditModel(WebAppLSV.Modelo.DB.DBLSVContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["IdCurso"] = new SelectList(_context.Curso, "Id", "Identificador");
           ViewData["IdEstudiante"] = new SelectList(_context.Estudiante, "Id", "Apellido");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Documentosecretaria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentosecretariaExists(Documentosecretaria.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DocumentosecretariaExists(int id)
        {
            return _context.Documentosecretaria.Any(e => e.Id == id);
        }
    }
}
