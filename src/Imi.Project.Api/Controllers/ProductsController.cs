using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.ListAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} does not exist");
            }
            return Ok(product);
        }

        [HttpPost]
        [Authorize(Policy = "SuperAdmin")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Post(ProductRequestDto productRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productResponseDto = await _productService.AddAsync(productRequestDto);

            return CreatedAtAction(nameof(Get), new { id = productResponseDto.Id }, productResponseDto);
        }

        [HttpPut]
        [Authorize(Policy = "SuperAdmin")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Put(ProductRequestDto productRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productResponseDto = await _productService.UpdateAsync(productRequestDto);
            return Ok(productResponseDto);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "SuperAdmin")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound($"ProductRequestDto with ID {id} does not exist");
            }
            await _productService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost("{id}/image"), HttpPut("{id}/image")]
        [Authorize(Policy = "SuperAdmin")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Image([FromRoute] Guid id, IFormFile image) 
        {
            var product = await _productService.AddOrUpdateImageAsync(id, image); 
            if (product == null) 
            { 
                return NotFound($"Product with ID {id} does not exist"); 
            } 
            return Ok(product); 
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string name)
        {
            if (name != null)
            {
                var products = await _productService.SearchAsync(name);
                if (products.Any())
                {
                    return Ok(products);
                }
                return NotFound($"There were no categories found that contain {name} in their name");
            }
            else
            {
                var products = await _productService.ListAllAsync();
                return Ok(products);
            }
        }

    }
}
