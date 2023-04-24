using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IChannelService
    {
        public Task<IEnumerable<ChannelVM>> GetChannels();
        public Task<string> UpdateChannel(ChannelVM channel);
        public Task<string> SaveChannel(ChannelVM channel);
    }
}
