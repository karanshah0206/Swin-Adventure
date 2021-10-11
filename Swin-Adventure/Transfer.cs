namespace Swin_Adventure
{
    class Transfer : Command
    {
        public Transfer () : base (new string[] { "put", "take" })
        { }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 2) return "Error in take input";
            Item i = p.Locate(text[1]) as Item;
            if (i == null) return "Item named " + text[1] + " not found.";
            switch (text[0])
            {
                case "put": return Put(p, i); case "take": return Take(p, i);
                default: return "Error in take input.";
            }
        }

        private string Put(Player p, Item i)
        {
            if (!p.Inventory.HasItem(i.FirstId)) return p.Name + " does not have this item.";
            p.Inventory.Take(i.FirstId);
            p.Location.Inventory.Put(i);
            return p.Name + " put down the " + i.Name + ".";
        }

        private string Take(Player p, Item i)
        {
            if (!p.Location.Inventory.HasItem(i.FirstId)) return p.Location.Name + " does not have this item.";
            p.Location.Inventory.Take(i.FirstId);
            p.Inventory.Put(i);
            return p.Name + " took the " + i.Name + ".";
        }
    }
}
