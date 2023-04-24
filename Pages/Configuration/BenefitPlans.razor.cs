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
    public partial class BenefitPlans
    {
        RadzenDataGrid<BenefitPlansVM> benefitPlansGrid = null;
        BenefitPlansVM benefitPlansToInsert = null;
        public IEnumerable<BenefitPlansVM> benefitPlans = new List<BenefitPlansVM>();
        bool enable = true;
        public IEnumerable<BenefitTypeVM> benefitTypeLookup;
        public IEnumerable<PlanTypeVM> planLookup;


        protected override async Task OnInitializedAsync()
        {

            benefitPlans = await _benefitPlansService.GetBenefitPlans();
            benefitTypeLookup = await _benefitTypeService.GetBenefitTypes();
            planLookup = await _planTypeService.GetPlanTypes();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<BenefitPlansVM>(benefitPlansGrid, type, "BenefitPlans", "BenefitPlans");
        }


        async Task EditRow(BenefitPlansVM benefitPlanCover)
        {
            await benefitPlansGrid.EditRow(benefitPlanCover);
        }

        async void OnUpdateRow(BenefitPlansVM benefitPlans)
        {
            if (benefitPlans == benefitPlansToInsert)
            {
                benefitPlansToInsert = null;
            }


            await _benefitPlansService.UpdateBenefitPlans(benefitPlans);

        }

        async Task SaveRow(BenefitPlansVM benefitPlanCover)
        {
            if (benefitPlanCover == benefitPlansToInsert)
            {
                benefitPlansToInsert = null;
            }

            await benefitPlansGrid.UpdateRow(benefitPlanCover);
        }

        void CancelEdit(BenefitPlansVM benefitPlanCover)
        {
            if (benefitPlanCover == benefitPlansToInsert)
            {
                benefitPlansToInsert = null;
            }

            benefitPlansGrid.CancelEditRow(benefitPlanCover);

        }

        async Task DeleteRow(BenefitPlansVM benefitPlanCover)
        {
            if (benefitPlanCover == benefitPlansToInsert)
            {
                benefitPlansToInsert = null;
            }

            if (benefitPlans.Contains(benefitPlanCover))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                benefitPlans.ToList().Remove(benefitPlanCover);

                // For production
                //dbContext.SaveChanges();

                await benefitPlansGrid.Reload();
            }
            else
            {
                benefitPlansGrid.CancelEditRow(benefitPlanCover);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            benefitPlansToInsert = new BenefitPlansVM();
            await benefitPlansGrid.InsertRow(benefitPlansToInsert);

        }

        async Task OnCreateRow(BenefitPlansVM benefitPlanCover)
        {
            // dbContext.Add(order);
            await _benefitPlansService.SaveBenefitPlans(benefitPlanCover);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
