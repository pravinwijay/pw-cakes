using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pw_cakes.Server.Entities
{
    public class Commande
    {
        [Key, Column("id")]
        public int? id { get; set; }
        [Column("id_client")]
        public int? id_client { get; set; }
        [Column("type")]
        public string? type { get; set; }
        [Column("nb_parts")]
        public int? nb_parts { get; set; }
        [Column("info_supplementaires")]
        public string? info_supplementaires { get; set; }
        [Column("date_livraison")]
        public DateTime? date_livraison { get; set; }
        [Column("type_livraison")]
        public string? type_livraison { get; set; }
    }
}
