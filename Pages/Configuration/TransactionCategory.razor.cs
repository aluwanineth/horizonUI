using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using HorizonPollyC.Services.General;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;



namespace HorizonPollyC.Pages.Configuration
{
    partial class TransactionCategory
    {
        RadzenDataGrid<TransactionCategoriesVM> modelGrid = null;
        TransactionCategoriesVM modelToInsert = null;
        public IEnumerable<TransactionCategoriesVM> modelList = new List<TransactionCategoriesVM>();
        bool enable = true;

        protected override async Task OnInitializedAsync()
        {
            modelList = await _genericService.Get();
        }
        public async Task Export(string type)
        {
            await _exportService.ExportData<TransactionCategoriesVM>(modelGrid, type, "TransCategory", "TransactionCategory");
        }
        async Task EditRow(TransactionCategoriesVM pModel)
        {
            await modelGrid.EditRow(pModel);
        }

        async void OnUpdateRow(TransactionCategoriesVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await _genericService.Update(pModel);
        }

        async Task SaveRow(TransactionCategoriesVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await modelGrid.UpdateRow(pModel);
        }

        void CancelEdit(TransactionCategoriesVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }
            modelGrid.CancelEditRow(pModel);

        }

        async Task DeleteRow(TransactionCategoriesVM pModel)
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
            modelToInsert = new TransactionCategoriesVM();
            await modelGrid.InsertRow(modelToInsert);

        }

        async Task OnCreateRow(TransactionCategoriesVM pModel)
        {
            await _genericService.Update(pModel);
        }
    }
}
