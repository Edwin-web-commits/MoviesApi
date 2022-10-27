using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;
using MoviesApi.Exceptions;
using MoviesApi.IRepository;
using MoviesApi.Models.Category;

namespace MoviesApi.Controllers
{
    [Route("api/v{version:apiVersion}/categories")]
    [ApiController]
    [ApiVersion("2.0")]
    public class CategoriesV2Controller : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesV2Controller(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetManyCategoriesDto>>> GetCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var mappedCategories = _mapper.Map<List<GetManyCategoriesDto>>(categories);
            return Ok(mappedCategories);
        }

        [HttpGet("category/{id}")]
        public async Task<ActionResult<GetSingleCategoryDto>> GetCategory(int id)
        {
            var category = await _categoryRepository.GetDetails(id);

            if (category == null)
            {
                throw new NotFoundException(nameof(GetCategory), id);
            }
            var singleCategory = _mapper.Map<GetSingleCategoryDto>(category);
            return Ok(singleCategory);
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("updateCategory/{id}")]
        public async Task<IActionResult> PutCategory(int id, UpdateCategoryDto category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }
            var existingCategory = await _categoryRepository.GetAsync(id);
            if (existingCategory == null)
            {
                throw new NotFoundException(nameof(PutCategory), id);
            }
            var mappedCategory = _mapper.Map(category, existingCategory);

            //try
            //{
            //    await _categoryRepository.UpdateAsync(mappedCategory);
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!await CategoryExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            await _categoryRepository.UpdateAsync(mappedCategory);
            return NoContent();
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("createCategory")]
        public async Task<ActionResult<Category>> PostCategory(CreateCategoryDto category)
        {
            var mappedcategory = _mapper.Map<Category>(category);
            var newCategory = await _categoryRepository.AddAsync(mappedcategory);

            return CreatedAtAction("GetCategory", new { id = newCategory.Id }, category);
        }

        [HttpDelete("deleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetAsync(id);
            if (category == null)
            {
                throw new NotFoundException(nameof(DeleteCategory), id);
                //return NotFound();
            }

            await _categoryRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CategoryExists(int id)
        {
            return await _categoryRepository.Exists(id);
        }
    }
}