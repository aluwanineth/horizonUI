using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class EntryAge
    {
        RadzenDataGrid<EntryAgeVM> entryAgeGrid = null;
        EntryAgeVM entryAgeToInsert = null;
        public IEnumerable<EntryAgeVM> entryAges = new List<EntryAgeVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            entryAges = await _entryAgeService.GetEntryAges();

        }
        public async Task Export(string type)
        {
            await _exportService.ExportData<EntryAgeVM>(entryAgeGrid, type, "EntryAge", "EntryAges");
        }


        async Task EditRow(EntryAgeVM entryage)
        {
            await entryAgeGrid.EditRow(entryage);
        }

        async void OnUpdateRow(EntryAgeVM entryage)
        {
            if (entryage == entryAgeToInsert)
            {
                entryAgeToInsert = null;
            }


            await _entryAgeService.UpdateEntryAge(entryage);

        }

        async Task SaveRow(EntryAgeVM entryage)
        {

            if (entryage == entryAgeToInsert)
            {
                entryAgeToInsert = null;
            }

            await entryAgeGrid.UpdateRow(entryage);
        }

        void CancelEdit(EntryAgeVM entryage)
        {
            if (entryage == entryAgeToInsert)
            {
                entryAgeToInsert = null;
            }

            entryAgeGrid.CancelEditRow(entryage);

        }

        async Task DeleteRow(EntryAgeVM entryage)
        {
            if (entryage == entryAgeToInsert)
            {
                entryAgeToInsert = null;
            }

            if (entryAges.Contains(entryage))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                entryAges.ToList().Remove(entryage);

                // For production
                //dbContext.SaveChanges();

                await entryAgeGrid.Reload();
            }
            else
            {
                entryAgeGrid.CancelEditRow(entryage);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            entryAgeToInsert = new EntryAgeVM();
            await entryAgeGrid.InsertRow(entryAgeToInsert);

        }

        async Task OnCreateRow(EntryAgeVM entryage)
        {
            // dbContext.Add(order);
            await _entryAgeService.SaveEntryAge(entryage);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
