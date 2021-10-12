using System;
using System.Windows.Forms;
using Swin_Adventure;

namespace Swin_Adventure_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Text = "=============== INITIALIZING ===============\r\n";
            Path p = CreatePath();
            Player player = CreatePlayer(p.From);
            textBox2.Text += "READY TO PLAY!\r\n";
            textBox2.Text += "\r\n=============== INTRODUCTION ===============\r\n";
            textBox2.Text += player.FullDescription.Replace("\n", "\r\n");
            textBox2.Text += "Starting location: " + player.Location.Name + "\r\n";
            textBox2.Text += "\r\n=============== QUERIES ===============\r\n";
        }

        private Path CreatePath()
        {
            Location start = new Location(new string[] { "base", "start" }, "Base", "A Starting Point For All Players.");
            Location secretRoom = new Location(new string[] { "secret" }, "Secret Room", "A Room Of Hidden Mysteries.");
            Path tunnel = new Path(new string[] { "north", "tunnel" }, "Tunnel", "Connects Base To Secret Room.", start, secretRoom);
            textBox2.Text += "Initialized paths...\r\n";
            return tunnel;
        }

        private Player CreatePlayer(Location loc)
        {
            Player player = new Player("Karan", "A Mighty Programmer", loc);
            InitializePlayer(player);
            textBox2.Text += "Initialized player...\r\n";
            return player;
        }

        private void InitializePlayer(Player player)
        {
            Item i1 = new Item(new string[] { "shovel" }, "Shovel", "Tool to dig or break boxes");
            Item i2 = new Item(new string[] { "sword" }, "Sword", "Weapon for self-defence");
            Item i3 = new Item(new string[] { "ruby" }, "Ruby Gem", "Priceless little red stone");
            Bag bag = new Bag(new string[] { "gembag" }, "Gem Bag", "Bag to store collected gems");

            player.Inventory.Put(i1); player.Inventory.Put(i2);
            bag.Inventory.Put(i3); player.Inventory.Put(bag);
        }
    }
}
