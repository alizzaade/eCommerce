using eCommerce.Entities;
using System.Collections.Generic;

namespace eCommerce.Interfaces
{
    public interface IProductRepository
    {
        Task<IReadOnlyCollection<Product>> GetProductsAsync();
        Task<IReadOnlyCollection<Product>> GetProductsAsync(string? brand, string? type, string? sort);
        Task<Product?> GetProductByIdAsync(int id);
        Task<IReadOnlyList<string>> GetBrandsAsync();
        Task<IReadOnlyList<string>> GetTypeAsync();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        bool ProductExists(int id);
        Task<bool> SaveChangesAsync(); 
    }
}
