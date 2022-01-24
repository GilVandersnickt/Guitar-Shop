using Imi.Project.Mobile.Domain.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Interfaces
{
    public interface ICategoryService : ICrudService<Category>
    {
        Task<bool> AddImage(Guid id, Stream entity);
    }
}
