using AutoMapper;
using MoviesApi.Data;
using MoviesApi.Models.Category;
using MoviesApi.Models.Cinema;
using MoviesApi.Models.Movie;

namespace MoviesApi.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Movie, CreateMovieDto>().ReverseMap();
            CreateMap<Movie, GetManyMoviesDto>().ReverseMap();
            CreateMap<Movie, GetSingleMovieDto>().ReverseMap();
            CreateMap<Movie, UpdateMovieDto>().ReverseMap();

            CreateMap<Cinema, CreateCinemaDto>().ReverseMap();
            CreateMap<Cinema, GetSingleCinemaDto>().ReverseMap();
            CreateMap<Cinema, GetManyCinemasDto>().ReverseMap();
            CreateMap<Cinema, UpdateCinemaDto>().ReverseMap();

            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, GetSingleCategoryDto>().ReverseMap();
            CreateMap<Category, GetManyCategoriesDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        }
    }
}