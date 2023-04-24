using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IPartnerService
    {
        public Task<IEnumerable<PartnerVM>> GetPartners();
        public Task<string> UpdatePartner(PartnerVM partner);
        public Task<string> SavePartner(PartnerVM partner);
    }
}
