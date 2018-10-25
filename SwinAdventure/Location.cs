using System;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Player _p;

        public Inventory LocationInventory
        {
            get
            {
                return _inventory;
            }
        }

        public Location(string[] ids, string name, string desc) : base (ids, name, desc)
        {
            _inventory = new Inventory();
            _p = null;
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id)) return this;
            else return _p.PlayerInventory.Fetch(id);
        }

        public void Enter(Player p)
        {
            _p = p;
        }

        public void Exit()
        {
            _p = null;
        }
    }
}