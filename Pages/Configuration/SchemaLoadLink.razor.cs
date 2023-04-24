using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using HorizonPollyC.Services.General;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;


namespace HorizonPollyC.Pages.Configuration
{
    partial class SchemaLoadLink
    {

        RadzenDataGrid<ScheneLoadLinkVM> modelGrid = null;
        ScheneLoadLinkVM modelToInsert = null;
        public IEnumerable<ScheneLoadLinkVM> modelList = new List<ScheneLoadLinkVM>();
        bool enable = true;

        protected override async Task OnInitializedAsync()
        {
            modelList = await _genericService.Get();
        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<ScheneLoadLinkVM>(modelGrid, type, "SchemeLoadLink", "SchemeLoadLink");
        }
        async Task EditRow(ScheneLoadLinkVM pModel)
        {
            await modelGrid.EditRow(pModel);
        }

        async void OnUpdateRow(ScheneLoadLinkVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await _genericService.Update(pModel);
        }

        async Task SaveRow(ScheneLoadLinkVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }

            await modelGrid.UpdateRow(pModel);
        }

        void CancelEdit(ScheneLoadLinkVM pModel)
        {
            if (pModel == modelToInsert)
            {
                modelToInsert = null;
            }
            modelGrid.CancelEditRow(pModel);

        }

        async Task DeleteRow(ScheneLoadLinkVM pModel)
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
            modelToInsert = new ScheneLoadLinkVM();
            await modelGrid.InsertRow(modelToInsert);

        }

        async Task OnCreateRow(ScheneLoadLinkVM pModel)
        {
            await _genericService.Update(pModel);
        }
    }

}
