using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class SchemeBackupService : IGeneric<SchemeBackupVM>
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public SchemeBackupService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<SchemeBackupVM>> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<SchemeBackupVM>>(BaseURIConfig + "SchemeBackup/SchemeBackup");
            return result;
        }


        public async Task<string> Update(SchemeBackupVM model)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "SchemeBackup/UpdateSchemeBackup", model);
            return result.ToString();
        }
    }
}
