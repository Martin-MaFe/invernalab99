using InvernalabProject.Server.Models;
using InvernalabProject.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InvernalabProject.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreateCompanyController : ControllerBase
    {
        private readonly InvernalabContext _context;
      
        public CreateCompanyController(InvernalabContext context )
        {
            
            _context = context;
        }

        [HttpPost("Save")]

        public IActionResult GuardarEmpresa([FromForm] RestriccionesEmpresa nuevaEmpresa, [FromForm] IFormFile? logo)
        {
            if (ModelState.IsValid)
            {
                //mapeo
                

                var empresa = new Empresa
                {
                    Nombre = nuevaEmpresa.Nombre,
                    
                    //Estado = nuevaEmpresa.Estado=1,
                    Nit = nuevaEmpresa.Nit,
                    Usuario = nuevaEmpresa.Usuario,
                    Contraseña = nuevaEmpresa.Contraseña,
                    FechaInsert = DateTime.Now
                };


                if (empresa.NitExits(_context))
                {
                    ModelState.AddModelError("Nit", "Ya existe una empresa con este Nit.");
                    return BadRequest(ModelState);
                }

                
          

                _context.Empresas.Add(empresa);
                _context.SaveChanges();


                if (logo != null)
                {
                    //codicion para que sea formato png
                    if (logo.ContentType == "image/png" || logo.ContentType == "image/jpg" || logo.ContentType == "image/jpeg")
                    {
                        var wwwrootPath = Path.Combine("..", "Client", "wwwroot");


                        var directoryPath = Path.Combine(wwwrootPath, "logos", "imagen");

                        var fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(logo.FileName);

                        var filePath = Path.Combine(directoryPath, fileName);


                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            logo.CopyTo(stream);
                        }


                        empresa.Logo = $"/logos/imagen/{fileName}";
                        _context.SaveChanges();

                    }
                    else
                    {
                    
                        ModelState.AddModelError("Logo", "El archivo debe ser una imagen PNG, JPG o JPEG.");
                        return BadRequest(ModelState);
                    }


                }
                else
                {
                    empresa.Logo = "/logos/imagen/logodefecto.png";
                    _context.SaveChanges();
                }


                string welcomeMessage = "¡Bienvenido a Invernalab Company! Gracias por confiar en nosotros.";

                //crear una instancia
                var CompanyEmail = new CompanyEmail();
                CompanyEmail.SendEmail(nuevaEmpresa.Usuario, welcomeMessage, nuevaEmpresa.Contraseña);

                return Ok(new { mensaje = "Empresa Registrada Exitosamente" });

            }


            return BadRequest(ModelState);




        }
    }
    
}
   