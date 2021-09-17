namespace Swin_Adventure
{
    public class Look : Command
    {
        public Look() : base(new string[] { "look" })
        { }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 3 && text.Length != 5) return "I don't know how to look at that.";
            if (text[0] != "look") return "Error in look input.";
            if (text[1] != "at") return "What do you want to look at?";
            if (text.Length == 5 && text[3] != "in") return "What do you want to look in?";

            IHaveInventory container;
            if (text.Length == 3) container = p;
            else container = FetchContainer(p, text[4]);

            if (container == null) return "I can't find the " + text[4] + ".";
            else return LookAtIn(text[2], container);
        }

        public IHaveInventory FetchContainer(Player p, string containerId)
        { return p.Locate(containerId) as IHaveInventory; }

        public string LookAtIn(string thingId, IHaveInventory container)
        {
            Game thing = container.Locate(thingId);
            if (thing == null) return "I can't find the " + thingId + ".";
            else return thing.FullDescription;
        }
    }
}
