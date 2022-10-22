using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApi.Data
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime Playdate { get; set; }
        public string ImageUrl { get; set; }

        [ForeignKey(nameof(CatergoryId))]
        public int CatergoryId { get; set; }

        public Category Category { get; set; }

        [ForeignKey(nameof(CinemaId))]
        public int CinemaId { get; set; }

        public Cinema Cinema { get; set; }
    }
}