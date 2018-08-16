using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.UnitTests
{
    [TestFixture]
    public class SwinAdventureTests
    {
        private readonly Program _sa;
        private SwinAdventure.IdentifiableObject identobj;

        public SwinAdventureTests()
        {
            _sa = new Program();
            identobj = new SwinAdventure.IdentifiableObject(new string[] { "yeet", "skrrt", "yote" });
        }

        [TestCase("yeet")]
        [TestCase("skrrt")]
        [TestCase("yote")]
        public void TestAreYou(string id)
        {
            var result = identobj.AreYou(id);
            Assert.IsTrue(result);
        }

        [TestCase("not")]
        [TestCase("in")]
        [TestCase("list")]
        public void TestNotAreYou(string id)
        {
            var result = identobj.AreYou(id);
            Assert.IsFalse(result);
        }

        [TestCase("YEET")]
        [TestCase("skRRT")]
        [TestCase("yOtE")]
        public void TestCaseSensitive(string id)
        {
            var result = identobj.AreYou(id);
            Assert.IsTrue(result);
        }

        [Test]
        public void TestFirstID()
        {
            var result = identobj.FirstID;
            Assert.AreEqual(result, "yeet");
        }

        [TestCase("hello")]
        [TestCase("world")]
        public void TestAddID(string id)
        {
            identobj.AddIdentifier(id);
            var result = identobj.AreYou(id);
            Assert.IsTrue(result);
        }
    }
}
