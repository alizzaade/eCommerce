using eCommerce.Entities;
using System.Text.Json;

namespace eCommerce.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.Products.Any())
            {
                var productsData = await File.ReadAllTextAsync("C:\\Users\\umuta\\source\\repos\\eCommerce\\Data\\SeedData\\products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products == null) return;
                context.Products.AddRange(products);
                await context.SaveChangesAsync();
            }
        }
    }
}
