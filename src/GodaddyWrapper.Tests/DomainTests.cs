using GodaddyWrapper;
using GodaddyWrapper.Base;
using GodaddyWrapper.Requests;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GodaddyWrapper.Tests
{
    public class DomainTests
    {
        [Fact]
        public async void DomainCheckTest()
        {
            var client = new Client("3mM44UbhEZZWcL_HqbVN2G2MDcpugKnmaypKz", "TNAYNy9EPJLKq2Zf3KFHQp", "https://api.ote-godaddy.com/api/v1/");
            var response = await client.CheckDomainAvailable(new DomainAvailable
            {
                Domain = "google.com"
            });

            response.Available.ShouldBe(false);
        }

        [Fact]
        public async void DomainListTest()
        {
            var client = new Client("3mM44UbhEZZWcL_HqbVN2G2MDcpugKnmaypKz", "TNAYNy9EPJLKq2Zf3KFHQp", "https://api.ote-godaddy.com/api/v1/");
            var response = await client.RetrieveDomainList(new DomainRetrieve { Limit = 100 });

            response.Count.ShouldBe(0);
        }
    }
}
