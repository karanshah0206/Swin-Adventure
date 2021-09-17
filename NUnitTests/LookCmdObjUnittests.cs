using NUnit.Framework;
using Swin_Adventure;

namespace NUnitTests
{
    [TestFixture]
    class LookCmdObjUnittests
    {
        private Look lookCommand;
        private Player player;
        private Item i1 = new Item(new string[] { "shovel" }, "wooden shovel", "A Weak Digging Tool");
        private Item i2 = new Item(new string[] { "spear", "javelin" }, "jade spear", "A dead deity's priceless weapon");
        private Bag sBag = new Bag(new string[] { "b1", "bag1" }, "Spear Bag", "A bag that contains spears.");

        [SetUp]
        public void Setup()
        {
            lookCommand = new Look();
            player = new Player("Odin", "Widely Revered Mythical King of Norse Gods");
            player.Inventory.Put(i1);
            sBag.Inventory.Put(i2);
            player.Inventory.Put(sBag);
        }

        [Test]
        public void TestLookAtMe()
        {
        }
    }
}
