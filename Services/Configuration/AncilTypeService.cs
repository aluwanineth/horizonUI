using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class AncilTypeService : IAncilTypeService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public AncilTypeService(HttpClient client, IConfiguration Configuration)
        {

            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }

        public async Task<IEnumerable<AncilTypeVM>> GetAncilTypes()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<AncilTypeVM>>(BaseURIConfig + "ancilltype/ancilltypes");
            return result;
        }


        public async Task<string> SaveAnciltype(AncilTypeVM anciltypes)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "ancilltype/saveancilltype", anciltypes);
            return result.ToString();
        }

        public async Task<string> UpdateAnciltype(AncilTypeVM anciltypes)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "ancilltype/updateancilltype", anciltypes);
            return result.ToString();
        }

    }
}
