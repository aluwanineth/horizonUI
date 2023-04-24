using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using HorizonPollyC.Services.General;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;


namespace HorizonPollyC.Pages.Configuration
{
    partial class PremiumType
    {

        RadzenDataGrid<PremiumTypeVM> modelGrid = null;
        PremiumTypeVM modelToInsert = null;
        public IEnumerable<PremiumTypeVM> modelList = new List<PremiumTypeVM>();
        bool enable = true;

        protected override async Task OnInitializedAsync()
        {
            modelList = await _genericService.Get();
        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<PremiumTypeVM>(modelGrid, type, "PremiumType", "PremiumType");
        }
        async Task EditRow(PremiumTypeVM pModel)
        {
            await modelGrid.EditRow(pModel);
        }

        async void OnUpdateRow(PremiumTypeVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await _genericService.Update(pModel);
        }

        async Task SaveRow(PremiumTypeVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await modelGrid.UpdateRow(pModel);
        }

        void CancelEdit(PremiumTypeVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }
            modelGrid.CancelEditRow(pModel);

        }

        async Task DeleteRow(PremiumTypeVM pModel)
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
            modelToInsert = new PremiumTypeVM();
            await modelGrid.InsertRow(modelToInsert);

        }

        async Task OnCreateRow(PremiumTypeVM pModel)
        {
            await _genericService.Update(pModel);
        }
    }

}
