namespace MoviesApi.Models.Movie
{
    public class UpdateMovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime Playdate { get; set; }
        public string ImageUrl { get; set; }
    }
}