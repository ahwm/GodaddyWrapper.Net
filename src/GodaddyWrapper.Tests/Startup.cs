using GodaddyWrapper;
#if NETCORE
using Microsoft.Extensions.DependencyInjection;
using System;
#endif

namespace GodaddyWrapper.Tests
{
#if NETCORE
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            string AccessKey = Environment.GetEnvironmentVariable("GODADDY_ACCESS_KEY").Trim();
            string ApiSecret = Environment.GetEnvironmentVariable("GODADDY_API_SECRET").Trim();
            services.AddGoDaddy(AccessKey, ApiSecret, true);
            //services.AddTransient<IDomainService, OpenSRSDomainService>();
        }
    }
#endif
}
