using System;
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.UnitTests
{
    [TestFixture]
    public class LocationTests
    {
        private readonly Program _sa;
        private Player p;

        public LocationTests()
        {
            _sa = new Program();
            p = new Player("Dan", "dunno man");
        }

        // Location unit tests
        [TestCase(new string[] { "house" }, "House", "It's a house")]
        [TestCase(new string[] { "cave" }, "Cave", "It's a cave")]
        [TestCase(new string[] { "atc101" }, "atc101", "S W I N B U R N E")]
        public void TestLocationAreYou(string[] ids, string name, string desc)
        {
            Location loc = new Location(ids, name, desc);
            Assert.IsTrue(loc.AreYou(ids[0]));
        }

        [TestCase(new string[] { "house" }, "House", "It's a house")]
        [TestCase(new string[] { "cave" }, "Cave", "It's a cave")]
        [TestCase(new string[] { "atc101" }, "atc101", "S W I N B U R N E")]
        public void PlayerInLocation(string[] ids, string name, string desc)
        {
            Location loc = new Location(ids, name, desc);

            p.EnterLocation(loc);

            Assert.AreEqual(p.CurrentLocation, loc);
        }

        [TestCase(new string[] { "house" }, "House", "It's a house")]
        [TestCase(new string[] { "cave" }, "Cave", "It's a cave")]
        [TestCase(new string[] { "atc101" }, "atc101", "S W I N B U R N E")]
        public void LocateInLocation(string[] ids, string name, string desc)
        {
            Location loc = new Location(ids, name, desc);
            loc.LocationInventory.Put(new Item(new string[] { "item" }, "item", "and item"));

            p.EnterLocation(loc);

            Assert.AreEqual(p.Locate("item").Name, "item");
        }

        [TestCase(new string[] { "house" }, "House", "It's a house")]
        [TestCase(new string[] { "cave" }, "Cave", "It's a cave")]
        [TestCase(new string[] { "atc101" }, "atc101", "S W I N B U R N E")]
        public void LocateNotInLocation(string[] ids, string name, string desc)
        {
            Location loc = new Location(ids, name, desc);
            loc.LocationInventory.Put(new Item(new string[] { "item" }, "item", "and item"));

            p.EnterLocation(loc);

            Assert.AreNotEqual(p.Locate("item").Name, "spaghetti");
        }

        [TestCase(new string[] { "house" }, "House", "It's a house")]
        [TestCase(new string[] { "cave" }, "Cave", "It's a cave")]
        [TestCase(new string[] { "atc101" }, "atc101", "S W I N B U R N E")]
        public void LocateInPlayer(string[] ids, string name, string desc)
        {
            Location loc = new Location(ids, name, desc);
            p.PlayerInventory.Put(new Item(new string[] { "item" }, "item", "and item"));

            p.EnterLocation(loc);

            Assert.AreEqual(p.Locate("item").Name, "item");
        }
    }
}