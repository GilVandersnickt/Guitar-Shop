﻿using Imi.Project.Api.Infrastructure.Repositories.Interfaces;
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
    public class SubcategoriesController : ControllerBase
    {
        protected readonly ISubcategoryRepository _subcategoryRepository;
        public SubcategoriesController(ISubcategoryRepository categoryRepository)
        {
            _subcategoryRepository = categoryRepository;
        }
    }
}
