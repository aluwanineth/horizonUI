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
    public partial class ValidateStructure
    {
        RadzenDataGrid<ValidateStructureVM> validateStructureGrid = null;
        ValidateStructureVM validateStructureToInsert = null;
        public IEnumerable<ValidateStructureVM> validateStructures = new List<ValidateStructureVM>();
        bool enable = true;
        public IEnumerable<LevelVM> levelLookup;
        public IEnumerable<TableVM> tableLookup;
        public IEnumerable<DataArtefactVM> dataartefactLookup;


        protected override async Task OnInitializedAsync()
        {

            validateStructures = await _validateStructureService.GetValidateStructure();
            levelLookup = await _levelService.GetLevels();
            tableLookup = await _tablesService.GetTable();
            dataartefactLookup = await _dataartefactService.GetDataArtefacts();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<ValidateStructureVM>(validateStructureGrid, type, "ValidateStructure", "ValidateStructures");
        }

        async Task EditRow(ValidateStructureVM validateStructure)
        {
            await validateStructureGrid.EditRow(validateStructure);
        }

        async void OnUpdateRow(ValidateStructureVM validateStructure)
        {
            if (validateStructure == validateStructureToInsert)
            {
                validateStructureToInsert = null;
            }


            await _validateStructureService.UpdateValidateStructure(validateStructure);

        }

        async Task SaveRow(ValidateStructureVM validateStructure)
        {
            if (validateStructure == validateStructureToInsert)
            {
                validateStructureToInsert = null;
            }

            await validateStructureGrid.UpdateRow(validateStructure);
        }

        void CancelEdit(ValidateStructureVM validateStructure)
        {
            if (validateStructure == validateStructureToInsert)
            {
                validateStructureToInsert = null;
            }

            validateStructureGrid.CancelEditRow(validateStructure);

        }

        async Task DeleteRow(ValidateStructureVM validateStructure)
        {
            if (validateStructure == validateStructureToInsert)
            {
                validateStructureToInsert = null;
            }

            if (validateStructures.Contains(validateStructure))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                validateStructures.ToList().Remove(validateStructure);

                // For production
                //dbContext.SaveChanges();

                await validateStructureGrid.Reload();
            }
            else
            {
                validateStructureGrid.CancelEditRow(validateStructure);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            validateStructureToInsert = new ValidateStructureVM();
            await validateStructureGrid.InsertRow(validateStructureToInsert);

        }

        async Task OnCreateRow(ValidateStructureVM validateStructure)
        {
            // dbContext.Add(order);
            await _validateStructureService.SaveValidateStructure(validateStructure);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
