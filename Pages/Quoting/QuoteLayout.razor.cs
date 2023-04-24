using HorizonPollyC.Shared;
using Microsoft.AspNetCore.Components;

namespace HorizonPollyC.Pages.Quoting
{
    partial class QuoteLayout
    {


        private IDictionary<string, object> PassThroughParamaters;

        public Type ComponentToShow;
        public int CurrentWorkFlowStep = 1;

        protected override async Task OnInitializedAsync()
        {
            SetScreen();
        }

        public void SetScreen()
        {
            switch (CurrentWorkFlowStep)
            {

                case 1:
                    ComponentToShow = typeof(QuoteEntities);
                    break;

                default:
                    break;
            }
        }


        public void Next()
        {
            CurrentWorkFlowStep++;
            SetScreen();
        }
        public void Back()
        {
            CurrentWorkFlowStep--;
            SetScreen();
        }
        public void Cancel()
        {

        }

    }
}
