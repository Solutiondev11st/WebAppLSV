#define SortFilterPage // SortFilterPage // SortFilter //SortOnly // first 

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
    #region snippet1
    public class HistoricoCargarArchivoModel : PageModel
    {
        private readonly WebAppLSV.Modelo.DB.DBLSVContext _context;

        public HistoricoCargarArchivoModel(WebAppLSV.Modelo.DB.DBLSVContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
    #endregion
        //public PaginatedList<Controlarchivo> Controlarchivo { get; set; }

#if SortFilterPage

        #region snippet_SortFilterPageType

        public PaginatedList<Controlarchivo> Controlarchivo { get;set; }

        #endregion

#else

        public IList<Controlarchivo> Controlarchivo { get; set; }

#endif

#if first

        #region snippet_ScaffoldedIndex

        public async Task OnGetAsync()

        {

            Controlarchivo = await _context.Controlarchivo.ToListAsync();

        }

        #endregion

#endif

#if SortOnly

        #region snippet_SortOnly

        public async Task OnGetAsync(string sortOrder)

        {

        #region snippet_Ternary

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

        #endregion



            IQueryable<Controlarchivo> ControlarchivoIQ = from s in _context.Controlarchivo
                                                            select s;



            switch (sortOrder)

            {

                case "name_desc":

                    ControlarchivoIQ = ControlarchivoIQ.OrderByDescending(s => s.Nombre);

                    break;

                case "Date":

                    ControlArchivoIQ = ControlarchivoIQ.OrderBy(s => s.Fecha_Proceso);

                    break;

                case "date_desc":

                    ControlArchivoIQ = ControlarchivoIQ.OrderByDescending(s => s.Fecha_Proceso);

                    break;

                default:

                    ControlArchivoIQ = ControlarchivoIQ.OrderBy(s => s.Nombre);

                    break;

            }



        #region snippet_SortOnlyRtn

            ControlArchivo = await ControlarchivoIQ.AsNoTracking().ToListAsync();

        #endregion

        }

        #endregion

#endif


#if SortFilter

        #region snippet_SortFilter

        public async Task OnGetAsync(string sortOrder, string searchString)

        {

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            CurrentFilter = searchString;



            IQueryable<Student> ControlArchivoIQ = from s in _context.ControlArchivo
                                                   select s;

            if (!String.IsNullOrEmpty(searchString))

            {

                ControlArchivoIQ = ControlArchivoIQ.Where(s => s.Nombre.Contains(searchString);
                                               
            }



            switch (sortOrder)

            {

                case "name_desc":

                    ControlArchivoIQ = ControlArchivoIQ.OrderByDescending(s => s.Nombre);

                    break;

                case "Date":

                    ControlArchivoIQ = ControlArchivoIQ.OrderBy(s => s.Fecha_Proceso);

                    break;

                case "date_desc":

                    ControlArchivoIQ = ControlArchivoIQ.OrderByDescending(s => s.Fecha_Proceso);

                    break;

                default:

                    ControlArchivoIQ = ControlArchivoIQ.OrderBy(s => s.Nombre);

                    break;

            }



            ControlArchivo = await ControlArchivoIQ.AsNoTracking().ToListAsync();

        }

        #endregion

#endif

#if SortFilterPage

        #region snippet_SortFilterPage

        #region snippet_SortFilterPage2

        public async Task OnGetAsync(string sortOrder,string currentFilter, string searchString, int? pageIndex)

        #endregion

        {

            DateTime fechaconsultaFIN = DateTime.Today;

            DateTime fechaconsultaINI = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            CurrentSort = sortOrder;

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            #region snippet_SortFilterPage3

            if (searchString != null)

            {

                pageIndex = 1;

            }

            else

            {

                searchString = currentFilter;

            }

            #endregion



            CurrentFilter = searchString;



            IQueryable<Controlarchivo> ControlarchivoIQ = from s in _context.Controlarchivo
                                                          select s;



            ControlarchivoIQ = ControlarchivoIQ.Where(c => c.Estado == "Procesado")
                                    .Where(f => f.FechaCargar > fechaconsultaINI && f.FechaCargar < fechaconsultaFIN);      

            if (!String.IsNullOrEmpty(searchString))

            {

                ControlarchivoIQ = ControlarchivoIQ.Where(s => s.Nombre.Contains(searchString));

                                      
            }

            switch (sortOrder)

            {

                case "name_desc":

                    ControlarchivoIQ = ControlarchivoIQ.OrderByDescending(s => s.Nombre);

                    break;

                case "Date":

                    ControlarchivoIQ = ControlarchivoIQ.OrderBy(s => s.FechaProceso);

                    break;

                case "date_desc":

                    ControlarchivoIQ = ControlarchivoIQ.OrderByDescending(s => s.FechaProceso);

                    break;

                default:

                    ControlarchivoIQ = ControlarchivoIQ.OrderBy(s => s.Nombre);

                    break;

            }

            int pageSize = 5;

            #region snippet_SortFilterPage4

            Controlarchivo = await PaginatedList<Controlarchivo>.CreateAsync(ControlarchivoIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

            #endregion

        }

        #endregion

#endif

        //public async Task OnGetAsync()
        //{
             

        //    DateTime fechaconsultaFIN = DateTime.Today;

        //    DateTime fechaconsultaINI = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

        //    Controlarchivo = await _context.Controlarchivo
        //                            .Where(c => c.Estado == "Procesado")
        //                            .Where(f => f.FechaCargar > fechaconsultaINI && f.FechaCargar < fechaconsultaFIN)
        //                            .ToListAsync();
        //}
    }
}
