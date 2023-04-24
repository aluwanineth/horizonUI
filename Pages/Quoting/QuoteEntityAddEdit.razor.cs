using HorizonPollyC.Models;
using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Models.Quoting;
using HorizonPollyC.Shared;
using Microsoft.AspNetCore.Components;



namespace HorizonPollyC.Pages.Quoting
{
    partial class QuoteEntityAddEdit
    {


        [CascadingParameter]
        public GlobalVariables? userInfo { get; set; }
        [Parameter]
        public string EntityID { get; set; }
        [Parameter]
        public string EntityType { get; set; }

        public bool busy_loading { get; set; }


        public QuoteEntity Model;
        public IEnumerable<RoleVM> RoleLookup = new List<RoleVM>();
        public IEnumerable<TitlesVM> TitleLookup = new List<TitlesVM>();
        public IEnumerable<StatusVM> StatusLookup;
        public IEnumerable<GenderVM> GenderLookup;
        public IEnumerable<CoverVM> CoverLookup;


        public bool isExtendedMember;
        public bool isBeneficiary;

        protected override async Task OnInitializedAsync()
        {
            busy_loading = true;

            StatusLookup = await _statusService.Get();
            RoleLookup = await _genericService.Get();
            TitleLookup = await _titlesService.Get();
            GenderLookup = await _genderService.GetGenders();
            CoverLookup = await _coverService.GetCovers();

            Model = new QuoteEntity();
            Model.Relationid = 1;
            Model.NationalityID = 1;
            Model.PolicyNo = userInfo.SelectedCustomersPolicy.Policy_NO;
            Model.NationalityDesc = "TODO";
            Model.RelationDesc = "TODO";
            Model.QuoteNo = userInfo.SelectedQuote;

            Model.isAlsoBeneficiary = false;
            Model.isAlsoExtendedMember = false;

            if (EntityID == null)
                EntityID = "0";

            EntityType = EntityType.Replace("\'", "");

            //this is here because the HTML doesnt allow complex logic in the visable tags
            if (EntityType == "Beneficiary")
            {
                isExtendedMember = false;
                isBeneficiary = true;
                Model.Relationid = 4;
            }
            else
            {
                isExtendedMember = true;
                isBeneficiary = false;
            }

            Model = await _QuotesService.GetQuoteEntity(Convert.ToInt32(EntityID), Model.PolicyNo, Model.QuoteNo);
            Model.EntityType = "";


            if (Model.PhysicalAddress == null)
                Model.PhysicalAddress = new Address();
            if (Model.PostalAddress == null)
                Model.PostalAddress = new Address();

            busy_loading = false;

        }

        void OnChange(bool? value)
        {
            Console.WriteLine(value);
            StateHasChanged();
        }

        public async Task UpdateEntity()
        {
            Model.NationalityDesc = "TODO";
            Model.RelationDesc = "TODO";
            Model.CellNumber = "TODO";
            Model.EmailAddress = "TODO";

            await _QuotesService.CreateUpdateEntity(Model);
            NavManager.NavigateTo($"Quotes/Quotes");
        }
        public async Task Cancel()
        {
            NavManager.NavigateTo($"Quotes/Quotes");
        }
    }
}
