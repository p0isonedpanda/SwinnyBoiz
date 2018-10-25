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
            GameObject output = null;
            switch (id)
            {
                case "me":
                case "inventory":
                    output = this;
                    break;
                
                default:
                    output = _inventory.Fetch(id);
                    break;
            }

            if (output == null && _currentLocation != null) output = _currentLocation.LocationInventory.Fetch(id);

            return output;
        }

        public void EnterLocation(Location newLoc)
        {
            if (_currentLocation != null) _currentLocation.Exit();
            newLoc.Enter(this);
            _currentLocation = newLoc;
        }
    }
}