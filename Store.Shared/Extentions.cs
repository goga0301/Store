using Microsoft.Extensions.DependencyInjection;
using Store.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
