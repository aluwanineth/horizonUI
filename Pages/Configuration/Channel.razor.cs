using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class Channel
    {
        RadzenDataGrid<ChannelVM> channelGrid = null;
        ChannelVM channelToInsert = null;
        public IEnumerable<ChannelVM> channels = new List<ChannelVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            channels = await _channelService.GetChannels();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<ChannelVM>(channelGrid, type, "Channel", "Channels");
        }


        async Task EditRow(ChannelVM channel)
        {
            await channelGrid.EditRow(channel);
        }

        async void OnUpdateRow(ChannelVM channel)
        {
            if (channel == channelToInsert)
            {
                channelToInsert = null;
            }


            await _channelService.UpdateChannel(channel);

        }

        async Task SaveRow(ChannelVM channel)
        {
            if (channel == channelToInsert)
            {
                channelToInsert = null;
            }

            await channelGrid.UpdateRow(channel);
        }

        void CancelEdit(ChannelVM channel)
        {
            if (channel == channelToInsert)
            {
                channelToInsert = null;
            }

            channelGrid.CancelEditRow(channel);

        }

        async Task DeleteRow(ChannelVM channel)
        {
            if (channel == channelToInsert)
            {
                channelToInsert = null;
            }

            if (channels.Contains(channel))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                channels.ToList().Remove(channel);

                // For production
                //dbContext.SaveChanges();

                await channelGrid.Reload();
            }
            else
            {
                channelGrid.CancelEditRow(channel);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            channelToInsert = new ChannelVM();
            await channelGrid.InsertRow(channelToInsert);

        }

        async Task OnCreateRow(ChannelVM channel)
        {
            // dbContext.Add(order);
            await _channelService.SaveChannel(channel);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
