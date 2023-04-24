using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Configuration
{
    public interface IGeneric<T>
    {
        public Task<IEnumerable<T>> Get();
        public Task<string> Update(T model);

    }
}
