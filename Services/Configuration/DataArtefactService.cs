using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class DataArtefactService : IDataArtefactService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public DataArtefactService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<DataArtefactVM>> GetDataArtefacts()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<DataArtefactVM>>(BaseURIConfig + "dataartefact/dataartefacts");
            return result;
        }

        public async Task<string> SaveDataArtefact(DataArtefactVM dataartefact)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "dataartefact/savedataartefact", dataartefact);
            return result.ToString();
        }

        public async Task<string> UpdateDataArtefact(DataArtefactVM dataartefact)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "dataartefact/updatedataartefact", dataartefact);
            return result.ToString();
        }
    }
}
