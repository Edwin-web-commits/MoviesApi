using Microsoft.EntityFrameworkCore;

namespace MoviesApi.Data
{
    public class MoviesApiDbContext : DbContext
    {
        public MoviesApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>().HasData(

               new Movie
               {
                   Id = 1,
                   Name = "ShawShank Redemption",
                   Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                   ReleaseDate = DateTime.Now,
                   CategoryId = 1,
                   ImageUrl = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/5794/5794111_so.jpg",
                   Playdate = DateTime.Now,
                   CinemaId = 2,
               },
               new Movie
               {
                   Id = 2,
                   Name = "Breaking Bad",
                   Description = "A high school chemistry teacher diagnosed with inoperable lung cancer turns to manufacturing and selling methamphetamine in order to secure his family's future.",
                   ReleaseDate = DateTime.Now,
                   CategoryId = 2,
                   ImageUrl = "https://televisionpromos.com/wp-content/uploads/2013/07/Breaking-Bad-AMC-TV-series-Artwork.jpg",
                   Playdate = DateTime.Now,
                   CinemaId = 1,
               });

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Action"
                },
                new Category
                {
                    Id = 2,
                    Name = "Story Telling"
                }
            );
            modelBuilder.Entity<Cinema>().HasData(

                new Cinema
                {
                    Id = 1,
                    Name = "Apololo City",
                    City = "Johannesburg",
                    Address = "123 Jan Smuts,Braamfontein, Johannesburg"
                },
                new Cinema
                {
                    Id = 2,
                    Name = "Night Time",
                    City = "Johannesburg",
                    Address = "19 Mandela Street,BedfordView, Johannesburg"
                });
        }
    }
}