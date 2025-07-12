using eCommerce.Entities;

namespace eCommerce.Specifications
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification(string? brand, string? type, string? sort) : base(x =>
            (string.IsNullOrWhiteSpace(brand) || x.Brand == brand) && (string.IsNullOrWhiteSpace(type) || x.Type == type)
        )
        {
            switch (sort)
            {
                case "asc":
                    AddOrderBy(x => x.Price);
                    break;
                case "desc":
                    AddOrderByDescending(x => x.Price);
                    break;
                default:
                    AddOrderBy(x => x.Name);
                    break;
            }
        }
    }
}
