using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pw_cakes.Server.Entities
{
    public class Utilisateur
    {
        [Key, Column("id")]
        public int id {  get; set; }
        [Column("nom")]
        public string nom { get; set; }
        [Column("prenom")]
        public string prenom { get; set; }
        [Column("email")]
        public string email { get; set; }
        [Column("telephone")]
        public int telephone { get; set; }
        [Column("est_admin")]
        public string est_admin { get; set; }
        [Column("mdp")]
        public string mdp { get; set; }
    }
}
