using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class Partner
    {
        RadzenDataGrid<PartnerVM> partnerGrid = null;
        PartnerVM partnerToInsert = null;
        public IEnumerable<PartnerVM> partners = new List<PartnerVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            partners = await _partnerService.GetPartners();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<PartnerVM>(partnerGrid, type, "Partner", "Partners");
        }



        async Task EditRow(PartnerVM partner)
        {
            await partnerGrid.EditRow(partner);
        }

        async void OnUpdateRow(PartnerVM partner)
        {
            if (partner == partnerToInsert)
            {
                partnerToInsert = null;
            }


            await _partnerService.UpdatePartner(partner);

        }

        async Task SaveRow(PartnerVM partner)
        {
            if (partner == partnerToInsert)
            {
                partnerToInsert = null;
            }

            await partnerGrid.UpdateRow(partner);
        }

        void CancelEdit(PartnerVM partner)
        {
            if (partner == partnerToInsert)
            {
                partnerToInsert = null;
            }

            partnerGrid.CancelEditRow(partner);

        }

        async Task DeleteRow(PartnerVM partner)
        {
            if (partner == partnerToInsert)
            {
                partnerToInsert = null;
            }

            if (partners.Contains(partner))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                partners.ToList().Remove(partner);

                // For production
                //dbContext.SaveChanges();

                await partnerGrid.Reload();
            }
            else
            {
                partnerGrid.CancelEditRow(partner);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            partnerToInsert = new PartnerVM();
            await partnerGrid.InsertRow(partnerToInsert);

        }

        async Task OnCreateRow(PartnerVM partner)
        {
            // dbContext.Add(order);
            await _partnerService.SavePartner(partner);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
