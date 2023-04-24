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
    public partial class BenefitPlanCovers
    {
        RadzenDataGrid<BenefitPlanCoversVM> benefitPlanCoversGrid = null;
        BenefitPlanCoversVM benefitPlanCoversToInsert = null;
        public IEnumerable<BenefitPlanCoversVM> benefitPlanCovers = new List<BenefitPlanCoversVM>();

        public IEnumerable<CoverVM> coversLookup;
        public IEnumerable<BenefitPlansVM> benefitPlansLookup;

        bool enable = true;



        protected override async Task OnInitializedAsync()
        {

            benefitPlanCovers = await _benefitPlanCoversService.GetBenefitPlanCovers();
            coversLookup = await _coverService.GetCovers();
            benefitPlansLookup = await _benefitsPlanService.GetBenefitPlans();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<BenefitPlanCoversVM>(benefitPlanCoversGrid, type, "BenefitPlanCovers", "BenefitPlanCovers");
        }


        async Task EditRow(BenefitPlanCoversVM benefitPlanCover)
        {
            await benefitPlanCoversGrid.EditRow(benefitPlanCover);
        }

        async void OnUpdateRow(BenefitPlanCoversVM benefitPlanCovers)
        {
            if (benefitPlanCovers == benefitPlanCoversToInsert)
            {
                benefitPlanCoversToInsert = null;
            }


            await _benefitPlanCoversService.UpdateBenefitPlanCovers(benefitPlanCovers);

        }

        async Task SaveRow(BenefitPlanCoversVM benefitPlanCover)
        {
            if (benefitPlanCover == benefitPlanCoversToInsert)
            {
                benefitPlanCoversToInsert = null;
            }

            await benefitPlanCoversGrid.UpdateRow(benefitPlanCover);
        }

        void CancelEdit(BenefitPlanCoversVM benefitPlanCover)
        {
            if (benefitPlanCover == benefitPlanCoversToInsert)
            {
                benefitPlanCoversToInsert = null;
            }

            benefitPlanCoversGrid.CancelEditRow(benefitPlanCover);

        }

        async Task DeleteRow(BenefitPlanCoversVM benefitPlanCover)
        {
            if (benefitPlanCover == benefitPlanCoversToInsert)
            {
                benefitPlanCoversToInsert = null;
            }

            if (benefitPlanCovers.Contains(benefitPlanCover))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                benefitPlanCovers.ToList().Remove(benefitPlanCover);

                // For production
                //dbContext.SaveChanges();

                await benefitPlanCoversGrid.Reload();
            }
            else
            {
                benefitPlanCoversGrid.CancelEditRow(benefitPlanCover);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            benefitPlanCoversToInsert = new BenefitPlanCoversVM();
            await benefitPlanCoversGrid.InsertRow(benefitPlanCoversToInsert);

        }

        async Task OnCreateRow(BenefitPlanCoversVM benefitPlanCover)
        {
            // dbContext.Add(order);
            await _benefitPlanCoversService.SaveBenefitPlanCovers(benefitPlanCover);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
