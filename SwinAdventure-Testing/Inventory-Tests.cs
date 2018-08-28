using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.UnitTests
{
    [TestFixture]
    public class InventoryTests
    {
        private readonly Program _sa;

        public InventoryTests()
        {
            _sa = new Program();
        }

        // Inventory unit tests
        [Test]
        public void TestFindItem()
        {
            var result = true;
            Inventory inv = new Inventory();
            for (int i = 0; i < 100; i++)
            {
                inv.Put(new Item
                (
                    new string[] { "id" + i.ToString() },
                    "name" + i.ToString(),
                    "desc" + i.ToString()
                ));
            }

            for (int i = 0; i < 100; i++)
            {
                if (!inv.HasItem("id" + i.ToString()))
                {
                    result = false;
                    break;
                }
            }

            Assert.IsTrue(result);
        }

        [Test]
        public void TestNoItemFind()
        {
            var result = false;
            Inventory inv = new Inventory();
            for (int i = 0; i < 100; i++)
            {
                inv.Put(new Item
                (
                    new string[] { "id" + i.ToString() },
                    "name" + i.ToString(),
                    "desc" + i.ToString()
                ));
            }

            for (int i = 0; i < 100; i++)
            {
                if (!inv.HasItem("id"))
                {
                    result = true;
                    break;
                }
            }

            Assert.IsTrue(result);
        }

        [TestCase(new string[] { "sword" }, "Sword", "It a pointy boi")]
        [TestCase(new string[] { "wand", "stick" }, "Wand", "It a magic boi")]
        [TestCase(new string[] { "potion", "drink", "slurpy boi" }, "Potion", "It a slurpy boi")]
        public void TestFetchItem(string[] idents, string name, string desc)
        {
            var result = false;
            Item i = new Item(idents, name, desc);
            Inventory inv = new Inventory();
            inv.Put(i);
            Item fetched = inv.Fetch(idents[0]);
            if (i == fetched && inv.HasItem(idents[0]))
            {
                result = true;
            }

            Assert.IsTrue(result);
        }

        [TestCase(new string[] { "sword" }, "Sword", "It a pointy boi")]
        [TestCase(new string[] { "wand", "stick" }, "Wand", "It a magic boi")]
        [TestCase(new string[] { "potion", "drink", "slurpy boi" }, "Potion", "It a slurpy boi")]
        public void TestTakeItem(string[] idents, string name, string desc)
        {
            var result = false;
            Item i = new Item(idents, name, desc);
            Inventory inv = new Inventory();
            inv.Put(i);
            Item taken = inv.Take(idents[0]);
            if (i == taken && !inv.HasItem(idents[0]))
            {
                result = true;
            }

            Assert.IsTrue(result);
        }

        [Test]
        public void TestItemList()
        {
            Inventory inv = new Inventory();
            string expected =
                "    Sword (sword)\n" +
                "    Wand (wand)\n" +
                "    Potion (potion)\n";
            inv.Put(new Item(new string[] { "sword" }, "Sword", "It a pointy boi"));
            inv.Put(new Item(new string[] { "wand", "stick" }, "Wand", "It a magic boi"));
            inv.Put(new Item(new string[] { "potion", "drink", "slurpy boi" }, "Potion", "It a slurpy boi"));
            Assert.AreEqual(inv.ItemList, expected);
        }
    }
}
