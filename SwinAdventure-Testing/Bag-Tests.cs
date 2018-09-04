using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.UnitTests
{
    [TestFixture]
    public class BagTests
    {
        private readonly Program _sa;

        public BagTests()
        {
            _sa = new Program();
        }

        //Bag unit tests
        [Test]
        public void TestBagLocatesItems()
        {
            Item i = new Item(new string[] { "sword" }, "Sword", "It a pointy boi");
            Bag b = new Bag(new string[] { "bag" }, "Bag", "It a baggy boi");
            b.BagInventory.Put(i);
            GameObject fetched = b.Locate("sword");
            var result = i == fetched && (b.Locate("sword") != null);
            Assert.IsTrue(result);
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            Item i = new Item(new string[] { "sword" }, "Sword", "It a pointy boi");
            Bag b = new Bag(new string[] { "bag" }, "Bag", "It a baggy boi");
            b.BagInventory.Put(i);
            var result = b.Locate("boi");
            Assert.IsNull(result);
        }

        [Test]
        public void TestBagLongDescription()
        {
            Item i = new Item(new string[] { "sword" }, "Sword", "It a pointy boi");
            Bag b = new Bag(new string[] { "bag" }, "Bag", "It a baggy boi");
            b.BagInventory.Put(i);
            string expected =
                "In the Bag you can see:\n" +
                "    Sword (sword)\n";
            Assert.AreEqual(b.LongDescription, expected);
        }

        [Test]
        public void TestBagInBag()
        {
            Item i1 = new Item(new string[] { "sword" }, "Sword", "It a pointy boi");
            Item i2 = new Item(new string[] { "wand" }, "Wand", "It a magic boi");
            Bag b1 = new Bag(new string[] { "bag1" }, "Bag1", "It the first baggy boi");
            Bag b2 = new Bag(new string[] { "bag2" }, "Bag2", "it the second baggu boi");
            b2.BagInventory.Put(i2);
            b1.BagInventory.Put(b2);
            b1.BagInventory.Put(i1);

            var result = b1.Locate("bag2") != null;
            result = b1.Locate("sword") != null;
            result = b1.Locate("wand") == null;
            Assert.IsTrue(result);
        }
    }
}