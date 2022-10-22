namespace MoviesApi.Models.Movie
{
    public class BaseMovieDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime Playdate { get; set; }
        public string ImageUrl { get; set; }
        public int CatergoryId { get; set; }
        public int CinemaId { get; set; }
    }
}