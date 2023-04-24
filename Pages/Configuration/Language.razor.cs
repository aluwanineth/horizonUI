using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class Language
    {
        RadzenDataGrid<LanguageVM> languageGrid = null;
        LanguageVM languageToInsert = null;
        public IEnumerable<LanguageVM> languages = new List<LanguageVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            languages = await _languageService.GetLanguages();

        }
        public async Task Export(string type)
        {
            await _exportService.ExportData<LanguageVM>(languageGrid, type, "Language", "Languages");
        }


        async Task EditRow(LanguageVM language)
        {
            await languageGrid.EditRow(language);
        }

        async void OnUpdateRow(LanguageVM language)
        {
            if (language == languageToInsert)
            {
                languageToInsert = null;
            }


            await _languageService.UpdateLanguage(language);

        }

        async Task SaveRow(LanguageVM language)
        {

            if (language == languageToInsert)
            {
                languageToInsert = null;
            }

            await languageGrid.UpdateRow(language);
        }

        void CancelEdit(LanguageVM language)
        {
            if (language == languageToInsert)
            {
                languageToInsert = null;
            }

            languageGrid.CancelEditRow(language);

        }

        async Task DeleteRow(LanguageVM language)
        {
            if (language == languageToInsert)
            {
                languageToInsert = null;
            }

            if (languages.Contains(language))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                languages.ToList().Remove(language);

                // For production
                //dbContext.SaveChanges();

                await languageGrid.Reload();
            }
            else
            {
                languageGrid.CancelEditRow(language);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            languageToInsert = new LanguageVM();
            await languageGrid.InsertRow(languageToInsert);

        }

        async Task OnCreateRow(LanguageVM language)
        {
            // dbContext.Add(order);
            await _languageService.SaveLanguage(language);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
