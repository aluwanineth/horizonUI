using HorizonPollyC.Models;
using HorizonPollyC.Shared;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using HorizonPollyC.Pages.Components;
using HorizonPollyC.Services;
using Microsoft.AspNetCore.Authorization;

namespace HorizonPollyC.Pages
{
    partial class BenefitDetail
    {

        [CascadingParameter]
        public GlobalVariables? Globals { get; set; }

        public RadzenDataGrid<BenefitDetail2> benefitsResultsGrid;
        public IList<BenefitDetail2> BenefitsModel;
        public IEnumerable<BenefitDetail2> SelectedBenefits;
        public Decimal PremiumTotal = 0m;
        public Boolean is_loading = false;
        protected override async Task OnInitializedAsync()
        {
            LoadData();
        }

        public async Task LoadData()
        {
            is_loading = true;
            StateHasChanged();

            try
            {
                                
                BenefitsModel = await _SCVService.GetBenefitDetail2(Globals.PolicyNumber.ToString());
                if ((!(BenefitsModel == null)) && (BenefitsModel.Count > 0) && (!(BenefitsModel[0].PremiumTotal == null)))
                {
                    PremiumTotal = BenefitsModel[0].PremiumTotal.Value;
                }
                
            }
            catch (Exception ex)
            {
                Globals.error_msg = "Error loading benefits";
            }

            is_loading = false;
            StateHasChanged();
        }

        private void OnStateHasChanged()
        {
            StateHasChanged();
        }

        public async void PolicySelected()
        {
            LoadData();
        }


    }
}
