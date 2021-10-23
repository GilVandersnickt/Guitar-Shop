using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;

        public CategoriesController(ICategoryService categoryService, IProductService productService, IBrandService brandService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.ListAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound($"Category with ID {id} does not exist");
            }
            return Ok(category);
        }
        [HttpGet("{id}/products")] 
        public async Task<IActionResult> GetProductsFromCategory(Guid id) 
        { 
            var productResponseDtos = await _productService.GetByCategoryIdAsync(id); 
            return Ok(productResponseDtos); 
        }
        [HttpGet("{id}/brands")] 
        public async Task<IActionResult> GetBrandsFromCategory(Guid id) 
        { 
            var brandResponseDtos = await _brandService.GetByCategoryIdAsync(id); 
            return Ok(brandResponseDtos); 
        }
        [HttpPost]
        public async Task<IActionResult> Post(CategoryRequestDto categoryRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoryResponseDto = await _categoryService.AddAsync(categoryRequestDto);

            return CreatedAtAction(nameof(Get), new { id = categoryResponseDto.Id }, categoryResponseDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(CategoryRequestDto categoryRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoryResponseDto = await _categoryService.UpdateAsync(categoryRequestDto);
            return Ok(categoryResponseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound($"Category with ID {id} does not exist");
            }
            await _categoryService.DeleteAsync(id);
            return Ok();
        }
    }
}
