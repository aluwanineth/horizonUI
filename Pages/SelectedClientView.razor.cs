
using HorizonPollyC.Models;
using HorizonPollyC.Services;
using HorizonPollyC.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Radzen.Blazor;

namespace HorizonPollyC.Pages
{
    partial class SelectedClientView
    {

        public PersonSearch ClientSearchResults = new PersonSearch();
        public List<CustomerPolicies> CustomerPoliciesModel = new List<CustomerPolicies>();
        public RadzenDataGrid<CustomerPolicies> CustomerPolicyResultsGrid;
        [CascadingParameter]
        public GlobalVariables? Globals { get; set; }

        protected override async Task OnInitializedAsync()
        {

            var tempValue = await _localStorageService.GetItemAsStringAsync("LoggedInUser");
            Globals.LoggedInUser = tempValue.Replace("\"", "");


            if (Globals.ClientSearchResults != null)
            {
                ClientSearchResults = Globals.ClientSearchResults.Where(x=> x.EntityID== Globals.EntityID).FirstOrDefault();
            }
        }

        public async void PolicySelected()
        {
            NavManager.NavigateTo("PolicyDetails");

        }

    }
}
