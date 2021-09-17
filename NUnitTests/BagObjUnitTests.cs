using NUnit.Framework;
using Swin_Adventure;

namespace NUnitTests
{
    [TestFixture]
    public class BagObjUnitTests
    {
        private Bag _bag;

        [SetUp]
        public void Setup()
        {
            _bag = new Bag(new string[] { "b1", "bag1" }, "GunBag", "A Bag To Store Guns");
        }

        [Test]
        public void TestBagLocatesItems()
        {
            Item i1 = new Item(new string[] { "ak47" }, "AK47", "Assault Rifle");
            Item i2 = new Item(new string[] { "p90" }, "P90", "Small Machine Gun");
            Item i3 = new Item(new string[] { "glock" }, "Glock", "Serviceable Pistol");

            _bag.Inventory.Put(i1);
            _bag.Inventory.Put(i2);
            _bag.Inventory.Put(i3);

            Assert.AreEqual(i1, _bag.Locate("ak47"));
            Assert.AreEqual(i3, _bag.Locate("glock"));
            Assert.AreEqual(i2, _bag.Locate("p90"));
        }

        [Test]
        public void TestbagLocatesItself()
        {
            Assert.AreEqual(_bag, _bag.Locate("b1"));
            Assert.AreEqual(_bag, _bag.Locate("bag1"));
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            Assert.Null(_bag.Locate("random"));
            Assert.Null(_bag.Locate(""));
        }

        [Test]
        public void TestBagFullDescription()
        {
            Item i1 = new Item(new string[] { "ak47" }, "AK47", "Assault Rifle");
            Item i2 = new Item(new string[] { "p90" }, "P90", "Small Machine Gun");
            Item i3 = new Item(new string[] { "glock" }, "Glock", "Serviceable Pistol");

            _bag.Inventory.Put(i1);
            _bag.Inventory.Put(i2);
            _bag.Inventory.Put(i3);

            Assert.AreEqual("In the GunBag you can see:\n\ta AK47 (ak47)\n\ta P90 (p90)\n\ta Glock (glock)\n", _bag.FullDescription);
        }

        [Test]
        public void TestBagInBag()
        {
            Bag b2 = new Bag(new string[] {"b2", "bag2"}, "TestBag", "A Bag To Test Bag In Bag");
            Item i1 = new Item(new string[] { "ak47" }, "AK47", "Assault Rifle");
            Item i2 = new Item(new string[] { "p90" }, "P90", "Small Machine Gun");

            b2.Inventory.Put(i2);
            _bag.Inventory.Put(i1);
            _bag.Inventory.Put(b2);

            Assert.AreEqual(b2, _bag.Locate("b2"));
            Assert.AreEqual(b2, _bag.Locate("bag2"));
            Assert.AreEqual(i1, _bag.Locate("ak47"));
            Assert.Null(_bag.Locate("p90"), "Bag 1 Should Not Be Able To Locate Items In Bag 2");
        }
    }
}
