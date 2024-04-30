using PetApp.Data.DataAccess.SqlServer.Repositorys.Interfaces;
using PetApp.Data.Entity.Implementations;
using PetApp.Data.Enum;

namespace PetApp.Data.DataAccess.SqlServer.Repositorys.Implementations
{
    public class PetPostRepository : IPetPostRepository
    {
        private readonly PetAppDb _context;
        public PetPostRepository(PetAppDb context)
        {
            _context = context;
        }
        public List<PetPost> Get() => _context.PetPosts.ToList();
        public PetPost Get(int postId) => _context.PetPosts.First(p => p.Id == postId);
        public List<PetPost> Get (PetType petType) => _context.PetPosts.Where(x => x.PetType == petType).ToList();
        public int Insert(PetPost post)
        {
            _context.PetPosts.Add(post);
            _context.SaveChanges();

            return post.Id;
        } 
        public bool Update(PetPost post)
        {
            var postFromDb = _context.PetPosts.First(p => p.Id == post.Id);
            if (postFromDb == null) return false;

            postFromDb = new PetPost
            {
                Id = post.Id,
                Name = post.Name,
                Description = post.Description,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                Creator = _context.Users.First(u => u.Id == post.CreatorId),
            };

            _context.SaveChanges();

            return true;
        }
        public bool Delete(int postId)
        {
            var spendingFromDb = _context.PetPosts.First(p => p.Id == postId); 
            if (spendingFromDb == null) return false;

            _context.PetPosts.Remove(spendingFromDb);
            _context.SaveChanges();

            return true;
        }


        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
