using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class TelecomTypesService : IGeneric<TelecomType>
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        String BaseURIConfig;

        public TelecomTypesService(HttpClient client, IConfiguration configuration)
        {
            httpClient = client;
            _configuration = configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }

        public async Task<IEnumerable<TelecomType>> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<TelecomType>>(BaseURIConfig + "TelecomTypes/TelecomTypes");
            return result;
        }

        public async Task<String> Update(TelecomType model)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "TelecomTypes/UpdateTelecomTypes", model);
            return result.ToString();
        }
    }
}
