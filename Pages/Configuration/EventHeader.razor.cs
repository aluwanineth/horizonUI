using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
using System.Linq;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class EventHeader
    {
        RadzenDataGrid<EventHeaderVM> eventheaderGrid = null;
        EventHeaderVM eventheaderToInsert = null;
        public IEnumerable<EventHeaderVM> eventheaders = new List<EventHeaderVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            eventheaders = await _eventheaderService.GetEventHeaders();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<EventHeaderVM>(eventheaderGrid, type, "EventHeader", "EventHeaders");
        }


        async Task EditRow(EventHeaderVM eventheader)
        {
            await eventheaderGrid.EditRow(eventheader);
        }

        async void OnUpdateRow(EventHeaderVM eventheader)
        {
            if (eventheader == eventheaderToInsert)
            {
                eventheaderToInsert = null;
            }


            await _eventheaderService.UpdateEventHeader(eventheader);

        }

        async Task SaveRow(EventHeaderVM eventheader)
        {

            if (eventheader == eventheaderToInsert)
            {
                eventheaderToInsert = null;
            }

            await eventheaderGrid.UpdateRow(eventheader);
        }

        void CancelEdit(EventHeaderVM eventheader)
        {
            if (eventheader == eventheaderToInsert)
            {
                eventheaderToInsert = null;
            }

            eventheaderGrid.CancelEditRow(eventheader);

        }

        async Task DeleteRow(EventHeaderVM eventheader)
        {
            if (eventheader == eventheaderToInsert)
            {
                eventheaderToInsert = null;
            }

            if (eventheaders.Contains(eventheader))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                eventheaders.ToList().Remove(eventheader);

                // For production
                //dbContext.SaveChanges();

                await eventheaderGrid.Reload();
            }
            else
            {
                eventheaderGrid.CancelEditRow(eventheader);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            eventheaderToInsert = new EventHeaderVM();
            await eventheaderGrid.InsertRow(eventheaderToInsert);

        }

        async Task OnCreateRow(EventHeaderVM eventheader)
        {
            // dbContext.Add(order);
            await _eventheaderService.SaveEventHeader(eventheader);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
