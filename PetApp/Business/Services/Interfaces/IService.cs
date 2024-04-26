using PetApp.Data.Entity;
using PetApp.Data.Enum;

namespace PetApp.Business.Services.Interfaces
{
    public interface IService<T>
    {
        Task<List<T>> GetSpendingsAsync();
        Task<T> GetSpendingAsync(int modelId);
        Task InsertSpendingAsync(T model);
        Task UpdateSpendingAsync(T model);
        Task DeleteSpendingAsync(int modelId);
    }
}
