using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.DTO;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryReponsitory _categoryReponsitory;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryReponsitory categoryReponsitory, IMapper mapper)
        {
            _categoryReponsitory = categoryReponsitory;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetPokemons()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_categoryReponsitory.GetCategories());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categories);
        }
        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int categoryId)
        {
            if (!_categoryReponsitory.CategoryExists(categoryId)) return NotFound();

            var category = _mapper.Map<CategoryDto>(_categoryReponsitory.GetCategory(categoryId));

            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(category);
        }
    }
}
