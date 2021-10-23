using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

    }
}
