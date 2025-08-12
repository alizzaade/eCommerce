using eCommerce.Entities;
using eCommerce.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class CartController(ICartService cartService) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<ShoppingCart>> GetCartById(string id)
        {
            var cart = await cartService.GetCartAsync(id);
            return Ok(cart ?? new ShoppingCart { ID = id });
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> UpdateCart(ShoppingCart cart)
        {
            var updatedCart = await cartService.SetCartAsync(cart);
            if (updatedCart == null) return BadRequest("A problem occurred with cart!");
            return updatedCart;
        }

        [HttpDelete]
        public async Task<ActionResult<ShoppingCart>> DeleteCartById(string id)
        {
            var result = await cartService.DeleteCartAsync(id);
            if (!result) return BadRequest("Problem deleting cart!");
            return Ok();
        }
    }
}
