using HorizonPollyC.Models;
using HorizonPollyC.Shared;
using Microsoft.AspNetCore.Components;
using Radzen.Blazor;

namespace HorizonPollyC.Pages
{
    partial class AccountingHistory
    {
        [CascadingParameter]
        public GlobalVariables? userInfo { get; set; }

        public RadzenDataGrid<AccountingHistoryDetails> AccountingHistoryGrid;
        public IList<AccountingHistoryDetails> AccountingHistoryModel;
        public IEnumerable<AccountingHistoryDetails> SelectedAccountingHistoryDetail;

        protected override async Task OnInitializedAsync()
        {
            AccountingHistoryModel = await _SCVService.GetPolicyAccountingHistory(userInfo.PolicyNumber.ToString());
        }
    }
}
