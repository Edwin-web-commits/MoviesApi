using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;
using MoviesApi.IRepository;
using MoviesApi.Models.Movie;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MoviesController(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetManyMoviesDto>>> GetMovies()
        {
            var movies = await _movieRepository.GetAllAsync();
            var mappedMovies = _mapper.Map<List<GetManyMoviesDto>>(movies);
            return Ok(mappedMovies);
        }

        [HttpGet("movie/{id}")]
        public async Task<ActionResult<GetSingleMovieDto>> GetMovie(int id)
        {
            var movie = await _movieRepository.GetAsync(id);

            if (movie == null)
            {
                return NotFound();
            }
            var singleMovie = _mapper.Map<GetSingleMovieDto>(movie);
            return Ok(singleMovie);
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("updateMovie/{id}")]
        public async Task<IActionResult> PutMovie(int id, UpdateMovieDto movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }
            var existingMovie = await _movieRepository.GetAsync(id);
            var mappedMovie = _mapper.Map(movie, existingMovie);

            try
            {
                await _movieRepository.UpdateAsync(mappedMovie);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("createMovie")]
        public async Task<ActionResult<Movie>> PostMovie(CreateMovieDto movie)
        {
            var mappedmovie = _mapper.Map<Movie>(movie);
            var newMovie = await _movieRepository.AddAsync(mappedmovie);

            return CreatedAtAction("GetMovie", new { id = newMovie.Id }, movie);
        }

        [HttpDelete("deleteMovie/{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _movieRepository.GetAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            await _movieRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> MovieExists(int id)
        {
            return await _movieRepository.Exists(id);
        }
    }
}