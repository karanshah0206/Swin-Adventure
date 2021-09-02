using NUnit.Framework;
using Swin_Adventure;

namespace NUnitTests
{
    [TestFixture]
    public class InventoryObjUnitTests
    {
        private Inventory _inventory;
        Item i1 = new Item(new string[] { "shovel" }, "wooden shovel", "A Weak Digging Tool");
        Item i2 = new Item(new string[] { "spear", "javelin" }, "jade spear", "A dead deity's priceless weapon");

        [SetUp]
        public void Setup()
        {
            _inventory = new Inventory();
            _inventory.Put(i1);
            _inventory.Put(i2);
        }

        [Test]
        public void TestInventoryFindItem()
        {
            Assert.IsTrue(_inventory.HasItem("shovel"));
            Assert.IsTrue(_inventory.HasItem("javelin"));
            Assert.IsTrue(_inventory.HasItem("spear"));
            Assert.IsFalse(_inventory.HasItem("spade"), "Inventory Should Return False For Items It Does Not Contain.");
        }

        [Test]
        public void TestInventoryFetchItem()
        {
            Assert.AreEqual(i1, _inventory.Fetch("shovel"));
            Assert.IsTrue(_inventory.HasItem("shovel"), "Item Must Remain In Inventory After Fetch.");
        }

        [Test]
        public void TestInventoryTakeItem()
        {
            Assert.AreEqual(i2, _inventory.Take("javelin"));
            Assert.IsFalse(_inventory.HasItem("spear"), "Item Must Not Remain In Inventory After Take.");
        }

        [Test]
        public void TestInventoryItemList()
        {
            Assert.AreEqual("\ta wooden shovel (shovel)\n\ta jade spear (spear)\n", _inventory.ItemList);
        }
    }
}
