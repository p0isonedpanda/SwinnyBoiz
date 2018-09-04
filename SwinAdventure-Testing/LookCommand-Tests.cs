using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.UnitTests
{
    [TestFixture]
    public class LookCommandTests
    {
        private readonly Program _sa;
        private LookCommand cmd;
        private Player p;

        public LookCommandTests()
        {
            _sa = new Program();
            cmd = new LookCommand();
            p = new Player("Daniel", "It's me!");
        }

        [TestCase(new string[] { "look", "at", "me" }, "You are carrying:\n    Gem (gem)\n    Bag (bag)\n")]
        [TestCase(new string[] { "look", "at", "inventory" }, "You are carrying:\n    Gem (gem)\n    Bag (bag)\n")]
        public void TestLookAtMe(string[] text, string expected)
        {
            var result = cmd.Execute(p, text);
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void TestLookAtGem()
        {
            p.PlayerInventory.Put(new Item(new string[] { "gem" }, "Gem", "A red gem, looks pree dope ngl"));
            var result = cmd.Execute(p, new string[] { "look", "at", "gem" });
            Assert.AreEqual(result, "A red gem, looks pree dope ngl");
        }

        [Test]
        public void TestLookAtUnk()
        {
            var result = cmd.Execute(p, new string[] { "look", "at", "yeet" });
            Assert.AreEqual(result, "I cannot find the yeet");
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            var result = cmd.Execute(p, new string[] { "look", "at", "gem", "in", "inventory" });
            Assert.AreEqual(result, "A red gem, looks pree dope ngl");
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            Bag b = new Bag(new string[] { "bag" }, "Bag", "It holds stuff I don't know what you want me to say");
            b.BagInventory.Put(new Item(new string[] { "gold" }, "Gold", "OwO sh-shiny??"));
            p.PlayerInventory.Put(b);
            var result = cmd.Execute(p, new string[] { "look", "at", "gold", "in", "bag" });
            Assert.AreEqual(result, "OwO sh-shiny??");
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            var result = cmd.Execute(p, new string[] { "look", "at", "gold", "in", "sack" });
            Assert.AreEqual(result, "I cannot find the sack");
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            var result = cmd.Execute(p, new string[] { "look", "at", "gem", "in", "bag" });
            Assert.AreEqual(result, "Cannot locate gem in bag");
        }

        [TestCase(new string[] { "yeet" }, "Error in look input")]
        [TestCase(new string[] { "look", "here" }, "What do you want to look at?")]
        [TestCase(new string[] { "look", "at", "gem", "so", "pretty" }, "What do you want to look in?")]
        public void TestInvalidLook(string[] text, string expected)
        {
            var result = cmd.Execute(p, text);
            Assert.AreEqual(result, expected);
        }
    }
}