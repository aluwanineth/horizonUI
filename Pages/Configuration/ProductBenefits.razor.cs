using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class ProductBenefits
    {
        RadzenDataGrid<ProductBenefitsVM> productBenefitsGrid = null;
        ProductBenefitsVM productBenefitsToInsert = null;
        public IEnumerable<ProductBenefitsVM> productBenefits = new List<ProductBenefitsVM>();
        bool enable = true;
        public IEnumerable<ProductLineVM> productlineLookup;
        public IEnumerable<BenefitTypeVM> benefittypeLookup;



        protected override async Task OnInitializedAsync()
        {

            productBenefits = await _productBenefitsService.GetProductBenefits();
            productlineLookup = await _productlineService.Get();
            benefittypeLookup = await _benefitTypeService.GetBenefitTypes();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<ProductBenefitsVM>(productBenefitsGrid, type, "ProductBenefits", "ProductBenefits");
        }


        async Task EditRow(ProductBenefitsVM productBenefit)
        {
            await productBenefitsGrid.EditRow(productBenefit);
        }

        async void OnUpdateRow(ProductBenefitsVM productBenefit)
        {
            if (productBenefit == productBenefitsToInsert)
            {
                productBenefitsToInsert = null;
            }


            await _productBenefitsService.UpdateProductBenefits(productBenefit);

        }

        async Task SaveRow(ProductBenefitsVM productBenefit)
        {
            if (productBenefit == productBenefitsToInsert)
            {
                productBenefitsToInsert = null;
            }

            await productBenefitsGrid.UpdateRow(productBenefit);
        }

        void CancelEdit(ProductBenefitsVM productBenefit)
        {
            if (productBenefit == productBenefitsToInsert)
            {
                productBenefitsToInsert = null;
            }

            productBenefitsGrid.CancelEditRow(productBenefit);

        }

        async Task DeleteRow(ProductBenefitsVM productBenefit)
        {
            if (productBenefit == productBenefitsToInsert)
            {
                productBenefitsToInsert = null;
            }

            if (productBenefits.Contains(productBenefit))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                productBenefits.ToList().Remove(productBenefit);

                // For production
                //dbContext.SaveChanges();

                await productBenefitsGrid.Reload();
            }
            else
            {
                productBenefitsGrid.CancelEditRow(productBenefit);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            productBenefitsToInsert = new ProductBenefitsVM();
            await productBenefitsGrid.InsertRow(productBenefitsToInsert);

        }

        async Task OnCreateRow(ProductBenefitsVM productBenefit)
        {
            // dbContext.Add(order);
            await _productBenefitsService.SaveProductBenefits(productBenefit);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
