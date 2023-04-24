using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface ILevelService
    {
        public Task<IEnumerable<LevelVM>> GetLevels();
        public Task<string> UpdateLevel(LevelVM level);
        public Task<string> SaveLevel(LevelVM level);
    }
}
