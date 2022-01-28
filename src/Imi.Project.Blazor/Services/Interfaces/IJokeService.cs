using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Interfaces
{
    public interface IJokeService
    {
        Task<string> GetRandomJoke();
    }
}
