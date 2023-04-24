using Microsoft.AspNetCore.Mvc;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Services.General
{
    public interface IExportService
    {
        // public Task<byte[]> ExportDataToExcel(string fileName = null, string type = null, Query query = null);
        public Task<IQueryable<T>> GetData<T>(string Controller, string Action);// where T : class;
        public Task<IQueryable<T>> GetData<T>(string Controller);
        public IQueryable<T> ApplyQuery<T>(IQueryable<T> items, Query query = null);// where T : class;
        public FileStreamResult ToExcel(IQueryable query, string fileName = null);
        public FileStreamResult ToCSV(IQueryable query, string fileName = null);
        public Task<IQueryable<T>> ExportData<T>(RadzenDataGrid<T> RadzonGrid, string type, string Controller, string Action);
    }
}
