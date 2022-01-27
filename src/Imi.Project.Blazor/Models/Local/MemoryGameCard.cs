namespace Imi.Project.Blazor.Models.Local
{
    public class MemoryGameCard
    {
        public int Number { get; set; }
        public string Color { get; set; }
        public string Image { get { return Flipped ? "Guitar" + Number.ToString() + ".PNG" : string.Empty; } }
        public bool Flipped { get; set; }
    }
}
