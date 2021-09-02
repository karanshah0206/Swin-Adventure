using System.Collections.Generic;

namespace Swin_Adventure
{
    class Inventory
    {
        private List<Item> _items = new List<Item>();

        public Inventory()
        { }

        public bool HasItem(string id)
        { return false; }

        public void Put(Item itm)
        { }

        public Item Take(string id)
        { return _items[0]; }

        public Item Fetch(string id)
        { return _items[0]; }

        public string ItemList
        {
            get { return ""; }
        }
    }
}
