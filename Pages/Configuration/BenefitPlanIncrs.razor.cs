using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using HorizonPollyC.Services.General;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
using System.Linq;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class BenefitPlanIncrs
    {
        RadzenDataGrid<BenefitPlanIncrsVM> benefitPlanIncrsGrid = null;
        BenefitPlanIncrsVM benefitPlanIncrsToInsert = null;
        public IEnumerable<BenefitPlanIncrsVM> benefitPlanIncrs = new List<BenefitPlanIncrsVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IBenefitPackagesService _benefitPackagesService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            benefitPlanIncrs = await _benefitPlanIncrsService.GetBenefitPlanIncrs();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<BenefitPlanIncrsVM>(benefitPlanIncrsGrid, type, "BenefitPlanIncrs", "BenefitPlanIncrs");
        }

        async Task EditRow(BenefitPlanIncrsVM benefitPlanCover)
        {
            await benefitPlanIncrsGrid.EditRow(benefitPlanCover);
        }

        async void OnUpdateRow(BenefitPlanIncrsVM benefitPlanIncrs)
        {
            if (benefitPlanIncrs == benefitPlanIncrsToInsert)
            {
                benefitPlanIncrsToInsert = null;
            }


            await _benefitPlanIncrsService.UpdateBenefitPlanIncrs(benefitPlanIncrs);

        }

        async Task SaveRow(BenefitPlanIncrsVM benefitPlanCover)
        {
            if (benefitPlanCover == benefitPlanIncrsToInsert)
            {
                benefitPlanIncrsToInsert = null;
            }

            await benefitPlanIncrsGrid.UpdateRow(benefitPlanCover);
        }

        void CancelEdit(BenefitPlanIncrsVM benefitPlanCover)
        {
            if (benefitPlanCover == benefitPlanIncrsToInsert)
            {
                benefitPlanIncrsToInsert = null;
            }

            benefitPlanIncrsGrid.CancelEditRow(benefitPlanCover);

        }

        async Task DeleteRow(BenefitPlanIncrsVM benefitPlanCover)
        {
            if (benefitPlanCover == benefitPlanIncrsToInsert)
            {
                benefitPlanIncrsToInsert = null;
            }

            if (benefitPlanIncrs.Contains(benefitPlanCover))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                benefitPlanIncrs.ToList().Remove(benefitPlanCover);

                // For production
                //dbContext.SaveChanges();

                await benefitPlanIncrsGrid.Reload();
            }
            else
            {
                benefitPlanIncrsGrid.CancelEditRow(benefitPlanCover);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            benefitPlanIncrsToInsert = new BenefitPlanIncrsVM();
            await benefitPlanIncrsGrid.InsertRow(benefitPlanIncrsToInsert);

        }

        async Task OnCreateRow(BenefitPlanIncrsVM benefitPlanCover)
        {
            // dbContext.Add(order);
            await _benefitPlanIncrsService.SaveBenefitPlanIncrs(benefitPlanCover);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
