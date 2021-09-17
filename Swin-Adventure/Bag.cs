namespace Swin_Adventure
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory = new Inventory();

        public Bag(string[] idents, string name, string desc) : base(idents, name, desc)
        { }

        public Game Locate(string id)
        {
            if (this.AreYou(id)) return this;
            return _inventory.Fetch(id);
        }

        public override string FullDescription
        {
            get { return "In the " + Name + " you can see:\n" + _inventory.ItemList; }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }
    }
}
