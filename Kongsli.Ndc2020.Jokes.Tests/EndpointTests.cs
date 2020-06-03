using System.Threading.Tasks;
using Kongsli.Ndc2020.Jokes.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Kongsli.Ndc2020.Jokes.Tests
{
    public class EndpointTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public EndpointTests(WebApplicationFactory<Startup> factory) => _factory = factory;

        [Theory]
        [InlineData("/")]
        [InlineData("/jokes")]
        [InlineData("/chuckjokes")]
        [InlineData("/sciencejokes")]
        public async Task Test1(string path)
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
        }
    }
}
