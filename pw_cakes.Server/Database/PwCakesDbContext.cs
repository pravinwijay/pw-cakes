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
    }
}
