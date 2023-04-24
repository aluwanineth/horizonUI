using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class GenderService : IGenderService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public GenderService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<GenderVM>> GetGenders()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<GenderVM>>(BaseURIConfig + "gender/genders");
            return result;
        }

        public async Task<string> SaveGender(GenderVM gender)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "gender/savegender", gender);
            return result.ToString();
        }

        public async Task<string> UpdateGender(GenderVM gender)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "gender/updategender", gender);
            return result.ToString();
        }
    }
}
