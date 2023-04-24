using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IPlanOptionService
    {
        public Task<IEnumerable<PlanOptionVM>> GetPlanOptions();
        public Task<string> UpdatePlanOption(PlanOptionVM planoption);
        public Task<string> SavePlanOption(PlanOptionVM planoption);
    }
}
