using DocumentFormat.OpenXml.Wordprocessing;
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
    public partial class StatusReasons
    {
        RadzenDataGrid<StatusReasonsVM> statusReasonsGrid = null;
        StatusReasonsVM statusReasonsToInsert = null;
        public IEnumerable<StatusReasonsVM> statusReasons = new List<StatusReasonsVM>();
        bool enable = true;
        public IEnumerable<StatusVM> statusLookup;
        public IEnumerable<ReasonVM> reasonLookup;


        protected override async Task OnInitializedAsync()
        {

            statusReasons = await _statusReasonsService.GetStatusReasons();
            statusLookup = await _statusService.Get();
            reasonLookup = await _reasonService.Get();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<StatusReasonsVM>(statusReasonsGrid, type, "StatusReasons", "StatusReasons");
        }


        async Task EditRow(StatusReasonsVM statusReason)
        {
            await statusReasonsGrid.EditRow(statusReason);
        }

        async void OnUpdateRow(StatusReasonsVM statusReason)
        {
            if (statusReason == statusReasonsToInsert)
            {
                statusReasonsToInsert = null;
            }


            await _statusReasonsService.UpdateStatusReasons(statusReason);

        }

        async Task SaveRow(StatusReasonsVM statusReason)
        {
            if (statusReason == statusReasonsToInsert)
            {
                statusReasonsToInsert = null;
            }

            await statusReasonsGrid.UpdateRow(statusReason);
        }

        void CancelEdit(StatusReasonsVM statusReason)
        {
            if (statusReason == statusReasonsToInsert)
            {
                statusReasonsToInsert = null;
            }

            statusReasonsGrid.CancelEditRow(statusReason);

        }

        async Task DeleteRow(StatusReasonsVM statusReason)
        {
            if (statusReason == statusReasonsToInsert)
            {
                statusReasonsToInsert = null;
            }

            if (statusReasons.Contains(statusReason))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                statusReasons.ToList().Remove(statusReason);

                // For production
                //dbContext.SaveChanges();

                await statusReasonsGrid.Reload();
            }
            else
            {
                statusReasonsGrid.CancelEditRow(statusReason);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            statusReasonsToInsert = new StatusReasonsVM();
            await statusReasonsGrid.InsertRow(statusReasonsToInsert);

        }

        async Task OnCreateRow(StatusReasonsVM statusReason)
        {
            // dbContext.Add(order);
            await _statusReasonsService.SaveStatusReasons(statusReason);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
