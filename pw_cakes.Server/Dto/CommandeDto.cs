namespace pw_cakes.Server.Dto
{
    public class CommandeDto
    {
        public string? type { get; set; }
        public int id_client { get; set; }
        public int nb_parts { get; set; }
        public string? info_supplementaires { get; set; }
        public DateTime date_livraison { get; set; }
        public string? type_livraison { get; set; }
        public double? prix { get; set; }
    }
}
