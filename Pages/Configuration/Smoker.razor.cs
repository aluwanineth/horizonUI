using HorizonPollyC.Models.Configuration;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class Smoker
    {
        RadzenDataGrid<SmokerVM> smokerGrid = null;
        SmokerVM smokerToInsert = null;
        public IEnumerable<SmokerVM> smokers = new List<SmokerVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            smokers = await _smokerService.Get();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<SmokerVM>(smokerGrid, type, "Smoker", "Smoker");
        }


        async Task EditRow(SmokerVM smoker)
        {
            await smokerGrid.EditRow(smoker);
        }

        async void OnUpdateRow(SmokerVM smoker)
        {
            if (smoker == smokerToInsert)
            {
                smokerToInsert = null;
            }


            await _smokerService.Update(smoker);

        }

        async Task SaveRow(SmokerVM smoker)
        {
            if (smoker == smokerToInsert)
            {
                smokerToInsert = null;
            }

            await smokerGrid.UpdateRow(smoker);
        }

        void CancelEdit(SmokerVM smoker)
        {
            if (smoker == smokerToInsert)
            {
                smokerToInsert = null;
            }

            smokerGrid.CancelEditRow(smoker);

        }

        async Task DeleteRow(SmokerVM smoker)
        {
            if (smoker == smokerToInsert)
            {
                smokerToInsert = null;
            }

            if (smokers.Contains(smoker))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                smokers.ToList().Remove(smoker);

                // For production
                //dbContext.SaveChanges();

                await smokerGrid.Reload();
            }
            else
            {
                smokerGrid.CancelEditRow(smoker);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            smokerToInsert = new SmokerVM();
            await smokerGrid.InsertRow(smokerToInsert);

        }

        async Task OnCreateRow(SmokerVM smoker)
        {
            // dbContext.Add(order);
            await _smokerService.Update(smoker);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
