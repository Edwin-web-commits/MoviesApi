using MoviesApi.Data;

namespace MoviesApi.IRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetDetails(int id);
    }
}