using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IEntityTypeService
    {
        public Task<IEnumerable<EntityTypeVM>> GetEntityTypes();
        public Task<string> UpdateEntityType(EntityTypeVM entitytype);
        public Task<string> SaveEntityType(EntityTypeVM entitytype);
    }
}
