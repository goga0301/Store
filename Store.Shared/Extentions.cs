using Microsoft.Extensions.DependencyInjection;
using Store.Shared.Helpers;

namespace Store.Shared
{
    public class Extentions
    {
        public static void AddHelperServices(IServiceCollection services)
        {
            services.AddSingleton<IConnectionString, ConnectionString>();
        }

       


    }
}
