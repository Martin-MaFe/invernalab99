using InvernalabProject.Shared.Entities;
using Microsoft.IdentityModel.Tokens;

namespace InvernalabProject.Server.Models
{
    public class RolM
    {

        private InvernalabContext context;
        public RolM(InvernalabContext _context)
        {
            context = _context;
        }

        public List<Rol> getAllRol()
        {
            List<Rol> rols = context.Rols.ToList();
            if (rols.IsNullOrEmpty())
            {
                return null;
            }
            else
            {
                return rols;
            }
        }
    }
}

