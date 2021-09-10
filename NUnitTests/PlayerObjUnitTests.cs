using NUnit.Framework;
using Swin_Adventure;

namespace NUnitTests
{
    [TestFixture]
    class PlayerObjUnitTests
    {
        private Player player;
        private Item i1 = new Item(new string[] { "shovel" }, "wooden shovel", "A Weak Digging Tool");
        private Item i2 = new Item(new string[] { "spear", "javelin" }, "jade spear", "A dead deity's priceless weapon");

        [SetUp]
        public void Setup()
        {
            player = new Player("Odin", "Widely Revered Mythical King of Norse Gods");
            player.Inventory.Put(i1);
            player.Inventory.Put(i2);
        }

        [Test]
        public void TestPlayerIsIdentifiable()
        {
            Assert.IsTrue(player.AreYou("me"));
            Assert.IsTrue(player.AreYou("inventory"));
            Assert.IsFalse(player.AreYou("Odin"), "Should Not Return True For An ID Not Contained By Player.");
        }

        [Test]
        public void TestPlayerLocateSelf()
        {
            Assert.AreEqual(player, player.Locate("me"));
            Assert.AreEqual(player, player.Locate("inventory"));
        }

        [Test]
        public void TestPlayerLocateItems()
        {
            Assert.AreEqual(i1, player.Locate("shovel"));
            Assert.AreEqual(i2, player.Locate("spear"));
            Assert.AreEqual(i2, player.Locate("javelin"));
        }

        [Test]
        public void TestPlayerLocateNull()
        {
            Assert.IsNull(player.Locate("Thor"));
            Assert.IsNull(player.Locate("spade"));
            Assert.IsNull(player.Locate("sword"));
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            Assert.AreEqual("You are Odin Widely Revered Mythical King of Norse Gods\nYou are carrying:\n\ta wooden shovel (shovel)\n\ta jade spear (spear)\n", player.FullDescription);
        }
    }
}
