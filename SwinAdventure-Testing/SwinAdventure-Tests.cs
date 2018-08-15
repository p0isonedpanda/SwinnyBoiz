using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.UnitTests
{
    [TestFixture]
    public class SwinAdventureTests
    {
        private readonly Program _sa;

        public SwinAdventureTests()
        {
            _sa = new Program();
        }

        [TestCase("yeet")]
        [TestCase("skrrt")]
        [TestCase("yote")]
        public void IsAreYou(string id)
        {
            SwinAdventure.IdentifiableObject identobj = new SwinAdventure.IdentifiableObject(new string[] { "yeet", "skrrt", "yote" });

            var result = identobj.AreYou(id);
            Assert.IsTrue(result);
        }
    }
}
