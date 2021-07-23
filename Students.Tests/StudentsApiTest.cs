using System.Net;
using System.Net.Http;
using Xunit;
using Students.WebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Threading.Tasks;

namespace Students.Tests
{
    public class StudentsApiTest
    {
        private readonly HttpClient _client;

        public StudentsApiTest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup(typeof(Startup)));
            _client = server.CreateClient();
        }

        [Theory]
        [InlineData("GET")]
        public async Task StudentsGetAllTestAsync(string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), "/students");

            var responce = await _client.SendAsync(request);

            responce.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, responce.StatusCode);
        }

        [Theory]
        [InlineData("GET", 1)]
        public async Task StudentGetTestAsync(string method, int? id = null)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), $"/students/{id}");

            var responce = await _client.SendAsync(request);

            responce.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, responce.StatusCode);
        }
    }
}
