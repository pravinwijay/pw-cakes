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

        public async Task<List<Catalogue>> GetFromCatalogueAsync()
        {
            return await _context.catalogue.ToListAsync();
        }

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
        
    }
}
