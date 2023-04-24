using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class PaymentFrequency
    {
        RadzenDataGrid<PaymentFreqVM> paymentfrequencyGrid = null;
        PaymentFreqVM paymentfrequencyToInsert = null;
        public IEnumerable<PaymentFreqVM> paymentfrequencies = new List<PaymentFreqVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            paymentfrequencies = await _paymentfrequencyService.GetPaymentFreqs();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<PaymentFreqVM>(paymentfrequencyGrid, type, "PaymentFreq", "PaymentFreqs");
        }


        async Task EditRow(PaymentFreqVM paymentfrequency)
        {
            await paymentfrequencyGrid.EditRow(paymentfrequency);
        }

        async void OnUpdateRow(PaymentFreqVM paymentfrequency)
        {
            if (paymentfrequency == paymentfrequencyToInsert)
            {
                paymentfrequencyToInsert = null;
            }


            await _paymentfrequencyService.UpdatePaymentFreq (paymentfrequency);

        }

        async Task SaveRow(PaymentFreqVM paymentfrequency)
        {
            if (paymentfrequency == paymentfrequencyToInsert)
            {
                paymentfrequencyToInsert = null;
            }

            await paymentfrequencyGrid.UpdateRow(paymentfrequency);
        }

        void CancelEdit(PaymentFreqVM paymentfrequency)
        {
            if (paymentfrequency == paymentfrequencyToInsert)
            {
                paymentfrequencyToInsert = null;
            }

            paymentfrequencyGrid.CancelEditRow(paymentfrequency);

        }

        async Task DeleteRow(PaymentFreqVM paymentfrequency)
        {
            if (paymentfrequency == paymentfrequencyToInsert)
            {
                paymentfrequencyToInsert = null;
            }

            if (paymentfrequencies.Contains(paymentfrequency))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                paymentfrequencies.ToList().Remove(paymentfrequency);

                // For production
                //dbContext.SaveChanges();

                await paymentfrequencyGrid.Reload();
            }
            else
            {
                paymentfrequencyGrid.CancelEditRow(paymentfrequency);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            paymentfrequencyToInsert = new PaymentFreqVM();
            await paymentfrequencyGrid.InsertRow(paymentfrequencyToInsert);

        }

        async Task OnCreateRow(PaymentFreqVM paymentfrequency)
        {
            // dbContext.Add(order);
            await _paymentfrequencyService.SavePaymentFreq(paymentfrequency);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
