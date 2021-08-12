using NUnit.Framework;
using Swin_Adventure;

namespace NUnitTests
{
    [TestFixture]
    public class IdentifiableObjUnitTests
    {
        private Identifiable _identifiableObject;

        [SetUp]
        public void Setup()
        {
            _identifiableObject = new Identifiable(new string[] { "id1", "id2" });
        }

        [Test]
        public void TestAreYou()
        {
            Assert.IsTrue(_identifiableObject.AreYou("id1"));
            Assert.IsTrue(_identifiableObject.AreYou("id2"));
        }

        [Test]
        public void TestAreYouNot()
        {
            Assert.IsFalse(_identifiableObject.AreYou("id3"));
            Assert.IsFalse(_identifiableObject.AreYou(""));
            Assert.IsFalse(_identifiableObject.AreYou(1.ToString()));
        }

        [Test]
        public void TestAreYouCaseSensitive()
        {
            Assert.IsTrue(_identifiableObject.AreYou("Id2"));
            Assert.IsTrue(_identifiableObject.AreYou("ID2"));
            Assert.IsTrue(_identifiableObject.AreYou("iD1"));
        }

        [Test]
        public void TestFirstID()
        {
            Assert.AreEqual("id1", _identifiableObject.FirstId);
        }

        [Test]
        public void TestAddID()
        {
            _identifiableObject.AddIdentifier("ID3");
            Assert.IsTrue(_identifiableObject.AreYou("id3"));
            Assert.IsTrue(_identifiableObject.AreYou("id2"));
            Assert.IsTrue(_identifiableObject.AreYou("id1"));
        }
    }
}