namespace eCommerce.Entities
{
    public class ShoppingCart
    {
        public required string ID { get; set; }
        public List<CartItem> Items { get; set; }
    }
}
