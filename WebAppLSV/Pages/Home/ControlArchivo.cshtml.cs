using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppLSV.Modelo.DB;
using WebAppLSV.Modelo;


namespace WebAppLSV.Pages.Home
{
    public class ControlArchivoModel : PageModel
    {
        private readonly WebAppLSV.Modelo.DB.DBLSVContext _context;

        public ControlArchivoModel(WebAppLSV.Modelo.DB.DBLSVContext context)
        {
            _context = context;
        }

        public IList<Controlarchivo> Controlarchivo { get;set; }

        [BindProperty]
        public ControlArchivoViewModel ControlarchivoVM { get; set; }

        public async Task OnGetAsync()
        {
            Controlarchivo = await _context.Controlarchivo.ToListAsync();
        }
    }
}
