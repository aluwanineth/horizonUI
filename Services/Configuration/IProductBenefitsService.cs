using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IProductBenefitsService
    {
        public Task<IEnumerable<ProductBenefitsVM>> GetProductBenefits();
        public Task<string> UpdateProductBenefits(ProductBenefitsVM productBenefit);
        public Task<string> SaveProductBenefits(ProductBenefitsVM productBenefit);
    }
}
