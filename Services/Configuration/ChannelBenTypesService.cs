using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public partial class ChannelBenTypesService : IChannelBenTypesService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public ChannelBenTypesService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<ChannelBenTypesVM>> GetChannelBenTypes()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<ChannelBenTypesVM>>(BaseURIConfig + "ChannelBenTypes/ChannelBenTypes");
            return result;
        }

        public async Task<string> SaveChannelBenTypes(ChannelBenTypesVM channelBenTypes)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "channelBenTypes/savechannelBenTypes", channelBenTypes);
            return result.ToString();
        }

        public async Task<string> UpdateChannelBenTypes(ChannelBenTypesVM channelBenTypes)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "channelBenTypes/updatechannelBenTypes", channelBenTypes);
            return result.ToString();
        }
    }
}
