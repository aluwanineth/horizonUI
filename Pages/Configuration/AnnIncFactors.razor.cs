using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using HorizonPollyC.Services.General;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class AnnIncFactors
    {
        RadzenDataGrid<AnnIncFactorsVM> anincfactorsGrid = null;
        AnnIncFactorsVM anincfactorsToInsert = null;
        public IEnumerable<AnnIncFactorsVM> anincfactors = new List<AnnIncFactorsVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            anincfactors = await _annincfactorService.GetAnIncFactors();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<AnnIncFactorsVM>(anincfactorsGrid, type, "AnnIncFactors", "AnnIncFactors");
        }


        async Task EditRow(AnnIncFactorsVM anincfactor)
        {
            await anincfactorsGrid.EditRow(anincfactor);
        }

        async void OnUpdateRow(AnnIncFactorsVM anincfactor)
        {
            if (anincfactor == anincfactorsToInsert)
            {
                anincfactorsToInsert = null;
            }


            await _annincfactorService.UpdateAnIncFactors(anincfactor);

        }

        async Task SaveRow(AnnIncFactorsVM anincfactor)
        {
            if (anincfactor == anincfactorsToInsert)
            {
                anincfactorsToInsert = null;
            }

            await anincfactorsGrid.UpdateRow(anincfactor);
        }

        void CancelEdit(AnnIncFactorsVM anincfactor)
        {
            if (anincfactor == anincfactorsToInsert)
            {
                anincfactorsToInsert = null;
            }

            anincfactorsGrid.CancelEditRow(anincfactor);

        }

        async Task DeleteRow(AnnIncFactorsVM anincfactor)
        {
            if (anincfactor == anincfactorsToInsert)
            {
                anincfactorsToInsert = null;
            }

            if (anincfactors.Contains(anincfactor))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                anincfactors.ToList().Remove(anincfactor);

                // For production
                //dbContext.SaveChanges();

                await anincfactorsGrid.Reload();
            }
            else
            {
                anincfactorsGrid.CancelEditRow(anincfactor);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            anincfactorsToInsert = new AnnIncFactorsVM();
            await anincfactorsGrid.InsertRow(anincfactorsToInsert);

        }

        async Task OnCreateRow(AnnIncFactorsVM anincfactor)
        {
            // dbContext.Add(order);
            await _annincfactorService.SaveAnIncFactors(anincfactor);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
