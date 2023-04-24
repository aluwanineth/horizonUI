using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class LoadingType
    {
        RadzenDataGrid<LoadingTypeVM> loadingtypeGrid = null;
        LoadingTypeVM loadingtypeToInsert = null;
        public IEnumerable<LoadingTypeVM> loadingtypes = new List<LoadingTypeVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            loadingtypes = await _loadingtypeService.GetLoadingTypes();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<LoadingTypeVM>(loadingtypeGrid, type, "LoadingType", "LoadingTypes");
        }


        async Task EditRow(LoadingTypeVM loadingtype)
        {
            await loadingtypeGrid.EditRow(loadingtype);
        }

        async void OnUpdateRow(LoadingTypeVM loadingtype)
        {
            if (loadingtype == loadingtypeToInsert)
            {
                loadingtypeToInsert = null;
            }


            await _loadingtypeService.UpdateLoadingType(loadingtype);

        }

        async Task SaveRow(LoadingTypeVM loadingtype)
        {
            if (loadingtype == loadingtypeToInsert)
            {
                loadingtypeToInsert = null;
            }

            await loadingtypeGrid.UpdateRow(loadingtype);
        }

        void CancelEdit(LoadingTypeVM loadingtype)
        {
            if (loadingtype == loadingtypeToInsert)
            {
                loadingtypeToInsert = null;
            }

            loadingtypeGrid.CancelEditRow(loadingtype);

        }

        async Task DeleteRow(LoadingTypeVM loadingtype)
        {
            if (loadingtype == loadingtypeToInsert)
            {
                loadingtypeToInsert = null;
            }

            if (loadingtypes.Contains(loadingtype))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                loadingtypes.ToList().Remove(loadingtype);

                // For production
                //dbContext.SaveChanges();

                await loadingtypeGrid.Reload();
            }
            else
            {
                loadingtypeGrid.CancelEditRow(loadingtype);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            loadingtypeToInsert = new LoadingTypeVM();
            await loadingtypeGrid.InsertRow(loadingtypeToInsert);

        }

        async Task OnCreateRow(LoadingTypeVM loadingtype)
        {
            // dbContext.Add(order);
            await _loadingtypeService.SaveLoadingType(loadingtype);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
