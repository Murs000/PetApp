namespace PetAppData.DataAccess.SqlServer
{
    public class PetAppDb : DbContext
    {
        public PetAppDb(DbContextOptions<PetAppDb> options) : base(options) { }
        public DbSet<PetPost> PetPosts => Set<PetPost>();
        public DbSet<User> Users => Set<User>();
    }
}
