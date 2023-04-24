

using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using HorizonPollyC.Services.General;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    partial class TransactionType
    {

        RadzenDataGrid<TransactionTypesVM> modelGrid = null;
        TransactionTypesVM modelToInsert = null;
        public IEnumerable<TransactionTypesVM> modelList = new List<TransactionTypesVM>();
        bool enable = true;

        protected override async Task OnInitializedAsync()
        {
            modelList = await _genericService.Get();
        }
        public async Task Export(string type)
        {
            await _exportService.ExportData<TransactionTypesVM>(modelGrid, type, "TransactionType", "TransactionType");
        }
        async Task EditRow(TransactionTypesVM pModel)
        {
            await modelGrid.EditRow(pModel);
        }

        async void OnUpdateRow(TransactionTypesVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await _genericService.Update(pModel);
        }

        async Task SaveRow(TransactionTypesVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await modelGrid.UpdateRow(pModel);
        }

        void CancelEdit(TransactionTypesVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }
            modelGrid.CancelEditRow(pModel);

        }

        async Task DeleteRow(TransactionTypesVM pModel)
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
            modelToInsert = new TransactionTypesVM();
            await modelGrid.InsertRow(modelToInsert);

        }

        async Task OnCreateRow(TransactionTypesVM pModel)
        {
            await _genericService.Update(pModel);
        }
    }


}
