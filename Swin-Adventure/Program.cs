using System;

namespace Swin_Adventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = InitPlayer();
            RecurringCommands(player);
        }

        static Player InitPlayer()
        {
            Location l1 = new Location(new string[] { "base" }, "Base", "A Starting Point For All Players.");
            Location l2 = new Location(new string[] { "secret" }, "Secret Room", "A Room Of Hidden Mysteries");
            Location l3 = new Location(new string[] { "cave" }, "Cave", "An Ancient Cave Full Of Suprises");
            l1.AddPath(new Path(new string[] { "north" }, "North", "a small door", l2));
            l1.AddPath(new Path(new string[] { "south" }, "South", "a grassland", l3));
            l2.AddPath(new Path(new string[] { "south" }, "South", "a small door", l1));
            l3.AddPath(new Path(new string[] { "north" }, "North", "a grassland", l1));
            return CreatePlayer(l1);
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
            Processor cmdProcessor = new Processor(); string response = "";
            Console.WriteLine("Starting Location: " + player.Location.ShortDescription);
            while (response != Quit.QuitMessage)
            {
                Console.Write("Command> ");
                string[] command = Console.ReadLine().Trim().Split(' ');
                response = cmdProcessor.Execute(player, command);
                Console.WriteLine(response);
            }
        }
    }
}
