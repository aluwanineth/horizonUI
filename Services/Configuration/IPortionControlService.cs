using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IPortionControlService
    {
        public Task<IEnumerable<PortionControlVM>> GetPortionControls();
        public Task<string> UpdatePortionControl(PortionControlVM portioncontrol);
        public Task<string> SavePortionControl(PortionControlVM portioncontrol);
    }
}
