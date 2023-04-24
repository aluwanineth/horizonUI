using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class PremiumPortionType
    {
        RadzenDataGrid<PremiumPortionTypeVM> premiumportiontypeGrid = null;
        PremiumPortionTypeVM premiumportiontypeToInsert = null;
        public IEnumerable<PremiumPortionTypeVM> premiumportiontypes = new List<PremiumPortionTypeVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            premiumportiontypes = await _premiumportionService.GetPremiumPortions();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<PremiumPortionTypeVM>(premiumportiontypeGrid, type, "PremiumPortionType", "PremiumPortionType");
        }


        async Task EditRow(PremiumPortionTypeVM Premiumportion)
        {
            await premiumportiontypeGrid.EditRow(Premiumportion);
        }

        async void OnUpdateRow(PremiumPortionTypeVM Premiumportion)
        {
            if (Premiumportion == premiumportiontypeToInsert)
            {
                premiumportiontypeToInsert = null;
            }


           await _premiumportionService.UpdatePremiumPortion(Premiumportion);

        }

        async Task SaveRow(PremiumPortionTypeVM Premiumportion)
        {
            if (Premiumportion == premiumportiontypeToInsert)
            {
                premiumportiontypeToInsert = null;
            }


            await premiumportiontypeGrid.UpdateRow(Premiumportion);
        }

        void CancelEdit(PremiumPortionTypeVM Premiumportion)
        {
            if (Premiumportion == premiumportiontypeToInsert)
            {
                premiumportiontypeToInsert = null;
            }

            premiumportiontypeGrid.CancelEditRow(Premiumportion);

        }

        async Task DeleteRow(PremiumPortionTypeVM Premiumportion)
        {
            if (Premiumportion == premiumportiontypeToInsert)
            {
                premiumportiontypeToInsert = null;
            }

            if (premiumportiontypes.Contains(Premiumportion))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                premiumportiontypes.ToList().Remove(Premiumportion);

                // For production
                //dbContext.SaveChanges();

                await premiumportiontypeGrid.Reload();
            }
            else
            {
                premiumportiontypeGrid.CancelEditRow(Premiumportion);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            premiumportiontypeToInsert = new PremiumPortionTypeVM();
            await premiumportiontypeGrid.InsertRow(premiumportiontypeToInsert);

        }

        async Task OnCreateRow(PremiumPortionTypeVM Premiumportion)
        {
            // dbContext.Add(order);
            await _premiumportionService.SavePremiumPortion(Premiumportion);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
