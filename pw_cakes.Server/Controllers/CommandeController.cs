using Microsoft.AspNetCore.Mvc;
using pw_cakes.Server.Dto;
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
        /// <returns>La liste des commandes - 200 OK</returns>
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

        /// <summary>
        /// Retourne une commande par son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var commande = await _commandeService.GetOrderByIdAsync(id);
            if (commande == null)
            {
                return NotFound("Commande introuvable");
            }
            return Ok(commande);
        }

        /// <summary>
        /// Met à jour une commande
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commandeDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] CommandeDto commandeDto)
        {
            if (commandeDto == null)
            {
                return BadRequest("Commande nulle");
            }
            var updatedOrder = await _commandeService.UpdateOrderAsync(id, commandeDto);
            if (updatedOrder == null)
            {
                return NotFound("Commande introuvable");
            }
            return Ok(updatedOrder);
        }

        /// <summary>
        /// Supprime une commande
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var deletedOrder = await _commandeService.DeleteOrderAsync(id);
            if (deletedOrder == null)
            {
                return NotFound("Commande introuvable");
            }
            return Ok(deletedOrder);
        }
    }
}