using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class Movement
    {
        RadzenDataGrid<MovementVM> movementGrid = null;
        MovementVM movementToInsert = null;
        public IEnumerable<MovementVM> movements = new List<MovementVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            movements = await _movementService.GetMovements();

        }
        public async Task Export(string type)
        {
            await _exportService.ExportData<MovementVM>(movementGrid, type, "Movement", "Movements");
        }


        async Task EditRow(MovementVM movement)
        {
            await movementGrid.EditRow(movement);
        }

        async void OnUpdateRow(MovementVM movement)
        {
            if (movement == movementToInsert)
            {
                movementToInsert = null;
            }


            await _movementService.UpdateMovement(movement);

        }

        async Task SaveRow(MovementVM movement)
        {
            if (movement == movementToInsert)
            {
                movementToInsert = null;
            }

            await movementGrid.UpdateRow(movement);
        }

        void CancelEdit(MovementVM movement)
        {
            if (movement == movementToInsert)
            {
                movementToInsert = null;
            }

            movementGrid.CancelEditRow(movement);

        }

        async Task DeleteRow(MovementVM movement)
        {
            if (movement == movementToInsert)
            {
                movementToInsert = null;
            }

            if (movements.Contains(movement))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                movements.ToList().Remove(movement);

                // For production
                //dbContext.SaveChanges();

                await movementGrid.Reload();
            }
            else
            {
                movementGrid.CancelEditRow(movement);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            movementToInsert = new MovementVM();
            await movementGrid.InsertRow(movementToInsert);

        }

        async Task OnCreateRow(MovementVM movement)
        {
            // dbContext.Add(order);
            await _movementService.SaveMovement(movement);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
