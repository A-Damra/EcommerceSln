using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers.Products
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IModelRepository productRepository;
        public ProductsController(IModelRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await productRepository.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct(Guid productGuid)
        {
            var data = await productRepository.GetByGuidAsync(productGuid);

            return Ok(data);
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            var result = await productRepository.CreateAsync(product);
            if (result > 0)
                return Ok(product);
            return BadRequest("Failed to create product.");
        }

        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            var result = await productRepository.UpdateAsync(product);
            if (result > 0)
                return Ok("Product updated successfully.");
            return BadRequest("Failed to update product.");
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(Guid productGuid)
        {
            var result = await productRepository.DeleteAsync(productGuid);
            if (result > 0)
                return Ok("Product deleted successfully.");
            return BadRequest("Failed to delete product.");
        }
    }
}
