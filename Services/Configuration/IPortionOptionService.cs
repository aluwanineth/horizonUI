using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IPortionOptionService
    {
        public Task<IEnumerable<PortionOptionVM>> GetPortionOptions();
        public Task<string> UpdatePortionOption(PortionOptionVM portionoption);
        public Task<string> SavePortionOption(PortionOptionVM portionoption);
    }
}
