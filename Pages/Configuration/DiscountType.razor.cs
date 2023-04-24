using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class DiscountType
    {
        RadzenDataGrid<DiscountTypeVM> discounttypeGrid = null;
        DiscountTypeVM discounttypeToInsert = null;
        public IEnumerable<DiscountTypeVM> discounttypes = new List<DiscountTypeVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            discounttypes = await _discounttypeService.GetDiscountTypes();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<DiscountTypeVM>(discounttypeGrid, type, "DiscountType", "DiscountTypes");
        }

        async Task EditRow(DiscountTypeVM discounttype)
        {
            await discounttypeGrid.EditRow( discounttype);
        }

        async void OnUpdateRow(DiscountTypeVM discounttype)
        {
            if (discounttype == discounttypeToInsert)
            {
                discounttypeToInsert = null;
            }


            await _discounttypeService.UpdateDiscountType(discounttype);

        }

        async Task SaveRow(DiscountTypeVM discounttype)
        {

            if (discounttype == discounttypeToInsert)
            {
                discounttypeToInsert = null;
            }

            await discounttypeGrid.UpdateRow(discounttype);
        }

        void CancelEdit(DiscountTypeVM discounttype)
        {
            if (discounttype == discounttypeToInsert)
            {
                discounttypeToInsert = null;
            }

            discounttypeGrid.CancelEditRow(discounttype);

        }

        async Task DeleteRow(DiscountTypeVM discounttype)
        {
            if (discounttype == discounttypeToInsert)
            {
                discounttypeToInsert = null;
            }

            if (discounttypes.Contains(discounttype))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                discounttypes.ToList().Remove(discounttype);

                // For production
                //dbContext.SaveChanges();

                await discounttypeGrid.Reload();
            }
            else
            {
                discounttypeGrid.CancelEditRow(discounttype);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            discounttypeToInsert = new DiscountTypeVM();
            await discounttypeGrid.InsertRow(discounttypeToInsert);

        }

        async Task OnCreateRow(DiscountTypeVM discounttype)
        {
            // dbContext.Add(order);
            await _discounttypeService.SaveDiscountType(discounttype);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
