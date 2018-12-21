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
        public IList<Controlarchivo> ControlarchivoCargado { get; set; }

        [BindProperty]
        public ControlArchivoViewModel ControlarchivoVM { get; set; }

        public async Task OnGetAsync()
        {
            
 

            Controlarchivo = await _context.Controlarchivo
                                .Where(s=>s.Estado =="Cargado") 
                                .ToListAsync();

            
        }

       

        public async Task<IActionResult> OnPostProcesarArchivoAsync()
            
        {
            try
            {
                
                int v_error = 0;

                DbCommand cmd = _context.Database.GetDbConnection().CreateCommand();

                cmd.CommandText = "dbo.ProcesarArchivo";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IdArchivo", SqlDbType.Int) { Value = ControlarchivoVM.IdArchivo });
                cmd.Parameters.Add(new SqlParameter("@usuario", SqlDbType.VarChar) { Value = ControlarchivoVM.Usuario });

                cmd.Parameters.Add(new SqlParameter("@V_ERROR", SqlDbType.Int) { Direction = ParameterDirection.Output });

                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }

                await cmd.ExecuteNonQueryAsync();

                v_error = (int)cmd.Parameters["@V_ERROR"].Value;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEliminarArchivoAsync()

        {
            try
            {
                Controlarchivo Archivo = await _context.Controlarchivo.FindAsync(ControlarchivoVM.IdArchivo);

                if (Archivo != null)
                {
                    _context.Controlarchivo.Remove(Archivo);
                    await _context.SaveChangesAsync();

                }

                

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return RedirectToPage();
        }
    }
}
