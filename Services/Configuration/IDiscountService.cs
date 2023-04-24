using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IDiscountService
    {
        public Task<IEnumerable<DiscountVM>> GetDiscounts();
        public Task<string> UpdateDiscount(DiscountVM discount);
        public Task<string> SaveDiscount(DiscountVM discount);
    }
}
