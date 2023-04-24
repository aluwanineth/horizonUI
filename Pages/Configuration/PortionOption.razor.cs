using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class PortionOption
    {
        RadzenDataGrid<PortionOptionVM> portionoptionGrid = null;
        PortionOptionVM portionoptionToInsert = null;
        public IEnumerable<PortionOptionVM> portionoptions = new List<PortionOptionVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            portionoptions = await _portionoptionService.GetPortionOptions();

        }
        public async Task Export(string type)
        {
            await _exportService.ExportData<PortionOptionVM>(portionoptionGrid, type, "PortionOption", "PortionOption");
        }


        async Task EditRow(PortionOptionVM portionoption)
        {
            await portionoptionGrid.EditRow(portionoption);
        }

        async void OnUpdateRow(PortionOptionVM portionoption)
        {
            if (portionoption == portionoptionToInsert)
            {
                portionoptionToInsert = null;
            }


           // await _portionoptionService.UpdatePortionOption(portionoption);

        }

        async Task SaveRow(PortionOptionVM portionoption)
        {
            if (portionoption == portionoptionToInsert)
            {
                portionoptionToInsert = null;
            }


            await portionoptionGrid.UpdateRow(portionoption);
        }

        void CancelEdit(PortionOptionVM portionoption)
        {
            if (portionoption == portionoptionToInsert)
            {
                portionoptionToInsert = null;
            }

            portionoptionGrid.CancelEditRow(portionoption);

        }

        async Task DeleteRow(PortionOptionVM portionoption)
        {
            if (portionoption == portionoptionToInsert)
            {
                portionoptionToInsert = null;
            }

            if (portionoptions.Contains(portionoption))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                portionoptions.ToList().Remove(portionoption);

                // For production
                //dbContext.SaveChanges();

                await portionoptionGrid.Reload();
            }
            else
            {
                portionoptionGrid.CancelEditRow(portionoption);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            portionoptionToInsert = new PortionOptionVM();
            await portionoptionGrid.InsertRow(portionoptionToInsert);

        }

        async Task OnCreateRow(PortionOptionVM portionoption)
        {
            // dbContext.Add(order);
            await _portionoptionService.SavePortionOption(portionoption);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
