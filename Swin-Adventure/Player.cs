namespace Swin_Adventure
{
    public class Player : Game
    {
        private Inventory _inventory = new Inventory();

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        { }

        public Game Locate(string id)
        {
            if (this.AreYou(id)) { return this; }
            if (_inventory.HasItem(id)) { return _inventory.Fetch(id); }
            return null;
        }

        public override string FullDescription
        {
            get {
                return "You are " + Name + " " + base.FullDescription + "\nYou are carrying:\n" + _inventory.ItemList;
            }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }
    }
}
