using System.Data.SqlClient;
using System.Configuration;
using Microsoft.SqlServer;
using Microsoft.EntityFrameworkCore;
using pw_cakes.Server.Entities;

namespace pw_cakes.Server.Database
{
    public class PwCakesDbContext: DbContext
    {
        public PwCakesDbContext(DbContextOptions<PwCakesDbContext> options): base(options) 
        {}
        public DbSet<Commande> commandes { get; set; }
        public DbSet<Utilisateur> utilisateurs { get; set; }
        public DbSet<Catalogue> catalogue { get; set; }

        // Pour gérer la relation entre Commande et Utilisateur
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commande>()
                .HasOne(c => c.utilisateur)
                .WithMany(u => u.commandes)
                .HasForeignKey(c => c.id_client)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
