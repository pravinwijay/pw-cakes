using Microsoft.EntityFrameworkCore;
using pw_cakes.Server.Database;
using pw_cakes.Server.Entities;

namespace pw_cakes.Server.Services
{
    public class CommandeService
    {
        public readonly PwCakesDbContext _context;
        public CommandeService(PwCakesDbContext context)
        {
            _context = context;
        }
        public async Task<List<Commande>> GetAllOrdersAsync()
        {
            return await _context.commandes.ToListAsync();
        }
    }
}