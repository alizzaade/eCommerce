
using eCommerce.Data;
using eCommerce.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eCommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddDbContext<StoreContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
           
            var app = builder.Build();

            app.MapControllers();
            app.Run();
        }
    }
}
