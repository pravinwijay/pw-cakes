using Microsoft.AspNetCore.Mvc;
using pw_cakes.Server.Services;

namespace pw_cakes.Server.Controllers
{
    [ApiController]
    [Route("commandes")]
    [Tags("Récupération de toutes les commandes")]
    public class CommandeController : ControllerBase
    {
        private readonly CommandeService _commandeService;
        public CommandeController(CommandeService commandeService)
        {
            {
                _commandeService = commandeService;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders() 
        {
            var commandes = await _commandeService.GetAllOrdersAsync();
            if (!commandes.Any())
            {
                return NotFound("Contains no orders");
            }
            return Ok(commandes);
        }
    }
}
