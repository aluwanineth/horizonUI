using HorizonPollyC.Models.UserManagement;
using HorizonPollyC.Services.UserManagement;
using Microsoft.AspNetCore.Authorization;
using Radzen.Blazor;


namespace HorizonPollyC.Pages.UserManagement
{
    [Authorize(Roles = "UserManagement")]
    partial class FeatureList
    {
        RadzenDataGrid<Features> featuregrid;
        public IEnumerable<Features> featureList = new List<Features>();
        Features featuresToInsert;
        bool enable = true;

        //IUserManagementService _userManagementService;

        public FeatureList()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            featureList = await _userManagementService.GetFeatures();

        }

        async Task EditRow(Features features)
        {
            await featuregrid.EditRow(features);
        }

        async void OnUpdateRow(Features features)
        {
            if (features == featuresToInsert)
            {
                featuresToInsert = null;
            }

            await _userManagementService.CreateUpdateFeature(features);
        }

        async Task SaveRow(Features features)
        {
            if (features == featuresToInsert)
            {
                featuresToInsert = null;
            }

            await featuregrid.UpdateRow(features);
        }

        void CancelEdit(Features features)
        {
            if (features == featuresToInsert)
            {
                featuresToInsert = null;
            }

            featuregrid.CancelEditRow(features);

        }

        async Task DeleteRow(Features features)
        {
            if (features == featuresToInsert)
            {
                featuresToInsert = null;
            }

            if (featureList.Contains(features))
            {
                featureList.ToList().Remove(features);
                await featuregrid.Reload();
            }
            else
            {
                featuregrid.CancelEditRow(features);
            }
        }

        async Task InsertRow()
        {
            enable = false;
            featuresToInsert = new Features();
            await featuregrid.InsertRow(featuresToInsert);

        }

        async Task OnCreateRow(Features features)
        {
            await _userManagementService.CreateUpdateFeature(features);
        }
    }
}
