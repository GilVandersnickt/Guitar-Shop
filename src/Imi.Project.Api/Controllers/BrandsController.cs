using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISubcategoryService _subcategoryService;

        public BrandsController(IBrandService brandService, IProductService productService, ICategoryService categoryService, ISubcategoryService subcategoryService)
        {
            _brandService = brandService;
            _productService = productService;
            _categoryService = categoryService;
            _subcategoryService = subcategoryService;
        }

        [HttpGet] 
        public async Task<IActionResult> Get() 
        { 
            var brands = await _brandService.ListAllAsync(); 
            return Ok(brands); 
        }
        [HttpGet("{id}")] 
        public async Task<IActionResult> Get(Guid id) 
        { var brand = await _brandService.GetByIdAsync(id); 
            if (brand == null) 
            { 
                return NotFound($"Brand with ID {id} does not exist"); 
            } 
            return Ok(brand); 
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetProductsFromBrand(Guid id)
        {
            var productResponseDtos = await _productService.GetByBrandIdAsync(id);
            return Ok(productResponseDtos);
        }

        [HttpGet("{id}/categories")]
        public async Task<IActionResult> GetCategoriesFromBrand(Guid id)
        {
            var categoryResponseDtos = await _categoryService.GetByBrandIdAsync(id);
            return Ok(categoryResponseDtos);
        }
        
        [HttpGet("{id}/subcategories")]
        public async Task<IActionResult> GetSubcategoriesFromBrand(Guid id)
        {
            var subcategoryResponseDtos = await _subcategoryService.GetByBrandIdAsync(id);
            return Ok(subcategoryResponseDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BrandRequestDto brandRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var brandResponseDto = await _brandService.AddAsync(brandRequestDto);

            return CreatedAtAction(nameof(Get), new { id = brandResponseDto.Id }, brandResponseDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(BrandRequestDto brandRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var brandResponseDto = await _brandService.UpdateAsync(brandRequestDto);
            return Ok(brandResponseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var artist = await _brandService.GetByIdAsync(id);
            if (artist == null)
            {
                return NotFound($"Brand with ID {id} does not exist");
            }
            await _brandService.DeleteAsync(id);
            return Ok();
        }
    }
}
