namespace Swin_Adventure
{
    public class Location : Game, IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        public Location(string[] ids, string name, string desc) : base (ids, name, desc)
        { }

        public Game Locate(string id)
        {
            if (this.AreYou(id)) { return this; }
            if (_inventory.HasItem(id)) { return _inventory.Fetch(id); }
            return null;
        }

        public Inventory Inventory
        { get { return _inventory; } }
    }
}
