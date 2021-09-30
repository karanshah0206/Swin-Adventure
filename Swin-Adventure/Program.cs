using System;

namespace Swin_Adventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Location loc = new Location(new string[] { "base" }, "Base", "A Starting Point For All Players.");
            string[] playerDetails = GetPlayerDetails();
            Player player = InitializePlayer(playerDetails[0], playerDetails[1], loc);
            Look look = new Look();

            while (true) {
                Console.Write("Command> ");
                string[] command = Console.ReadLine().Trim().Split(' ');
                string response = look.Execute(player, command);
                Console.WriteLine(response);
            }
        }

        static string[] GetPlayerDetails()
        {
            string name, desc;

            do {
                Console.Clear();

                Console.Write("Enter Player's Name: ");
                name = Console.ReadLine().Trim();

                Console.Write("Enter {0}'s Description: ", name);
                desc = Console.ReadLine().Trim();

                Console.WriteLine("");
            } while (name == "" || desc == "");

            return new string[] { name, desc };
        }

        static Player InitializePlayer(string name, string desc, Location loc)
        {
            Player player = new Player(name, desc, loc);

            Item i1 = new Item(new string[] { "shovel" }, "Shovel", "Tool to dig or break boxes");
            Item i2 = new Item(new string[] { "sword" }, "Sword", "Weapon for self-defence");
            Item i3 = new Item(new string[] { "ruby" }, "Ruby Gem", "Priceless little red stone");
            Bag bag = new Bag(new string[] { "gembag" }, "Gem Bag", "Bag to store collected gems");
            
            player.Inventory.Put(i1); player.Inventory.Put(i2);
            bag.Inventory.Put(i3); player.Inventory.Put(bag);

            return player;
        }
    }
}
