using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace pw_cakes.Server.Entities
{
    public class Utilisateur
    {
        [Key, Column("id")]
        public int? id {  get; set; }
        [Column("nom")]
        public string? nom { get; set; }
        [Column("prenom")]
        public string? prenom { get; set; }
        [Column("email")]
        public string? email { get; set; }
        [Column("telephone")]
        public string? telephone { get; set; }
        [Column("est_admin")]
        public bool? est_admin { get; set; }
        [Column("mdp")]
        public string? mdp { get; set; }

        // Un utilisateur peut passer plusieurs commandes
        [JsonIgnore]
        public ICollection<Commande> commandes { get; set; }
    }
}
