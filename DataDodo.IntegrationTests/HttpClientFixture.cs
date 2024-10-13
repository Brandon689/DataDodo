using DataDodo.Domain;

namespace DataDodo.IntegrationTests
{
    public class HttpClientFixture : IDisposable
    {
        public IHttpClientWrapper HttpClientWrapper { get; }

        public HttpClientFixture()
        {
            var httpClient = new HttpClient();
            HttpClientWrapper = new HttpClientWrapper(httpClient);
        }

        public void Dispose()
        {
            // Clean up if necessary
        }
    }
}
