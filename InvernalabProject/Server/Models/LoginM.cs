using InvernalabProject.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace InvernalabProject.Server.Models
{
	public class LoginM
	{
		private InvernalabContext context;
		public LoginM(InvernalabContext _context)
		{
			context = _context;
		}
		public Empresa loginCompany(string user, string password)
		{
			Empresa company = context.Empresas.FirstOrDefault(u => u.Usuario == user.Replace(" ", "") && u.Contraseña==password);

			if (company == null)
			{
				return null;
			}
			else 
			{
				return company;
			}			
		}

		public dynamic loginUser(string user, string password)
		{
			var objUser = context.Usuarios
				.Where(u => u.Email == user.Replace(" ", "") && u.Contraseña == password)
				.Select(u => new
				{
				u.IdUsuario,
				u.Nombre,
				u.Apellido,				
				u.Email,
				u.Contraseña,
				u.Foto,
				u.IdEmpresa,
				u.IdRol,
				EstadoEmpresa = u.IdEmpresaNavigation.Estado,
				NombreEmpresa=u.IdEmpresaNavigation.Nombre,
				NombreRol=u.IdRolNavigation.NombreRol
				})
				.FirstOrDefault();

			if (objUser == null)
			{
				return null;
			}
			else
			{
				return objUser;
			}
		}
	}
}
	