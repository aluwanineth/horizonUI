using HorizonPollyC.Models.Quoting;
using HorizonPollyC.Shared;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Quoting
{
    partial class QuoteList
    {
        [CascadingParameter]
        public GlobalVariables? userInfo { get; set; }
        public RadzenDataGrid<QuoteListModel> ResultsGrid;
        public IEnumerable<QuoteListModel> DisplayModel;
        public IList<QuoteListModel> SelecteModelDetail;


        protected override async Task OnInitializedAsync()
        {
            DisplayModel = await _QuotesService.GetEntityPolicyQuotes((int)userInfo.EntityID, (int)userInfo.PolicyNumber);
            StateHasChanged();
        }

        async Task EditQuote(int QuoteNo)
        {
            userInfo.SelectedQuote = QuoteNo;
            NavManager.NavigateTo($"Quotes/Quotes");
            //  throw new NotFiniteNumberException();
        }
        async Task AcceptQuote(int QuoteNo)
        {
            await _QuotesService.AcceptQuote((int)userInfo.PolicyNumber, QuoteNo);
            NavManager.NavigateTo($"Quotes/QuotesList");

        }
        async Task RejectQuote(int QuoteNo)
        {
            await _QuotesService.DeActivateQuote((int)userInfo.PolicyNumber, QuoteNo);
            NavManager.NavigateTo($"Quotes/QuotesList");
        }

        async Task CopyQuote(int QuoteNo)
        {
            string QuoteN0 = await _QuotesService.CopyQuote((int)userInfo.PolicyNumber, QuoteNo);
                 EditQuote(Convert.ToInt32(QuoteN0));
        }

        async Task CreateNewQuote()
        {
            var NewQuoteNumber = await _QuotesService.CreateNewQuote((int)userInfo.PolicyNumber);

            if (NewQuoteNumber != string.Empty)
                EditQuote(Convert.ToInt32(NewQuoteNumber));
        }
    }
}
