using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class Cover
    {
        RadzenDataGrid<CoverVM> coverGrid = null;
        CoverVM coverToInsert = null;
        public IEnumerable<CoverVM> covers = new List<CoverVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            covers = await _coverService.GetCovers();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<CoverVM>(coverGrid, type, "Cover", "Cover");
        }


        async Task EditRow(CoverVM cover)
        {
            await coverGrid.EditRow(cover);
        }

        async void OnUpdateRow(CoverVM cover)
        {
            if (cover == coverToInsert)
            {
                coverToInsert = null;
            }


            await _coverService.UpdateCover(cover);

        }

        async Task SaveRow(CoverVM cover)
        {

            if (cover == coverToInsert)
            {
                coverToInsert = null;
            }

            await coverGrid.UpdateRow(cover);
        }

        void CancelEdit(CoverVM cover)
        {
            if (cover == coverToInsert)
            {
                coverToInsert = null;
            }

            coverGrid.CancelEditRow(cover);

        }

        async Task DeleteRow(CoverVM cover)
        {
            if (cover == coverToInsert)
            {
                coverToInsert = null;
            }

            if (covers.Contains(cover))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                covers.ToList().Remove(cover);

                // For production
                //dbContext.SaveChanges();

                await coverGrid.Reload();
            }
            else
            {
                coverGrid.CancelEditRow(cover);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            coverToInsert = new CoverVM();
            await coverGrid.InsertRow(coverToInsert);

        }

        async Task OnCreateRow(CoverVM cover)
        {
            // dbContext.Add(order);
            await _coverService.SaveCover(cover);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
