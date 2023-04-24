using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class ProcessControlLogsService : IProcessControlLogService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public ProcessControlLogsService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<ProcessControlLogsVM>> GetProcessControlLogs()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<ProcessControlLogsVM>>(BaseURIConfig + "processcontrollogs/processcontrollogs");
            return result;
        }

        public async Task<string> SaveProcessControlLogs(ProcessControlLogsVM processControlLogs)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "processcontrollogs/saveprocesscontrollogs", processControlLogs);
            return result.ToString();
        }

        public async Task<string> UpdateProcessControlLogs(ProcessControlLogsVM processControlLogs)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "processcontrollogs/updateprocesscontrollogs", processControlLogs);
            return result.ToString();
        }
    }
}
