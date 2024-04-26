using PetApp.Data.Entity.Implementations;
using PetApp.Data.Enum;

namespace PetApp.Data.DataAccess.SqlServer.Repositorys.Interfaces
{
    public interface IPetPostRepository : IDisposable
    {
        Task<List<PetPost>> GetAsync();
        Task<PetPost> GetAsync(int postId);
        Task<List<PetPost>> GetAsync(PetType petType);
        Task InsertAsync(PetPost post);
        Task UpdateAsync(PetPost post);
        Task DeleteAsync(int postId);
        Task SaveAsync();
    }
}
