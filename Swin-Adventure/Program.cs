using System;

namespace Swin_Adventure
{
    class Program
    {
        static void Main(string[] args)
        {
            string name, desc;

            // Get Player Details
            do
            {
                Console.Clear();
                Console.Write("\x1b[1mEnter Player's Name:\x1b[0m ");
                name = Console.ReadLine().Trim();
                Console.Write("\x1b[1mEnter {0}'s Description:\x1b[0m ", name);
                desc = Console.ReadLine().Trim();
                Console.WriteLine("");
            } while (name == "" || desc == "");

            // Create Player Object + Add Basic Items
            Player player = new Player(name, desc);
            Item i1 = new Item(new string[] { "shovel" }, "Shovel", "Tool to dig or break boxes");
            Item i2 = new Item(new string[] { "sword" }, "Sword", "Weapon for self-defence");
            player.Inventory.Put(i1); player.Inventory.Put(i2);
            // Add A Bag
            Bag bag = new Bag(new string[] { "gembag" }, "Gem Bag", "Bag to store collected gems");
            player.Inventory.Put(bag);
            // Add A Gem To The Bag
            Item i3 = new Item(new string[] { "ruby" }, "Ruby Gem", "Priceless little red stone");
            bag.Inventory.Put(i3);

            // Loop Look Command
            Look look = new Look();
            while (true)
            {
                Console.Write("\x1b[1mCommand>\x1b[0m ");

                Console.ForegroundColor = ConsoleColor.Red;
                string[] command = Console.ReadLine().Trim().Split(' ');
                Console.ForegroundColor = ConsoleColor.Gray;

                string response = look.Execute(player, command);
                Console.WriteLine(response);
            }
        }
    }
}
