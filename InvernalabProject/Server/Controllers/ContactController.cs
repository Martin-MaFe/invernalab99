using InvernalabProject.Server.Models;
using InvernalabProject.Shared.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace InvernalabProject.Server.Controllers
{
    [ApiController]
    [Route("contact")]
    public class ContactController : ControllerBase
    {

        [HttpPost]
        [Route("sendMail")]
        public IActionResult SendEmail([FromBody] UserFormContactE user)
        {
            SendContactMail obj = new SendContactMail();
            if (!obj.CreateEmailInvernalabM(user))
            {
                return BadRequest(
                    new
                    {   
                        message = "Error al enviar email a Invernalab"
                    });
            }
            else if (!obj.CreateEmailResponseM(user))
            {
                return BadRequest(
                    new
                    {
                        message = "Error al enviar email de respuesta"
                    });
            }
            else
            {
                return Ok(
                   new
                   {
                       message = "Solicitud enviada",
                       dataUser = user
                   });
            }
        }
    }
}
