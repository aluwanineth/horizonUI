using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using HorizonPollyC.Services.General;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
using System.Linq;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class SchemePlanFactors
    {
        RadzenDataGrid<SchemePlanFactorsVM> schemePlanFactorsGrid = null;
        SchemePlanFactorsVM schemePlanFactorsToInsert = null;
        public IEnumerable<SchemePlanFactorsVM> schemePlanFactors = new List<SchemePlanFactorsVM>();
        bool enable = true;


        protected override async Task OnInitializedAsync()
        {

            schemePlanFactors = await _schemePlanFactorsService.GetSchemePlanFactors();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<SchemePlanFactorsVM>(schemePlanFactorsGrid, type, "SchemePlanFactors", "SchemePlanFactors");
        }


        async Task EditRow(SchemePlanFactorsVM schemePlanFactor)
        {
            await schemePlanFactorsGrid.EditRow(schemePlanFactor);
        }

        async void OnUpdateRow(SchemePlanFactorsVM schemePlanFactor)
        {
            if (schemePlanFactor == schemePlanFactorsToInsert)
            {
                schemePlanFactorsToInsert = null;
            }


            await _schemePlanFactorsService.UpdateSchemePlanFactors(schemePlanFactor);

        }

        async Task SaveRow(SchemePlanFactorsVM schemePlanFactor)
        {
            if (schemePlanFactor == schemePlanFactorsToInsert)
            {
                schemePlanFactorsToInsert = null;
            }

            await schemePlanFactorsGrid.UpdateRow(schemePlanFactor);
        }

        void CancelEdit(SchemePlanFactorsVM schemePlanFactor)
        {
            if (schemePlanFactor == schemePlanFactorsToInsert)
            {
                schemePlanFactorsToInsert = null;
            }

            schemePlanFactorsGrid.CancelEditRow(schemePlanFactor);

        }

        async Task DeleteRow(SchemePlanFactorsVM schemePlanFactor)
        {
            if (schemePlanFactor == schemePlanFactorsToInsert)
            {
                schemePlanFactorsToInsert = null;
            }

            if (schemePlanFactors.Contains(schemePlanFactor))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                schemePlanFactors.ToList().Remove(schemePlanFactor);

                // For production
                //dbContext.SaveChanges();

                await schemePlanFactorsGrid.Reload();
            }
            else
            {
                schemePlanFactorsGrid.CancelEditRow(schemePlanFactor);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            schemePlanFactorsToInsert = new SchemePlanFactorsVM();
            await schemePlanFactorsGrid.InsertRow(schemePlanFactorsToInsert);

        }

        async Task OnCreateRow(SchemePlanFactorsVM schemePlanFactor)
        {
            // dbContext.Add(order);
            await _schemePlanFactorsService.SaveSchemePlanFactors(schemePlanFactor);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
