using LibraryDAO.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Xunit;

namespace LibraryTest
{
    // Based on https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-2.2

    public class LibraryControllerTest : IClassFixture<WebApplicationFactory<LibraryWebAPI.Startup>>
    {
        private readonly WebApplicationFactory<LibraryWebAPI.Startup> _factory;
        public LibraryControllerTest(WebApplicationFactory<LibraryWebAPI.Startup> factory)
        {
            // HttpClient is intended to be instantiated once and reused throughout the life of an application.
            // Instantiating an HttpClient class for every request will exhaust the number of sockets available under heavy loads.
            // https://docs.microsoft.com/es-es/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
            _factory = factory;
        }


        [Fact]
        public async void GetByGenre_Cifi_Test()
        {
            // Arrange         
            var _client = this._factory.CreateClient();

            // Act
            var response = await _client.GetAsync("/Library/GetByGenre/Ci-fi");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());

            Stream contentStream = await response.Content.ReadAsStreamAsync();
            var streamReader = new StreamReader(contentStream);
            var jsonReader = new JsonTextReader(streamReader);
            JsonSerializer serializer = new JsonSerializer();

            var result = serializer.Deserialize<IEnumerable<BookDTO>>(jsonReader);
            Assert.True(result.Count() > 0);
            Assert.True(result.All(b => b.Genre == "Ci-fi"));
        }


    }
}
