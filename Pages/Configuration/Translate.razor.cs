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
    partial class Translate
    {
        RadzenDataGrid<TranslateVM> modelGrid = null;
        TranslateVM modelToInsert = null;
        public IEnumerable<TranslateVM> modelList = new List<TranslateVM>();
        bool enable = true;

        protected override async Task OnInitializedAsync()
        {
            modelList = await _genericService.Get();
        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<TranslateVM>(modelGrid, type, "Translate", "Translate");
        }
        async Task EditRow(TranslateVM pModel)
        {
            await modelGrid.EditRow(pModel);
        }

        async void OnUpdateRow(TranslateVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await _genericService.Update(pModel);
        }

        async Task SaveRow(TranslateVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await modelGrid.UpdateRow(pModel);
        }

        void CancelEdit(TranslateVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }
            modelGrid.CancelEditRow(pModel);

        }

        async Task DeleteRow(TranslateVM pModel)
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
            modelToInsert = new TranslateVM();
            await modelGrid.InsertRow(modelToInsert);

        }

        async Task OnCreateRow(TranslateVM pModel)
        {
            await _genericService.Update(pModel);
        }
    }
}
