using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using HorizonPollyC.Services.General;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;


namespace HorizonPollyC.Pages.Configuration
{
    partial class TakeOnOption
    {

        RadzenDataGrid<TakeOnOptionVM> modelGrid = null;
        TakeOnOptionVM modelToInsert = null;
        public IEnumerable<TakeOnOptionVM> modelList = new List<TakeOnOptionVM>();
        bool enable = true;

        protected override async Task OnInitializedAsync()
        {
            modelList = await _genericService.Get();
        }


        public async Task Export(string type)
        {
            await _exportService.ExportData<TakeOnOptionVM>(modelGrid, type, "TakeonOption", "TakeonOption");
        }
        async Task EditRow(TakeOnOptionVM pModel)
        {
            await modelGrid.EditRow(pModel);
        }

        async void OnUpdateRow(TakeOnOptionVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await _genericService.Update(pModel);
        }

        async Task SaveRow(TakeOnOptionVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await modelGrid.UpdateRow(pModel);
        }

        void CancelEdit(TakeOnOptionVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }
            modelGrid.CancelEditRow(pModel);

        }

        async Task DeleteRow(TakeOnOptionVM pModel)
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
            modelToInsert = new TakeOnOptionVM();
            await modelGrid.InsertRow(modelToInsert);

        }

        async Task OnCreateRow(TakeOnOptionVM pModel)
        {
            await _genericService.Update(pModel);
        }
    }

}
