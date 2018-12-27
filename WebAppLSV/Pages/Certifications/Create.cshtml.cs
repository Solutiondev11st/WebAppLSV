using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppLSV.Modelo.DB;

namespace WebAppLSV.Pages.Certifications
{
    public class CreateModel : PageModel
    {
        private readonly WebAppLSV.Modelo.DB.DBLSVContext _context;

        public CreateModel(WebAppLSV.Modelo.DB.DBLSVContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdCurso"] = new SelectList(_context.Curso, "Id", "Identificador");
        ViewData["IdEstudiante"] = new SelectList(_context.Estudiante, "Id", "Apellido");
            return Page();
        }

        [BindProperty]
        public Documentosecretaria Documentosecretaria { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Documentosecretaria.Add(Documentosecretaria);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}