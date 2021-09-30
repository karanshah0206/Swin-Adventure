namespace Swin_Adventure
{
    public class Player : Game, IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        private Location _currentLocation;

        public Player(string name, string desc, Location location) : base(new string[] { "me", "inventory" }, name, desc)
        { _currentLocation = location; }

        public Game Locate(string id)
        {
            if (this.AreYou(id)) { return this; }
            if (_inventory.HasItem(id)) { return _inventory.Fetch(id); }
            return _currentLocation.Locate(id); // returns null if item not found
        }

        public override string FullDescription
        {
            get {
                return "You are " + Name + " " + base.FullDescription + "\nYou are carrying:\n" + _inventory.ItemList;
            }
        }

        public Inventory Inventory
        { get { return _inventory; } }

        public Location Location
        {
            get { return _currentLocation; }
            set { _currentLocation = value; }
        }

    }
}
