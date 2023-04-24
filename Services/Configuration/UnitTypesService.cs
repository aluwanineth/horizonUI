using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class UnitTypeService : IGeneric<UnitTypesVM>
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public UnitTypeService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<UnitTypesVM>> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<UnitTypesVM>>(BaseURIConfig + "UnitTypes/UnitTypes");
            return result;
        }


        public async Task<string> Update(UnitTypesVM model)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "UnitTypes/UpdateUnitTypes", model);
            return result.ToString();
        }
    }
}
