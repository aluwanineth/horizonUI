using HorizonPollyC.Models;
using HorizonPollyC.Shared;
using Microsoft.AspNetCore.Components;
using Radzen.Blazor;

namespace HorizonPollyC.Pages
{
    partial class PolicyEntityDetails
    {
        [CascadingParameter]
        public GlobalVariables? userInfo { get; set; }

        public RadzenDataGrid<BeneficiaryDetails> BeneficiaryDetailsResultsGrid;
        public IList<BeneficiaryDetails> BeneficiaryDetailsModel;
        public IEnumerable<BeneficiaryDetails> SelectedBeneficiaryDetail;

        public RadzenDataGrid<ExtendedMembersDetails> ExtendedMembersDetailsResultsGrid;
        public IList<ExtendedMembersDetails> ExtendedMembersDetailsModel;
        public IEnumerable<ExtendedMembersDetails> SelectedExtendedMembersDetails;


        protected override async Task OnInitializedAsync()
        {
            BeneficiaryDetailsModel = await _SCVService.GetPolicyBeneficiaries(userInfo.PolicyNumber.ToString());
            ExtendedMembersDetailsModel = await _SCVService.GetPolicyExtendedMembers(userInfo.PolicyNumber.ToString());
         
            Console.WriteLine(userInfo.EntityID);
        }

    }
}
