using HorizonPollyC.Models;
using HorizonPollyC.Shared;
using Microsoft.AspNetCore.Components;

namespace HorizonPollyC.Pages
{
    partial class BrokerDetails
    {
        public BrokerDetail _BrokerDetails { get; set; }
        [CascadingParameter]
        public GlobalVariables? userInfo { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _BrokerDetails = _SCVService.GetBrokerDetails(userInfo.PolicyNumber.ToString()).Result;
        }
    }
}
