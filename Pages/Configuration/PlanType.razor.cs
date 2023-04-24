using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class PlanType
    {

        RadzenDataGrid<PlanTypeVM> plantypeGrid = null;
        PlanTypeVM plantypeToInsert = null;
        public IEnumerable<PlanTypeVM> plantypes = new List<PlanTypeVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            plantypes = await _plantypeService.GetPlanTypes();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<PlanTypeVM>(plantypeGrid, type, "PlanType", "PlanTypes");
        }


        async Task EditRow(PlanTypeVM plantype)
        {
            await plantypeGrid.EditRow(plantype);
        }

        async void OnUpdateRow(PlanTypeVM plantype)
        {
            if (plantype == plantypeToInsert)
            {
                plantypeToInsert = null;
            }


            await _plantypeService.UpdatePlanType(plantype);

        }

        async Task SaveRow(PlanTypeVM plantype)
        {
            if (plantype == plantypeToInsert)
            {
                plantypeToInsert = null;
            }


            await plantypeGrid.UpdateRow(plantype);
        }

        void CancelEdit(PlanTypeVM plantype)
        {
            if (plantype == plantypeToInsert)
            {
                plantypeToInsert = null;
            }

            plantypeGrid.CancelEditRow(plantype);

        }

        async Task DeleteRow(PlanTypeVM plantype)
        {
            if (plantype == plantypeToInsert)
            {
                plantypeToInsert = null;
            }

            if (plantypes.Contains(plantype))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                plantypes.ToList().Remove(plantype);

                // For production
                //dbContext.SaveChanges();

                await plantypeGrid.Reload();
            }
            else
            {
                plantypeGrid.CancelEditRow(plantype);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            plantypeToInsert = new PlanTypeVM();
            await plantypeGrid.InsertRow(plantypeToInsert);

        }

        async Task OnCreateRow(PlanTypeVM plantype)
        {
            // dbContext.Add(order);
            await _plantypeService.SavePlanType(plantype);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
