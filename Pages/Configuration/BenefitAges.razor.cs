using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using HorizonPollyC.Services.General;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class BenefitAges
    {
        RadzenDataGrid<BenefitAgesVM> benefitAgeGrid = null;
        BenefitAgesVM benefitAgesToInsert = null;
        public IEnumerable<BenefitAgesVM> benefitAges = new List<BenefitAgesVM>();
        bool enable = true;

        public IEnumerable<BenefitTypeVM> benefitTypeLookup;
        public IEnumerable<EntryAgeVM> EntryAgeLookup;
        public IEnumerable<ExpiryAgeVM> ExpiyAgeLookup;



        protected override async Task OnInitializedAsync()
        {

            benefitAges = await _benefitAgesService.GetBenefitAges();
            benefitTypeLookup = await _benefitTypeService.GetBenefitTypes();
            EntryAgeLookup = await _entryAgeService.GetEntryAges();
            ExpiyAgeLookup = await _expiryAgeService.GetExpiryAges();

        }
        public async Task Export(string type)
        {
            await _exportService.ExportData<BenefitAgesVM>(benefitAgeGrid, type, "BenefitAges", "BenefitAges");
        }


        async Task EditRow(BenefitAgesVM benefitAges)
        {
            await benefitAgeGrid.EditRow(benefitAges);
        }

        async void OnUpdateRow(BenefitAgesVM benefitAges)
        {
            if (benefitAges == benefitAgesToInsert)
            {
                benefitAgesToInsert = null;
            }


            await _benefitAgesService.UpdateBenefitAges(benefitAges);

        }

        async Task SaveRow(BenefitAgesVM benefitAges)
        {
            if (benefitAges == benefitAgesToInsert)
            {
                benefitAgesToInsert = null;
            }

            await benefitAgeGrid.UpdateRow(benefitAges);
        }

        void CancelEdit(BenefitAgesVM benefitAges)
        {
            if (benefitAges == benefitAgesToInsert)
            {
                benefitAgesToInsert = null;
            }

            benefitAgeGrid.CancelEditRow(benefitAges);

        }

        async Task InsertRow()
        {
            enable = false;
            benefitAgesToInsert = new BenefitAgesVM();
            await benefitAgeGrid.InsertRow(benefitAgesToInsert);

        }

        async Task OnCreateRow(BenefitAgesVM benefitAges)
        {
            // dbContext.Add(order);
            await _benefitAgesService.SaveBenefitAges(benefitAges);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
