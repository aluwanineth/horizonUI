using HorizonPollyC.Models.Configuration;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class Scheme
    {
        RadzenDataGrid<SchemeVM> schemeGrid = null;
        SchemeVM schemeToInsert = null;
        public IEnumerable<SchemeVM> schemes = new List<SchemeVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            schemes = await _schemeService.Get();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<SchemeVM>(schemeGrid, type, "Smoker", "Smoker");
        }


        async Task EditRow(SchemeVM scheme)
        {
            await schemeGrid.EditRow(scheme);
        }

        async void OnUpdateRow(SchemeVM scheme)
        {
            if (scheme == schemeToInsert)
            {
                schemeToInsert = null;
            }


            await _schemeService.Update(scheme);

        }

        async Task SaveRow(SchemeVM scheme)
        {
            if (scheme == schemeToInsert)
            {
                schemeToInsert = null;
            }

            await schemeGrid.UpdateRow(scheme);
        }

        void CancelEdit(SchemeVM scheme)
        {
            if (scheme == schemeToInsert)
            {
                schemeToInsert = null;
            }

            schemeGrid.CancelEditRow(scheme);

        }

        async Task DeleteRow(SchemeVM scheme)
        {
            if (scheme == schemeToInsert)
            {
                schemeToInsert = null;
            }

            if (schemes.Contains(scheme))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                schemes.ToList().Remove(scheme);

                // For production
                //dbContext.SaveChanges();

                await schemeGrid.Reload();
            }
            else
            {
                schemeGrid.CancelEditRow(scheme);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            schemeToInsert = new SchemeVM();
            await schemeGrid.InsertRow(schemeToInsert);

        }

        async Task OnCreateRow(SchemeVM smoker)
        {
            // dbContext.Add(order);
            await _schemeService.Update(smoker);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
