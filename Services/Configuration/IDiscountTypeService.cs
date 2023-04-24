using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IDiscountTypeService
    {
        public Task<IEnumerable<DiscountTypeVM>> GetDiscountTypes();
        public Task<string> UpdateDiscountType(DiscountTypeVM discounttype);
        public Task<string> SaveDiscountType(DiscountTypeVM discounttype);
    }
}
