using InvernalabProject.Server.Models;
using InvernalabProject.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace InvernalabProject.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class loginController : ControllerBase
	{
		private InvernalabContext context;
		public loginController(InvernalabContext _context)
		{
			this.context = _context;
		}

		[HttpPost]		
		public IActionResult recoverPassword([FromBody] Empresa com)
		{
			LoginM obj = new LoginM(context);
			Empresa company=obj.loginCompany(com.Usuario, com.Contraseña);
			if (company != null)
			{
				return Ok(new
				{
					data = company
				});
			}
			else
			{
				var objUser= obj.loginUser(com.Usuario, com.Contraseña);				

				if (objUser != null)
				{
					return Ok(new	
					{
						data = objUser
					});
				}
				
				return BadRequest(new
				{
					mensaje="Los datos ingresados no corresponden a una cuenta registrada"
				});
			}
		}
	}
}
