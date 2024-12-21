using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using pw_cakes.Server.Dto;
using pw_cakes.Server.Entities;
using pw_cakes.Server.Services;

namespace pw_cakes.Server.Controllers
{
    [ApiController]
    [Route("[catalogue]")]
    [Tags("Catalogue")]
    public class CatalogueController : ControllerBase
    {
        private readonly CatalogueService _catalogueService;

        public CatalogueController(CatalogueService catalogueService)
        {
            _catalogueService = catalogueService;
        }
        
        /// <summary>
        ///  Retourne la liste des gâteaux du catalogue
        /// </summary>
        /// <returns>La liste des gâteaux du catalogue - 200 OK</returns>
        [HttpGet]
        public async Task<IActionResult> GetFromCatalogue()
        {
            var catalogue = await _catalogueService.GetFromCatalogueAsync();
            if (!catalogue.Any())
            {
                return NotFound("Nothing to see");
            }
            return Ok(catalogue);
        }

        [HttpGet]
        public async Task<IActionResult> AddToCatalogue([FromBody] CatalogueDto catalogueDto)
        {
            if (catalogueDto == null)
            {
                return BadRequest("Null catalogue");
            }
            
            var nouveauGateau = await _catalogueService.AddToCatalogueAsync(catalogueDto);
            if (nouveauGateau == null)
            {
                return NotFound("Nothing to see");
            }
            return CreatedAtAction(nameof(GetFromCatalogue), new { id = nouveauGateau.id }, nouveauGateau);
        }
    }
}
