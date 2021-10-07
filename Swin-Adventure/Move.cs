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
                case "move": case "head": case "go": return MoveToLoc(p, p.Location.FindExitPath(text[1]));
                case "leave": return LeaveLoc(p, p.Location.FindEntryPath(text[1]));
                default: return "Error in move input.";
            }
        }

        private string MoveToLoc(Player p, Path path)
        {
            if (path == null) return "Path not found.";
            if (!path.IsTraversable) return "Path is locked.";
            p.Location = path.Desetination;
            return "You have moved to " + p.Location.ShortDescription;
        }

        private string LeaveLoc(Player p, Path path)
        {
            if (path == null) return "Exit path not found.";
            if (!path.IsTraversable) return "Path is locked.";
            p.Location = path.From;
            return "You have moved to " + p.Location.ShortDescription;
        }
    }
}
