using Microsoft.EntityFrameworkCore;
using pw_cakes.Server.Database;
using pw_cakes.Server.Entities;

namespace pw_cakes.Server.Services
{
    public class UtilisateurService
    {
        public readonly PwCakesDbContext _context;
        public UtilisateurService (PwCakesDbContext context)
        {
            _context = context;
        }

        public async Task<List<Utilisateur>> GetAllUsersAsync()
        {
            return await _context.utilisateurs.ToListAsync();
        }
    }
}
