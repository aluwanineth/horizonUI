using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using HorizonPollyC.Services.General;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;


namespace HorizonPollyC.Pages.Configuration
{
    partial class ReinsDuration
    {

        RadzenDataGrid<ReinsuranceDurationVM> modelGrid = null;
        ReinsuranceDurationVM modelToInsert = null;
        public IEnumerable<ReinsuranceDurationVM> modelList = new List<ReinsuranceDurationVM>();
        bool enable = true;

        protected override async Task OnInitializedAsync()
        {
            modelList = await _genericService.Get();
        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<ReinsuranceDurationVM>(modelGrid, type, "ReinsDuration", "ReinsuranceDuration");
        }
        async Task EditRow(ReinsuranceDurationVM pModel)
        {
            await modelGrid.EditRow(pModel);
        }

        async void OnUpdateRow(ReinsuranceDurationVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await _genericService.Update(pModel);
        }

        async Task SaveRow(ReinsuranceDurationVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await modelGrid.UpdateRow(pModel);
        }

        void CancelEdit(ReinsuranceDurationVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }
            modelGrid.CancelEditRow(pModel);

        }

        async Task DeleteRow(ReinsuranceDurationVM pModel)
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
            modelToInsert = new ReinsuranceDurationVM();
            await modelGrid.InsertRow(modelToInsert);

        }

        async Task OnCreateRow(ReinsuranceDurationVM pModel)
        {
            await _genericService.Update(pModel);
        }
    }

}
