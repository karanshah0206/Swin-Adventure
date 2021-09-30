using NUnit.Framework;
using Swin_Adventure;

namespace NUnitTests
{
    [TestFixture]
    class LocationObjUnitTests
    {
        private Location loc;
        private Item i1 = new Item(new string[] { "shovel" }, "wooden shovel", "A Weak Digging Tool");
        private Item i2 = new Item(new string[] { "spear", "javelin" }, "jade spear", "A dead deity's priceless weapon");

        [SetUp]
        public void Setup()
        {
            loc = new Location(new string[] { "base" }, "Base", "A Starting Point For All Players");
            loc.Inventory.Put(i1);
            loc.Inventory.Put(i2);
        }

        [Test]
        public void TestLocationIsIdentifiable()
        {
            Assert.AreEqual(loc, loc.Locate("base"));
        }

        [Test]
        public void TestLocationLocatesItems()
        {
            Assert.AreEqual(i1, loc.Locate("shovel"));
            Assert.AreEqual(i2, loc.Locate("spear"));
            Assert.AreEqual(i2, loc.Locate("javelin"));
        }

        [Test]
        public void TestLocationLocatesNull()
        {
            Assert.IsNull(loc.Locate(""));
            Assert.IsNull(loc.Locate(" "));
            Assert.IsNull(loc.Locate("123"));
            Assert.IsNull(loc.Locate("sword"));
        }

        [Test]
        public void TestLocationFullDescription()
        {
            Assert.AreEqual("A Starting Point For All Players", loc.FullDescription);
        }

        [Test]
        public void TestPlayerLocatesLocation()
        {
            Player player = new Player("Odin", "A Mythical God", loc);
            Assert.AreEqual(loc, player.Locate("base"));
        }

        [Test]
        public void TestPlayerLocatesItemsInLocation()
        {
            Player player = new Player("Odin", "A Mythical God", loc);
            Assert.AreEqual(i1, player.Locate("shovel"));
            Assert.AreEqual(i2, player.Locate("javelin"));
        }
    }
}
