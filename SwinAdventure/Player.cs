using System;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;

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

        public Player(string name, string desc) : base (new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            switch (id)
            {
                case "me":
                    return this;
                
                case "inventory":
                    return this;

                default:
                    return _inventory.Fetch(id);
            }
        }
    }
}