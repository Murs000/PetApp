using Microsoft.EntityFrameworkCore;
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
        public Task<List<PetPost>> GetAsync() => _context.PetPosts.ToListAsync();
        public async Task<PetPost> GetAsync(int postId) => await _context.PetPosts.FindAsync([postId]);
        public async Task<List<PetPost>> GetAsync(PetType petType) => await _context.PetPosts.Where(x => x.PetType == petType).ToListAsync();
        public async Task InsertAsync(PetPost post) => await _context.PetPosts.AddAsync(post);
        public async Task UpdateAsync(PetPost post)
        {
            var postFromDb = await _context.PetPosts.FindAsync([post.Id]);
            if (postFromDb == null) return;
            postFromDb = new PetPost
            {
                Id = post.Id,
                Name = post.Name,
                Description = post.Description,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                Creator = await _context.Users.FindAsync([post.CreatorId]),
            };

        }
        public async Task DeleteAsync(int postId)
        {
            var spendingFromDb = await _context.PetPosts.FindAsync([postId]);
            if (spendingFromDb == null) return;
            _context.PetPosts.Remove(spendingFromDb);
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
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
