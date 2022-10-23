using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;
using MoviesApi.IRepository;

namespace MoviesApi.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly MoviesApiDbContext _context;

        public CategoryRepository(MoviesApiDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Category> GetDetails(int id)
        {
            return await _context.Categories.Include(category => category.Movies).FirstOrDefaultAsync(category => category.Id == id);
        }
    }
}