
using InvernalabProject.Server.Models;
using InvernalabProject.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InvernalabProject.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecoverPasswordController : ControllerBase
    {
        private InvernalabContext context;      
        public RecoverPasswordController(InvernalabContext _context)
        {
            this.context = _context; 
        }        

        [HttpPost]
        public IActionResult recoverPassword([FromBody] string mail)
        {
            RecoverPasswordM obj = new RecoverPasswordM(context);
            
            if (obj.SendEmailPassword(mail))
            {
                return Ok(new
                {
                    mensaje = "Se envio un email con las credenciales de ingreso al email registrado"
                });
            }
            else
            {
                return BadRequest(new
                {
                    message = "El email ingresado no esta registrado en nustra base de datos"
                });                     
            }            
        }
    }
}

