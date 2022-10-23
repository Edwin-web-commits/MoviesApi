﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;
using MoviesApi.IRepository;
using MoviesApi.Models.Cinema;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICinemaRepository _cinemaRepository;

        public CinemasController(IMapper mapper, ICinemaRepository cinemaRepository)
        {
            _mapper = mapper;
            _cinemaRepository = cinemaRepository;
        }

        // GET: api/Cinemas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetManyCinemasDto>>> GetCinemas()
        {
            var cinemas = await _cinemaRepository.GetAllAsync();
            var records = _mapper.Map<List<GetManyCinemasDto>>(cinemas);

            return Ok(records);
        }

        // GET: api/Cinemas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetSingleCinemaDto>> GetCinema(int id)
        {
            var cinema = await _cinemaRepository.GetDetails(id);

            if (cinema == null)
            {
                return NotFound();
            }
            var record = _mapper.Map<GetSingleCinemaDto>(cinema);
            return Ok(record);
        }

        // PUT: api/Cinemas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCinema(int id, UpdateCinemaDto cinema)
        {
            if (id != cinema.Id)
            {
                return BadRequest();
            }

            var existingCinema = await _cinemaRepository.GetAsync(id);

            if (existingCinema == null)
            {
                return NotFound();
            }

            _mapper.Map(cinema, existingCinema);

            try
            {
                await _cinemaRepository.UpdateAsync(existingCinema);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CinemaExists(id))
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

        // POST: api/Cinemas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GetSingleCinemaDto>> PostCinema(CreateCinemaDto cinema)
        {
            var cinema_ = _mapper.Map<Cinema>(cinema);
            await _cinemaRepository.AddAsync(cinema_);

            return CreatedAtAction("GetCinema", new { id = cinema_.Id }, cinema);
        }

        // DELETE: api/Cinemas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCinema(int id)
        {
            var cinema = await _cinemaRepository.GetAsync(id);
            if (cinema == null)
            {
                return NotFound();
            }
            await _cinemaRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CinemaExists(int id)
        {
            return await _cinemaRepository.Exists(id);
        }
    }
}