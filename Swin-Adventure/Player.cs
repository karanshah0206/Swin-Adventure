using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
{
    class Player : Game
    {
        private Inventory _inventory = new Inventory();

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        { }

        public Game Locate(string id)
        { return null; }

        public override string FullDescription
        {
            get { return ""; }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }
    }
}
