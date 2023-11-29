using InvernalabProject.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InvernalabProject.Server.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ListCompanyController : ControllerBase
    {
        private readonly InvernalabContext _context;

        public ListCompanyController(InvernalabContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            try
            {
                var empresas = await _context.Empresas
                    .OrderByDescending(e => e.IdEmpresa)
                    .Select(e => new Empresa
                    {
                        Nombre = e.Nombre,
                        Logo = e.Logo,
                        Nit = e.Nit,
                        Usuario = e.Usuario,

                    })
                    .ToListAsync();

                return Ok(empresas);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error al procesar la solicitud: {ex}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
