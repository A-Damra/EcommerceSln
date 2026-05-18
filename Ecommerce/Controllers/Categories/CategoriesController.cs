using Microsoft.AspNetCore.Mvc;
using Ecommerce.Domain.Entities;
using Ecommerce.Application.Interfaces;
namespace Ecommerce.API.Controllers.Categories
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IModelRepository categoryRepository;

        public CategoriesController(IModelRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await categoryRepository.GetAllAsync();

            return Ok(categories);
        }

        [HttpGet("GetCategory{guid}")]
        public async Task<IActionResult> GetCategory(Guid guid)
        {
            var category = await categoryRepository.GetByGuidAsync(guid);
            if (category == null)
                return NotFound();
            return Ok(category);
        }

        [HttpPost("InsertCategory")]
        public async Task<IActionResult> InsertCategory(Category categories)
        {
            var result = await categoryRepository.CreateAsync(categories);

            if (result > 0)
                return Ok(categories);
            else
                return BadRequest("Failed to create Category.");
        }

        [HttpPost("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(Category categories)
        {
            var result = await categoryRepository.UpdateAsync(categories);

            if (result > 0)
                return Ok("Category was updated");
            else
                return BadRequest("Failed to update Category.");
        }

        [HttpPost("DeleteCategory/{guid}")]
        public async Task<IActionResult> DeleteCategory(Guid guid)
        {
            var result = await categoryRepository.DeleteAsync(guid);

            if (result > 0)
                return Ok("Category was deleted");

            return BadRequest("Failed to delete Category.");
        }
    }
}
