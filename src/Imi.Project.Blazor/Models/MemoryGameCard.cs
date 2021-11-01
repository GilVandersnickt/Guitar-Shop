using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Models
{
    public class MemoryGameCard
    {
        public int number { get; set; }
        public string color { get; set; }
        public string image { get { return flipped ? "Guitar" + number.ToString() + ".PNG" : string.Empty; } }
        public bool flipped { get; set; }

    }
}
