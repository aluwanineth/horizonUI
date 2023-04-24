using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class BenefitType
    {
        RadzenDataGrid<BenefitTypeVM> benefittypesGrid = null;
        BenefitTypeVM benefittypeToInsert = null;
        public IEnumerable<BenefitTypeVM> benefittypes = new List<BenefitTypeVM>();
        bool enable = true;


        protected override async Task OnInitializedAsync()
        {

            benefittypes = await _benefitTypeService.GetBenefitTypes();

        }
        public async Task Export(string type)
        {
            await _exportService.ExportData<BenefitTypeVM>(benefittypesGrid, type, "BenefitType", "BenefitTypes");
        }

        async Task EditRow(BenefitTypeVM benefittype)
        {
            await benefittypesGrid.EditRow(benefittype);
        }

        async void OnUpdateRow(BenefitTypeVM benefittype)
        {
            if (benefittype == benefittypeToInsert)
            {
                benefittypeToInsert = null;
            }


            await _benefitTypeService.UpdateBenefitType(benefittype);

        }

        async Task SaveRow(BenefitTypeVM benefittype)
        {
            if (benefittype == benefittypeToInsert)
            {
                benefittypeToInsert = null;
            }

            await benefittypesGrid.UpdateRow(benefittype);
        }

        void CancelEdit(BenefitTypeVM benefittype)
        {
            if (benefittype == benefittypeToInsert)
            {
                benefittypeToInsert = null;
            }

            benefittypesGrid.CancelEditRow(benefittype);

        }

        async Task DeleteRow(BenefitTypeVM benefittype)
        {
            if (benefittype == benefittypeToInsert)
            {
                benefittypeToInsert = null;
            }

            if (benefittypes.Contains(benefittype))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                benefittypes.ToList().Remove(benefittype);

                // For production
                //dbContext.SaveChanges();

                await benefittypesGrid.Reload();
            }
            else
            {
                benefittypesGrid.CancelEditRow(benefittype);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            benefittypeToInsert = new BenefitTypeVM();
            await benefittypesGrid.InsertRow(benefittypeToInsert);

        }

        async Task OnCreateRow(BenefitTypeVM benefittype)
        {
            // dbContext.Add(order);
            await _benefitTypeService.SaveBenefitType(benefittype);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
