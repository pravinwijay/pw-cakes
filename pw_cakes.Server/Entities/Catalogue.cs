using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pw_cakes.Server.Entities
{
    public class Catalogue
    {
        [Key, Column("id")]
        public int id { get; set; }
        [Column("nom")]
        public string nom { get; set; }
        [Column("nb_parts")]
        public int nb_parts { get; set; }
        [Column("description")]
        public string description { get; set; }
        [Column("image")]
        public string image { get; set; }   
    }
}

