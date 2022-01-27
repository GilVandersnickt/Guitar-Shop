using Imi.Project.Blazor.Enums;
using Imi.Project.Blazor.Models.Local;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Interfaces
{
    public interface IMemoryGameService
    {
        void StartGame();
        void ResetGame();
        Task Flip(MemoryGameCard card);
        Color[] GetRandomColorList();
    }
}
