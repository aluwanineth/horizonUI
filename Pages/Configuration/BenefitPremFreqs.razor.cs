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
    public partial class BenefitPremFreqs
    {
        RadzenDataGrid<BenefitPremFreqsVM> benefitPremFreqsGrid = null;
        BenefitPremFreqsVM benefitPremFreqsToInsert = null;
        public IEnumerable<BenefitPremFreqsVM> benefitPremFreqs = new List<BenefitPremFreqsVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IBenefitPackagesService _benefitPackagesService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            benefitPremFreqs = await _benefitPremFreqsService.GetBenefitPremFreqs();

        }
        public async Task Export(string type)
        {
            await _exportService.ExportData<BenefitPremFreqsVM>(benefitPremFreqsGrid, type, "BenefitPremFreqs", "BenefitPremFreqs");
        }

        async Task EditRow(BenefitPremFreqsVM benefitPlanCover)
        {
            await benefitPremFreqsGrid.EditRow(benefitPlanCover);
        }

        async void OnUpdateRow(BenefitPremFreqsVM benefitPremFreqs)
        {
            if (benefitPremFreqs == benefitPremFreqsToInsert)
            {
                benefitPremFreqsToInsert = null;
            }


            await _benefitPremFreqsService.UpdateBenefitPremFreqs(benefitPremFreqs);

        }

        async Task SaveRow(BenefitPremFreqsVM benefitPlanCover)
        {
            if (benefitPlanCover == benefitPremFreqsToInsert)
            {
                benefitPremFreqsToInsert = null;
            }

            await benefitPremFreqsGrid.UpdateRow(benefitPlanCover);
        }

        void CancelEdit(BenefitPremFreqsVM benefitPlanCover)
        {
            if (benefitPlanCover == benefitPremFreqsToInsert)
            {
                benefitPremFreqsToInsert = null;
            }

            benefitPremFreqsGrid.CancelEditRow(benefitPlanCover);

        }

        async Task DeleteRow(BenefitPremFreqsVM benefitPlanCover)
        {
            if (benefitPlanCover == benefitPremFreqsToInsert)
            {
                benefitPremFreqsToInsert = null;
            }

            if (benefitPremFreqs.Contains(benefitPlanCover))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                benefitPremFreqs.ToList().Remove(benefitPlanCover);

                // For production
                //dbContext.SaveChanges();

                await benefitPremFreqsGrid.Reload();
            }
            else
            {
                benefitPremFreqsGrid.CancelEditRow(benefitPlanCover);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            benefitPremFreqsToInsert = new BenefitPremFreqsVM();
            await benefitPremFreqsGrid.InsertRow(benefitPremFreqsToInsert);

        }

        async Task OnCreateRow(BenefitPremFreqsVM benefitPlanCover)
        {
            // dbContext.Add(order);
            await _benefitPremFreqsService.SaveBenefitPremFreqs(benefitPlanCover);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
