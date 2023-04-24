using HorizonPollyC.Models;
using HorizonPollyC.Shared;
using Microsoft.AspNetCore.Components;
using Radzen.Blazor;

namespace HorizonPollyC.Pages
{
    partial class AuditLog
    {

        [CascadingParameter]
        public GlobalVariables? userInfo { get; set; }

        public RadzenDataGrid<AuditLogDetails> AuditLogDetailsGrid;
        public IList<AuditLogDetails> AuditLogDetailsModel;
        public IEnumerable<AuditLogDetails> SelectedAuditLogDetailsDetail;

        protected override async Task OnInitializedAsync()
        {
            AuditLogDetailsModel = await _SCVService.GetPolicyAuditLogs(userInfo.PolicyNumber.ToString());
        }
    }
}
