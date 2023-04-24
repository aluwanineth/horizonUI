using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class CountryPhoneService : IGeneric<CountryPhone>
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        String BaseURIConfig;

        public CountryPhoneService(HttpClient client, IConfiguration configuration)
        {
            httpClient = client;
            _configuration = configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }

        public async Task<IEnumerable<CountryPhone>> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<CountryPhone>>(BaseURIConfig + "CountryPhone/CountryPhone");
            return result;
        }

        public async Task<String> Update(CountryPhone model)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "CountryPhone/UpdateCountryPhones", model);
            return result.ToString();
        }

    }
}
