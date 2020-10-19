using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Shopping.HttpAggregator.Services;

namespace Web.Shopping.HttpAggregator.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService catalog;

        public CatalogController(ICatalogService catalog)
        {
            this.catalog = catalog;
        }

        /// <summary>
        /// Lists avaiable catalog items.
        /// </summary>
        /// <param name="startIndex">The zero-based index for paginating the results.</param>
        /// <param name="pageSize">The maximum number of catalog items to return.</param>
        /// <response code="200">Returns the list of catalog items.</response>
        /// <response code="400">If startIndex &lt; 0 or pageSize &lt;= 0.</response>
        [Route("")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(IEnumerable<Models.CatalogItem>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Models.CatalogItem>>> ListCatalogItemsAsync(int startIndex = 0, int pageSize = 10)
        {
            if (startIndex < 0) return BadRequest($"Parameter {nameof(startIndex)} must be >= 0.");
            if (pageSize < 0) return BadRequest($"Parameter {nameof(pageSize)} must be >= 0.");
            return Ok(await catalog.ListCatalogItems(startIndex, pageSize));
        }
    }
}
