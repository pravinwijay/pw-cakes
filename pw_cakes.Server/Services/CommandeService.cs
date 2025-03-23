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

        /// <summary>
        /// Retourne la liste des commandes
        /// </summary>
        /// <returns>Une liste de commandes</returns>
        public async Task<List<Commande>> GetAllOrdersAsync()
        {
            return await _context.commandes.ToListAsync();
        }

        /// <summary>
        /// Ajoute une commande de gâteau
        /// </summary>
        /// <param name="commandeDto"></param>
        /// <returns>Si réussi : Code 201</returns>
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

        /// <summary>
        /// Retourne une commande par son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Commande?> GetOrderByIdAsync(int id)
        {
            return await _context.commandes.FindAsync(id);
        }

        /// <summary>
        /// Met à jour une commande
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commandeDto"></param>
        /// <returns></returns>
        public async Task<Commande?> UpdateOrderAsync(int id, CommandeDto commandeDto)
        {
            var commande = await _context.commandes.FindAsync(id);
            if (commande == null)
            {
                return null;
            }
            commande.type = commandeDto.type;
            commande.nb_parts = commandeDto.nb_parts;
            commande.info_supplementaires = commandeDto.info_supplementaires;
            commande.prix = commandeDto.prix;
            commande.date_livraison = commandeDto.date_livraison;
            commande.type_livraison = commandeDto.type_livraison;
            commande.id_client = commandeDto.id_client;
            await _context.SaveChangesAsync();
            return commande;
        }

        /// <summary>
        /// Supprime une commande
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Commande?> DeleteOrderAsync(int id)
        {
            var commande = await _context.commandes.FindAsync(id);
            if (commande == null)
            {
                return null;
            }
            _context.commandes.Remove(commande);
            await _context.SaveChangesAsync();
            return commande;
        }
    }

}