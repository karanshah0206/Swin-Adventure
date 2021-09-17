using NUnit.Framework;
using Swin_Adventure;

namespace NUnitTests
{
    [TestFixture]
    class LookCmdObjUnittests
    {
        private Look lookCommand;
        private Player player;
        private Item i1 = new Item(new string[] { "gem" }, "ruby trinket", "A priceless magical gem");
        private Item i2 = new Item(new string[] { "spear", "javelin" }, "jade spear", "A dead deity's weapon");
        private Bag bag = new Bag(new string[] { "bag" }, "spear bag", "A bag that contains spears.");

        [SetUp]
        public void Setup()
        {
            lookCommand = new Look();
            player = new Player("Odin", "Widely Revered Mythical King of Norse Gods");
            player.Inventory.Put(i1);
            bag.Inventory.Put(i2);
            player.Inventory.Put(bag);
        }

        [Test]
        public void TestLookAtMe()
        {
            Assert.AreEqual(player.FullDescription, lookCommand.Execute(player, new string[] { "look", "at", "inventory" }));
            Assert.AreEqual(player.FullDescription, lookCommand.Execute(player, new string[] { "look", "at", "me" }));
        }

        [Test]
        public void TestLookAtGem()
        {
            Assert.AreEqual(i1.FullDescription, lookCommand.Execute(player, new string[] { "look", "at", "gem" }));
        }

        [Test]
        public void TestLookAtUnk()
        {
            Assert.AreEqual("I can't find the diamond.", lookCommand.Execute(player, new string[] { "look", "at", "diamond" }));
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            Assert.AreEqual(i1.FullDescription, lookCommand.Execute(player, new string[] { "look", "at", "gem", "in", "inventory" }));
            Assert.AreEqual(i1.FullDescription, lookCommand.Execute(player, new string[] { "look", "at", "gem", "in", "me" }));
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            Assert.AreEqual(i2.FullDescription, lookCommand.Execute(player, new string[] { "look", "at", "spear", "in", "bag" }));
            Assert.AreEqual(i2.FullDescription, lookCommand.Execute(player, new string[] { "look", "at", "javelin", "in", "bag" }));
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            Assert.AreEqual("I can't find the nobag.", lookCommand.Execute(player, new string[] { "look", "at", "javelin", "in", "nobag" }));
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            Assert.AreEqual("I can't find the gem.", lookCommand.Execute(player, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [Test]
        public void TestInvalidLook()
        {
            Assert.AreEqual("I don't know how to look at that.", lookCommand.Execute(player, new string[] { }));
            Assert.AreEqual("I don't know how to look at that.", lookCommand.Execute(player, new string[] { "testing" }));
            Assert.AreEqual("I don't know how to look at that.", lookCommand.Execute(player, new string[] { "testing", "for", "four", "words" }));
            Assert.AreEqual("Error in look input.", lookCommand.Execute(player, new string[] { "hello", "from", "Melbourne" }));
            Assert.AreEqual("What do you want to look at?", lookCommand.Execute(player, new string[] { "look", "randomly", "anywhere" }));
            Assert.AreEqual("What do you want to look in?", lookCommand.Execute(player, new string[] { "look", "at", "fish", "on", "sea" }));
        }
    }
}
