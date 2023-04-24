using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class Loading
    {
        RadzenDataGrid<LoadingVM> loadingGrid = null;
        LoadingVM loadingToInsert = null;
        public IEnumerable<LoadingVM> loadings = new List<LoadingVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            loadings = await _loadingService.GetLoadings();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<LoadingVM>(loadingGrid, type, "Loading", "Loadings");
        }


        async Task EditRow(LoadingVM loading)
        {
            await loadingGrid.EditRow(loading);
        }

        async void OnUpdateRow(LoadingVM loading)
        {
            if (loading == loadingToInsert)
            {
                loadingToInsert = null;
            }


            await _loadingService.UpdateLoading(loading);

        }

        async Task SaveRow(LoadingVM loading)
        {
            if (loading == loadingToInsert)
            {
                loadingToInsert = null;
            }

            await loadingGrid.UpdateRow(loading);
        }

        void CancelEdit(LoadingVM loading)
        {
            if (loading == loadingToInsert)
            {
                loadingToInsert = null;
            }

            loadingGrid.CancelEditRow(loading);

        }

        async Task DeleteRow(LoadingVM loading)
        {
            if (loading == loadingToInsert)
            {
                loadingToInsert = null;
            }

            if (loadings.Contains(loading))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                loadings.ToList().Remove(loading);

                // For production
                //dbContext.SaveChanges();

                await loadingGrid.Reload();
            }
            else
            {
                loadingGrid.CancelEditRow(loading);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            loadingToInsert = new LoadingVM();
            await loadingGrid.InsertRow(loadingToInsert);

        }

        async Task OnCreateRow(LoadingVM loading)
        {
            // dbContext.Add(order);
            await _loadingService.SaveLoading(loading);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
