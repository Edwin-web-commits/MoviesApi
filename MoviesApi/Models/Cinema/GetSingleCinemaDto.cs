using MoviesApi.Models.Movie;

namespace MoviesApi.Models.Cinema
{
    public class GetSingleCinemaDto : BaseCinemaDto
    {
        public int Id { get; set; }
        public List<GetSingleMovieDto> Movies { get; set; }
    }
}