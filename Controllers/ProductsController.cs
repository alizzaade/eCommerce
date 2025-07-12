using eCommerce.Data;
using eCommerce.Entities;
using eCommerce.Interfaces;
using eCommerce.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IGenericRepository<Product> repo) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts(string? brand, string? type, string? sort)
        {
            var spec = new ProductSpecification(brand, type, sort);
            var products = await repo.ListAsync(spec);
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await repo.GetByIdAsync(id);
            if (product == null) return NotFound();
            return product;
        }

        //Implement later
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetBrands()
        {
            return Ok();
        }
        //Implement later
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            repo.Add(product);
            if (await repo.SaveAllAsync()) return CreatedAtAction("GetProduct", new { id = product.Id }, product);
            return BadRequest("Something went wrong!");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct(Product product, int id)
        {
            if (product.Id != id || !ProductExists(id)) return BadRequest("Cannot update this product!");
            repo.Update(product);

            if (await repo.SaveAllAsync())
            {
                return NoContent();
            }
            return BadRequest("Problem updating the product!");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await repo.GetByIdAsync(id);
            if (product == null) return NotFound();
            repo.Delete(product);
            if (await repo.SaveAllAsync())
            {
                return NoContent();
            }
            return BadRequest("Problem deleting the product!");
        }

        private bool ProductExists(int id)
        {
            return repo.Exists(id);
        }
    }
}
