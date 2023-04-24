using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface ITransTypeService
    {
        public Task<IEnumerable<TransTypeVM>> GetTransType();
        public Task<string> UpdateTransType(TransTypeVM transType);
        public Task<string> SaveTransType(TransTypeVM transType);
    }
}
