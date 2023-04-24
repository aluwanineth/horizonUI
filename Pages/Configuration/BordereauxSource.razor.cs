using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class BordereauxSource
    {
        RadzenDataGrid<BordereauxSourceVM> bordereauxsourcesGrid = null;
        BordereauxSourceVM bordereauxsourceToInsert = null;
        public IEnumerable<BordereauxSourceVM> bordereauxsources = new List<BordereauxSourceVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            bordereauxsources = await _bordereauxSource.GetBordereauxSources();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<BordereauxSourceVM>(bordereauxsourcesGrid, type, "BordereauxSource", "BordereauxSources");
        }


        async Task EditRow(BordereauxSourceVM bordereauxsource)
        {
            await bordereauxsourcesGrid.EditRow(bordereauxsource);
        }

        async void OnUpdateRow(BordereauxSourceVM bordereauxsource)
        {
            if( bordereauxsource == bordereauxsourceToInsert)
            {
                bordereauxsourceToInsert = null;
            }


            await _bordereauxSource.UpdatetBordereauxSource(bordereauxsource);

        }

        async Task SaveRow(BordereauxSourceVM bordereauxsource)
        {
            if (bordereauxsource == bordereauxsourceToInsert)
            {
                bordereauxsourceToInsert = null;
            }

            await bordereauxsourcesGrid.UpdateRow(bordereauxsource);
        }

        void CancelEdit(BordereauxSourceVM bordereauxsource)
        {
            if (bordereauxsource == bordereauxsourceToInsert)
            {
                bordereauxsourceToInsert = null;
            }

            bordereauxsourcesGrid.CancelEditRow(bordereauxsource);

        }

        async Task DeleteRow(BordereauxSourceVM bordereauxsource)
        {
            if (bordereauxsource == bordereauxsourceToInsert)
            {
                bordereauxsourceToInsert = null;
            }

            if (bordereauxsources.Contains(bordereauxsource))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                bordereauxsources.ToList().Remove(bordereauxsource);

                // For production
                //dbContext.SaveChanges();

                await bordereauxsourcesGrid.Reload();
            }
            else
            {
                bordereauxsourcesGrid.CancelEditRow(bordereauxsource);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            bordereauxsourceToInsert = new BordereauxSourceVM();
            await bordereauxsourcesGrid.InsertRow(bordereauxsourceToInsert);

        }

        async Task OnCreateRow(BordereauxSourceVM bordereauxsource)
        {
            // dbContext.Add(order);
            await _bordereauxSource.SavetBordereauxSource(bordereauxsource);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
