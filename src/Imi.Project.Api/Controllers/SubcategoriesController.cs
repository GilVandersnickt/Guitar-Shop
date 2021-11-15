using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriesController : ControllerBase
    {
        private readonly ISubcategoryService _subcategoryService;
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;

        public SubcategoriesController(ISubcategoryService subcategoryService, IProductService productService, IBrandService brandService)
        {
            _subcategoryService = subcategoryService;
            _productService = productService;
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var subcategories = await _subcategoryService.ListAllAsync();
            return Ok(subcategories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var subcategory = await _subcategoryService.GetByIdAsync(id);
            if (subcategory == null)
            {
                return NotFound($"Subcategory with ID {id} does not exist");
            }
            return Ok(subcategory);
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetProductsFromSubcategory(Guid id)
        {
            var productResponseDtos = await _productService.GetBySubcategoryIdAsync(id);
            return Ok(productResponseDtos);
        }

        [HttpGet("{id}/brands")]
        public async Task<IActionResult> GetBrandsFromSubcategory(Guid id)
        {
            var brandResponseDtos = await _brandService.GetBySubcategoryIdAsync(id);
            return Ok(brandResponseDtos);
        }

        [HttpPost]
        [Authorize(Policy = "SuperAdmin")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Post(SubcategoryRequestDto subcategoryRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var subcategoryResponseDto = await _subcategoryService.AddAsync(subcategoryRequestDto);

            return CreatedAtAction(nameof(Get), new { id = subcategoryResponseDto.Id }, subcategoryResponseDto);
        }

        [HttpPut]
        [Authorize(Policy = "SuperAdmin")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Put(SubcategoryRequestDto subcategoryRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var subcategoryResponseDto = await _subcategoryService.UpdateAsync(subcategoryRequestDto);
            return Ok(subcategoryResponseDto);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "SuperAdmin")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var subcategory = await _subcategoryService.GetByIdAsync(id);
            if (subcategory == null)
            {
                return NotFound($"Subcategory with ID {id} does not exist");
            }
            await _subcategoryService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string name)
        {
            if (name != null)
            {
                var subcategories = await _subcategoryService.SearchAsync(name);
                if (subcategories.Any())
                {
                    return Ok(subcategories);
                }
                return NotFound($"There were no subcategories found that contain {name} in their name");
            }
            else
            {
                var subcategories = await _subcategoryService.ListAllAsync();
                return Ok(subcategories);
            }
        }

    }
}
