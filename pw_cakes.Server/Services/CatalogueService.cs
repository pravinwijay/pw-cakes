using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using pw_cakes.Server.Database;
using pw_cakes.Server.Dto;
using pw_cakes.Server.Entities;

namespace pw_cakes.Server.Services
{
    public class CatalogueService
    {
        public readonly PwCakesDbContext _context;
        public CatalogueService(PwCakesDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retourne la liste des gâteaux du catalogue
        /// </summary>
        /// <returns></returns>
        public async Task<List<Catalogue>> GetAllFromCatalogueAsync()
        {
            return await _context.catalogue.ToListAsync();
        }

        /// <summary>
        /// Ajoute un gâteau au catalogue
        /// </summary>
        /// <param name="catalogueDto"></param>
        /// <returns></returns>
        public async Task<Catalogue?> AddToCatalogueAsync(CatalogueDto catalogueDto)
        {
            // Création d'un nouveau gâteau pour le catalogue
            var gateau = new Catalogue
            {
                nom = catalogueDto.nom,
                nb_parts = catalogueDto.nb_parts,
                description = catalogueDto.description,
                image = catalogueDto.image,
            };
            
            // Ajout à la BD
            await _context.catalogue.AddAsync(gateau);
            await _context.SaveChangesAsync();
            return gateau;
        }
        /// <summary>
        /// Retourne un gâteau du catalogue par son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Catalogue?> GetFromCatalogueByIdAsync(int id)
        {
            return await _context.catalogue.FindAsync(id);
        }

        /// <summary>
        /// Met à jour un gâteau du catalogue
        /// </summary>
        /// <param name="id"></param>
        /// <param name="catalogueDto"></param>
        /// <returns></returns>
        public async Task<Catalogue?> UpdateCatalogueAsync(int id, CatalogueDto catalogueDto)
        {
            var gateau = await _context.catalogue.FindAsync(id);
            if (gateau == null)
            {
                return null;
            }
            gateau.nom = catalogueDto.nom;
            gateau.nb_parts = catalogueDto.nb_parts;
            gateau.description = catalogueDto.description;
            gateau.image = catalogueDto.image;
            await _context.SaveChangesAsync();
            return gateau;
        }

        /// <summary>
        /// Supprime un gâteau du catalogue
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Catalogue?> DeleteFromCatalogueAsync(int id)
        {
            var gateau = await _context.catalogue.FindAsync(id);
            if (gateau == null)
            {
                return null;
            }
            _context.catalogue.Remove(gateau);
            await _context.SaveChangesAsync();
            return gateau;
        }
    }
}
