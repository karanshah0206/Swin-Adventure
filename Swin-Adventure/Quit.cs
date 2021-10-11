namespace Swin_Adventure
{
    class Quit : Command
    {
        private static string _quitMessage = "See ya later!";
        public Quit() : base (new string[] { "quit", "exit" })
        { }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 1) return "Error in quit command.";
            if (text[0] == "exit" || text[0] == "quit") return _quitMessage;
            return "Error in quit command.";
        }

        public static string QuitMessage
        { get { return _quitMessage; } }
    }
}
