using InvernalabProject.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InvernalabProject.Server.Models
{
    public class WorkersM
    {
        private InvernalabContext context;
        public WorkersM(InvernalabContext _context)
        {
            context = _context;
        }
        public List<Usuario> getAllWorkers()
        {
            List<Usuario> users = context.Usuarios.ToList();
            if (users.IsNullOrEmpty())
            {
                return null;
            }
            else
            {
                return users;
            }
        }

       
        public List<Usuario> getWorkerByRol(int idRol)
        {
            List<Usuario> users= context.Usuarios
                .Where(u => u.IdRol == idRol).ToList(); 

            if (users.IsNullOrEmpty())
            {
                return null;
            }
            else
            {
                return users.ToList();
            }
        }

    }
}
