using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppLSV.Modelo.DB;
using WebAppLSV.Modelo;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

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

        //public async Task OnPostProcesarArchivo(int )
        //{
        //    Controlarchivo = await _context.Controlarchivo.ToListAsync();
        //}

        public async Task OnPostProcesarArchivoAsync()
            
        {
            try
            {
                // Verification.
                if (ModelState.IsValid)
                {

                    DbCommand cmd = _context.Database.GetDbConnection().CreateCommand();

                    cmd.CommandText = "dbo.ProcesarArchivo";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IdArchivo", SqlDbType.Int) { Value = 5 });
                    cmd.Parameters.Add(new SqlParameter("@usuario", SqlDbType.VarChar) { Value = User.Identity.Name });

                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Direction = ParameterDirection.Output });

                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }

                    await cmd.ExecuteNonQueryAsync();

                    int id = (int)cmd.Parameters["@lId"].Value;

                    RedirectToPage("/Index");
                }
                else
                {
                    // Setting.
                    ModelState.AddModelError(string.Empty, "Estado del modelo Invalido.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
