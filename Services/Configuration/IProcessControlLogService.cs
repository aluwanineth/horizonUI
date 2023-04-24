using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IProcessControlLogService
    {
        public Task<IEnumerable<ProcessControlLogsVM>> GetProcessControlLogs();
        public Task<string> UpdateProcessControlLogs(ProcessControlLogsVM processControlLogs);
        public Task<string> SaveProcessControlLogs(ProcessControlLogsVM processControlLogs);
    }
}
