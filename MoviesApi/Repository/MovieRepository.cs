using MoviesApi.Data;
using MoviesApi.IRepository;

namespace MoviesApi.Repository
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MoviesApiDbContext context) : base(context)
        {
        }
    }
}