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
    public partial class ChannelBenTypes
    {
        RadzenDataGrid<ChannelBenTypesVM> channelBenTypesGrid = null;
        ChannelBenTypesVM channelBenTypesToInsert = null;
        public IEnumerable<ChannelBenTypesVM> channelBenTypes = new List<ChannelBenTypesVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            channelBenTypes = await _channelBenTypesService.GetChannelBenTypes();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<ChannelBenTypesVM>(channelBenTypesGrid, type, "ChannelBenTypes", "ChannelBenTypes");
        }


        async Task EditRow(ChannelBenTypesVM channelBenType)
        {
            await channelBenTypesGrid.EditRow(channelBenType);
        }

        async void OnUpdateRow(ChannelBenTypesVM channelBenType)
        {
            if (channelBenType == channelBenTypesToInsert)
            {
                channelBenTypesToInsert = null;
            }


            await _channelBenTypesService.UpdateChannelBenTypes(channelBenType);

        }

        async Task SaveRow(ChannelBenTypesVM channelBenType)
        {
            if (channelBenType == channelBenTypesToInsert)
            {
                channelBenTypesToInsert = null;
            }

            await channelBenTypesGrid.UpdateRow(channelBenType);
        }

        void CancelEdit(ChannelBenTypesVM channelBenType)
        {
            if (channelBenType == channelBenTypesToInsert)
            {
                channelBenTypesToInsert = null;
            }

            channelBenTypesGrid.CancelEditRow(channelBenType);

        }

        async Task DeleteRow(ChannelBenTypesVM channelBenType)
        {
            if (channelBenType == channelBenTypesToInsert)
            {
                channelBenTypesToInsert = null;
            }

            if (channelBenTypes.Contains(channelBenType))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                channelBenTypes.ToList().Remove(channelBenType);

                // For production
                //dbContext.SaveChanges();

                await channelBenTypesGrid.Reload();
            }
            else
            {
                channelBenTypesGrid.CancelEditRow(channelBenType);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            channelBenTypesToInsert = new ChannelBenTypesVM();
            await channelBenTypesGrid.InsertRow(channelBenTypesToInsert);

        }

        async Task OnCreateRow(ChannelBenTypesVM channel)
        {
            // dbContext.Add(order);
            await _channelBenTypesService.SaveChannelBenTypes(channel);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
