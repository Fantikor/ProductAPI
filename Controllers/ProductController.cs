using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected readonly ProductContext context;
        protected readonly ILogger logger;

        public ProductController(ILogger<ProductController> logger, ProductContext context)
        {
            this.logger = logger;
            this.context = context;

            context.Database.OpenConnection();
            context.Database.EnsureCreated();
        }

        // GET
        // api/product/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductItem>>> GetProductItemsAsync()
        {
            logger?.LogDebug("'{0}' has been invoked", nameof(GetProductItemsAsync));

            return await context.ProductItems.ToListAsync();
        }

        // GET
        // api/product/guid
        [Route("{id:guid}")]
        [HttpGet]
        public async Task<ActionResult<ProductItem>> GetProductItemAsync(Guid id)
        {
            logger?.LogDebug("'{0}' has been invoked", nameof(GetProductItemAsync));

            var productItem = await context.GetProductItemsAsync(new ProductItem(id));

            if(productItem == null)
            {
                return NotFound();
            }

            return productItem;
        }

        // POST
        // api/product/
        [HttpPost]
        public async Task<ActionResult<ProductItem>> PostProductItemAsync([FromBody] ProductCreateInputModel model)
        {
            logger?.LogDebug("'{0}' has been invoked with model {1}", nameof(PostProductItemAsync), model);

            if (!ModelState.IsValid)
                return BadRequest();

            var entity = model.ToEntity();

            context.Add(entity);

            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductItemAsync), new { id = entity.ItemID }, model);
        }

        // PUT
        // api/product/
        [HttpPut]
        public async Task<IActionResult> PutProductItemAsync([FromBody]ProductUpdateInputModel model)
        {
            logger?.LogDebug("'{0}' has been invoked with model {1}", nameof(PostProductItemAsync), model);

            var entity = await context.GetProductItemsAsync(new ProductItem(model.ItemId));

            if (entity == null)
                return NotFound();

            entity.ItemName = model.ItemName;
            entity.ItemPrice = model.ItemPrice;

            context.Update(entity);

            await context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE
        // api/product/guid
        [Route("{id:guid}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTodoItem(Guid id)
        {
            logger?.LogDebug("'{0}' has been invoked with guid {1}", nameof(PostProductItemAsync), id);

            var entity = await context.GetProductItemsAsync(new ProductItem(id));

            if (entity == null)
                return NotFound();

            context.Remove(entity);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
