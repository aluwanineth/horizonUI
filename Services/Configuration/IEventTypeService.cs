using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IEventTypeService
    {
        public Task<IEnumerable<EventTypeVM>> GetEventTypes();
        public Task<string> UpdateEventType(EventTypeVM eventtype);
        public Task<string> SaveEventType(EventTypeVM eventtype);
    }
}
