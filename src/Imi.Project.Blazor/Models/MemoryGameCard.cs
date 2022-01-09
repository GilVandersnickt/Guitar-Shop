using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Models
{
    public class MemoryGameCard
    {
        public int Number { get; set; }
        public string Color { get; set; }
        public string Image { get { return Flipped ? "Guitar" + Number.ToString() + ".PNG" : string.Empty; } }
        public bool Flipped { get; set; }
    }
}
