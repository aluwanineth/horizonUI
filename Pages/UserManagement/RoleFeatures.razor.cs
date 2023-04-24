using HorizonPollyC.Components;
using HorizonPollyC.Models.UserManagement;
using HorizonPollyC.Services.UserManagement;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.UserManagement
{
    partial class RoleFeatures
    {

        RadzenDataGrid<RoleFeaturesVM> featuregrid;

        public IEnumerable<Roles> roleList = new List<Roles>();

        public IEnumerable<RoleFeaturesVM> WorkingfeatureList = new List<RoleFeaturesVM>();
        public IEnumerable<RoleFeaturesVM> InitialfeatureList = new List<RoleFeaturesVM>();

        public IEnumerable<int> SelectedFeatures = new int[] { };
        public IEnumerable<RoleFeaturesVM> InitialySelectedRoleFeatures = new List<RoleFeaturesVM>();
        public IEnumerable<Features> SelectedfeatureList = new List<Features>();
        public bool ShowProcessingScreen;



        int SelectedRole ;
        public bool showFeatures = false;


        public class RoleFeaturesVM : Features
        {
            public bool isSelected { get; set; }
        }
        public RoleFeatures()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            ShowProcessingScreen = false;
            roleList = await _userManagementService.GetRoles();

           // awaits dont work so well with linq
            IEnumerable<Features> tempAwaitFeaturelist = await _userManagementService.GetFeatures();
            InitialfeatureList = tempAwaitFeaturelist.Select(x => new RoleFeaturesVM()
            {
                isActive = x.isActive,
                FeatureDescription = x.FeatureDescription,
                ID = x.ID,
                isSelected = false
            }).ToList();

            WorkingfeatureList = InitialfeatureList;
        }


        async void OnRoleChange(object value)
        {
            ShowProcessingScreen = true;
            if (value != null)
            {
                SelectedRole =Convert.ToInt32(value) ;

                //this get the list of features you have access to
                SelectedfeatureList = await _userManagementService.GetRoleFeatures(value.ToString());

                //when we change the role we reset the selected Items
                WorkingfeatureList = CloneObject.Clone<IEnumerable<RoleFeaturesVM>>(InitialfeatureList);

                //get the ID's and update the working set with selected value
                SelectedFeatures = SelectedfeatureList.Select(x => x.ID).ToArray();
                foreach (var item in SelectedfeatureList)
                {
                    WorkingfeatureList.Where(x => x.ID == item.ID).FirstOrDefault().isSelected = true;
                }
                //keep what the initial Roles selection was , for the cancel button
                InitialySelectedRoleFeatures = CloneObject.Clone<IEnumerable<RoleFeaturesVM>>(WorkingfeatureList);
            } 
            
            ShowProcessingScreen = false;
            StateHasChanged();
           
        }

        public void UpdateFeatureList()
        {
            ShowProcessingScreen = true;
            StateHasChanged();

            IEnumerable<RoleFeaturesVM> ToRemoveList = WorkingfeatureList.Where(x => !SelectedFeatures.Contains(x.ID) && x.isSelected).ToList();
            IEnumerable<RoleFeaturesVM> ToAddList = WorkingfeatureList.Where(x => SelectedFeatures.Contains(x.ID) && !x.isSelected).ToList();

            foreach (var item in ToRemoveList)
            {
                _userManagementService.DeleteRoleFeature(item.ID, SelectedRole);
            }

            //find everything to Add
            IEnumerable<RoleFeature> FeaturesToAdd = ToAddList.Select(x => new RoleFeature
            {
                FeatureID = x.ID,
                RoleID = SelectedRole
            }).ToList();

            foreach (var item in FeaturesToAdd)
            {
                _userManagementService.AddRoleFeature(item);
            }

            ShowProcessingScreen=false;
            StateHasChanged();
        }

        public void ClearSelection()
        {
            WorkingfeatureList = CloneObject.Clone<IEnumerable<RoleFeaturesVM>>(InitialySelectedRoleFeatures);
        }
    }
}
