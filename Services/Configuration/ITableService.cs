using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface ITableService
    {
        public Task<IEnumerable<TableVM>> GetTable();
        public Task<string> UpdateTable(TableVM table);
        public Task<string> SaveTable(TableVM table);
    }
}
