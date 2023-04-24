using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class ReinsMemberTypeService : IGeneric<ReinsuranceMemberTypeVM>
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public ReinsMemberTypeService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<ReinsuranceMemberTypeVM>> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<ReinsuranceMemberTypeVM>>(BaseURIConfig + "ReinsMemberType/ReinsuranceMemberType");
            return result;
        }


        public async Task<string> Update(ReinsuranceMemberTypeVM model)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "ReinsMemberType/UpdateReinsuranceMemberType", model);
            return result.ToString();
        }
    }
}
