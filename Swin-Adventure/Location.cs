using System.Collections.Generic;

namespace Swin_Adventure
{
    public class Location : Game, IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        private List<Path> _exitPaths;
        private Path _entryPath;
        public Location(string[] ids, string name, string desc, Path entryPath) : base (ids, name, desc)
        { _entryPath = entryPath; }

        public Game Locate(string id)
        {
            if (this.AreYou(id)) { return this; }
            if (_inventory.HasItem(id)) { return _inventory.Fetch(id); }
            return null;
        }

        public Path FindPath(string id)
        {
            foreach (Path p in _exitPaths) if (p.AreYou(id)) return p;
            return null;
        }

        public void AddPath(Path path)
        { _exitPaths.Add(path); }

        public Path LeavePath
        { get { return _entryPath; } }

        public Inventory Inventory
        { get { return _inventory; } }
    }
}
