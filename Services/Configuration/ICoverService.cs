using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface ICoverService
    {
        public Task<IEnumerable<CoverVM>> GetCovers();
        public Task<string> UpdateCover(CoverVM cover);
        public Task<string> SaveCover(CoverVM cover);
    }
}
