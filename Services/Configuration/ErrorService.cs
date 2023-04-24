using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class ErrorService : IErrorService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public ErrorService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<ErrorVM>> GetErrors()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<ErrorVM>>(BaseURIConfig + "error/errors");
            return result;
        }

        public async Task<string> SaveError(ErrorVM error)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "error/saveeerror", error);
            return result.ToString();
        }

        public async Task<string> UpdateError(ErrorVM error)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "error/updateerror", error);
            return result.ToString();
        }
    }
}
