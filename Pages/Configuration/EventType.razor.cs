using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class EventType
    {
        RadzenDataGrid<EventTypeVM> eventtypeGrid = null;
        EventTypeVM eventtypeToInsert = null;
        public IEnumerable<EventTypeVM> eventtypes = new List<EventTypeVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            eventtypes = await _eventtypeService.GetEventTypes();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<EventTypeVM>(eventtypeGrid, type, "EventType", "EventTypes");
        }


        async Task EditRow(EventTypeVM eventtype)
        {
            await eventtypeGrid.EditRow(eventtype);
        }

        async void OnUpdateRow(EventTypeVM eventtype)
        {
            if (eventtype == eventtypeToInsert)
            {
                eventtypeToInsert = null;
            }


            await _eventtypeService.UpdateEventType(eventtype);

        }

        async Task SaveRow(EventTypeVM eventtype)
        {

            if (eventtype == eventtypeToInsert)
            {
                eventtypeToInsert = null;
            }

            await eventtypeGrid.UpdateRow(eventtype);
        }

        void CancelEdit(EventTypeVM eventtype)
        {
            if (eventtype == eventtypeToInsert)
            {
                eventtypeToInsert = null;
            }

            eventtypeGrid.CancelEditRow(eventtype);

        }

        async Task DeleteRow(EventTypeVM eventtype)
        {
            if (eventtype == eventtypeToInsert)
            {
                eventtypeToInsert = null;
            }

            if (eventtypes.Contains(eventtype))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                eventtypes.ToList().Remove(eventtype);

                // For production
                //dbContext.SaveChanges();

                await eventtypeGrid.Reload();
            }
            else
            {
                eventtypeGrid.CancelEditRow(eventtype);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            eventtypeToInsert = new EventTypeVM();
            await eventtypeGrid.InsertRow(eventtypeToInsert);

        }

        async Task OnCreateRow(EventTypeVM eventtype)
        {
            // dbContext.Add(order);
            await _eventtypeService.SaveEventType(eventtype);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
