using PetApp.Data.Entity;
using PetApp.Data.Enum;

namespace PetApp.Business.Services.Interfaces
{
    public interface IService<T>
    {
        Task<List<T>> GetAsync();
        Task<T> GetAsync(int modelId);
        Task InsertAsync(T model);
        Task UpdateAsync(T model);
        Task DeleteAsync(int modelId);
    }
}
