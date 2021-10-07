using System.Collections.Generic;

namespace Swin_Adventure
{
    public class Location : Game, IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        private List<Path> _exitPaths = new List<Path>();
        private Path _entryPath;
        public Location(string[] ids, string name, string desc) : base (ids, name, desc)
        { _entryPath = null; }

        public Game Locate(string id)
        {
            if (this.AreYou(id)) { return this; }
            if (_inventory.HasItem(id)) { return _inventory.Fetch(id); }
            return null;
        }

        public Path FindExitPath(string id)
        {
            foreach (Path p in _exitPaths) if (p.AreYou(id)) return p;
            return null;
        }

        public void AddExitPath(Path path)
        { _exitPaths.Add(path); }

        public Path LeavePath
        {
            get { return _entryPath; }
            set { _entryPath = value; }
        }

        public Inventory Inventory
        { get { return _inventory; } }
    }
}
