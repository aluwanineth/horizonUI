using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class ValidateStructureService: IValidateStructureService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public ValidateStructureService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<ValidateStructureVM>> GetValidateStructure()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<ValidateStructureVM>>(BaseURIConfig + "validatestructure/validatestructures");
            return result;
        }

        public async Task<string> SaveValidateStructure(ValidateStructureVM validateStructure)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "validateStructure/saveValidateStructure", validateStructure);
            return result.ToString();
        }

        public async Task<string> UpdateValidateStructure(ValidateStructureVM validateStructure)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "validateStructure/updateValidateStructure", validateStructure);
            return result.ToString();
        }
    }
}
