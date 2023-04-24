using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using HorizonPollyC.Services.General;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    partial class Title
    {

        RadzenDataGrid<TitlesVM> modelGrid = null;
        TitlesVM modelToInsert = null;
        public IEnumerable<TitlesVM> modelList = new List<TitlesVM>();
        bool enable = true;

        protected override async Task OnInitializedAsync()
        {
            modelList = await _genericService.Get();
        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<TitlesVM>(modelGrid, type, "Titles", "Titles");
        }
        async Task EditRow(TitlesVM pModel)
        {
            await modelGrid.EditRow(pModel);
        }

        async void OnUpdateRow(TitlesVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await _genericService.Update(pModel);
        }

        async Task SaveRow(TitlesVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await modelGrid.UpdateRow(pModel);
        }

        void CancelEdit(TitlesVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }
            modelGrid.CancelEditRow(pModel);

        }

        async Task DeleteRow(TitlesVM pModel)
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
            modelToInsert = new TitlesVM();
            await modelGrid.InsertRow(modelToInsert);

        }

        async Task OnCreateRow(TitlesVM pModel)
        {
            await _genericService.Update(pModel);
        }
    }
}
