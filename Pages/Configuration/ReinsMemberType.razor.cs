using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using HorizonPollyC.Services.General;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;


namespace HorizonPollyC.Pages.Configuration
{
    partial class ReinsMemberType
    {

        RadzenDataGrid<ReinsuranceMemberTypeVM> modelGrid = null;
        ReinsuranceMemberTypeVM modelToInsert = null;
        public IEnumerable<ReinsuranceMemberTypeVM> modelList = new List<ReinsuranceMemberTypeVM>();
        bool enable = true;

        protected override async Task OnInitializedAsync()
        {
            modelList = await _genericService.Get();
        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<ReinsuranceMemberTypeVM>(modelGrid, type, "ReinsMemberType", "ReinsuranceMemberType");
        }
        async Task EditRow(ReinsuranceMemberTypeVM pModel)
        {
            await modelGrid.EditRow(pModel);
        }

        async void OnUpdateRow(ReinsuranceMemberTypeVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await _genericService.Update(pModel);
        }

        async Task SaveRow(ReinsuranceMemberTypeVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await modelGrid.UpdateRow(pModel);
        }

        void CancelEdit(ReinsuranceMemberTypeVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }
            modelGrid.CancelEditRow(pModel);

        }

        async Task DeleteRow(ReinsuranceMemberTypeVM pModel)
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
            modelToInsert = new ReinsuranceMemberTypeVM();
            await modelGrid.InsertRow(modelToInsert);

        }

        async Task OnCreateRow(ReinsuranceMemberTypeVM pModel)
        {
            await _genericService.Update(pModel);
        }
    }

}
