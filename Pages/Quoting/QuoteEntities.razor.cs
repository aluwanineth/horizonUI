using HorizonPollyC.Models.Quoting;
using HorizonPollyC.Shared;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Quoting
{
    partial class QuoteEntities
    {

        [CascadingParameter]
        public GlobalVariables? userInfo { get; set; }
        public RadzenDataGrid<QuoteEntitiesList> ResultsGrid;
        public IEnumerable<QuoteEntitiesList> MainMemberModel;
        public IEnumerable<QuoteEntitiesList> ExtededMemberModel;
        public IEnumerable<QuoteEntitiesList> BeneficiaryMemberModel;

        public IList<QuoteEntitiesList> SelecteModelDetail;



        public int[] NotExtendedMembersList = new int[] { 1, 2, 3, 4 };
        public int[] BeneficiaryMembersList = new int[] { 4 };
        public int[] MainMembersList = new int[] { 1, 2, 3 };


        protected override async Task OnInitializedAsync()
        {
           var DisplayModel = await _QuotesService.GetQuoteEntities(userInfo.SelectedQuote);

            MainMemberModel = DisplayModel.Where(x => MainMembersList.Contains(x.RelationID));
            ExtededMemberModel = DisplayModel.Where(x => !NotExtendedMembersList.Contains(x.RelationID));
            BeneficiaryMemberModel = DisplayModel.Where(x => BeneficiaryMembersList.Contains(x.RelationID));

        }

        public void AddNewEntity(string Type)
        {
            NavManager.NavigateTo($"Quotes/QuoteEntityAddEdit/{0}/{Type}");
        }


        public void EditEntity(int EntityID, string EntityType)
        {
            NavManager.NavigateTo($"Quotes/QuoteEntityAddEdit/{EntityID}/{EntityType}");
        }

        public void RemoveEntity(int EntityID)
        {

        }

    }
}
