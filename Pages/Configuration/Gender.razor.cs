using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class Gender
    {
        RadzenDataGrid<GenderVM> genderGrid = null;
        GenderVM genderToInsert = null;
        public IEnumerable<GenderVM> genders = new List<GenderVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            genders = await _genderService.GetGenders();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<GenderVM>(genderGrid, type, "Gender", "Genders");
        }


        async Task EditRow(GenderVM gender)
        {
            await genderGrid.EditRow(gender);
        }

        async void OnUpdateRow(GenderVM gender)
        {
            if (gender == genderToInsert)
            {
                genderToInsert = null;
            }


            await _genderService.UpdateGender(gender);

        }

        async Task SaveRow(GenderVM gender)
        {

            if (gender == genderToInsert)
            {
                genderToInsert = null;
            }

            await genderGrid.UpdateRow(gender);
        }

        void CancelEdit(GenderVM gender)
        {
            if (gender == genderToInsert)
            {
                genderToInsert = null;
            }

            genderGrid.CancelEditRow(gender);

        }

        async Task DeleteRow(GenderVM gender)
        {
            if (gender == genderToInsert)
            {
                genderToInsert = null;
            }

            if (genders.Contains(gender))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                genders.ToList().Remove(gender);

                // For production
                //dbContext.SaveChanges();

                await genderGrid.Reload();
            }
            else
            {
                genderGrid.CancelEditRow(gender);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            genderToInsert = new GenderVM();
            await genderGrid.InsertRow(genderToInsert);

        }

        async Task OnCreateRow(GenderVM gender)
        {
            // dbContext.Add(order);
            await _genderService.SaveGender(gender);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
