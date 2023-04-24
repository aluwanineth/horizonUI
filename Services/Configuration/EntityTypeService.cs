using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class EntityTypeService : IEntityTypeService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public EntityTypeService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<EntityTypeVM>> GetEntityTypes()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<EntityTypeVM>>(BaseURIConfig + "entitytype/entitytypes");
            return result;
        }

        public async Task<string> SaveEntityType(EntityTypeVM entitytype)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "entitytype/saveentitytype", entitytype);
            return result.ToString();
        }

        public async Task<string> UpdateEntityType(EntityTypeVM entitytype)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "entitytype/updateentitytype", entitytype);
            return result.ToString();
        }
    }
}
