using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using HorizonPollyC.Services.General;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
namespace HorizonPollyC.Pages.Configuration
{
    partial class WaitingPeriods
    {
        RadzenDataGrid<WaitingPeriodsVM> modelGrid = null;
        WaitingPeriodsVM modelToInsert = null;
        public IEnumerable<WaitingPeriodsVM> modelList = new List<WaitingPeriodsVM>();
        bool enable = true;

        protected override async Task OnInitializedAsync()
        {
            modelList = await _genericService.Get();
        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<WaitingPeriodsVM>(modelGrid, type, "WaitingPeriod", "WaitingPeriods");
        }
        async Task EditRow(WaitingPeriodsVM pModel)
        {
            await modelGrid.EditRow(pModel);
        }

        async void OnUpdateRow(WaitingPeriodsVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await _genericService.Update(pModel);
        }

        async Task SaveRow(WaitingPeriodsVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await modelGrid.UpdateRow(pModel);
        }

        void CancelEdit(WaitingPeriodsVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }
            modelGrid.CancelEditRow(pModel);

        }

        async Task DeleteRow(WaitingPeriodsVM pModel)
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
            modelToInsert = new WaitingPeriodsVM();
            await modelGrid.InsertRow(modelToInsert);

        }

        async Task OnCreateRow(WaitingPeriodsVM pModel)
        {
            await _genericService.Update(pModel);
        }
    }
}
