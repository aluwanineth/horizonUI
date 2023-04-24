using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class BenefitPackage
    {

        RadzenDataGrid<BenefitPackageVM> benefitpackagesGrid = null;
        BenefitPackageVM benefitpackageToInsert = null;
        public IEnumerable<BenefitPackageVM> benefitpackages = new List<BenefitPackageVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            benefitpackages = await _benefitOptionService.GetBenefitPackages();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<BenefitPackageVM>(benefitpackagesGrid, type, "BenefitPackage", "BenefitPackage");
        }


        async Task EditRow(BenefitPackageVM benefitpackage)
        {
            await benefitpackagesGrid.EditRow(benefitpackage);
        }

        async void OnUpdateRow(BenefitPackageVM benefitpackage)
        {
            if (benefitpackage == benefitpackageToInsert)
            {
                benefitpackageToInsert = null;
            }


            await _benefitOptionService.UpdateBenefitPackage(benefitpackage);

        }

        async Task SaveRow(BenefitPackageVM benefitpackage)
        {
            if (benefitpackage == benefitpackageToInsert)
            {
                benefitpackageToInsert = null;
            }

            await benefitpackagesGrid.UpdateRow(benefitpackage);
        }

        void CancelEdit(BenefitPackageVM benefitpackage)
        {
            if (benefitpackage == benefitpackageToInsert)
            {
                benefitpackageToInsert = null;
            }

            benefitpackagesGrid.CancelEditRow(benefitpackage);

        }

        async Task DeleteRow(BenefitPackageVM benefitpackage)
        {
            if (benefitpackage == benefitpackageToInsert)
            {
                benefitpackageToInsert = null;
            }

            if (benefitpackages.Contains(benefitpackage))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                benefitpackages.ToList().Remove(benefitpackage);

                // For production
                //dbContext.SaveChanges();

                await benefitpackagesGrid.Reload();
            }
            else
            {
                benefitpackagesGrid.CancelEditRow(benefitpackage);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            benefitpackageToInsert = new BenefitPackageVM();
            await benefitpackagesGrid.InsertRow(benefitpackageToInsert);

        }

        async Task OnCreateRow(BenefitPackageVM benefitpackage)
        {
            // dbContext.Add(order);
            await _benefitOptionService.SaveBenefitPackage(benefitpackage);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
