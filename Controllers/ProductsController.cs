using eCommerce.Data;
using eCommerce.Entities;
using eCommerce.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IProductRepository repo) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
        {
            return Ok(await repo.GetProductsAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await repo.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            repo.AddProduct(product);
            if (await repo.SaveChangesAsync()) return CreatedAtAction("GetProduct", new { id = product.Id }, product);
            return BadRequest("Something went wrong!");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct(Product product, int id)
        {
            if (product.Id != id || !ProductExists(id)) return BadRequest("Cannot update this product!");
            repo.UpdateProduct(product);

            if (await repo.SaveChangesAsync())
            {
                return NoContent();
            }
            return BadRequest("Problem updating the product!");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await repo.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            repo.DeleteProduct(product);
            if (await repo.SaveChangesAsync())
            {
                return NoContent();
            }
            return BadRequest("Problem deleting the product!");
        }

        private bool ProductExists(int id)
        {
            return repo.ProductExists(id);
        }
    }
}
