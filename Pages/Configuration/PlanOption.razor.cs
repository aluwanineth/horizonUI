using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class PlanOption
    {
        RadzenDataGrid<PlanOptionVM> planoptionGrid = null;
        PlanOptionVM planoptionToInsert = null;
        public IEnumerable<PlanOptionVM> planoptions = new List<PlanOptionVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            planoptions = await _planoptionService.GetPlanOptions();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<PlanOptionVM>(planoptionGrid, type, "PlanOption", "PlanOptions");
        }


        async Task EditRow(PlanOptionVM planoption)
        {
            await planoptionGrid.EditRow(planoption);
        }

        async void OnUpdateRow(PlanOptionVM planoption)
        {
            if (planoption == planoptionToInsert)
            {
                planoptionToInsert = null;
            }


            await _planoptionService.UpdatePlanOption(planoption);

        }

        async Task SaveRow(PlanOptionVM planoption)
        {
            if (planoption == planoptionToInsert)
            {
                planoptionToInsert = null;
            }

            await planoptionGrid.UpdateRow(planoption);
        }

        void CancelEdit(PlanOptionVM planoption)
        {
            if (planoption == planoptionToInsert)
            {
                planoptionToInsert = null;
            }

            planoptionGrid.CancelEditRow(planoption);

        }

        async Task DeleteRow(PlanOptionVM planoption)
        {
            if (planoption == planoptionToInsert)
            {
                planoptionToInsert = null;
            }

            if (planoptions.Contains(planoption))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                planoptions.ToList().Remove(planoption);

                // For production
                //dbContext.SaveChanges();

                await planoptionGrid.Reload();
            }
            else
            {
                planoptionGrid.CancelEditRow(planoption);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            planoptionToInsert = new PlanOptionVM();
            await planoptionGrid.InsertRow(planoptionToInsert);

        }

        async Task OnCreateRow(PlanOptionVM paymentoption)
        {
            // dbContext.Add(order);
            await _planoptionService.SavePlanOption(paymentoption);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
