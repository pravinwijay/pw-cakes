using Microsoft.AspNetCore.Mvc;
using pw_cakes.Server.Dto;
using pw_cakes.Server.Entities;
using pw_cakes.Server.Services;

namespace pw_cakes.Server.Controllers
{
    [ApiController]
    [Route("commandes")]
    [Tags("Commandes")]
    public class CommandeController : ControllerBase
    {
        private readonly CommandeService _commandeService;
        public CommandeController(CommandeService commandeService)
        {
            _commandeService = commandeService;
        }

        /// <summary>
        /// Retourne la liste des commandes
        /// </summary>
        /// <returns>Liste de commandes</returns>
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


        /// <summary>
        /// Ajoute une commande de gâteau
        /// </summary>
        /// <param name="commandeDto"></param>
        /// <returns>HTTP Status Code 201 Created</returns>
        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] CommandeDto commandeDto)
        {
            if (commandeDto == null)
            {
                return BadRequest("Nul Germain");
            }

            var nouvelleCommande = await _commandeService.AddOrderAsync(commandeDto);
            if (nouvelleCommande == null)
            {
                return NotFound("Tjr nul");
            }

            return CreatedAtAction(nameof(GetOrders), new { id = nouvelleCommande.id }, nouvelleCommande);
        }
    }
}