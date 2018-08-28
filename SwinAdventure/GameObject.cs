using System;

namespace SwinAdventure
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _description;
        private string _name;

        public string Name
        {
            get { return _name; }
        }

        public string ShortDescription
        {
            get
            {
                return _name + " (" + FirstID + ")";
            }
        }
        
        public virtual string LongDescription
        {
            get
            {
                return _description;
            }
        }

        public GameObject(string[] ids, string name, string desc) : base (ids)
        {
            _name = name;
            _description = desc;
        }
    }
}