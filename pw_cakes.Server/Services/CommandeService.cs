using Microsoft.EntityFrameworkCore;
using pw_cakes.Server.Database;
using pw_cakes.Server.Dto;
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

        public async Task<Commande?> AddOrderAsync(CommandeDto commandeDto)
        {
            var utilisateur = await _context.utilisateurs.FindAsync(commandeDto.id_client);
            if (utilisateur == null)
            {
                return null;
            }

            // Création de la nouvelle commande
            var commande = new Commande
            {
                type = commandeDto.type,
                nb_parts = commandeDto.nb_parts,
                info_supplementaires = commandeDto.info_supplementaires,
                prix = commandeDto.prix,
                date_livraison = commandeDto.date_livraison,
                type_livraison = commandeDto.type_livraison,
                id_client = commandeDto.id_client
            };

            // Ajout à la BD
            await _context.commandes.AddAsync(commande);
            await _context.SaveChangesAsync();
            return commande;
        }
    }

}