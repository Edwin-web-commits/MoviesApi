using MoviesApi.Models.Movie;

namespace MoviesApi.Models.Category
{
    public class GetSingleCategoryDto : BaseCategoryDto
    {
        public int Id { get; set; }
        public List<GetSingleMovieDto> Movies { get; set; }
    }
}