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
            // Registers IGoDaddyClient/GoDaddyClient with a dummy PAT so the DI wiring is exercised
            // on both the net462 and net8.0 test targets. Replace with a real PAT (e.g. from the
            // GODADDY_PAT environment variable) to run live integration tests.
            services.AddGoDaddy("dummy-pat-for-tests");
        }
    }
#endif
}
