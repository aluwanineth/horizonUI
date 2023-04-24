using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class TableService : ITableService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public TableService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<TableVM>> GetTable()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<TableVM>>(BaseURIConfig + "table/table");
            return result;
        }

        public async Task<string> SaveTable(TableVM table)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "table/saveTable", table);
            return result.ToString();
        }

        public async Task<string> UpdateTable(TableVM table)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "table/updateTable", table);
            return result.ToString();
        }
    }
}
