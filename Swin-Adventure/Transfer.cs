namespace Swin_Adventure
{
    class Transfer : Command
    {
        public Transfer () : base (new string[] { "put", "drop", "take", "pickup" })
        { }

        public override string Execute(Player p, string[] text)
        {
            Item i;
            if (text.Length == 2)
            {
                i = p.Locate(text[1]) as Item;
                if (i == null) return "Item named " + text[1] + " not found.";
                switch (text[0])
                {
                    case "put": case "drop": return Put(p, i);
                    case "take": case "pickup": return Take(p, i);
                    default: return "Error in transfer input.";
                }
            }
            else if (text.Length == 4) {
                Bag b = p.Locate(text[3]) as Bag;
                if (b == null) return text[3] + " not found.";
                i = b.Locate(text[1]) as Item;
                if (i == null) return "Item named " + text[1] + " not found.";
                switch (text[0])
                {
                    case "put": case "drop":
                        if (text[2] != "in") return "Error in transfer input.";
                        return Put(p, i, b);
                    case "take": case "pickup":
                        if (text[2] != "from") return "Error in transfer input.";
                        return Take(p, i, b);
                    default: return "Error in transfer input.";
                }
            }
            else return "Error in transfer input.";
        }

        private string Put(Player p, Item i, Bag b = null)
        {
            if (b == null)
            {
                if (!p.Inventory.HasItem(i.FirstId)) return p.Name + " does not have this item.";
                p.Inventory.Take(i.FirstId);
                p.Location.Inventory.Put(i);
            }
            else
            {
                if (!p.Inventory.HasItem(b.FirstId)) return p.Name + " does not have " + b.Name + ".";
                if (!b.Inventory.HasItem(i.FirstId)) return b.Name + " does not have " + i.Name + ".";
                b.Inventory.Take(i.FirstId);
                p.Location.Inventory.Put(i);
            }
            return p.Name + " put down the " + i.Name + ".";
        }

        private string Take(Player p, Item i, Bag b = null)
        {
            if (b == null)
            {
                if (!p.Location.Inventory.HasItem(i.FirstId)) return p.Location.Name + " does not have this item.";
                p.Location.Inventory.Take(i.FirstId);
                p.Inventory.Put(i);
            }
            else
            {
                if (!p.Location.Inventory.HasItem(b.FirstId)) return p.Location.Name + " does not have " + b.Name;
                if (!b.Inventory.HasItem(i.FirstId)) return b.Name + " does not have this item.";
                b.Inventory.Take(i.FirstId);
                p.Inventory.Put(i);
            }
            return p.Name + " took the " + i.Name + ".";
        }
    }
}
