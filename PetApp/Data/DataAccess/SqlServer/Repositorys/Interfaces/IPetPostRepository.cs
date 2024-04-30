namespace PetApp.Data.DataAccess.SqlServer.Repositorys.Interfaces
{
    public interface IPetPostRepository : IDisposable
    {
        List<PetPost> Get();
        PetPost Get(int postId);
        List<PetPost> Get(PetType petType);
        int Insert(PetPost post);
        bool Update(PetPost post);
        bool Delete(int postId);
    }
}
