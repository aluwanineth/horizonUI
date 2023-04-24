using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IValidateStructureService
    {
        public Task<IEnumerable<ValidateStructureVM>> GetValidateStructure();
        public Task<string> UpdateValidateStructure(ValidateStructureVM validateStructure);
        public Task<string> SaveValidateStructure(ValidateStructureVM validateStructure);
    }
}
