using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IEventSubscriberService
    {
        public Task<IEnumerable<EventSubscriberVM>> GetEventSubscribers();
        public Task<string> UpdateEventSubscriber(EventSubscriberVM eventsubscriber);
        public Task<string> SaveEventSubscriber(EventSubscriberVM eventsubscriber);
    }
}
