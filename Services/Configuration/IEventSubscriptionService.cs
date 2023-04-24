using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IEventSubscriptionService
    {
        public Task<IEnumerable<EventSubscriptionVM>> GetEventSubscriptions();
        public Task<string> UpdateEventSubscription(EventSubscriptionVM eventsubscription);
        public Task<string> SaveEventSubscription(EventSubscriptionVM eventsubscription);
    }
}
