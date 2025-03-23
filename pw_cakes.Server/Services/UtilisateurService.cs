using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pw_cakes.Server.Database;
using pw_cakes.Server.Dto;
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
        /// <summary>
        /// Retourne la liste des utilisateurs
        /// </summary>
        /// <returns>Une liste d'utilisateurs</returns>
        public async Task<List<Utilisateur>> GetAllUsersAsync()
        {
            return await _context.utilisateurs.ToListAsync();
        }

        public async Task<Utilisateur?> AddUserAsync(UtilisateurDto utilisateurDto)
        {
            // Création du nouvel utilisateur
            var utilisateur = new Utilisateur
            {
                nom = utilisateurDto.nom,
                prenom = utilisateurDto.prenom,
                email = utilisateurDto.email,
                telephone = utilisateurDto.telephone,
                est_admin = utilisateurDto.est_admin,
                mdp = utilisateurDto.mdp
            };
            // Ajout à la BD
            await _context.utilisateurs.AddAsync(utilisateur);
            await _context.SaveChangesAsync();
            return utilisateur;
        }

        /// <summary>
        /// Retourne un utilisateur par son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Utilisateur?> GetUserByIdAsync(int id)
        {
            return await _context.utilisateurs.FindAsync(id);
        }

        /// <summary>
        /// Met à jour un utilisateur
        /// </summary>
        /// <param name="id"></param>
        /// <param name="utilisateurDto"></param>
        /// <returns></returns>
        public async Task<Utilisateur?> UpdateUserAsync(int id, UtilisateurDto utilisateurDto)
        {
            var utilisateur = await _context.utilisateurs.FindAsync(id);
            if (utilisateur == null)
            {
                return null;
            }
            utilisateur.nom = utilisateurDto.nom;
            utilisateur.prenom = utilisateurDto.prenom;
            utilisateur.email = utilisateurDto.email;
            utilisateur.telephone = utilisateurDto.telephone;
            utilisateur.est_admin = utilisateurDto.est_admin;
            utilisateur.mdp = utilisateurDto.mdp;
            await _context.SaveChangesAsync();
            return utilisateur;
        }

        /// <summary>
        /// Supprime un utilisateur
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Utilisateur?> DeleteUserAsync(int id)
        {
            var utilisateur = await _context.utilisateurs.FindAsync(id);
            if (utilisateur == null)
            {
                return null;
            }
            _context.utilisateurs.Remove(utilisateur);
            await _context.SaveChangesAsync();
            return utilisateur;
        }
    }
}
