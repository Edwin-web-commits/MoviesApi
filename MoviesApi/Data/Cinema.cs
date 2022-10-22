namespace MoviesApi.Data
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}