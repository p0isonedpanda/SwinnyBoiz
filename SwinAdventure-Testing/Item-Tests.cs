using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.UnitTests
{
    [TestFixture]
    public class ItemTests
    {
        private readonly Program _sa;

        public ItemTests()
        {
            _sa = new Program();
        }

        // Item unit tests
        [TestCase(new string[] { "sword" }, "Sword", "It a pointy boi")]
        [TestCase(new string[] { "wand", "stick" }, "Wand", "It a magic boi")]
        [TestCase(new string[] { "potion", "drink", "slurpy boi" }, "Potion", "It a slurpy boi")]
        public void TestItemIsIdentifiable(string[] idents, string name, string desc)
        {
            Item i = new Item(idents, name, desc);
            var result = false;
            foreach (string s in idents)
            {
                result = i.AreYou(s);
            }

            Assert.IsTrue(result);
        }

        [TestCase(new string[] { "sword" }, "Sword", "It a pointy boi", "Sword (sword)")]
        [TestCase(new string[] { "wand", "stick" }, "Wand", "It a magic boi", "Wand (wand)")]
        [TestCase(new string[] { "potion", "drink", "slurpy boi" }, "Potion", "It a slurpy boi", "Potion (potion)")]
        public void TestShortDescription(string[] idents, string name, string desc, string expected)
        {
            Item i = new Item(idents, name, desc);
            Assert.AreEqual(i.ShortDescription, expected);
        }

        [TestCase(new string[] { "sword" }, "Sword", "It a pointy boi")]
        [TestCase(new string[] { "wand", "stick" }, "Wand", "It a magic boi")]
        [TestCase(new string[] { "potion", "drink", "slurpy boi" }, "Potion", "It a slurpy boi")]
        public void TestFullDescription(string[] idents, string name, string desc)
        {
            Item i = new Item(idents, name, desc);
            Assert.AreEqual(i.LongDescription, desc);
        }
    }
}
