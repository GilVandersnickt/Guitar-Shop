using Imi.Project.Blazor.Models.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Interfaces
{
    public interface IBrandService
    {
        Task<List<BrandResponse>> Get();
    }
}
