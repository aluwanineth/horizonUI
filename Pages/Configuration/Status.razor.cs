using HorizonPollyC.Models.Configuration;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class Status
    {
        RadzenDataGrid<StatusVM> statusGrid = null;
        StatusVM statusToInsert = null;
        public IEnumerable<StatusVM> statuses = new List<StatusVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            statuses = await _statusService.Get();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<StatusVM>(statusGrid, type, "Status", "Status");
        }


        async Task EditRow(StatusVM status)
        {
            await statusGrid.EditRow(status);
        }

        async void OnUpdateRow(StatusVM status)
        {
            if (status == statusToInsert)
            {
                statusToInsert = null;
            }


            await _statusService.Update(status);

        }

        async Task SaveRow(StatusVM status)
        {
            if (status == statusToInsert)
            {
                statusToInsert = null;
            }

            await statusGrid.UpdateRow(status);
        }

        void CancelEdit(StatusVM status)
        {
            if (status == statusToInsert)
            {
                statusToInsert = null;
            }

            statusGrid.CancelEditRow(status);

        }

        async Task DeleteRow(StatusVM status)
        {
            if (status == statusToInsert)
            {
                statusToInsert = null;
            }

            if (statuses.Contains(status))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                statuses.ToList().Remove(status);

                // For production
                //dbContext.SaveChanges();

                await statusGrid.Reload();
            }
            else
            {
                statusGrid.CancelEditRow(status);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            statusToInsert = new StatusVM();
            await statusGrid.InsertRow(statusToInsert);

        }

        async Task OnCreateRow(StatusVM status)
        {
            // dbContext.Add(order);
            await _statusService.Update(status);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
