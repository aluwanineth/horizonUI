using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IDataArtefactService
    {
        public Task<IEnumerable<DataArtefactVM>> GetDataArtefacts();
        public Task<string> UpdateDataArtefact(DataArtefactVM dataartefact);
        public Task<string> SaveDataArtefact(DataArtefactVM dataartefact);
    }
}
