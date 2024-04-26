using Microsoft.EntityFrameworkCore;
using PetApp.Data.Entity.Implementations;

namespace PetApp.Data.DataAccess.SqlServer
{
    public class PetAppDb : DbContext
    {
        public PetAppDb(DbContextOptions<PetAppDb> options) : base(options) { }
        public DbSet<PetPost> PetPosts => Set<PetPost>();
        public DbSet<User> Users => Set<User>();
    }
}
