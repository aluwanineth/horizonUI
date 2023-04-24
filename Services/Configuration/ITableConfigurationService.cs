using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface ITableConfigurationService
    {
        public Task<IEnumerable<TableConfigurationVM>> GetTableConfiguration();
    }
 
}
