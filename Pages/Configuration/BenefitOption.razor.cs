using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class BenefitOption 
    {
        RadzenDataGrid<BenefitOptionVM> benefitoptionsGrid = null;
        BenefitOptionVM benefitoptionToInsert = null;
        public IEnumerable<BenefitOptionVM> benefitoptions = new List<BenefitOptionVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            benefitoptions = await _benefitOptionService.GetBenefitOptions();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<BenefitOptionVM>(benefitoptionsGrid, type, "BenefitOption", "BenefitOptions");
        }


        async Task EditRow(BenefitOptionVM benefitoption)
        {
            await benefitoptionsGrid.EditRow(benefitoption);
        }

        async void OnUpdateRow(BenefitOptionVM benefitoption)
        {
            if (benefitoption == benefitoptionToInsert)
            {
                benefitoptionToInsert = null;
            }


            await _benefitOptionService.UpdateBenefitOption(benefitoption);

        }

        async Task SaveRow(BenefitOptionVM benefitoption)
        {
            if (benefitoption == benefitoptionToInsert)
            {
                benefitoptionToInsert = null;
            }

            await benefitoptionsGrid.UpdateRow(benefitoption);
        }

        void CancelEdit(BenefitOptionVM benefitoption)
        {
            if (benefitoption == benefitoptionToInsert)
            {
                benefitoptionToInsert = null;
            }

            benefitoptionsGrid.CancelEditRow(benefitoption);

        }

        async Task DeleteRow(BenefitOptionVM benefitoption)
        {
            if (benefitoption == benefitoptionToInsert)
            {
                benefitoptionToInsert = null;
            }

            if (benefitoptions.Contains(benefitoption))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                benefitoptions.ToList().Remove(benefitoption);

                // For production
                //dbContext.SaveChanges();

                await benefitoptionsGrid.Reload();
            }
            else
            {
                benefitoptionsGrid.CancelEditRow(benefitoption);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            benefitoptionToInsert = new BenefitOptionVM();
            await benefitoptionsGrid.InsertRow(benefitoptionToInsert);

        }

        async Task OnCreateRow(BenefitOptionVM attribute)
        {
            // dbContext.Add(order);
            await _benefitOptionService.SaveBenefitOption(attribute);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
