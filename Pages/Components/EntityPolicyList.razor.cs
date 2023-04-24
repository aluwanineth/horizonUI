using HorizonPollyC.Models;
using HorizonPollyC.Services;
using HorizonPollyC.Shared;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorizonPollyC.Pages.Components
{
    partial class EntityPolicyList
    {
        [Parameter]
        public EventCallback onPolicySelect { get; set; }

        public RadzenDataGrid<CustomerPolicies> CustomerPolicyResultsGrid;
        public IEnumerable<CustomerPolicies> CustomerPoliciesModel;
        public IList<CustomerPolicies> SelectedPolicy;

        [CascadingParameter]
        public GlobalVariables? Globals { get; set; }


        protected override async Task OnInitializedAsync()
        {

            if (Globals.SearchedCustomers == null)
            {
                if (Globals.EntityID != null)
                {
                    CustomerPoliciesModel = await _SCVService.GetCustomerPolicyInfo(Convert.ToInt32(Globals.EntityID));
                    //Globals.PolicyNumber = CustomerPoliciesModel.FirstOrDefault().Policy_NO;

                    if (Globals.PolicyNumber!=null && Globals.PolicyNumber!=0)
                        SelectedPolicy = CustomerPoliciesModel.Where(x=>x.Policy_NO == Globals.PolicyNumber).ToList();
                    else
                    {
                        Globals.PolicyNumber = CustomerPoliciesModel.FirstOrDefault().Policy_NO;
                        SelectedPolicy = CustomerPoliciesModel.Take(1).ToList();
                    }
                       

                    Globals.SearchedCustomers = CustomerPoliciesModel;
                    Globals.SelectedCustomersPolicy = SelectedPolicy.FirstOrDefault();
                }
            }
            else
            {
                CustomerPoliciesModel = Globals.SearchedCustomers;
                SelectedPolicy = CustomerPoliciesModel.Where(x => x.Policy_NO == Globals.PolicyNumber).ToList();
            }
        }

        public void PolicySelected(DataGridRowMouseEventArgs<CustomerPolicies> Arg)
        {
            Globals.PolicyNumber = Arg.Data.Policy_NO;
            SelectedPolicy = CustomerPoliciesModel.Where(x => x.Policy_NO == Globals.PolicyNumber).ToList();
            StateHasChanged();

            onPolicySelect.InvokeAsync();
           
        }

    }
}
