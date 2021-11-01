using Imi.Project.Blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Interfaces
{
    public interface IMemoryGameService
    {
        void StartGame();
        void ResetGame();
        Task Flip(MemoryGameCard card);
    }
}
