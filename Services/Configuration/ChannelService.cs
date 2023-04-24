using HorizonPollyC.Models.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class ChannelService : IChannelService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public ChannelService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<ChannelVM>> GetChannels()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<ChannelVM>>(BaseURIConfig + "Channel/Channels");
            return result;
        }

        public async Task<string> SaveChannel(ChannelVM channel)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "channel/savechannel", channel);
            return result.ToString();
        }

        public async Task<string> UpdateChannel(ChannelVM channel)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "channel/updatechannel", channel);
            return result.ToString();
        }
    }
}
