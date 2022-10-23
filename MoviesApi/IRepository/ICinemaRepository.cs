using MoviesApi.Data;

namespace MoviesApi.IRepository
{
    public interface ICinemaRepository : IGenericRepository<Cinema>
    {
        Task<Cinema> GetDetails(int id);
    }
}