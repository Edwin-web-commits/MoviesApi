using MoviesApi.Models.Movie;

namespace MoviesApi.Models.Cinema
{
    public class GetSingleCinema : BaseCinemaDto
    {
        public int Id { get; set; }
        public List<GetSingleMovieDto> Movies { get; set; }
    }
}