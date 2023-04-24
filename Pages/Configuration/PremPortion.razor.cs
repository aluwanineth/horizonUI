using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using HorizonPollyC.Services.General;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
using System.Linq;


namespace HorizonPollyC.Pages.Configuration
{
    public partial class PremPortion
    {
        RadzenDataGrid<PremPortionVM> premPortionGrid = null;
        PremPortionVM premPortionToInsert = null;
        public IEnumerable<PremPortionVM> premPortions = new List<PremPortionVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }
        public IEnumerable<SchemeVM> schemeLookup;
        public IEnumerable<PlanTypeVM> plantypeLookup;
        public IEnumerable<LevelVM> levelLookup;
        public IEnumerable<PremiumPortionTypeVM> premiumportiontypeLookup;


        protected override async Task OnInitializedAsync()
        {

            premPortions = await _premPortionService.GetPremPortion();

            //schemeLookup = await _schemeService.Get();
            //plantypeLookup = await _plantypeService.GetPlanTypes();
            //levelLookup = await _levelService.GetLevels();
            //premiumportiontypeLookup = await _premiumportionService.GetPremiumPortions();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<PremPortionVM>(premPortionGrid, type, "PremPortion", "PremPortion");
        }

        async Task EditRow(PremPortionVM premPortion)
        {
            await premPortionGrid.EditRow(premPortion);
        }

        async void OnUpdateRow(PremPortionVM premPortion)
        {
            if (premPortion == premPortionToInsert)
            {
                premPortionToInsert = null;
            }


            await _premPortionService.UpdatePremPortion(premPortion);

        }

        async Task SaveRow(PremPortionVM premPortion)
        {
            if (premPortion == premPortionToInsert)
            {
                premPortionToInsert = null;
            }

            await premPortionGrid.UpdateRow(premPortion);
        }

        void CancelEdit(PremPortionVM premPortion)
        {
            if (premPortion == premPortionToInsert)
            {
                premPortionToInsert = null;
            }

            premPortionGrid.CancelEditRow(premPortion);

        }

        async Task DeleteRow(PremPortionVM premPortion)
        {
            if (premPortion == premPortionToInsert)
            {
                premPortionToInsert = null;
            }

            if (premPortions.Contains(premPortion))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                premPortions.ToList().Remove(premPortion);

                // For production
                //dbContext.SaveChanges();

                await premPortionGrid.Reload();
            }
            else
            {
                premPortionGrid.CancelEditRow(premPortion);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            premPortionToInsert = new PremPortionVM();
            await premPortionGrid.InsertRow(premPortionToInsert);

        }

        async Task OnCreateRow(PremPortionVM premPortion)
        {
           
           var result = await _premPortionService.SavePremPortion(premPortion);

       

            premPortions = await _premPortionService.GetPremPortion();

     
        }
    }
}
