using DataDodo.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace DataDodo.IntegrationTests
{
    public class IntegrationTestFixture : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Here you can replace services with test doubles if needed
                // For example:
                // services.AddScoped<IDataRepository, TestDataRepository>();
            });
        }

        public IHttpClientWrapper CreateHttpClientWrapper()
        {
            var client = CreateClient();
            return new HttpClientWrapper(client);
        }
    }
}
