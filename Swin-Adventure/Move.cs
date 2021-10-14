namespace Swin_Adventure
{
    public class Move : Command
    {
        public Move() : base(new string[] { "move", "head", "go", "leave" })
        { }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 2) return "Error in move input.";

            switch (text[0])
            {
                case "move": case "head": case "go": case "leave": return Traverse(p, p.Location.FindPath(text[1]));
                default: return "Error in move input.";
            }
        }

        private string Traverse(Player p, Path path)
        {
            if (path == null) return "Path not found.";
            if (!path.IsTraversable) return "Path is locked.";
            p.Location = path.Destination;
            return path.FullDescription;
        }
    }
}
