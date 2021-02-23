using Leak.Application.Interfaces;
using Leak.Application.ViewModels.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> Add(CategoryViewModel categoryViewModel)
        {
            var validationResult = await _categoryService.Add(categoryViewModel);

            if (validationResult.IsValid)
                return Ok();

            return BadRequest(validationResult.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.Delete(new CategoryViewModel(id, ""));

            if (result.IsValid)
                return Ok();

            return BadRequest(result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryViewModel categoryViewModel)
        {
            var result = await _categoryService.Update(categoryViewModel);

            if (result.IsValid)
                return Ok();

            return BadRequest(result.Errors);
        }
    }
}
