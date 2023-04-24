using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IAttributeService
    {
        public Task<IEnumerable<AttributeVM>> GetAttributes();
        public Task<string> UpdateAttribute(AttributeVM attribute);
        public Task<string> SaveAttribute(AttributeVM attribute);
    }
}
