using NUnit.Framework;
using Swin_Adventure;

namespace NUnitTests
{
    [TestFixture]
    public class MoveCmdObjUnitTests
    {
        private Move move;
        private Player player;
        private Location start = new Location(new string[] { "base", "start" }, "Base", "A Starting Point For All Players.");
        private Location secretRoom = new Location(new string[] { "secret_room" }, "Secret Room", "A Room Of Hidden Mysteries.");
        private Location secretBathroom = new Location(new string[] { "secret_bathroom" } , "Secret Bathroom", "A Smelly Corner Of The Secret Room.");
        private Path lobby; private Path corridor;

        [SetUp]
        public void Setup()
        {
            move = new Move();
            lobby = new Path(new string[] { "north", "lobby" }, "Lobby", "Connects Base To Secret Room.", start, secretRoom);
            corridor = new Path(new string[] { "west", "corridor" }, "Corridor", "Connects Secret Room To Secret Bathroom.", secretRoom, secretBathroom);
            player = new Player("Odin", "A Norse God", start);
        }

        [Test]
        public void TestMoveToLocation()
        {
            Assert.AreEqual("You have moved to a Secret Room (secret_room)", move.Execute(player, new string[] { "move", "north" }));
            Assert.AreEqual("You have moved to a Secret Bathroom (secret_bathroom)", move.Execute(player, new string[] { "go", "west" }));
        }

        [Test]
        public void TestMoveToFalseLocation()
        {
            Assert.AreEqual("Path not found.", move.Execute(player, new string[] { "move", "somewhere" }));
            Assert.AreEqual("Path not found.", move.Execute(player, new string[] { "move", "" }));
            Assert.AreEqual("Path not found.", move.Execute(player, new string[] { "go", " " }));
            Assert.AreEqual("Path not found.", move.Execute(player, new string[] { "head", "123" }));
        }

        [Test]
        public void TestInvalidCommandSyntax()
        {
            Assert.AreEqual("Error in move input.", move.Execute(player, new string[] { "" }));
            Assert.AreEqual("Error in move input.", move.Execute(player, new string[] { "$_@#$" }));
            Assert.AreEqual("Error in move input.", move.Execute(player, new string[] { "testing" }));
            Assert.AreEqual("Error in move input.", move.Execute(player, new string[] { "testing", "again" }));
            Assert.AreEqual("Error in move input.", move.Execute(player, new string[] { "testing", "again", "and", "again" }));
        }
    }
}
