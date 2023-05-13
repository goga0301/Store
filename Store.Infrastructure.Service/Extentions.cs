using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Service.Domain;
using Store.Infrastructure.Service.Domain;

namespace Store.Infrastructure.Service
{
    public static class Extentions
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IMainCategoryService, MainCategoryService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IOrderService, OrderService>();

        }
    }
}
