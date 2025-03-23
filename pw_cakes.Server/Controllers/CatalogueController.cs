using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using pw_cakes.Server.Dto;
using pw_cakes.Server.Entities;
using pw_cakes.Server.Services;

namespace pw_cakes.Server.Controllers
{
    [ApiController]
    [Route("catalogue")]
    [Tags("Catalogue")]
    public class CatalogueController : ControllerBase
    {
        private readonly CatalogueService _catalogueService;
        public CatalogueController(CatalogueService catalogueService)
        {
            _catalogueService = catalogueService;
        }

        /// <summary>
        /// Retourne la liste des gâteaux du catalogue
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllFromCatalogue()
        {
            var catalogue = await _catalogueService.GetAllFromCatalogueAsync();
            if(!catalogue.Any())
            {
                return NotFound("Nothing here");
            }
            return Ok(catalogue);
        }

        /// <summary>
        /// Ajoute un gâteau au catalogue
        /// </summary>
        /// <param name="catalogueDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddToCatalogue([FromBody] CatalogueDto catalogueDto)
        {
            if(catalogueDto == null)
            {
                return BadRequest("Catalogue is null");
            }
            var newCake = await _catalogueService.AddToCatalogueAsync(catalogueDto);
            if(newCake == null)
            {
                return NotFound("Cake not found");
            }
            return CreatedAtAction(nameof(GetAllFromCatalogue), new { id = newCake.id }, newCake);
        }

        /// <summary>
        /// Retourne un gâteau du catalogue par son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFromCatalogueById(int id)
        {
            var cake = await _catalogueService.GetFromCatalogueByIdAsync(id);
            if (cake == null)
            {
                return NotFound("Cake not found");
            }
            return Ok(cake);
        }

        /// <summary>
        /// Met à jour un gâteau du catalogue
        /// </summary>
        /// <param name="id"></param>
        /// <param name="catalogueDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCatalogue(int id, [FromBody] CatalogueDto catalogueDto)
        {
            if (catalogueDto == null)
            {
                return BadRequest("Catalogue is null");
            }
            var updatedCake = await _catalogueService.UpdateCatalogueAsync(id, catalogueDto);
            if (updatedCake == null)
            {
                return NotFound("Cake not found");
            }
            return Ok(updatedCake);
        }

        /// <summary>
        /// Supprime un gâteau du catalogue
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFromCatalogue(int id)
        {
            var cake = await _catalogueService.GetFromCatalogueByIdAsync(id);
            if (cake == null)
            {
                return NotFound("Cake not found");
            }
            await _catalogueService.DeleteFromCatalogueAsync(cake.id);
            return Ok();
        }
    }
}
