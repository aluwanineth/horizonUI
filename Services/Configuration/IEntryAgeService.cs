using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IEntryAgeService
    {
        public Task<IEnumerable<EntryAgeVM>> GetEntryAges();
        public Task<string> UpdateEntryAge(EntryAgeVM entryage);
        public Task<string> SaveEntryAge(EntryAgeVM entryage);
    }
}
