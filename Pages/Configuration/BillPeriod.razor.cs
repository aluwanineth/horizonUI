using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class BillPeriod
    {
        RadzenDataGrid<BillPeriodVM> billperiodsGrid = null;
        BillPeriodVM billperiodToInsert = null;
        public IEnumerable<BillPeriodVM> billperiods = new List<BillPeriodVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            billperiods = await _billPeriodService.GetBillPeriods();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<BillPeriodVM>(billperiodsGrid, type, "BillPeriod", "BillPeriods");
        }

        async Task EditRow(BillPeriodVM billperiod)
        {
            await billperiodsGrid.EditRow(billperiod);
        }

        async void OnUpdateRow(BillPeriodVM billperiod)
        {
            if (billperiod == billperiodToInsert)
            {
                billperiodToInsert = null;
            }


            await _billPeriodService.UpdateBillPeriod(billperiod);

        }

        async Task SaveRow(BillPeriodVM billperiod)
        {
            if (billperiod == billperiodToInsert)
            {
                billperiodToInsert = null;
            }

            await billperiodsGrid.UpdateRow(billperiod);
        }

        void CancelEdit(BillPeriodVM billperiod)
        {
            if (billperiod == billperiodToInsert)
            {
                billperiodToInsert = null;
            }

            billperiodsGrid.CancelEditRow(billperiod);

        }

        async Task DeleteRow(BillPeriodVM billperiod)
        {
            if (billperiod == billperiodToInsert)
            {
                billperiodToInsert = null;
            }

            if (billperiods.Contains(billperiod))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                billperiods.ToList().Remove(billperiod);

                // For production
                //dbContext.SaveChanges();

                await billperiodsGrid.Reload();
            }
            else
            {
                billperiodsGrid.CancelEditRow(billperiod);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            billperiodToInsert = new BillPeriodVM();
            await billperiodsGrid.InsertRow(billperiodToInsert);

        }

        async Task OnCreateRow(BillPeriodVM billperiod)
        {
            // dbContext.Add(order);
            await _billPeriodService.SaveBillPeriod(billperiod);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
