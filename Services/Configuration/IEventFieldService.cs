using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IEventFieldService
    {
        public Task<IEnumerable<EventFieldVM>> GetEventFields();
        public Task<string> UpdateEventField(EventFieldVM eventfield);
        public Task<string> SaveEventField(EventFieldVM eventfield);
    }
}
