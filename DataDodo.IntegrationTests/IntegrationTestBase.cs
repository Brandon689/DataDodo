using DataDodo.Domain;

namespace DataDodo.IntegrationTests
{
    public class IntegrationTestBase : IClassFixture<IntegrationTestFixture>, IDisposable
    {
        protected readonly IntegrationTestFixture Fixture;
        protected readonly IHttpClientWrapper HttpClientWrapper;

        public IntegrationTestBase(IntegrationTestFixture fixture)
        {
            Fixture = fixture;
            HttpClientWrapper = Fixture.CreateHttpClientWrapper();
        }

        public void Dispose()
        {
            // Perform any cleanup here
        }
    }
}
