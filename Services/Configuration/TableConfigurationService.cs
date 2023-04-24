using HorizonPollyC.Models.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
//using System.Web.Mvc;

namespace HorizonPollyC.Services.Configuration
{
    public class TableConfigurationService /*: ITableConfigurationService*/
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public TableConfigurationService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }

        public Task<IEnumerable<TableConfigurationVM>> GetTableConfiguration()
        {
            return null;
          //  ResponseCacheAttribute.Redirect("http://localhost:5153/configuration/account");

        }
    }
}
