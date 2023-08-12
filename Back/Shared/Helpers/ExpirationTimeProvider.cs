using Microsoft.Extensions.Configuration;

namespace Shared.Helpers
{
    public class ExpirationTimeProvider
    {
        private readonly IConfiguration _configuration;
        
        public ExpirationTimeProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TimeSpan GetExpirationTime(string entity, string method)
        {
            var expirationTime = _configuration.GetSection($"ExpirationTimes:{entity}_{method}");
            if (expirationTime.Exists())
                return TimeSpan.FromSeconds(expirationTime.Get<int>());

            var defaultxpirationTime = _configuration.GetSection($"DefaultExpirationTimes").Get<DefaultExpirationTimes>() ?? throw new Exception("DefaultExpirationTimes settings does not exists"); 
            return TimeSpan.FromSeconds(defaultxpirationTime.GetAllAsync);
        }
    }

    public class DefaultExpirationTimes
    {
        public int GetAllAsync { get; set; }
    }
}
