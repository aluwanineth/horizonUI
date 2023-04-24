using HorizonPollyC.Models;
using HorizonPollyC.Models.Chat;
using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Chat
{
    public class ChatService : IChatService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;

        public ChatService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }

        public async Task<IEnumerable<ColleaguesVM>> GetColleagueDetails()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<ColleaguesVM>>(BaseURIConfig + "chat/departmentmembersbyemail");
            return result;
        }

        public async Task<IEnumerable<ChatGroupToCollegueVM>> GetGroupDetails()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<ChatGroupToCollegueVM>>(BaseURIConfig + "chat/groupsbyemail");
            return result;
        }
    }
}
