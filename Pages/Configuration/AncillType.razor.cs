using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class AncillType
    {
        RadzenDataGrid<AncilTypeVM> anciltypeGrid = null;
        AncilTypeVM anciltypeToInsert = null;
        public IEnumerable<AncilTypeVM> anciltypes = new List<AncilTypeVM>();
        bool enable = true;


        protected override async Task OnInitializedAsync()
        {

            anciltypes = await _ancilTypeService.GetAncilTypes();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<AncilTypeVM>(anciltypeGrid, type, "ancilltype", "ancilltypes");
        }

        async Task EditRow(AncilTypeVM anciltype)
        {
            await anciltypeGrid.EditRow(anciltype);
        }

        async void OnUpdateRow(AncilTypeVM anciltype)
        {
            if (anciltype == anciltypeToInsert)
            {
                anciltypeToInsert = null;
            }


            await _ancilTypeService.UpdateAnciltype(anciltype);

        }

        async Task SaveRow(AncilTypeVM anciltype)
        {
            if (anciltype == anciltypeToInsert)
            {
                anciltypeToInsert = null;
            }

            await anciltypeGrid.UpdateRow(anciltype);
        }

        void CancelEdit(AncilTypeVM anciltype)
        {
            if (anciltype == anciltypeToInsert)
            {
                anciltypeToInsert = null;
            }

            anciltypeGrid.CancelEditRow(anciltype);

        }

        async Task DeleteRow(AncilTypeVM anciltype)
        {
            if (anciltype == anciltypeToInsert)
            {
                anciltypeToInsert = null;
            }

            if (anciltypes.Contains(anciltype))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                anciltypes.ToList().Remove(anciltype);

                // For production
                //dbContext.SaveChanges();

                await anciltypeGrid.Reload();
            }
            else
            {
                anciltypeGrid.CancelEditRow(anciltype);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            anciltypeToInsert = new AncilTypeVM();
            await anciltypeGrid.InsertRow(anciltypeToInsert);

        }

        async Task OnCreateRow(AncilTypeVM anciltype)
        {
            // dbContext.Add(order);
            await _ancilTypeService.SaveAnciltype(anciltype);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
