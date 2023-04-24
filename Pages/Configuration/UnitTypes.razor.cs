using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using HorizonPollyC.Services.General;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;


namespace HorizonPollyC.Pages.Configuration
{
    partial class UnitTypes
    {

        RadzenDataGrid<UnitTypesVM> modelGrid = null;
        UnitTypesVM modelToInsert = null;
        public IEnumerable<UnitTypesVM> modelList = new List<UnitTypesVM>();
        bool enable = true;

        protected override async Task OnInitializedAsync()
        {
            modelList = await _genericService.Get();
        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<UnitTypesVM>(modelGrid, type, "UnitTypes", "UnitTypes");
        }

        async Task EditRow(UnitTypesVM pModel)
        {
            await modelGrid.EditRow(pModel);
        }

        async void OnUpdateRow(UnitTypesVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await _genericService.Update(pModel);
        }

        async Task SaveRow(UnitTypesVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await modelGrid.UpdateRow(pModel);
        }

        void CancelEdit(UnitTypesVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }
            modelGrid.CancelEditRow(pModel);

        }

        async Task DeleteRow(UnitTypesVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            if (modelList.Contains(pModel))
            {
                modelList.ToList().Remove(pModel);
                await modelGrid.Reload();
            }
            else
            {
                modelGrid.CancelEditRow(pModel);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            modelToInsert = new UnitTypesVM();
            await modelGrid.InsertRow(modelToInsert);

        }

        async Task OnCreateRow(UnitTypesVM pModel)
        {
            await _genericService.Update(pModel);
        }
    }

}
