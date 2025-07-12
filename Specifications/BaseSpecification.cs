using eCommerce.Interfaces;
using System.Linq.Expressions;

namespace eCommerce.Specifications
{
    public class BaseSpecification<T>(Expression<Func<T, bool>>? criteria) : ISpecification<T>
    {
        public BaseSpecification() : this(null) { }
        public Expression<Func<T, bool>>? Criteria { get; } = criteria;
    }
}
