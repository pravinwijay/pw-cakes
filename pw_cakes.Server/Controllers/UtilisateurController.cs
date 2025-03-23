using Microsoft.AspNetCore.Mvc;
using pw_cakes.Server.Dto;
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

        /// <summary>
        /// Retourne la liste des utilisateurs
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Ajoute un utilisateur
        /// </summary>
        /// <param name="utilisateurDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UtilisateurDto utilisateurDto)
        {
            if (utilisateurDto == null)
            {
                return BadRequest("User is null");
            }
            var newUser = await _utilisateurService.AddUserAsync(utilisateurDto);
            if (newUser == null)
            {
                return NotFound("User not found");
            }
            return CreatedAtAction(nameof(GetUsers), new { id = newUser.id }, newUser);
        }

        /// <summary>
        /// Retourne un utilisateur par son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var utilisateur = await _utilisateurService.GetUserByIdAsync(id);
            if (utilisateur == null)
            {
                return NotFound("User not found");
            }
            return Ok(utilisateur);
        }

        /// <summary>
        /// Met à jour un utilisateur
        /// </summary>
        /// <param name="id"></param>
        /// <param name="utilisateurDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UtilisateurDto utilisateurDto)
        {
            if (utilisateurDto == null)
            {
                return BadRequest("User is null");
            }
            var updatedUser = await _utilisateurService.UpdateUserAsync(id, utilisateurDto);
            if (updatedUser == null)
            {
                return NotFound("User not found");
            }
            return Ok(updatedUser);
        }

        /// <summary>
        /// Supprime un utilisateur
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var utilisateur = await _utilisateurService.GetUserByIdAsync(id);
            if (utilisateur == null)
            {
                return NotFound("User not found");
            }
            await _utilisateurService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
