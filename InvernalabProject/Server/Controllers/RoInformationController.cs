using InvernalabProject.Server.Models;
using InvernalabProject.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InvernalabProject.Server.Controllers
{
    [ApiController]
    [Route("rols")]
    public class RoInformationController : Controller
    {

        private InvernalabContext context;
        public RoInformationController(InvernalabContext _context)
        {
            this.context = _context;
        }

        [HttpGet]
        public IActionResult GetAllRol() {
            RolM obj = new RolM(context);
            if (!obj.getAllRol().IsNullOrEmpty()) {
                return Ok(new
                {
                    rols=obj.getAllRol(),
                });
            }
            else
            {
                return NotFound(new
                {
                    messaje="No se encontro ningun rol registrado"
                });
            }
        }
    }
}
