using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IBordereauxSourceService
    {
        public Task<IEnumerable<BordereauxSourceVM>> GetBordereauxSources();
        public Task<string> UpdatetBordereauxSource(BordereauxSourceVM bordereauxsource);
        public Task<string> SavetBordereauxSource(BordereauxSourceVM bordereauxsource);
    }
}
