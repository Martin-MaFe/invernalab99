using InvernalabProject.Server.Models;
using InvernalabProject.Shared.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace InvernalabProject.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkersInformationController : Controller
    {
        private InvernalabContext context;
        public WorkersInformationController(InvernalabContext _context)
        {
            this.context = _context;
        }

        [HttpGet]
        public IActionResult GetAllWorkers()
        {
            WorkersM obj = new WorkersM(context);
            if (!obj.getAllWorkers().IsNullOrEmpty())
            {
                return Ok(
                    new
                    {
                        users = obj.getAllWorkers(),
                    });
            }
            else
            {
                return NotFound(new
                {
                    message = "No se encontraron registros de empleados"
                });
            }
        }

        [HttpGet]
        [Route("byRol")]
        public IActionResult findWorkerByRol([FromQuery] int idRol)
        {
            WorkersM obj = new WorkersM(context);
            if (!obj.getWorkerByRol(idRol).IsNullOrEmpty())
            {
                return Ok(
                    new
                    {
                        users = obj.getWorkerByRol(idRol),
                    });
            }
            else
            {
                return NotFound(new
                {
                    message = "No se encontraron registros de trabajadores con el rol especificado"
                });
            }

        }


    }
}
