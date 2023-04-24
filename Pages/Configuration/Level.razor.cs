using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class Level
    {
        RadzenDataGrid<LevelVM> levelGrid = null;
        LevelVM levelToInsert = null;
        public IEnumerable<LevelVM> levels = new List<LevelVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            levels = await _levelService.GetLevels();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<LevelVM>(levelGrid, type, "Level", "Levels");
        }


        async Task EditRow(LevelVM level)
        {
            await levelGrid.EditRow(level);
        }

        async void OnUpdateRow(LevelVM level)
        {
            if (level == levelToInsert)
            {
                levelToInsert = null;
            }


            await _levelService.UpdateLevel(level);

        }

        async Task SaveRow(LevelVM level)
        {

            if (level == levelToInsert)
            {
                levelToInsert = null;
            }

            await levelGrid.UpdateRow(level);
        }

        void CancelEdit(LevelVM level)
        {
            if (level == levelToInsert)
            {
                levelToInsert = null;
            }

            levelGrid.CancelEditRow(level);

        }

        async Task DeleteRow(LevelVM level)
        {
            if (level == levelToInsert)
            {
                levelToInsert = null;
            }

            if (levels.Contains(level))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                levels.ToList().Remove(level);

                // For production
                //dbContext.SaveChanges();

                await levelGrid.Reload();
            }
            else
            {
                levelGrid.CancelEditRow(level);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            levelToInsert = new LevelVM();
            await levelGrid.InsertRow(levelToInsert);

        }

        async Task OnCreateRow(LevelVM level)
        {
            // dbContext.Add(order);
            await _levelService.SaveLevel(level);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
