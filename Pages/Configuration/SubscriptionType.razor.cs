using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using HorizonPollyC.Services.General;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;


namespace HorizonPollyC.Pages.Configuration
{
    partial class SubscriptionType
    {

        RadzenDataGrid<SubscriptionTypeVM> modelGrid = null;
        SubscriptionTypeVM modelToInsert = null;
        public IEnumerable<SubscriptionTypeVM> modelList = new List<SubscriptionTypeVM>();
        bool enable = true;

        protected override async Task OnInitializedAsync()
        {
            modelList = await _genericService.Get();
        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<SubscriptionTypeVM>(modelGrid, type, "SubscriptionType", "SubscriptionType");
        }
        async Task EditRow(SubscriptionTypeVM pModel)
        {
            await modelGrid.EditRow(pModel);
        }

        async void OnUpdateRow(SubscriptionTypeVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await _genericService.Update(pModel);
        }

        async Task SaveRow(SubscriptionTypeVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await modelGrid.UpdateRow(pModel);
        }

        void CancelEdit(SubscriptionTypeVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }
            modelGrid.CancelEditRow(pModel);

        }

        async Task DeleteRow(SubscriptionTypeVM pModel)
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
            modelToInsert = new SubscriptionTypeVM();
            await modelGrid.InsertRow(modelToInsert);

        }

        async Task OnCreateRow(SubscriptionTypeVM pModel)
        {
            await _genericService.Update(pModel);
        }
    }

}
