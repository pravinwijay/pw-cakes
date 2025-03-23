namespace pw_cakes.Server.Dto
{
    public class UtilisateurDto
    {
        public string? nom { get; set; }
        public string? prenom { get; set; }
        public string? email { get; set; }
        public string telephone { get; set; }
        public bool? est_admin { get; set; }
        public string mdp { get; set; }
    }
}
