using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    [Collection("TestServerFixture collection")]
    public class ControllerTests
    {
        private readonly HttpClient _client;

        public ControllerTests(TestServerFixture testServerFixture)
        {
            _client = testServerFixture.TestServer.CreateClient();
        }

        [Fact]
        public async Task InfoReturns()
        {
            var response = await _client.GetAsync("/info");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task RootReturns()
        {
            var response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();

            Assert.Equal(@"{""status"":""Up""}", await response.Content.ReadAsStringAsync());
        }
    }
}
