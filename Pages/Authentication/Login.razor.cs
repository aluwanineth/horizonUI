using HorizonPollyC.Components;
using HorizonPollyC.Models;
using HorizonPollyC.Services;
using HorizonPollyC.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace HorizonPollyC.Pages.Authentication
{
    public partial class Login
    {
        User userModel = new User();
        bool ShowProcessingScreen = false;

        [CascadingParameter]
        public GlobalVariables? userInfo { get; set; }
        public string ErrorMessage { get; set; }

        //[CascadingParameter]
        //public EventCallback setRefreshEventTimer { get; set; }

        //[AvailableFeatureAttribite("")]

        protected override async Task OnInitializedAsync()
        {
            //remove any old tokens;
            await _localStorageService.RemoveItemAsync("authResult");


        }

        public async void OnLogin()
        {
            try
            {
                ShowProcessingScreen = true;
                ErrorMessage = string.Empty;
                await AuthenticationService.Login(userModel);
                userInfo = new GlobalVariables();
                userInfo.LoggedInUser = userModel.username;

                //call this again to make sure the new claims are loaded
                await ASP.GetAuthenticationStateAsync();

                NavigationManager.NavigateTo("Search", false);
                ShowProcessingScreen = false;

            }
            catch (AccessViolationException Aex)
            {
                ErrorMessage = Aex.Message;
                ShowProcessingScreen = false;
                StateHasChanged();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                ShowProcessingScreen = false;
                StateHasChanged();
            }
        }
    }

}
