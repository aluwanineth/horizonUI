using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class EntityType
    {
        RadzenDataGrid<EntityTypeVM> entitytypeGrid = null;
        EntityTypeVM entitytypeToInsert = null;
        public IEnumerable<EntityTypeVM> entitytypes = new List<EntityTypeVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            entitytypes = await _entitytypeService.GetEntityTypes();

        }
        public async Task Export(string type)
        {
            await _exportService.ExportData<EntityTypeVM>(entitytypeGrid, type, "EntityType", "EntityTypes");
        }


        async Task EditRow(EntityTypeVM entitytype)
        {
            await entitytypeGrid.EditRow(entitytype);
        }

        async void OnUpdateRow(EntityTypeVM entitytype)
        {
            if (entitytype == entitytypeToInsert)
            {
                entitytypeToInsert = null;
            }


            await _entitytypeService.UpdateEntityType(entitytype);

        }

        async Task SaveRow(EntityTypeVM entitytype)
        {

            if (entitytype == entitytypeToInsert)
            {
                entitytypeToInsert = null;
            }

            await entitytypeGrid.UpdateRow(entitytype);
        }

        void CancelEdit(EntityTypeVM entitytype)
        {
            if (entitytype == entitytypeToInsert)
            {
                entitytypeToInsert = null;
            }

            entitytypeGrid.CancelEditRow(entitytype);

        }

        async Task DeleteRow(EntityTypeVM entitytype)
        {
            if (entitytype == entitytypeToInsert)
            {
                entitytypeToInsert = null;
            }

            if (entitytypes.Contains(entitytype))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                entitytypes.ToList().Remove(entitytype);

                // For production
                //dbContext.SaveChanges();

                await entitytypeGrid.Reload();
            }
            else
            {
                entitytypeGrid.CancelEditRow(entitytype);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            entitytypeToInsert = new EntityTypeVM();
            await entitytypeGrid.InsertRow(entitytypeToInsert);

        }

        async Task OnCreateRow(EntityTypeVM entitytype)
        {
            // dbContext.Add(order);
            await _entitytypeService.SaveEntityType(entitytype);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
