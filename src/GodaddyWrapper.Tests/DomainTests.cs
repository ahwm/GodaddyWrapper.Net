using GodaddyWrapper.Requests;
using Shouldly;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace GodaddyWrapper.Tests
{
    public class DomainTests
    {

        private readonly GoDaddyClient client;

#if NETCORE
        public DomainTests(GoDaddyClient goDaddyClient)
        {
            client = goDaddyClient;
        }
#else
        public DomainTests()
        {
            var accessKey = Environment.GetEnvironmentVariable("GODADDY_ACCESS_KEY").Trim();
            var apiSecret = Environment.GetEnvironmentVariable("GODADDY_API_SECRET").Trim();
            client = new GoDaddyClient(new GoDaddyClientOptions { AccessKey = accessKey, SecretKey = apiSecret, IsTesting = true });
        }
#endif

        [Fact]
        public async Task DomainCheckTest()
        {
            try
            {
                var response = await client.CheckDomainAvailable(new DomainAvailable
                {
                    Domain = "google.com"
                });

                response.Available.ShouldBe(false);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [Fact]
        public async Task DomainListTest()
        {
            try
            {
                var response = await client.RetrieveDomainList(new DomainRetrieve { Limit = 100 });

                response.Count.ShouldBe(0);
            }
            catch (Exception) 
            {
                Assert.Fail();
            }
        }
    }
}
