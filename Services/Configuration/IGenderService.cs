using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IGenderService
    {
        public Task<IEnumerable<GenderVM>> GetGenders();
        public Task<string> UpdateGender(GenderVM gender);
        public Task<string> SaveGender(GenderVM gender);
    }
}
