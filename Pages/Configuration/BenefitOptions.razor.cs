using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using HorizonPollyC.Services.General;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MoreLinq;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class BenefitOptions
    {
        RadzenDataGrid<BenefitOptionsVM> benefitOptionsGrid = null;
        BenefitOptionsVM benefitOptionsToInsert = null;
        public IEnumerable<BenefitOptionsVM> benefitOptions = new List<BenefitOptionsVM>();
        public IEnumerable<BenefitTypeVM> benefitTypeLookup;
        public IEnumerable<BenefitOptionVM> benefitOptionLookup;




      bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IBenefitOptionsService _benefitOptionsService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            benefitOptions = await _benefitOptionsService.GetBenefitOptions();
            benefitTypeLookup = await _benefitTypeService.GetBenefitTypes();
            benefitOptionLookup = await _benefitOptionService.GetBenefitOptions();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<BenefitOptionsVM>(benefitOptionsGrid, type, "BenefitOptions", "BenefitOptions");
        }


        async Task EditRow(BenefitOptionsVM benefitOption)
        {
            await benefitOptionsGrid.EditRow(benefitOption);
        }

        async void OnUpdateRow(BenefitOptionsVM benefitOption)
        {
            if (benefitOption == benefitOptionsToInsert)
            {
                benefitOptionsToInsert = null;
            }


            await _benefitOptionsService.UpdateBenefitOptions(benefitOption);

        }

        async Task SaveRow(BenefitOptionsVM benefitOption)
        {
            if (benefitOption == benefitOptionsToInsert)
            {
                benefitOptionsToInsert = null;
            }

            await benefitOptionsGrid.UpdateRow(benefitOption);
        }

        void CancelEdit(BenefitOptionsVM benefitOption)
        {
            if (benefitOption == benefitOptionsToInsert)
            {
                benefitOptionsToInsert = null;
            }

            benefitOptionsGrid.CancelEditRow(benefitOption);

        }

        async Task DeleteRow(BenefitOptionsVM benefitOption)
        {
            if (benefitOption == benefitOptionsToInsert)
            {
                benefitOptionsToInsert = null;
            }

            if (benefitOptions.Contains(benefitOption))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                benefitOptions.ToList().Remove(benefitOption);

                // For production
                //dbContext.SaveChanges();

                await benefitOptionsGrid.Reload();
            }
            else
            {
                benefitOptionsGrid.CancelEditRow(benefitOption);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            benefitOptionsToInsert = new BenefitOptionsVM();
            await benefitOptionsGrid.InsertRow(benefitOptionsToInsert);

        }

        async Task OnCreateRow(BenefitOptionsVM benefitOptions)
        {
            // dbContext.Add(order);
            await _benefitOptionsService.SaveBenefitOptions(benefitOptions);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
