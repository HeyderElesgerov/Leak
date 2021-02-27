using Leak.Application.Interfaces;
using Leak.Application.ViewModels.Category;
using Leak.UI.MVC.Dtos.Category;
using Leak.UI.MVC.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Leak.UI.MVC.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _categoryService.GetAllCategories());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _categoryService.GetCategory(id);

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryDto createcategorydto)
        {
            var createCategoryViewModel = CustomMapper.GetCreateCategoryViewModel(createcategorydto);
            var validationResult = await _categoryService.Add(createCategoryViewModel);

            if (validationResult.IsValid)
                return Ok();

            return BadRequest(validationResult.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.Delete(id);

            if (result.IsValid)
                return Ok();

            return BadRequest(result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            var updateCategoryViewModel = CustomMapper.GetUpdateCategoryViewModel(updateCategoryDto);
            var result = await _categoryService.Update(updateCategoryViewModel);

            if (result.IsValid)
                return Ok();

            return BadRequest(result.Errors);
        }
    }
}
