using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class ReinsuranceDurationService : IGeneric<ReinsuranceDurationVM>
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public ReinsuranceDurationService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<ReinsuranceDurationVM>> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<ReinsuranceDurationVM>>(BaseURIConfig + "ReinsDuration/ReinsuranceDuration");
            return result;
        }


        public async Task<string> Update(ReinsuranceDurationVM model)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "ReinsDuration/UpdateReinsuranceDuration", model);
            return result.ToString();
        }
    }
}
