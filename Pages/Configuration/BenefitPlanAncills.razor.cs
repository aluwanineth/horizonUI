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
    public partial class BenefitPlanAncills
    {
        RadzenDataGrid<BenefitPlanAncillsVM> benefitPlanAncillsGrid = null;
        BenefitPlanAncillsVM benefitPlanAncillsToInsert = null;
        public IEnumerable<BenefitPlanAncillsVM> benefitPlanAncills = new List<BenefitPlanAncillsVM>();

        public IEnumerable<BenefitPlansVM> benefitPlanLookup;
        public IEnumerable<RoleVM> roleTypeLookup;
        public IEnumerable<AncilTypeVM> ancilTypeLookup;


        bool enable = true;



        protected override async Task OnInitializedAsync()
        {

            benefitPlanAncills = await _benefitPlanAncillsService.GetBenefitPlanAncills();
            benefitPlanLookup = await _benefitPlanService.GetBenefitPlans();
            roleTypeLookup = await _genericService.Get();
            ancilTypeLookup = await _ancilTypeService.GetAncilTypes();


        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<BenefitPlanAncillsVM>(benefitPlanAncillsGrid, type, "BenefitPlanAncills", "benefitplanancills");
        }


        async Task EditRow(BenefitPlanAncillsVM benefitPlanAncill)
        {
            await benefitPlanAncillsGrid.EditRow(benefitPlanAncill);
        }

        async void OnUpdateRow(BenefitPlanAncillsVM benefitPackages)
        {
            if (benefitPackages == benefitPlanAncillsToInsert)
            {
                benefitPlanAncillsToInsert = null;
            }


            await _benefitPlanAncillsService.UpdateBenefitPlanAncills(benefitPackages);

        }

        async Task SaveRow(BenefitPlanAncillsVM benefitPlanAncill)
        {
            if (benefitPlanAncill == benefitPlanAncillsToInsert)
            {
                benefitPlanAncillsToInsert = null;
            }

            await benefitPlanAncillsGrid.UpdateRow(benefitPlanAncill);
        }

        void CancelEdit(BenefitPlanAncillsVM benefitPlanAncill)
        {
            if (benefitPlanAncill == benefitPlanAncillsToInsert)
            {
                benefitPlanAncillsToInsert = null;
            }

            benefitPlanAncillsGrid.CancelEditRow(benefitPlanAncill);

        }

        async Task DeleteRow(BenefitPlanAncillsVM benefitPlanAncill)
        {
            if (benefitPlanAncill == benefitPlanAncillsToInsert)
            {
                benefitPlanAncillsToInsert = null;
            }

            if (benefitPlanAncills.Contains(benefitPlanAncill))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                benefitPlanAncills.ToList().Remove(benefitPlanAncill);

                // For production
                //dbContext.SaveChanges();

                await benefitPlanAncillsGrid.Reload();
            }
            else
            {
                benefitPlanAncillsGrid.CancelEditRow(benefitPlanAncill);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            benefitPlanAncillsToInsert = new BenefitPlanAncillsVM();
            await benefitPlanAncillsGrid.InsertRow(benefitPlanAncillsToInsert);

        }

        async Task OnCreateRow(BenefitPlanAncillsVM benefitPackages)
        {
            // dbContext.Add(order);
            await _benefitPlanAncillsService.SaveBenefitPlanAncills(benefitPackages);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
