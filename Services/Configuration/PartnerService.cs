using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class PartnerService : IPartnerService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public PartnerService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<PartnerVM>> GetPartners()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<PartnerVM>>(BaseURIConfig + "partner/partners");
            return result;
        }

        public async Task<string> SavePartner(PartnerVM partner)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "partner/savepartner", partner);
            return result.ToString();
        }

        public async Task<string> UpdatePartner(PartnerVM partner)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "partner/updatepartner", partner);
            return result.ToString();
        }
    }
}
