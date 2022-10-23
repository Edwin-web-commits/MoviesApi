using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;
using MoviesApi.IRepository;

namespace MoviesApi.Repository
{
    public class CinemaRepository : GenericRepository<Cinema>, ICinemaRepository
    {
        private readonly MoviesApiDbContext _context;

        public CinemaRepository(MoviesApiDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Cinema> GetDetails(int id)
        {
            return await _context.Cinemas.Include(cinema => cinema.Movies).FirstOrDefaultAsync(cinema => cinema.Id == id);
        }
    }
}