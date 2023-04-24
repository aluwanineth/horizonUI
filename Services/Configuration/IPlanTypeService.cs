using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IPlanTypeService
    {
        public Task<IEnumerable<PlanTypeVM>> GetPlanTypes();
        public Task<string> UpdatePlanType(PlanTypeVM plantype);
        public Task<string> SavePlanType(PlanTypeVM plantype);
    }
}
