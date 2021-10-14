using System.Collections.Generic;

namespace Swin_Adventure
{
    public class Location : Game, IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        private List<Path> _paths = new List<Path>();

        public Location(string[] ids, string name, string desc) : base (ids, name, desc)
        { }

        public Game Locate(string id)
        {
            if (this.AreYou(id)) { return this; }
            if (_inventory.HasItem(id)) { return _inventory.Fetch(id); }
            return null;
        }

        public Path FindPath(string id)
        {
            foreach (Path p in _paths) if (p.AreYou(id)) return p;
            return null;
        }

        public void AddPath(Path path)
        { _paths.Add(path); }

        public override string FullDescription
        { get { return Name + " is " + base.FullDescription + "\nThis location contains:\n" + _inventory.ItemList; } }

        public Inventory Inventory
        { get { return _inventory; } }
    }
}
