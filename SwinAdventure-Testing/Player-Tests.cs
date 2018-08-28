using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.UnitTests
{
    [TestFixture]
    public class PlayerTests
    {
        private readonly Program _sa;

        public PlayerTests()
        {
            _sa = new Program();
        }

        // Player unit tests
        [Test]
        public void TestPlayerIsIdentifiable()
        {
            Player p = new Player("Dan", "dunno man");
            Assert.IsTrue(p.AreYou("me") && p.AreYou("inventory"));
        }

        [TestCase(new string[] { "sword" }, "Sword", "It a pointy boi")]
        [TestCase(new string[] { "wand", "stick" }, "Wand", "It a magic boi")]
        [TestCase(new string[] { "potion", "drink", "slurpy boi" }, "Potion", "It a slurpy boi")]
        public void TestPlayerLocatesItems(string[] idents, string name, string desc)
        {
            var result = false;
            Player p = new Player("Dan", "dunno man");
            Item i = new Item(idents, name, desc);
            p.PlayerInventory.Put(i);
            GameObject fetched = p.Locate(idents[0]);
            if (i == fetched && p.PlayerInventory.HasItem(idents[0]))
            {
                result = true;
            }

            Assert.IsTrue(result);
        }

        [TestCase("me")]
        [TestCase("inventory")]
        public void TestPlayerLocatesItself(string id)
        {
            Player p = new Player("Dan", "dunno man");
            var result = p.Locate(id);
            Assert.AreEqual(result, p);
        }

        [TestCase("skrrt")]
        [TestCase("yeet")]
        [TestCase("yote")]
        public void TestPlayerLocatesNothing(string id)
        {
            Player p = new Player("Dan", "dunno man");
            var result = p.Locate(id);
            Assert.IsNull(result);
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            Player p = new Player("Dan", "dunno man");
            string expected =
                "You are carrying:\n" +
                "    Sword (sword)\n" +
                "    Wand (wand)\n" +
                "    Potion (potion)\n";
            p.PlayerInventory.Put(new Item(new string[] { "sword" }, "Sword", "It a pointy boi"));
            p.PlayerInventory.Put(new Item(new string[] { "wand", "stick" }, "Wand", "It a magic boi"));
            p.PlayerInventory.Put(new Item(new string[] { "potion", "drink", "slurpy boi" }, "Potion", "It a slurpy boi"));
            Assert.AreEqual(p.LongDescription, expected);
        }
    }
}
