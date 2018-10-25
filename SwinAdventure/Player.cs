using System;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _currentLocation;

        public override string LongDescription
        {
            get
            {
                return "You are carrying:\n" + _inventory.ItemList;
            }
        }

        public Inventory PlayerInventory
        {
            get
            {
                return _inventory;
            }
        }

        public Location CurrentLocation
        {
            get
            {
                return _currentLocation;
            }
        }

        public Player(string name, string desc) : base (new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
            _currentLocation = null;
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id)) return this;
            else if (_inventory.HasItem(id)) return _inventory.Fetch(id);
            else return _currentLocation.LocationInventory.Fetch(id);
        }

        public void EnterLocation(Location newLoc)
        {
            _currentLocation.Exit();
            newLoc.Enter(this);
            _currentLocation = newLoc;
        }
    }
}