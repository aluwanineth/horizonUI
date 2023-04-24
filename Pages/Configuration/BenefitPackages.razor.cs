using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using HorizonPollyC.Services.General;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class BenefitPackages
    {
        RadzenDataGrid<BenefitPackagesVM> benefitPackageGrid = null;
        BenefitPackagesVM benefitPackageToInsert = null;
        public IEnumerable<BenefitPackagesVM> benefitPackages = new List<BenefitPackagesVM>();
        public IEnumerable<BenefitPackageVM> benefitPackageLookup;
        public IEnumerable<BenefitTypeVM> benefitTypeLookup;

        bool enable = true;

        protected override async Task OnInitializedAsync()
        {

            benefitPackages = await _benefitPackagesService.GetBenefitPackages();
            benefitPackageLookup = await _benefitPackageService.GetBenefitPackages();
            benefitTypeLookup = await _benefitTypeService.GetBenefitTypes();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<BenefitPackagesVM>(benefitPackageGrid, type, "BenefitPackages", "benefitpackages");
        }

        async Task EditRow(BenefitPackagesVM benefitPackage)
        {
            await benefitPackageGrid.EditRow(benefitPackage);
        }

        async void OnUpdateRow(BenefitPackagesVM benefitPackages)
        {
            if (benefitPackages == benefitPackageToInsert)
            {
                benefitPackageToInsert = null;
            }


            await _benefitPackagesService.UpdateBenefitPackages(benefitPackages);

        }

        async Task SaveRow(BenefitPackagesVM benefitPackage)
        {
            if (benefitPackage == benefitPackageToInsert)
            {
                benefitPackageToInsert = null;
            }

            await benefitPackageGrid.UpdateRow(benefitPackage);
        }

        void CancelEdit(BenefitPackagesVM benefitPackage)
        {
            if (benefitPackage == benefitPackageToInsert)
            {
                benefitPackageToInsert = null;
            }

            benefitPackageGrid.CancelEditRow(benefitPackage);

        }

        async Task DeleteRow(BenefitPackagesVM benefitPackage)
        {
            if (benefitPackage == benefitPackageToInsert)
            {
                benefitPackageToInsert = null;
            }

            if (benefitPackages.Contains(benefitPackage))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                benefitPackages.ToList().Remove(benefitPackage);

                // For production
                //dbContext.SaveChanges();

                await benefitPackageGrid.Reload();
            }
            else
            {
                benefitPackageGrid.CancelEditRow(benefitPackage);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            benefitPackageToInsert = new BenefitPackagesVM();
            await benefitPackageGrid.InsertRow(benefitPackageToInsert);

        }

        async Task OnCreateRow(BenefitPackagesVM benefitPackages)
        {
            // dbContext.Add(order);
            await _benefitPackagesService.SaveBenefitPackages(benefitPackages);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
