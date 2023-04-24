using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IStatusReasonsService
    {
        public Task<IEnumerable<StatusReasonsVM>> GetStatusReasons();
        public Task<string> UpdateStatusReasons(StatusReasonsVM statusReasons);
        public Task<string> SaveStatusReasons(StatusReasonsVM statusReasons);
    }
}
