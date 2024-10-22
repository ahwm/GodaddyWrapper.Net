using System;
using Xunit;

namespace GodaddyWrapper.Tests
{
    public class DomainTests
    {
        private readonly string AccessKey;
        private readonly string ApiSecret;

        public DomainTests()
        {
            AccessKey = Environment.GetEnvironmentVariable("GODADDY_ACCESS_KEY").Trim();
            ApiSecret = Environment.GetEnvironmentVariable("GODADDY_API_SECRET").Trim();
        }

        [Fact]
        public async void DomainCheckTest()
        {
            //var client = new GoDaddyClient(new HttpClient(), new GoDaddyClientOptions { AccessKey = AccessKey, SecretKey = ApiSecret, IsTesting = true });
            //var response = await client.CheckDomainAvailable(new DomainAvailable
            //{
            //    Domain = "google.com"
            //});

            //response.Available.ShouldBe(false);
        }

        [Fact]
        public async void DomainListTest()
        {
            //var client = new GoDaddyClient(new HttpClient(), new GoDaddyClientOptions { AccessKey = AccessKey, SecretKey = ApiSecret, IsTesting = true });
            //var response = await client.RetrieveDomainList(new DomainRetrieve { Limit = 100 });

            //response.Count.ShouldBe(0);
        }
    }
}
