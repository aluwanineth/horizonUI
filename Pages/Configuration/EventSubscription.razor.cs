using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class EventSubscription
    {
        RadzenDataGrid<EventSubscriptionVM> eventsubscriptionGrid = null;
        EventSubscriptionVM eventsubscriptionToInsert = null;
        public IEnumerable<EventSubscriptionVM> eventsubscriptions = new List<EventSubscriptionVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            eventsubscriptions = await _eventsubscriptionService.GetEventSubscriptions();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<EventSubscriptionVM>(eventsubscriptionGrid, type, "EventSubscription", "EventSubscriptions");
        }


        async Task EditRow(EventSubscriptionVM eventsubscription)
        {
            await eventsubscriptionGrid.EditRow(eventsubscription);
        }

        async void OnUpdateRow(EventSubscriptionVM eventsubscription)
        {
            if (eventsubscription == eventsubscriptionToInsert)
            {
                eventsubscriptionToInsert = null;
            }


            await _eventsubscriptionService.UpdateEventSubscription(eventsubscription);

        }

        async Task SaveRow(EventSubscriptionVM eventsubscription)
        {

            if (eventsubscription == eventsubscriptionToInsert)
            {
                eventsubscriptionToInsert = null;
            }

            await eventsubscriptionGrid.UpdateRow(eventsubscription);
        }

        void CancelEdit(EventSubscriptionVM eventsubscription)
        {
            if (eventsubscription == eventsubscriptionToInsert)
            {
                eventsubscriptionToInsert = null;
            }

            eventsubscriptionGrid.CancelEditRow(eventsubscription);

        }

        async Task DeleteRow(EventSubscriptionVM eventsubscription)
        {
            if (eventsubscription == eventsubscriptionToInsert)
            {
                eventsubscriptionToInsert = null;
            }

            if (eventsubscriptions.Contains(eventsubscription))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                eventsubscriptions.ToList().Remove(eventsubscription);

                // For production
                //dbContext.SaveChanges();

                await eventsubscriptionGrid.Reload();
            }
            else
            {
                eventsubscriptionGrid.CancelEditRow(eventsubscription);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            eventsubscriptionToInsert = new EventSubscriptionVM();
            await eventsubscriptionGrid.InsertRow(eventsubscriptionToInsert);

        }

        async Task OnCreateRow(EventSubscriptionVM eventsubscription)
        {
            // dbContext.Add(order);
            await _eventsubscriptionService.SaveEventSubscription(eventsubscription);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
