using HorizonPollyC.Models;
using HorizonPollyC.Services;
using HorizonPollyC.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages
{

    partial class Search
    {
        public class ScreenControlls
        {
            public string SearchString;
        }
        bool ShowProcessingScreen;
        bool DisplayPolicyResults;
        bool ShowErrorMessage = false;
        string ErrorMessage = String.Empty;

        // public string SearchString;
        public ScreenControlls screenControlls;

        public RadzenDataGrid<PersonSearch> ClientsResultsGrid;
        public IEnumerable<PersonSearch> ClientsModel;
        public IList<PersonSearch> SelectedClients;

        [CascadingParameter]
        public GlobalVariables? Globals { get; set; }

        async Task SearchForPerson()
        {
            /*
            ShowErrorMessage = false;
            ShowProcessingScreen = true;
            // Get the entity first based on the wildcard search criteria
            ClientsModel = await SCVService.GetPersonSearch(screenControlls.SearchString);

            if (ClientsModel == null || ClientsModel.Count() == 0)
            {
                ErrorMessage = "There are no clients matching the information entered.";
                ShowProcessingScreen = false;
                ShowErrorMessage = true;
                DisplayPolicyResults = false;

                Globals.EntityID = 0;
                Globals.PolicyNumber = 0;

                Globals.ClientSearchResults = null;
                Globals.SearchedCustomers = null;

                return;
            }

            //TODO: this to needs to be the selected one
            // Globals.EntityID = ClientSearchResults.EntityID;
            Globals.ClientSearchResults = ClientsModel.ToList();
            //SelectedClients = ClientsModel.Take(1).ToList() ;


            Globals.SearchedCustomers = null;
            ShowProcessingScreen = false;
            DisplayPolicyResults = true;

            StateHasChanged();
            */
        }

        public async void ClientSelected(DataGridRowMouseEventArgs<PersonSearch> Arg)
        {
            Globals.EntityID = Arg.Data.EntityID;
            Globals.PersonFirstName = Arg.Data.PersonFirstName;
            Globals.PersonSurname = Arg.Data.PersonSurname;

            //SelectedClients.Add(Arg.Data);

            NavManager.NavigateTo("SelectedClientView");

        }




    }
}
