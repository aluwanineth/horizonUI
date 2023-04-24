using Microsoft.AspNetCore.Components;

namespace HorizonPollyC.Shared
{
    partial class NavMenu
    {

        [CascadingParameter]
        public GlobalVariables? userInfo { get; set; }
        bool PolicySelected = false;    
        protected override async Task OnInitializedAsync()
        {
            PolicySelected = false;
            if (userInfo == null)
                return;

            if (userInfo.PolicyNumber == null)
                return;

            if(userInfo.PolicyNumber!= 0)
            {
                PolicySelected = true;
            }

        }

    }
}
