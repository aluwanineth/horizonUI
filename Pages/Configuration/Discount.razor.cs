using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class Discount
    {
        RadzenDataGrid<DiscountVM> discountGrid = null;
        DiscountVM discountToInsert = null;
        public IEnumerable<DiscountVM> discounts = new List<DiscountVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            discounts = await _discountService.GetDiscounts();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<DiscountVM>(discountGrid, type, "Discount", "Discounts");
        }

        async Task EditRow(DiscountVM discount)
        {
            await discountGrid.EditRow(discount);
        }

        async void OnUpdateRow(DiscountVM discount)
        {
            if (discount == discountToInsert)
            {
                discountToInsert = null;
            }


            await _discountService.UpdateDiscount(discount);

        }

        async Task SaveRow(DiscountVM discount)
        {

            if (discount == discountToInsert)
            {
                discountToInsert = null;
            }

            await discountGrid.UpdateRow(discount);
        }

        void CancelEdit(DiscountVM discount)
        {
            if (discount == discountToInsert)
            {
                discountToInsert = null;
            }

            discountGrid.CancelEditRow(discount);

        }

        async Task DeleteRow(DiscountVM discount)
        {
            if (discount == discountToInsert)
            {
                discountToInsert = null;
            }

            if (discounts.Contains(discount))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                discounts.ToList().Remove(discount);

                // For production
                //dbContext.SaveChanges();

                await discountGrid.Reload();
            }
            else
            {
                discountGrid.CancelEditRow(discount);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            discountToInsert = new DiscountVM();
            await discountGrid.InsertRow(discountToInsert);

        }

        async Task OnCreateRow(DiscountVM discount)
        {
            // dbContext.Add(order);
            await _discountService.SaveDiscount(discount);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
