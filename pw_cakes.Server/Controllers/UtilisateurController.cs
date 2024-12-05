using Microsoft.AspNetCore.Mvc;
using pw_cakes.Server.Services;

namespace pw_cakes.Server.Controllers
{
    [ApiController]
    [Route("utilisateurs")]
    [Tags("Utilisateur")]
    public class UtilisateurController : ControllerBase
    {
        private readonly UtilisateurService _utilisateurService;
        public UtilisateurController(UtilisateurService utilisateurService)
        {
            _utilisateurService = utilisateurService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var utilisateur = await _utilisateurService.GetAllUsersAsync();
            if (!utilisateur.Any())
            {
                return NotFound("User not found");
            }
            return Ok(utilisateur);
        }
    }
}
