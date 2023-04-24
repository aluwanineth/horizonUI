using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IEventHeaderService
    {
        public Task<IEnumerable<EventHeaderVM>> GetEventHeaders();
        public Task<string> UpdateEventHeader(EventHeaderVM eventheader);
        public Task<string> SaveEventHeader(EventHeaderVM eventheader);
    }
}
