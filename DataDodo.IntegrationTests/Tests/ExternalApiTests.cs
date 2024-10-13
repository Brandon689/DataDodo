using DataDodo.Domain;

namespace DataDodo.IntegrationTests.Tests
{
    public class ExternalApiTests : IClassFixture<HttpClientFixture>
    {
        private readonly IHttpClientWrapper _httpClient;

        public ExternalApiTests(HttpClientFixture fixture)
        {
            _httpClient = fixture.HttpClientWrapper;
        }

        [Fact]
        public async Task FetchExternalResource_ReturnsSuccessStatusCode()
        {
            // Arrange
            var url = "https://jsonplaceholder.typicode.com/todos/1";

            // Act
            var response = await _httpClient.GetAsync(url);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task FetchExternalResource_ReturnsExpectedData()
        {
            // Arrange
            var url = "https://jsonplaceholder.typicode.com/todos/4";

            // Act
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains("et porro tempora", content);
        }
    }
}
