using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class Error
    {
        RadzenDataGrid<ErrorVM> errorGrid = null;
        ErrorVM errorToInsert = null;
        public IEnumerable<ErrorVM> errors = new List<ErrorVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            errors = await _errorService.GetErrors();

        }
        public async Task Export(string type)
        {
            await _exportService.ExportData<ErrorVM>(errorGrid, type, "Error", "Errors");
        }


        async Task EditRow(ErrorVM error)
        {
            await errorGrid.EditRow(error);
        }

        async void OnUpdateRow(ErrorVM error)
        {
            if (error == errorToInsert)
            {
                errorToInsert = null;
            }


            await _errorService.UpdateError(error);

        }

        async Task SaveRow(ErrorVM error)
        {

            if (error == errorToInsert)
            {
                errorToInsert = null;
            }

            await errorGrid.UpdateRow(error);
        }

        void CancelEdit(ErrorVM error)
        {
            if (error == errorToInsert)
            {
                errorToInsert = null;
            }

            errorGrid.CancelEditRow(error);

        }

        async Task DeleteRow(ErrorVM error)
        {
            if (error == errorToInsert)
            {
                errorToInsert = null;
            }

            if (errors.Contains(error))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                errors.ToList().Remove(error);

                // For production
                //dbContext.SaveChanges();

                await errorGrid.Reload();
            }
            else
            {
                errorGrid.CancelEditRow(error);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            errorToInsert = new ErrorVM();
            await errorGrid.InsertRow(errorToInsert);

        }

        async Task OnCreateRow(ErrorVM error)
        {
            // dbContext.Add(order);
            await _errorService.SaveError(error);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}

