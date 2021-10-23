using Imi.Project.Api.Core.Interfaces.Repositories;
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
    public class SearchController : ControllerBase
    {
        private readonly IProductRepository _productRepository; 
        private readonly ICategoryRepository _categoryRepository; 
        private readonly ISubcategoryRepository _subcategoryRepository; 
        private readonly IBrandRepository _brandRepository; 
        public SearchController(IProductRepository productRepository, ICategoryRepository categoryRepository, ISubcategoryRepository subcategoryRepository, IBrandRepository brandrepository) 
        { 
            _productRepository = productRepository; 
            _categoryRepository = categoryRepository;
            _subcategoryRepository = subcategoryRepository;
            _brandRepository = brandrepository;
        }
    }
}
