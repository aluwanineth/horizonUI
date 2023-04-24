using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class AttributeService : IAttributeService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public AttributeService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<AttributeVM>> GetAttributes()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<AttributeVM>>(BaseURIConfig + "attribute/attributes");
            return result;
        }

        public async Task<string> SaveAttribute(AttributeVM attribute)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "attribute/saveattribute", attribute);
            return result.ToString();
        }

        public async Task<string> UpdateAttribute(AttributeVM attribute)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "attribute/updateattribute", attribute);
            return result.ToString();
        }
    }
}
