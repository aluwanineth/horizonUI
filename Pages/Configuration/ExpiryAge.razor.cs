using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class ExpiryAge
    {
        RadzenDataGrid<ExpiryAgeVM> expiryageGrid = null;
        ExpiryAgeVM expiryageToInsert = null;
        public IEnumerable<ExpiryAgeVM> expiryages = new List<ExpiryAgeVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            expiryages = await _expiryageService.GetExpiryAges();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<ExpiryAgeVM>(expiryageGrid, type, "ExpiryAge", "ExpiryAges");
        }


        async Task EditRow(ExpiryAgeVM expiryage)
        {
            await expiryageGrid.EditRow(expiryage);
        }

        async void OnUpdateRow(ExpiryAgeVM expiryage)
        {
            if (expiryage == expiryageToInsert)
            {
                expiryageToInsert = null;
            }


            await _expiryageService.UpdateExpiryAge(expiryage);

        }

        async Task SaveRow(ExpiryAgeVM expiryage)
        {

            if (expiryage == expiryageToInsert)
            {
                expiryageToInsert = null;
            }

            await expiryageGrid.UpdateRow(expiryage);
        }

        void CancelEdit(ExpiryAgeVM expiryage)
        {
            if (expiryage == expiryageToInsert)
            {
                expiryageToInsert = null;
            }

            expiryageGrid.CancelEditRow(expiryage);

        }

        async Task DeleteRow(ExpiryAgeVM expiryage)
        {
            if (expiryage == expiryageToInsert)
            {
                expiryageToInsert = null;
            }

            if (expiryages.Contains(expiryage))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                expiryages.ToList().Remove(expiryage);

                // For production
                //dbContext.SaveChanges();

                await expiryageGrid.Reload();
            }
            else
            {
                expiryageGrid.CancelEditRow(expiryage);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            expiryageToInsert = new ExpiryAgeVM();
            await expiryageGrid.InsertRow(expiryageToInsert);

        }

        async Task OnCreateRow(ExpiryAgeVM expiryage)
        {
            // dbContext.Add(order);
            await _expiryageService.SaveExpiryAge(expiryage);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
