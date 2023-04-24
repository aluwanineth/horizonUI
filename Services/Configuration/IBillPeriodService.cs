using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IBillPeriodService
    {
        public Task<IEnumerable<BillPeriodVM>> GetBillPeriods();
        public Task<string> UpdateBillPeriod(BillPeriodVM billperiod);
        public Task<string> SaveBillPeriod(BillPeriodVM billperiod);
    }
}
