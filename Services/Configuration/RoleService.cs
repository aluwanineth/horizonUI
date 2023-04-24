using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class RoleService : IGeneric<RoleVM>
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public RoleService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<RoleVM>> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<RoleVM>>(BaseURIConfig + "Role/Role");
            return result;
        }


        public async Task<string> Update(RoleVM model)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "Role/UpdateRole", model);
            return result.ToString();
        }
    }
}
