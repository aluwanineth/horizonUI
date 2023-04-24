using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class ReasonService : IGeneric<ReasonVM>
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public ReasonService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<ReasonVM>> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<ReasonVM>>(BaseURIConfig + "Reason/Reason");
            return result;
        }


        public async Task<string> Update(ReasonVM model)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "Reason/UpdateReason", model);
            return result.ToString();
        }
    }
}
