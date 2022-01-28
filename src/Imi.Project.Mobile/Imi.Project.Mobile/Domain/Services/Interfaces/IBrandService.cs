using Imi.Project.Mobile.Domain.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Interfaces
{
    public interface IBrandService : ICrudService<Brand>
    {
        Task<bool> AddImage(Guid id, Stream entity);
    }
}
