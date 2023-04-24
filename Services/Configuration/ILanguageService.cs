using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface ILanguageService
    {
        public Task<IEnumerable<LanguageVM>> GetLanguages();
        public Task<string> UpdateLanguage(LanguageVM language);
        public Task<string> SaveLanguage(LanguageVM language);
    }
}
