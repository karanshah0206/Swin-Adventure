using NUnit.Framework;
using Swin_Adventure;

namespace NUnitTests
{
    [TestFixture]
    public class ItemObjUnitTests
    {
        private Item _item;

        [SetUp]
        public void Setup()
        {
            _item = new Item(new string[] { "spear", "javelin" }, "jade spear", "A dead deity's priceless weapon");
        }

        [Test]
        public void TestItemIsIdentifiable()
        {
            Assert.IsTrue(_item.AreYou("spear"));
            Assert.IsTrue(_item.AreYou("javelin"));
            Assert.IsFalse(_item.AreYou("spade"), "Should Not Return True For An ID Not Contained By The Item.");
        }

        [Test]
        public void TestItemShortDescription()
        {
            Assert.AreEqual("a jade spear (spear)", _item.ShortDescription, "Short Description Should Have Format: 'a [name] ([firstID])'.");
        }

        [Test]
        public void TestItemFullDescription()
        {
            Assert.AreEqual("A dead deity's priceless weapon", _item.FullDescription, "Should return the description of the item as passed to constructor.");
        }
    }
}
