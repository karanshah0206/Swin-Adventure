using System;
using NUnit.Framework;
using Swin_Adventure;

namespace NUnitTests
{
    [TestFixture]
    public class IdentifiableObjUnitTests
    {
        private Object _identifiableObject;
        [SetUp]
        public void Setup()
        {
            _identifiableObject = new Identifiable(new string[] { });
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}