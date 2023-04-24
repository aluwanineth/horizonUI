using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace HorizonPollyC.Shared
{
    partial class UserDetails
    {

        [CascadingParameter]
        public GlobalVariables? userInfo { get; set; }
        public string LoggedInUser { get; set; }
        protected override async Task OnInitializedAsync()
        {
            
        }

    }
}
