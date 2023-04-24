using HorizonPollyC.Models;

namespace HorizonPollyC.Services.Configuration
{
    public interface IYesNoService
    {
        public Task<IEnumerable<YesNoVM>> GetYesNos();
    }
}
