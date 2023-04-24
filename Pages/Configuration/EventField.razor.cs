using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class EventField
    {
        RadzenDataGrid<EventFieldVM> eventfieldGrid = null;
        EventFieldVM eventfieldToInsert = null;
        public IEnumerable<EventFieldVM> eventfields = new List<EventFieldVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            eventfields = await _eventFieldService.GetEventFields();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<EventFieldVM>(eventfieldGrid, type, "EventField", "EventFields");
        }


        async Task EditRow(EventFieldVM eventfield)
        {
            await eventfieldGrid.EditRow(eventfield);
        }

        async void OnUpdateRow(EventFieldVM eventfield)
        {
            if (eventfield == eventfieldToInsert)
            {
                eventfieldToInsert = null;
            }


            await _eventFieldService.UpdateEventField(eventfield);

        }

        async Task SaveRow(EventFieldVM eventfield)
        {

            if (eventfield == eventfieldToInsert)
            {
                eventfieldToInsert = null;
            }

            await eventfieldGrid.UpdateRow(eventfield);
        }

        void CancelEdit(EventFieldVM eventfield)
        {
            if (eventfield == eventfieldToInsert)
            {
                eventfieldToInsert = null;
            }

            eventfieldGrid.CancelEditRow(eventfield);

        }

        async Task DeleteRow(EventFieldVM eventfield)
        {
            if (eventfield == eventfieldToInsert)
            {
                eventfieldToInsert = null;
            }

            if (eventfields.Contains(eventfield))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                eventfields.ToList().Remove(eventfield);

                // For production
                //dbContext.SaveChanges();

                await eventfieldGrid.Reload();
            }
            else
            {
                eventfieldGrid.CancelEditRow(eventfield);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            eventfieldToInsert = new EventFieldVM();
            await eventfieldGrid.InsertRow(eventfieldToInsert);

        }

        async Task OnCreateRow(EventFieldVM eventfield)
        {
            // dbContext.Add(order);
            await _eventFieldService.SaveEventField(eventfield);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
