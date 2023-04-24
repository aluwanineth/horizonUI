using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class LegacyPayment
    {
        RadzenDataGrid<LegacyPaymentVM> legacypaymentGrid = null;
        LegacyPaymentVM legacypaymentToInsert = null;
        public IEnumerable<LegacyPaymentVM> legacypayments = new List<LegacyPaymentVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            legacypayments = await _legacypaymentService.GetLegacyPayments();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<LegacyPaymentVM>(legacypaymentGrid, type, "LegacyPayment", "LegacyPayments");
        }


        async Task EditRow(LegacyPaymentVM legacypayment)
        {
            await legacypaymentGrid.EditRow(legacypayment);
        }

        async void OnUpdateRow(LegacyPaymentVM legacypayment)
        {
            if (legacypayment == legacypaymentToInsert)
            {
                legacypaymentToInsert = null;
            }


            await _legacypaymentService.UpdateLegacyPayment(legacypayment);

        }

        async Task SaveRow(LegacyPaymentVM legacypayment)
        {

            if (legacypayment == legacypaymentToInsert)
            {
                legacypaymentToInsert = null;
            }

            await legacypaymentGrid.UpdateRow(legacypayment);
        }

        void CancelEdit(LegacyPaymentVM legacypayment)
        {
            if (legacypayment == legacypaymentToInsert)
            {
                legacypaymentToInsert = null;
            }

            legacypaymentGrid.CancelEditRow(legacypayment);

        }

        async Task DeleteRow(LegacyPaymentVM legacypayment)
        {
            if (legacypayment == legacypaymentToInsert)
            {
                legacypaymentToInsert = null;
            }

            if (legacypayments.Contains(legacypayment))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                legacypayments.ToList().Remove(legacypayment);

                // For production
                //dbContext.SaveChanges();

                await legacypaymentGrid.Reload();
            }
            else
            {
                legacypaymentGrid.CancelEditRow(legacypayment);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            legacypaymentToInsert = new LegacyPaymentVM();
            await legacypaymentGrid.InsertRow(legacypaymentToInsert);

        }

        async Task OnCreateRow(LegacyPaymentVM legacypayment)
        {
            // dbContext.Add(order);
            await _legacypaymentService.SaveLegacyPayment(legacypayment);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
