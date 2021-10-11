using System.Collections.Generic;

namespace Swin_Adventure
{
    public class Processor
    {
        private List<Command> _commands = new List<Command>();

        public Processor()
        {
            _commands.Add(new Look());
            _commands.Add(new Move());
            _commands.Add(new Transfer());
            _commands.Add(new Quit());
        }

        public string Execute(Player p, string[] text)
        {
            foreach (Command c in _commands) if (c.AreYou(text[0])) return c.Execute(p, text);
            return "Unidentified Command.";
        }
    }
}
