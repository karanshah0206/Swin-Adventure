using System;

namespace Swin_Adventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Path p = CreatePath();
            Player player = CreatePlayer(p.From);
            RecurringCommands(player);
        }

        static Path CreatePath()
        {
            Location start = new Location(new string[] { "base", "start" }, "Base", "A Starting Point For All Players.");
            Location secretRoom = new Location(new string[] { "secret" }, "Secret Room", "A Room Of Hidden Mysteries.");
            Path tunnel = new Path(new string[] { "north", "tunnel" }, "Tunnel", "Connects Base To Secret Room.", start, secretRoom);
            return tunnel;
        }

        static Player CreatePlayer(Location loc)
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

            Player player = new Player(name, desc, loc);
            InitializePlayer(player);
            return player;
        }

        static void InitializePlayer(Player player)
        {
            Item i1 = new Item(new string[] { "shovel" }, "Shovel", "Tool to dig or break boxes");
            Item i2 = new Item(new string[] { "sword" }, "Sword", "Weapon for self-defence");
            Item i3 = new Item(new string[] { "ruby" }, "Ruby Gem", "Priceless little red stone");
            Bag bag = new Bag(new string[] { "gembag" }, "Gem Bag", "Bag to store collected gems");
            
            player.Inventory.Put(i1); player.Inventory.Put(i2);
            bag.Inventory.Put(i3); player.Inventory.Put(bag);
        }

        static void RecurringCommands(Player player)
        {
            Look look = new Look();

            while (true)
            {
                Console.Write("Command> ");
                string[] command = Console.ReadLine().Trim().Split(' ');
                string response = look.Execute(player, command);
                Console.WriteLine(response);
            }
        }
    }
}
