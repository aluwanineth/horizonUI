using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IChannelBenTypesService
    {
        public Task<IEnumerable<ChannelBenTypesVM>> GetChannelBenTypes();
        public Task<string> UpdateChannelBenTypes(ChannelBenTypesVM channelBenTypes);
        public Task<string> SaveChannelBenTypes(ChannelBenTypesVM channelBenTypes);
    }
}
