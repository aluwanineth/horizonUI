using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class EventSubscriber
    {
        RadzenDataGrid<EventSubscriberVM> eventsubscriberGrid = null;
        EventSubscriberVM eventsubscriberToInsert = null;
        public IEnumerable<EventSubscriberVM> eventsubscribers = new List<EventSubscriberVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            eventsubscribers = await _eventsubscriberService.GetEventSubscribers();

        }


        public async Task Export(string type)
        {
            await _exportService.ExportData<EventSubscriberVM>(eventsubscriberGrid, type, "EventSubscriber", "EventSubscribers");
        }

        async Task EditRow(EventSubscriberVM eventsubscriber)
        {
            await eventsubscriberGrid.EditRow(eventsubscriber);
        }

        async void OnUpdateRow(EventSubscriberVM eventsubscriber)
        {
            if (eventsubscriber == eventsubscriberToInsert)
            {
                eventsubscriberToInsert = null;
            }


            await _eventsubscriberService.UpdateEventSubscriber(eventsubscriber);

        }

        async Task SaveRow(EventSubscriberVM eventsubscriber)
        {

            if (eventsubscriber == eventsubscriberToInsert)
            {
                eventsubscriberToInsert = null;
            }

            await eventsubscriberGrid.UpdateRow(eventsubscriber);
        }

        void CancelEdit(EventSubscriberVM eventsubscriber)
        {
            if (eventsubscriber == eventsubscriberToInsert)
            {
                eventsubscriberToInsert = null;
            }

            eventsubscriberGrid.CancelEditRow(eventsubscriber);

        }

        async Task DeleteRow(EventSubscriberVM eventsubscriber)
        {
            if (eventsubscriber == eventsubscriberToInsert)
            {
                eventsubscriberToInsert = null;
            }

            if (eventsubscribers.Contains(eventsubscriber))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                eventsubscribers.ToList().Remove(eventsubscriber);

                // For production
                //dbContext.SaveChanges();

                await eventsubscriberGrid.Reload();
            }
            else
            {
                eventsubscriberGrid.CancelEditRow(eventsubscriber);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            eventsubscriberToInsert = new EventSubscriberVM();
            await eventsubscriberGrid.InsertRow(eventsubscriberToInsert);

        }

        async Task OnCreateRow(EventSubscriberVM eventsubscriber)
        {
            // dbContext.Add(order);
            await _eventsubscriberService.SaveEventSubscriber(eventsubscriber);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
